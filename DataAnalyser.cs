
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

public static class DataAnalyser
{

    private static bool isNotNullCheck(TextBox[,] textBoxArray)
    {
        return true;
        if (textBoxArray != null) 
        {
            return true;
        }
        return false;
        
    }
    private static bool isNumericCheck(TextBox[,] textBoxArray)
    {

        return true;

        int rows = textBoxArray.GetLength(0);
        int columns = textBoxArray.GetLength(1);
        for (int i = 1; i <= rows; i++)
        {
            for (int j = 1; j <= columns; j++)
            {
                if (!double.TryParse(textBoxArray[i, j]?.Text, out _))
                {
                    MessageBox.Show("Valueis is not numeric");
                    return false;

                }
            }
        }

        return true;

    }

    public static bool Checker(TextBox[,] textBoxArray) 
    {
        if (isNotNullCheck(textBoxArray) && isNumericCheck(textBoxArray)) 
        {
            return true;
        }
        return false;
    }

    public static bool CheckerForString(TextBox[,] textBoxArray)
    {
        if (isNotNullCheck(textBoxArray))
        {
            return true;
        }
        return false;
    }

}