using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        operaciones_arreglos op_arr = new operaciones_arreglos();

        principal enl_princ = new principal();

        //Tex_base bas = new Tex_base();
        operaciones_textos op_tex = new operaciones_textos();
        public void iniciar()
        {
            crear_archivos_transferencia();
            crear_archivos_para_punto_de_venta();

            pruebas();
            
            
        }

        private void crear_archivos_transferencia()
        {

            for (int i = 0; i < G_dir_arch_transferencia.Length - 1; i++)
            {
                //bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(G_dir_arch_transferencia[i], "sin_informacion", leer_y_agrega_al_arreglo: false);
                enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "CREAR_ARCHIVO" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[i]);
            }

            //bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(G_dir_arch_transferencia[2], leer_y_agrega_al_arreglo: false);
            enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "CREAR_ARCHIVO" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[2]);



            //string[] info = bas.Leer(G_dir_arch_transferencia[2]);
            string[] info = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "LEER_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[2]).Split(G_caracter_separacion[0][0]);
            if (info == null)
            {
                //bas.Agregar_a_archivo_sin_arreglo(G_dir_arch_transferencia[2], var_fun_GG.GG_id_programa + "\n" + var_fun_GG.GG_id_programa);
                enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_USO_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[2] + G_caracter_separacion_funciones_espesificas[3] + "0" + G_caracter_separacion_funciones_espesificas[3] + var_fun_GG.GG_id_programa + "\n" + var_fun_GG.GG_id_programa);
            }
            else
            {
                //bas.Agregar_sino_existe(G_dir_arch_transferencia[2], 0, var_fun_GG.GG_id_programa, var_fun_GG.GG_id_programa);
                enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_SINO_EXISTE_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[2] + G_caracter_separacion_funciones_espesificas[3] + "0"+ G_caracter_separacion_funciones_espesificas[3] + var_fun_GG.GG_id_programa + G_caracter_separacion_funciones_espesificas[3] + var_fun_GG.GG_id_programa);
            }
        }


        public void crear_archivos_para_punto_de_venta()
        {


            // Crear archivos del programa
            for (int i = 0; i < var_fun_GG_dir_arch_crear.GG_dir_nom_archivos.GetLength(0); i++)
            {
                /*
                bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(
                    var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[i, 0],
                    var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[i, 1],
                    var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[i, 2].Split(G_caracter_separacion_funciones_espesificas[1][0]));
                */

                string[] direccion_extencion_espliteada = var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[i, 0].Split('.');
                string info_a_inicial = "ID_TOT" + G_caracter_separacion[0] + "1" + "\nCOLUMNAS" + G_caracter_separacion[0] + var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[i, 1] + "\nCANT_POR_ARCH" + G_caracter_separacion[0] + var_fun_GG.GG_cantidado_por_archivo;
                enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "CREAR_ARCHIVO" + G_caracter_separacion_funciones_espesificas[1] + var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[i, 0] + G_caracter_separacion_funciones_espesificas[3] + info_a_inicial + G_caracter_separacion_funciones_espesificas[3] + var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[i, 2]);

                string dir_info_bas = direccion_extencion_espliteada[0] + "_dat\\" + enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "GENERAR_RUTA_ARCHIVO" + G_caracter_separacion_funciones_espesificas[1] + "0" + G_caracter_separacion_funciones_espesificas[3] + var_fun_GG.GG_cantidado_por_archivo);
                string contenido_fila = op_tex.recorrer_caracter_separacion(var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[i, 1]);
                enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "CREAR_ARCHIVO" + G_caracter_separacion_funciones_espesificas[1] + dir_info_bas + G_caracter_separacion_funciones_espesificas[3] + contenido_fila + G_caracter_separacion_funciones_espesificas[3] + var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[i, 2]);

                string[] info_del_archivo = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "LEER_INFO_DIVIDIDA" + G_caracter_separacion_funciones_espesificas[1] + var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[i, 0]).Split(G_caracter_separacion_funciones_espesificas[3][0]);
                string columnas_archivo = op_tex.recorrer_caracter_separacion(var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[i, 1]);
                var_fun_GG.GG_dir_bd_y_valor_inicial_bidimencional = op_arr.agregar_registro_del_array_bidimensional(var_fun_GG.GG_dir_bd_y_valor_inicial_bidimencional, var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[i, 0] + G_caracter_separacion_funciones_espesificas[0] + columnas_archivo, G_caracter_separacion_funciones_espesificas);
                var_fun_GG.GG_base_arreglo_de_arreglos = op_arr.agregar_arreglo_a_arreglo_de_arreglos(var_fun_GG.GG_base_arreglo_de_arreglos, info_del_archivo);

            }



            //bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[0, 0], var_fun_GG.GG_id_programa, new string[] { var_fun_GG.GG_id_programa }, leer_y_agrega_al_arreglo: false);
            //enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "CREAR_ARCHIVO" + G_caracter_separacion_funciones_espesificas[1] + var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[0, 0] + G_caracter_separacion_funciones_espesificas[4] + var_fun_GG.GG_id_programa + G_caracter_separacion_funciones_espesificas[4] + var_fun_GG.GG_id_programa + G_caracter_separacion_funciones_espesificas[4] + "false");



            // Crear archivos del programa SIN ARREGLO GG
            for (int i = 0; i < var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG.GetLength(0); i++)
            {
                /*
                bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(
                    var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[i, 0],
                    var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[i, 1],
                    var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[i, 2].Split(G_caracter_separacion_funciones_espesificas[1][0]), leer_y_agrega_al_arreglo: false);
                */
                string[] direccion_extencion_espliteada = var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[i, 0].Split('.');
                string dir_info_bas = direccion_extencion_espliteada[0] + "_dat\\" + enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "GENERAR_RUTA_ARCHIVO" + G_caracter_separacion_funciones_espesificas[1] + "0" + G_caracter_separacion_funciones_espesificas[3] + var_fun_GG.GG_cantidado_por_archivo);

                enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "CREAR_ARCHIVO" + G_caracter_separacion_funciones_espesificas[1] + var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[i, 0] + G_caracter_separacion_funciones_espesificas[3] + var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[i, 1] + G_caracter_separacion_funciones_espesificas[3] + var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[i, 2]);

                string contenido_fila = op_tex.recorrer_caracter_separacion(var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[i, 1]);
                enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "CREAR_ARCHIVO" + G_caracter_separacion_funciones_espesificas[1] + dir_info_bas + G_caracter_separacion_funciones_espesificas[3] + contenido_fila + G_caracter_separacion_funciones_espesificas[3] + var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[i, 2]);

            }

        }

        public void pruebas()
        {
            //enl_princ.enlasador("MODELO_NEGOCIOS" + G_caracter_separacion_funciones_espesificas[0] + "TIENDA" + G_caracter_separacion_funciones_espesificas[1] + "EXTRAER_INVENTARIO" + G_caracter_separacion_funciones_espesificas[2] + G_dir_arch_transferencia[i]);
            enl_princ.enlasador("MODELO_NEGOCIOS" + G_caracter_separacion_funciones_espesificas[0] + "TIENDA" + G_caracter_separacion_funciones_espesificas[1] + "AGREGAR_PRODUCTO" + G_caracter_separacion_funciones_espesificas[2] + G_caracter_separacion_funciones_espesificas[3] + "" );
        }


        //fin clase-----------------------------------------------------------------------------------------------------
    }
}
