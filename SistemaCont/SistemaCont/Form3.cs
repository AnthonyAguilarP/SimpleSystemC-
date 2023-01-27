using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace SistemaCont
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            metodo();
        }
        private Cuenta[] cu, cu1, cu2;

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

        public void Datos(Cuenta[] ct, Cuenta[] ct1, Cuenta[] ct2)
        {
            cu = ct;
            cu1 = ct1;
            cu2 = ct2;
        }
        public void metodo()
        {
            if (cu != null & cu1 != null)
            {
                EstadosFinancieros ef = new EstadosFinancieros();
                ef.add(cu);
                foreach (Cuenta cc in cu)
                {
                    d.Rows.Add(cc.CUENTA, cc.TIPO, cc.SALDO);
                }
                d.Rows.Add("Total Ventas", "", ef.sum(cu));
                foreach (Cuenta cc in cu1)
                {
                    d.Rows.Add(cc.CUENTA, cc.TIPO, cc.SALDO);
                }
                d.Rows.Add("Total Costos", "", ef.sum(cu1));
                d.Rows.Add("Margen de Contribucion", "", ef.sum(cu)-ef.sum(cu1));
                foreach (Cuenta cc in cu2)
                {
                    d.Rows.Add(cc.CUENTA, cc.TIPO, cc.SALDO);
                }
                d.Rows.Add("Total Gastos", "", ef.sum(cu2));
                d.Rows.Add("Utilidad", "", (ef.sum(cu) - ef.sum(cu1)-ef.sum(cu2)));
            }
            else MessageBox.Show("Se esperan datos de activo y pasivo");
        }
    }
}
