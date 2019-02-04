using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;

namespace Minesweeper
{
    static class MDArrayExtensions
    {
        public static void Fill(this char[,] array, char value)
        {
            for (var row = 0; row < array.GetLength(0); row++)
            {
                for (var column = 0; column < array.GetLength(1); column++)
                {
                    array[row, column] = value;
                }
            }
        }

        public static bool IsBomb(this char[,] board, int x, int y) => board[x, y] == 'X';
        
        public static string ToSaveString(this Array ar)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new SoapFormatter();
                formatter.Serialize(ms, ar);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public static object FromSaveString(this string s)
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(s)))
            {
                var formatter = new SoapFormatter();
                return formatter.Deserialize(ms) as Array;
            }
        }

        public static T FromSaveString<T>(this string s)
        {
            return (T)FromSaveString(s);
        }
    }
}
