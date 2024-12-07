using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;

namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.procesos
{
    internal class _11_proceso_intermediario_acendente
    {


        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_para_usar_como_enter_y_nuevo_mensaje = var_fun_GG.GG_caracter_para_usar_como_enter_y_nuevo_mensaje;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;

        var_fun_GG vf_GG = new var_fun_GG();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        Tex_base bas = new Tex_base();

        operaciones_textos op_tex = new operaciones_textos();
        operaciones_arreglos op_arr = new operaciones_arreglos();


        string[] G_direcciones =
        {

        };

        public void agregar_producto_servicio(string[] produc_servicion)
        {
            string _0_contacto = produc_servicion[0];
            string _0_COD_BAR = produc_servicion[1];
            string _1_PROVEDOR = produc_servicion[2];
            string _2_PRECIO_COMPRA = produc_servicion[3];
            string _3_PRECIO_VENTA = produc_servicion[4];
            string _4_TIEMPO_FABRICACION = produc_servicion[5];
            string _5_UBICACION_GPS = produc_servicion[6];




            produc_servicion = op_arr.quitar_registro_del_array(produc_servicion, 1, true);


            string dir_inv_arch = "CONFIG\\INF\\INTERMEDIARIO\\" + _0_contacto + "\\" + _0_contacto + "_INVENTARIO.TXT";
            string dir_prov_arch = "CONFIG\\INF\\INTERMEDIARIO\\" + _0_contacto + "\\" + _0_contacto + "_PROVEDORES.TXT";



            bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(
                   dir_inv_arch,
                   "0_COD_BAR|1_PROVEDOR|2_PRECIO_COMPRA|3_PRECIO_VENTA|4_TIEMPO_FABRICACION|5_DIRECCION_IMAGEN",
                   leer_y_agrega_al_arreglo: false
                   );

            bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(
                   dir_prov_arch,
                   "0_PROVEDOR|1_UBICACION_GPS|2_TELEFONO|3_TIPO_DE_CONTACTO|4_FORMATO_PETICION|5_horario|6_disponible",
                   leer_y_agrega_al_arreglo: false
                   );



            bas.Editar_incr_o_agrega_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID
                (
                    dir_inv_arch,
                    1,
                    produc_servicion[1],
                    "1",
                    produc_servicion[2],
                    produc_servicion[2],
                    "2",

                    string.Join(G_caracter_separacion[0], produc_servicion)
                );


            bas.Agregar_sino_existe(dir_prov_arch, 1, _1_PROVEDOR, _1_PROVEDOR + "|" + _5_UBICACION_GPS + "||" + "0" + "|" + "");

        }




        public string venta_producto_servicio(string[] produc_servicion)
        {
            string info_retornar = null;

            // Extraer valores iniciales del array de entrada
            string _0_contacto = produc_servicion[0];
            string _0_COD_BAR = produc_servicion[1];
            string _1_CANTIDAD = produc_servicion[2];

            // Quitar el primer registro del array (si es necesario)
            produc_servicion = op_arr.quitar_registro_del_array(produc_servicion, 1, true);

            // Definir rutas de los archivos para inventario y proveedores
            string dir_inv_arch = "CONFIG\\INF\\INTERMEDIARIO\\" + _0_contacto + "\\" + _0_contacto + "_INVENTARIO.TXT";
            string dir_prov_arch = "CONFIG\\INF\\INTERMEDIARIO\\" + _0_contacto + "\\" + _0_contacto + "_PROVEDORES.TXT";

            // Leer el archivo de inventario usando el método 'bas.leer'
            string[] inventario = bas.leer(dir_inv_arch);

            // Buscar el producto en el inventario
            bool productoEncontrado = false;
            string proveedor = null;

            for (int i = 0; i < inventario.Length; i++)
            {
                // Dividir cada línea del inventario por el separador
                string[] lineaInventario = inventario[i].Split(G_caracter_separacion[0][0]);

                // Asignar los valores correspondientes de cada columna en el inventario
                string cod_barras = lineaInventario[0];
                proveedor = lineaInventario[1];

                // Verificar si el código de barras coincide
                if (cod_barras == _0_COD_BAR)
                {
                    productoEncontrado = true;
                    break;
                }
            }

            if (productoEncontrado)
            {
                // Leer el archivo de proveedores para obtener la información relevante del proveedor
                string[] proveedores = bas.leer(dir_prov_arch);
                string ubicacionGPS = null;
                bool disponible = false;

                for (int j = 0; j < proveedores.Length; j++)
                {
                    string[] datosProveedor = proveedores[j].Split(G_caracter_separacion[0][0]);
                    if (datosProveedor[0] == proveedor)
                    {
                        ubicacionGPS = datosProveedor[1];  // Obtener la ubicación GPS
                        string horario = datosProveedor[5]; // Horario del proveedor
                        disponible = datosProveedor[6] == "1"; // Verificar disponibilidad

                        break;
                    }
                }

                // Construir el mensaje de retorno con la información del proveedor
                if (ubicacionGPS != null && disponible)
                {
                    info_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + $"Venta realizada. Recoger el producto en la ubicación GPS del proveedor: {ubicacionGPS}";
                }
                else if (!disponible)
                {
                    info_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "El proveedor no está disponible actualmente.";
                }
                else
                {
                    info_retornar = "2" + G_caracter_para_confirmacion_o_error[0] + "Venta realizada, pero no se encontró la ubicación GPS del proveedor.";
                }
            }
            else
            {
                info_retornar = "Producto no encontrado en el inventario.";
            }

            return info_retornar;
        }



        public string obtenerInventarioCompleto(string[] produc_servicion)
        {
            string _0_contacto = produc_servicion[0];
            // Generar la ruta del archivo de inventario usando el contacto
            string dir_inv_arch = "CONFIG\\INF\\INTERMEDIARIO\\" + _0_contacto + "\\" + _0_contacto + "_INVENTARIO.TXT";

            // Leer el archivo de inventario
            string[] inventario = bas.leer(dir_inv_arch);

            // Unir todos los registros del inventario con el carácter ∆
            string inventarioCompleto = string.Join(G_caracter_para_usar_como_enter_y_nuevo_mensaje[1], inventario);

            inventarioCompleto = "1" + G_caracter_para_confirmacion_o_error[0] + inventarioCompleto;

            return inventarioCompleto;
        }


        public string poner_imagen_a_producto(string[] produc_servicion)
        {
            string info_retornar = null;

            // Extraer valores iniciales del array de entrada
            string _0_contacto = produc_servicion[0];
            string _0_COD_BAR = produc_servicion[1];
            string _1_NUEVA_DIRECCION = produc_servicion[2];

            // Quitar el primer registro del array (si es necesario)
            produc_servicion = op_arr.quitar_registro_del_array(produc_servicion, 1, true);

            // Definir rutas de los archivos para inventario y proveedores
            string dir_inv_arch = "CONFIG\\INF\\INTERMEDIARIO\\" + _0_contacto + "\\" + _0_contacto + "_INVENTARIO.TXT";

            bas.Editar_o_incr_espesifico_si_no_esta_agrega_linea(dir_inv_arch, 0, _0_COD_BAR, "5", _1_NUEVA_DIRECCION, "0");
            

            return info_retornar;
        }



        private string ValidarSiTieneElMismoTipoDeVariable(string[,] arregloBidimensional, int columna_comparar, string[] datosAComparar)
        {
            string infoRetornar = null;

            for (int i = 0; i < arregloBidimensional.GetLength(0); i++)
            {
                double valorConvertido;
                bool esConvertible = double.TryParse(datosAComparar[i], out valorConvertido);
                string resultado = esConvertible ? "ENTERO_DECIMAL" : "TEXTO";

                if (arregloBidimensional[i, 4] != resultado || arregloBidimensional[i, 4] == "TEXTO")
                {
                    // Si no coincide, retorna el mensaje de error
                    return "0" + G_caracter_para_confirmacion_o_error[0] + "error en: " + arregloBidimensional[i, 1];
                }

            }

            // Si todos los tipos son correctos
            return "1" + G_caracter_para_confirmacion_o_error[0] + "datos_correctos";
        }

        //fin clase-----------------------------------------------------------------------------------
    }
}
