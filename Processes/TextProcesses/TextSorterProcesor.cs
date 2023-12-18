using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MiniExcel
{
    internal class TextSorterProcesor
    {
        public static TextBox[,] AbcSorter(TextBox[,] OriginalArray) 
        {
            string[] ListedArray= FieldManipulator.ConvertToString1DArray(OriginalArray);

            Array.Sort(ListedArray);

            return FieldManipulator.ConvertTo2DArray(ListedArray);

        }

        public static TextBox[,] LengthSorter(TextBox[,] OriginalArray)
        {
            string[] ListedArray = FieldManipulator.ConvertToString1DArray(OriginalArray).ToList().ToArray();

            Array.Sort(ListedArray, (x, y) => x.Length.CompareTo(y.Length));

            return FieldManipulator.ConvertTo2DArray(ListedArray);
        }
    }
}
