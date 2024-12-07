using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas
{
    internal class var_fun_GG_dir_arch_crear
    {


        static public string[] GG_variables_string =
        {
           /*0*/ "",//tex_esplit[0]//codbar
           /*1*/ "",//prov_anterior
           /*2*/ "", //provedores_txt//todos_los_provedores
           /*3*/ "",//impuesto anterior
           /*4*/ "", //impuestos_txt//todos_los_impuestos
           /*5*/ "",//tipo_medida_producto_anterior
           /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
        };

        //funciones y restricciones txt y cmb ventana_emergente cod:poison
        ////////////////////////////////////////////////////////////////////////
        //                                SI EDITAS                           //
        //                      [,] GG_ventana_emergente_                     //
        //                             TIENES QUE EDITAR                      //
        //                      RecargarVentanaEmergente                      //
        //                          ES EL DE ABAJITO A ESTE                   //
        //           TIENE QUE SER EL MISMO ARREGLO UNO QUE EL OTRO           //
        ////////////////////////////////////////////////////////////////////////

        //datos configuracio

        static public string[,] GG_ventana_datos_conf = new string[,]
        {
                /*0*/ { "2", "dato_de_configuracion", "" , "TEXTO" },
                /*1*/ { "2", "descripcion_de_configuracion", "" , "TEXTO" },
        };
        public static void RecargarVentanaEmergenteDatosConfiguracion(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_datos_conf = new string[,]
            {
                /*0*/ { "2", "dato_de_configuracion", "" , "TEXTO" },
                /*1*/ { "2", "descripcion_de_configuracion", "" , "TEXTO" },
            };





            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }


        //ventana productos
        static public string[,] GG_ventana_emergente_productos = new string[,]
        {
                /*0*/ { "2", "_00_ID", "" ,"-1", "ENTERO_DECIMAL" },
                /*1*/ { "1", "_01_PRODUCTO", "", "NOSE", "TEXTO" },
                /*2*/ { "1", "_02_CONTENIDO", "0|SOLO_NUMEROS", "-0" , "ENTERO_DECIMAL" },
                /*3*/ { "4", "_03_TIPO_MEDIDA", "NOSE|TODAS_MAYUSCULAS|" + GG_variables_string[1] + '|' + GG_variables_string[2], "NOSE" , "TEXTO" },
                /*4*/ { "1", "_04_PRECIO_VENTA", "0|SOLO_NUMEROS", "NOSE" , "ENTERO_DECIMAL" },
                /*5*/ { "2", "_05_COD_BARRAS", GG_variables_string[0], "NOSE" , "TEXTO" },
                /*6*/ { "1", "_06_CANTIDAD", "1|SOLO_NUMEROS" , "-0", "ENTERO_DECIMAL" },
                /*7*/ { "1", "_07_COSTO_COMP", "0|SOLO_NUMEROS" , "-0", "ENTERO_DECIMAL" },
                /*8*/ { "4", "_08_PROVEDOR", "NOSE|TODAS_MAYUSCULAS|" + GG_variables_string[5] + '|' + GG_variables_string[6] , "NOSE", "TEXTO" },
                /*9*/ { "4", "_09_GRUPO", "PRODUCTO_PIEZA||PRODUCTO_PIEZA|PRODUCTO_PIEZA°PRODUCTO_CANTIDAD°PRODUCTO_ELABORADO°VENTA_INGREDIENTE|OCULTAR_CONTROL¬29¬PRODUCTO_ELABORADO°OCULTAR_CONTROL¬45¬PRODUCTO_ELABORADO", "PRODUCTO_PIEZA", "TEXTO" },
                /*10*/ { "1", "_10_CANT_X_PAQUET", "1|SOLO_NUMEROS" , "-0", "ENTERO_DECIMAL" },
                /*11*/ { "4", "_11_ES_PAQUETE", "INDIVIDUAL||INDIVIDUAL|INDIVIDUAL°PAQUETE_MAYOREO°PAQUETE_PROMOCION|OCULTAR_CONTROL¬27¬PAQUETE_MAYOREO╦PAQUETE_PROMOCION", "INDIVIDUAL", "TEXTO" },
                /*12*/ { "1", "_12_CODBAR_PAQUETE", "" , "NOSE", "TEXTO" },
                /*13*/ { "1", "_13_COD_BAR_INDIVIDUAL_ES_PAQ", "" , "NOSE", "TEXTO" },
                /*14*/ { "1", "_14_LIGAR_PROD_SAB", "" , "NOSE", "TEXTO" },
                /*15*/ { "1", "_15_IMPUESTOS", "|TODAS_MAYUSCULAS|||REYENO_TEXTBOX_VENTANA_IMPU" , "NOSE", "TEXTO" },
                /*16*/ { "1", "_16_INGREDIENTES", "||||NO_VISIBLE°PRODUCTO_ELABORADO" , "NOSE", "TEXTO" },
                /*17*/ { "1", "_17_CADUCIDAD", "0|SOLO_NUMEROS" , "-0", "TEXTO" },
                /*18*/ { "1", "_18_ULTIMO_MOV", "0|SOLO_NUMEROS" , "-0", "TEXTO" },
                /*19*/ { "1", "_19_SUCUR_VENT", "" , "NOSE", "TEXTO" },
                /*20*/ { "1", "_20_CLAF_PROD", "" , "-0", "ENTERO_DECIMAL" },
                /*21*/ { "1", "_21_DIR_IMG_INTER", "" , "NOSE", "TEXTO" },
                /*22*/ { "1", "_22_DIR_IMG_COMP", "" , "NOSE", "TEXTO" },
                /*23*/ { "1", "_23_INFO_EXTRA", "" , "NOSE", "TEXTO" },
                /*24*/ { "1", "_24_PROCESO_CREAR", "||||NO_VISIBLE" , "NOSE", "TEXTO" },
                /*25*/ { "1", "_25_DIR_VID_PROC_CREAR", "" , "NOSE", "TEXTO" },
                /*26*/ { "1", "_26_TIEMPO_FABRICACION", "0" , "NOSE", "ENTERO_DECIMAL" },
                /*27*/ { "2", "_27_NO_PONER_NADA", "" , "", "TEXTO" },
        };
        public static void RecargarVentanaEmergenteProductos(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_emergente_productos = new string[,]
            {
                /*0*/ { "2", "_00_ID", "" ,"-1", "ENTERO_DECIMAL" },
                /*1*/ { "1", "_01_PRODUCTO", "", "NOSE", "TEXTO" },
                /*2*/ { "1", "_02_CONTENIDO", "0|SOLO_NUMEROS", "-0" , "ENTERO_DECIMAL" },
                /*3*/ { "4", "_03_TIPO_MEDIDA", "NOSE|TODAS_MAYUSCULAS|" + GG_variables_string[1] + '|' + GG_variables_string[2], "NOSE" , "TEXTO" },
                /*4*/ { "1", "_04_PRECIO_VENTA", "0|SOLO_NUMEROS", "NOSE" , "ENTERO_DECIMAL" },
                /*5*/ { "2", "_05_COD_BARRAS", GG_variables_string[0], "NOSE" , "TEXTO" },
                /*6*/ { "1", "_06_CANTIDAD", "1|SOLO_NUMEROS" , "-0", "ENTERO_DECIMAL" },
                /*7*/ { "1", "_07_COSTO_COMP", "0|SOLO_NUMEROS" , "-0", "ENTERO_DECIMAL" },
                /*8*/ { "4", "_08_PROVEDOR", "NOSE|TODAS_MAYUSCULAS|" + GG_variables_string[5] + '|' + GG_variables_string[6] , "NOSE", "TEXTO" },
                /*9*/ { "4", "_09_GRUPO", "PRODUCTO_PIEZA||PRODUCTO_PIEZA|PRODUCTO_PIEZA°PRODUCTO_CANTIDAD°PRODUCTO_ELABORADO°VENTA_INGREDIENTE|OCULTAR_CONTROL¬29¬PRODUCTO_ELABORADO°OCULTAR_CONTROL¬45¬PRODUCTO_ELABORADO", "PRODUCTO_PIEZA", "TEXTO" },
                /*10*/ { "1", "_10_CANT_X_PAQUET", "1|SOLO_NUMEROS" , "-0", "ENTERO_DECIMAL" },
                /*11*/ { "4", "_11_ES_PAQUETE", "INDIVIDUAL||INDIVIDUAL|INDIVIDUAL°PAQUETE_MAYOREO°PAQUETE_PROMOCION|OCULTAR_CONTROL¬27¬PAQUETE_MAYOREO╦PAQUETE_PROMOCION", "INDIVIDUAL", "TEXTO" },
                /*12*/ { "1", "_12_CODBAR_PAQUETE", "" , "NOSE", "TEXTO" },
                /*13*/ { "1", "_13_COD_BAR_INDIVIDUAL_ES_PAQ", "" , "NOSE", "TEXTO" },
                /*14*/ { "1", "_14_LIGAR_PROD_SAB", "" , "NOSE", "TEXTO" },
                /*15*/ { "1", "_15_IMPUESTOS", "|TODAS_MAYUSCULAS|||REYENO_TEXTBOX_VENTANA_IMPU" , "NOSE", "TEXTO" },
                /*16*/ { "1", "_16_INGREDIENTES", "||||NO_VISIBLE°PRODUCTO_ELABORADO" , "NOSE", "TEXTO" },
                /*17*/ { "1", "_17_CADUCIDAD", "0|SOLO_NUMEROS" , "-0", "TEXTO" },
                /*18*/ { "1", "_18_ULTIMO_MOV", "0|SOLO_NUMEROS" , "-0", "TEXTO" },
                /*19*/ { "1", "_19_SUCUR_VENT", "" , "NOSE", "TEXTO" },
                /*20*/ { "1", "_20_CLAF_PROD", "" , "-0", "ENTERO_DECIMAL" },
                /*21*/ { "1", "_21_DIR_IMG_INTER", "" , "NOSE", "TEXTO" },
                /*22*/ { "1", "_22_DIR_IMG_COMP", "" , "NOSE", "TEXTO" },
                /*23*/ { "1", "_23_INFO_EXTRA", "" , "NOSE", "TEXTO" },
                /*24*/ { "1", "_24_PROCESO_CREAR", "||||NO_VISIBLE" , "NOSE", "TEXTO" },
                /*25*/ { "1", "_25_DIR_VID_PROC_CREAR", "" , "NOSE", "TEXTO" },
                /*26*/ { "1", "_26_TIEMPO_FABRICACION", "0" , "NOSE", "ENTERO_DECIMAL" },
                /*27*/ { "2", "_27_NO_PONER_NADA", "" , "", "TEXTO" },
            };





            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }



        //cosas no estaban en el inventario
        static public string[,] GG_ventana_COSAS_NO_ESTABAN_INVENTARIO =
        {
            { "1","0_COD_BAR","", "NOSE", "TEXTO" },
            { "1","1_NOMBRE","" , "NOSE", "TEXTO" },

        };
        public static void RecargarVentanaEmergente_Cosas_que_no_estaban(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_COSAS_NO_ESTABAN_INVENTARIO = new string[,]
            {
                { "1","0_COD_BAR","", "NOSE", "TEXTO" },
                { "1","1_NOMBRE","" , "NOSE", "TEXTO" },
            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }

        //ventana provedores
        static public string[,] GG_ventana_provedor =
        {
            { "1","0_ID_EMPRESA","", "-0", "TEXTO" },
            { "1","1_NOMBRE_EMPRESA","", "NOSE", "TEXTO" },
            { "1","2_NOMBRE_ENCARGADO","", "NOSE" , "TEXTO" },
            { "1","3_DIRECCIÓN_EMPRESA","", "NOSE" , "TEXTO" },
            { "1","4_CIUDAD_EMPRESA","", "NOSE" , "TEXTO" },
            { "1","5_ESTADO_EMPRESA","", "NOSE" , "TEXTO" },
            { "1","6_CÓDIGO_POSTAL","", "NOSE" , "TEXTO" },
            { "1","7_PAÍS","" , "NOSE", "TEXTO" },
            { "1","8_CORREO_ELECTRÓNICO","" , "NOSE", "TEXTO" },
            { "1","9_TELÉFONO_ENCARGADO","" , "NOSE", "TEXTO" },
            { "1","10_TELEFONO_EMPRESA","" , "NOSE", "TEXTO" },
            { "1","11_TIPO_DE_PROVEEDOR","" , "NOSE", "TEXTO" },
            { "1","12_PRODUCTOS_SERVICIOS_SUMINISTRADOS","" , "NOSE", "TEXTO" },
            { "1","13_CUENTA_BANCO","" , "NOSE", "TEXTO" },
            { "1","14_UBICACIÓN_(GPS)","" , "-0", "TEXTO" },
            { "1","15_NOTAS","" , "NOSE", "TEXTO" },
            { "1","16_RECORDATORIO","" , "", "TEXTO" },
            { "1","17_ACTIVO_O_NO_ACTIVO","", "ACTIVO", "TEXTO" },
            { "1","18_CALIFICACION_PREVENTA¬0°CALIFICACION_ENTREGA¬0","" ,"CALIFICACION_PREVENTA¬0°CALIFICACION_ENTREGA¬0" , "TEXTO" },
            { "1","19_COMENTARIOS_PREVENTA_ENTREGA","" , "NOSE", "TEXTO" },
            { "1","20_SUCURSALES_QUE_LE_COMPRAN","" , "NOSE", "TEXTO" },
            { "1","21_DINERO_A_COMPRARLE","0|SOLO_NUMEROS" , "0", "TEXTO" },
            { "1","22_DIAS_DE_PREVENTA_0°DIAS_DE_PREVENTA_1","","NOSE°NOSE" , "TEXTO" },
            { "1","23_DIAS_DE_ENTREGA_0°DIAS_DE_ENTREGA_1","","NOSE°NOSE" , "TEXTO" },


        };
        public static void RecargarVentanaEmergenteProvedor(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_provedor = new string[,]
            {
                { "1","0_ID_EMPRESA","", "-0", "TEXTO" },
                { "1","1_NOMBRE_EMPRESA","", "NOSE", "TEXTO" },
                { "1","2_NOMBRE_ENCARGADO","", "NOSE" , "TEXTO" },
                { "1","3_DIRECCIÓN_EMPRESA","", "NOSE" , "TEXTO" },
                { "1","4_CIUDAD_EMPRESA","", "NOSE" , "TEXTO" },
                { "1","5_ESTADO_EMPRESA","", "NOSE" , "TEXTO" },
                { "1","6_CÓDIGO_POSTAL","", "NOSE" , "TEXTO" },
                { "1","7_PAÍS","" , "NOSE", "TEXTO" },
                { "1","8_CORREO_ELECTRÓNICO","" , "NOSE", "TEXTO" },
                { "1","9_TELÉFONO_ENCARGADO","" , "NOSE", "TEXTO" },
                { "1","10_TELEFONO_EMPRESA","" , "NOSE", "TEXTO" },
                { "1","11_TIPO_DE_PROVEEDOR","" , "NOSE", "TEXTO" },
                { "1","12_PRODUCTOS_SERVICIOS_SUMINISTRADOS","" , "NOSE", "TEXTO" },
                { "1","13_CUENTA_BANCO","" , "NOSE", "TEXTO" },
                { "1","14_UBICACIÓN_(GPS)","" , "-0", "TEXTO" },
                { "1","15_NOTAS","" , "NOSE", "TEXTO" },
                { "1","16_RECORDATORIO","" , "", "TEXTO" },
                { "1","17_ACTIVO_O_NO_ACTIVO","", "ACTIVO", "TEXTO" },
                { "1","18_CALIFICACION_PREVENTA¬0°CALIFICACION_ENTREGA¬0","" ,"CALIFICACION_PREVENTA¬0°CALIFICACION_ENTREGA¬0" , "TEXTO" },
                { "1","19_COMENTARIOS_PREVENTA_ENTREGA","" , "NOSE", "TEXTO" },
                { "1","20_SUCURSALES_QUE_LE_COMPRAN","" , "NOSE", "TEXTO" },
                { "1","21_DINERO_A_COMPRARLE","0|SOLO_NUMEROS" , "0", "TEXTO" },
                { "1","22_DIAS_DE_PREVENTA_0°DIAS_DE_PREVENTA_1","","NOSE°NOSE" , "TEXTO" },
                { "1","23_DIAS_DE_ENTREGA_0°DIAS_DE_ENTREGA_1","","NOSE°NOSE" , "TEXTO" },
            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }


        //ventana APRENDICES_E
        static public string[,] GG_ventana_APRENDICES_E =
        {
            { "2","0_ID","","-0" , "TEXTO" },
            { "1","1_NOMBRE","" , "NOSE", "TEXTO" },
            { "1","2_APELLIDO_PATERNO","" , "NOSE", "TEXTO" },
            { "1","3_APELLIDO_MATERNO","" , "NOSE", "TEXTO" },
            { "1","4_FECHA_DE_NACIMIENTO","" , "NOSE", "TEXTO" },
            { "1","5_GÉNERO","" , "NOSE", "TEXTO" },
            { "1","6_DIRECCIÓN","" , "NOSE", "TEXTO" },
            { "1","7_CIUDAD","" , "NOSE", "TEXTO" },
            { "1","8_ESTADO_PROVINCIA","" , "NOSE", "TEXTO" },
            { "1","9_CÓDIGO_POSTAL","" , "NOSE", "TEXTO" },
            { "1","10_PAÍS","" , "NOSE", "TEXTO" },
            { "1","11_CORREO_ELECTRÓNICO","" , "NOSE", "TEXTO" },
            { "1","12_TELÉFONO","" , "NOSE", "TEXTO" },
            { "1","13_FECHA_DE_INGRESO","" , "NOSE", "TEXTO" },
            { "1","14_SUELDO","" , "NOSE", "TEXTO" },
            { "1","15_CARGO","" , "NOSE", "TEXTO" },
            { "1","16_ESTADO_DE_CURS_APRENDIS_E","" , "NOSE", "TEXTO" },
            { "1","17_SUPERVISOR","" , "NOSE", "TEXTO" },
            { "1","18_NOTAS","" , "", "TEXTO" },
            { "1","19_AFILIADO","" , "NOSE", "TEXTO" },
            { "1","20_FECHA_DE_TERMINACIÓN","0|SOLO_NUMEROS" , "0", "TEXTO" },
            { "1","21_MOTIVO_DE_TERMINACIÓN°DIAS_DE_PREVENTA_1","" , "NOSE", "TEXTO" },
            { "1","22_HORAS_TRABAJADAS","" , "NOSE", "TEXTO" },
            { "1","23_EVALUACIONES_DE_DESEMPEÑO","" , "NOSE", "TEXTO" },
            { "1","24_HABILIDADES_Y_CERTIFICACIONES","" , "NOSE", "TEXTO" },
            { "1","25_IDIOMAS","" , "NOSE", "TEXTO" },
            { "1","26_FECHA_DE_ÚLTIMA_PROMOCIÓN","" , "NOSE", "TEXTO" },
            { "1","27_ID_DEL_DEPARTAMENTO_DE_SUPERVISIÓN","" , "NOSE", "TEXTO" },
            { "1","28_HISTORIAL_DE_CAPACITACIÓN","" , "NOSE", "TEXTO" },
            { "1","29_ÚLTIMO_AUMENTO_DE_SALARIO","" , "NOSE", "TEXTO" },
            { "1","30_TIPO_EMPLEADO","" , "NOSE", "TEXTO" },
            { "1","31_RANGO_CALIF","" , "-0", "TEXTO" },

        };
        public static void RecargarVentanaEmergenteAPRENDICES_E(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_APRENDICES_E = new string[,]
            {
                { "2","0_ID","","-0" , "TEXTO" },
                { "1","1_NOMBRE","" , "NOSE", "TEXTO" },
                { "1","2_APELLIDO_PATERNO","" , "NOSE", "TEXTO" },
                { "1","3_APELLIDO_MATERNO","" , "NOSE", "TEXTO" },
                { "1","4_FECHA_DE_NACIMIENTO","" , "NOSE", "TEXTO" },
                { "1","5_GÉNERO","" , "NOSE", "TEXTO" },
                { "1","6_DIRECCIÓN","" , "NOSE", "TEXTO" },
                { "1","7_CIUDAD","" , "NOSE", "TEXTO" },
                { "1","8_ESTADO_PROVINCIA","" , "NOSE", "TEXTO" },
                { "1","9_CÓDIGO_POSTAL","" , "NOSE", "TEXTO" },
                { "1","10_PAÍS","" , "NOSE", "TEXTO" },
                { "1","11_CORREO_ELECTRÓNICO","" , "NOSE", "TEXTO" },
                { "1","12_TELÉFONO","" , "NOSE", "TEXTO" },
                { "1","13_FECHA_DE_INGRESO","" , "NOSE", "TEXTO" },
                { "1","14_SUELDO","" , "NOSE", "TEXTO" },
                { "1","15_CARGO","" , "NOSE", "TEXTO" },
                { "1","16_ESTADO_DE_CURS_APRENDIS_E","" , "NOSE", "TEXTO" },
                { "1","17_SUPERVISOR","" , "NOSE", "TEXTO" },
                { "1","18_NOTAS","" , "", "TEXTO" },
                { "1","19_AFILIADO","" , "NOSE", "TEXTO" },
                { "1","20_FECHA_DE_TERMINACIÓN","0|SOLO_NUMEROS" , "0", "TEXTO" },
                { "1","21_MOTIVO_DE_TERMINACIÓN°DIAS_DE_PREVENTA_1","" , "NOSE", "TEXTO" },
                { "1","22_HORAS_TRABAJADAS","" , "NOSE", "TEXTO" },
                { "1","23_EVALUACIONES_DE_DESEMPEÑO","" , "NOSE", "TEXTO" },
                { "1","24_HABILIDADES_Y_CERTIFICACIONES","" , "NOSE", "TEXTO" },
                { "1","25_IDIOMAS","" , "NOSE", "TEXTO" },
                { "1","26_FECHA_DE_ÚLTIMA_PROMOCIÓN","" , "NOSE", "TEXTO" },
                { "1","27_ID_DEL_DEPARTAMENTO_DE_SUPERVISIÓN","" , "NOSE", "TEXTO" },
                { "1","28_HISTORIAL_DE_CAPACITACIÓN","" , "NOSE", "TEXTO" },
                { "1","29_ÚLTIMO_AUMENTO_DE_SALARIO","" , "NOSE", "TEXTO" },
                { "1","30_TIPO_EMPLEADO","" , "NOSE", "TEXTO" },
                { "1","31_RANGO_CALIF","" , "-0", "TEXTO" },

            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }

        //ventana afiliados_simples
        static public string[,] GG_ventana_afiliados_simples =
        {
            { "2","0_ID_USUARIO","","-0" , "TEXTO" },
            { "1","1_ID_PAT_COMP","","-0" , "TEXTO" },
            { "1","2_TABLA_PAT_COMP","","NOSE" , "TEXTO" },
            { "1","3_ID_ENC_SIMP","", "-0", "TEXTO" },
            { "1","4_TABLA_ENC_SIMP","","NOSE" , "TEXTO" },
            { "1","5_PUNTOS_D","" ,"0", "TEXTO" },
            { "1","6_PUNTOS_D_A_DAR","" ,"0", "TEXTO" },
            { "1","7_DATOS","","" , "TEXTO" },
            { "1","8_NIVELES","","0" , "TEXTO" },
            { "1","9_ID_HORIZONTAL","","0" , "TEXTO" },
            { "1","10_TIPO_AFILIADO","","NOSE" , "TEXTO" },

        };
        public static void RecargarVentanaEmergenteAfiliados_simples(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_afiliados_simples = new string[,]
            {
                { "2","0_ID_USUARIO","","-0" , "TEXTO" },
                { "1","1_ID_PAT_COMP","","-0" , "TEXTO" },
                { "1","2_TABLA_PAT_COMP","","NOSE" , "TEXTO" },
                { "1","3_ID_ENC_SIMP","", "-0", "TEXTO" },
                { "1","4_TABLA_ENC_SIMP","","NOSE" , "TEXTO" },
                { "1","5_PUNTOS_D","" ,"0", "TEXTO" },
                { "1","6_PUNTOS_D_A_DAR","" ,"0", "TEXTO" },
                { "1","7_DATOS","","" , "TEXTO" },
                { "1","8_NIVELES","","0" , "TEXTO" },
                { "1","9_ID_HORIZONTAL","","0" , "TEXTO" },
                { "1","10_TIPO_AFILIADO","","NOSE" , "TEXTO" },
            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }

        //ventana afiliados_complejos
        static public string[,] GG_ventana_afiliados_complejos =
        {
            { "2","0_ID_USUARIO","","0" , "TEXTO" },
            { "1","1_ID_PAT_COMP","","0" , "TEXTO" },
            { "1","2_TABLA_PAT_COMP","","NOSE" , "TEXTO" },
            { "1","3_ID_ENC_SIMP","","0" , "TEXTO" },
            { "1","4_TABLA_ENC_SIMP","","NOSE" , "TEXTO" },
            { "1","5_PUNTOS_D","","0" , "TEXTO" },
            { "1","6_PUNTOS_D_A_DAR","","0" , "TEXTO" },
            { "1","7_DATOS","","" , "TEXTO" },
            { "1","8_NIVELES","","0" , "TEXTO" },
            { "1","9_ID_HORIZONTAL","","0" , "TEXTO" },
            { "1","10_TIPO_AFILIADO","","0" , "TEXTO" },

        };
        public static void RecargarVentanaEmergenteAfiliados(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_afiliados_complejos = new string[,]
            {
                { "2","0_ID_USUARIO","","0" , "TEXTO" },
                { "1","1_ID_PAT_COMP","","0" , "TEXTO" },
                { "1","2_TABLA_PAT_COMP","","NOSE" , "TEXTO" },
                { "1","3_ID_ENC_SIMP","","0" , "TEXTO" },
                { "1","4_TABLA_ENC_SIMP","","NOSE" , "TEXTO" },
                { "1","5_PUNTOS_D","","0" , "TEXTO" },
                { "1","6_PUNTOS_D_A_DAR","","0" , "TEXTO" },
                { "1","7_DATOS","","" , "TEXTO" },
                { "1","8_NIVELES","","0" , "TEXTO" },
                { "1","9_ID_HORIZONTAL","","0" , "TEXTO" },
                { "1","10_TIPO_AFILIADO","","0" , "TEXTO" },
            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }

        //ventana niveles_afiliados_simples
        static public string[,] GG_ventana_niv_afiliados_simples =
        {
            { "1","0_NIVEL","","0" , "TEXTO" },
            { "1","1_ID_HORIZONTAL","","0" , "TEXTO" },
            { "1","2_VACIOS","","" , "TEXTO" },
        };
        public static void RecargarVentanaEmergente_niv_afiliados_simples(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_niv_afiliados_simples = new string[,]
            {
                { "1","0_NIVEL","","0" , "TEXTO" },
                { "1","1_ID_HORIZONTAL","","0" , "TEXTO" },
                { "1","2_VACIOS","","" , "TEXTO" },
            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }

        //ventana niv_afiliados_comp
        static public string[,] GG_ventana_niv_afiliados_comp =
        {
            { "1","0_NIVEL","","0" , "TEXTO" },
            { "1","1_ID_HORIZONTAL","","0" , "TEXTO" },
            { "1","2_VACIOS","","" , "TEXTO" },

        };
        public static void RecargarVentanaEmergente_niv_afiliados_comp(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_niv_afiliados_comp = new string[,]
            {
                { "1","0_NIVEL","","0" , "TEXTO" },
                { "1","1_ID_HORIZONTAL","","0" , "TEXTO" },
                { "1","2_VACIOS","","" , "TEXTO" },
            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }

        //ventana afiliados_unificados
        static public string[,] GG_ventana_afiliados_unificados =
        {
            { "1","0)ID_USUARIO","","0" , "TEXTO" },
            { "1","1)0IDP╦1IDP¬0PROYECTO_P°0IDP╦1IDP¬1PROYECTO_P","","0╦0¬0°0╦1¬1" , "TEXTO" },
            { "1","2)0IPUNTOS_D_R¬0PROYECTO_R°1PUNTOS_D_R¬1PROYECTO_R","","0¬0°0¬0" , "TEXTO" },
            { "1","3)PUNTOS_D_R_TOTALES","","0" , "TEXTO" },
            { "1","4)DATOS","" , "NOSE", "TEXTO" },
            { "1","5)NIVEL","" ,"0", "TEXTO" },
            { "1","6)ID_HORIZONTAL","" , "0", "TEXTO" },
            { "1","7)TIPO_AFILIADO","" ,"NOSE", "TEXTO" },

        };
        public static void RecargarVentanaEmergenteAfiliados_unificados(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_afiliados_unificados = new string[,]
            {
                { "1","0)ID_USUARIO","","0" , "TEXTO" },
                { "1","1)0IDP╦1IDP¬0PROYECTO_P°0IDP╦1IDP¬1PROYECTO_P","","0╦0¬0°0╦1¬1" , "TEXTO" },
                { "1","2)0IPUNTOS_D_R¬0PROYECTO_R°1PUNTOS_D_R¬1PROYECTO_R","","0¬0°0¬0" , "TEXTO" },
                { "1","3)PUNTOS_D_R_TOTALES","","0" , "TEXTO" },
                { "1","4)DATOS","" , "NOSE", "TEXTO" },
                { "1","5)NIVEL","" ,"0", "TEXTO" },
                { "1","6)ID_HORIZONTAL","" , "0", "TEXTO" },
                { "1","7)TIPO_AFILIADO","" ,"NOSE", "TEXTO" },

            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }

        //ventana niv_afiliados_comp
        static public string[,] GG_ventana_niv_afiliados_unificado =
        {
            { "1","0_NIVEL","","0" , "TEXTO" },
            { "1","1_ID_HORIZONTAL","","0" , "TEXTO" },
            { "1","2_VACIOS","" ,"", "TEXTO" },

        };
        public static void RecargarVentanaEmergente_niv_afiliados_unificado(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_niv_afiliados_unificado = new string[,]
            {
                { "1","0_NIVEL","","0" , "TEXTO" },
                { "1","1_ID_HORIZONTAL","","0" , "TEXTO" },
                { "1","2_VACIOS","" ,"", "TEXTO" },
            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }


        //ventana SUCURSALES
        static public string[,] GG_ventana_SUCUR =
        {
            { "1","0_NOM_ID_SUCUR","","-0" , "TEXTO" },
            { "1","1_NOMBRE_SUCUR","" , "NOSE", "TEXTO" },
            { "1","2_NOMBRE_ENCARGADO","" , "NOSE", "TEXTO" },
            { "1","3_DIRECCIÓN_SUCUR","" , "NOSE", "TEXTO" },
            { "1","4_CIUDAD_SUCUR","" , "NOSE", "TEXTO" },
            { "1","5_ESTADO_SUCUR","" , "NOSE", "TEXTO" },
            { "1","6_CÓDIGO_POSTAL","" , "NOSE", "TEXTO" },
            { "1","7_PAÍS","" , "NOSE", "TEXTO" },
            { "1","8_CORREO_ELECTRÓNICO","" , "NOSE", "TEXTO" },
            { "1","9_TELÉFONO_ENCARGADO","" , "NOSE", "TEXTO" },
            { "1","10_TELEFONO_SUCUR","" , "NOSE", "TEXTO" },
            { "1","11_TIPO_DE_SUCUR","" , "NOSE", "TEXTO" },
            { "1","12_PRODUCTOS_SERVICIOS_SUMINISTRADOS","" , "NOSE", "TEXTO" },
            { "1","13_CUENTA_BANCO","" , "NOSE", "TEXTO" },
            { "1","14_UBICACIÓN_(GPS)","" , "-0", "TEXTO" },
            { "1","15_NOTAS","" , "", "TEXTO" },
            { "1","16_RECORDATORIO","" , "NOSE", "TEXTO" },
            { "1","17_ACTIVO_O_NO_ACTIVO","" , "NOSE", "TEXTO" },
            { "1","18_HORA_ABRIR°HORA_CERRAR","" , "NOSE", "TEXTO" },


        };
        public static void RecargarVentanaEmergenteSUCUR(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_SUCUR = new string[,]
            {
                { "1","0_NOM_ID_SUCUR","","-0" , "TEXTO" },
                { "1","1_NOMBRE_SUCUR","" , "NOSE", "TEXTO" },
                { "1","2_NOMBRE_ENCARGADO","" , "NOSE", "TEXTO" },
                { "1","3_DIRECCIÓN_SUCUR","" , "NOSE", "TEXTO" },
                { "1","4_CIUDAD_SUCUR","" , "NOSE", "TEXTO" },
                { "1","5_ESTADO_SUCUR","" , "NOSE", "TEXTO" },
                { "1","6_CÓDIGO_POSTAL","" , "NOSE", "TEXTO" },
                { "1","7_PAÍS","" , "NOSE", "TEXTO" },
                { "1","8_CORREO_ELECTRÓNICO","" , "NOSE", "TEXTO" },
                { "1","9_TELÉFONO_ENCARGADO","" , "NOSE", "TEXTO" },
                { "1","10_TELEFONO_SUCUR","" , "NOSE", "TEXTO" },
                { "1","11_TIPO_DE_SUCUR","" , "NOSE", "TEXTO" },
                { "1","12_PRODUCTOS_SERVICIOS_SUMINISTRADOS","" , "NOSE", "TEXTO" },
                { "1","13_CUENTA_BANCO","" , "NOSE", "TEXTO" },
                { "1","14_UBICACIÓN_(GPS)","" , "-0", "TEXTO" },
                { "1","15_NOTAS","" , "", "TEXTO" },
                { "1","16_RECORDATORIO","" , "NOSE", "TEXTO" },
                { "1","17_ACTIVO_O_NO_ACTIVO","" , "NOSE", "TEXTO" },
                { "1","18_HORA_ABRIR°HORA_CERRAR","" , "NOSE", "TEXTO" },

            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }

        //REGISTROS-------------------------------------------------------------------------------------

        //registro dia
        static public string[,] GG_ventana_reg_dia =
        {

            { "1","0_HORA","" ,"0", "TEXTO" },
            { "1","1_OPERACION_1_VENTA_2_COMPRA_3_RETIRAR_DINERO_4_INTODUCIR","","NOSE" , "TEXTO" },
            { "1","2_IMPUESTO_1¬CANTIDAD_A_PAGAR_IMPUESTO_1¬PORCENTAGE_DE_IMPUESTO_1°IMPUESTO_2¬CANTIDAD_A_PAGAR_IMPUESTO_2¬PORCENTAGE_DE_IMPUESTO_2","","NOSE¬0" , "TEXTO" },
            { "1","3_CODIGO_PRECIOTOTAL_PRODUCTOS_CANTIDAD_PLATAFORMA_DATPLATAFORMA","" ,"NOSE", "TEXTO" },
            { "1","4_COMENTARIO","" ,"", "TEXTO" },
            { "1","5_TOTAL_VENTA","" ,"0", "TEXTO" },
            { "1","6_TOTAL_COSTO_COMP","","0" , "TEXTO" },
            { "1","7_TOTAL_IMPUESTOS","" ,"0", "TEXTO" },
            { "1","8_TOTAL_DEDUSIBLES_SOLO_SE_USA_EN_COMPRAS_Y_DONACIONES_SENECECITA_LA_FACTURA","" ,"0", "TEXTO" },
            { "1","9_TOTAL_GANANCIA_DESPUES_DE_IMPUESTOS","" ,"0", "TEXTO" },
            { "1","10_PLATAFORMA","" ,"NOSE", "TEXTO" },

        };
        public static void RecargarVentanaEmergenteRegDia(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {

            GG_ventana_reg_dia = new string[,]
            {
                { "1","0_HORA","" ,"0", "TEXTO" },
                { "1","1_OPERACION_1_VENTA_2_COMPRA_3_RETIRAR_DINERO_4_INTODUCIR","","NOSE" , "TEXTO" },
                { "1","2_IMPUESTO_1¬CANTIDAD_A_PAGAR_IMPUESTO_1¬PORCENTAGE_DE_IMPUESTO_1°IMPUESTO_2¬CANTIDAD_A_PAGAR_IMPUESTO_2¬PORCENTAGE_DE_IMPUESTO_2","","NOSE¬0" , "TEXTO" },
                { "1","3_CODIGO_PRECIOTOTAL_PRODUCTOS_CANTIDAD_PLATAFORMA_DATPLATAFORMA","" ,"NOSE", "TEXTO" },
                { "1","4_COMENTARIO","" ,"", "TEXTO" },
                { "1","5_TOTAL_VENTA","" ,"0", "TEXTO" },
                { "1","6_TOTAL_COSTO_COMP","","0" , "TEXTO" },
                { "1","7_TOTAL_IMPUESTOS","" ,"0", "TEXTO" },
                { "1","8_TOTAL_DEDUSIBLES_SOLO_SE_USA_EN_COMPRAS_Y_DONACIONES_SENECECITA_LA_FACTURA","" ,"0", "TEXTO" },
                { "1","9_TOTAL_GANANCIA_DESPUES_DE_IMPUESTOS","" ,"0", "TEXTO" },
                { "1","10_PLATAFORMA","" ,"NOSE", "TEXTO" },

            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }

        //registro mes
        static public string[,] GG_ventana_reg_mes =
        {

            { "1","0_DIA","" ,"0", "TEXTO" },
            { "1","1_OPERACION_1_VENTA_2_COMPRA_3_RETIRAR_DINERO_4_INTODUCIR","" ,"NOSE", "TEXTO" },
            { "1","2_IMPUESTO_1¬CANTIDAD_A_PAGAR_IMPUESTO_1¬PORCENTAGE_DE_IMPUESTO_1°IMPUESTO_2¬CANTIDAD_A_PAGAR_IMPUESTO_2¬PORCENTAGE_DE_IMPUESTO_2","","NOSE¬0" , "TEXTO" },
            { "1","3_PRODUCTOS_PRECIOTOTAL_CANTIDAD","","0" , "TEXTO" },
            { "1","4_COMENTARIO","" ,"", "TEXTO" },
            { "1","5_TOTAL_VENTA","" ,"0", "TEXTO" },
            { "1","6_TOTAL_COSTO_COMP","","0" , "TEXTO" },
            { "1","7_TOTAL_IMPUESTOS","" ,"0", "TEXTO" },
            { "1","8_TOTAL_DEDUSIBLES_SOLO_SE_USA_EN_COMPRAS_Y_DONACIONES_SENECECITA_LA_FACTURA","","0" , "TEXTO" },
            { "1","9_TOTAL_GANANCIA_DESPUES_DE_IMPUESTOS","","0" , "TEXTO" },


        };
        public static void RecargarVentanaEmergenteRegMes(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {

            GG_ventana_reg_mes = new string[,]
            {
                { "1","0_DIA","" ,"0", "TEXTO" },
                { "1","1_OPERACION_1_VENTA_2_COMPRA_3_RETIRAR_DINERO_4_INTODUCIR","" ,"NOSE", "TEXTO" },
                { "1","2_IMPUESTO_1¬CANTIDAD_A_PAGAR_IMPUESTO_1¬PORCENTAGE_DE_IMPUESTO_1°IMPUESTO_2¬CANTIDAD_A_PAGAR_IMPUESTO_2¬PORCENTAGE_DE_IMPUESTO_2","","NOSE¬0" , "TEXTO" },
                { "1","3_PRODUCTOS_PRECIOTOTAL_CANTIDAD","","0" , "TEXTO" },
                { "1","4_COMENTARIO","" ,"", "TEXTO" },
                { "1","5_TOTAL_VENTA","" ,"0", "TEXTO" },
                { "1","6_TOTAL_COSTO_COMP","","0" , "TEXTO" },
                { "1","7_TOTAL_IMPUESTOS","" ,"0", "TEXTO" },
                { "1","8_TOTAL_DEDUSIBLES_SOLO_SE_USA_EN_COMPRAS_Y_DONACIONES_SENECECITA_LA_FACTURA","","0" , "TEXTO" },
                { "1","9_TOTAL_GANANCIA_DESPUES_DE_IMPUESTOS","","0" , "TEXTO" },

            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }

        //registro año
        static public string[,] GG_ventana_reg_año =
        {

            { "1","0_MES","" ,"0", "TEXTO" },
            { "1","1_OPERACION_1_VENTA_2_COMPRA_3_RETIRAR_DINERO_4_INTODUCIR","" ,"NOSE", "TEXTO" },
            { "1","2_IMPUESTO_1¬CANTIDAD_A_PAGAR_IMPUESTO_1¬PORCENTAGE_DE_IMPUESTO_1°IMPUESTO_2¬CANTIDAD_A_PAGAR_IMPUESTO_2¬PORCENTAGE_DE_IMPUESTO_2","","NOSE¬0" , "TEXTO" },
            { "1","3_PRODUCTOS_PRECIOTOTAL_CANTIDAD","" ,"NOSE", "TEXTO" },
            { "1","4_COMENTARIO","","" , "TEXTO" },
            { "1","5_TOTAL_VENTA","","0" , "TEXTO" },
            { "1","6_TOTAL_COSTO_COMP","","0" , "TEXTO" },
            { "1","7_TOTAL_IMPUESTOS","","0" , "TEXTO" },
            { "1","8_TOTAL_DEDUSIBLES_SOLO_SE_USA_EN_COMPRAS_Y_DONACIONES_SENECECITA_LA_FACTURA","","0" , "TEXTO" },
            { "1","9_TOTAL_GANANCIA_DESPUES_DE_IMPUESTOS","" ,"0", "TEXTO" },




        };
        public static void RecargarVentanaEmergenteRegAño(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_reg_año = new string[,]
            {
                { "1","0_MES","" ,"0", "TEXTO" },
                { "1","1_OPERACION_1_VENTA_2_COMPRA_3_RETIRAR_DINERO_4_INTODUCIR","" ,"NOSE", "TEXTO" },
                { "1","2_IMPUESTO_1¬CANTIDAD_A_PAGAR_IMPUESTO_1¬PORCENTAGE_DE_IMPUESTO_1°IMPUESTO_2¬CANTIDAD_A_PAGAR_IMPUESTO_2¬PORCENTAGE_DE_IMPUESTO_2","","NOSE¬0" , "TEXTO" },
                { "1","3_PRODUCTOS_PRECIOTOTAL_CANTIDAD","" ,"NOSE", "TEXTO" },
                { "1","4_COMENTARIO","","" , "TEXTO" },
                { "1","5_TOTAL_VENTA","","0" , "TEXTO" },
                { "1","6_TOTAL_COSTO_COMP","","0" , "TEXTO" },
                { "1","7_TOTAL_IMPUESTOS","","0" , "TEXTO" },
                { "1","8_TOTAL_DEDUSIBLES_SOLO_SE_USA_EN_COMPRAS_Y_DONACIONES_SENECECITA_LA_FACTURA","","0" , "TEXTO" },
                { "1","9_TOTAL_GANANCIA_DESPUES_DE_IMPUESTOS","" ,"0", "TEXTO" },


            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }

        //registro total
        static public string[,] GG_ventana_reg_total =
        {

            { "1","0_AÑO","","0" , "TEXTO" },
            { "1","1_OPERACION_1_VENTA_2_COMPRA_3_RETIRAR_DINERO_4_INTODUCIR","" , "NOSE", "TEXTO" },
            { "1","2_IMPUESTO_1¬CANTIDAD_A_PAGAR_IMPUESTO_1¬PORCENTAGE_DE_IMPUESTO_1°IMPUESTO_2¬CANTIDAD_A_PAGAR_IMPUESTO_2¬PORCENTAGE_DE_IMPUESTO_2","" , "NOSE¬0", "TEXTO" },
            { "1","3_PRODUCTOS_PRECIOTOTAL_CANTIDAD","" , "0", "TEXTO" },
            { "1","4_COMENTARIO","" , "", "TEXTO" },
            { "1","5_TOTAL_VENTA","" , "0", "TEXTO" },
            { "1","6_TOTAL_COSTO_COMP","", "0" , "TEXTO" },
            { "1","7_TOTAL_IMPUESTOS","" , "0", "TEXTO" },
            { "1","8_TOTAL_DEDUSIBLES_SOLO_SE_USA_EN_COMPRAS_Y_DONACIONES_SENECECITA_LA_FACTURA","" , "0", "TEXTO" },
            { "1","9_TOTAL_GANANCIA_DESPUES_DE_IMPUESTOS","" , "0", "TEXTO" },


        };
        public static void RecargarVentanaEmergenteRegTotal(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_reg_total = new string[,]
            {
                { "1","0_AÑO","","0" , "TEXTO" },
                { "1","1_OPERACION_1_VENTA_2_COMPRA_3_RETIRAR_DINERO_4_INTODUCIR","" , "NOSE", "TEXTO" },
                { "1","2_IMPUESTO_1¬CANTIDAD_A_PAGAR_IMPUESTO_1¬PORCENTAGE_DE_IMPUESTO_1°IMPUESTO_2¬CANTIDAD_A_PAGAR_IMPUESTO_2¬PORCENTAGE_DE_IMPUESTO_2","" , "NOSE¬0", "TEXTO" },
                { "1","3_PRODUCTOS_PRECIOTOTAL_CANTIDAD","" , "0", "TEXTO" },
                { "1","4_COMENTARIO","" , "", "TEXTO" },
                { "1","5_TOTAL_VENTA","" , "0", "TEXTO" },
                { "1","6_TOTAL_COSTO_COMP","", "0" , "TEXTO" },
                { "1","7_TOTAL_IMPUESTOS","" , "0", "TEXTO" },
                { "1","8_TOTAL_DEDUSIBLES_SOLO_SE_USA_EN_COMPRAS_Y_DONACIONES_SENECECITA_LA_FACTURA","" , "0", "TEXTO" },
                { "1","9_TOTAL_GANANCIA_DESPUES_DE_IMPUESTOS","" , "0", "TEXTO" },

            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }



        //registros productos


        //registro produc dia
        static public string[,] GG_ventana_reg_prod_dia =
        {

            { "1","0_HORA","" ,"0", "TEXTO" },
            { "1","1_OPERACION_VENTA_COMPRA_RETIRAR_PRODUCTO_INTODUCIR_PRODUCTO","" , "NOSE", "TEXTO" },
            { "1","2_COD_BAR_CANTIDADES_NOMBRE_PRODUCTO_PLATAFORMA_DATOSPLATAFORMA","" , "NOSE", "TEXTO" },


        };
        public static void RecargarVentanaEmergenteReg_prod_Dia(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_reg_prod_dia = new string[,]
            {
                { "1","0_HORA","" ,"0", "TEXTO" },
                { "1","1_OPERACION_VENTA_COMPRA_RETIRAR_PRODUCTO_INTODUCIR_PRODUCTO","" , "NOSE", "TEXTO" },
                { "1","2_COD_BAR_CANTIDADES_NOMBRE_PRODUCTO_PLATAFORMA_DATOSPLATAFORMA","" , "NOSE", "TEXTO" },

            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }

        //registro produc mes
        static public string[,] GG_ventana_reg_prod_mes =
        {


            { "1","0_NOMBRE_PRODUCTO","","NOSE" , "TEXTO" },
            { "1","1_CANTIDAD","" , "0", "TEXTO" },
            { "1","2_COD_BAR","" , "NOSE", "TEXTO" },
            { "1","3_PROVEDORES","" , "NOSE", "TEXTO" },
            { "1","4_HISTORIAL","" , "0°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°", "TEXTO" },
            { "1","5_RANKING","" , "0", "TEXTO" },
            { "1","6_PROMEDIO","" , "0", "TEXTO" },
            { "1","7_VECES_QUE_SUPERA_PROMEDIO","","7" , "TEXTO" },
            { "1","8_USO_MULTIPLE","" ,"", "TEXTO" },              // Nueva columna
            { "1","9_USOMULTI_TIPO_DE_PRODUCTO","","" , "TEXTO" },  // Nueva columna
            { "1","10_MULTI_COSTO_COMPRA","" , "0", "TEXTO" },        // Nueva columna
            { "1","11_NIVEL_DE_NESECIDAD","" , "0", "TEXTO" },        // Nueva columna

        };
        public static void RecargarVentanaEmergenteReg_prod_Mes(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_reg_prod_mes = new string[,]
            {
                { "1","0_NOMBRE_PRODUCTO","","NOSE" , "TEXTO" },
                { "1","1_CANTIDAD","" , "0", "TEXTO" },
                { "1","2_COD_BAR","" , "NOSE", "TEXTO" },
                { "1","3_PROVEDORES","" , "NOSE", "TEXTO" },
                { "1","4_HISTORIAL","" , "0°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°", "TEXTO" },
                { "1","5_RANKING","" , "0", "TEXTO" },
                { "1","6_PROMEDIO","" , "0", "TEXTO" },
                { "1","7_VECES_QUE_SUPERA_PROMEDIO","","7" , "TEXTO" },
                { "1","8_USO_MULTIPLE","" ,"", "TEXTO" },              // Nueva columna
                { "1","9_USOMULTI_TIPO_DE_PRODUCTO","","" , "TEXTO" },  // Nueva columna
                { "1","10_MULTI_COSTO_COMPRA","" , "", "TEXTO" },        // Nueva columna
                { "1","11_NIVEL_DE_NESECIDAD","" , "0", "TEXTO" },        // Nueva columna
            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }

        //registro produc año
        static public string[,] GG_ventana_reg_prod_año =
        {

            { "1","0_NOMBRE_PRODUCTO","" ,"NOSE", "TEXTO" },
            { "1","1_CANTIDAD","" , "0", "TEXTO" },
            { "1","2_COD_BAR","" , "NOSE", "TEXTO" },
            { "1","3_PROVEDORES","" , "NOSE", "TEXTO" },
            { "1","4_HISTORIAL","","0°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°" , "TEXTO" },
            { "1","5_RANKING","" , "0", "TEXTO" },
            { "1","6_PROMEDIO","" , "0", "TEXTO" },
            { "1","7_VECES_QUE_SUPERA_PROMEDIO","" , "7", "TEXTO" },
            { "1","8_USO_MULTIPLE","" , "", "TEXTO" },              // Nueva columna
            { "1","9_USOMULTI_TIPO_DE_PRODUCTO","" , "", "TEXTO" },  // Nueva columna
            { "1","10_MULTI_COSTO_COMPRA","" , "0", "TEXTO" },        // Nueva columna
            { "1","11_NIVEL_DE_NESECIDAD","" , "0", "TEXTO" },        // Nueva columna

        };
        public static void RecargarVentanaEmergenteReg_prod_Año(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_reg_prod_año = new string[,]
            {
                { "1","0_NOMBRE_PRODUCTO","" ,"NOSE", "TEXTO" },
                { "1","1_CANTIDAD","" , "0", "TEXTO" },
                { "1","2_COD_BAR","" , "NOSE", "TEXTO" },
                { "1","3_PROVEDORES","" , "NOSE", "TEXTO" },
                { "1","4_HISTORIAL","","0°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°" , "TEXTO" },
                { "1","5_RANKING","" , "0", "TEXTO" },
                { "1","6_PROMEDIO","" , "0", "TEXTO" },
                { "1","7_VECES_QUE_SUPERA_PROMEDIO","" , "7", "TEXTO" },
                { "1","8_USO_MULTIPLE","" , "", "TEXTO" },              // Nueva columna
                { "1","9_USOMULTI_TIPO_DE_PRODUCTO","" , "", "TEXTO" },  // Nueva columna
                { "1","10_MULTI_COSTO_COMPRA","" , "0", "TEXTO" },        // Nueva columna
                { "1","11_NIVEL_DE_NESECIDAD","" , "0", "TEXTO" },        // Nueva columna
            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }

        //registro produc total
        static public string[,] GG_ventana_reg_prod_total =
        {
            { "1","0_NOMBRE_PRODUCTO","" ,"NOSE", "TEXTO" },
            { "1","1_CANTIDAD","" , "0", "TEXTO" },
            { "1","2_COD_BAR","" , "NOSE", "TEXTO" },
            { "1","3_PROVEDORES","" , "NOSE", "TEXTO" },
            { "1","4_HISTORIAL","","0°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°" , "TEXTO" },
            { "1","5_RANKING","" , "0", "TEXTO" },
            { "1","6_PROMEDIO","" , "0", "TEXTO" },
            { "1","7_VECES_QUE_SUPERA_PROMEDIO","" , "7", "TEXTO" },
            { "1","8_USO_MULTIPLE","" , "", "TEXTO" },              // Nueva columna
            { "1","9_USOMULTI_TIPO_DE_PRODUCTO","" , "", "TEXTO" },  // Nueva columna
            { "1","10_MULTI_COSTO_COMPRA","" , "0", "TEXTO" },        // Nueva columna
            { "1","11_NIVEL_DE_NESECIDAD","" , "0", "TEXTO" },        // Nueva columna


        };
        public static void RecargarVentanaEmergenteReg_prod_total(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_reg_prod_total = new string[,]
            {
                { "1","0_NOMBRE_PRODUCTO","" ,"NOSE", "TEXTO" },
                { "1","1_CANTIDAD","" , "0", "TEXTO" },
                { "1","2_COD_BAR","" , "NOSE", "TEXTO" },
                { "1","3_PROVEDORES","" , "NOSE", "TEXTO" },
                { "1","4_HISTORIAL","","0°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°" , "TEXTO" },
                { "1","5_RANKING","" , "0", "TEXTO" },
                { "1","6_PROMEDIO","" , "0", "TEXTO" },
                { "1","7_VECES_QUE_SUPERA_PROMEDIO","" , "7", "TEXTO" },
                { "1","8_USO_MULTIPLE","" , "", "TEXTO" },              // Nueva columna
                { "1","9_USOMULTI_TIPO_DE_PRODUCTO","" , "", "TEXTO" },  // Nueva columna
                { "1","10_MULTI_COSTO_COMPRA","" , "0", "TEXTO" },        // Nueva columna
                { "1","11_NIVEL_DE_NESECIDAD","" , "0", "TEXTO" },        // Nueva columna

            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }

        //impuestos
        //ventana IMPUESTOS
        static public string[,] GG_ventana_IMPUESTOS =
        {
            { "1","0_IMPUESTO","","0" , "TEXTO" },
            { "1","1_PORCENTAGE","" , "0", "TEXTO" },
            { "1","2_DESCRIPCION","" , "NOSE", "TEXTO" },
            { "1","3_INFO_EXTRA","" , "NOSE", "TEXTO" },
            { "1","3_IMPUESTO_1_DIRECTO_2_INDIRECTO_3_NOSE","" , "3", "TEXTO" },

        };

        public static void RecargarVentanaEmergenteImpuestos(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_IMPUESTOS = new string[,]
            {
                { "1","0_IMPUESTO","","0" , "TEXTO" },
                { "1","1_PORCENTAGE","" , "0", "TEXTO" },
                { "1","2_DESCRIPCION","" , "NOSE", "TEXTO" },
                { "1","3_INFO_EXTRA","" , "NOSE", "TEXTO" },
                { "1","3_IMPUESTO_1_DIRECTO_2_INDIRECTO_3_NOSE","" , "3", "TEXTO" },


            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }

        //ventana DEDUSIBLES
        static public string[,] GG_ventana_DEDUSIBLES =
        {
            { "1","0_FECHA_yyyyMMddHH","" ,"0", "TEXTO" },
            { "1","1_MONTO","" , "0", "TEXTO" },
            { "1","2_DESCRIPCION","" , "NOSE", "TEXTO" },
            { "1","3_PROVEDOR_O_INSTITUCION_DE_LA_FACTURA_O_DONACION","" , "NOSE", "TEXTO" },
            { "1","4_DIRECCION_ARCHIVO_FACTURA","" , "NOSE", "TEXTO" },
            { "1","5_FOLIO","" , "NOSE", "TEXTO" },

        };

        public static void RecargarVentanaEmergenteDedusibles(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_DEDUSIBLES = new string[,]
            {
                { "1","0_FECHA_yyyyMMddHH","" ,"0", "TEXTO" },
                { "1","1_MONTO","" , "0", "TEXTO" },
                { "1","2_DESCRIPCION","" , "NOSE", "TEXTO" },
                { "1","3_PROVEDOR_O_INSTITUCION_DE_LA_FACTURA_O_DONACION","" , "NOSE", "TEXTO" },
                { "1","4_DIRECCION_ARCHIVO_FACTURA","" , "NOSE", "TEXTO" },
                { "1","5_FOLIO","" , "NOSE", "TEXTO" },
            };



            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }

        //HERRAMIENTAS
        static public string[,] GG_ventana_HERRAMIENTAS =
        {
            { "1","0_COD_BAR","","" , "TEXTO" },

        };
        public static void RecargarVentanaEmergente_HERRAMIENTAS(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_HERRAMIENTAS = new string[,]
            {
                { "1","0_COD_BAR","","" , "TEXTO" },

            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }


        //trabajos_por_dia
        static public string[,] GG_trabajos_dia =
        {
            { "1","dia|trabajos_cada_fila_es_un_dia°id_trabajador_sie_es_vacio_son_todos°hecho_o_no°id_quienlo_iso_si_es_vacio_son_todos°id_programa_enviar","","" , "TEXTO" },

        };
        public static void RecargarVentanaEmergente_TRABAJOS_DIA(string al_finalizar_que_borrar_para_proxima_ventana = "")
        {
            GG_ventana_HERRAMIENTAS = new string[,]
            {
                { "1","dia|trabajos_cada_fila_es_un_dia°id_trabajador_sie_es_vacio_son_todos°hecho_o_no°id_quienlo_iso_si_es_vacio_son_todos°id_programa_enviar","","" , "TEXTO" },

            };


            if (al_finalizar_que_borrar_para_proxima_ventana != null)
            {


                string[] datos_a_borrar = al_finalizar_que_borrar_para_proxima_ventana.ToString().Split(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));

                for (int i = 0; i < datos_a_borrar.Length; i++)
                {

                    if (datos_a_borrar[i] == "TODO")
                    {
                        GG_variables_string = new[]
                        {
                            /*0*/ "",//tex_esplit[0]//codbar
                            /*1*/ "",//prov_anterior
                            /*2*/ "", //provedores_txt//todos_los_provedores
                            /*3*/ "",//impuesto anterior
                            /*4*/ "", //impuestos_txt//todos_los_impuestos
                            /*5*/ "",//tipo_medida_producto_anterior
                            /*6*/ ""//tipo_medida_producto_txt//todos_los_tipos_de_medida
           
                        };
                    }

                    else if (datos_a_borrar[i] == "") { }

                    else
                    {
                        GG_variables_string[Convert.ToInt32(datos_a_borrar[i])] = "";
                    }

                }
            }

        }



        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        public static string columnas_concatenadas(string[,] arreglo_bidimencional, int id_columna, string caracter_separacion = null)
        {
            if (caracter_separacion == null)
            {
                caracter_separacion = var_fun_GG.GG_caracter_separacion[0];
            }
            string nombresConcatenados = "";

            for (int i = 0; i < arreglo_bidimencional.GetLength(0); i++)
            {
                string nombre = arreglo_bidimencional[i, id_columna];
                nombresConcatenados += nombre + Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]);
            }

            if (!string.IsNullOrEmpty(nombresConcatenados))
            {
                nombresConcatenados = nombresConcatenados.TrimEnd(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));
            }

            return nombresConcatenados;
        }


        static public string[] GG_direccion_carpetas_base = { "" };



        static public string[,] GG_dir_nom_archivos =
        {
            /*0*/{ GG_direccion_carpetas_base[0] + "ARCHIVOS_INICIALES\\INICIO.TXT",columnas_concatenadas(GG_ventana_datos_conf,1,var_fun_GG.GG_caracter_separacion[0]),"|DIA_SE_ABRIO§1|ULTIMO_ID_VEND"},
            /*1*/{ GG_direccion_carpetas_base[0] + "CONFIG\\INF\\INVENTARIO\\INVENTARIO.TXT", columnas_concatenadas(GG_ventana_emergente_productos,1,var_fun_GG.GG_caracter_separacion[0]),""},
            /*2*/{ GG_direccion_carpetas_base[0] + "CONFIG\\INF\\DAT\\PROVEDORES.TXT", columnas_concatenadas(GG_ventana_provedor,1,var_fun_GG.GG_caracter_separacion[0]),"1|NOSE|2_NOMBRE_ENCARGADO|3_DIRECCIÓN_EMPRESA|4_CIUDAD_EMPRESA|5_ESTADO_EMPRESA|6_CÓDIGO_POSTAL|7_PAÍS|8_CORREO_ELECTRÓNICO|9_TELÉFONO_ENCARGADO|10_TELEFONO_EMPRESA|11_TIPO_DE_PROVEEDOR|12_PRODUCTOS_SERVICIOS_SUMINISTRADOS|13_CUENTA_BANCO|14_UBICACIÓN_(GPS)|15_NOTAS|16_RECORDATORIO|17_ACTIVO_O_NO_ACTIVO|18_CALIFICACION_PREVENTA¬0°CALIFICACION_ENTREGA¬0|19_COMENTARIOS_PREVENTA_ENTREGA|20_SUCURSALES_QUE_LE_COMPRAN|0|22_DIAS_DE_PREVENTA_0°DIAS_DE_PREVENTA_1|23_DIAS_DE_ENTREGA_0°DIAS_DE_ENTREGA_1§2|NOSE2|2_NOMBRE_ENCARGADO2|3_DIRECCIÓN_EMPRESA|4_CIUDAD_EMPRESA|5_ESTADO_EMPRESA|6_CÓDIGO_POSTAL|7_PAÍS|8_CORREO_ELECTRÓNICO|9_TELÉFONO_ENCARGADO|10_TELEFONO_EMPRESA|11_TIPO_DE_PROVEEDOR|12_PRODUCTOS_SERVICIOS_SUMINISTRADOS|13_CUENTA_BANCO|14_UBICACIÓN_(GPS)|15_NOTAS|16_RECORDATORIO|17_ACTIVO_O_NO_ACTIVO|18_CALIFICACION_PREVENTA¬0°CALIFICACION_ENTREGA¬0|19_COMENTARIOS_PREVENTA_ENTREGA|20_SUCURSALES_QUE_LE_COMPRAN|0|22_DIAS_DE_PREVENTA_0°DIAS_DE_PREVENTA_1|23_DIAS_DE_ENTREGA_0°DIAS_DE_ENTREGA_1"},
            /*3*/{ GG_direccion_carpetas_base[0] + "CONFIG\\INF\\DAT\\APRENDICES_E.TXT", columnas_concatenadas(GG_ventana_APRENDICES_E,1,var_fun_GG.GG_caracter_separacion[0]),""},
            /*4*/{ GG_direccion_carpetas_base[0] + "CONFIG\\AFILIADOS\\AFILIADOS_SIMPLE.TXT", columnas_concatenadas(GG_ventana_afiliados_simples,1,var_fun_GG.GG_caracter_separacion[0]),"0|0|TABLA_COMPLEJA|0|TABLA_SIMPLE|0|0|0_NOM_PRU°1_AP_PAT_PRU°2_APE_MAT_PRU°0╦BANCO°4_CURP°5_CLAV_ELECTOR°6_OTRA_ID_IDENTIFICACION°7_0000000000°8_DIRECCION°9_COLONIA°10_MUNICIOPIO°11_ESTADO°12_CORREO@CORREO.COM|0|0||§1|0|TABLA_COMPLEJA|0|TABLA_SIMPLE|0|0|0_NOM_PRU°1_AP_PAT_PRU°2_APE_MAT_PRU°0╦BANCO°4_CURP°5_CLAV_ELECTOR°6_OTRA_ID_IDENTIFICACION°7_0000000000°8_DIRECCION°9_COLONIA°10_MUNICIOPIO°11_ESTADO°12_CORREO@CORREO.COM|1|0||§2|1|TABLA_COMPLEJA|1|TABLA_SIMPLE|0|0|0_NOM_PRU°1_AP_PAT_PRU°2_APE_MAT_PRU°0╦BANCO°4_CURP°5_CLAV_ELECTOR°6_OTRA_ID_IDENTIFICACION°7_0000000000°8_DIRECCION°9_COLONIA°10_MUNICIOPIO°11_ESTADO°12_CORREO@CORREO.COM|2|0||§3|2|TABLA_COMPLEJA|2|TABLA_SIMPLE|0|0|0_NOM_PRU°1_AP_PAT_PRU°2_APE_MAT_PRU°0╦BANCO°4_CURP°5_CLAV_ELECTOR°6_OTRA_ID_IDENTIFICACION°7_0000000000°8_DIRECCION°9_COLONIA°10_MUNICIOPIO°11_ESTADO°12_CORREO@CORREO.COM|3|0||§4|3|TABLA_COMPLEJA|3|TABLA_SIMPLE|0|0|0_NOM_PRU°1_AP_PAT_PRU°2_APE_MAT_PRU°0╦BANCO°4_CURP°5_CLAV_ELECTOR°6_OTRA_ID_IDENTIFICACION°7_0000000000°8_DIRECCION°9_COLONIA°10_MUNICIOPIO°11_ESTADO°12_CORREO@CORREO.COM|4|0||"},
            /*5*/{ GG_direccion_carpetas_base[0] + "CONFIG\\AFILIADOS\\AFILIADOS_COMPLEJO.TXT", columnas_concatenadas(GG_ventana_afiliados_complejos,1,var_fun_GG.GG_caracter_separacion[0]),"0|0|TABLA_COMPLEJA|0|TABLA_SIMPLE|0|0|0_NOM_PRU°1_AP_PAT_PRU°2_APE_MAT_PRU°0╦BANCO°4_CURP°5_CLAV_ELECTOR°6_OTRA_ID_IDENTIFICACION°7_0000000000°8_DIRECCION°9_COLONIA°10_MUNICIOPIO°11_ESTADO°12_CORREO@CORREO.COM|0|0||§1|0|TABLA_COMPLEJA|0|TABLA_SIMPLE|0|0|0_NOM_PRU°1_AP_PAT_PRU°2_APE_MAT_PRU°0╦BANCO°4_CURP°5_CLAV_ELECTOR°6_OTRA_ID_IDENTIFICACION°7_0000000000°8_DIRECCION°9_COLONIA°10_MUNICIOPIO°11_ESTADO°12_CORREO@CORREO.COM|1|0||§2|0|TABLA_COMPLEJA|1|TABLA_SIMPLE|0|0|0_NOM_PRU°1_AP_PAT_PRU°2_APE_MAT_PRU°0╦BANCO°4_CURP°5_CLAV_ELECTOR°6_OTRA_ID_IDENTIFICACION°7_0000000000°8_DIRECCION°9_COLONIA°10_MUNICIOPIO°11_ESTADO°12_CORREO@CORREO.COM|2|0||§3|0|TABLA_COMPLEJA|2|TABLA_SIMPLE|0|0|0_NOM_PRU°1_AP_PAT_PRU°2_APE_MAT_PRU°0╦BANCO°4_CURP°5_CLAV_ELECTOR°6_OTRA_ID_IDENTIFICACION°7_0000000000°8_DIRECCION°9_COLONIA°10_MUNICIOPIO°11_ESTADO°12_CORREO@CORREO.COM|3|0||§4|0|TABLA_COMPLEJA|3|TABLA_SIMPLE|0|0|0_NOM_PRU°1_AP_PAT_PRU°2_APE_MAT_PRU°0╦BANCO°4_CURP°5_CLAV_ELECTOR°6_OTRA_ID_IDENTIFICACION°7_0000000000°8_DIRECCION°9_COLONIA°10_MUNICIOPIO°11_ESTADO°12_CORREO@CORREO.COM|4|0||"},
            /*6*/{ GG_direccion_carpetas_base[0] + "CONFIG\\AFILIADOS\\NIVELES_E_ID_HORISONTAL_AFILIADOS_SIMPLE.TXT", columnas_concatenadas(GG_ventana_niv_afiliados_simples,1,var_fun_GG.GG_caracter_separacion[0]),"1|1|§2|1|§3|1|§4|1|"},
            /*7*/{ GG_direccion_carpetas_base[0] + "CONFIG\\AFILIADOS\\NIVELES_E_ID_HORISONTAL_AFILIADOS_COMPLEJO.TXT", columnas_concatenadas(GG_ventana_niv_afiliados_comp,1,var_fun_GG.GG_caracter_separacion[0]),"1|1|§2|1|§3|1|§4|1|"},
            /*8*/{ GG_direccion_carpetas_base[0] + "CONFIG\\AFILIADOS\\AFILIADOS_UNIFICADO.TXT", columnas_concatenadas(GG_ventana_afiliados_unificados,1,var_fun_GG.GG_caracter_separacion[0]),"0|0╦0¬0AFILIADOS_UNIFICADO°0╦0¬AFILIADOS_UNIFICADO1|0¬AFILIADOS_UNIFICADO°0¬AFILIADOS_UNIFICADO1|0|0_NOM_PRU°1_AP_PAT_PRU°2_APE_MAT_PRU°0╦BANCO°4_CURP°5_CLAV_ELECTOR°6_OTRA_ID_IDENTIFICACION°7_0000000000°8_DIRECCION°9_COLONIA°10_MUNICIOPIO°11_ESTADO°12_CORREO@CORREO.COM|0|0||§1|0¬AFILIADOS_UNIFICADO_P|0¬AFILIADOS_UNIFICADO|0|0_NOM_PRU°1_AP_PAT_PRU°2_APE_MAT_PRU°0╦BANCO°4_CURP°5_CLAV_ELECTOR°6_OTRA_ID_IDENTIFICACION°7_0000000000°8_DIRECCION°9_COLONIA°10_MUNICIOPIO°11_ESTADO°12_CORREO@CORREO.COM|1|0||§2|1¬AFILIADOS_UNIFICADO|0¬AFILIADOS_UNIFICADO|0|0_NOM_PRU°1_AP_PAT_PRU°2_APE_MAT_PRU°0╦BANCO°4_CURP°5_CLAV_ELECTOR°6_OTRA_ID_IDENTIFICACION°7_0000000000°8_DIRECCION°9_COLONIA°10_MUNICIOPIO°11_ESTADO°12_CORREO@CORREO.COM|2|0||§3|2¬AFILIADOS_UNIFICADO|0¬AFILIADOS_UNIFICADO|0|0_NOM_PRU°1_AP_PAT_PRU°2_APE_MAT_PRU°0╦BANCO°4_CURP°5_CLAV_ELECTOR°6_OTRA_ID_IDENTIFICACION°7_0000000000°8_DIRECCION°9_COLONIA°10_MUNICIOPIO°11_ESTADO°12_CORREO@CORREO.COM|3|0||§4|3¬AFILIADOS_UNIFICADO|0¬AFILIADOS_UNIFICADO|0|0_NOM_PRU°1_AP_PAT_PRU°2_APE_MAT_PRU°0╦BANCO°4_CURP°5_CLAV_ELECTOR°6_OTRA_ID_IDENTIFICACION°7_0000000000°8_DIRECCION°9_COLONIA°10_MUNICIOPIO°11_ESTADO°12_CORREO@CORREO.COM|4|0||"},
            /*9*/{ GG_direccion_carpetas_base[0] + "CONFIG\\AFILIADOS\\NIVELES_E_ID_HORISONTAL_AFILIADOS_UNIFICADO.TXT", columnas_concatenadas(GG_ventana_niv_afiliados_unificado,1,var_fun_GG.GG_caracter_separacion[0]),"1|1|§2|1|§3|1|§4|1|"},
            /*10*/{ GG_direccion_carpetas_base[0] + "CONFIG\\INF\\DAT\\SUCUR.TXT", columnas_concatenadas(GG_ventana_SUCUR,1,var_fun_GG.GG_caracter_separacion[0]),""},
            //registros
            /*11*/{ GG_direccion_carpetas_base[0] + "CONFIG\\INF\\REGISTROS\\FECHAS\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("yyyyMM") + "\\" + DateTime.Now.ToString("yyyyMMdd") + "_REGISTRO.TXT", columnas_concatenadas(GG_ventana_reg_dia,1,var_fun_GG.GG_caracter_separacion[0]),""},
            /*12*/{ GG_direccion_carpetas_base[0] + "CONFIG\\INF\\REGISTROS\\FECHAS\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("yyyyMM") + "_REGISTRO.TXT", columnas_concatenadas(GG_ventana_reg_mes,1,var_fun_GG.GG_caracter_separacion[0]),""},
            /*13*/{ GG_direccion_carpetas_base[0] + "CONFIG\\INF\\REGISTROS\\FECHAS\\" + DateTime.Now.ToString("yyyy") + "_REGISTRO.TXT", columnas_concatenadas(GG_ventana_reg_año,1,var_fun_GG.GG_caracter_separacion[0]),""},
            /*14*/{ GG_direccion_carpetas_base[0] + "CONFIG\\INF\\REGISTROS\\ACUMULADO_REGISTRO.TXT", columnas_concatenadas(GG_ventana_reg_total,1,var_fun_GG.GG_caracter_separacion[0]),""},
            //registro productos
            /*15*/{ GG_direccion_carpetas_base[0] + "CONFIG\\INF\\REGISTROS\\FECHAS\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("yyyyMM") + "\\" + DateTime.Now.ToString("yyyyMMdd") + "_PRODUC_REGISTRO.TXT", columnas_concatenadas(GG_ventana_reg_prod_dia,1,var_fun_GG.GG_caracter_separacion[0]),""},
            /*16*/{ GG_direccion_carpetas_base[0] + "CONFIG\\INF\\REGISTROS\\FECHAS\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("yyyyMM") + "_PRODUC_REGISTRO.TXT", columnas_concatenadas(GG_ventana_reg_prod_mes,1,var_fun_GG.GG_caracter_separacion[0]),""},
            /*17*/{ GG_direccion_carpetas_base[0] + "CONFIG\\INF\\REGISTROS\\FECHAS\\" + DateTime.Now.ToString("yyyy") + "_PRODUC_REGISTRO.TXT", columnas_concatenadas(GG_ventana_reg_prod_año,1,var_fun_GG.GG_caracter_separacion[0]),""},
            /*18*/{ GG_direccion_carpetas_base[0] + "CONFIG\\INF\\REGISTROS\\ACUMULADO_PRODUC_REGISTRO.TXT", columnas_concatenadas(GG_ventana_reg_prod_total,1,var_fun_GG.GG_caracter_separacion[0]),""},
            //impuestos
            /*19*/{ GG_direccion_carpetas_base[0] + "CONFIG\\INF\\IMPUESTOS\\IMPUESTOS.TXT", columnas_concatenadas(GG_ventana_IMPUESTOS,1,var_fun_GG.GG_caracter_separacion[0]),"NOSE|0|SIN DESCRIPCION|INFO_EXTRA_NOSE|3§IVA|16|SIN DESCRIPCION|INFO_EXTRA_NOSE|2"},
            /*20*/{ GG_direccion_carpetas_base[0] + "CONFIG\\INF\\IMPUESTOS\\DEDUSIBLES.TXT", columnas_concatenadas(GG_ventana_DEDUSIBLES,1,var_fun_GG.GG_caracter_separacion[0]),""},
            //herramientas
            /*21*/{ GG_direccion_carpetas_base[0] + "CONFIG\\INF\\INVENTARIO\\COSAS_NO_ESTABAN.TXT", columnas_concatenadas(GG_ventana_COSAS_NO_ESTABAN_INVENTARIO,1,var_fun_GG.GG_caracter_separacion[0]),""},
            /*22*/{ GG_direccion_carpetas_base[0] + "CONFIG\\INF\\INVENTARIO\\TIPOS_DE_MEDIDA.TXT", columnas_concatenadas(GG_ventana_HERRAMIENTAS,1,var_fun_GG.GG_caracter_separacion[0]),"NOSE§ML§GR§KG"},
            /*23*/{ GG_direccion_carpetas_base[0] + "CONFIG\\INF\\DAT\\TRABAJOS_POR_DIA.TXT", columnas_concatenadas(GG_trabajos_dia,1,var_fun_GG.GG_caracter_separacion[0]),"LUN§MAR§MIE§JUE§VIE§SAB§DOM"},

    };

        static public string[,] GG_dir_nom_archivos_SIN_ARREGLOS_GG =
        {
            //archivos transferencia informacion
            /*0*/{ "C:\\XEROX\\CONFIG\\INF\\BKLKFJC\\BANDERAS.TXT", var_fun_GG.GG_id_programa, var_fun_GG.GG_id_programa},//no_hacer_caso
            /*1*/{ "C:\\XEROX\\CONFIG\\INF\\BKLKFJC\\1.TXT", "SIN_INFO", ""},//preguntas
            /*2*/{"C:\\XEROX\\CONFIG\\INF\\BKLKFJC\\2.TXT", "SIN_INFO", ""},//respuestas
            /*3*/{"C:\\XEROX\\CONFIG\\REG\\REG_" + DateTime.Now.ToString("yyyyMMdd"),"" , "" },//reg_modificacion archivos
            /*4*/{"CONFIG\\INF\\RECORDATORIO\\RECORDATORIO.TXT","" , "" },//reg_modificacion archivos

        };

        //direccion_para_hacer_inventarios
        public string[,] GG_direccion_hacer_inventarios =
        {
            { "CONFIG\\INF\\INVENTARIO\\HACER_INVENTARIO\\" + DateTime.Now.ToString("yyyyMMdd") + "_VENTAS_DURANTE_INV.TXT", "CODBAR|nombre_producto|CANTIDA|ULTIMO_MOVIMIENTO" },
            { "CONFIG\\INF\\INVENTARIO\\HACER_INVENTARIO\\" + DateTime.Now.ToString("yyyyMMdd") + "_SOBRANTES.TXT", "CODBAR|nombre_producto|CANTIDA|ULTIMO_MOVIMIENTO" },
            { "CONFIG\\INF\\INVENTARIO\\HACER_INVENTARIO\\" + DateTime.Now.ToString("yyyyMMdd") + "_FALTANTES.TXT", "CODBAR|nombre_producto|CANTIDA|ULTIMO_MOVIMIENTO" },
            { "CONFIG\\INF\\INVENTARIO\\HACER_INVENTARIO\\" + DateTime.Now.ToString("yyyyMMdd") + "_NO_ESTAN_EN_EL_FISICO.TXT", "CODBAR|nombre_producto|CANTIDA|ULTIMO_MOVIMIENTO" },
            { "CONFIG\\INF\\INVENTARIO\\HACER_INVENTARIO\\" + DateTime.Now.ToString("yyyyMMdd") + "_NO_ESTAN_EN_EL_FISICO_PERO_PUEDE_QUE_FALTEN.TXT", "CODBAR|nombre_producto|CANTIDA|ULTIMO_MOVIMIENTO" },

        };

        public static string GG_NUEVA_INFO_DEFAUL(string[,] arreglo_info, string columnas_a_ingresar_info_NO_DEFAUL, string info_NO_DEFAUL, string columnas_que_no_quieres_que_aparescan = "")
        {
            string info_a_retornar = "";



            string[] copia_arreglo = new string[arreglo_info.GetLength(0)];

            for (int i = 0; i < arreglo_info.GetLength(0); i++)
            {
                copia_arreglo[i] = arreglo_info[i, 3];
            }


            operaciones_textos op_tex = new operaciones_textos();
            string[] columnas_a_editar = columnas_a_ingresar_info_NO_DEFAUL.Split(var_fun_GG.GG_caracter_separacion[0][0]);
            string[] info_editar = info_NO_DEFAUL.Split(var_fun_GG.GG_caracter_separacion[0][0]);
            string[] columnas_a_QUITAR = columnas_que_no_quieres_que_aparescan.Split(var_fun_GG.GG_caracter_separacion[0][0]);

            for (int j = 0; j < columnas_a_editar.Length; j++)
            {
                int indice_a_editar = Convert.ToInt32(columnas_a_editar[j]);
                copia_arreglo[indice_a_editar] = info_editar[j];
            }




            if (columnas_que_no_quieres_que_aparescan != "")
            {
                for (int i = 0; i < copia_arreglo.Length; i++)
                {
                    bool agregar = true;
                    for (int j = 0; j < columnas_a_QUITAR.Length; j++)
                    {
                        if ((i + "") == columnas_a_QUITAR[j])
                        {
                            agregar = false;
                            break;
                        }

                    }
                    if (agregar == true)
                    {
                        info_a_retornar = op_tex.concatenacion_caracter_separacion(info_a_retornar, copia_arreglo[i], var_fun_GG.GG_caracter_separacion[0]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < copia_arreglo.Length; i++)
                {
                    info_a_retornar = op_tex.concatenacion_caracter_separacion(info_a_retornar, copia_arreglo[i], var_fun_GG.GG_caracter_separacion[0]);
                }
            }

            return info_a_retornar;
        }
    }
}