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
using CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas;

namespace CLASE_QU1R30N_2
{
    public partial class Form1 : Form
    {


        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;

        
        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        principal enl_princ = new principal();
        public Form1()
        {
            InitializeComponent();

            Poner_al_inicio inicio = new Poner_al_inicio();
            inicio.iniciar();

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
