using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;
using clase_qu1r30n_2._0.sin_internet.sin_formularios.modelos;


namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.procesos
{
    internal class _09_proceso_funciones_diversas
    {
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_para_transferencia_entre_archivos = var_fun_GG.GG_caracter_para_transferencia_entre_archivos;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;
        string[] G_caracter_para_usar_como_enter_y_nuevo_mensaje = var_fun_GG.GG_caracter_para_usar_como_enter_y_nuevo_mensaje;

        var_fun_GG vf_GG = new var_fun_GG();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        operaciones_textos op_tex = new operaciones_textos();
        operaciones_arreglos op_arr = new operaciones_arreglos();
        Tex_base bas = new Tex_base();

        public string[] G_dir_arch_transferencia =
        {
            var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[0,0],
            var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[1,0],
            var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[2,0],

        };

        public string[] G_dir_arch_uso =
        {
            var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[4,0],
            var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[23,0],
        };

        public string extraer_tipos_de_medida(string direccion_archivo, object caracter_separacion_obj = null)
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
                        info_a_retornar = op_tex.concatenacion_caracter_separacion(info_a_retornar, Tex_base.GG_base_arreglo_de_arreglos[indice][i], caracter_separacion_string[1]);
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


        public string guardar_recordatorio(string direccion_archivo, string mensaje, string horario, string CONTACTO, string ID_PROGRAMA = "NEXOPORTALARCANO")
        {
            string info_a_retornar = null;

            string info_a_agregar = ID_PROGRAMA + G_caracter_para_transferencia_entre_archivos[0] + var_fun_GG.GG_id_programa + G_caracter_para_transferencia_entre_archivos[1] + "WS_RS" + G_caracter_para_transferencia_entre_archivos[1] + "RECORDATORIO" + G_caracter_para_transferencia_entre_archivos[1] + mensaje + G_caracter_para_transferencia_entre_archivos[1] + horario + G_caracter_para_transferencia_entre_archivos[1] + CONTACTO;
            bas.Agregar(direccion_archivo, info_a_agregar, false);

            info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + "recordatorio guardado";

            return info_a_retornar;
        }

        public void checar_recordatorios()
        {
            string[] lista_recordatorioas = bas.leer(G_dir_arch_uso[0]);
            if (lista_recordatorioas != null)
            {
                string[] lista_de_recordatorios_a_eliminar = null;
                for (int i = G_donde_inicia_la_tabla; i < lista_recordatorioas.Length; i++)
                {

                    string[] informacion_prog = lista_recordatorioas[i].Split(G_caracter_para_transferencia_entre_archivos[0][0]);
                    string programa_a_responder = informacion_prog[0];
                    string[] informacion = informacion_prog[1].Split(G_caracter_para_transferencia_entre_archivos[1][0]);
                    long horar_recordatorio = Convert.ToInt64(informacion[4]);
                    long fechaHoraActual = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmm"));

                    if (horar_recordatorio <= fechaHoraActual)
                    {
                        lista_de_recordatorios_a_eliminar = op_arr.agregar_registro_del_array(lista_de_recordatorios_a_eliminar, horar_recordatorio + "");
                        string info_a_mandar = programa_a_responder + G_caracter_para_transferencia_entre_archivos[0] + var_fun_GG.GG_id_programa + G_caracter_para_transferencia_entre_archivos[1] + informacion[1] + G_caracter_para_transferencia_entre_archivos[1] + informacion[2] + G_caracter_para_transferencia_entre_archivos[1] + informacion[3] + G_caracter_para_transferencia_entre_archivos[1] + informacion[5];
                        bas.Agregar(G_dir_arch_transferencia[2], info_a_mandar);
                        //NEXOPORTALARCANO┴CLASE_QU1R30N■PREGUNTAS_WS■■■contactos

                    }
                }
                if (lista_de_recordatorios_a_eliminar != null)
                {
                    for (int i = 0; i < lista_de_recordatorios_a_eliminar.Length; i++)
                    {
                        bas.eliminar_fila_PARA_MULTIPLES_PROGRAMAS(G_dir_arch_uso[0], 4, lista_de_recordatorios_a_eliminar[i] + "", G_caracter_para_transferencia_entre_archivos[1], G_donde_inicia_la_tabla);
                    }
                }
            }

        }

        public string trabajo_por_dia()
        {
            string info_a_retornar = null;

            string dia_hoy = DateTime.Now.ToString("ddd").ToUpper().Replace("Á", "A").Replace(".", "");
            string[] inf_esp = Tex_base.GG_base_arreglo_de_arreglos[0][1].Split(G_caracter_separacion[0][0]);
            string dia_ultimo_inicio = inf_esp[0];

            if (dia_ultimo_inicio != dia_hoy)
            {
                inf_esp[0] = dia_hoy;
                Tex_base.GG_base_arreglo_de_arreglos[0][1] = string.Join(G_caracter_separacion[0], inf_esp);
                bas.cambiar_archivo_con_arreglo(Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[0, 0], Tex_base.GG_base_arreglo_de_arreglos[0]);
                string[] res_ind = bas.sacar_indice_del_arreglo_de_direccion(G_dir_arch_uso[1]).Split(G_caracter_para_confirmacion_o_error[0][0]);

                if (Convert.ToInt32(res_ind[0]) > 0)
                {
                    if (res_ind[0] == "1")
                    {
                        int indice = Convert.ToInt32(res_ind[1]);
                        for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[indice].Length; i++)
                        {
                            string[] dias_y_trab = Tex_base.GG_base_arreglo_de_arreglos[indice][i].Split(G_caracter_separacion[0][0]);

                            if (dias_y_trab[0] == dia_hoy)
                            {
                                for (int j = 1; j < dias_y_trab.Length; j++)
                                {
                                    U___unir_trabajos_para_solo_mandar_un_mensaje_a_usuarios(j, dias_y_trab[j]);
                                }
                                U____mandar_trabajo_a_hacer_ws();
                            }


                        }
                    }
                }
                else
                {

                }
            }
            return info_a_retornar;
        }


        string[] G___id_trabajadores = null;
        string[] G___trabajos_a_hacer = null;
        string[] G___ids_programas_a_enviar = null;
        private void U___unir_trabajos_para_solo_mandar_un_mensaje_a_usuarios(int id_trabajo, string trabajo)
        {
            string[] datos_trabajo = trabajo.Split(G_caracter_separacion[1][0]);


            string trabajo_a_hacer = datos_trabajo[0];
            string[] id_empleados_lo_haran = datos_trabajo[1].Split(G_caracter_separacion[2][0]);
            string trabajo_hecho_o_no = datos_trabajo[2];
            string ids_de_quienes_hicieron_el_trabajo = datos_trabajo[3];
            G___ids_programas_a_enviar = datos_trabajo[4].Split(G_caracter_separacion[2][0]);

            for (int i = 0; i < id_empleados_lo_haran.Length; i++)
            {
                bool esta_el_trabajador = false;

                if (G___id_trabajadores != null)
                {
                    for (int j = 0; j < G___id_trabajadores.Length; j++)
                    {
                        if (id_empleados_lo_haran[i] == G___id_trabajadores[j])
                        {
                            esta_el_trabajador = true;
                            G___trabajos_a_hacer[j] = op_tex.concatenacion_caracter_separacion(G___trabajos_a_hacer[j], trabajo_a_hacer, G_caracter_para_usar_como_enter_y_nuevo_mensaje[0]);
                        }
                    }
                }
                if (esta_el_trabajador == false)
                {
                    G___id_trabajadores = op_arr.agregar_registro_del_array(G___id_trabajadores, id_empleados_lo_haran[i]);
                    G___trabajos_a_hacer = op_arr.agregar_registro_del_array(G___trabajos_a_hacer, trabajo_a_hacer);

                }
            }




        }
        private void U____mandar_trabajo_a_hacer_ws()
        {
            principal enl_prin = new principal();
            for (int j = 0; j < G___ids_programas_a_enviar.Length; j++)
            {
                for (int i = 0; i < G___id_trabajadores.Length; i++)
                {
                    enl_prin.enlasador("MODELO_APRENDICES_E~TRABAJO_EVENTUAL§" + G___id_trabajadores[i] + G_caracter_separacion[1] + G___trabajos_a_hacer[i] + G_caracter_separacion[1] + "" + G_caracter_separacion[1] + G___ids_programas_a_enviar[j]);
                }
            }
        }


    }
}

