
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

public static class DataProcesor
{

    public static TextBox[,] SortArray(TextBox[,] array, int startRow, int startColumn, int endRow, int endColumn)
    {
        // Clone the array to avoid modifying the original array
        TextBox[,] sortedArray = (TextBox[,])array.Clone();

        // Bubble sort algorithm
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startColumn; j <= endColumn; j++)
            {
                for (int k = startRow; k <= endRow; k++)
                {
                    for (int l = startColumn; l <= endColumn - (k - startRow); l++)
                    {
                        double value1 = double.Parse(sortedArray[k, l].Text);
                        double value2 = double.Parse(sortedArray[i, j].Text);

                        if (value1 > value2)
                        {
                            // Swap TextBoxes if they are in the wrong order
                            TextBox temp = sortedArray[k, l];
                            sortedArray[k, l] = sortedArray[i, j];
                            sortedArray[i, j] = temp;
                        }
                    }
                }
            }
        }

        return sortedArray;
    }

    public static TextBox FindMaxValue(TextBox[,] array, int startRow, int startColumn, int endRow, int endColumn)
    {
        TextBox maxTextBox = array[startRow, startColumn]; // Assume the first element within the specified range as the initial maximum

        // Iterate through the specified range to find the maximum value
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startColumn; j <= endColumn; j++)
            {
                double currentValue = double.Parse(array[i, j].Text);

                // Compare with the current maximum value
                if (currentValue > double.Parse(maxTextBox.Text))
                {
                    maxTextBox = array[i, j];
                }
            }
        }

        return maxTextBox;
    }

    public static TextBox FindMinValue(TextBox[,] array, int startRow, int startColumn, int endRow, int endColumn)
    {
        TextBox minTextBox = array[startRow, startColumn]; // Assume the first element within the specified range as the initial minimum

        // Iterate through the specified range to find the minimum value
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startColumn; j <= endColumn; j++)
            {
                double currentValue = double.Parse(array[i, j].Text);

                // Compare with the current minimum value
                if (currentValue < double.Parse(minTextBox.Text))
                {
                    minTextBox = array[i, j];
                }
            }
        }

        return minTextBox;
    }

    public static TextBox[,] FilterArray(TextBox[,] array, double minValue, double maxValue, int startRow, int startColumn, int endRow, int endColumn)
    {
        // Calculate the dimensions of the filtered array
        int filteredRows = endRow - startRow + 1;
        int filteredColumns = endColumn - startColumn + 1;

        // Create a new array to store the filtered values
        TextBox[,] filteredArray = new TextBox[filteredRows, filteredColumns];

        // Iterate through the specified range and copy values within the specified range
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startColumn; j <= endColumn; j++)
            {
                double currentValue = double.Parse(array[i, j].Text);

                // Check if the value is within the specified range
                if (currentValue >= minValue && currentValue <= maxValue)
                {
                    // Create a new TextBox for the filtered array
                    filteredArray[i - startRow, j - startColumn] = new TextBox();
                    filteredArray[i - startRow, j - startColumn].Text = currentValue.ToString();
                }
                else
                {
                    // Set to null if the value is outside the range
                    filteredArray[i - startRow, j - startColumn] = null;
                }
            }
        }

        return filteredArray;
    }


    public static double CalculateAverage(TextBox[,] array, int startRow, int startColumn, int endRow, int endColumn)
    {
        double sum = 0;
        int count = 0;

        // Iterate through the specified range and calculate the sum of values
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startColumn; j <= endColumn; j++)
            {
                double currentValue = double.Parse(array[i, j].Text);
                sum += currentValue;
                count++;
            }
        }

        // Calculate the average
        double average = count > 0 ? sum / count : 0;
        return average;
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public static TextBox[,] ConvertTextToUppercase(TextBox[,] inputArray, int startRow, int startColumn, int endRow, int endColumn)
    {
        int rows = inputArray.GetLength(0);
        int columns = inputArray.GetLength(1);

        TextBox[,] resultArray = new TextBox[rows, columns];

        // Iterate through the specified range and convert text to uppercase
        for (int i = startRow; i <= endRow && i < rows; i++)
        {
            for (int j = startColumn; j <= endColumn && j < columns; j++)
            {
                resultArray[i, j] = new TextBox();
                resultArray[i, j].Text = inputArray[i, j].Text.ToUpper();
            }
        }

        return resultArray;
    }

    public static TextBox[,] ConvertTextToLowercase(TextBox[,] inputArray, int startRow, int startColumn, int endRow, int endColumn)
    {
        int rows = inputArray.GetLength(0);
        int columns = inputArray.GetLength(1);

        TextBox[,] resultArray = new TextBox[rows, columns];

        // Iterate through the specified range and convert text to lowercase
        for (int i = startRow; i <= endRow && i < rows; i++)
        {
            for (int j = startColumn; j <= endColumn && j < columns; j++)
            {
                resultArray[i, j] = new TextBox();
                resultArray[i, j].Text = inputArray[i, j].Text.ToLower();
            }
        }

        return resultArray;
    }

    public static TextBox[,] SortTextAlphabetically(TextBox[,] inputArray, int startRow, int startColumn, int endRow, int endColumn)
    {
        int rows = inputArray.GetLength(0);
        int columns = inputArray.GetLength(1);

        TextBox[,] resultArray = new TextBox[rows, columns];

        // Flatten the specified range of the array and sort the texts alphabetically
        var flattenedAndSortedTexts = inputArray
            .Cast<TextBox>()
            .Skip(startRow * columns + startColumn)
            .Take((endRow - startRow + 1) * columns)
            .OrderBy(tb => tb.Text)
            .Select((tb, index) => new { TextBox = tb, Index = index });

        // Reconstruct the sorted array within the specified range
        foreach (var item in flattenedAndSortedTexts)
        {
            int row = startRow + item.Index / columns;
            int col = startColumn + item.Index % columns;

            resultArray[row, col] = new TextBox();
            resultArray[row, col].Text = item.TextBox.Text;
        }

        return resultArray;
    }


    public static TextBox[,] SortTextByLength(TextBox[,] inputArray, int startRow, int startColumn, int endRow, int endColumn)
    {
        int rows = inputArray.GetLength(0);
        int columns = inputArray.GetLength(1);

        TextBox[,] resultArray = new TextBox[rows, columns];

        // Flatten the specified range of the array and sort the texts by length
        var flattenedAndSortedTexts = inputArray
            .Cast<TextBox>()
            .Skip(startRow * columns + startColumn)
            .Take((endRow - startRow + 1) * columns)
            .OrderBy(tb => tb.Text.Length)
            .Select((tb, index) => new { TextBox = tb, Index = index });

        // Reconstruct the sorted array within the specified range
        foreach (var item in flattenedAndSortedTexts)
        {
            int row = startRow + item.Index / columns;
            int col = startColumn + item.Index % columns;

            resultArray[row, col] = new TextBox();
            resultArray[row, col].Text = item.TextBox.Text;
        }

        return resultArray;
    }


    public static TextBox[] GetTextBoxesContainingWord(TextBox[,] inputArray, string word, int startRow, int startColumn, int endRow, int endColumn)
    {
        int rows = inputArray.GetLength(0);
        int columns = inputArray.GetLength(1);

        // Flatten the specified range of the array and filter TextBoxes containing the specified word
        var textBoxesWithWord = inputArray
            .Cast<TextBox>()
            .Skip(startRow * columns + startColumn)
            .Take((endRow - startRow + 1) * columns)
            .Where(tb => tb.Text.Contains(word))
            .ToArray();

        return textBoxesWithWord;
    }


}