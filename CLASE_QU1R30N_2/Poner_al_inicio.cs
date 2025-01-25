using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLASE_QU1R30N_2.sin_internet.sin_formularios;
using CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas;

namespace CLASE_QU1R30N_2
{
    internal class Poner_al_inicio
    {
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;
        string[] G_dir_arch_transferencia = var_fun_GG.GG_dir_arch_transferencia;

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        principal enl_princ = new principal();

        //Tex_base bas = new Tex_base();
        public void iniciar()
        {

            for (int i = 0; i < G_dir_arch_transferencia.Length - 1; i++)
            {
                //bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(G_dir_arch_transferencia[i], "sin_informacion", leer_y_agrega_al_arreglo: false);
                enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "CREAR_ARCHIVO" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[i]);
            }

            //bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(G_dir_arch_transferencia[2], leer_y_agrega_al_arreglo: false);
            enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "CREAR_ARCHIVO" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[2]);



            //string[] info = bas.Leer(G_dir_arch_transferencia[2]);
            string[] info = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "LEER_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[0]).Split(G_caracter_separacion_funciones_espesificas[4][0]);
            if (info == null)
            {
                //bas.Agregar_a_archivo_sin_arreglo(G_dir_arch_transferencia[2], var_fun_GG.GG_id_programa + "\n" + var_fun_GG.GG_id_programa);
                enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_USO_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[2] + G_caracter_separacion_funciones_espesificas[4] + var_fun_GG.GG_id_programa + "\n" + var_fun_GG.GG_id_programa);
            }
            else
            {
                //bas.Agregar_sino_existe(G_dir_arch_transferencia[2], 0, var_fun_GG.GG_id_programa, var_fun_GG.GG_id_programa);
                enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_SINO_EXISTE_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[2] + G_caracter_separacion_funciones_espesificas[4] + var_fun_GG.GG_id_programa);
            }
            
        }
    }
}
