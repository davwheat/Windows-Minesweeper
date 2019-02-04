using System.Windows.Forms;

namespace Minesweeper
{
    public class DataGridViewDisableButtonColumn : DataGridViewButtonColumn
    {
        public DataGridViewDisableButtonColumn()
        {
            CellTemplate = new DataGridViewButtonDisableCell();
        }

        public sealed override DataGridViewCell CellTemplate
        {
            get => base.CellTemplate;
            set => base.CellTemplate = value;
        }
    }
}
