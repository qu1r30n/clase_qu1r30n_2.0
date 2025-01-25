using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using CLASE_QU1R30N_2.sin_internet.sin_formularios;
using CLASE_QU1R30N_2.conexion.herramientas_internet;

namespace CLASE_QU1R30N_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Poner_al_inicio inicio = new Poner_al_inicio();

        }

        private void btn_proceso_Click(object sender, EventArgs e)
        {
            principal enl_princ = new principal();
            string info_resultado = null;

            conexiones con = new conexiones();


            while (true)
            {
                Thread.Sleep(2000);
                con.datos_recibidos_a_procesar_y_borrar();
            }

        }
    }
}
