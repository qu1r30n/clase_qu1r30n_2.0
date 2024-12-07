using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;

namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.procesos
{
    internal class _07_proceso_sucursales
    {
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;

        var_fun_GG vf_GG = new var_fun_GG();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        Tex_base bas = new Tex_base();


        public string registrar_sucursal(string direccion_archivo, string datos, object caracter_separacion_obj = null)
        {

            string[] caracter_separacion_string = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string info_a_retornar = "";



            string resultado_archivo_aprendices_E = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo);
            string[] res_esp_archivo = resultado_archivo_aprendices_E.Split(G_caracter_para_confirmacion_o_error[0][0]);
            if (Convert.ToInt32(res_esp_archivo[0]) > 0)//si res es mayor a 0 la operacioon fue exitosa si no hubo un error
            {
                if (res_esp_archivo[0] == "1")
                {
                    int indice = Convert.ToInt32(res_esp_archivo[1]);
                    string texto_agregar = Tex_base.GG_base_arreglo_de_arreglos[indice].Length + caracter_separacion_string[0] + datos;


                    bas.Agregar(direccion_archivo, texto_agregar);


                    info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + texto_agregar;
                }

                else if (res_esp_archivo[0] == "2")
                {
                    int indice = Convert.ToInt32(res_esp_archivo[1]);
                    string texto_agregar = Tex_base.GG_base_arreglo_de_arreglos[indice].Length + G_caracter_para_confirmacion_o_error[0] + datos;
                    bas.Agregar(direccion_archivo, texto_agregar, false);
                    info_a_retornar = "2" + G_caracter_para_confirmacion_o_error[0] + texto_agregar;
                }
            }

            else
            {
                info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se encontro la direccion";
            }

            return info_a_retornar;
        }



    }
}
