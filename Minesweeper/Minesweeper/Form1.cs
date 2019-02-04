using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        private MinesweeperBoard board;
        private Stopwatch timer = new Stopwatch();
        private string difficulty = "";

        public Form1()
        {
            InitializeComponent();

            Icon = Properties.Resources.icon;

            minesweeperBoardControl.Enabled = false;

            if (SystemInformation.TerminalServerSession) return;

            var dgvType = minesweeperBoardControl.GetType();
            var pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);

            if (pi != null)
                pi.SetValue(minesweeperBoardControl, true, null);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var f = new AboutBox1())
            {
                f.ShowDialog();
            }
        }

        private void StartGame(int width, int height, int mines)
        {
            timer.Reset();

            cellsToShow = new HashSet<(int x, int y)>();
            shownCells = new HashSet<(int x, int y)>();

            minesweeperBoardControl.RowCount = 0;
            minesweeperBoardControl.ColumnCount = 0;

            minesweeperBoardControl.Enabled = true;

            SendMessage(minesweeperBoardControl.Handle, WM_SETREDRAW, false, 0);

            board = new MinesweeperBoard(width, height, mines);

            var list = new List<DataGridViewColumn>();

            for (var i = 0; i < width; i++)
            {
                var col = new DataGridViewDisableButtonColumn { Width = 25 };
                list.Add(col);
            }

            minesweeperBoardControl.Columns.AddRange(list.ToArray());
            minesweeperBoardControl.RowCount = height;

            SendMessage(minesweeperBoardControl.Handle, WM_SETREDRAW, true, 0);
            minesweeperBoardControl.Refresh();

            timer.Start();
        }

        private void StartGame(char[,] savedBoard, IEnumerable<(int x, int y)> shownCellSet)
        {
            timer.Reset();

            cellsToShow = new HashSet<(int x, int y)>();
            shownCells = new HashSet<(int x, int y)>(shownCellSet);

            minesweeperBoardControl.RowCount = 0;
            minesweeperBoardControl.ColumnCount = 0;

            minesweeperBoardControl.Enabled = true;

            SendMessage(minesweeperBoardControl.Handle, WM_SETREDRAW, false, 0);

            board = new MinesweeperBoard(savedBoard);

            var list = new List<DataGridViewColumn>();

            for (var i = 0; i < board.width; i++)
            {
                var col = new DataGridViewDisableButtonColumn { Width = 25 };
                list.Add(col);
            }

            minesweeperBoardControl.Columns.AddRange(list.ToArray());
            minesweeperBoardControl.RowCount = board.height;

            PropogateSavedBoard(shownCells);

            SendMessage(minesweeperBoardControl.Handle, WM_SETREDRAW, true, 0);
            minesweeperBoardControl.Refresh();

            timer.Start();
        }

        private void PropogateSavedBoard(HashSet<(int x, int y)> shownCellSet)
        {
            while (shownCellSet.Count > 0)
            {
                var (x, y) = (shownCellSet.First().x, shownCellSet.First().y);
                MinesweeperCellShown(x, y);

                shownCellSet.Remove((x, y));
            }
        }

        private HashSet<(int x, int y)> cellsToShow = new HashSet<(int x, int y)>();
        private HashSet<(int x, int y)> shownCells = new HashSet<(int x, int y)>();

        private void MinesweeperCellShown(int x, int y)
        {
            var thisCell = minesweeperBoardControl.Rows[y].Cells[x] as DataGridViewButtonDisableCell;

            if (thisCell.Enabled == false)
                // Cell has a flag or is already shown
                return;

            shownCells.Add((x, y));

            var bombs = board.CalculateNearbyBombs(x, y);

            switch (bombs)
            {
                case -1:
                    timer.Stop();
                    LoseGame(thisCell);
                    return;

                case 0:
                    thisCell.Value = "";
                    thisCell.Enabled = false;
                    ShowSurroundingCells((x, y));
                    break;

                default:
                    thisCell.Value = bombs.ToString();
                    thisCell.Enabled = false;
                    break;
            }
        }

        private void MinesweeperCellFlag(int x, int y)
        {
            if (shownCells.Contains((x, y)))
                return;

            var thisCell = minesweeperBoardControl.Rows[y].Cells[x] as DataGridViewButtonDisableCell;

            if (thisCell != null && thisCell.Value == "🚩")
            {
                thisCell.Value = "";
                thisCell.Enabled = true;
            }
            else
            {
                thisCell.Value = "🚩";
                thisCell.Enabled = false;
                // Stops accidental clicks
            }
        }

        private void ShowSurroundingCells((int x, int y) currentCellLocation)
        {
            var cells = board.GetSurroundingCells(currentCellLocation.x, currentCellLocation.y);

            cellsToShow.UnionWith(cells);
            cellsToShow.ExceptWith(shownCells);

            while (cellsToShow.Count > 0)
            {
                var cell = cellsToShow.First();
                cellsToShow.Remove(cell);
                MinesweeperCellShown(cell.x, cell.y);
            }
        }

        private void LoseGame(DataGridViewButtonDisableCell cellClicked)
        {
            if (cellClicked == null) throw new ArgumentNullException(nameof(cellClicked));

            minesweeperBoardControl.Enabled = false;

            cellClicked.Style.BackColor = Color.DarkRed;
            cellClicked.Style.ForeColor = Color.White;
            cellClicked.Selected = false;
            cellClicked.FlatStyle = FlatStyle.Flat;
            cellClicked.Style.Font = new Font("Segoe UI", 8);

            cellClicked.Value = "X";

            var ml = board.mineList;
            ml.Sort((x, y) => x.y.CompareTo(y.y));
            ml.Remove((cellClicked.ColumnIndex, cellClicked.RowIndex));

            ShowBombCells(ml);
        }

        private async Task ShowBombCells(List<(int x, int y)> mineList)
        {
            var cellCount = minesweeperBoardControl.ColumnCount * minesweeperBoardControl.RowCount;

            if (cellCount > 750)
            {
                Application.UseWaitCursor = true;
            }

            foreach (var (x, y) in mineList)
            {
                var mineCell = minesweeperBoardControl.Rows[y].Cells[x] as DataGridViewButtonDisableCell;


                mineCell.Value = "X";

                mineCell.Style.BackColor = Color.Red;
                mineCell.Style.ForeColor = Color.White;
                mineCell.FlatStyle = FlatStyle.Flat;
                mineCell.Style.Font = new Font("Segoe UI", 8);

                if (cellCount <= 400)
                    await Task.Delay(80);
                else if (cellCount <= 750)
                    await Task.Delay(40);
            }

            Application.UseWaitCursor = false;
            var time = timer.Elapsed;
            var timeText = time.Hours + "h " + time.Minutes + "m " + time.Seconds + "s " + time.Milliseconds + "ms";

            MessageBox.Show(
                $"You lost!\n" +
                $"\n" +
                $"Time: {timeText}\n" +
                $"Difficulty: {difficulty}\n" +
                $"Size: {minesweeperBoardControl.ColumnCount}x{minesweeperBoardControl.RowCount}\n" +
                $"Number of bombs: {board.mineList.Count + 1}", "You Lost", MessageBoxButtons.OK);
        }

        private  void WinGame()
        {
            Application.UseWaitCursor = false;
            var time = timer.Elapsed;
            var timeText = time.Hours + "h " + time.Minutes + "m " + time.Seconds + "s " + time.Milliseconds + "ms";

            MessageBox.Show(
                $"You WON!\n" +
                $"\n" +
                $"Time: {timeText}\n" +
                $"Difficulty: {difficulty}\n" +
                $"Size: {minesweeperBoardControl.ColumnCount}x{minesweeperBoardControl.RowCount}\n" +
                $"Number of bombs: {board.mineList.Count + 1}", "You Lost", MessageBoxButtons.OK);
        }

        private void beginnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficulty = "Beginner";
            StartGame(10, 10, 8); // 12.5 cells per bomb
        }

        private void intermediateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficulty = "Intermediate";
            StartGame(20, 15, 30); // 10 cells per bomb
        }

        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficulty = "Expert";
            StartGame(30, 25, 100); // 7.5 cells per bomb
        }

        private void insanityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficulty = "Insanity";
            StartGame(40, 30, 240); // 5 cells per bomb
        }

        private void whatTheHeckIsWrongWithYouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficulty = "Clinically Insane";
            StartGame(50, 40, 500); // 3 cells per bomb
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            SendMessage(minesweeperBoardControl.Handle, WM_SETREDRAW, false, 0);
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            SendMessage(minesweeperBoardControl.Handle, WM_SETREDRAW, true, 0);
            minesweeperBoardControl.Refresh();
        }

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        private void minesweeperBoardControl_MouseClick(object sender, MouseEventArgs e)
        {
            var x = minesweeperBoardControl.HitTest(e.X, e.Y).ColumnIndex;
            var y = minesweeperBoardControl.HitTest(e.X, e.Y).RowIndex;

            if (e.Button == MouseButtons.Left)
            {
                if (x >= 0 && y >= 0)
                {
                    MinesweeperCellShown(x, y);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (x >= 0 && y >= 0)
                {
                    MinesweeperCellFlag(x, y);
                }
            }
        }

        private void minesweeperBoardControl_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((board.width * board.height) - shownCells.Count == board.mineList.Count)
                WinGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var path = "";

            using (var s = new SaveFileDialog())
            {
                s.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                s.FileName = "Minesweeper Save File.swp";
                s.AddExtension = true;
                s.Filter = "Minesweeper Save File|*.swp";

                s.ShowDialog();

                path = Path.GetFullPath(s.FileName);
            }


            using (var sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                sw.WriteLine("[Board]");
                sw.Write(board.board.ToSaveString());

                sw.WriteLine("[ShownCells]");

                var result = new int[shownCells.Count,2];

                for (var i = 0; i < shownCells.Count; i++)
                {
                    var tuple = shownCells.First();
                    shownCells.Remove(tuple);
                    result[i, 0] = tuple.x;
                    result[i, 1] = tuple.y;
                }

                sw.Write(result.ToSaveString());
            }
        }

        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var path = "";

            using (var s = new OpenFileDialog())
            {
                s.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                s.FileName = "Minesweeper Save File.swp";
                s.AddExtension = true;
                s.Filter = "Minesweeper Save File|*.swp";

                s.ShowDialog();

                path = Path.GetFullPath(s.FileName);
            }

            var file = "";

            using (var sr = new StreamReader(path, Encoding.UTF8))
            {
                file = sr.ReadToEnd();
            }

            var save = file.Split(new[] {"[Board]"}, StringSplitOptions.RemoveEmptyEntries)[0].Split(new[] { "[ShownCells]" }, StringSplitOptions.RemoveEmptyEntries);

            var boardSave = (char[,]) (save[0].FromSaveString());
            var shownCellsSave = (int[,])(save[1].FromSaveString());

            var shownCellSet = new HashSet<(int x, int y)>();

            for (var set = 0; set < shownCellsSave.GetLength(0); set++)
            {
                shownCellSet.Add((shownCellsSave[set, 0], shownCellsSave[set, 1]));
            }

            StartGame(boardSave, shownCellSet);
        }
    }
}
