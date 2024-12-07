using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;

namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.procesos
{
    internal class _05_proceso_afiliados
    {


        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;

        var_fun_GG vf_GG = new var_fun_GG();
        operaciones_textos op_tex = new operaciones_textos();
        Tex_base bas = new Tex_base();
        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;




        /* REGISTROS
        public string registro_simple_cod1(string direccion_archivo, string dir_arch_niveles, string id_enc_simple, string tabla_enc_simp, string datos, object caracter_separacion_obj = null, bool viene_reg_comp = false)
        {
            string[] caracter_separacion_string = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string info_a_retornar = "";

            if (viene_reg_comp == false)
            {
                DateTime fecha_hora = DateTime.Now;
                string año_mes_dia_hora_min = fecha_hora.ToString("yyyyMMddHHmm");
                string año = fecha_hora.ToString("yyyy");
                string dir = "config\\afiliados\\reg\\" + año + "_reg.TXT";
                bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(dir, leer_y_agrega_al_arreglo: false);
                string info_movimiento = "reg_sim" + caracter_separacion_string[0] + id_enc_simple + caracter_separacion_string[0] + tabla_enc_simp + caracter_separacion_string[0] + datos + caracter_separacion_string[0];
                bas.Agregar(dir, info_movimiento, con_arreglo_GG: false);
            }


            string direccion_tab_enc_simple = direccion_archivo;
            string direccion_tab_NIVELES_IDHORIZONTAL_enc_simple = dir_arch_niveles;
            string resultado_inf_enc_simp = bas.sacar_indice_del_arreglo_de_direccion(direccion_tab_enc_simple);
            string resultado_inf_direccion_tab_NIVELES_IDHORIZONTAL_enc_simple = bas.sacar_indice_del_arreglo_de_direccion(direccion_tab_NIVELES_IDHORIZONTAL_enc_simple);
            string[] res_esp_enc_simp = resultado_inf_enc_simp.Split(G_caracter_para_confirmacion_o_error[0][0]);
            string[] res_esp_NIV_enc_simp = resultado_inf_direccion_tab_NIVELES_IDHORIZONTAL_enc_simple.Split(G_caracter_para_confirmacion_o_error[0][0]);

            if (res_esp_enc_simp[0] == "1" && res_esp_NIV_enc_simp[0] == "1")
            {

                int indic_afil_simp = Convert.ToInt32(res_esp_enc_simp[1]);
                int indic_niv_afil_simp = Convert.ToInt32(res_esp_NIV_enc_simp[1]);
                //0_id_usuario|1_id_patrocinador|2_tabla_patrocinador|3_id_encargado|5_tabla_encargado|5_diner|6_a_pagar|7_datos|8_encargados|



                string nivel_encargados = "";
                string nivel_usuario = "";
                for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[indic_afil_simp].Length; i++)
                {
                    string[] info_base_split = Tex_base.GG_base_arreglo_de_arreglos[indic_afil_simp][i].Split(caracter_separacion_string[0][0]);
                    //en registro simple en la base el id_encargado el el id_patrocinador
                    if (info_base_split[0] == id_enc_simple)
                    {
                        nivel_encargados = info_base_split[8];
                        nivel_usuario = "" + (Convert.ToInt32(nivel_encargados) + 1);
                        break;
                    }
                }

                bool encontro_nivel_usuario = false;
                string id_horizontal_usuario_simple = "";
                for (int j = G_donde_inicia_la_tabla; j < Tex_base.GG_base_arreglo_de_arreglos[indic_niv_afil_simp].Length; j++)
                {

                    string[] info_base_split = Tex_base.GG_base_arreglo_de_arreglos[indic_niv_afil_simp][j].Split(caracter_separacion_string[0][0]);

                    if (info_base_split[0] == nivel_usuario)
                    {
                        encontro_nivel_usuario = true;

                        info_base_split[2] = info_base_split[2].Replace(" ", "");
                        info_base_split[2] = info_base_split[2].Replace(caracter_separacion_string[1] + caracter_separacion_string[1], caracter_separacion_string[1]);
                        string[] lugares_horizontales_vacios = info_base_split[2].Split(caracter_separacion_string[1][0]);
                        //si horizontales vacios tiene lugares vacios o se crea un nuevo id_horizontal
                        if (lugares_horizontales_vacios[0] == "" && lugares_horizontales_vacios.Length == 1)
                        {
                            info_base_split[1] = "" + (Convert.ToInt32(info_base_split[1]) + 1);
                            id_horizontal_usuario_simple = info_base_split[1];
                        }
                        else
                        {
                            string[] actualisacdor_lugares_vacios = new string[lugares_horizontales_vacios.Length - 1];
                            id_horizontal_usuario_simple = lugares_horizontales_vacios[0];
                            //actualiza lugares vacios
                            for (int k = 1; k < lugares_horizontales_vacios.Length; k++)
                            {
                                actualisacdor_lugares_vacios[k] = lugares_horizontales_vacios[k];
                            }
                            info_base_split[2] = string.Join(caracter_separacion_string[1], actualisacdor_lugares_vacios);
                        }

                        Tex_base.GG_base_arreglo_de_arreglos[indic_niv_afil_simp][j] = string.Join(caracter_separacion_string[0], info_base_split);
                        info_a_retornar = Tex_base.GG_base_arreglo_de_arreglos[indic_niv_afil_simp][j];
                        bas.cambiar_archivo_con_arreglo(direccion_tab_NIVELES_IDHORIZONTAL_enc_simple, Tex_base.GG_base_arreglo_de_arreglos[indic_niv_afil_simp]);
                        break;
                    }

                }

                if (encontro_nivel_usuario == false)
                {
                    id_horizontal_usuario_simple = "1";
                    info_a_retornar = bas.Agregar(direccion_tab_NIVELES_IDHORIZONTAL_enc_simple, nivel_usuario + caracter_separacion_string[0] + id_horizontal_usuario_simple + caracter_separacion_string[0]);

                }

                string info_a_agregar =
                    (Tex_base.GG_base_arreglo_de_arreglos[indic_afil_simp].Length - 1 + "")//0_id_usuario
                    + caracter_separacion_string[0]
                    + ""                    //|1_id_pat_comp    
                    + caracter_separacion_string[0]
                    + ""                    //|2_tabla_pat_comp    
                    + caracter_separacion_string[0]
                    + id_enc_simple         //|3_id_enc_simp 
                    + caracter_separacion_string[0]
                    + tabla_enc_simp        //|4_tabla_enc_simp
                    + caracter_separacion_string[0]
                    + "0"                   //|5_puntos_d
                    + caracter_separacion_string[0]
                    + "0"                   //|6_puntos_d_a_dar
                    + caracter_separacion_string[0]
                    + datos                 //|7_datos
                    + caracter_separacion_string[0]
                    + "" + nivel_usuario    //|8_niveles   
                    + caracter_separacion_string[0]
                    + "" + id_horizontal_usuario_simple//|9_id_horizontal
                    + caracter_separacion_string[0]
                    + ""                    //|10_tipo_afiliado| 
                    + caracter_separacion_string[0];

                info_a_retornar = bas.Agregar(direccion_tab_enc_simple, info_a_agregar);
            }

            else
            {
                if (res_esp_enc_simp[0] != "1")
                {
                    info_a_retornar = resultado_inf_enc_simp;
                }
                else if (res_esp_NIV_enc_simp[0] != "1")
                {
                    info_a_retornar = resultado_inf_direccion_tab_NIVELES_IDHORIZONTAL_enc_simple;
                }
                else
                {
                    return null;
                }
                return info_a_retornar;
            }
            return info_a_retornar;

        }


        public string registro_complejo_cod2(string dir_arch_afiliados, string dir_arch_niveles, string id_enc_complejo, string solo_nombre_archivo_enc_comp, string id_enc_simple, string tabla_enc_simp, string datos, object caracter_separacion_obj = null)
        {
            string[] caracter_separacion_string = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string info_a_retornar = "";


            string direccion_tab_enc_simple = dir_arch_afiliados;
            string direccion_tab_NIVELES_IDHORIZONTAL_enc_simple = dir_arch_niveles;
            string resultado_inf_enc_simp = bas.sacar_indice_del_arreglo_de_direccion(direccion_tab_enc_simple);
            string resultado_inf_direccion_tab_NIVELES_IDHORIZONTAL_enc_simple = bas.sacar_indice_del_arreglo_de_direccion(direccion_tab_NIVELES_IDHORIZONTAL_enc_simple);
            string[] res_esp_enc_simp = resultado_inf_enc_simp.Split(G_caracter_para_confirmacion_o_error[0][0]);
            string[] res_esp_NIV_enc_simp = resultado_inf_direccion_tab_NIVELES_IDHORIZONTAL_enc_simple.Split(G_caracter_para_confirmacion_o_error[0][0]);


            if (res_esp_enc_simp[0] == "1" && res_esp_NIV_enc_simp[0] == "1")
            {

                int indic_afil_simp = Convert.ToInt32(res_esp_enc_simp[1]);
                int indic_niv_afil_simp = Convert.ToInt32(res_esp_NIV_enc_simp[1]);
                //0_id_usuario|1_id_patrocinador|2_tabla_patrocinador|3_id_encargado|5_tabla_encargado|5_diner|6_a_pagar|7_datos|8_encargados|



                string nivel_encargados = "";
                string nivel_usuario = "";
                for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[indic_afil_simp].Length; i++)
                {
                    string[] info_base_split = Tex_base.GG_base_arreglo_de_arreglos[indic_afil_simp][i].Split(caracter_separacion_string[0][0]);
                    //en registro simple en la base el id_encargado el el id_patrocinador
                    if (info_base_split[0] == id_enc_simple)
                    {
                        nivel_encargados = info_base_split[8];
                        nivel_usuario = "" + (Convert.ToInt32(nivel_encargados) + 1);
                        break;
                    }
                }

                bool encontro_nivel_usuario = false;
                string id_horizontal_usuario_simple = "";
                for (int j = G_donde_inicia_la_tabla; j < Tex_base.GG_base_arreglo_de_arreglos[indic_niv_afil_simp].Length; j++)
                {

                    string[] info_base_split = Tex_base.GG_base_arreglo_de_arreglos[indic_niv_afil_simp][j].Split(caracter_separacion_string[0][0]);

                    if (info_base_split[0] == nivel_usuario)
                    {
                        encontro_nivel_usuario = true;

                        info_base_split[2] = info_base_split[2].Replace(" ", "");
                        info_base_split[2] = info_base_split[2].Replace(caracter_separacion_string[1] + caracter_separacion_string[1], caracter_separacion_string[1]);
                        string[] lugares_horizontales_vacios = info_base_split[2].Split(caracter_separacion_string[1][0]);
                        //si horizontales vacios tiene lugares vacios o se crea un nuevo id_horizontal
                        if (lugares_horizontales_vacios[0] == "" && lugares_horizontales_vacios.Length == 1)
                        {
                            info_base_split[1] = "" + (Convert.ToInt32(info_base_split[1]) + 1);
                            id_horizontal_usuario_simple = info_base_split[1];
                        }
                        else
                        {
                            string[] actualisacdor_lugares_vacios = new string[lugares_horizontales_vacios.Length - 1];
                            id_horizontal_usuario_simple = lugares_horizontales_vacios[0];
                            //actualiza lugares vacios
                            for (int k = 1; k < lugares_horizontales_vacios.Length; k++)
                            {
                                actualisacdor_lugares_vacios[k] = lugares_horizontales_vacios[k];
                            }
                            info_base_split[2] = string.Join(caracter_separacion_string[1], actualisacdor_lugares_vacios);
                        }

                        Tex_base.GG_base_arreglo_de_arreglos[indic_niv_afil_simp][j] = string.Join(caracter_separacion_string[0], info_base_split);
                        info_a_retornar = Tex_base.GG_base_arreglo_de_arreglos[indic_niv_afil_simp][j];
                        bas.cambiar_archivo_con_arreglo(direccion_tab_NIVELES_IDHORIZONTAL_enc_simple, Tex_base.GG_base_arreglo_de_arreglos[indic_niv_afil_simp]);
                        break;
                    }

                }

                if (encontro_nivel_usuario == false)
                {
                    id_horizontal_usuario_simple = "1";
                    info_a_retornar = bas.Agregar(direccion_tab_NIVELES_IDHORIZONTAL_enc_simple, nivel_usuario + caracter_separacion_string[0] + id_horizontal_usuario_simple + caracter_separacion_string[0]);

                }

                string info_a_agregar =
                    (Tex_base.GG_base_arreglo_de_arreglos[indic_afil_simp].Length - 1 + "")//0_id_usuario
                    + caracter_separacion_string[0]
                    + "" + id_enc_complejo  //|1_id_enc_comp    
                    + caracter_separacion_string[0]
                    + "" + solo_nombre_archivo_enc_comp   //|2_tabla_enc_comp    
                    + caracter_separacion_string[0]
                    + id_enc_simple         //|3_id_enc_simp 
                    + caracter_separacion_string[0]
                    + tabla_enc_simp        //|4_tabla_enc_simp
                    + caracter_separacion_string[0]
                    + "0"                   //|5_puntos_d
                    + caracter_separacion_string[0]
                    + "0"                   //|6_puntos_d_a_dar
                    + caracter_separacion_string[0]
                    + datos                 //|7_datos
                    + caracter_separacion_string[0]
                    + "" + nivel_usuario    //|8_niveles   
                    + caracter_separacion_string[0]
                    + "" + id_horizontal_usuario_simple//|9_id_horizontal
                    + caracter_separacion_string[0]
                    + ""                    //|10_tipo_afiliado| 
                    + caracter_separacion_string[0];

                info_a_retornar = bas.Agregar(direccion_tab_enc_simple, info_a_agregar);
            }

            else
            {
                if (res_esp_enc_simp[0] != "1")
                {
                    info_a_retornar = resultado_inf_enc_simp;
                }
                else if (res_esp_NIV_enc_simp[0] != "1")
                {
                    info_a_retornar = resultado_inf_direccion_tab_NIVELES_IDHORIZONTAL_enc_simple;
                }
                else
                {
                    return null;
                }
                return info_a_retornar;
            }
            return info_a_retornar;

        }

        */

        public string registro_unificado_cod3_r_(string dir_arch_afiliados, string dir_arch_niveles, string id_enc, string tabla_enc, string datos, object caracter_separacion_obj = null)
        {
            string[] caracter_separacion_string = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string info_a_retornar = "";


            string direccion_tab_enc_unificado = dir_arch_afiliados;
            
            string resultado_inf_enc_unificado = bas.sacar_indice_del_arreglo_de_direccion(direccion_tab_enc_unificado);

            string[] res_esp_enc_unificado = resultado_inf_enc_unificado.Split(G_caracter_para_confirmacion_o_error[0][0]);
            


            if (res_esp_enc_unificado[0] == "1" )
            {

                int indic_afil_unificado = Convert.ToInt32(res_esp_enc_unificado[1]);
                
                //0_id_usuario|1_id_patrocinador|2_tabla_patrocinador|3_id_encargado|5_tabla_encargado|5_diner|6_a_pagar|7_datos|8_encargados|



                

                string info_a_agregar =

                    (Tex_base.GG_base_arreglo_de_arreglos[indic_afil_unificado].Length + "")//0_id_usuario

                    + caracter_separacion_string[0]

                    + "" + tabla_enc + caracter_separacion_string[2] + id_enc
                    //1)id_y_proy_a_pagar//1)0idp╦1idp¬0proyecto_p°0idp╦1idp¬1proyecto_p
                    + caracter_separacion_string[0]

                    + "" + tabla_enc + caracter_separacion_string[2] + "0"          //2)puntod_de_proy_a_recibir//2)0puntos_d_r¬0proyecto_r°1puntos_d_r¬1proyecto_r

                    + caracter_separacion_string[0]

                    + "" + "0"                      //3)puntos_d_r_totales

                    + caracter_separacion_string[0]

                    + "" + datos                    //4)datos//5)datos

                    + caracter_separacion_string[0]

                    + ""             //5)nivel

                    + caracter_separacion_string[0]

                    + "" //6)id_horizontal

                    + caracter_separacion_string[0]

                    + ""                            //7)tipo_afiliado

                    + caracter_separacion_string[0];
                


                info_a_retornar = bas.Agregar(direccion_tab_enc_unificado, info_a_agregar);
            }

            else
            {

            }
            return info_a_retornar;

        }


    }
}
