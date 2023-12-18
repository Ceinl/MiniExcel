
using MiniExcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

public static class DataManager
{
    public static void OpenResultWindow(string result)
    {
        PopUpWindow popUpWindow = new PopUpWindow();
        popUpWindow.OutputContent(result);
        popUpWindow.SetEvent(popUpWindow.OutputAction);
        popUpWindow.Show();
        
    }

    //.......................... Методи виклику числових операцій .........................//

    public static TextBox[,] NumericSortCalling(TextBox[,] OriginalArray) 
    {
        if (DataAnalyser.Checker(OriginalArray)) 
        {
            return SortingProcesor.NumericSortingProcess(OriginalArray);
        }
        else 
        {
            MessageBox.Show("Error");
            return OriginalArray;
        }

    }

    public static void NumFilterCalling(TextBox[,] OriginalArray, int lowerbound, int higherbound)
    {
        if (DataAnalyser.Checker(OriginalArray))
        {
            OpenResultWindow(FilterProcesor.Filter(OriginalArray, lowerbound, higherbound));
        }
        else
        {
            MessageBox.Show("Error");
        }
    }
    public static void AvarageNumCalling(TextBox[,] OriginalArray) 
    {
        if (DataAnalyser.Checker(OriginalArray))
        {
            OpenResultWindow(FinderProcesor.AvarageFinder(OriginalArray).ToString());
        }
        else
        {
            MessageBox.Show("Error");
        }
    }

    public static void MaxNumCalling(TextBox[,] OriginalArray)
    {
        if (DataAnalyser.Checker(OriginalArray))
        {
            OpenResultWindow(FinderProcesor.MaxFinder(OriginalArray).ToString());
        }
        else
        {
            MessageBox.Show("Error");
        }
       
    }

    public static void MinNumCalling(TextBox[,] OriginalArray)
    {
        if (DataAnalyser.Checker(OriginalArray))
        {
            OpenResultWindow(FinderProcesor.MinFinder(OriginalArray).ToString());
        }
        else
        {
            MessageBox.Show("Error");
        }
    }

    //.......................... Методи виклику текстових операцій .........................//


    public static TextBox[,] LowerCaseCaller(TextBox[,] OriginalArray)
    {
        if (DataAnalyser.CheckerForString(OriginalArray))
        {
            return TextTransformerProcesor.lowerCaseConverter(OriginalArray);
        }
        else
        {
            MessageBox.Show("Error");
            return OriginalArray;
        }

    }

    public static TextBox[,] UpperCaseCaller(TextBox[,] OriginalArray)
    {
        if (DataAnalyser.CheckerForString(OriginalArray))
        {
            return TextTransformerProcesor.upperCaseConverter(OriginalArray);
        }
        else
        {
            MessageBox.Show("Error");
            return OriginalArray;
        }

    }

    public static TextBox[,] AbcSorterCalling(TextBox[,] OriginalArray)
    {
        if (DataAnalyser.CheckerForString(OriginalArray))
        {
            return TextSorterProcesor.AbcSorter(OriginalArray);
        }
        else
        {
            MessageBox.Show("Error");
            return OriginalArray;
        }
    }

    public static TextBox[,] LengthSorterCalling(TextBox[,] OriginalArray)
    {
        if (DataAnalyser.CheckerForString(OriginalArray))
        {
            return TextSorterProcesor.LengthSorter(OriginalArray);
        }
        else
        {
            MessageBox.Show("Error");
            return OriginalArray;
        }

    }

    public static TextBox[,] SearchByWord(TextBox[,] OriginalArray,string Parametr)
    {
        if (DataAnalyser.CheckerForString(OriginalArray))
        {
            return TextTransformerProcesor.WordSearcher(OriginalArray,Parametr);
        }
        else
        {
            MessageBox.Show("Error");
            return OriginalArray;
        }

    }

}


