using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Excel_Write
{
    public partial class Form1 : Form
    {
        private static Excel.Workbook MyBook = null;
        private static Excel.Application MyApp = null;
        private static Excel.Worksheet MySheet = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filepath = @"d:\dupa.xlsx";
            MyApp = new Excel.Application();
            MyApp.Visible = false;
            MyBook = MyApp.Workbooks.Open(filepath);
            MySheet = (Excel.Worksheet)MyBook.Sheets[1]; // Explicit cast is not required here
            Excel.Range cell = MySheet.Range[MySheet.Cells[1, 1], MySheet.Cells[4, 4]];
            foreach (Excel.Range item in cell)
            {
                item.Value = string.Format("row:{0:D2} col:{1:D2}", item.Row, item.Column);
            }
            MyBook.SaveAs(Filename: filepath);
            MyBook.Close();
        }
    }
}
