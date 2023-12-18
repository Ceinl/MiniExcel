using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MiniExcel
{
    internal static class FilterProcesor
    {
        public static string Filter(TextBox[,] OriginalTextBox, int lowerBound, int upperBound)
        {
            int[] LinedArray = FieldManipulator.ConvertTo1DArray(OriginalTextBox);

            string result = "";

            for (int i = 0; i < LinedArray.Length; i++)
            {
                if (LinedArray[i] > lowerBound && LinedArray[i] < upperBound)
                {
                    result += LinedArray[i].ToString() + " ";
                }
            }

           return result;
        }

    }
}
