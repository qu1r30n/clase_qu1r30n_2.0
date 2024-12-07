using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;
using clase_qu1r30n_2._0.sin_internet.sin_formularios.procesos;

namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.modelos
{
    internal class _01_modelo_compras
    {
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;

        var_fun_GG vf_GG = new var_fun_GG();
        operaciones_textos op_tex = new operaciones_textos();
        operaciones_arreglos op_arr = new operaciones_arreglos();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        string[] G_direcciones =
        {
            Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[1, 0]//"config\\inf\\inventario\\inventario.TXT",
        };



        _01_proceso_compras pr_Comp = new _01_proceso_compras();
        public string operacion_a_hacer(string proceso, string datos, string fecha_hora)
        {
            string info_a_retornar = null;

            string[] cant_datos = datos.Split(G_caracter_separacion_funciones_espesificas[2][0]);


            for (int i = 0; i < cant_datos.Length; i++)
            {
                string[] info_espliteada = cant_datos[i].Split(G_caracter_separacion[0][0]);
                switch (proceso)
                {
                    case "COMPRA":
                        info_a_retornar = pr_Comp.compras(G_direcciones[0], info_espliteada[0], info_espliteada[1], info_espliteada[2]);
                        break;
                    case "COMPRA_MAYOREO":

                        break;

                    case "COMPRA_CON_PROMOCION":

                        break;
                    case "CANCELAR":

                        break;
                    default:
                        info_a_retornar = "-1" + G_caracter_para_confirmacion_o_error[0] + "no existe ese PROCESO";
                        break;
                }

            }
            return info_a_retornar;
        }
    }
}
