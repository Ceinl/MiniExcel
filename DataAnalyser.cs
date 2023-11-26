
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

public class DataAnalyser
{

    private bool AreValuesNumeric(TextBox[,] textBoxArray, int row, int column)
    {
        if (textBoxArray == null || row < 0 || row >= textBoxArray.GetLength(0) || column < 0 || column >= textBoxArray.GetLength(1))
        {
            return false;
        }

        for (int i = 0; i <= row; i++)
        {
            for (int j = 0; j <= column; j++)
            {
                if (!double.TryParse(textBoxArray[i, j]?.Text, out _))
                {
                    return false;
                }
            }
        }

        return true;
    }

}