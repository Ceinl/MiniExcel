using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MiniExcel
{
    internal static class FieldManipulator
    {
        #region Fields
        public static int[] UpdateFieldCoordinates = new int[4];
        #endregion

        #region PublicMethods
        public static void SetCoordinates(int RowStart, int ColumneStart, int RowEnd, int ColumneEnd) 
        {
            UpdateFieldCoordinates[0] = RowStart;
            UpdateFieldCoordinates[1] = ColumneStart;
            UpdateFieldCoordinates[2] = RowEnd;
            UpdateFieldCoordinates[3] = ColumneEnd;
        }

        public static TextBox[,] FieldConector(TextBox[,] OriginalTextBox, TextBox[,] UpdatedTextBox) 
        {
            return FieldOverlapping(OriginalTextBox, UpdatedTextBox);
        }

        public static TextBox[,] FieldSplitter(TextBox[,] FullTextBox)
        {
            int rows = UpdateFieldCoordinates[2] - UpdateFieldCoordinates[0] +1;
            int columns = UpdateFieldCoordinates[3] - UpdateFieldCoordinates[1] + 1;

            TextBox[,] CropetTextBox = new TextBox[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    CropetTextBox[i, j] = new TextBox
                    {
                        Text = FullTextBox[i + UpdateFieldCoordinates[0], j + UpdateFieldCoordinates[1]].Text,
                    };
                }
            }

            return CropetTextBox;
        }

        public static int[] ConvertTo1DArray(TextBox[,] originalArray)
        {

            int rows = 1 + UpdateFieldCoordinates[2] - UpdateFieldCoordinates[0];
            int columns = 1+ UpdateFieldCoordinates[3] - UpdateFieldCoordinates[1];

            int[] flattenedArray = new int[rows * columns];

            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (int.TryParse(originalArray[i, j].Text, out int value))
                    {
                        flattenedArray[index] = value;
                        index++;
                    }
                }
            }

            return flattenedArray;
        }

        public static TextBox[,] ConvertTo2DArray(int[] flattenedArray)
        {
            int rows = 1 + UpdateFieldCoordinates[2] - UpdateFieldCoordinates[0];
            int columns =  1 + UpdateFieldCoordinates[3] - UpdateFieldCoordinates[1];

            TextBox[,] resultArray = new TextBox[rows, columns];

            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    resultArray[j, i] = new TextBox
                    {
                        Text = flattenedArray[index].ToString()
                    };
                    index++;
                }
            }

            return resultArray;
        }

        public static string[] ConvertToString1DArray(TextBox[,] originalArray)
        {
            int rows = 1 + UpdateFieldCoordinates[2] - UpdateFieldCoordinates[0];
            int columns = 1 + UpdateFieldCoordinates[3] - UpdateFieldCoordinates[1];

            string[] flattenedArray = new string[rows * columns];

            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    flattenedArray[index] = originalArray[i, j].Text;
                    index++;
                }
            }

            return flattenedArray;
        }

        public static TextBox[,] ConvertTo2DArray(string[] flattenedArray)
        {
            int rows = 1 + UpdateFieldCoordinates[2] - UpdateFieldCoordinates[0];
            int columns = 1 + UpdateFieldCoordinates[3] - UpdateFieldCoordinates[1];

            TextBox[,] resultArray = new TextBox[rows, columns];

            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    resultArray[j, i] = new TextBox
                    {
                        Text = flattenedArray[index]
                    };
                    index++;
                }
            }

            return resultArray;
        }



        #endregion




        #region PrivateMethods
        private static TextBox[,] FieldOverlapping(TextBox[,] OriginalTextBox, TextBox[,] UpdatedTextBox)
        {
            int rowStartOverlapping = UpdateFieldCoordinates[0];
            int columnStartOverlapping = UpdateFieldCoordinates[1];

            int numberOfRows = UpdatedTextBox.GetLength(0);
            int numberOfColumns = UpdatedTextBox.GetLength(1);

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    OriginalTextBox[rowStartOverlapping + i, columnStartOverlapping + j].Text = UpdatedTextBox[i, j].Text;
                }
            }

            return OriginalTextBox;
        }


        #endregion

    }
}
