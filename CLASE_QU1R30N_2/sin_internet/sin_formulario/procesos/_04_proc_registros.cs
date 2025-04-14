using CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas;
using CLASE_QU1R30N_2.sin_internet.sin_formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLASE_QU1R30N_2.sin_internet.sin_formulario.procesos
{
    internal class _04_proc_registros
    {


        string[] G_direcciones =
        {
            /*0*/var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[0, 0],//"config\\inf\\inventario\\inventario.TXT",
            /*1*/var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[18, 0],//CONFIG\\INF\\IMPUESTOS\\IMPUESTOS.TXT,
            //registro
            /*2*/var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[10, 0],//"CONFIG\\INF\\REGISTROS\\FECHAS\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("yyyyMM") + "\\" + DateTime.Now.ToString("yyyyMMdd") + "_REGISTRO.TXT"
            /*3*/var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[11, 0],//"CONFIG\\INF\\REGISTROS\\FECHAS\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("yyyyMM") + "_REGISTRO.TXT"
            /*4*/var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[12, 0],//"CONFIG\\INF\\REGISTROS\\FECHAS\\" + DateTime.Now.ToString("yyyy") + "_REGISTRO.TXT"
            /*5*/var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[13, 0],//"CONFIG\\INF\\REGISTROS\\ACUMULADO_REGISTRO.TXT"
            //productos
            /*6*/var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[14, 0],//"CONFIG\\INF\\REGISTROS\\FECHAS\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("yyyyMM") + "\\" + DateTime.Now.ToString("yyyyMMdd") + "_PRODUC_REGISTRO.TXT"
            /*7*/var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[15, 0],//"CONFIG\\INF\\REGISTROS\\FECHAS\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("yyyyMM") + "_PRODUC_REGISTRO.TXT"
            /*8*/var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[16, 0],//"CONFIG\\INF\\REGISTROS\\FECHAS\\" + DateTime.Now.ToString("yyyy") + "_PRODUC_REGISTRO.TXT"
            /*9*/var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[17, 0],//"CONFIG\\INF\\REGISTROS\\ACUMULADO_PRODUC_REGISTRO.TXT"

        };

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;
        operaciones_textos op_tex = new operaciones_textos();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        string[] G_solo_para_consultas_relacionadas_encontrar_el_id;

        principal enl_princ = new principal();

        var_fun_GG vf_GG = new var_fun_GG();

        operaciones_arreglos op_arr = new operaciones_arreglos();

        public void modificar_historial_ranking(string datos)
        {
            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            //PARAMETROS---------------------------------------------------------------------------
            string direccion_archivo = "";
            if (datos_epliteados.Length >= 1 && datos_epliteados[0] != "")
            {
                direccion_archivo = datos_epliteados[0];
            }

            string datos_procesados = "";
            if (datos_epliteados.Length >= 2 && datos_epliteados[1] != "")
            {
                datos_procesados = datos_epliteados[1];
            }

            string fecha_o_hora = "";
            if (datos_epliteados.Length >= 3 && datos_epliteados[2] != "")
            {
                fecha_o_hora = datos_epliteados[2];
            }

            object caracter_separacion_obj = null;
            if (datos_epliteados.Length >= 4 && datos_epliteados[3] != "")
            {
                caracter_separacion_obj = datos_epliteados[3];
            }


            //0_NOMBRE_PRODUCTO|1_CANTIDAD|2_COD_BAR|3_COMENTARIO|4_HISTORIAL|5_RANKING|6_PROMEDIO|7_VECES_QUE_SUPERA_PROMEDIO
            string[] caracter_separacion_string = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);

            string[] dat_esp = datos_procesados.Split(G_caracter_separacion[0][0]);
            string[] cuantos_cod_bar = dat_esp[2].Split(G_caracter_separacion[1][0]);

            cuantos_cod_bar = si_hay_iguales_en_codigo_y_plataforma_suma_cantidad_proceso_registros(cuantos_cod_bar);

            for (int l = 0; l < cuantos_cod_bar.Length; l++)
            {
                string[] info_dat = cuantos_cod_bar[l].Split(G_caracter_separacion[2][0]);
                string cod_bar = info_dat[0];


                //string[] res_busq_produc = bas.buscar(direccion_archivo, cod_bar, 2).Split(G_caracter_para_confirmacion_o_error[0][0]);
                string[] res_busq_produc = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "BUSCAR" + G_caracter_separacion_funciones_espesificas[1] + direccion_archivo + G_caracter_separacion_funciones_espesificas[3][0] + cod_bar + G_caracter_separacion_funciones_espesificas[3][0] + "2").Split(G_caracter_para_confirmacion_o_error[0][0]);


                //encontro el producto?
                if (Convert.ToInt32(res_busq_produc[0]) > 0)
                {
                    if (res_busq_produc[0] == "1")
                    {
                        string[] info_produc = res_busq_produc[1].Split(caracter_separacion_string[0][0]);
                        string[] historial = info_produc[4].Split(caracter_separacion_string[1][0]);
                        string[] temp = new string[historial.Length];
                        temp[0] = "0";

                        for (int i = 0; i < historial.Length; i++)
                        {

                            if (i < temp.Length - 1)
                            {
                                temp[i + 1] = historial[i];

                            }

                        }
                        info_produc[4] = string.Join(caracter_separacion_string[1], temp);
                        string info_a_editar = string.Join(caracter_separacion_string[0], info_produc);
                        //string res_edicion = bas.Editar_fila_espesifica(direccion_archivo, Convert.ToInt32(res_busq_produc[2]), info_a_editar);
                        string res_edicion = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "EDITAR_FILA_ESPESIFICA_SIN_ARREGLO_GG_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + direccion_archivo + G_caracter_separacion_funciones_espesificas[3][0] + res_busq_produc[2] + G_caracter_separacion_funciones_espesificas[3][0] + info_a_editar);

                    }
                }

            }





        }


        public string registrar_venta(string datos)
        {

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS---------------------------------------------------------------------------
            string datos_procesados = "";
            if (datos_epliteados.Length >= 1 && datos_epliteados[0] != "")
            {
                datos_procesados = datos_epliteados[0];
            }

            string fecha_o_hora = "";
            if (datos_epliteados.Length >= 2 && datos_epliteados[1] != "")
            {
                fecha_o_hora = datos_epliteados[1];
            }


            string sucursal = "";
            if (datos_epliteados.Length >= 3 && datos_epliteados[2] != "")
            {
                sucursal = datos_epliteados[2];
            }


            object caracter_separacion_obj = null;
            if (datos_epliteados.Length >= 4 && datos_epliteados[3] != "")
            {
                caracter_separacion_obj = datos_epliteados[3];
            }


            string[] caracter_separacion_string = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string info_a_retornar = "";
            //FIN PARAMETROS-------------------------------------------------------------

            var_fun_GG_dir_arch_crear.RecargarTodosLosArreglosYArchivos();



            //string resultado_archivo = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo);
            string resultado_archivo = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "SACAR_INDICE_DEL_ARREGLO_DE_DIRECCION_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_direcciones[2]);







            G_direcciones = new string[]
        {
                /*0*/
                var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[0, 0],//"config\\inf\\inventario\\inventario.TXT",
            /*1*/var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[18, 0],//CONFIG\\INF\\IMPUESTOS\\IMPUESTOS.TXT,
            //registro
            /*2*/var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[10, 0],//"CONFIG\\INF\\REGISTROS\\FECHAS\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("yyyyMM") + "\\" + DateTime.Now.ToString("yyyyMMdd") + "_REGISTRO.TXT"
            /*3*/var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[11, 0],//"CONFIG\\INF\\REGISTROS\\FECHAS\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("yyyyMM") + "_REGISTRO.TXT"
            /*4*/var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[12, 0],//"CONFIG\\INF\\REGISTROS\\FECHAS\\" + DateTime.Now.ToString("yyyy") + "_REGISTRO.TXT"
            /*5*/var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[13, 0],//"CONFIG\\INF\\REGISTROS\\ACUMULADO_REGISTRO.TXT"
            //productos
            /*6*/var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[14, 0],//"CONFIG\\INF\\REGISTROS\\FECHAS\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("yyyyMM") + "\\" + DateTime.Now.ToString("yyyyMMdd") + "_PRODUC_REGISTRO.TXT"
            /*7*/var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[15, 0],//"CONFIG\\INF\\REGISTROS\\FECHAS\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("yyyyMM") + "_PRODUC_REGISTRO.TXT"
            /*8*/var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[16, 0],//"CONFIG\\INF\\REGISTROS\\FECHAS\\" + DateTime.Now.ToString("yyyy") + "_PRODUC_REGISTRO.TXT"
            /*9*/var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[17, 0],//"CONFIG\\INF\\REGISTROS\\ACUMULADO_PRODUC_REGISTRO.TXT"

        };


            string[] res_esp_archivo = resultado_archivo.Split(G_caracter_para_confirmacion_o_error[0][0]);
            //se encontro indice archivo
            if (Convert.ToInt32(res_esp_archivo[0]) > 0)
            {
                int indice = Convert.ToInt32(res_esp_archivo[1]);


                string tipo_de_operacion = "";
                double total_venta = 0;
                double total_compra = 0;

                double total_pagar_imp = 0;


                string[] impuestos_a_registrar = null;




                string[] cuantos_cod_bar = datos_procesados.Split(G_caracter_separacion_funciones_espesificas[4][0]);

                cuantos_cod_bar = si_hay_iguales_en_codigo_y_plataforma_suma_cantidad_proceso_registros(cuantos_cod_bar);

                string Codbar_PreTot_Nom_Cant = "";

                for (int l = 0; l < cuantos_cod_bar.Length; l++)
                {
                    string[] info_dat = cuantos_cod_bar[l].Split(G_caracter_separacion_funciones_espesificas[5][0]);
                    string cod_bar = info_dat[0];
                    double cantidad = Convert.ToDouble(info_dat[1]);
                    double precio_venta = Convert.ToDouble(info_dat[2]);
                    double precio_compra = Convert.ToDouble(info_dat[3]);
                    Int64 id = Convert.ToInt64(info_dat[4]);
                    double tot_venta_producto = -0;
                    double tot_compra_producto = -0;
                    double ganancia = -0;

                    string nombre_produc = "";



                    //string[] res_busq_produc = bas.buscar(, , 5, info_dat[2]).Split(G_caracter_para_confirmacion_o_error[0][0]);                    
                    string[] res_busq_produc = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "SELECCIONAR_ID_INFO_DIVIDIDA_EXTRAE_INFO_ARCHIVO_Y_FILA" + G_caracter_separacion_funciones_espesificas[1] + G_direcciones[0] + G_caracter_separacion_funciones_espesificas[3][0] + id).Split(G_caracter_para_confirmacion_o_error[0][0]);
                    //encontro producto
                    if (Convert.ToInt32(res_busq_produc[0]) > 0)
                    {
                        if (res_busq_produc[0] == "1")
                        {


                            string[] produc_bas_esp = res_busq_produc[1].Split(G_caracter_separacion[0][0]);
                            string[] imp_a_procesar = produc_bas_esp[15].Split(G_caracter_separacion[1][0]);
                            string[] sucursales_del_producto = produc_bas_esp[19].Split(G_caracter_separacion[1][0]);
                            for (int i = 0; i < sucursales_del_producto.Length; i++)
                            {
                                string[] info_sucursales = sucursales_del_producto[i].Split(G_caracter_separacion[2][0]);
                                if (info_sucursales[0] == sucursal)
                                {
                                    precio_venta = Convert.ToDouble(info_sucursales[1]);
                                    break;
                                }
                                else
                                {
                                    precio_venta = Convert.ToDouble(produc_bas_esp[4]);
                                }
                            }


                            nombre_produc = produc_bas_esp[1] + " " + produc_bas_esp[2] + " " + produc_bas_esp[3];




                            precio_compra = Convert.ToDouble(produc_bas_esp[7]);
                            tot_venta_producto = cantidad * precio_venta;
                            tot_compra_producto = cantidad * precio_compra;
                            ganancia = tot_venta_producto - tot_compra_producto;


                            for (int i = 0; i < imp_a_procesar.Length; i++)
                            {
                                //string[] res_busq_imp = bas.buscar(G_direcciones[1], imp_a_procesar[i], 0).Split(G_caracter_para_confirmacion_o_error[0][0]);
                                string[] res_busq_imp = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "BUSCAR_INFO_DIVIDIDA" + G_caracter_separacion_funciones_espesificas[1] + G_direcciones[1] + G_caracter_separacion_funciones_espesificas[3][0] + imp_a_procesar[i] + G_caracter_separacion_funciones_espesificas[3][0] + "1").Split(G_caracter_para_confirmacion_o_error[0][0]);
                                //encontro impuesto
                                if (Convert.ToInt32(res_busq_imp[0]) > 0)
                                {
                                    if (res_busq_imp[0] == "1")
                                    {
                                        string[] inf_imp = res_busq_imp[1].Split(caracter_separacion_string[0][0]);

                                        if (impuestos_a_registrar != null)
                                        {
                                            bool ya_se_proceso_el_imp_previamente = false;
                                            for (int j = 0; j < impuestos_a_registrar.Length; j++)
                                            {
                                                string[] imp_reg_esp = impuestos_a_registrar[j].Split(caracter_separacion_string[2][0]);

                                                if (imp_reg_esp[0] == imp_a_procesar[i])
                                                {
                                                    ya_se_proceso_el_imp_previamente = true;


                                                    double impuesto_en_decimal = (Convert.ToDouble(inf_imp[1]) / 100);

                                                    double impueesto_en_dinero = (impuesto_en_decimal * ganancia);

                                                    imp_reg_esp[1] = "" + (Convert.ToDouble(imp_reg_esp[1]) + impueesto_en_dinero);
                                                    impuestos_a_registrar[j] = string.Join(caracter_separacion_string[2], imp_reg_esp);


                                                    total_pagar_imp = total_pagar_imp + impueesto_en_dinero;

                                                }
                                            }
                                            if (ya_se_proceso_el_imp_previamente == false)
                                            {


                                                double impuesto_en_decimal = (Convert.ToDouble(inf_imp[1]) / 100);

                                                double impueesto_en_dinero = (impuesto_en_decimal * ganancia);

                                                impuestos_a_registrar = op_arr.agregar_registro_del_array(impuestos_a_registrar, inf_imp[0] + caracter_separacion_string[2] + (impuesto_en_decimal * tot_venta_producto));


                                                total_pagar_imp = total_pagar_imp + impueesto_en_dinero;
                                            }

                                        }
                                        else
                                        {


                                            double impuesto_en_decimal = (Convert.ToDouble(inf_imp[2]) / 100);

                                            impuestos_a_registrar = op_arr.agregar_registro_del_array(impuestos_a_registrar, inf_imp[1] + caracter_separacion_string[2] + (impuesto_en_decimal * tot_venta_producto) + caracter_separacion_string[2] + "%" + inf_imp[2]);

                                            double impueesto_en_dinero = (impuesto_en_decimal * ganancia);


                                            total_pagar_imp = total_pagar_imp + impueesto_en_dinero;
                                        }

                                    }
                                }
                            }



                            //registro productos--------------------------------------------------------------

                            string indice_reg_dia = produc_bas_esp[27];
                            string indice_reg_mes = produc_bas_esp[28];
                            string indice_reg_año = produc_bas_esp[29];
                            string ultima_venta_del_producto = produc_bas_esp[30];
                            string indice_reg_total = produc_bas_esp[31];
                            string fecha_de_la_venta_total = "";
                            string fecha_de_la_venta_año = fecha_o_hora[0] + "" + fecha_o_hora[1] + "" + fecha_o_hora[2] + "" + fecha_o_hora[3];
                            string fecha_de_la_venta_mes = fecha_o_hora[4] + "" + fecha_o_hora[5];
                            string fecha_de_la_venta_dia = fecha_o_hora[6] + "" + fecha_o_hora[7];

                            fecha_de_la_venta_total = fecha_de_la_venta_año + fecha_de_la_venta_mes + fecha_de_la_venta_dia;


                            if (Convert.ToInt32(ultima_venta_del_producto) < Convert.ToInt32(fecha_de_la_venta_total))
                            {
                                AgregarRegistro(indice_reg_dia, indice_reg_mes, indice_reg_año, nombre_produc, "" + cantidad, cod_bar, produc_bas_esp[8], ultima_venta_del_producto, fecha_de_la_venta_total, id + "");
                            }

                            //info_a_retornar = op_tex.concatenacion_caracter_separacion(info_a_retornar, enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "INCREMENTA_CELDA_ID_INFO_DIVIDIDA" + G_caracter_separacion_funciones_espesificas[1] + var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[0, 0] + G_caracter_separacion_funciones_espesificas[3] + id[i] + G_caracter_separacion_funciones_espesificas[3] + "6" + G_caracter_separacion_funciones_espesificas[3] + "-" + cantidades_espliteados[i]), G_caracter_para_confirmacion_o_error[1]);

                            incremento_registro_producto(indice_reg_total, indice_reg_mes, indice_reg_dia, indice_reg_año, nombre_produc, "" + cantidad, cod_bar, produc_bas_esp[8], ultima_venta_del_producto, fecha_de_la_venta_total, id + "");


                            //fin_registro_producto-----------------------------------------------------------------------------

                        }

                    }



                    total_venta = total_venta + tot_venta_producto;
                    total_compra = total_compra + tot_compra_producto;


                    Codbar_PreTot_Nom_Cant = op_tex.concatenacion_caracter_separacion(Codbar_PreTot_Nom_Cant, cod_bar + caracter_separacion_string[2] + tot_venta_producto + caracter_separacion_string[2] + nombre_produc + caracter_separacion_string[2] + cantidad, caracter_separacion_string[1]);


                    tipo_de_operacion = op_tex.concatenacion_caracter_separacion(tipo_de_operacion, "VENTA", G_caracter_separacion[1]);
                    //Codbar_PreTot_Nom_Cant_Plat_DatPlat = "";
                    //total_compra = "";
                    //total_pagar_imp = "";



                }




                //registro ventas--------------------------------------------------------------

                string info_agregar =
                    fecha_o_hora
                    + caracter_separacion_string[0]
                    + tipo_de_operacion
                    + caracter_separacion_string[0]
                    + string.Join(caracter_separacion_string[1], impuestos_a_registrar)
                    + caracter_separacion_string[0]
                    + Codbar_PreTot_Nom_Cant
                    + caracter_separacion_string[0]
                    + "SIN_COMENTARIOS"
                    + caracter_separacion_string[0]
                    + total_venta//total_costo_venta
                    + caracter_separacion_string[0]
                    + total_compra//total_costo_compra
                    + caracter_separacion_string[0]
                    + total_pagar_imp
                    + caracter_separacion_string[0]
                    + "0" //total_dedusibles
                    + caracter_separacion_string[0]
                    + (total_venta - (total_compra + total_pagar_imp))//ganancia_total
                    + caracter_separacion_string[0]
                    + sucursal;

                //info_a_retornar = bas.Agregar(direccion_archivo, info_agregar);
                info_a_retornar = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_INFO_DIV" + G_caracter_separacion_funciones_espesificas[1] + G_direcciones[2] + G_caracter_separacion_funciones_espesificas[3][0] + info_agregar);


                string año_mes_dia = "";
                for (int j = 0; j < fecha_o_hora.Length - 4; j++)
                {
                    año_mes_dia = año_mes_dia + fecha_o_hora[j];
                }

                info_agregar =
                    año_mes_dia
                    + caracter_separacion_string[0]
                    + tipo_de_operacion
                    + caracter_separacion_string[0]
                    + "total_imp" + caracter_separacion_string[2] + total_pagar_imp + caracter_separacion_string[1] + string.Join(caracter_separacion_string[1], impuestos_a_registrar)
                    + caracter_separacion_string[0]
                    + "SIN_COMENTARIOS"
                    + caracter_separacion_string[0]
                    + total_venta//total_costo_venta
                    + caracter_separacion_string[0]
                    + total_compra//total_costo_compra
                    + caracter_separacion_string[0]
                    + total_pagar_imp
                    + caracter_separacion_string[0]
                    + "0" //total_dedusibles
                    + caracter_separacion_string[0]
                    + (total_venta - (total_compra + total_pagar_imp))//ganancia_total
                    + caracter_separacion_string[0]
                    + sucursal;

                enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "INCREMENTA_CELDA_BUSQUEDA_INFO_DIVIDIDA" + G_caracter_separacion_funciones_espesificas[1] + G_direcciones[3] + G_caracter_separacion_funciones_espesificas[3] + (año_mes_dia + G_caracter_separacion[0] + tipo_de_operacion) + G_caracter_separacion_funciones_espesificas[3] + ("1" + G_caracter_separacion[0] + "2") + G_caracter_separacion_funciones_espesificas[3] + ("5" + G_caracter_separacion[0] + "6" + G_caracter_separacion[0] + "7" + G_caracter_separacion[0] + "8") + G_caracter_separacion_funciones_espesificas[3] + (total_venta + G_caracter_separacion[0] + total_compra + G_caracter_separacion[0] + total_pagar_imp + G_caracter_separacion[0] + (total_venta - (total_compra + total_pagar_imp))) + G_caracter_separacion_funciones_espesificas[3] + info_agregar);




                string año_mes = "";
                for (int j = 0; j < fecha_o_hora.Length - 6; j++)
                {
                    año_mes = año_mes + fecha_o_hora[j];
                }

                info_agregar = año_mes + caracter_separacion_string[0] + tipo_de_operacion + caracter_separacion_string[0] + "total_imp" + caracter_separacion_string[2] + total_pagar_imp + caracter_separacion_string[1] + string.Join(caracter_separacion_string[1], impuestos_a_registrar) + caracter_separacion_string[0] + "SIN_COMENTARIOS" + caracter_separacion_string[0] + total_venta + caracter_separacion_string[0] + total_compra + caracter_separacion_string[0] + total_pagar_imp + caracter_separacion_string[0] + "0" + caracter_separacion_string[0] + (total_venta - (total_compra + total_pagar_imp)) + caracter_separacion_string[0] + sucursal;

                enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "INCREMENTA_CELDA_BUSQUEDA_INFO_DIVIDIDA" + G_caracter_separacion_funciones_espesificas[1] + G_direcciones[4] + G_caracter_separacion_funciones_espesificas[3] + (año_mes + G_caracter_separacion[0] + tipo_de_operacion) + G_caracter_separacion_funciones_espesificas[3] + ("1" + G_caracter_separacion[0] + "2") + G_caracter_separacion_funciones_espesificas[3] + ("5" + G_caracter_separacion[0] + "6" + G_caracter_separacion[0] + "7" + G_caracter_separacion[0] + "8") + G_caracter_separacion_funciones_espesificas[3] + (total_venta + G_caracter_separacion[0] + total_compra + G_caracter_separacion[0] + total_pagar_imp + G_caracter_separacion[0] + (total_venta - (total_compra + total_pagar_imp))) + G_caracter_separacion_funciones_espesificas[3] + info_agregar);



                string año = "";
                for (int j = 0; j < fecha_o_hora.Length - 8; j++)
                {
                    año = año + fecha_o_hora[j];
                }

                info_agregar = año + caracter_separacion_string[0] + tipo_de_operacion + caracter_separacion_string[0] + "total_imp" + caracter_separacion_string[2] + total_pagar_imp + caracter_separacion_string[1] + string.Join(caracter_separacion_string[1], impuestos_a_registrar) + caracter_separacion_string[0] + "SIN_COMENTARIOS" + caracter_separacion_string[0] + total_venta + caracter_separacion_string[0] + total_compra + caracter_separacion_string[0] + total_pagar_imp + caracter_separacion_string[0] + "0" + caracter_separacion_string[0] + (total_venta - (total_compra + total_pagar_imp)) + caracter_separacion_string[0] + sucursal;

                enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "INCREMENTA_CELDA_BUSQUEDA_INFO_DIVIDIDA" + G_caracter_separacion_funciones_espesificas[1] + G_direcciones[5] + G_caracter_separacion_funciones_espesificas[3] + (año + G_caracter_separacion[0] + tipo_de_operacion) + G_caracter_separacion_funciones_espesificas[3] + ("1" + G_caracter_separacion[0] + "2") + G_caracter_separacion_funciones_espesificas[3] + ("5" + G_caracter_separacion[0] + "6" + G_caracter_separacion[0] + "7" + G_caracter_separacion[0] + "8") + G_caracter_separacion_funciones_espesificas[3] + (total_venta + G_caracter_separacion[0] + total_compra + G_caracter_separacion[0] + total_pagar_imp + G_caracter_separacion[0] + (total_venta - (total_compra + total_pagar_imp))) + G_caracter_separacion_funciones_espesificas[3] + info_agregar);


                //fin registro ventas--------------------------------








            }

            else
            {
                info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se encontro la direccion";
            }

            return info_a_retornar;
        }

        public string registrar_compra(string datos)
        {

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS---------------------------------------------------------------------------
            string direccion_archivo = "";
            if (datos_epliteados.Length >= 1 && datos_epliteados[0] != "")
            {
                direccion_archivo = datos_epliteados[0];
            }

            string datos_procesados = "";
            if (datos_epliteados.Length >= 2 && datos_epliteados[1] != "")
            {
                datos_procesados = datos_epliteados[1];
            }

            string fecha_o_hora = "";
            if (datos_epliteados.Length >= 3 && datos_epliteados[2] != "")
            {
                fecha_o_hora = datos_epliteados[2];
            }

            object caracter_separacion_obj = null;
            if (datos_epliteados.Length >= 4 && datos_epliteados[3] != "")
            {
                caracter_separacion_obj = datos_epliteados[3];
            }


            string[] caracter_separacion_string = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string info_a_retornar = "";



            //string resultado_archivo = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo);
            string resultado_archivo = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "SACAR_INDICE_DEL_ARREGLO_DE_DIRECCION_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + direccion_archivo);
            string[] res_esp_archivo = resultado_archivo.Split(G_caracter_para_confirmacion_o_error[0][0]);
            if (Convert.ToInt32(res_esp_archivo[0]) > 0)
            {
                int indice = Convert.ToInt32(res_esp_archivo[1]);


                string tipo_de_operacion = "";
                double total_compra = 0;

                double total_pagar_imp = 0;


                string[] impuestos_a_registrar = null;



                string[] dat_esp = datos_procesados.Split(G_caracter_separacion[0][0]);
                string[] cuantos_cod_bar = dat_esp[0].Split(G_caracter_separacion[1][0]);

                cuantos_cod_bar = si_hay_iguales_en_codigo_y_plataforma_suma_cantidad_proceso_registros(cuantos_cod_bar);

                string Codbar_PreTot_Nom_Cant_Plat_DatPlat = "";

                for (int l = 0; l < cuantos_cod_bar.Length; l++)
                {
                    string[] info_dat = cuantos_cod_bar[l].Split(G_caracter_separacion[2][0]);
                    string cod_bar = info_dat[0];
                    double cantidad = Convert.ToDouble(info_dat[1]);
                    double precio = Convert.ToDouble(info_dat[2]);
                    double tot_com_producto = cantidad * precio;

                    string nombre_produc = "NO_SE_ENCONTRO_PRODUCTO";

                    //encontro archivo?
                    if (res_esp_archivo[0] == "1")
                    {

                        //string[] res_busq_produc = bas.buscar(G_direcciones[0], info_dat[0], 5, info_dat[3]).Split(G_caracter_para_confirmacion_o_error[0][0]);
                        string[] res_busq_produc = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "BUSCAR" + G_caracter_separacion_funciones_espesificas[1] + G_direcciones[0] + G_caracter_separacion_funciones_espesificas[3][0] + info_dat[0] + G_caracter_separacion_funciones_espesificas[3][0] + "5" + G_caracter_separacion_funciones_espesificas[3][0] + info_dat[3]).Split(G_caracter_para_confirmacion_o_error[0][0]);
                        //encontro producto
                        if (Convert.ToInt32(res_busq_produc[0]) > 0)
                        {
                            if (res_busq_produc[0] == "1")
                            {

                                string[] produc_bas_esp = res_busq_produc[1].Split(G_caracter_separacion[0][0]);
                                string[] imp_a_procesar = produc_bas_esp[15].Split(G_caracter_separacion[1][0]);
                                nombre_produc = produc_bas_esp[1] + " " + produc_bas_esp[2] + " " + produc_bas_esp[3];


                                for (int i = 0; i < imp_a_procesar.Length; i++)
                                {
                                    //string[] res_busq_imp = bas.buscar(G_direcciones[1], imp_a_procesar[i], 0).Split(G_caracter_para_confirmacion_o_error[0][0]);
                                    string[] res_busq_imp = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "BUSCAR" + G_caracter_separacion_funciones_espesificas[1] + G_direcciones[1] + G_caracter_separacion_funciones_espesificas[3][0] + imp_a_procesar[i] + G_caracter_separacion_funciones_espesificas[3][0] + "0").Split(G_caracter_para_confirmacion_o_error[0][0]);
                                    //encontro impuesto
                                    if (Convert.ToInt32(res_busq_imp[0]) > 0)
                                    {
                                        if (res_busq_imp[0] == "1")
                                        {
                                            string[] inf_imp = res_busq_imp[1].Split(caracter_separacion_string[0][0]);

                                            if (impuestos_a_registrar != null)
                                            {
                                                bool ya_se_proceso_el_imp_previamente = false;
                                                for (int j = 0; j < impuestos_a_registrar.Length; j++)
                                                {
                                                    string[] imp_reg_esp = impuestos_a_registrar[j].Split(caracter_separacion_string[2][0]);

                                                    if (imp_reg_esp[0] == imp_a_procesar[i])
                                                    {
                                                        ya_se_proceso_el_imp_previamente = true;


                                                        double impuesto_en_decimal = (Convert.ToDouble(inf_imp[1]) / 100);

                                                        double impueesto_en_dinero = (impuesto_en_decimal * tot_com_producto);

                                                        imp_reg_esp[1] = "" + (Convert.ToDouble(imp_reg_esp[1]) + impueesto_en_dinero);
                                                        impuestos_a_registrar[j] = string.Join(caracter_separacion_string[2], imp_reg_esp);


                                                        total_pagar_imp = total_pagar_imp + impueesto_en_dinero;

                                                    }
                                                }
                                                if (ya_se_proceso_el_imp_previamente == false)
                                                {


                                                    double impuesto_en_decimal = (Convert.ToDouble(inf_imp[1]) / 100);

                                                    double impueesto_en_dinero = (impuesto_en_decimal * tot_com_producto);

                                                    impuestos_a_registrar = op_arr.agregar_registro_del_array(impuestos_a_registrar, inf_imp[0] + caracter_separacion_string[2] + (impuesto_en_decimal * tot_com_producto));


                                                    total_pagar_imp = total_pagar_imp + impueesto_en_dinero;
                                                }

                                            }
                                            else
                                            {


                                                double impuesto_en_decimal = (Convert.ToDouble(inf_imp[1]) / 100);

                                                impuestos_a_registrar = op_arr.agregar_registro_del_array(impuestos_a_registrar, inf_imp[0] + caracter_separacion_string[2] + (impuesto_en_decimal * tot_com_producto));

                                                double impueesto_en_dinero = (impuesto_en_decimal * tot_com_producto);


                                                total_pagar_imp = total_pagar_imp + impueesto_en_dinero;
                                            }

                                        }
                                    }
                                }

                            }

                        }



                        total_compra = total_compra + tot_com_producto;
                        //COD_BAR¬400¬PRODUCTO¬4¬PLATAFORMA1╝4╔4¬VENTAS°COD_BAR1¬100¬PRODUCTO¬1¬PLATAFORMA1╝4¬VENTAS

                        Codbar_PreTot_Nom_Cant_Plat_DatPlat = op_tex.concatenacion_caracter_separacion(Codbar_PreTot_Nom_Cant_Plat_DatPlat, cod_bar + caracter_separacion_string[2] + tot_com_producto + caracter_separacion_string[2] + nombre_produc + caracter_separacion_string[2] + cantidad, caracter_separacion_string[1]);


                        tipo_de_operacion = op_tex.concatenacion_caracter_separacion(tipo_de_operacion, "COMPRA", G_caracter_separacion[1]);
                        //Codbar_PreTot_Nom_Cant_Plat_DatPlat = "";
                        //total_compra = "";
                        //total_pagar_imp = "";

                    }


                }

                string info_agregar =
                    fecha_o_hora
                    + caracter_separacion_string[0]
                    + tipo_de_operacion
                    + caracter_separacion_string[0]
                    + string.Join(caracter_separacion_string[1], impuestos_a_registrar)
                    + caracter_separacion_string[0]
                    + Codbar_PreTot_Nom_Cant_Plat_DatPlat
                    + caracter_separacion_string[0]
                    + "SIN_COMENTARIOS"
                    + caracter_separacion_string[0]
                    + ""//total_costo_venta
                    + caracter_separacion_string[0]
                    + total_compra
                    + caracter_separacion_string[0]
                    + total_pagar_imp
                    + caracter_separacion_string[0]
                    + ""
                    + caracter_separacion_string[0]
                    + ""//ganancia_total
                    + caracter_separacion_string[0]
                    + "";

                //info_a_retornar = bas.Agregar(direccion_archivo, info_agregar);
                info_a_retornar = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_USO_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + direccion_archivo + G_caracter_separacion_funciones_espesificas[4] + info_agregar);

            }

            else
            {
                info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se encontro la direccion";
            }

            return info_a_retornar;
        }

        public string registro_incrementar_venta(string datos)
        {

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS---------------------------------------------------------------------------
            string direccion_archivo = "";
            if (datos_epliteados.Length >= 1 && datos_epliteados[0] != "")
            {
                direccion_archivo = datos_epliteados[0];
            }

            string datos_procesados = "";
            if (datos_epliteados.Length >= 2 && datos_epliteados[1] != "")
            {
                datos_procesados = datos_epliteados[1];
            }

            string fecha = "";
            if (datos_epliteados.Length >= 3 && datos_epliteados[2] != "")
            {
                fecha = datos_epliteados[2];
            }


            string info_a_retornar = "";

            //string resultado_archivo = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo);
            string resultado_archivo = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "SACAR_INDICE_DEL_ARREGLO_DE_DIRECCION_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + direccion_archivo);
            string[] res_esp_archivo = resultado_archivo.Split(G_caracter_para_confirmacion_o_error[0][0]);
            //encontro el archivo
            if (Convert.ToInt32(res_esp_archivo[0]) > 0)
            {
                if (res_esp_archivo[0] == "1")
                {
                    string[] datos_esp = datos_procesados.Split(G_caracter_separacion[0][0]);
                    datos_esp[0] = fecha;
                    string[] datos_tip_operacion = datos_esp[1].Split(G_caracter_separacion[1][0]);
                    string[] datos_iva = datos_esp[2].Split(G_caracter_separacion[1][0]);
                    string[] datos_cod_bar_dinero_nom_produc = datos_esp[3].Split(G_caracter_separacion[1][0]);

                    datos_iva = si_hay_iguales_en_codigo_suma_cantidad_proceso_registros(datos_iva);
                    datos_esp[2] = string.Join(G_caracter_separacion[1], datos_iva);

                    bool fue_creada_la_informacion = false;
                    for (int j = 0; j < datos_cod_bar_dinero_nom_produc.Length; j++)
                    {
                        string[] inf_dat = datos_cod_bar_dinero_nom_produc[j].Split(G_caracter_separacion[2][0]);
                        string info_dat_prod = inf_dat[0]
                            + G_caracter_separacion[2] + inf_dat[1]
                            + G_caracter_separacion[2] + inf_dat[2]
                            + G_caracter_separacion[2] + inf_dat[3];

                        string sino_lo_encuentra = datos_esp[0] //0_fecha
                            + G_caracter_separacion[0] + datos_tip_operacion[j] //1_OPERACION_1_VENTA_2_COMPRA_3_RETIRAR_DINERO_4_INTODUCIR
                            + G_caracter_separacion[0] + datos_esp[2] //2_IMPUESTO_1¬CANTIDAD_A_PAGAR_IMPUESTO_1¬PORCENTAGE_DE_IMPUESTO_1°IMPUESTO_2¬CANTIDAD_A_PAGAR_IMPUESTO_2¬PORCENTAGE_DE_IMPUESTO_2
                            + G_caracter_separacion[0] + info_dat_prod //3_PRODUCTOS_PRECIO_TOTAL_PRECIO_UNITARIO
                            + G_caracter_separacion[0] + "SIN_COMENTARIOS" //4_COMENTARIO
                            + G_caracter_separacion[0] + datos_esp[5] //5_TOTAL_VENTA
                            + G_caracter_separacion[0] + datos_esp[6] //6_TOTAL_COSTO_COMP
                            + G_caracter_separacion[0] + datos_esp[7]// 7_TOTAL_IMPUESTOS
                            + G_caracter_separacion[0] + datos_esp[8] //8_TOTAL_DEDUSIBLES_SOLO_SE_USA_EN_COMPRAS_Y_DONACIONES_SENECECITA_LA_FACTURA
                            + G_caracter_separacion[0] + datos_esp[9];//9_TOTAL_GANANCIA_DESPUES_DE_IMPUESTOS

                        /*
                        string res = bas.Editar_incr_o_agrega_COMPARACION_YY_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID
                                    (direccion_archivo,
                                    //columnas a comparar
                                    "0" + G_caracter_separacion_funciones_espesificas[0] + "1"
                                    ,//comparar
                                    fecha + G_caracter_separacion_funciones_espesificas[0] + datos_tip_operacion[j]//tipo_operacion
                                    ,//columnas a editar
                                      "3"//3_productos
                                    , //edicion
                                      info_dat_prod//3_productos
                                    ,// 0:editar  1:incrementar 2:agregar
                                      "1"                                                  //3_productos
                                    , sino_lo_encuentra
                                    );
                        */

                        string res = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "EDITAR_INCR_O_AGREGA_COMPARACION_YY_INFO_DENTRO_DE_CELDA_Y_AGREGA_FILA_SI_NO_ESTA_Y_NO_ES_VACIA_LA_VARIABLE_ES_MULTIPLE_CON_COMPARACION_FINAL_BUSQUEDA_ID" + G_caracter_separacion_funciones_espesificas[1] +
                                    direccion_archivo +
                                    G_caracter_separacion_funciones_espesificas[3] +
                                    "0" + G_caracter_separacion_funciones_espesificas[0] + "1" +
                                    G_caracter_separacion_funciones_espesificas[3] +
                                    fecha + G_caracter_separacion_funciones_espesificas[0] + datos_tip_operacion[j] +
                                    G_caracter_separacion_funciones_espesificas[3] +
                                    "3" +
                                    G_caracter_separacion_funciones_espesificas[3] +
                                    info_dat_prod +
                                    G_caracter_separacion_funciones_espesificas[3] +
                                    "1" +
                                    G_caracter_separacion_funciones_espesificas[3] +
                                    sino_lo_encuentra
                                    );


                        string[] res_esp = res.Split(G_caracter_para_confirmacion_o_error[0][0]);
                        if (res_esp[0] == "2")
                        {
                            fue_creada_la_informacion = true;

                        }

                    }

                    //ESTE ES IMPORTANTE ESTE ES EL QUE HACE LOS PROCESOS CON LA INFORMACION
                    if (fue_creada_la_informacion == false)
                    {

                        rep_funcion_cantidad_del_arreglo(direccion_archivo, "0", fecha, "2", datos_iva, "1", "VENTA");
                        rep_funcion_cantidad_del_arreglo(direccion_archivo, "0", fecha, "5", datos_esp[5], "1", "VENTA");
                        rep_funcion_cantidad_del_arreglo(direccion_archivo, "0", fecha, "6", datos_esp[6], "1", "VENTA");
                        rep_funcion_cantidad_del_arreglo(direccion_archivo, "0", fecha, "7", datos_esp[7], "1", "VENTA");
                        rep_funcion_cantidad_del_arreglo(direccion_archivo, "0", fecha, "9", datos_esp[9], "1", "VENTA");

                    }


                }
            }
            else
            {
                if (res_esp_archivo[0] == "0")
                {

                }
            }


            return info_a_retornar;
        }

        public string registro_incrementar_compra(string datos)
        {
            string info_a_retornar = "";

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS---------------------------------------------------------------------------
            string direccion_archivo = "";
            if (datos_epliteados.Length >= 1 && datos_epliteados[0] != "")
            {
                direccion_archivo = datos_epliteados[0];
            }

            string datos_procesados = "";
            if (datos_epliteados.Length >= 2 && datos_epliteados[1] != "")
            {
                datos_procesados = datos_epliteados[1];
            }

            string fecha = "";
            if (datos_epliteados.Length >= 3 && datos_epliteados[2] != "")
            {
                fecha = datos_epliteados[2];
            }


            //string resultado_archivo = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo);
            string resultado_archivo = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "SACAR_INDICE_DEL_ARREGLO_DE_DIRECCION_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + direccion_archivo);


            string[] res_esp_archivo = resultado_archivo.Split(G_caracter_para_confirmacion_o_error[0][0]);
            //encontro el archivo
            if (Convert.ToInt32(res_esp_archivo[0]) > 0)
            {
                if (res_esp_archivo[0] == "1")
                {
                    string[] datos_esp = datos_procesados.Split(G_caracter_separacion[0][0]);
                    datos_esp[0] = fecha;
                    string[] datos_tip_operacion = datos_esp[1].Split(G_caracter_separacion[1][0]);
                    string[] datos_iva = datos_esp[2].Split(G_caracter_separacion[1][0]);
                    string[] datos_cod_bar_dinero_nom_produc = datos_esp[3].Split(G_caracter_separacion[1][0]);

                    datos_iva = si_hay_iguales_en_codigo_suma_cantidad_proceso_registros(datos_iva);
                    datos_esp[2] = string.Join(G_caracter_separacion[1], datos_iva);

                    bool fue_creada_la_informacion = false;
                    for (int j = 0; j < datos_cod_bar_dinero_nom_produc.Length; j++)
                    {
                        string[] inf_dat = datos_cod_bar_dinero_nom_produc[j].Split(G_caracter_separacion[2][0]);
                        string info_dat_prod = inf_dat[0]
                            + G_caracter_separacion[2] + inf_dat[1]
                            + G_caracter_separacion[2] + inf_dat[2]
                            + G_caracter_separacion[2] + inf_dat[3];

                        string sino_lo_encuentra = datos_esp[0] //0_fecha
                            + G_caracter_separacion[0] + datos_tip_operacion[j] //1_OPERACION_1_VENTA_2_COMPRA_3_RETIRAR_DINERO_4_INTODUCIR
                            + G_caracter_separacion[0] + datos_esp[2] //2_IMPUESTO_1¬CANTIDAD_A_PAGAR_IMPUESTO_1¬PORCENTAGE_DE_IMPUESTO_1°IMPUESTO_2¬CANTIDAD_A_PAGAR_IMPUESTO_2¬PORCENTAGE_DE_IMPUESTO_2
                            + G_caracter_separacion[0] + info_dat_prod //3_PRODUCTOS_PRECIO_TOTAL_PRECIO_UNITARIO
                            + G_caracter_separacion[0] + "SIN_COMENTARIOS" //4_COMENTARIO
                            + G_caracter_separacion[0] + datos_esp[5] //5_TOTAL_VENTA
                            + G_caracter_separacion[0] + datos_esp[6] //6_TOTAL_COSTO_COMP
                            + G_caracter_separacion[0] + datos_esp[7]// 7_TOTAL_IMPUESTOS
                            + G_caracter_separacion[0] + datos_esp[8] //8_TOTAL_DEDUSIBLES_SOLO_SE_USA_EN_COMPRAS_Y_DONACIONES_SENECECITA_LA_FACTURA
                            + G_caracter_separacion[0] + datos_esp[9];//9_TOTAL_GANANCIA_DESPUES_DE_IMPUESTOS

                        /*                 
                        string res = bas.Editar_incr_o_agrega_COMPARACION_YY_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID
                                    (//columnas a comparar
                                    direccion_archivo,
                                    //fecha y tipo_operacion
                                    "0" + G_caracter_separacion_funciones_espesificas[0] + "1"
                                    ,//comparar
                                    fecha + G_caracter_separacion_funciones_espesificas[0] + datos_tip_operacion[j]//tipo_operacion
                                    ,//columnas a editar
                                      "3"//3_productos
                                    ,//edicion
                                      info_dat_prod//3_productos
                                    ,// 0:editar  1:incrementar 2:agregar
                                      "1"                                                  //3_productos
                                    , sino_lo_encuentra
                                    );
                        */

                        string res = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "EDITAR_INCR_O_AGREGA_COMPARACION_YY_INFO_DENTRO_DE_CELDA_Y_AGREGA_FILA_SI_NO_ESTA_Y_NO_ES_VACIA_LA_VARIABLE_ES_MULTIPLE_CON_COMPARACION_FINAL_BUSQUEDA_ID" + G_caracter_separacion_funciones_espesificas[1] +
                                    direccion_archivo +
                                    G_caracter_separacion_funciones_espesificas[3] +
                                    "0" + G_caracter_separacion_funciones_espesificas[0] + "1" +
                                    G_caracter_separacion_funciones_espesificas[3] +
                                    fecha + G_caracter_separacion_funciones_espesificas[0] + datos_tip_operacion[j] +
                                    G_caracter_separacion_funciones_espesificas[3] +
                                    "3" +
                                    G_caracter_separacion_funciones_espesificas[3] +
                                    info_dat_prod +
                                    G_caracter_separacion_funciones_espesificas[3] +
                                    "1" +
                                    G_caracter_separacion_funciones_espesificas[3] +
                                    sino_lo_encuentra
                                    );


                        string[] res_esp = res.Split(G_caracter_para_confirmacion_o_error[0][0]);
                        if (res_esp[0] == "2") { fue_creada_la_informacion = true; }

                    }
                    //ESTE ES IMPORTANTE ESTE ES EL QUE HACE LOS PROCESOS CON LA INFORMACION
                    if (fue_creada_la_informacion == false)
                    {
                        rep_funcion_cantidad_del_arreglo(direccion_archivo, "0", fecha, "2", datos_iva, "1", "COMPRA");
                        rep_funcion_cantidad_del_arreglo(direccion_archivo, "0", fecha, "6", datos_esp[6], "1", "COMPRA");//total_COMPRA
                        rep_funcion_cantidad_del_arreglo(direccion_archivo, "0", fecha, "7", datos_esp[7], "1", "COMPRA");//total_IMPUESTOS

                    }


                }
            }
            else
            {
                if (res_esp_archivo[0] == "0")
                {

                }
            }


            return info_a_retornar;
        }



        public string registrar_movimiento_productos(string datos)
        {

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS---------------------------------------------------------------------------
            string direccion_archivo = "";
            if (datos_epliteados.Length >= 1 && datos_epliteados[0] != "")
            {
                direccion_archivo = datos_epliteados[0];
            }

            string modelo = "";
            if (datos_epliteados.Length >= 2 && datos_epliteados[1] != "")
            {
                modelo = datos_epliteados[1];
            }

            string proceso = "";
            if (datos_epliteados.Length >= 3 && datos_epliteados[2] != "")
            {
                proceso = datos_epliteados[2];
            }

            string datos_procesados = "";
            if (datos_epliteados.Length >= 4 && datos_epliteados[3] != "")
            {
                datos_procesados = datos_epliteados[3];
            }

            string fecha_o_hora = "";
            if (datos_epliteados.Length >= 5 && datos_epliteados[4] != "")
            {
                fecha_o_hora = datos_epliteados[4];
            }

            object caracter_separacion_obj = null;
            if (datos_epliteados.Length >= 6 && datos_epliteados[5] != "")
            {
                caracter_separacion_obj = datos_epliteados[5];
            }


            string[] caracter_separacion_string = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string info_a_retornar = "";



            //string resultado_archivo = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo);
            string resultado_archivo = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "SACAR_INDICE_DEL_ARREGLO_DE_DIRECCION_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + direccion_archivo);
            string[] res_esp_archivo = resultado_archivo.Split(G_caracter_para_confirmacion_o_error[0][0]);
            //encontro archivo?
            if (Convert.ToInt32(res_esp_archivo[0]) > 0)
            {
                int indice = Convert.ToInt32(res_esp_archivo[1]);






                string[] temp = datos_procesados.Split(G_caracter_separacion[0][0]);
                string[] cant_dat = temp[0].Split(G_caracter_separacion[1][0]);

                cant_dat = si_hay_iguales_en_codigo_suma_cantidad_proceso_registros(cant_dat);

                string info_agregar = "";
                cant_dat = extraer_datos_producto_reg(cant_dat);
                if (temp.Length > 1)
                {

                    info_agregar =
                        fecha_o_hora
                        + caracter_separacion_string[0]
                        + proceso
                        + caracter_separacion_string[0]
                        + string.Join(G_caracter_separacion[1], cant_dat)
                        + caracter_separacion_string[0]
                        + temp[1]
                        + caracter_separacion_string[0]
                        + temp[2];
                }
                else
                {

                    info_agregar =
                        fecha_o_hora
                        + caracter_separacion_string[0]
                        + proceso
                        + caracter_separacion_string[0]
                        + string.Join(G_caracter_separacion[1], cant_dat);

                }






                //info_a_retornar = bas.Agregar(direccion_archivo, info_agregar);
                string resp_del_agregue = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_USO_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + direccion_archivo + G_caracter_separacion_funciones_espesificas[4] + info_agregar);

            }

            else
            {
                info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se encontro la direccion";
            }

            return info_a_retornar;
        }
        public string registro_incrementar_productos(string datos)
        {
            string info_a_retornar = "";

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS---------------------------------------------------------------------------
            string direccion_archivo = "";
            if (datos_epliteados.Length >= 1 && datos_epliteados[0] != "")
            {
                direccion_archivo = datos_epliteados[0];
            }

            string datos_procesados = "";
            if (datos_epliteados.Length >= 2 && datos_epliteados[1] != "")
            {
                datos_procesados = datos_epliteados[1];
            }

            string fecha = "";
            if (datos_epliteados.Length >= 3 && datos_epliteados[2] != "")
            {
                fecha = datos_epliteados[2];
            }


            //string resultado_archivo = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo);
            string resultado_archivo = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "SACAR_INDICE_DEL_ARREGLO_DE_DIRECCION_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + direccion_archivo);
            string[] res_esp_archivo = resultado_archivo.Split(G_caracter_para_confirmacion_o_error[0][0]);
            //encontro el archivo
            if (Convert.ToInt32(res_esp_archivo[0]) > 0)
            {
                if (res_esp_archivo[0] == "1")
                {



                    string[] datos_esp = datos_procesados.Split(G_caracter_separacion[0][0]);
                    datos_esp[0] = fecha;
                    string[] datos_tip_operacion = datos_esp[1].Split(G_caracter_separacion[1][0]);
                    string[] datos_codbar = datos_esp[2].Split(G_caracter_separacion[1][0]);

                    string provedores = "SIN_PROVEDOR";
                    string provedores_sin_cantidad = "";






                    if (datos_esp[1] == "VENTA")
                    {

                        datos_codbar = si_hay_iguales_en_codigo_suma_cantidad_proceso_registros(datos_codbar);
                    }
                    else if (datos_esp[1] == "COMPRA")
                    {
                        provedores = datos_esp[3] + G_caracter_separacion[2] + "0";
                        provedores_sin_cantidad = datos_esp[3];
                        datos_codbar = junta_y_pone_a_cero_la_cantidad(datos_codbar);

                    }
                    else
                    {
                        datos_codbar = si_hay_iguales_en_codigo_suma_cantidad_proceso_registros(datos_codbar);
                    }
                    datos_esp[2] = string.Join(G_caracter_separacion[1], datos_codbar);




                    //bool fue_creada_la_informacion = false;
                    for (int j = 0; j < datos_codbar.Length; j++)
                    {
                        string[] inf_dat = datos_codbar[j].Split(G_caracter_separacion[2][0]);


                        string si_no_tiene_historial_ranking_semanas = "";


                        string nombre = "";
                        if (datos_esp[1] == "VENTA")
                        {
                            nombre = inf_dat[5];
                            provedores = inf_dat[4].Replace(G_caracter_separacion[4], G_caracter_separacion[2]);
                            provedores = provedores.Replace(G_caracter_separacion[3], G_caracter_separacion[1]);
                        }
                        if (datos_esp[1] == "COMPRA")
                        {
                            nombre = inf_dat[6];
                        }
                        for (int i = 0; i < 52; i++)
                        {
                            si_no_tiene_historial_ranking_semanas = si_no_tiene_historial_ranking_semanas + G_caracter_separacion[1];
                        }
                        string sino_lo_encuentra =
                            nombre
                            + G_caracter_separacion[0] + inf_dat[1] //1_CANTIDAD
                            + G_caracter_separacion[0] + inf_dat[0] //2_CODIGO
                            + G_caracter_separacion[0] + provedores //3_PROVEDORES
                            + G_caracter_separacion[0] + inf_dat[1] + si_no_tiene_historial_ranking_semanas //4_HISTORIAL
                            + G_caracter_separacion[0] + inf_dat[1] //5_columna_ranking
                            + G_caracter_separacion[0] + inf_dat[1] //6_columnas_promedio
                            + G_caracter_separacion[0] + "4" //7_columna_veces_que_supera_promedio//ponemos 7 para que sean 2 meses porque son 4 semanas por mes
                            + G_caracter_separacion[0] + "0" //8_columna_uso_multiple
                            + G_caracter_separacion[0] + "0" //9_columna_usomulti_tipo_de_producto
                            + G_caracter_separacion[0] + "0" //10_columna_multi_costo_compra
                            + G_caracter_separacion[0] + "0" //11_nivel_nesesidad
                            ;
                        ;

                        //columna_historial,columna_ranking,columnas_promedio,columna_veces_que_supera_promedio,
                        //|//0_NOMBRE_PRODUCTO|1_CANTIDAD|2_COD_BAR|3_COMENTARIO



                        /*
                         
                        bas.Editar_incr_o_agrega_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID
                                    (
                                    direccion_archivo
                                    , 2                                                   //2_codbar
                                    , inf_dat[0]
                                    , "1" + G_caracter_separacion_funciones_espesificas[0] + "4" + G_caracter_separacion[0] + "0" + G_caracter_separacion_funciones_espesificas[0] + "5"
                                    , inf_dat[1] + G_caracter_separacion_funciones_espesificas[0] + inf_dat[1] + G_caracter_separacion_funciones_espesificas[0] + inf_dat[1] + G_caracter_separacion_funciones_espesificas[0] + provedores
                                    , "" + G_caracter_separacion_funciones_espesificas[0] + "" + G_caracter_separacion_funciones_espesificas[0] + "" + G_caracter_separacion_funciones_espesificas[0] + provedores
                                    , "1" + G_caracter_separacion_funciones_espesificas[0] + "1" + G_caracter_separacion_funciones_espesificas[0] + "1" + G_caracter_separacion_funciones_espesificas[0] + "2"
                                    , sino_lo_encuentra
                                    );
                        */

                        string res = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "EDITAR_INCR_O_AGREGA_INFO_DENTRO_DE_CELDA_Y_AGREGA_FILA_SI_NO_ESTA_Y_NO_ES_VACIA_LA_VARIABLE_ES_MULTIPLE_CON_COMPARACION_FINAL_BUSQUEDA_ID" + G_caracter_separacion_funciones_espesificas[1] +
                            direccion_archivo + G_caracter_separacion_funciones_espesificas[3] +
                            "2" + G_caracter_separacion_funciones_espesificas[0] +
                            inf_dat[0] + G_caracter_separacion_funciones_espesificas[3] +
                            "1" + G_caracter_separacion_funciones_espesificas[0] + "4" + G_caracter_separacion[0] + "0" + G_caracter_separacion_funciones_espesificas[0] + "5" + G_caracter_separacion_funciones_espesificas[3] +
                            inf_dat[1] + G_caracter_separacion_funciones_espesificas[0] + inf_dat[1] + G_caracter_separacion_funciones_espesificas[0] + inf_dat[1] + G_caracter_separacion_funciones_espesificas[0] + provedores + G_caracter_separacion_funciones_espesificas[3] +
                            "" + G_caracter_separacion_funciones_espesificas[0] + "" + G_caracter_separacion_funciones_espesificas[0] + "" + G_caracter_separacion_funciones_espesificas[0] + provedores + G_caracter_separacion_funciones_espesificas[3] +
                            "1" + G_caracter_separacion_funciones_espesificas[0] + "1" + G_caracter_separacion_funciones_espesificas[0] + "1" + G_caracter_separacion_funciones_espesificas[0] + "2" + G_caracter_separacion_funciones_espesificas[3] +
                            sino_lo_encuentra
                            );



                        if (datos_esp[1] == "COMPRA")
                        {
                            /*  
                          bas.Editar_incr_o_agrega_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID
                                  (
                                  direccion_archivo
                                  , 2                                                   //2_codbar
                                  , inf_dat[0]
                                  , "3"
                                  , inf_dat[2]
                                  , provedores_sin_cantidad
                                  , "0"

                                  );

                          */
                            string res_2 = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "EDITAR_INCR_O_AGREGA_INFO_DENTRO_DE_CELDA_Y_AGREGA_FILA_SI_NO_ESTA_Y_NO_ES_VACIA_LA_VARIABLE_ES_MULTIPLE_CON_COMPARACION_FINAL_BUSQUEDA_ID" + G_caracter_separacion_funciones_espesificas[1] +
                                direccion_archivo + G_caracter_separacion_funciones_espesificas[3] +
                                "2" + G_caracter_separacion_funciones_espesificas[0] +
                                inf_dat[0] + G_caracter_separacion_funciones_espesificas[3] +
                                "3" + G_caracter_separacion_funciones_espesificas[3] +
                                inf_dat[2] + G_caracter_separacion_funciones_espesificas[3] +
                                provedores_sin_cantidad + G_caracter_separacion_funciones_espesificas[3] +
                                "0"
                                );



                        }



                    }




                }
            }
            else
            {
                if (res_esp_archivo[0] == "0")
                {

                }
            }


            return info_a_retornar;
        }



        private string[] si_hay_iguales_en_codigo_y_plataforma_suma_cantidad_proceso_registros(string[] produc_cantidad)
        {
            string[] arr_retornar = null;
            if (produc_cantidad.Length > 1)
            {
                for (int i = 0; i < produc_cantidad.Length; i++)
                {

                    if (produc_cantidad[i] != "")
                    {
                        string[] comp_prod_1 = produc_cantidad[i].Split(G_caracter_separacion[2][0]);
                        bool hubo_otro_codigo_igual = false;
                        int posicion_si_se_sumo = 0;
                        for (int j = i + 1; j < produc_cantidad.Length; j++)
                        {
                            if (produc_cantidad[j] != "")
                            {
                                string[] comp_prod_2 = produc_cantidad[j].Split(G_caracter_separacion[2][0]);

                                if (comp_prod_1[0] == comp_prod_2[0])
                                {


                                    comp_prod_1[1] = (Convert.ToDouble(comp_prod_1[1]) + Convert.ToDouble(comp_prod_2[1])).ToString();
                                    if (posicion_si_se_sumo != i)
                                    {
                                        arr_retornar = op_arr.agregar_registro_del_array(arr_retornar, string.Join(G_caracter_separacion[2], comp_prod_1));
                                    }
                                    else
                                    {
                                        arr_retornar = op_arr.agregar_registro_del_array(arr_retornar, string.Join(G_caracter_separacion[2], comp_prod_1));
                                    }

                                    produc_cantidad[j] = "";
                                    posicion_si_se_sumo = i;
                                    hubo_otro_codigo_igual = true;

                                }
                            }

                        }


                        if (hubo_otro_codigo_igual == false)
                        {
                            arr_retornar = op_arr.agregar_registro_del_array(arr_retornar, string.Join(G_caracter_separacion[2], comp_prod_1));
                        }
                    }
                }

            }
            else
            {
                arr_retornar = produc_cantidad;
            }

            return arr_retornar;
        }


        private string[] si_hay_iguales_en_codigo_suma_cantidad_proceso_registros(string[] produc_cantidad)
        {
            string[] arr_retornar = new string[0];
            //hay mas de uno para comparar?
            if (produc_cantidad.Length > 1)
            {
                for (int i = 0; i < produc_cantidad.Length; i++)
                {
                    if (produc_cantidad[i] != "")
                    {
                        string[] comp_prod_1 = produc_cantidad[i].Split(G_caracter_separacion[2][0]);
                        for (int j = i + 1; j < produc_cantidad.Length; j++)
                        {
                            if (produc_cantidad[j] != "")
                            {
                                string[] comp_prod_2 = produc_cantidad[j].Split(G_caracter_separacion[2][0]);

                                if (comp_prod_1[0] == comp_prod_2[0])
                                {
                                    comp_prod_1[1] = (Convert.ToDouble(comp_prod_1[1]) + Convert.ToDouble(comp_prod_2[1])).ToString();
                                    produc_cantidad[j] = "";
                                }
                            }
                        }

                        arr_retornar = op_arr.agregar_registro_del_array(arr_retornar, string.Join(G_caracter_separacion[2], comp_prod_1));
                    }
                }
            }
            else
            {
                arr_retornar = produc_cantidad;
            }

            return arr_retornar;
        }


        private string[] extraer_datos_producto_reg(string[] productos)
        {
            string[] arr_retornar = new string[0];
            //hay mas de uno para comparar?
            if (productos.Length > 0)
            {
                for (int i = 0; i < productos.Length; i++)
                {
                    if (productos[i] != "")
                    {
                        string[] comp_prod_1 = productos[i].Split(G_caracter_separacion[2][0]);
                        //string[] res_busq_produc = bas.buscar(G_direcciones[0], comp_prod_1[0], 5).Split(G_caracter_para_confirmacion_o_error[0][0]);
                        string[] res_busq_produc = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "BUSCAR" + G_caracter_separacion_funciones_espesificas[1] + G_direcciones[0] + G_caracter_separacion_funciones_espesificas[3][0] + comp_prod_1[0] + G_caracter_separacion_funciones_espesificas[3][0] + "5").Split(G_caracter_para_confirmacion_o_error[0][0]);

                        if (res_busq_produc[0] == "1")
                        {


                            string[] info_produc = res_busq_produc[1].Split(G_caracter_separacion[0][0]);
                            //op_arr.agregar_registro_del_array()

                            string provedores = info_produc[8].Replace(G_caracter_separacion[2], G_caracter_separacion[4]);
                            provedores = provedores.Replace(G_caracter_separacion[1], G_caracter_separacion[3]);


                            comp_prod_1 = op_arr.agregar_registro_del_array(comp_prod_1, provedores);

                            comp_prod_1 = op_arr.agregar_registro_del_array(comp_prod_1, info_produc[1] + " " + info_produc[2] + " " + info_produc[3]);

                            arr_retornar = op_arr.agregar_registro_del_array(arr_retornar, string.Join(G_caracter_separacion[2], comp_prod_1));
                        }
                        else
                        {
                            comp_prod_1 = op_arr.agregar_registro_del_array(comp_prod_1, "SIN_PROVEDOR");
                            comp_prod_1 = op_arr.agregar_registro_del_array(comp_prod_1, "NOM_PRODUCTO_SI_NO_ESTA");
                            arr_retornar = op_arr.agregar_registro_del_array(arr_retornar, string.Join(G_caracter_separacion[2], comp_prod_1));
                        }
                    }
                }
            }
            else
            {
                arr_retornar = productos;
            }

            return arr_retornar;
        }


        private string[] junta_y_pone_a_cero_la_cantidad(string[] produc_cantidad)
        {
            string[] arr_retornar = new string[0];
            //hay mas de uno para comparar?
            if (produc_cantidad.Length > 1)
            {
                for (int i = 0; i < produc_cantidad.Length; i++)
                {
                    if (produc_cantidad[i] != "")
                    {
                        string[] comp_prod_1 = produc_cantidad[i].Split(G_caracter_separacion[2][0]);
                        comp_prod_1[1] = "0";

                        arr_retornar = op_arr.agregar_registro_del_array(arr_retornar, string.Join(G_caracter_separacion[2], comp_prod_1));
                    }
                }

            }
            else
            {
                arr_retornar = produc_cantidad;
            }

            return arr_retornar;
        }




        private void rep_funcion_cantidad_del_arreglo
            (string direccion_archivo
            , string num_columnas_comparar
            , string comparar
            , string col_editar
            , object arreglo_o_string_de_comparar_y_editar
            , string _0_editar_1_incrementar_2_agregar
            , string tipo_operacion
            )
        {

            string[] arr_comparar_editar = null;
            if (arreglo_o_string_de_comparar_y_editar is string[])
            {
                arr_comparar_editar = (string[])arreglo_o_string_de_comparar_y_editar;
            }
            else
            {
                arr_comparar_editar = arreglo_o_string_de_comparar_y_editar.ToString().Split(G_caracter_separacion[1][0]);
            }

            for (int j = 0; j < arr_comparar_editar.Length; j++)
            {
                string dat_epsliteado = "";

                string[] inf_dat = dat_epsliteado.Split(G_caracter_separacion[2][0]);
                /*
                string res = bas.Editar_incr_o_agrega_COMPARACION_YY_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID
                    (
                    direccion_archivo,
                    num_columnas_comparar
                    + G_caracter_separacion_funciones_espesificas[0]
                                    + "1"//1_tipo_operacion
                                         ,
                    comparar
                    + G_caracter_separacion_funciones_espesificas[0]
                                    + tipo_operacion//tipo_operacion
                    ,

                    col_editar,

                    arr_comparar_editar[j],

                    _0_editar_1_incrementar_2_agregar
                    );
                */
                string res = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "EDITAR_INCR_O_AGREGA_COMPARACION_YY_INFO_DENTRO_DE_CELDA_Y_AGREGA_FILA_SI_NO_ESTA_Y_NO_ES_VACIA_LA_VARIABLE_ES_MULTIPLE_CON_COMPARACION_FINAL_BUSQUEDA_ID" + G_caracter_separacion_funciones_espesificas[1] +
                direccion_archivo + G_caracter_separacion_funciones_espesificas[3] +
                    num_columnas_comparar
                    + G_caracter_separacion_funciones_espesificas[0]
                                    + "1"//1_tipo_operacion
                                          + G_caracter_separacion_funciones_espesificas[3] +
                    comparar
                    + G_caracter_separacion_funciones_espesificas[0]
                                    + tipo_operacion//tipo_operacion
                     + G_caracter_separacion_funciones_espesificas[3] +

                    col_editar + G_caracter_separacion_funciones_espesificas[3] +

                    arr_comparar_editar[j] + G_caracter_separacion_funciones_espesificas[3] +

                    _0_editar_1_incrementar_2_agregar
                    );


                //0_DIA
                //|1_OPERACION_1_VENTA_2_COMPRA_3_RETIRAR_DINERO_4_INTODUCIR
                //|2_IMPUESTO_1¬CANTIDAD_A_PAGAR_IMPUESTO_1¬PORCENTAGE_DE_IMPUESTO_1°IMPUESTO_2¬CANTIDAD_A_PAGAR_IMPUESTO_2¬PORCENTAGE_DE_IMPUESTO_2
                //|3_PRODUCTOS_PRECIOTOTAL_CANTIDAD
                //|4_COMENTARIO
                //|5_TOTAL_VENTA
                //|6_TOTAL_COSTO_COMP
                //|7_TOTAL_IMPUESTOS
                //|8_TOTAL_DEDUSIBLES_SOLO_SE_USA_EN_COMPRAS_Y_DONACIONES_SENECECITA_LA_FACTURA
                //|9_TOTAL_GANANCIA_DESPUES_DE_IMPUESTOS

            }
        }


        private string AgregarRegistro(string id_año, string id_mes, string id_dia, string nombre_produc, string cantidad, string cod_bar, string provedor, string ultima_venta_del_producto, string fecha_de_la_venta_total, string id)
        {
            string info_a_retornar = "";


            string info_agregar_temp = nombre_produc + G_caracter_separacion[0] + cantidad + G_caracter_separacion[0] + cod_bar + G_caracter_separacion[0] + provedor + G_caracter_separacion[0] + cantidad + G_caracter_separacion[0] + cantidad + G_caracter_separacion[0] + cantidad + G_caracter_separacion[0] + "7" + G_caracter_separacion[0] + G_caracter_separacion[0] + G_caracter_separacion[0] + G_caracter_separacion[0];
            if (ultima_venta_del_producto == "")
            {
                //dia-------------------------------------------------------------------------
                string[] resul_agregue = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_INFO_DIV" + G_caracter_separacion_funciones_espesificas[1] + G_direcciones[6] + G_caracter_separacion_funciones_espesificas[3][0] + info_agregar_temp).Split(G_caracter_para_confirmacion_o_error[0][0]);
                string[] info_agregue = resul_agregue[1].Split(G_caracter_separacion[0][0]);

                string info_editar_temp = G_direcciones[0] + G_caracter_separacion_funciones_espesificas[3] +
                    info_agregue[0] + G_caracter_separacion_funciones_espesificas[3] +
                    "27" + G_caracter_separacion_funciones_espesificas[4] + "30" + G_caracter_separacion_funciones_espesificas[4] + "18" + G_caracter_separacion_funciones_espesificas[3] +
                    info_agregue[0] + G_caracter_separacion_funciones_espesificas[4] + fecha_de_la_venta_total + G_caracter_separacion_funciones_espesificas[4] + fecha_de_la_venta_total;

                info_a_retornar = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "EDITAR_CELDA_ID_INFO_DIVIDIDA" + G_caracter_separacion_funciones_espesificas[1] + info_editar_temp);
                //mes----------------------------------------------------------------------------------
                resul_agregue = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_INFO_DIV" + G_caracter_separacion_funciones_espesificas[1] + G_direcciones[7] + G_caracter_separacion_funciones_espesificas[3][0] + info_agregar_temp).Split(G_caracter_para_confirmacion_o_error[0][0]);
                info_agregue = resul_agregue[1].Split(G_caracter_separacion[0][0]);

                info_editar_temp = G_direcciones[0] + G_caracter_separacion_funciones_espesificas[3] +
                    info_agregue[0] + G_caracter_separacion_funciones_espesificas[3] +
                    "28" + G_caracter_separacion_funciones_espesificas[3] +
                    info_agregue[0];
                info_a_retornar = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "EDITAR_CELDA_ID_INFO_DIVIDIDA" + G_caracter_separacion_funciones_espesificas[1] + info_editar_temp);
                //año--------------------------------------------------------------------------------------
                resul_agregue = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_INFO_DIV" + G_caracter_separacion_funciones_espesificas[1] + G_direcciones[8] + G_caracter_separacion_funciones_espesificas[3][0] + info_agregar_temp).Split(G_caracter_para_confirmacion_o_error[0][0]);
                info_agregue = resul_agregue[1].Split(G_caracter_separacion[0][0]);

                info_editar_temp = G_direcciones[0] + G_caracter_separacion_funciones_espesificas[3] +
                    info_agregue[0] + G_caracter_separacion_funciones_espesificas[3] +
                    "29" + G_caracter_separacion_funciones_espesificas[3] +
                    info_agregue[0];

                info_a_retornar = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "EDITAR_CELDA_ID_INFO_DIVIDIDA" + G_caracter_separacion_funciones_espesificas[1] + info_editar_temp);
                //acumulado--------------------------------------------------------------------------------------
                resul_agregue = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_INFO_DIV" + G_caracter_separacion_funciones_espesificas[1] + G_direcciones[9] + G_caracter_separacion_funciones_espesificas[3][0] + info_agregar_temp).Split(G_caracter_para_confirmacion_o_error[0][0]);
                info_agregue = resul_agregue[1].Split(G_caracter_separacion[0][0]);

                info_editar_temp = G_direcciones[0] + G_caracter_separacion_funciones_espesificas[3] +
                    info_agregue[0] + G_caracter_separacion_funciones_espesificas[3] +
                    "31" + G_caracter_separacion_funciones_espesificas[3] +
                    info_agregue[0];

                info_a_retornar = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "EDITAR_CELDA_ID_INFO_DIVIDIDA" + G_caracter_separacion_funciones_espesificas[1] + info_editar_temp);
                //--------------------------------------------------------------------------------------------


            }
            else
            {
                if (Convert.ToInt32(ultima_venta_del_producto) > Convert.ToInt32(fecha_de_la_venta_total))
                {
                    //aqui va a buscar en el archivo la informacion para editar
                    //o la agrega mejor en un archivo diferente
                    //pero si son diferentes puntos de venta y venden varios productos iguales  masomenos al mismo tiempo  tiene que editarse

                    info_a_retornar = "-1" + G_caracter_para_confirmacion_o_error[0] + "es_un_archivo_anterior";
                }
                else
                {
                    info_a_retornar = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_INFO_DIV" + G_caracter_separacion_funciones_espesificas[1] + G_direcciones[6] + G_caracter_separacion_funciones_espesificas[3][0] + info_agregar_temp);


                    string info_editar_temp = G_direcciones[0] + G_caracter_separacion_funciones_espesificas[3] +
                        id + G_caracter_separacion_funciones_espesificas[3] +
                        "30" + G_caracter_separacion_funciones_espesificas[3] +
                        fecha_de_la_venta_total;

                    info_a_retornar = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "EDITAR_CELDA_ID_INFO_DIVIDIDA" + G_caracter_separacion_funciones_espesificas[1] + info_editar_temp);
                }
            }
            return info_a_retornar;
        }

        private string incremento_registro_producto(string id_arc_total, string id_año, string id_mes, string id_dia, string nombre_produc, string cantidad, string cod_bar, string provedor, string ultima_venta_del_producto, string fecha_de_la_venta_total, string id)
        {
            string info_a_retornar = "";


            string info_agregar_temp = nombre_produc + G_caracter_separacion[0] + cantidad + G_caracter_separacion[0] + cod_bar + G_caracter_separacion[0] + provedor + G_caracter_separacion[0] + cantidad + G_caracter_separacion[0] + cantidad + G_caracter_separacion[0] + cantidad + G_caracter_separacion[0] + "7" + G_caracter_separacion[0] + G_caracter_separacion[0] + G_caracter_separacion[0] + G_caracter_separacion[0];
            
            if (ultima_venta_del_producto == "")
            {
                //dia-------------------------------------------------------------------------
                string[] resul_agregue = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_INFO_DIV" + G_caracter_separacion_funciones_espesificas[1] + G_direcciones[6] + G_caracter_separacion_funciones_espesificas[3][0] + info_agregar_temp).Split(G_caracter_para_confirmacion_o_error[0][0]);
                string[] info_agregue = resul_agregue[1].Split(G_caracter_separacion[0][0]);

                string info_editar_temp = G_direcciones[0] + G_caracter_separacion_funciones_espesificas[3] +
                    info_agregue[0] + G_caracter_separacion_funciones_espesificas[3] +
                    "27" + G_caracter_separacion_funciones_espesificas[4] + "30" + G_caracter_separacion_funciones_espesificas[4] + "18" + G_caracter_separacion_funciones_espesificas[3] +
                    info_agregue[0] + G_caracter_separacion_funciones_espesificas[4] + fecha_de_la_venta_total + G_caracter_separacion_funciones_espesificas[4] + fecha_de_la_venta_total;

                info_a_retornar = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "EDITAR_CELDA_ID_INFO_DIVIDIDA" + G_caracter_separacion_funciones_espesificas[1] + info_editar_temp);
                //mes----------------------------------------------------------------------------------
                resul_agregue = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_INFO_DIV" + G_caracter_separacion_funciones_espesificas[1] + G_direcciones[7] + G_caracter_separacion_funciones_espesificas[3][0] + info_agregar_temp).Split(G_caracter_para_confirmacion_o_error[0][0]);
                info_agregue = resul_agregue[1].Split(G_caracter_separacion[0][0]);

                info_editar_temp = G_direcciones[0] + G_caracter_separacion_funciones_espesificas[3] +
                    info_agregue[0] + G_caracter_separacion_funciones_espesificas[3] +
                    "28" + G_caracter_separacion_funciones_espesificas[3] +
                    info_agregue[0];
                info_a_retornar = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "EDITAR_CELDA_ID_INFO_DIVIDIDA" + G_caracter_separacion_funciones_espesificas[1] + info_editar_temp);
                //año--------------------------------------------------------------------------------------
                resul_agregue = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_INFO_DIV" + G_caracter_separacion_funciones_espesificas[1] + G_direcciones[8] + G_caracter_separacion_funciones_espesificas[3][0] + info_agregar_temp).Split(G_caracter_para_confirmacion_o_error[0][0]);
                info_agregue = resul_agregue[1].Split(G_caracter_separacion[0][0]);

                info_editar_temp = G_direcciones[0] + G_caracter_separacion_funciones_espesificas[3] +
                    info_agregue[0] + G_caracter_separacion_funciones_espesificas[3] +
                    "29" + G_caracter_separacion_funciones_espesificas[3] +
                    info_agregue[0];

                info_a_retornar = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "EDITAR_CELDA_ID_INFO_DIVIDIDA" + G_caracter_separacion_funciones_espesificas[1] + info_editar_temp);
                //acumulado--------------------------------------------------------------------------------------
                resul_agregue = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_INFO_DIV" + G_caracter_separacion_funciones_espesificas[1] + G_direcciones[9] + G_caracter_separacion_funciones_espesificas[3][0] + info_agregar_temp).Split(G_caracter_para_confirmacion_o_error[0][0]);
                info_agregue = resul_agregue[1].Split(G_caracter_separacion[0][0]);

                info_editar_temp = G_direcciones[0] + G_caracter_separacion_funciones_espesificas[3] +
                    info_agregue[0] + G_caracter_separacion_funciones_espesificas[3] +
                    "29" + G_caracter_separacion_funciones_espesificas[3] +
                    info_agregue[0];

                info_a_retornar = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "EDITAR_CELDA_ID_INFO_DIVIDIDA" + G_caracter_separacion_funciones_espesificas[1] + info_editar_temp);
                //--------------------------------------------------------------------------------------------


            }
            else
            {

                if (Convert.ToInt32(ultima_venta_del_producto) > Convert.ToInt32(fecha_de_la_venta_total))
                {
                    //aqui va a buscar en el archivo la informacion para editar
                    //o la agrega mejor en un archivo diferente

                    //pero si son diferentes puntos de venta y venden varios productos iguales  masomenos al mismo tiempo  tiene que editarse
                    info_a_retornar = "-1" + G_caracter_para_confirmacion_o_error[0] + "es_un_archivo_anterior";
                }
                else if (Convert.ToInt32(ultima_venta_del_producto) == Convert.ToInt32(fecha_de_la_venta_total))
                {
                    //dia_-------------------------------------------------------------------------------------

                    string dir_tem = consigue_la_direccion_del_registro_productos_de_la_fecha(fecha_de_la_venta_total);


                    string info_editar_temp =
                    dir_tem + G_caracter_separacion_funciones_espesificas[3] +
                        id_dia + G_caracter_separacion_funciones_espesificas[3] +
                        "2" + G_caracter_separacion_funciones_espesificas[4] + "5" + G_caracter_separacion_funciones_espesificas[5] + "0" + G_caracter_separacion_funciones_espesificas[3] +
                        cantidad + G_caracter_separacion_funciones_espesificas[4] + cantidad;
                        
                    info_a_retornar = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "INCREMENTA_CELDA_ID_INFO_DIVIDIDA" + G_caracter_separacion_funciones_espesificas[1] + info_editar_temp);

                    //mes--------------------------------------------------------------------------------------
                    dir_tem = "";
                    for (int j = 0; j < fecha_de_la_venta_total.Length-2; j++)
                    {
                        dir_tem= dir_tem+fecha_de_la_venta_total[j];
                    }

                    dir_tem = consigue_la_direccion_del_registro_productos_de_la_fecha(dir_tem);


                    info_editar_temp =
                    dir_tem + G_caracter_separacion_funciones_espesificas[3] +
                        id_mes + G_caracter_separacion_funciones_espesificas[3] +
                        "2" + G_caracter_separacion_funciones_espesificas[4] + "5" + G_caracter_separacion_funciones_espesificas[5] + "0" + G_caracter_separacion_funciones_espesificas[3] +
                        cantidad + G_caracter_separacion_funciones_espesificas[4] + cantidad;

                    info_a_retornar = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "INCREMENTA_CELDA_ID_INFO_DIVIDIDA" + G_caracter_separacion_funciones_espesificas[1] + info_editar_temp);

                    //año--------------------------------------------------------------------------------------
                    dir_tem = "";
                    for (int j = 0; j < fecha_de_la_venta_total.Length - 4; j++)
                    {
                        dir_tem = dir_tem + fecha_de_la_venta_total[j];
                    }

                    dir_tem = consigue_la_direccion_del_registro_productos_de_la_fecha(dir_tem);


                    info_editar_temp =
                    dir_tem + G_caracter_separacion_funciones_espesificas[3] +
                        id_año + G_caracter_separacion_funciones_espesificas[3] +
                        "2" + G_caracter_separacion_funciones_espesificas[4] + "5" + G_caracter_separacion_funciones_espesificas[5] + "0" + G_caracter_separacion_funciones_espesificas[3] +
                        cantidad + G_caracter_separacion_funciones_espesificas[4] + cantidad;

                    info_a_retornar = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "INCREMENTA_CELDA_ID_INFO_DIVIDIDA" + G_caracter_separacion_funciones_espesificas[1] + info_editar_temp);

                    //actual-----------------------------------------------------------------------------------


                    info_editar_temp =
                    G_direcciones[9] + G_caracter_separacion_funciones_espesificas[3] +
                        id_arc_total + G_caracter_separacion_funciones_espesificas[3] +
                        "2" + G_caracter_separacion_funciones_espesificas[4] + "5" + G_caracter_separacion_funciones_espesificas[5] + "0" + G_caracter_separacion_funciones_espesificas[3] +
                        cantidad + G_caracter_separacion_funciones_espesificas[4] + cantidad;

                    info_a_retornar = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "INCREMENTA_CELDA_ID_INFO_DIVIDIDA" + G_caracter_separacion_funciones_espesificas[1] + info_editar_temp);




                    //info_a_retornar = "-1" + G_caracter_para_confirmacion_o_error[0] + "es_un_archivo_anterior";
                }
                else if (Convert.ToInt32(ultima_venta_del_producto) < Convert.ToInt32(fecha_de_la_venta_total))
                {

                }
            }
            return info_a_retornar;
        }

        private string consigue_la_direccion_del_registro_productos_de_la_fecha(string fecha)
        {
            string[] dir_esp = var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[14, 0].Split('\\');
            string direccion = "";
            for (int i = 0; i < dir_esp.Length-3; i++)
            {
                direccion = op_tex.concatenacion_caracter_separacion(direccion, dir_esp[i], "\\");
            }

            string año = "";
            string mes = "";
            string dia = "";
            if (fecha.Length < 5) 
            {
                año = fecha.Substring(0, 4);
                direccion = direccion + "\\" + año;
            }
            else if (fecha.Length >= 5 && fecha.Length < 7) 
            {
                año = fecha.Substring(0, 4);
                mes = fecha.Substring(4, 2);
                direccion = direccion + "\\" + año + "\\" + año + mes;
            }
            else if (fecha.Length >= 7 && fecha.Length < 9)
            {
                año = fecha.Substring(0, 4);
                mes = fecha.Substring(4, 2);
                dia = fecha.Substring(6, 2);
                direccion = direccion + "\\" + año + "\\" + año + mes + "\\" + año + mes + dia;
            }

            direccion = direccion + "_PRODUC_REGISTRO.TXT";
            return direccion;
        }

        //fin clase-----------------------------------------------------------------
    }
}
