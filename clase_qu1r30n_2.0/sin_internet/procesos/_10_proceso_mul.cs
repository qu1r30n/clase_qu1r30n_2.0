using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;

namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.procesos
{
    internal class _10_proceso_mul
    {


        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;

        var_fun_GG vf_GG = new var_fun_GG();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        Tex_base bas = new Tex_base();

        operaciones_textos op_tex = new operaciones_textos();
        operaciones_arreglos op_arr = new operaciones_arreglos();


        string[] G_direcciones =
        {
            Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[2, 0],//string G_direccion_negocio = "config\\sismul2\\negocio.TXT";
            Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[3, 0],//string G_direccion_patrocinadores_complejos = "config\\sismul2\\patrocinadores_complejos.TXT";
            Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[4, 0],//string G_direccion_porcentages = "config\\sismul2\\porcentajes\\porcentajes.TXT";
        };

        public string registro_unificado_cod3_r_(string dir_arch_afiliados, string dir_arch_niveles, string id_enc, string tabla_enc, string datos, object caracter_separacion_obj = null)
        {
            string[] caracter_separacion_string = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string info_a_retornar = "";


            string direccion_tab_enc_unificado = dir_arch_afiliados;

            string resultado_inf_enc_unificado = bas.sacar_indice_del_arreglo_de_direccion(direccion_tab_enc_unificado);

            string[] res_esp_enc_unificado = resultado_inf_enc_unificado.Split(G_caracter_para_confirmacion_o_error[0][0]);



            if (res_esp_enc_unificado[0] == "1")
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

                    + "";                            //7)tipo_afiliado
                

                info_a_retornar = bas.Agregar(direccion_tab_enc_unificado, info_a_agregar);


            }

            else
            {

            }
            return info_a_retornar;

        }


        public string dinero_de_venta(string direccion_archivo, string id_usuario, string din,string a_que_proyecto_va_el_dinero, string porsentajes_de_comision_para_patrosinadores = "", string porsentajes_de_comision_venta_directa = "", string porcentage_o_dienro = "", object caracter_separacion_obj = null)
        {

            string[] caracter_separacion_string = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string info_a_retornar = "";


            string direccion_archivo_aprendices_emp = direccion_archivo;
            string resultado_archivo_aprendices_emp = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo_aprendices_emp);
            string[] res_esp_archivo_emp = resultado_archivo_aprendices_emp.Split(G_caracter_para_confirmacion_o_error[0][0]);
            if (res_esp_archivo_emp[0] != "0")
            {
                entrada_dinero_simple_metodo(direccion_archivo, id_usuario, din, a_que_proyecto_va_el_dinero, porsentajes_de_comision_para_patrosinadores, porsentajes_de_comision_venta_directa,porcentage_o_dienro);
                
            }

            else
            {
                info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se encontro la direccion";
            }

            return info_a_retornar;
        }

        /* REGISTROS
        private void registro_simple(string direccion, string id_encargado_simple, string tabla_simple, string[] datos, double dinero_registro = 0, object caracter_separacion_objeto = null, bool regis = true)
        {

            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            string datos_usuario = "";
            for (int i = 0; i < datos.Length; i++)
            {
                if (i > datos.Length - 1)
                {
                    datos_usuario = datos_usuario + datos[i] + caracter_separacion[1];
                }
                else
                {
                    datos_usuario = datos_usuario + datos[i];
                }
            }

            int indice_de_la_base = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(direccion));
            int cantidad_de_registros = Tex_base.GG_base_arreglo_de_arreglos[indice_de_la_base].Length;
            //                      0_id_usuario                  |       1_id_patrocinador_complejo|                 2_tabla_patrocinador_complejo           |               3_id_encargado_simple           |       4_tabla_encargado_simple    |                       5_diner                 |                 6_pago_directo    |            7_pago_indirecto     |                      8_datos                  |        9_encargados     |
            string info_a_agregar = cantidad_de_registros + caracter_separacion[0] + "0" + caracter_separacion[0] + "patrocinadores_complejos" + caracter_separacion[0] + id_encargado_simple + caracter_separacion[0] + tabla_simple + caracter_separacion[0] + dinero_registro + caracter_separacion[0] + "0" + caracter_separacion[0] + "0" + caracter_separacion[0] + datos_usuario + caracter_separacion[0] + "" + caracter_separacion[0];
            bas.Agregar(direccion, info_a_agregar);

            if (regis == true)
            {
                char[] parametro2 = { '/', '\\' };//estos seran los parametros de separacion de el split

                string[] direccion_espliteada = direccion.Split(parametro2);//spliteamos la direccion

                string carpetas = op_tex.joineada_paraesida_y_quitador_de_extremos_del_string(direccion_espliteada, "\\", 2);

                DateTime fecha_hora = DateTime.Now;
                string año_mes_dia = fecha_hora.ToString("yyyyMMdd");
                string dir = carpetas + "\\reg\\" + año_mes_dia + "registro_simple_mov.TXT";
                bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(dir, "registro_simple|dir_tabla|id_usuario|datos_usuario|dinero_registro|id_encargado_simple|", leer_y_agrega_al_arreglo: false);
                string info_movimiento = "registro_simple" + caracter_separacion[0] + direccion + caracter_separacion[0] + cantidad_de_registros + caracter_separacion[0] + datos_usuario + caracter_separacion[0] + dinero_registro + caracter_separacion[0] + id_encargado_simple + caracter_separacion[0];
                bas.Agregar(dir, info_movimiento, false);
            }
        }

        private void registro_complejo(string direccion, string id_encargado_simple, string tabla_simple, string id_encargado_complejo, string tabla_complejo, string[] datos, double dinero_registro = 0, object caracter_separacion_objeto = null, bool regis = true)
        {
            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            string datos_usuario = "";
            for (int i = 0; i < datos.Length; i++)
            {
                if (i > datos.Length - 1)
                {
                    datos_usuario = datos_usuario + datos[i] + caracter_separacion[1];
                }
                else
                {
                    datos_usuario = datos_usuario + datos[i];
                }
            }

            int indice_de_la_base = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(direccion));
            int cantidad_de_registros = Tex_base.GG_base_arreglo_de_arreglos[indice_de_la_base].Length;
            //                      0_id_usuario                  |       1_id_patrocinador_complejo|                 2_tabla_patrocinador_complejo           |               3_id_encargado_simple           |       4_tabla_encargado_simple    |                       5_diner                 |                 6_pago_directo    |            7_pago_indirecto     |                      8_datos                  |        9_encargados     |
            string info_a_agregar = cantidad_de_registros + caracter_separacion[0] + id_encargado_complejo + caracter_separacion[0] + tabla_complejo + caracter_separacion[0] + id_encargado_simple + caracter_separacion[0] + tabla_simple + caracter_separacion[0] + dinero_registro + caracter_separacion[0] + "0" + caracter_separacion[0] + "0" + caracter_separacion[0] + datos_usuario + caracter_separacion[0] + "" + caracter_separacion[0];



            bas.Agregar(direccion, info_a_agregar);




            if (regis == true)
            {
                char[] parametro2 = { '/', '\\' };//estos seran los parametros de separacion de el split

                string[] direccion_espliteada = direccion.Split(parametro2);//spliteamos la direccion

                string carpetas = op_tex.joineada_paraesida_y_quitador_de_extremos_del_string(direccion_espliteada, "\\", 2);

                DateTime fecha_hora = DateTime.Now;
                string año_mes_dia = fecha_hora.ToString("yyyyMMdd");
                string dir = carpetas + "\\reg\\" + año_mes_dia + "registro_simple_mov.TXT";
                bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(dir, "registro_simple|dir_tabla|id_usuario|datos_usuario|dinero_registro|id_encargado_simple|", leer_y_agrega_al_arreglo: false);
                string info_movimiento = "registro_complejo" + caracter_separacion[0] + direccion + caracter_separacion[0] + cantidad_de_registros + caracter_separacion[0] + datos_usuario + caracter_separacion[0] + dinero_registro + caracter_separacion[0] + id_encargado_simple + caracter_separacion[0] + id_encargado_complejo + caracter_separacion[0];
                bas.Agregar(dir, info_movimiento, false);
            }
        }
        */
        
        public void entrada_dinero_simple_metodo(string direccion, string id_usuario, string cantidad_dinero_string, string a_que_proyecto_va_el_dinero, string porsentajes_de_comision_para_patrosinadores = "", string porsentajes_de_comision_venta_directa = "", string porcentage_o_dienro = "PORCENTAJE", object caracter_separacion_objeto = null)
        {
            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            double cantidad_dinero = Convert.ToDouble(cantidad_dinero_string);
            
            double temp_cant_dinero = 0;
            
            if (porsentajes_de_comision_para_patrosinadores != "")
            {


                string[] comiciones = porsentajes_de_comision_para_patrosinadores.Split(caracter_separacion[3][0]);


                string usu = bas.seleccionar(direccion, 0, id_usuario);
                string[] usu_esp = usu.Split(caracter_separacion[0][0]);


                string enc_simples = extraer_patrosinadores_funcion_recursiva(direccion, 0, id_usuario, 1, comiciones.Length, a_que_proyecto_va_el_dinero, G_caracter_separacion[3]);

                string[] encargados = enc_simples.Split(G_caracter_separacion[3][0]);

                

                for (int i = 0; i < encargados.Length; i++)
                {
                    if (porcentage_o_dienro == "DINERO")
                    {
                        temp_cant_dinero = cantidad_dinero;
                    }

                    else if (porcentage_o_dienro == "PORCENTAJE")
                    {
                        temp_cant_dinero = (cantidad_dinero * (Convert.ToDouble(comiciones[i]) / 100));
                    }

                    else
                    {
                        temp_cant_dinero = (cantidad_dinero * (Convert.ToDouble(comiciones[i]) / 100));
                    }

                    bas.Editar_incr_o_agrega_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID
                        (
                        direccion, 0, encargados[i], "2","" + temp_cant_dinero, a_que_proyecto_va_el_dinero, "1"
                        );
                    bas.Editar_incr_o_agrega_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID
                        (
                        direccion, 0, encargados[i], "3", "" + temp_cant_dinero, "", "1"
                        );

                    
                }
            }
            
            if (porsentajes_de_comision_venta_directa != "")
            {

                if (porcentage_o_dienro == "DINERO")
                {
                    temp_cant_dinero = cantidad_dinero;

                }
                else if (porcentage_o_dienro == "PORCENTAJE")
                {
                    temp_cant_dinero = (cantidad_dinero * (Convert.ToDouble(porsentajes_de_comision_venta_directa) / 100));
                }
                else 
                {
                    temp_cant_dinero = (cantidad_dinero * (Convert.ToDouble(porsentajes_de_comision_venta_directa) / 100));
                }


                bas.Editar_incr_o_agrega_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID
                    (
                    direccion, 0, id_usuario, "2", "" + temp_cant_dinero, a_que_proyecto_va_el_dinero, "1"
                    );

                bas.Editar_incr_o_agrega_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID
                    (
                    direccion, 0, id_usuario, "3", "" + temp_cant_dinero, "", "1"
                    );
            }

        }

        

        private string extraer_patrosinadores_funcion_recursiva(string direccion, int columna_a_comparar_usuario, string id_comparar_usuario, int columna_patrocinadores, int cantidad_patrocinadores_a_extraer, string a_que_proyecto_va_el_dinero, string car_sep_para_retornar = null, object caracter_separacion_objeto = null, bool no_cambiar = true)
        {
            
            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            string[] res_indice = bas.sacar_indice_del_arreglo_de_direccion(direccion).Split(G_caracter_para_confirmacion_o_error[0][0]);

            string ids_pat_a_retornar = null;

            if (Convert.ToInt32(res_indice[0]) > 0)
            {
                int indice_de_base = Convert.ToInt32(res_indice[1]);
   
                for (int j = 0; j < cantidad_patrocinadores_a_extraer; j++)
                {
                    for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[indice_de_base].Length; i++)
                    {
                        string[] fila_espliteada = Tex_base.GG_base_arreglo_de_arreglos[indice_de_base][i].Split(caracter_separacion[0][0]);
                        if (fila_espliteada[columna_a_comparar_usuario] == id_comparar_usuario)
                        {
                            
                            if (cantidad_patrocinadores_a_extraer > 0)
                            {
                                //que caracter se usara para separar los patrocinadores
                                
                                string[] cantidad_tipo_patrocinadores = fila_espliteada[columna_patrocinadores].Split(G_caracter_separacion[1][0]);
                                bool encontro_clase = false;
                                for (int g = 0; g < cantidad_tipo_patrocinadores.Length; g++)
                                {
                                    string[] id_pat_y_tipo = cantidad_tipo_patrocinadores[g].Split(G_caracter_separacion[2][0]);

                                    if (id_pat_y_tipo[0] == a_que_proyecto_va_el_dinero)
                                    {
                                        encontro_clase = true;

                                        ids_pat_a_retornar = extraer_patrosinadores_funcion_recursiva(direccion, columna_a_comparar_usuario, id_pat_y_tipo[1], columna_patrocinadores, cantidad_patrocinadores_a_extraer - 1, a_que_proyecto_va_el_dinero, car_sep_para_retornar, no_cambiar: false);

                                        ids_pat_a_retornar = op_tex.concatenacion_caracter_separacion(ids_pat_a_retornar, id_pat_y_tipo[1], car_sep_para_retornar, "CONCATENACION_INVERSA");





                                    }
                                }
                                if (encontro_clase == false)
                                {

                                }

                                return ids_pat_a_retornar;
                            }
                        }
                    }
                }

            }

            return ids_pat_a_retornar;
        }

        private string[,] calc_din_por_enc_y_total(string encargados_simple, string dinero, string encargados_complejo = null, string porsentajes_de_comision_encargados_simp = null, string porsentajes_de_comision_encargados_complejo = null, string comision_venta_dir_compleja = null, string car_sep_para_retornar = null, object caracter_separacion_objeto = null)
        {
            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);
            int indice_de_porcentages = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_direcciones[2]));
            if (comision_venta_dir_compleja == null)
            {
                comision_venta_dir_compleja = Tex_base.GG_base_arreglo_de_arreglos[indice_de_porcentages][4];
            }

            if (porsentajes_de_comision_encargados_simp == null)
            {
                porsentajes_de_comision_encargados_simp = Tex_base.GG_base_arreglo_de_arreglos[indice_de_porcentages][2];
            }
            if (porsentajes_de_comision_encargados_complejo == null)
            {
                porsentajes_de_comision_encargados_complejo = Tex_base.GG_base_arreglo_de_arreglos[indice_de_porcentages][3];
            }


            string[] porsentajes_de_comision_encargados_simp_ESPLITEADO = porsentajes_de_comision_encargados_simp.Split(caracter_separacion[0][0]);
            string[] porsentajes_de_comision_encargados_complejo_ESPLITEADO = porsentajes_de_comision_encargados_complejo.Split(caracter_separacion[0][0]);



            string info_a_devolver = null;
            double total_acumulado = 0;

            string[,] arreglo_bidimencional = null;
            double dinero_a_devolver_a_enc_complejos;
            for (int i = 0; i < porsentajes_de_comision_encargados_simp_ESPLITEADO.Length; i++)
            {

                double dinero_a_devolver = (Convert.ToDouble(porsentajes_de_comision_encargados_simp_ESPLITEADO[i]) / 100) * Convert.ToDouble(dinero);

                if (i < porsentajes_de_comision_encargados_simp_ESPLITEADO.Length - 1)
                {

                    info_a_devolver = info_a_devolver + dinero_a_devolver + car_sep_para_retornar;
                }
                else
                {
                    info_a_devolver = info_a_devolver + dinero_a_devolver + "";
                }
                total_acumulado = total_acumulado + dinero_a_devolver;
            }



            if (encargados_complejo != null && comision_venta_dir_compleja != null)
            {
                info_a_devolver = info_a_devolver + G_caracter_separacion_funciones_espesificas[1];

                for (int i = 0; i < porsentajes_de_comision_encargados_complejo_ESPLITEADO.Length; i++)
                {
                    double dinero_a_devolver = (Convert.ToDouble(porsentajes_de_comision_encargados_complejo_ESPLITEADO[i]) / 100) * (Convert.ToDouble(dinero) * (Convert.ToDouble(comision_venta_dir_compleja) / 100));
                    if (i < porsentajes_de_comision_encargados_complejo_ESPLITEADO.Length - 1)
                    {
                        info_a_devolver = info_a_devolver + dinero_a_devolver + car_sep_para_retornar;
                    }
                    else
                    {

                        info_a_devolver = info_a_devolver + dinero_a_devolver + "";
                    }
                    total_acumulado = total_acumulado + dinero_a_devolver;
                }
            }
            else
            {
                info_a_devolver = info_a_devolver + G_caracter_separacion_funciones_espesificas[1] + "falto_encargados_complejo_O_comision_venta_dir_compleja";
            }
            info_a_devolver = info_a_devolver + G_caracter_separacion_funciones_espesificas[1] + total_acumulado;
            arreglo_bidimencional = op_arr.agregar_registro_del_array_bidimensional(arreglo_bidimencional, info_a_devolver, G_caracter_separacion_funciones_espesificas[1]);


            return arreglo_bidimencional;
        }

        private string[] acumulador_de_strings(string texto, int veces, object caracter_separacion_objeto = null, object caracter_separacion_devolvera_2 = null)
        {
            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);
            string[] caracter_separacion_devolvera = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_devolvera_2);
            string[] texto_espliteado = texto.Split(caracter_separacion[0][0]);

            string[] tex_a_retornar = new string[texto_espliteado.Length];

            for (int j = 0; j < texto_espliteado.Length; j++)
            {
                string acumulador = "";
                for (int i = 0; i < veces; i++)
                {
                    if (i < veces - 1)
                    {
                        acumulador = acumulador + texto_espliteado[j] + caracter_separacion_devolvera[0];
                    }
                    else
                    {
                        acumulador = acumulador + texto_espliteado[j];
                    }

                }
                tex_a_retornar[j] = acumulador;

            }
            return tex_a_retornar;
        }

        public string busqueda_con_curp(string curp)
        {
            string info_a_retornar = "";

            string[] res = bas.sacar_indice_del_arreglo_de_direccion(G_direcciones[0]).Split(G_caracter_para_confirmacion_o_error[0][0]);
            if (res[0] == "1")
            {
                int indice = Convert.ToInt32(res[1]);

                for (int i = 0; i < Tex_base.GG_base_arreglo_de_arreglos[indice].Length; i++)
                {
                    string fila = Tex_base.GG_base_arreglo_de_arreglos[indice][i];
                    string[] res_busqueda = op_tex.busqueda_profunda_string(fila, "7|4", curp).Split(G_caracter_para_confirmacion_o_error[0][0]);
                    if (res_busqueda[0] == "1")
                    {
                        info_a_retornar = res_busqueda[1];
                        break;
                    }
                }
            }


            return info_a_retornar;
        }

        public string busqueda_con_clave_elector(string clave_elector)
        {
            string info_a_retornar = "";

            string[] res = bas.sacar_indice_del_arreglo_de_direccion(G_direcciones[0]).Split(G_caracter_para_confirmacion_o_error[0][0]);
            if (res[0] == "1")
            {
                int indice = Convert.ToInt32(res[1]);

                for (int i = 0; i < Tex_base.GG_base_arreglo_de_arreglos[indice].Length; i++)
                {
                    string fila = Tex_base.GG_base_arreglo_de_arreglos[indice][i];
                    string[] res_busqueda = op_tex.busqueda_profunda_string(fila, "7|5", clave_elector).Split(G_caracter_para_confirmacion_o_error[0][0]);
                    if (res_busqueda[0] == "1")
                    {
                        info_a_retornar = res_busqueda[1];
                        break;
                    }
                }
            }


            return info_a_retornar;
        }

        public string busqueda_con_otra_identificacion_oficial(string otra_identificacion_oficial)
        {
            string info_a_retornar = "";

            string[] res = bas.sacar_indice_del_arreglo_de_direccion(G_direcciones[0]).Split(G_caracter_para_confirmacion_o_error[0][0]);
            if (res[0] == "1")
            {
                int indice = Convert.ToInt32(res[1]);

                for (int i = 0; i < Tex_base.GG_base_arreglo_de_arreglos[indice].Length; i++)
                {
                    string fila = Tex_base.GG_base_arreglo_de_arreglos[indice][i];
                    string[] res_busqueda = op_tex.busqueda_profunda_string(fila, "7|6", otra_identificacion_oficial).Split(G_caracter_para_confirmacion_o_error[0][0]);
                    if (res_busqueda[0] == "1")
                    {
                        info_a_retornar = res_busqueda[1];
                        break;
                    }
                }
            }


            return info_a_retornar;
        }

        public string busqueda_con_telefono(string num_telefono)
        {
            string info_a_retornar = "";

            string[] res = bas.sacar_indice_del_arreglo_de_direccion(G_direcciones[2]).Split(G_caracter_para_confirmacion_o_error[0][0]);
            if (res[0] == "1")
            {
                int indice = Convert.ToInt32(res[1]);

                for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[indice].Length; i++)
                {
                    string fila = Tex_base.GG_base_arreglo_de_arreglos[indice][i];
                    string[] res_busqueda = op_tex.busqueda_profunda_string(fila, "7|7", num_telefono).Split(G_caracter_para_confirmacion_o_error[0][0]);
                    if (res_busqueda[0] == "1")
                    {
                        info_a_retornar = res_busqueda[1];
                        break;
                    }
                }
            }


            return info_a_retornar;
        }

        public string busqueda_con_id(string id)
        {
            string info_a_retornar = "";

            string[] res = bas.sacar_indice_del_arreglo_de_direccion(G_direcciones[2]).Split(G_caracter_para_confirmacion_o_error[0][0]);
            if (res[0] == "1")
            {
                int indice = Convert.ToInt32(res[1]);

                for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[indice].Length; i++)
                {
                    string fila = Tex_base.GG_base_arreglo_de_arreglos[indice][i];
                    string[] info = fila.Split(G_caracter_para_confirmacion_o_error[0][0]);
                    if (info[0] == id)
                    {
                        info_a_retornar = fila;
                        break;
                    }
                }
            }


            return info_a_retornar;
        }

    }
}
