using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;


namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.procesos
{
    internal class _06_proceso_provedores
    {
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;

        var_fun_GG vf_GG = new var_fun_GG();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        operaciones_textos op_tex = new operaciones_textos();
        Tex_base bas = new Tex_base();




        public string registro_provedores_cod3_r_(string direccion_archivo, string datos, object caracter_separacion_obj = null)
        {
            string info_a_retornar = "";
            string[] caracter_separacion_string = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);

            string direccion_archivo_provedores = direccion_archivo;
            string resultado_archivo_provedores = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo_provedores);
            string[] res_esp_archivo_provedores = resultado_archivo_provedores.Split(G_caracter_para_confirmacion_o_error[0][0]);
            if (Convert.ToInt32(res_esp_archivo_provedores[0]) > 0)//si res es mayor a 0 la operacioon fue exitosa si no hubo un error
            {
                string[] datos_espliteado = datos.Split(caracter_separacion_string[0][0]);

                string ID_encargado = "";
                string resul_agregue = "";
                bool esta_arreglo = false;

                if (res_esp_archivo_provedores[0] == "1")
                {
                    int indic_aprendiz_E = Convert.ToInt32(res_esp_archivo_provedores[1]);
                    ID_encargado = "" + Tex_base.GG_base_arreglo_de_arreglos[indic_aprendiz_E].Length;
                    resul_agregue = "1";
                    esta_arreglo = true;
                }
                else if (res_esp_archivo_provedores[0] == "-1")
                {
                    ID_encargado = "" + bas.leer(direccion_archivo_provedores).Length;
                    resul_agregue = "2";
                    esta_arreglo = false;
                }
                else
                {
                    info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se encontro ";
                }


                string provedor_de_que_empresa = datos_espliteado[0];
                string cantidad_vendida = datos_espliteado[1];
                string Nombre_encargado = datos_espliteado[2];
                string Dirección_empresa = datos_espliteado[3];
                string Ciudad_empresa = datos_espliteado[4];
                string Estado_empresa = datos_espliteado[5];
                string Código_postal = datos_espliteado[6];
                string País = datos_espliteado[7];
                string Correo_electrónico = datos_espliteado[8];
                string Teléfono_encargado = datos_espliteado[9];
                string Telefono_empresa = datos_espliteado[10];
                string Tipo_de_proveedor = datos_espliteado[11];
                string Productos_Servicios_suministrados = datos_espliteado[12];
                string cuenta_Banco = datos_espliteado[13];
                string Ubicación_GPS = datos_espliteado[14];
                string Notas = datos_espliteado[15];
                string Recordatorio = datos_espliteado[16];
                string activo_o_no_activo = datos_espliteado[17];

                string datos_a_agregar = ID_encargado + caracter_separacion_string[0] + provedor_de_que_empresa + caracter_separacion_string[0] + Nombre_encargado + caracter_separacion_string[0] + Dirección_empresa + caracter_separacion_string[0] + Ciudad_empresa + caracter_separacion_string[0] + Estado_empresa + caracter_separacion_string[0] + Código_postal + caracter_separacion_string[0] + País + caracter_separacion_string[0] + Correo_electrónico + caracter_separacion_string[0] + Teléfono_encargado + caracter_separacion_string[0] + Telefono_empresa + caracter_separacion_string[0] + Tipo_de_proveedor + caracter_separacion_string[0] + Productos_Servicios_suministrados + caracter_separacion_string[0] + cuenta_Banco + caracter_separacion_string[0] + Ubicación_GPS + caracter_separacion_string[0] + Notas + caracter_separacion_string[0] + Recordatorio + caracter_separacion_string[0] + activo_o_no_activo;
                bas.Agregar(direccion_archivo_provedores, datos_a_agregar, esta_arreglo);
                info_a_retornar = resul_agregue + G_caracter_para_confirmacion_o_error[0] + "agregado si es 2 solo al archivo si es 1 tambien al arreglo";

            }
            else
            {
                info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se encontro la direccion";
            }

            return info_a_retornar;
        }


        public string extraer_nombre_provedores(string direccion_archivo, string datos, object caracter_separacion_obj = null)
        {

            string[] caracter_separacion_string = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string info_a_retornar = "";


            string direccion_archivo_tipo_medid = direccion_archivo;
            string resultado_archivo_tipo_medida = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo_tipo_medid);
            string[] res_esp_archivo_tipo_medida = resultado_archivo_tipo_medida.Split(G_caracter_para_confirmacion_o_error[0][0]);

            if (Convert.ToInt32(res_esp_archivo_tipo_medida[0]) > 0)
            {
                if (res_esp_archivo_tipo_medida[0] == "1")
                {
                    int indice = Convert.ToInt32(res_esp_archivo_tipo_medida[1]);
                    for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[indice].Length; i++)
                    {
                        string[] info_pro_esp = Tex_base.GG_base_arreglo_de_arreglos[indice][i].Split(caracter_separacion_string[0][0]);
                        info_a_retornar = op_tex.concatenacion_caracter_separacion(info_a_retornar, info_pro_esp[1], caracter_separacion_string[1]);
                    }

                    info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + info_a_retornar;
                }

            }

            else
            {
                if (res_esp_archivo_tipo_medida[0] == "0")
                {
                    info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se encontro la direccion";
                }

            }

            return info_a_retornar;
        }

        public string extraer_nombre_provedores_y_dinero(string direccion_archivo, string datos, object caracter_separacion_obj = null)
        {

            string[] caracter_separacion_string = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string info_a_retornar = "";


            string direccion_archivo_tipo_medid = direccion_archivo;
            string resultado_archivo_tipo_medida = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo_tipo_medid);
            string[] res_esp_archivo_tipo_medida = resultado_archivo_tipo_medida.Split(G_caracter_para_confirmacion_o_error[0][0]);

            if (Convert.ToInt32(res_esp_archivo_tipo_medida[0]) > 0)
            {
                if (res_esp_archivo_tipo_medida[0] == "1")
                {
                    int indice = Convert.ToInt32(res_esp_archivo_tipo_medida[1]);
                    for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[indice].Length; i++)
                    {
                        string[] info_pro_esp = Tex_base.GG_base_arreglo_de_arreglos[indice][i].Split(caracter_separacion_string[0][0]);
                        info_a_retornar = op_tex.concatenacion_caracter_separacion(info_a_retornar, info_pro_esp[1] + caracter_separacion_string[2] + info_pro_esp[21], caracter_separacion_string[1]);
                    }

                    info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + info_a_retornar;
                }

            }

            else
            {
                if (res_esp_archivo_tipo_medida[0] == "0")
                {
                    info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se encontro la direccion";
                }

            }

            return info_a_retornar;
        }

    }
}
