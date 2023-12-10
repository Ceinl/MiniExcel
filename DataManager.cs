
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
    public static void OpenResultWindow(string result)
    {
        PopUpWindow popUpWindow = new PopUpWindow();
        popUpWindow.OutputContent(result);
        popUpWindow.SetEvent(popUpWindow.OutputAction);
        popUpWindow.Show();
    }

    public static void SortFunc(int startRow, int startColumn, int endRow, int endColumn)
    {
        if (DataAnalyser.AreValuesNumeric(MainWindow.GetTextBoxes(), endRow, endColumn))
        {
            var sortedArray = DataProcesor.SortArray(MainWindow.GetTextBoxes(), startRow, startColumn, endRow, endColumn);
            MainWindow.SetTextBoxes(sortedArray, startRow, startColumn, endRow, endColumn);
        }

        else
            MessageBox.Show("dsahf");
    }

    public static void FilterFunc(int startRow, int startColumn, int endRow, int endColumn, double minValue, double maxValue)
    {
        if (DataAnalyser.AreValuesNumeric(MainWindow.GetTextBoxes(), endRow, endColumn))
        {
            var filteredArray = DataProcesor.FilterArray(MainWindow.GetTextBoxes(), minValue, maxValue, startRow, startColumn, endRow, endColumn);
            MainWindow.SetTextBoxes(filteredArray, startRow, startColumn, endRow, endColumn);
        }
    }

    public static void MinFunc(int startRow, int startColumn, int endRow, int endColumn)
    {
        if (DataAnalyser.AreValuesNumeric(MainWindow.GetTextBoxes(), endRow, endColumn))
        {
            var result = DataProcesor.FindMinValue(MainWindow.GetTextBoxes(),startRow, startColumn, endRow, endColumn);
            OpenResultWindow(result.Text);
        }
    }

    public static void MaxFunc(int startRow, int startColumn, int endRow, int endColumn)
    {
        if (DataAnalyser.AreValuesNumeric(MainWindow.GetTextBoxes(), endRow, endColumn))
        {
            var result = DataProcesor.FindMaxValue(MainWindow.GetTextBoxes(), startRow, startColumn, endRow, endColumn);
            OpenResultWindow(result.Text);
        }
    }

    public static void AvarageFunc(int startRow, int startColumn, int endRow, int endColumn)
    {
        if (DataAnalyser.AreValuesNumeric(MainWindow.GetTextBoxes(), endRow, endColumn))
        {
            var result = DataProcesor.CalculateAverage(MainWindow.GetTextBoxes(), startRow, startColumn, endRow, endColumn);
            OpenResultWindow(result.ToString());
        }
    }

    

    public static void DisplayArray(TextBox[,] array, int rows, int columns)
    {
        // Call the SortArray function to sort the array
        TextBox[,] sortedArray = array;

        // Build a string to display the sorted array
        StringBuilder resultMessage = new StringBuilder();
        resultMessage.AppendLine("Sorted Array:");

        for (int i = 1; i <= rows; i++)
        {
            for (int j = 1; j <= columns; j++)
            {
                resultMessage.Append(sortedArray[i, j].Text + "\t");
            }
            resultMessage.AppendLine();
        }

        // Display the result in a MessageBox
        MessageBox.Show(resultMessage.ToString(), "Sorted Array");
    }
}