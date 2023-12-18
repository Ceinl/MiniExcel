using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MiniExcel
{
    internal class TextTransformerProcesor
    { 
        public static TextBox[,] lowerCaseConverter(TextBox[,] OriginalTextBox)
        {
            string[] LinedArray = FieldManipulator.ConvertToString1DArray(OriginalTextBox);

            for (int i = 0; i < LinedArray.Length; i++) 
            {
                LinedArray[i] = LinedArray[i].ToLower();
            }

            return FieldManipulator.ConvertTo2DArray(LinedArray);

        }

        public static TextBox[,] upperCaseConverter(TextBox[,] OriginalTextBox) 
        {
            string[] LinedArray = FieldManipulator.ConvertToString1DArray(OriginalTextBox);

            for (int i = 0; i < LinedArray.Length; i++)
            {
                LinedArray[i] = LinedArray[i].ToUpper();
            }

            return FieldManipulator.ConvertTo2DArray(LinedArray);
        }
        
        public static TextBox[,] WordSearcher(TextBox[,] OriginalTextBox, string SearchedWord) 
        {
            string[] LinedArray = FieldManipulator.ConvertToString1DArray(OriginalTextBox);

            
            for (int i = 0; i < LinedArray.Length; i++) 
            {
                
                if (LinedArray[i].Contains(SearchedWord)) 
                {
                    LinedArray[i] = LinedArray[i].ToUpper();
                }

            }
            MessageBox.Show("Table cells with searched word transformed to upper case");
         return FieldManipulator.ConvertTo2DArray(LinedArray);
        }
    }
}
