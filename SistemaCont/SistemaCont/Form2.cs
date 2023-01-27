using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace SistemaCont
{
    public partial class Form2 : Form
    {
        private Cuenta[] cu,cu1;
        public Form2()
        {
            InitializeComponent();
        }
        public void Datos(Cuenta[] ct, Cuenta[] ct1)
        {
            cu = ct;
            cu1 = ct1;
        }
        public void metodo()
        {
                EstadosFinancieros ef = new EstadosFinancieros();
                ef.add(cu);
                foreach (Cuenta cc in cu)
                {
                    d.Rows.Add(cc.CUENTA, cc.TIPO, cc.SALDO);
                }
                d.Rows.Add("Total Activo", "", ef.sum(cu));
                foreach (Cuenta cc in cu1)
                {
                    d.Rows.Add(cc.CUENTA, cc.TIPO, cc.SALDO);
                }
                d.Rows.Add("Total Pasivo", "", ef.sum(cu1));
                d.Rows.Add("Capital", "", (ef.sum(cu) - ef.sum(cu1)));
            }
        private void button1_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
            MessageBox.Show("Por favor espere mientras guardamos");
            Application xlApp = new Application();
            Workbook xlWorkbook = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet xlWorksheet = (Worksheet)xlWorkbook.Worksheets[1];
            for (int i = 0; i < d.Rows.Count; i++)
            {
                for (int j = 0; j < d.Columns.Count; j++)
                {
                    xlWorksheet.Cells[i + 1, j + 1] = d.Rows[i].Cells[j].Value;
                }
            }
            xlWorkbook.SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ExcelC#.xlsx");
            xlWorkbook.Close();
            xlApp.Quit();
            MessageBox.Show("Listo");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            metodo();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
