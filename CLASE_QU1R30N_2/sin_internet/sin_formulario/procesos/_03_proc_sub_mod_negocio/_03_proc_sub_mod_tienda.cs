using CLASE_QU1R30N_2.sin_internet.sin_formularios;
using CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE_QU1R30N_2.sin_internet.sin_formulario.procesos._03_proc_sub_mod_negocio
{
    internal class _03_proc_sub_mod_tienda
    {

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;
        operaciones_textos op_tex = new operaciones_textos();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        string[] G_solo_para_consultas_relacionadas_encontrar_el_id;

        principal enl_princ = new principal();

        var_fun_GG vf_GG = new var_fun_GG();
        public string extraer_inventario(string datos)
        {
            string info_a_retornar = null;

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            for (int i = 0; i < var_fun_GG.GG_base_arreglo_de_arreglos[0].Length; i++)
            {
                op_tex.busqueda_profunda_comparacion_final_string(var_fun_GG.GG_base_arreglo_de_arreglos[0][i], "19|0", "TIENDA");
            }



            return info_a_retornar;
        }

        public string agregar_producto(string datos)
        {
            string info_a_retornar = null;


            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS ---------------------------------------------------------------------------

            string _01_PRODUCTO = var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[1,3];
            if (datos_epliteados.Length >= 1 && datos_epliteados[0] != "")
            {
                _01_PRODUCTO = datos_epliteados[0];
            }

            double _02_CONTENIDO = Convert.ToDouble(var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[2, 3]);
            if (datos_epliteados.Length >= 2 && double.TryParse(datos_epliteados[1], out double contenido))
            {
                _02_CONTENIDO = contenido;
            }

            string _03_TIPO_MEDIDA = var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[3, 3];
            if (datos_epliteados.Length >= 3 && datos_epliteados[2] != "")
            {
                _03_TIPO_MEDIDA = datos_epliteados[2];
            }

            double _04_PRECIO_VENTA = Convert.ToDouble(var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[4, 3]);
            if (datos_epliteados.Length >= 4 && double.TryParse(datos_epliteados[3], out double precioVenta))
            {
                _04_PRECIO_VENTA = precioVenta;
            }

            string _05_COD_BARRAS = var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[5, 3];
            if (datos_epliteados.Length >= 5 && datos_epliteados[4] != "")
            {
                _05_COD_BARRAS = datos_epliteados[4];
            }

            double _06_CANTIDAD = Convert.ToDouble(var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[6, 3]);
            if (datos_epliteados.Length >= 6 && double.TryParse(datos_epliteados[5], out double cantidad))
            {
                _06_CANTIDAD = cantidad;
            }

            double _07_COSTO_COMP = Convert.ToDouble(var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[7, 3]);
            if (datos_epliteados.Length >= 7 && double.TryParse(datos_epliteados[6], out double costoComp))
            {
                _07_COSTO_COMP = costoComp;
            }

            string _08_PROVEDOR = var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[8, 3];
            if (datos_epliteados.Length >= 8 && datos_epliteados[7] != "")
            {
                _08_PROVEDOR = datos_epliteados[7];
            }

            string _09_GRUPO = var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[9, 3];
            if (datos_epliteados.Length >= 9 && datos_epliteados[8] != "")
            {
                _09_GRUPO = datos_epliteados[8];
            }

            double _10_CANT_X_PAQUET = Convert.ToDouble(var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[10, 3]);
            if (datos_epliteados.Length >= 10 && double.TryParse(datos_epliteados[9], out double cantXPaquet))
            {
                _10_CANT_X_PAQUET = cantXPaquet;
            }

            string _11_ES_PAQUETE = var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[11, 3];
            if (datos_epliteados.Length >= 11 && datos_epliteados[10] != "")
            {
                _11_ES_PAQUETE = datos_epliteados[10];
            }

            string _12_CODBAR_PAQUETE = var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[12, 3];
            if (datos_epliteados.Length >= 12 && datos_epliteados[11] != "")
            {
                _12_CODBAR_PAQUETE = datos_epliteados[11];
            }

            string _13_COD_BAR_INDIVIDUAL_ES_PAQ = var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[13, 3];
            if (datos_epliteados.Length >= 13 && datos_epliteados[12] != "")
            {
                _13_COD_BAR_INDIVIDUAL_ES_PAQ = datos_epliteados[12];
            }

            string _14_LIGAR_PROD_SAB = var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[14, 3];
            if (datos_epliteados.Length >= 14 && datos_epliteados[13] != "")
            {
                _14_LIGAR_PROD_SAB = datos_epliteados[13];
            }

            string _15_IMPUESTOS = var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[15, 3];
            if (datos_epliteados.Length >= 15 && datos_epliteados[14] != "")
            {
                _15_IMPUESTOS = datos_epliteados[14];
            }

            string _16_INGREDIENTES = var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[16, 3];
            if (datos_epliteados.Length >= 16 && datos_epliteados[15] != "")
            {
                _16_INGREDIENTES = datos_epliteados[15];
            }

            string _17_CADUCIDAD = var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[17, 3];
            if (datos_epliteados.Length >= 17 && datos_epliteados[16] != "")
            {
                _17_CADUCIDAD = datos_epliteados[16];
            }

            string _18_ULTIMO_MOV = var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[18, 3];
            if (datos_epliteados.Length >= 18 && datos_epliteados[17] != "")
            {
                _18_ULTIMO_MOV = datos_epliteados[17];
            }

            string _19_SUCUR_VENT = var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[19, 3];
            if (datos_epliteados.Length >= 19 && datos_epliteados[18] != "")
            {
                _19_SUCUR_VENT = datos_epliteados[18];
            }

            double _20_CLAF_PROD = Convert.ToDouble(var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[20, 3]);
            if (datos_epliteados.Length >= 20 && double.TryParse(datos_epliteados[19], out double clafProd))
            {
                _20_CLAF_PROD = clafProd;
            }

            string _21_DIR_IMG_INTER = var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[21, 3];
            if (datos_epliteados.Length >= 21 && datos_epliteados[20] != "")
            {
                _21_DIR_IMG_INTER = datos_epliteados[20];
            }

            string _22_DIR_IMG_COMP = var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[22, 3];
            if (datos_epliteados.Length >= 22 && datos_epliteados[21] != "")
            {
                _22_DIR_IMG_COMP = datos_epliteados[21];
            }

            string _23_INFO_EXTRA = var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[23, 3];
            if (datos_epliteados.Length >= 23 && datos_epliteados[22] != "")
            {
                _23_INFO_EXTRA = datos_epliteados[22];
            }

            string _24_PROCESO_CREAR = var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[24, 3];
            if (datos_epliteados.Length >= 24 && datos_epliteados[23] != "")
            {
                _24_PROCESO_CREAR = datos_epliteados[23];
            }

            string _25_DIR_VID_PROC_CREAR = var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[25, 3];
            if (datos_epliteados.Length >= 25 && datos_epliteados[24] != "")
            {
                _25_DIR_VID_PROC_CREAR = datos_epliteados[24];
            }

            double _26_TIEMPO_FABRICACION = Convert.ToDouble(var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[26, 3]);
            if (datos_epliteados.Length >= 26 && double.TryParse(datos_epliteados[25], out double tiempoFabricacion))
            {
                _26_TIEMPO_FABRICACION = tiempoFabricacion;
            }

            string _27_NO_PONER_NADA = var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos[27, 3];
            if (datos_epliteados.Length >= 27 && datos_epliteados[26] != "")
            {
                _27_NO_PONER_NADA = datos_epliteados[26];
            }


            string info_agregar = _01_PRODUCTO + G_caracter_separacion[0] + _02_CONTENIDO + G_caracter_separacion[0] + _03_TIPO_MEDIDA + G_caracter_separacion[0] + _04_PRECIO_VENTA + G_caracter_separacion[0] + _05_COD_BARRAS + G_caracter_separacion[0] + _06_CANTIDAD + G_caracter_separacion[0] + _07_COSTO_COMP + G_caracter_separacion[0] + _08_PROVEDOR + G_caracter_separacion[0] + _09_GRUPO + G_caracter_separacion[0] + _10_CANT_X_PAQUET + G_caracter_separacion[0] + _11_ES_PAQUETE + G_caracter_separacion[0] + _12_CODBAR_PAQUETE + G_caracter_separacion[0] + _13_COD_BAR_INDIVIDUAL_ES_PAQ + G_caracter_separacion[0] + _14_LIGAR_PROD_SAB + G_caracter_separacion[0] + _15_IMPUESTOS + G_caracter_separacion[0] + _16_INGREDIENTES + G_caracter_separacion[0] + _17_CADUCIDAD + G_caracter_separacion[0] + _18_ULTIMO_MOV + G_caracter_separacion[0] + _19_SUCUR_VENT + G_caracter_separacion[0] + _20_CLAF_PROD + G_caracter_separacion[0] + _21_DIR_IMG_INTER + G_caracter_separacion[0] + _22_DIR_IMG_COMP + G_caracter_separacion[0] + _23_INFO_EXTRA + G_caracter_separacion[0] + _24_PROCESO_CREAR + G_caracter_separacion[0] + _25_DIR_VID_PROC_CREAR + G_caracter_separacion[0] + _26_TIEMPO_FABRICACION + G_caracter_separacion[0] + _27_NO_PONER_NADA;

            info_a_retornar = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_SINO_EXISTE_INFO_DIV" + G_caracter_separacion_funciones_espesificas[1] + var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[0, 0] + G_caracter_separacion_funciones_espesificas[3] + "5" + G_caracter_separacion_funciones_espesificas[3] + _05_COD_BARRAS+ G_caracter_separacion_funciones_espesificas[3] + info_agregar);



            return info_a_retornar;
        }


    }
}
