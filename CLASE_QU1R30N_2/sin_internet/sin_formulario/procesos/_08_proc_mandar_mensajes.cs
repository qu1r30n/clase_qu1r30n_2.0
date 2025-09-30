using CLASE_QU1R30N_2.sin_internet.sin_formularios;
using CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE_QU1R30N_2.sin_internet.sin_formulario.procesos
{
    internal class _08_proc_mandar_mensajes
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



        public string mandar_mensaje_watsap(string datos)
        {
            string info_a_retornar = null;

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS---------------------------------------------------------------------------
            string numero = "";
            if (datos_epliteados.Length >= 1 && datos_epliteados[0] != "")
            {
                numero = datos_epliteados[0];
             }

            string mensaje = "";
            if (datos_epliteados.Length >= 2 && datos_epliteados[1] != "")
            {
                mensaje = datos_epliteados[1];
            }


            string ID_PROGRAMA = "NEXOPORTALARCANO";
            if (datos_epliteados.Length >= 3 && datos_epliteados[2] != "")
            {
                ID_PROGRAMA = datos_epliteados[2];
            }




            //-----------------------------------------------------------------------------

            // Aquí va el código para mandar un mensaje
            //string info_a_mandar = programa_a_responder + G_caracter_para_transferencia_entre_archivos[0] + var_fun_GG.GG_id_programa + G_caracter_para_transferencia_entre_archivos[1] + informacion[1] + G_caracter_para_transferencia_entre_archivos[1] + informacion[2] + G_caracter_para_transferencia_entre_archivos[1] + informacion[3] + G_caracter_para_transferencia_entre_archivos[1] + informacion[5];
            //bas.Agregar(G_dir_arch_transferencia[2], info_a_mandar);
            //NEXOPORTALARCANO┴CLASE_QU1R30N■PREGUNTAS_WS■■■contactos
            //NEXOPORTALARCANO┴CLASE_QU1R30N■PREGUNTAS_WS■■■datos_a_retornar


            string info_a_agregar = ID_PROGRAMA + G_caracter_para_transferencia_entre_archivos[0] + var_fun_GG.GG_id_programa + G_caracter_para_transferencia_entre_archivos[1] + mensaje + G_caracter_para_transferencia_entre_archivos[1] + numero;
            string resp_del_agregue = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_USO_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[1] + G_caracter_separacion_funciones_espesificas[3] + info_a_agregar);


            info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + "lanzado";

            return info_a_retornar;
        }

    }
}
