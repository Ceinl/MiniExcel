
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

public static class DataAnalyser
{

    public static bool AreValuesNumeric(TextBox[,] textBoxArray, int row, int column)
    {
        if (textBoxArray == null || row < 0 || row >= textBoxArray.GetLength(0) || column < 0 || column >= textBoxArray.GetLength(1))
        {
            MessageBox.Show("dsahfdsafasfaf");
            return false;
        }

        for (int i = 1; i <= row; i++)
        {
            for (int j = 1; j <= column; j++)
            {
                if (!double.TryParse(textBoxArray[i, j]?.Text, out _))
                {
                    MessageBox.Show("f");
                    return false;
                }
            }
        }

        return true;
    }

}