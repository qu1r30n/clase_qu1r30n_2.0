using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas;
using CLASE_QU1R30N_2.sin_internet.sin_formularios;

namespace CLASE_QU1R30N_2.sin_internet.sin_formulario.procesos
{
    internal class _06_proc_recordatorios
    {

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;
        string[] G_caracter_para_transferencia_entre_archivos = var_fun_GG.GG_caracter_para_transferencia_entre_archivos;
        string[,] G_dir_de_archivos_tipo_1_solo_archivo = var_fun_GG_dir_arch_crear.GG_dir_de_archivos_tipo_1_solo_archivo;


        public string[] G_dir_arch_transferencia =
        {
            var_fun_GG_dir_arch_crear.GG_dir_arch_transferencia[0,0],
            var_fun_GG_dir_arch_crear.GG_dir_arch_transferencia[1,0],
            var_fun_GG_dir_arch_crear.GG_dir_arch_transferencia[2,0],

        };


        operaciones_textos op_tex = new operaciones_textos();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        string[] G_solo_para_consultas_relacionadas_encontrar_el_id;

        principal enl_princ = new principal();

        var_fun_GG vf_GG = new var_fun_GG();

        operaciones_arreglos op_arr = new operaciones_arreglos();



        public string guardar_recordatorio(string datos)
        {
            string info_a_retornar = null;

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS---------------------------------------------------------------------------
            string mensaje = "";
            if (datos_epliteados.Length >= 1 && datos_epliteados[0] != "")
            {
                mensaje = datos_epliteados[0];
            }

            string horario = "";
            if (datos_epliteados.Length >= 2 && datos_epliteados[1] != "")
            {
                horario = datos_epliteados[1];
            }

            string USUARIO_AL_QUE_SELE_ENVIARA = "";
            if (datos_epliteados.Length >= 3 && datos_epliteados[2] != "")
            {
                USUARIO_AL_QUE_SELE_ENVIARA = datos_epliteados[2];
            }

            string ID_PROGRAMA = "NEXOPORTALARCANO";
            if (datos_epliteados.Length >= 4 && datos_epliteados[3] != "")
            {
                ID_PROGRAMA = datos_epliteados[3];
            }

            string TIPO_DE_MENSAJE = "ELIMINACION_INMEDIOATA";
            if (datos_epliteados.Length >= 5 && datos_epliteados[4] != "")
            {
                TIPO_DE_MENSAJE = datos_epliteados[4];
            }

            string DIAS_SE_MOSTRARA_SI_ES_PERSISTENTE_EL_MENSAJE = "TODOS_LOS_DIAS";
            if (datos_epliteados.Length >= 6 && datos_epliteados[5] != "")
            {
                DIAS_SE_MOSTRARA_SI_ES_PERSISTENTE_EL_MENSAJE = datos_epliteados[5];
            }



            //-----------------------------------------------------------------------------
            string info_a_agregar = ID_PROGRAMA + G_caracter_para_transferencia_entre_archivos[0] + var_fun_GG.GG_id_programa + G_caracter_para_transferencia_entre_archivos[1] +  mensaje + G_caracter_para_transferencia_entre_archivos[1] + horario + G_caracter_para_transferencia_entre_archivos[1] + USUARIO_AL_QUE_SELE_ENVIARA + G_caracter_para_transferencia_entre_archivos[1] + TIPO_DE_MENSAJE + G_caracter_para_transferencia_entre_archivos[1] + DIAS_SE_MOSTRARA_SI_ES_PERSISTENTE_EL_MENSAJE;
            string resp_del_agregue = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_USO_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_de_archivos_tipo_1_solo_archivo[1, 0] + G_caracter_separacion_funciones_espesificas[3] + info_a_agregar);


            info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + "recordatorio guardado";

            return info_a_retornar;
        }

        public string checar_recordatorios()
        {
            string info_retornar = "";
            
            

        

            string[] lista_recordatorioas = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "LEER_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_de_archivos_tipo_1_solo_archivo[1,0]).Split(G_caracter_separacion_funciones_espesificas[4][0]);
            if (lista_recordatorioas != null)
            {
                string[] lista_de_recordatorios_a_eliminar = null;
                for (int i = G_donde_inicia_la_tabla; i < lista_recordatorioas.Length; i++)
                {

                    string[] informacion_prog = lista_recordatorioas[i].Split(G_caracter_para_transferencia_entre_archivos[0][0]);
                    string programa_a_responder = informacion_prog[0];
                    string[] informacion = informacion_prog[1].Split(G_caracter_para_transferencia_entre_archivos[1][0]);
                    long horar_recordatorio = Convert.ToInt64(informacion[2]);
                    long fechaHoraActual = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmm"));

                    if (horar_recordatorio <= fechaHoraActual)
                    {
                        lista_de_recordatorios_a_eliminar = op_arr.agregar_registro_del_array(lista_de_recordatorios_a_eliminar, horar_recordatorio + "");
                        string info_a_mandar = programa_a_responder + G_caracter_para_transferencia_entre_archivos[0] + var_fun_GG.GG_id_programa + G_caracter_para_transferencia_entre_archivos[1] + informacion[1] + G_caracter_para_transferencia_entre_archivos[1] + informacion[2] + G_caracter_para_transferencia_entre_archivos[1] + informacion[3];

                        string resp_del_agregue = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_USO_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[2] + G_caracter_separacion_funciones_espesificas[3] + info_a_mandar);
                        //NEXOPORTALARCANO┴CLASE_QU1R30N■PREGUNTAS_WS■■■contactos

                    }
                }
                if (lista_de_recordatorios_a_eliminar != null)
                {
                    for (int i = 0; i < lista_de_recordatorios_a_eliminar.Length; i++)
                    {
                        
                        //bas.eliminar_fila_PARA_MULTIPLES_PROGRAMAS(direccion_archivo, 4, lista_de_recordatorios_a_eliminar[i] + "", G_caracter_para_transferencia_entre_archivos[1], G_donde_inicia_la_tabla);
                        string resp_del_agregue = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "ELIMINAR_FILA_PARA_MULTIPLES_PROGRAMAS_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_de_archivos_tipo_1_solo_archivo[1, 0] + G_caracter_separacion_funciones_espesificas[3]+ "2" + G_caracter_separacion_funciones_espesificas[3] + lista_de_recordatorios_a_eliminar[i] + G_caracter_separacion_funciones_espesificas[3] + G_caracter_para_transferencia_entre_archivos[1] + G_caracter_separacion_funciones_espesificas[3] + "1");
                    }
                }
            }
            return info_retornar;
        }

        //fin clase-------------------------------------------------------
    }
}
