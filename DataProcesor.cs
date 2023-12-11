
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
        TextBox[,] sortedArray = CloneArray(array);

        // Selection sort algorithm
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startColumn; j <= endColumn; j++)
            {
                int minIndex = FindMinIndex(sortedArray, i, j, endRow, endColumn);

                // Swap TextBoxes
                TextBox temp = sortedArray[i, j];
                sortedArray[i, j] = sortedArray[minIndex / (endColumn + 1), minIndex % (endColumn + 1)];
                sortedArray[minIndex / (endColumn + 1), minIndex % (endColumn + 1)] = temp;
            }
        }

        return sortedArray;
    }

    private static int FindMinIndex(TextBox[,] array, int startRow, int startColumn, int endRow, int endColumn)
    {
        int minIndex = startRow * (endColumn + 1) + startColumn;
        double minValue = double.Parse(array[startRow, startColumn].Text);

        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = (i == startRow) ? startColumn + 1 : startColumn; j <= endColumn; j++)
            {
                double currentValue = double.Parse(array[i, j].Text);

                if (currentValue < minValue)
                {
                    minValue = currentValue;
                    minIndex = i * (endColumn + 1) + j;
                }
            }
        }

        return minIndex;
    }


    public static TextBox[,] CloneArray(TextBox[,] sourceArray)
    {
        int rows = sourceArray.GetLength(0);
        int columns = sourceArray.GetLength(1);

        TextBox[,] clonedArray = new TextBox[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                clonedArray[i, j] = new TextBox();
                if (sourceArray[i, j] != null)
                clonedArray[i, j].Text = sourceArray[i, j].Text;
            }
        }

        return clonedArray;
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
        TextBox[,] filteredArray = CloneArray(array);

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
                    filteredArray[i, j] = new TextBox();
                    filteredArray[i, j].Text = currentValue.ToString();
                }
                else
                {
                    // Set to null if the value is outside the range
                    filteredArray[i, j].Text = string.Empty;
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