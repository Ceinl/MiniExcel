
using MiniExcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

public static class DataManager
{
    //1 метод для виклику вікна результату
    //1 метод на кожну дію
    public static void OpenResultWindow()
    {

    }

    public static void StartSortFunc(int startRow, int startColumn, int endRow, int endColumn) 
    {
        if (DataAnalyser.AreValuesNumeric(MainWindow.GetTextBoxes(), 2, 2))
        {
            DisplaySortedArray(MainWindow.GetTextBoxes(), endRow, endColumn);
            MainWindow.SetTextBoxes(DataProcesor.SortArray(MainWindow.GetTextBoxes(), 1, 1, endRow, endColumn));
        }

        else
            MessageBox.Show("dsahf");
    }

    public static void DisplaySortedArray(TextBox[,] array, int rows, int columns)
    {
        // Call the SortArray function to sort the array
        TextBox[,] sortedArray = DataProcesor.SortArray(array, 1, 1, rows, columns);

        // Build a string to display the sorted array
        StringBuilder resultMessage = new StringBuilder();
        resultMessage.AppendLine("Sorted Array:");

        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j < columns; j++)
            {
                resultMessage.Append(sortedArray[i, j].Text + "\t");
            }
            resultMessage.AppendLine();
        }

        // Display the result in a MessageBox
        MessageBox.Show(resultMessage.ToString(), "Sorted Array");
    }
}