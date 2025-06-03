using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas;
using CLASE_QU1R30N_2.sin_internet.sin_formularios;

namespace CLASE_QU1R30N_2.sin_internet.sin_formulario.procesos
{
    internal class _07_proc_intermediario
    {

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;
        string[] G_caracter_para_transferencia_entre_archivos = var_fun_GG.GG_caracter_para_transferencia_entre_archivos;
        string[,] G_dir_de_archivos_tipo_1_solo_archivo = var_fun_GG_dir_arch_crear.GG_dir_de_archivos_tipo_1_solo_archivo;

        string[,] G_dir_carpetas_y_columnas_para_archivos = var_fun_GG_dir_arch_crear.GG_dir_de_carpetas;

        

        operaciones_textos op_tex = new operaciones_textos();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        string[] G_solo_para_consultas_relacionadas_encontrar_el_id;

        principal enl_princ = new principal();

        var_fun_GG vf_GG = new var_fun_GG();

            operaciones_arreglos op_arr = new operaciones_arreglos();

        public string agregar_producto_intermediario(string datos)
        {
            string info_a_retornar = "";

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS---------------------------------------------------------------------------
            string id_intermediario = "";
            if (datos_epliteados.Length >= 1 && datos_epliteados[0] != "")
            {
                id_intermediario = datos_epliteados[0];
            }

            string cod_bar = "";
            if (datos_epliteados.Length >= 2 && datos_epliteados[1] != "")
            {
                cod_bar = datos_epliteados[1];
            }

            string nombre_producto = "";
            if (datos_epliteados.Length >= 3 && datos_epliteados[2] != "")
            {
                nombre_producto = datos_epliteados[2];
            }

            string nom_proveedor = "";
            if (datos_epliteados.Length >= 4 && datos_epliteados[3] != "")
            {
                nom_proveedor = datos_epliteados[3];
            }

            string precio_proveedor = "";
            if (datos_epliteados.Length >= 5 && datos_epliteados[4] != "")
            {
                precio_proveedor = datos_epliteados[4];
            }

            string calidad = "";
            if (datos_epliteados.Length >= 6 && datos_epliteados[5] != "")
            {
                calidad = datos_epliteados[5];
            }
            //-------------------------------------------------------------------------------------------------




            // Variable para indicar si el producto ya está en la lista

            //"0_ID|1_COD_BAR|2_NOMBRE|3_PROVEDOR¬PRECIO¬CALIDAD°PROVEDOR2¬PRECIO2¬CALIDAD|"
            string info_a_agregar_si_no_esta = cod_bar + G_caracter_separacion[0] + nombre_producto + G_caracter_separacion[0] + nom_proveedor + G_caracter_separacion[2] + precio_proveedor + G_caracter_separacion[2] + calidad;

            // Enlace a un sistema central para registrar datos en archivo
            principal enl_princ = new principal();
            enl_princ.enlasador(
                "TEX_BASE" +
                G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_SINO_EXISTE_INFO_DIV" +
                G_caracter_separacion_funciones_espesificas[1] + G_dir_carpetas_y_columnas_para_archivos[0,0] + id_intermediario + "\\" + id_intermediario + "_INVENTARIO.txt" +
                G_caracter_separacion_funciones_espesificas[3] + "1" +
                G_caracter_separacion_funciones_espesificas[3] + cod_bar +
                G_caracter_separacion_funciones_espesificas[3] + info_a_agregar_si_no_esta +
                G_caracter_separacion_funciones_espesificas[3] + op_tex.recorrer_caracter_separacion(G_dir_carpetas_y_columnas_para_archivos[0,1],"derecha")
            );


            return info_a_retornar;

        }

        public string agregar_proveedor_intermediario(string datos)
        {
            string info_a_retornar = "";

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS---------------------------------------------------------------------------
            string id_intermediario = "";
            if (datos_epliteados.Length >= 1 && datos_epliteados[0] != "")
            {
                id_intermediario = datos_epliteados[0];
            }

            string nombre = "";
            if (datos_epliteados.Length >= 2 && datos_epliteados[1] != "")
            {
                nombre = datos_epliteados[1];
            }

            string ubicacion = "";
            if (datos_epliteados.Length >= 3 && datos_epliteados[2] != "")
            {
                ubicacion = datos_epliteados[2];
            }

            string hora_apertura = "";
            if (datos_epliteados.Length >= 4 && datos_epliteados[3] != "")
            {
                hora_apertura = datos_epliteados[3];
            }

            string hora_cierre = "";
            if (datos_epliteados.Length >= 5 && datos_epliteados[4] != "")
            {
                hora_cierre = datos_epliteados[4];
            }

            string telefono = "";
            if (datos_epliteados.Length >= 6 && datos_epliteados[5] != "")
            {
                telefono = datos_epliteados[5];
            }

            string calidad = "";
            if (datos_epliteados.Length >= 7 && datos_epliteados[6] != "")
            {
                calidad = datos_epliteados[6];
            }

            string precio_tipo = "";
            if (datos_epliteados.Length >= 8 && datos_epliteados[7] != "")
            {
                precio_tipo = datos_epliteados[7];
            }
            //--------------------------------------------------------------------------------------------------------





            // Variable para verificar si ya existe ese proveedor
            bool existe = false;

            // Enlace a un sistema central para registrar el proveedor
            //0_ID|1_NOMBRE_PROVEDOR|2_UBICACION|3_HORA_APERTURA|4_HORA_CIERRE|5_CALIDAD_GENERAL|6_PRECIOS_GENERALES_ALTOS_MEDIOS_O_BAJOS|"
            string info_a_agregar_sino_esta = nombre + G_caracter_separacion[0] + ubicacion + G_caracter_separacion[0] + hora_apertura + G_caracter_separacion[0] + hora_cierre + G_caracter_separacion[0] + calidad + G_caracter_separacion[0] + precio_tipo;

            enl_princ.enlasador(
                "TEX_BASE" +
                G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_SINO_EXISTE_INFO_DIV" +
                G_caracter_separacion_funciones_espesificas[1] + G_dir_carpetas_y_columnas_para_archivos[1, 0] + id_intermediario + "\\provedores.txt" +
                G_caracter_separacion_funciones_espesificas[3] + "1" +
                G_caracter_separacion_funciones_espesificas[3] + "nombre" +
                G_caracter_separacion_funciones_espesificas[3] + info_a_agregar_sino_esta +
                G_caracter_separacion_funciones_espesificas[3] + op_tex.recorrer_caracter_separacion(G_dir_carpetas_y_columnas_para_archivos[1, 1], "derecha")
            );


            return info_a_retornar = "";

        }


