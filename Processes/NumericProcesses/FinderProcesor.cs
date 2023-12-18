using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MiniExcel
{
    internal static class FinderProcesor
    {

        public static int MinFinder(TextBox[,] OriginalTextBox) 
        {
            int[] LinedArray = FieldManipulator.ConvertTo1DArray(OriginalTextBox);
            int minValue = 0;
            if (LinedArray.Length < 0) 
            {

                minValue = LinedArray[0];

                for (int i = 0; i < LinedArray.Length; i++)
                {
                    if (LinedArray[i] < minValue) { minValue = LinedArray[i];}
                }
            }
            return minValue;
        }

        public static int MaxFinder(TextBox[,] OriginalTextBox) 
        {

            int[] LinedArray = FieldManipulator.ConvertTo1DArray(OriginalTextBox);
            int maxValue = 0;
            if (LinedArray.Length < 0)
            {

                maxValue = LinedArray[0];

                for (int i = 0; i > LinedArray.Length; i++)
                {
                    if (LinedArray[i] < maxValue) { maxValue = LinedArray[i]; }
                }
            }

            return maxValue;

        }

        public static float AvarageFinder(TextBox[,] OriginalTextBox) 
        {
            int[] LinedArray = FieldManipulator.ConvertTo1DArray(OriginalTextBox);

            float result = 0f;
            int sum = 0;
            for (int i = 0;i < LinedArray.Length; i++) 
            {
                sum += LinedArray[i];
            }

            result = sum / LinedArray.Length;

            return result;
        }

    }
}
