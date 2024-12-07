using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;

namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.procesos
{
    internal class _08_proceso_registros
    {
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;


        var_fun_GG vf_GG = new var_fun_GG();
        operaciones_textos op_tex = new operaciones_textos();
        operaciones_arreglos op_arr = new operaciones_arreglos();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        string[] G_direcciones =
        {
            Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[1, 0],//"config\\inf\\inventario\\inventario.TXT",
            Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[19, 0],//CONFIG\\INF\\IMPUESTOS\\IMPUESTOS.TXT,
        };

        Tex_base bas = new Tex_base();


        public void modificar_historial_ranking(string direccion_archivo, string datos, string fecha_o_hora, object caracter_separacion_obj = null)
        {
            //0_NOMBRE_PRODUCTO|1_CANTIDAD|2_COD_BAR|3_COMENTARIO|4_HISTORIAL|5_RANKING|6_PROMEDIO|7_VECES_QUE_SUPERA_PROMEDIO
            string[] caracter_separacion_string = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);

            string[] dat_esp = datos.Split(G_caracter_separacion[0][0]);
            string[] cuantos_cod_bar = dat_esp[2].Split(G_caracter_separacion[1][0]);

            cuantos_cod_bar = si_hay_iguales_en_codigo_y_plataforma_suma_cantidad_proceso_registros(cuantos_cod_bar);

            for (int l = 0; l < cuantos_cod_bar.Length; l++)
            {
                string[] info_dat = cuantos_cod_bar[l].Split(G_caracter_separacion[2][0]);
                string cod_bar = info_dat[0];

                string[] res_busq_produc = bas.buscar(direccion_archivo, cod_bar, 2).Split(G_caracter_para_confirmacion_o_error[0][0]);

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
                        string res_edicion = bas.Editar_fila_espesifica(direccion_archivo, Convert.ToInt32(res_busq_produc[2]), info_a_editar);


                    }
                }

            }





        }


        public string registrar_venta(string direccion_archivo, string datos, string fecha_o_hora, object caracter_separacion_obj = null)
        {

            string[] caracter_separacion_string = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string info_a_retornar = "";



            string resultado_archivo = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo);
            string[] res_esp_archivo = resultado_archivo.Split(G_caracter_para_confirmacion_o_error[0][0]);
            //se encontro indice archivo
            if (Convert.ToInt32(res_esp_archivo[0]) > 0)
            {
                int indice = Convert.ToInt32(res_esp_archivo[1]);


                string tipo_de_operacion = "";
                double total_venta = 0;

                double total_pagar_imp = 0;


                string[] impuestos_a_registrar = null;



                string[] dat_esp = datos.Split(G_caracter_separacion[0][0]);
                string[] cuantos_cod_bar = dat_esp[0].Split(G_caracter_separacion[1][0]);

                cuantos_cod_bar = si_hay_iguales_en_codigo_y_plataforma_suma_cantidad_proceso_registros(cuantos_cod_bar);

                string Codbar_PreTot_Nom_Cant_Plat_DatPlat = "";

                for (int l = 0; l < cuantos_cod_bar.Length; l++)
                {
                    string[] info_dat = cuantos_cod_bar[l].Split(G_caracter_separacion[2][0]);
                    string cod_bar = info_dat[0];
                    double cantidad = Convert.ToDouble(info_dat[1]);
                    double precio_venta = -0;
                    double precio_compra = -0;
                    double tot_venta_producto = -0;
                    double tot_compra_producto = -0;
                    double ganancia = -0;

                    string nombre_produc = "";



                    string[] res_busq_produc = bas.buscar(G_direcciones[0], info_dat[0], 5, info_dat[2]).Split(G_caracter_para_confirmacion_o_error[0][0]);
                    //encontro producto
                    if (Convert.ToInt32(res_busq_produc[0]) > 0)
                    {
                        if (res_busq_produc[0] == "1")
                        {


                            string[] produc_bas_esp = res_busq_produc[1].Split(G_caracter_separacion[0][0]);
                            string[] imp_a_procesar = produc_bas_esp[15].Split(G_caracter_separacion[1][0]);
                            nombre_produc = produc_bas_esp[1] + " " + produc_bas_esp[2] + " " + produc_bas_esp[3];
                            //cod_mod__01
                            precio_venta = Convert.ToDouble(produc_bas_esp[4]);
                            precio_compra = Convert.ToDouble(produc_bas_esp[7]);
                            tot_venta_producto = cantidad * precio_venta;
                            tot_compra_producto = cantidad * precio_compra;
                            ganancia = tot_venta_producto - tot_compra_producto;


                            for (int i = 0; i < imp_a_procesar.Length; i++)
                            {
                                string[] res_busq_imp = bas.buscar(G_direcciones[1], imp_a_procesar[i], 0).Split(G_caracter_para_confirmacion_o_error[0][0]);
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


                                            double impuesto_en_decimal = (Convert.ToDouble(inf_imp[1]) / 100);

                                            impuestos_a_registrar = op_arr.agregar_registro_del_array(impuestos_a_registrar, inf_imp[0] + caracter_separacion_string[2] + (impuesto_en_decimal * tot_venta_producto));

                                            double impueesto_en_dinero = (impuesto_en_decimal * ganancia);


                                            total_pagar_imp = total_pagar_imp + impueesto_en_dinero;
                                        }

                                    }
                                }
                            }

                        }

                    }



                    total_venta = total_venta + tot_venta_producto;


                    Codbar_PreTot_Nom_Cant_Plat_DatPlat = op_tex.concatenacion_caracter_separacion(Codbar_PreTot_Nom_Cant_Plat_DatPlat, cod_bar + caracter_separacion_string[2] + tot_venta_producto + caracter_separacion_string[2] + nombre_produc + caracter_separacion_string[2] + cantidad, caracter_separacion_string[1]);


                    tipo_de_operacion = op_tex.concatenacion_caracter_separacion(tipo_de_operacion, "VENTA", G_caracter_separacion[1]);
                    //Codbar_PreTot_Nom_Cant_Plat_DatPlat = "";
                    //total_compra = "";
                    //total_pagar_imp = "";



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
                    + total_venta//total_costo_venta
                    + caracter_separacion_string[0]
                    + ""//total_costo_compra
                    + caracter_separacion_string[0]
                    + total_pagar_imp
                    + caracter_separacion_string[0]
                    + ""
                    + caracter_separacion_string[0]
                    + ""//ganancia_total
                    + caracter_separacion_string[0]
                    + "";

                info_a_retornar = bas.Agregar(direccion_archivo, info_agregar);

            }

            else
            {
                info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se encontro la direccion";
            }

            return info_a_retornar;
        }

        public string registrar_compra(string direccion_archivo, string datos, string fecha_o_hora, object caracter_separacion_obj = null)
        {

            string[] caracter_separacion_string = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string info_a_retornar = "";



            string resultado_archivo = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo);
            string[] res_esp_archivo = resultado_archivo.Split(G_caracter_para_confirmacion_o_error[0][0]);
            if (Convert.ToInt32(res_esp_archivo[0]) > 0)
            {
                int indice = Convert.ToInt32(res_esp_archivo[1]);


                string tipo_de_operacion = "";
                double total_compra = 0;

                double total_pagar_imp = 0;


                string[] impuestos_a_registrar = null;



                string[] dat_esp = datos.Split(G_caracter_separacion[0][0]);
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

                        string[] res_busq_produc = bas.buscar(G_direcciones[0], info_dat[0], 5, info_dat[3]).Split(G_caracter_para_confirmacion_o_error[0][0]);
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
                                    string[] res_busq_imp = bas.buscar(G_direcciones[1], imp_a_procesar[i], 0).Split(G_caracter_para_confirmacion_o_error[0][0]);
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

                info_a_retornar = bas.Agregar(direccion_archivo, info_agregar);

            }

            else
            {
                info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se encontro la direccion";
            }

            return info_a_retornar;
        }

        public string registro_incrementar_venta(string direccion_archivo, string datos, string fecha)
        {
            string info_a_retornar = "";

            string resultado_archivo = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo);
            string[] res_esp_archivo = resultado_archivo.Split(G_caracter_para_confirmacion_o_error[0][0]);
            //encontro el archivo
            if (Convert.ToInt32(res_esp_archivo[0]) > 0)
            {
                if (res_esp_archivo[0] == "1")
                {
                    string[] datos_esp = datos.Split(G_caracter_separacion[0][0]);
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

        public string registro_incrementar_compra(string direccion_archivo, string datos, string fecha)
        {
            string info_a_retornar = "";

            string resultado_archivo = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo);
            string[] res_esp_archivo = resultado_archivo.Split(G_caracter_para_confirmacion_o_error[0][0]);
            //encontro el archivo
            if (Convert.ToInt32(res_esp_archivo[0]) > 0)
            {
                if (res_esp_archivo[0] == "1")
                {
                    string[] datos_esp = datos.Split(G_caracter_separacion[0][0]);
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



        public string registrar_movimiento_productos(string direccion_archivo, string modelo, string proceso, string datos, string fecha_o_hora, object caracter_separacion_obj = null)
        {


            string[] caracter_separacion_string = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string info_a_retornar = "";



            string resultado_archivo = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo);
            string[] res_esp_archivo = resultado_archivo.Split(G_caracter_para_confirmacion_o_error[0][0]);
            //encontro archivo?
            if (Convert.ToInt32(res_esp_archivo[0]) > 0)
            {
                int indice = Convert.ToInt32(res_esp_archivo[1]);






                string[] temp = datos.Split(G_caracter_separacion[0][0]);
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






                info_a_retornar = bas.Agregar(direccion_archivo, info_agregar);

            }

            else
            {
                info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se encontro la direccion";
            }

            return info_a_retornar;
        }
        public string registro_incrementar_productos(string direccion_archivo, string datos, string fecha)
        {
            string info_a_retornar = "";

            string resultado_archivo = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo);
            string[] res_esp_archivo = resultado_archivo.Split(G_caracter_para_confirmacion_o_error[0][0]);
            //encontro el archivo
            if (Convert.ToInt32(res_esp_archivo[0]) > 0)
            {
                if (res_esp_archivo[0] == "1")
                {



                    string[] datos_esp = datos.Split(G_caracter_separacion[0][0]);
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

                        if (datos_esp[1] == "COMPRA")
                        {
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
                        string[] res_busq_produc = bas.buscar(G_direcciones[0], comp_prod_1[0], 5).Split(G_caracter_para_confirmacion_o_error[0][0]);

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



    }
}
