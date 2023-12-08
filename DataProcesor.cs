
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

public class DataProcesor {

    public DataProcesor() 
    {

    }

    static TextBox[,] SortArray(TextBox[,] array, int rows, int columns)
    {
        // Clone the array to avoid modifying the original array
        TextBox[,] sortedArray = (TextBox[,])array.Clone();

        // Bubble sort algorithm
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns - 1; j++)
            {
                for (int k = 0; k < columns - j - 1; k++)
                {
                    double value1 = double.Parse(sortedArray[i, k].Text);
                    double value2 = double.Parse(sortedArray[i, k + 1].Text);

                    if (value1 > value2)
                    {
                        // Swap TextBoxes if they are in the wrong order
                        TextBox temp = sortedArray[i, k];
                        sortedArray[i, k] = sortedArray[i, k + 1];
                        sortedArray[i, k + 1] = temp;
                    }
                }
            }
        }

        return sortedArray;
    }

    static TextBox FindMaxValue(TextBox[,] array, int rows, int columns)
    {
        TextBox maxTextBox = array[0, 0]; // Assume the first element as the initial maximum

        // Iterate through the array to find the maximum value
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
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

    static TextBox FindMinValue(TextBox[,] array, int rows, int columns)
    {
        TextBox minTextBox = array[0, 0]; // Assume the first element as the initial minimum

        // Iterate through the array to find the minimum value
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
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
    static TextBox[,] FilterArray(TextBox[,] array, double minValue, double maxValue, int rows, int columns)
    {
        // Create a new array to store the filtered values
        TextBox[,] filteredArray = new TextBox[rows, columns];

        // Iterate through the array and copy values within the specified range
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
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
                    filteredArray[i, j] = null;
                }
            }
        }

        return filteredArray;
    }

    static double CalculateAverage(TextBox[,] array, int rows, int columns)
    {
        double sum = 0;

        // Iterate through the array and calculate the sum of values
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                double currentValue = double.Parse(array[i, j].Text);
                sum += currentValue;
            }
        }

        // Calculate the average
        double average = sum / (rows * columns);
        return average;
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    static TextBox[,] ConvertTextToUppercase(TextBox[,] inputArray, int rows, int columns)
    {
        TextBox[,] resultArray = new TextBox[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                resultArray[i, j] = new TextBox();
                resultArray[i, j].Text = inputArray[i, j].Text.ToUpper();
            }
        }

        return resultArray;
    }

    static TextBox[,] ConvertTextToLowercase(TextBox[,] inputArray, int rows, int columns)
    {
        TextBox[,] resultArray = new TextBox[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                resultArray[i, j] = new TextBox();
                resultArray[i, j].Text = inputArray[i, j].Text.ToLower();
            }
        }

        return resultArray;
    }

    static TextBox[,] SortTextAlphabetically(TextBox[,] inputArray, int rows, int columns)
    {
        TextBox[,] resultArray = new TextBox[rows, columns];

        // Flatten the array and sort the texts alphabetically
        var flattenedAndSortedTexts = inputArray
            .Cast<TextBox>()
            .OrderBy(tb => tb.Text)
            .Select((tb, index) => new { TextBox = tb, Index = index });

        // Reconstruct the sorted array
        foreach (var item in flattenedAndSortedTexts)
        {
            int row = item.Index / columns;
            int col = item.Index % columns;

            resultArray[row, col] = new TextBox();
            resultArray[row, col].Text = item.TextBox.Text;
        }

        return resultArray;
    }

    static TextBox[,] SortTextByLength(TextBox[,] inputArray, int rows, int columns)
    {
        TextBox[,] resultArray = new TextBox[rows, columns];

        // Flatten the array and sort the texts by length
        var flattenedAndSortedTexts = inputArray
            .Cast<TextBox>()
            .OrderBy(tb => tb.Text.Length)
            .Select((tb, index) => new { TextBox = tb, Index = index });

        // Reconstruct the sorted array
        foreach (var item in flattenedAndSortedTexts)
        {
            int row = item.Index / columns;
            int col = item.Index % columns;

            resultArray[row, col] = new TextBox();
            resultArray[row, col].Text = item.TextBox.Text;
        }

        return resultArray;
    }

    static TextBox[] GetTextBoxesContainingWord(TextBox[,] inputArray, string word)
    {
        // Flatten the array and filter TextBoxes containing the specified word
        var textBoxesWithWord = inputArray
            .Cast<TextBox>()
            .Where(tb => tb.Text.Contains(word))
            .ToArray();

        return textBoxesWithWord;
    }
}