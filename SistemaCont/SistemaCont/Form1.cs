using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaCont
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private EstadosFinancieros ef = new EstadosFinancieros();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (c.SelectedIndex != -1 & a.Text!=null & Double.Parse(b.Text)!=null)
                {
                    d.Rows.Add(a.Text, c.SelectedItem.ToString(), b.Text);
                }
            }catch(Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                d.Rows.RemoveAt(d.SelectedCells[0].RowIndex);
            }catch(Exception ex)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            d.Rows.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRowIndex = d.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = d.Rows[selectedRowIndex];
                selectedRow.Cells[0].Value = a.Text;
                selectedRow.Cells[1].Value = c.SelectedItem.ToString();
                selectedRow.Cells[2].Value = b.Text;
            }catch(Exception ex)
            {

            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            // int selectedRowIndex = d.SelectedCells[0].RowIndex;
            //DataGridViewRow selectedRow = d.Rows[selectedRowIndex];
            f2 = new Form2();
            try
            {
                ef.add(contenido());
                f2.Datos(ef.cuentas("Activo"), ef.cuentas("Pasivo"));
                f2.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //MessageBox.Show(selectedRowIndex+" "+d.RowCount+" " + selectedRow.Cells[0].Value);
        }
        Form2 f2;
        private Cuenta[] contenido()
        {
            int i = 0;
            Cuenta[] ct = new Cuenta[d.RowCount];
            while(i != (d.RowCount - 1))
            {                DataGridViewRow selectedRow = d.Rows[i];
                ct[i] = new Cuenta(selectedRow.Cells[0].Value.ToString(), selectedRow.Cells[1].Value.ToString(),Double.Parse(selectedRow.Cells[2].Value.ToString()));
                i++;
            }
            return ct;
        }
        Form3 f3;
        private void button6_Click(object sender, EventArgs e)
        {
            f3 = new Form3();
            try
            {
                ef.add(contenido());
                f3.Datos(ef.cuentas("Venta"), ef.cuentas("Costo"),ef.cuentas("Gasto"));
                f3.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