        public string editar_precio_compra_intermediario(string datos)
        {
            string info_a_retornar = "";

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS---------------------------------------------------------------------------
            string id_intermediario = "";
            if (datos_epliteados.Length >= 1 && datos_epliteados[0] != "")
            {
                id_intermediario = datos_epliteados[0];
            }

            string cod_bar = "";
            if (datos_epliteados.Length >= 2 && datos_epliteados[1] != "")
            {
                cod_bar = datos_epliteados[1];
            }

            string nom_proveedor = "";
            if (datos_epliteados.Length >= 3 && datos_epliteados[2] != "")
            {
                nom_proveedor = datos_epliteados[2];
            }

            string nuevo_precio = "";
            if (datos_epliteados.Length >= 4 && datos_epliteados[3] != "")
            {
                nuevo_precio = datos_epliteados[3];
            }
            //----------------------------------------------------------------------------------------------------


            // Crear instancia del sistema principal para ejecutar acción
            principal enl_princ = new principal();

            // Crear estructura del texto con datos para editar
            /*
            string info_editar_temp = G_dir_carpetas_y_columnas_para_archivos[0, 0] + id_intermediario + ".txt" + G_caracter_separacion_funciones_espesificas[3] +
                info_agregue[0] + G_caracter_separacion_funciones_espesificas[3] +
                "27" + G_caracter_separacion_funciones_espesificas[4] + "30" + G_caracter_separacion_funciones_espesificas[4] + "18" + G_caracter_separacion_funciones_espesificas[3] +
                info_agregue[0] + G_caracter_separacion_funciones_espesificas[4] + fecha_de_la_venta_total + G_caracter_separacion_funciones_espesificas[4] + fecha_de_la_venta_total;
            */
            // Enviar la instrucción para que el sistema edite
            /*
            info_a_retornar = enl_princ.enlasador(
                "TEX_BASE" +
                G_caracter_separacion_funciones_espesificas[0] + "EDITAR_CELDA_ID_INFO_DIVIDIDA" +
                G_caracter_separacion_funciones_espesificas[1] + info_editar_temp
            );
            */


            return info_a_retornar;

        }


        public string venta_intermediario(string datos)
        {
            string info_a_retornar = "";

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS---------------------------------------------------------------------------
            string id_intermediario = "";
            if (datos_epliteados.Length >= 1 && datos_epliteados[0] != "")
            {
                id_intermediario = datos_epliteados[0];
            }

            string id_producto = "";
            if (datos_epliteados.Length >= 2 && datos_epliteados[1] != "")
            {
                id_producto = datos_epliteados[1];
            }

            string cod_bar = "";
            if (datos_epliteados.Length >= 3 && datos_epliteados[2] != "")
            {
                cod_bar = datos_epliteados[2];
            }

            string cantidad = "";
            if (datos_epliteados.Length >= 4 && datos_epliteados[3] != "")
            {
                cantidad = datos_epliteados[3];
            }

            string provedor = "";
            if (datos_epliteados.Length >= 5 && datos_epliteados[4] != "")
            {
                provedor = datos_epliteados[4];
            }

            //---------------------------------------------------------------------------------------

            // Validación mínima (como hacen las otras funciones solo si quieres)
            if (id_intermediario == "" || cod_bar == "" || cantidad == "" )
            {
                return G_caracter_para_confirmacion_o_error[1] + "Faltan datos obligatorios para registrar la venta.";
            }

            // Construcción del texto de venta
            string info_venta = id_producto + G_caracter_separacion[0]
                              + cod_bar + G_caracter_separacion[0]
                              + cantidad + G_caracter_separacion[0]
                              + provedor + G_caracter_separacion[0];

            // Ruta del archivo de ventas (posicion [2, 0] debe estar reservada para "ventas")
            string ruta_archivo = G_dir_carpetas_y_columnas_para_archivos[1, 0] + id_intermediario + "\\" + id_intermediario + "_INVENTARIO.txt";



            string seleccion = enl_princ.enlasador
            (
                "TEX_BASE" +
                G_caracter_separacion_funciones_espesificas[0] + "SELECCIONAR_ID_INFO_DIVIDIDA" +
                G_caracter_separacion_funciones_espesificas[1] + ruta_archivo +
                G_caracter_separacion_funciones_espesificas[3] + id_producto
            );
            string[] res_product = seleccion.Split(G_caracter_para_confirmacion_o_error[0][0]);
            if (Convert.ToDouble(res_product[0])>0)
            {
                if (res_product[0] == "1")
                {

                }
            }

            return info_a_retornar;
        }






        //fin clase--------------------------------------------------------------
    }
}
