using CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas;
using CLASE_QU1R30N_2.sin_internet.sin_formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE_QU1R30N_2.sin_internet.sin_formulario.procesos
{
    internal class _02_proc_productos_e_inventario
    {

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;
        operaciones_textos op_tex = new operaciones_textos();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        string[] G_solo_para_consultas_relacionadas_encontrar_el_id;

        principal enl_princ = new principal();


        public string extraer_inventario(string datos)
        {
            string info_a_retornar = null;
            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            return info_a_retornar;
        }


    }
}
