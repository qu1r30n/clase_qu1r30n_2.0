using CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas;
using CLASE_QU1R30N_2.sin_internet.sin_formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CLASE_QU1R30N_2.sin_internet.sin_formulario.procesos
{
    internal class _05_proc_aprobaciones_de_proceso
    {

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;
        
        string[,] G_dir_de_archivos_tipo_1_solo_archivo = var_fun_GG_dir_arch_crear.GG_dir_de_archivos_tipo_1_solo_archivo;

        operaciones_textos op_tex = new operaciones_textos();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        string[] G_solo_para_consultas_relacionadas_encontrar_el_id;

        principal enl_princ = new principal();

        var_fun_GG vf_GG = new var_fun_GG();

        operaciones_arreglos op_arr = new operaciones_arreglos();



        public string GuardarPedidoAConfirmar(string datos)
        {
            string info_a_retornar = null;


            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS ---------------------------------------------------------------------------
            string prosesos_a_guardar = datos_epliteados[0];


            string nivel_de_aprobacion_0_es_el_maximo = "";
            if (datos_epliteados.Length >= 2)
            {
                if (datos_epliteados[1] != "")
                {
                    nivel_de_aprobacion_0_es_el_maximo = datos_epliteados[1];
                }
            }

            string aprobadores_espesificos_que_lo_aprobaran = "0";

            if (datos_epliteados.Length >= 3)
            {
                if (datos_epliteados[2] != "")
                {
                    aprobadores_espesificos_que_lo_aprobaran = datos_epliteados[2];
                }
            }

            string folio = op_tex.generar_folio();
            if (datos_epliteados.Length >= 4)
            {
                if (datos_epliteados[3] != "")
                {
                    folio = datos_epliteados[3];
                }
            }
            //-----------------------------------------------------------------------------------------
            info_a_retornar = folio + G_caracter_separacion_funciones_espesificas[3]+ prosesos_a_guardar + G_caracter_separacion_funciones_espesificas[3] + DateTime.Now.ToString("yyMMddHHmmss") + G_caracter_separacion_funciones_espesificas[3] + nivel_de_aprobacion_0_es_el_maximo + G_caracter_separacion_funciones_espesificas[3] + aprobadores_espesificos_que_lo_aprobaran;
            string resp_del_agregue = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_USO_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_de_archivos_tipo_1_solo_archivo[0,0] + G_caracter_separacion_funciones_espesificas[3] + info_a_retornar);


            return info_a_retornar;
        }

        public string Confirmar(string datos)
        {
            string info_a_retornar = null;


            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS ---------------------------------------------------------------------------
            string folio = datos_epliteados[0];


            string nivel_del_aprobador = "";
            if (datos_epliteados.Length >= 2)
            {
                if (datos_epliteados[1] != "")
                {
                    nivel_del_aprobador = datos_epliteados[1];
                }
            }

            string aprobador = "";

            if (datos_epliteados.Length >= 3)
            {
                if (datos_epliteados[2] != "")
                {
                    aprobador = datos_epliteados[2];
                }
            }

            //-----------------------------------------------------------------------------------------

            // Crear el StreamReader manualmente
            StreamReader sr = new StreamReader(G_dir_de_archivos_tipo_1_solo_archivo[0,0]);

            string linea;
            while ((linea = sr.ReadLine()) != null)
            {
                Console.WriteLine(linea);
            }

            // Cerrar el archivo después de usarlo
            sr.Close();



            return info_a_retornar;
        }

        public string Eliminar(string datos)
        {
            string info_a_retornar = null;


            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS ---------------------------------------------------------------------------
            string folio = datos_epliteados[0];


            string fecha = "";
            if (datos_epliteados.Length >= 2)
            {
                if (datos_epliteados[1] != "")
                {
                    fecha = datos_epliteados[1];
                }
            }


            //-----------------------------------------------------------------------------------------
            

            
            
            return info_a_retornar;
        }

        //fin clase---------------------------------------------------------------------------------------------

    }
}
