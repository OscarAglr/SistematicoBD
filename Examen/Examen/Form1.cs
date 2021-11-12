using Examen.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen
{
    public partial class Form1 : Form
    {
        Model.Model m;
        ECont ec;
        public Form1()
        {
            InitializeComponent();
        }

        public void MostrarDatos()
        {
            try
            {
                m = new Model.Model();
                ec = new ECont();
                m.Anio = Convert.ToInt32(txtYear.Text);

                if (ec.MostrarTablas(m).Rows.Count == 0)
                {
                    MessageBox.Show("La tabla se mostrará vacía, ingrese otro dato");
                }

                dgvMain.DataSource = ec.MostrarTablas(m);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mainBtn_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void mainBtn_Enter(object sender, EventArgs e)
        {
        }
    }
}
