using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace MiniExcel
{
    internal static class SortingProcesor
    {

        public static TextBox[,] NumericSortingProcess(TextBox[,] originalArray)
        { 
            int[] LinedArray = FieldManipulator.ConvertTo1DArray(originalArray);

            Array.Sort(LinedArray);
            string test = "";
            for (int i = 0; i < LinedArray.Length; i++) 
            {
                test += LinedArray[i].ToString();
            }

            MessageBox.Show(test);

            return FieldManipulator.ConvertTo2DArray(LinedArray);
        }

    }
}
