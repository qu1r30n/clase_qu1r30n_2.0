using System;using System.Collections.Generic;
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
        string[] G_caracter_para_usar_como_enter_y_nuevo_mensaje = var_fun_GG.GG_caracter_para_usar_como_enter_y_nuevo_mensaje;


        string[,] G_dir_de_archivos_tipo_1_solo_archivo = var_fun_GG_dir_arch_crear.GG_dir_de_archivos_tipo_1_solo_archivo;

        string[,] G_dir_carpetas_y_columnas_para_archivos = var_fun_GG_dir_arch_crear.GG_dir_de_carpetas;


        operaciones_arreglos op_arr = new operaciones_arreglos();
        operaciones_textos op_tex = new operaciones_textos();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;


        principal enl_princ = new principal();

        var_fun_GG vf_GG = new var_fun_GG();






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

            string precio_venta = "";
            if (datos_epliteados.Length >= 5 && datos_epliteados[4] != "")
            {
                precio_venta = datos_epliteados[4];
            }

            string precio_proveedor = "";
            if (datos_epliteados.Length >= 6 && datos_epliteados[5] != "")
            {
                precio_proveedor = datos_epliteados[5];
            }

            string calidad = "";
            if (datos_epliteados.Length >= 7 && datos_epliteados[6] != "")
            {
                calidad = datos_epliteados[6];
            }


            //-------------------------------------------------------------------------------------------------




            // Variable para indicar si el producto ya está en la lista
            string info_a_agregar_si_no_esta = "";
            if (precio_venta != "")
            {
                if (Convert.ToDouble(precio_venta) >= Convert.ToDouble(precio_proveedor))
                {
                    //"0_ID|1_COD_BAR|2_NOMBRE|3_PROVEDOR¬PRECIO_VENTA¬PRECIO_PROVEDOR¬CALIDAD°PROVEDOR2¬PRECIO_VENTA2¬PRECIO_PROVEDOR2¬CALIDAD|"
                    info_a_agregar_si_no_esta = cod_bar + G_caracter_separacion[0] + nombre_producto + G_caracter_separacion[0] + nom_proveedor + G_caracter_separacion[2] + precio_venta + G_caracter_separacion[2] + precio_proveedor + G_caracter_separacion[2] + calidad;
                }
                else
                {
                    //"0_ID|1_COD_BAR|2_NOMBRE|3_PROVEDOR¬PRECIO_VENTA¬PRECIO_PROVEDOR¬CALIDAD°PROVEDOR2¬PRECIO_VENTA2¬PRECIO_PROVEDOR2¬CALIDAD|"
                    info_a_agregar_si_no_esta = cod_bar + G_caracter_separacion[0] + nombre_producto + G_caracter_separacion[0] + nom_proveedor + G_caracter_separacion[2] + (Convert.ToDouble(precio_proveedor) * 1.25) + G_caracter_separacion[2] + precio_proveedor + G_caracter_separacion[2] + calidad;
                }

            }
            else
            {
                //"0_ID|1_COD_BAR|2_NOMBRE|3_PROVEDOR¬PRECIO_VENTA¬PRECIO_PROVEDOR¬CALIDAD°PROVEDOR2¬PRECIO_VENTA2¬PRECIO_PROVEDOR2¬CALIDAD|"
                info_a_agregar_si_no_esta = cod_bar + G_caracter_separacion[0] + nombre_producto + G_caracter_separacion[0] + nom_proveedor + G_caracter_separacion[2] + (Convert.ToDouble(precio_proveedor) * 1.25) + G_caracter_separacion[2] + precio_proveedor + G_caracter_separacion[2] + calidad;

            }

            // Enlace a un sistema central para registrar datos en archivo
            principal enl_princ = new principal();
            enl_princ.enlasador(
                "TEX_BASE" +
                G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_SINO_EXISTE_INFO_DIV" +
                G_caracter_separacion_funciones_espesificas[1] + G_dir_carpetas_y_columnas_para_archivos[0, 0] + id_intermediario + "\\" + id_intermediario + "_INVENTARIO.TXT" +
                G_caracter_separacion_funciones_espesificas[3] + "1" +
                G_caracter_separacion_funciones_espesificas[3] + cod_bar +
                G_caracter_separacion_funciones_espesificas[3] + info_a_agregar_si_no_esta +
                G_caracter_separacion_funciones_espesificas[3] + op_tex.recorrer_caracter_separacion(G_dir_carpetas_y_columnas_para_archivos[0, 1], "derecha")
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

            string tipo_de_mensaje = "";
            if (datos_epliteados.Length >= 9 && datos_epliteados[8] != "")
            {
                tipo_de_mensaje = datos_epliteados[8];
            }
            //--------------------------------------------------------------------------------------------------------





            // Variable para verificar si ya existe ese proveedor
            bool existe = false;

            // Enlace a un sistema central para registrar el proveedor
            //0_ID|1_NOMBRE_PROVEDOR|2_UBICACION|3_HORA_APERTURA|4_HORA_CIERRE|5_CALIDAD_GENERAL|6_PRECIOS_GENERALES_ALTOS_MEDIOS_O_BAJOS|"
            string info_a_agregar_sino_esta = nombre + G_caracter_separacion[0] + ubicacion + G_caracter_separacion[0] + hora_apertura + G_caracter_separacion[0] + hora_cierre + G_caracter_separacion[0] + calidad + G_caracter_separacion[0] + precio_tipo + G_caracter_separacion[0] + telefono + G_caracter_separacion[0] + tipo_de_mensaje;

            enl_princ.enlasador(
                "TEX_BASE" +
                G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_SINO_EXISTE_INFO_DIV" +
                G_caracter_separacion_funciones_espesificas[1] + G_dir_carpetas_y_columnas_para_archivos[1, 0] + id_intermediario + "\\" + id_intermediario + "_PROVEDORES.TXT" +
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

            string[] productos_vendidos = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            string temp = preparar_mensajes_a_provedores(productos_vendidos);

            string[,] contactos_mensajes = extraer_mensajes_y_borrar();
            string mensajes_a_mandar_a_intermediario = "";
            for (
                int j = 0; j < contactos_mensajes.GetLength(0); j++)
            {
                enl_princ.enlasador("MODELO_MENSAJES" + G_caracter_separacion_funciones_espesificas[0] + "MANDAR_MENSAJE_WATSAP" + G_caracter_separacion_funciones_espesificas[1] + contactos_mensajes[j, 0] + G_caracter_separacion_funciones_espesificas[3] + contactos_mensajes[j, 1]);
                mensajes_a_mandar_a_intermediario = op_tex.concatenacion_caracter_separacion(mensajes_a_mandar_a_intermediario, contactos_mensajes[j, 0] + G_caracter_para_usar_como_enter_y_nuevo_mensaje[0] + contactos_mensajes[j, 1] + G_caracter_para_usar_como_enter_y_nuevo_mensaje[0], G_caracter_para_usar_como_enter_y_nuevo_mensaje[0]);
            }

            for (int k = 0; k < productos_vendidos.Length; k++)
            {
                string[] datos_epliteados = productos_vendidos[k].Split(G_caracter_separacion_funciones_espesificas[4][0]);

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

                string ubicacion = "";
                if (datos_epliteados.Length >= 6 && datos_epliteados[5] != "")
                {
                    ubicacion = datos_epliteados[5];
                }

                //---------------------------------------------------------------------------------------

                // Validación mínima (como hacen las otras funciones solo si quieres)
                if (id_intermediario == "" || cod_bar == "" || cantidad == "")
                {
                    return "0" + G_caracter_para_confirmacion_o_error[1] + "Faltan datos obligatorios para registrar la venta.";
                }

                // Construcción del texto de venta
                string info_venta = id_producto + G_caracter_separacion[0]
                                  + cod_bar + G_caracter_separacion[0]
                                  + cantidad + G_caracter_separacion[0]
                                  + provedor + G_caracter_separacion[0];

                // Ruta del archivo de ventas (posicion [2, 0] debe estar reservada para "ventas")
                string ruta_archivo = G_dir_carpetas_y_columnas_para_archivos[1, 0] + id_intermediario + "\\" + id_intermediario + "_INVENTARIO.TXT";



                string seleccion = enl_princ.enlasador
                (
                    "TEX_BASE" +
                    G_caracter_separacion_funciones_espesificas[0] + "SELECCIONAR_ID_INFO_DIVIDIDA" +
                    G_caracter_separacion_funciones_espesificas[1] + ruta_archivo +
                    G_caracter_separacion_funciones_espesificas[3] + id_producto
                );

                string[] res_product = seleccion.Split(G_caracter_para_confirmacion_o_error[0][0]);
                if (Convert.ToDouble(res_product[0]) > 0)
                {
                    if (res_product[0] == "1")
                    {
                        string[] inf_produc = res_product[1].Split(G_caracter_separacion[0][0]);
                        if (cod_bar == inf_produc[1])
                        {
                            string[] provedores = inf_produc[3].Split(G_caracter_separacion[1][0]);
                            if (provedor != "")
                            {
                                bool lo_encontro = false;
                                for (int i = 0; i < provedores.Length; i++)
                                {
                                    string[] Prove_precio_calidad = provedores[i].Split(G_caracter_separacion[2][0]);
                                    if (Prove_precio_calidad[0] == provedor)
                                    {
                                        lo_encontro = true;

                                        MandarMensaje_provedor(Prove_precio_calidad[0], id_intermediario, "mensaje");
                                        Registros();

                                        break;
                                    }
                                }
                            }
                            else
                            {
                                string[] Prove_precio_calidad = provedores[0].Split(G_caracter_separacion[3][0]);

                                MandarMensaje_provedor(Prove_precio_calidad[0], id_intermediario, "mensaje");
                                Registros();
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

        private void MandarMensaje_provedor(string provedor, string id_intermediario, string mensaje)
        {

            string seleccion = enl_princ.enlasador
            (
                "TEX_BASE" +
                G_caracter_separacion_funciones_espesificas[0] + "BUSCAR_INFO_DIVIDIDA" +
                G_caracter_separacion_funciones_espesificas[1] + G_dir_carpetas_y_columnas_para_archivos[0, 0] + id_intermediario + "\\" + id_intermediario + "_PROVEDORES.TXT" +
                G_caracter_separacion_funciones_espesificas[3] + provedor +
                G_caracter_separacion_funciones_espesificas[3] + "1"
            );

            string[] selec_espl = seleccion.Split(G_caracter_separacion[0][0]);

            string resul = enl_princ.enlasador
            (
                "MODELO_MENSAJES" +
                G_caracter_separacion_funciones_espesificas[0] + "MANDAR_MENSAJE_WATSAP" +
                G_caracter_separacion_funciones_espesificas[1] + selec_espl[7] +
                G_caracter_separacion_funciones_espesificas[3] + mensaje +
                G_caracter_separacion_funciones_espesificas[3] + "NEXOPORTALARCANO"
            );

        }

        public void Registros()
        {
            // Aquí va el código para manejar registros
        }

        private string preparar_mensajes_a_provedores(string[] lineas)
        {
            string resultado = "0" + G_caracter_para_confirmacion_o_error[0] + "error";





            for (int i = 0; i < lineas.Length; i++)
            {
                string[] info_venta = lineas[i].Split(G_caracter_separacion_funciones_espesificas[4][0]);




                string id_intermediario = "";
                if (info_venta.Length >= 1 && info_venta[0] != "")
                {
                    id_intermediario = info_venta[0];
                }

                string id_producto = "";
                if (info_venta.Length >= 2 && info_venta[1] != "")
                {
                    id_producto = info_venta[1];
                }

                string cod_bar = "";
                if (info_venta.Length >= 3 && info_venta[2] != "")
                {
                    cod_bar = info_venta[2];
                }

                string cantidad = "";
                if (info_venta.Length >= 4 && info_venta[3] != "")
                {
                    cantidad = info_venta[3];
                }

                string provedor = "";
                if (info_venta.Length >= 5 && info_venta[4] != "")
                {
                    provedor = info_venta[4];
                }

                string ubicacion = "";
                if (info_venta.Length >= 6 && info_venta[5] != "")
                {
                    ubicacion = info_venta[5];
                }






                // Ruta del archivo de ventas (posicion [2, 0] debe estar reservada para "ventas")
                string ruta_archivo_productos = G_dir_carpetas_y_columnas_para_archivos[1, 0] + info_venta[0] + "\\" + info_venta[0] + "_INVENTARIO.TXT";
                string ruta_archivo_provedore = G_dir_carpetas_y_columnas_para_archivos[1, 0] + info_venta[0] + "\\" + info_venta[0] + "_PROVEDORES.TXT";

                string res_producto = enl_princ.enlasador
                    (
                        "TEX_BASE" +
                        G_caracter_separacion_funciones_espesificas[0] + "SELECCIONAR_ID_INFO_DIVIDIDA" +
                        G_caracter_separacion_funciones_espesificas[1] + ruta_archivo_productos +
                        G_caracter_separacion_funciones_espesificas[3] + info_venta[1]
                    );


                string[] res_esp = res_producto.Split(G_caracter_para_confirmacion_o_error[0][0]);
                if (res_esp[0] == "1")
                {
                    resultado = "1" + G_caracter_para_confirmacion_o_error[0] + "encontro productos";
                    string[] info_produc = res_esp[1].Split(G_caracter_separacion[0][0]);
                    bool encontro_provedor = false;

                    string[] inf_prod_prov = info_produc[3].Split(G_caracter_separacion[1][0]);

                    string res_provedor = "";
                    string primer_provedor = "";

                    if (provedor != "")
                    {

                        for (int j = 0; j < inf_prod_prov.Length; j++)
                        {

                            string[] prov_esp = inf_prod_prov[j].Split(G_caracter_separacion[2][0]);

                            //guardado del primer provedor
                            if (j == 0)
                            {
                                primer_provedor = prov_esp[0];
                            }

                            if (provedor == prov_esp[0])
                            {
                                res_provedor = enl_princ.enlasador
                                (
                                    "TEX_BASE" +
                                    G_caracter_separacion_funciones_espesificas[0] + "BUSCAR_INFO_DIVIDIDA"
                                    + G_caracter_separacion_funciones_espesificas[1] + ruta_archivo_provedore
                                    + G_caracter_separacion_funciones_espesificas[3] + prov_esp[0]
                                    + G_caracter_separacion_funciones_espesificas[3] + "1"
                                );

                                encontro_provedor = true;
                                break;

                            }

                        }

                        if (encontro_provedor == false)
                        {
                            res_provedor = enl_princ.enlasador
                            (
                                "TEX_BASE" +
                                G_caracter_separacion_funciones_espesificas[0] + "BUSCAR_INFO_DIVIDIDA"
                                + G_caracter_separacion_funciones_espesificas[1] + ruta_archivo_provedore
                                + G_caracter_separacion_funciones_espesificas[3] + primer_provedor
                                + G_caracter_separacion_funciones_espesificas[3] + "1"
                            );
                        }


                    }

                    else
                    {

                        string[] prov_esp = inf_prod_prov[0].Split(G_caracter_separacion[2][0]);


                        primer_provedor = prov_esp[0];


                        res_provedor = enl_princ.enlasador
                            (
                                "TEX_BASE" +
                                G_caracter_separacion_funciones_espesificas[0] + "BUSCAR_INFO_DIVIDIDA"
                                + G_caracter_separacion_funciones_espesificas[1] + ruta_archivo_provedore
                                + G_caracter_separacion_funciones_espesificas[3] + primer_provedor
                                + G_caracter_separacion_funciones_espesificas[3] + "1"
                            );
                    }




                    res_esp = res_provedor.Split(G_caracter_para_confirmacion_o_error[0][0]);
                    if (res_esp[0] == "1")
                    {
                        string[] info_provedor = res_esp[1].Split(G_caracter_separacion[0][0]);
                        if (info_provedor[8] == "ESPECIAL")
                        {
                            concat_mensaje(info_venta[4], info_produc[2] + " " + cantidad);
                        }
                        else if (info_provedor[8] == "NORMAL")
                        {
                            concat_mensaje(info_venta[4], info_produc[2] + " " + cantidad);


                        }

                        else if (info_provedor[8] == "NO_MENSAJE" || info_provedor[8] == "")
                        {
                            concat_mensaje(info_venta[4], info_produc[2] + " " + cantidad);
                        }



                    }
                }

            }


            return resultado;
        }



        string[,] contactos_mensajes = null;
        private void concat_mensaje(string proveedor, string mensaje)
        {

            bool encontro_provedor = false;
            if (contactos_mensajes != null)
            {


                for (int i = 0; i < contactos_mensajes.GetLength(0); i++)
                {
                    if (contactos_mensajes[i, 0] == proveedor)
                    {
                        encontro_provedor = true;
                        contactos_mensajes[i, 1] = op_tex.concatenacion_caracter_separacion(contactos_mensajes[i, 1], mensaje, G_caracter_para_usar_como_enter_y_nuevo_mensaje[0]);
                    }
                }
            }

            if (encontro_provedor == false)
            {
                contactos_mensajes = op_arr.agregar_registro_del_array_bidimensional(contactos_mensajes, proveedor + G_caracter_separacion[0] + mensaje );
            }

        }


        private string[,] extraer_mensajes_y_borrar()
        {
            string[,] arreglo_a_retoranar = extraer_mensajes();
            limpiar_contenedor_mensajes();

            return arreglo_a_retoranar;
        }

        private string[,] extraer_mensajes()
        {
            return contactos_mensajes;
        }
        private void limpiar_contenedor_mensajes()
        {
            contactos_mensajes = null;
        }

        //fin clase--------------------------------------------------------------
    }

}