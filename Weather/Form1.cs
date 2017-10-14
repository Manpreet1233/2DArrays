using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weather
{
    public partial class Form1 : Form
    {
        int[,] Temperature; // place holder for the 2D array


        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //generate random temperatures for 4 locations 
            //and for 1 week (Mon-Sun)

            //Initialise array size 
            Temperature = new int[4, 7]; //4 rows, 7 columns

            //set up random generator 
            Random Temp = new Random();
            
            //loop through each location (row)
            for (int i = 0; i < Temperature.GetLength(0); i++) {
                
                //loop through each day (column)
                for (int j = 0; j <Temperature.GetLength(1); j++) {

                    Temperature[i, j] = Temp.Next(-5, 10);
                }//column loop

            }//row loop

        }//end btn_Load

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            string Output = string.Empty; //""
            Output = Output + PadSpaces ("Location", 15) + PadSpaces("Monday", 15) + PadSpaces("Tuesday", 15) + PadSpaces("Wednesday", 15) + PadSpaces("Thursday", 15) + PadSpaces("Friday", 15) + PadSpaces("Saturday", 15) + PadSpaces("Sunday", 15) + "\n";
            Output = Output + PadSpaces("________", 15) + PadSpaces("_______", 15) + PadSpaces("________", 15) + PadSpaces("________", 15) + PadSpaces("________", 15) + PadSpaces("________", 15) + PadSpaces("________", 15) + PadSpaces("________", 15);
                        
            for (int i = 0; i < Temperature.GetLength(0); i++)
            { //loop through all the rows
                Output += "\n";
                Output = Output + PadSpaces("Location" + (i + 1), 15);

                for (int j = 0; j < Temperature.GetLength(1); j++)
                {
                    Output += PadSpaces(Temperature[i, j].ToString(), 15);
                }
            }
           
            lblOutput.Text = Output;
        }


        private string PadSpaces (string Word, int ColumnSize)
        {

            //this method returns a Word (text) padded with 
            //the number of spaces for a column 
            string NewWord = string.Empty;
            int Length = ColumnSize - Word.Length;

            for (int i = 0; i < Length; i++)
            {
                NewWord += " ";
            }
            NewWord = NewWord + Word; 

                return NewWord;
        }
    }
}
