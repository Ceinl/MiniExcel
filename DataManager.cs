
using MiniExcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

public static class DataManager
{
    //1 метод для виклику вікна результату
    //1 метод на кожну дію
    public static void OpenResultWindow()
    {

    }

    public static void StartSortFunc(int startRow, int startColumn, int endRow, int endColumn) 
    {
        if (DataAnalyser.AreValuesNumeric(MainWindow.GetTextBoxes(), 3, 3))
            MainWindow.SetTextBoxes(DataProcesor.SortArray(MainWindow.GetTextBoxes(), startRow, startColumn, endRow, endColumn));
        else
            MessageBox.Show("dsahf");
    }
}