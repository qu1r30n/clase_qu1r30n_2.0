using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;

namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.procesos
{
    internal class _03_proceso_productos_e_inventario
    {
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;



        var_fun_GG vf_GG = new var_fun_GG();
        var_fun_GG_dir_arch_crear vf_GG_arc_crear = new var_fun_GG_dir_arch_crear();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        Tex_base bas = new Tex_base();
        operaciones_textos op_tex = new operaciones_textos();
        operaciones_arreglos op_arr = new operaciones_arreglos();

        string[] G_direcciones =
        {
            /*0*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[1, 0],//"config\\tienda\\inf\\inventario\\inventario.TXT",
        };

        public string agregar_producto(string direccion_archivo, string producto, string columnas_son_numerico = "")
        {
            string info_a_retornar = "";
            string res_ind_ar = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo);
            string[] res_esp = res_ind_ar.Split(G_caracter_para_confirmacion_o_error[0][0]);


            if (Convert.ToInt32(res_ind_ar[0]) > 0)
            {
                string[] producto_espliteado = producto.Split(G_caracter_separacion[0][0]);
                string[] columnas_son_numerico_espl = columnas_son_numerico.Split(G_caracter_separacion[0][0]);

                int indice_arreglo = Convert.ToInt32(res_esp[1]);
                string temp = Tex_base.GG_base_arreglo_de_arreglos[indice_arreglo][0];
                string[] colmnas_del_inventario = temp.Split(G_caracter_separacion[0][0]);
                int cantidad_columnas_inventario = colmnas_del_inventario.Length;
                int cantidad_columnas_nuevo_productos = producto_espliteado.Length;

                //tiene la misma cantidad de columnas para agregar?
                //el -1 es porque el id_no_lo_tiene_y_hay_que_agregarlo
                if (cantidad_columnas_inventario - 1 == cantidad_columnas_nuevo_productos)
                {
                    //checa que todos las columnas como dinero y presio entre otros tengan el tipo numerico
                    for (int i = 0; i < columnas_son_numerico_espl.Length; i++)
                    {
                        if (columnas_son_numerico_espl[i] != "")
                        {
                            int indice_a_checar = Convert.ToInt32(columnas_son_numerico_espl[i]);
                            double variable_numerica = Convert.ToDouble(producto_espliteado[indice_a_checar]);
                        }

                    }
                }





                info_a_retornar = bas.Agregar(direccion_archivo, Tex_base.GG_base_arreglo_de_arreglos[indice_arreglo].Length + G_caracter_separacion[0] + producto);
                string temp_1 = "";

                temp_1 = producto_espliteado[4] + G_caracter_separacion[0] + producto_espliteado[0] + " " + producto_espliteado[1] + producto_espliteado[2] + G_caracter_separacion[0] + (Tex_base.GG_base_arreglo_de_arreglos[indice_arreglo].Length - 1);
                var_fun_GG.GG_autoCompleteCollection_codbar_venta.Add(temp_1);
                temp_1 = producto_espliteado[0] + G_caracter_separacion[0] + producto_espliteado[4] + " " + producto_espliteado[1] + producto_espliteado[2] + G_caracter_separacion[0] + (Tex_base.GG_base_arreglo_de_arreglos[indice_arreglo].Length - 1);
                var_fun_GG.GG_autoCompleteCollection_nom_produc_venta.Add(temp_1);


                //Mod__ falta registrar ingreso de nuevo producto
                _08_proceso_registros reg = new _08_proceso_registros();



            }




            else
            {
                if (res_esp[0] == "0")
                {
                    return "0";
                }
                else if (res_esp[0] == "-1")
                {
                    return "-1";
                }
            }

            return "";
        }


        public string agrega_si_no_existe(string direccion_archivo, string producto)
        {
            string info_a_retornar = "";
            string res_ind_ar = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo);
            string[] res_esp = res_ind_ar.Split(G_caracter_para_confirmacion_o_error[0][0]);
            if (Convert.ToInt32(res_ind_ar[0]) > 0)
            {

                if (res_esp[0] == "1")
                {

                    string[] producto_espliteado = producto.Split(G_caracter_separacion[0][0]);

                    DateTime fecha_hora = DateTime.Now;
                    string año_mes_dia_hora = fecha_hora.ToString("yyyyMMddHH");
                    string año = fecha_hora.ToString("yyyy");
                    int indice_arreglo = Convert.ToInt32(res_esp[1]);


                    string _0_id = "" + Tex_base.GG_base_arreglo_de_arreglos[indice_arreglo].Length;
                    string _1_NOM_PRODUCTO = producto_espliteado[0];
                    double _2_CONTENIDO = Convert.ToDouble(producto_espliteado[1]);
                    string _3_TIPO_MEDIDA = producto_espliteado[2];
                    double _4_PRECIO_VENTA = Convert.ToDouble(producto_espliteado[3]);
                    string _5_COD_BARRAS = producto_espliteado[4];
                    double _6_CANTIDAD = Convert.ToDouble(producto_espliteado[5]);
                    double _7_COSTO_COMP = Convert.ToDouble(producto_espliteado[6]);
                    string _8_PROVEDOR = producto_espliteado[7];
                    string _9_GRUPO = producto_espliteado[8];
                    double _10_CANT_PRODUC_X_PAQUET = Convert.ToDouble(producto_espliteado[9]);
                    string _11_COD_BAR_PAQUETE1_DATO1_DATO2_COD_BAR2_PAQUETE1_DATO1_DATO2 = producto_espliteado[10];
                    string _12_LIGAR_PRODUC_SAB = producto_espliteado[11];
                    string _13_IMPUESTOS = producto_espliteado[12];
                    string _14_SI_ES_ELABORADO_QUE_MATERIA_PRIMA_USA_Y_CANTIDAD = producto_espliteado[13];
                    string _15_CADUCIDAD = producto_espliteado[14];
                    int _16_ULTIMO_MOVIMIENTO = Convert.ToInt32(producto_espliteado[15]);
                    string _17_SUCURSAL_VENT = producto_espliteado[16];
                    string _18_CLASIFICACION_PRODUCTO = producto_espliteado[17];
                    string _19_DIRECCION_IMAGEN_INTERNET = producto_espliteado[18];
                    string _20_DIRECCION_IMAGEN_COMPUTADORA = producto_espliteado[19];
                    string _21_NO_PONER_NADA = producto_espliteado[20];



                    string todo_unido = _0_id + G_caracter_separacion[0] +
                     _1_NOM_PRODUCTO + G_caracter_separacion[0] +
                     _2_CONTENIDO + G_caracter_separacion[0] +
                     _3_TIPO_MEDIDA + G_caracter_separacion[0] +
                     _4_PRECIO_VENTA + G_caracter_separacion[0] +
                     _5_COD_BARRAS + G_caracter_separacion[0] +
                     _6_CANTIDAD + G_caracter_separacion[0] +
                     _7_COSTO_COMP + G_caracter_separacion[0] +
                     _8_PROVEDOR + G_caracter_separacion[0] +
                     _9_GRUPO + G_caracter_separacion[0] +
                     _10_CANT_PRODUC_X_PAQUET + G_caracter_separacion[0] +
                     _11_COD_BAR_PAQUETE1_DATO1_DATO2_COD_BAR2_PAQUETE1_DATO1_DATO2 + G_caracter_separacion[0] +
                     _12_LIGAR_PRODUC_SAB + G_caracter_separacion[0] +
                     _13_IMPUESTOS + G_caracter_separacion[0] +
                     _14_SI_ES_ELABORADO_QUE_MATERIA_PRIMA_USA_Y_CANTIDAD + G_caracter_separacion[0] +
                     _15_CADUCIDAD + G_caracter_separacion[0] +
                     _16_ULTIMO_MOVIMIENTO + G_caracter_separacion[0] +
                     _17_SUCURSAL_VENT + G_caracter_separacion[0] +
                     _18_CLASIFICACION_PRODUCTO + G_caracter_separacion[0] +
                     _19_DIRECCION_IMAGEN_INTERNET + G_caracter_separacion[0] +
                     _20_DIRECCION_IMAGEN_COMPUTADORA + G_caracter_separacion[0] +
                     _21_NO_PONER_NADA;

                    info_a_retornar = bas.Agregar_sino_existe(direccion_archivo, 5, _5_COD_BARRAS, todo_unido);
                    string[] resultado_espliteado = info_a_retornar.Split(G_caracter_para_confirmacion_o_error[0][0]);

                    if (resultado_espliteado[0] == "1")
                    {
                        var_fun_GG.GG_autoCompleteCollection_codbar_venta.Add(_5_COD_BARRAS + G_caracter_separacion[0] + _1_NOM_PRODUCTO + " " + _2_CONTENIDO + _3_TIPO_MEDIDA + G_caracter_separacion[0] + _0_id);
                        var_fun_GG.GG_autoCompleteCollection_nom_produc_venta.Add(_1_NOM_PRODUCTO + G_caracter_separacion[0] + _5_COD_BARRAS + " " + _2_CONTENIDO + _3_TIPO_MEDIDA + G_caracter_separacion[0] + _0_id);

                    }





                }




            }

            else
            {
                if (res_esp[0] == "0")
                {
                    info_a_retornar = "0";
                }
                else if (res_esp[0] == "-1")
                {
                    info_a_retornar = "-1";
                }
            }

            return info_a_retornar;
        }

        public string buscar(string direccion_archivo, string cod_bar, string id_producto_string = "")
        {
            string inf_retornar = "";
            string[] res_busq = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo).Split(G_caracter_para_confirmacion_o_error[0][0]);
            int indice = Convert.ToInt32(res_busq[1]);
            if (id_producto_string != "")
            {
                int id_producto = Convert.ToInt32(id_producto_string);
                string[] info_produc_esp = Tex_base.GG_base_arreglo_de_arreglos[indice][id_producto].Split(G_caracter_separacion[0][0]);
                if (cod_bar == info_produc_esp[5])
                {
                    inf_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + Tex_base.GG_base_arreglo_de_arreglos[indice][id_producto] + G_caracter_para_confirmacion_o_error[0] + id_producto;
                }
                else
                {
                    bool encontro_producto = false;
                    int indice_iniciar_busqueda = id_producto;
                    if (id_producto > 9) { indice_iniciar_busqueda = indice_iniciar_busqueda - 10; }
                    else { indice_iniciar_busqueda = G_donde_inicia_la_tabla; }

                    for (int i = indice_iniciar_busqueda; i < id_producto; i++)
                    {
                        string[] info_prod_bas = Tex_base.GG_base_arreglo_de_arreglos[indice][i].Split(G_caracter_separacion[0][0]);
                        if (cod_bar == info_prod_bas[5])
                        {
                            inf_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + Tex_base.GG_base_arreglo_de_arreglos[indice][i] + G_caracter_para_confirmacion_o_error[0] + i;
                            encontro_producto = true;
                            break;
                        }
                    }
                    if (encontro_producto == false)
                    {

                        for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[indice].Length; i++)
                        {
                            string[] info_prod_bas = Tex_base.GG_base_arreglo_de_arreglos[indice][i].Split(G_caracter_separacion[0][0]);

                            if (cod_bar == info_prod_bas[5])
                            {
                                inf_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + Tex_base.GG_base_arreglo_de_arreglos[indice][i] + G_caracter_para_confirmacion_o_error[0] + i;
                                encontro_producto = true;
                                break;
                            }
                        }

                    }
                }
            }
            else
            {
                bool encontro_producto = false;
                for (int i = 0; i < Tex_base.GG_base_arreglo_de_arreglos[indice].Length; i++)
                {
                    string[] info_produc_esp = Tex_base.GG_base_arreglo_de_arreglos[indice][i].Split(G_caracter_separacion[0][0]);
                    if (cod_bar == info_produc_esp[5])
                    {
                        inf_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + Tex_base.GG_base_arreglo_de_arreglos[indice][i] + G_caracter_para_confirmacion_o_error[0] + i;
                        encontro_producto = true;
                        break;
                    }
                }
                if (encontro_producto == false)
                {
                    inf_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no encontro el producto";
                }
            }
            return inf_retornar;
        }

        public string sacar_info_productos_unitario_del_paquete(string direccion_archivo, string cod_bar_si_es_paquete, string id_producto_string = "")
        {
            string info_retornar = "";
            string[] res_busq = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo).Split(G_caracter_para_confirmacion_o_error[0][0]);
            int indice = Convert.ToInt32(res_busq[1]);
            if (id_producto_string != "")
            {
                int id_producto = Convert.ToInt32(id_producto_string);
                string[] info_produc_esp = Tex_base.GG_base_arreglo_de_arreglos[indice][id_producto].Split(G_caracter_separacion[0][0]);
                if (cod_bar_si_es_paquete == info_produc_esp[5])
                {
                    info_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + Tex_base.GG_base_arreglo_de_arreglos[indice][id_producto] + G_caracter_para_confirmacion_o_error[0] + id_producto;
                }
                else
                {
                    bool encontro_producto = false;
                    int indice_iniciar_busqueda = id_producto;
                    if (id_producto > 9) { indice_iniciar_busqueda = indice_iniciar_busqueda - 10; }
                    else { indice_iniciar_busqueda = G_donde_inicia_la_tabla; }

                    for (int i = indice_iniciar_busqueda; i < id_producto; i++)
                    {
                        string[] info_prod_bas = Tex_base.GG_base_arreglo_de_arreglos[indice][i].Split(G_caracter_separacion[0][0]);
                        if (cod_bar_si_es_paquete == info_prod_bas[5])
                        {
                            info_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + Tex_base.GG_base_arreglo_de_arreglos[indice][i] + G_caracter_para_confirmacion_o_error[0] + i;
                            encontro_producto = true;
                            break;
                        }
                    }
                    if (encontro_producto == false)
                    {

                        for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[indice].Length; i++)
                        {
                            string[] info_prod_bas = Tex_base.GG_base_arreglo_de_arreglos[indice][i].Split(G_caracter_separacion[0][0]);

                            if (cod_bar_si_es_paquete == info_prod_bas[5])
                            {
                                info_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + Tex_base.GG_base_arreglo_de_arreglos[indice][i] + G_caracter_para_confirmacion_o_error[0] + i;
                                encontro_producto = true;
                                break;
                            }
                        }

                    }
                }
            }
            else
            {
                bool encontro_producto = false;
                for (int i = 0; i < Tex_base.GG_base_arreglo_de_arreglos[indice].Length; i++)
                {
                    string[] info_produc_esp = Tex_base.GG_base_arreglo_de_arreglos[indice][i].Split(G_caracter_separacion[0][0]);
                    if (cod_bar_si_es_paquete == info_produc_esp[5])
                    {
                        info_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + Tex_base.GG_base_arreglo_de_arreglos[indice][i] + G_caracter_para_confirmacion_o_error[0] + i;
                        encontro_producto = true;
                        break;
                    }
                }
                if (encontro_producto == false)
                {
                    info_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no encontro el producto";
                }
            }


            return info_retornar;

        }

        public void archivos_inicio_hacer_inventario()
        {
            bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(vf_GG_arc_crear.GG_direccion_hacer_inventarios[0, 0], vf_GG_arc_crear.GG_direccion_hacer_inventarios[0, 1], leer_y_agrega_al_arreglo: false);


        }

        public string hacer_inventario(string informacion, string año_mes_dia, object caracter_separacion_obj = null, object caracter_separacion_obj_funciones_espesificas_obj = null)
        {
            string info_retornar = "";

            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string[] caracter_separacion_funciones_espesificas = vf_GG.GG_funcion_caracter_separacion_funciones_especificas(caracter_separacion_obj_funciones_espesificas_obj);


            string[] OPERACION_A_HACER_DESPUES_DEL_INVENTARIO = informacion.Split(caracter_separacion_funciones_espesificas[2][0]);
            string[] CANTIDAD_INFO_HACER_INV = OPERACION_A_HACER_DESPUES_DEL_INVENTARIO[1].Split(caracter_separacion_funciones_espesificas[3][0]);
            string[] filas_archivo_ventas_hecha_durante_inv = bas.leer(vf_GG_arc_crear.GG_direccion_hacer_inventarios[0, 0], caracter_separacion_objeto: caracter_separacion_obj, iniciar_desde_que_fila: 1);

            string[] arreglo_juntos = null;
            if (filas_archivo_ventas_hecha_durante_inv != null)
            {
                arreglo_juntos = op_arr.juntar_dos_arreglos(CANTIDAD_INFO_HACER_INV, filas_archivo_ventas_hecha_durante_inv);
            }
            else
            {
                arreglo_juntos = CANTIDAD_INFO_HACER_INV;
            }

            arreglo_juntos = op_arr.ordenar_arreglo(arreglo_juntos, 3);
            List<string> inventario_en_existencia = new List<string>();

            for (int i = 0; i < arreglo_juntos.Length; i++)
            {
                string[] items_atras = arreglo_juntos[i].Split(caracter_separacion[0][0]);
                // Buscar si el producto ya está en la lista
                bool producto_esta_en_la_lista = false;


                for (int j = 0; j < inventario_en_existencia.Count; j++)
                {
                    string[] items_INVENTARIO = inventario_en_existencia[j].Split(caracter_separacion[0][0]);
                    // Si el producto ya está en la lista, actualizar la cantidad
                    if (items_atras[0] == items_INVENTARIO[0])
                    {
                        producto_esta_en_la_lista = true;

                        items_INVENTARIO[2] = "" + (Convert.ToDouble(items_INVENTARIO[2]) + Convert.ToDouble(items_atras[2]));
                        inventario_en_existencia[j] = string.Join(caracter_separacion[0], items_INVENTARIO);
                        producto_esta_en_la_lista = true;
                    }
                }
                // Si el producto no está en la lista, agregarlo
                if (producto_esta_en_la_lista == false)
                {
                    if (Convert.ToDouble(items_atras[2]) > 0)
                    {
                        inventario_en_existencia.Add(arreglo_juntos[i]);
                    }
                }
            }


            bool[] productos_BOOL_encontrados_del_inventario = new bool[inventario_en_existencia.Count];

            switch (OPERACION_A_HACER_DESPUES_DEL_INVENTARIO[0])
            {
                case "MODIFICAR_INVENTARIO":
                    for (int i = 0; i < inventario_en_existencia.Count; i++)
                    {

                        string[] producto_esp = inventario_en_existencia[i].Split(caracter_separacion[0][0]);
                        string resultado = bas.Editar_incr_o_agrega_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID
                            (G_direcciones[0],
                            5,
                            producto_esp[0],
                            "6",
                            producto_esp[2],
                            "",
                            "1"
                            );
                    }
                    break;

                case "MOSTRAR_FALTANTES":

                    //SOBRANTES
                    bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(vf_GG_arc_crear.GG_direccion_hacer_inventarios[1, 0], vf_GG_arc_crear.GG_direccion_hacer_inventarios[1, 1], leer_y_agrega_al_arreglo: false);
                    //FALTANTES
                    bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(vf_GG_arc_crear.GG_direccion_hacer_inventarios[2, 0], vf_GG_arc_crear.GG_direccion_hacer_inventarios[2, 1], leer_y_agrega_al_arreglo: false);
                    //NO ESTAN EN FISICO
                    bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(vf_GG_arc_crear.GG_direccion_hacer_inventarios[3, 0], vf_GG_arc_crear.GG_direccion_hacer_inventarios[3, 1], leer_y_agrega_al_arreglo: false);
                    //NO ESTAN EN FISICO PERO PUEDE QUE SEA FALTANTE
                    bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(vf_GG_arc_crear.GG_direccion_hacer_inventarios[4, 0], vf_GG_arc_crear.GG_direccion_hacer_inventarios[3, 1], leer_y_agrega_al_arreglo: false);


                    string[] res = bas.sacar_indice_del_arreglo_de_direccion(G_direcciones[0]).Split(G_caracter_para_confirmacion_o_error[0][0]);

                    if (Convert.ToInt32(res[0]) > 0)
                    {
                        int indice = Convert.ToInt32(res[1]);
                        for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[indice].Length; i++)
                        {
                            string[] produc_INV = Tex_base.GG_base_arreglo_de_arreglos[indice][i].Split(caracter_separacion[0][0]);
                            bool encontro_producto = false;
                            for (int j = 0; j < inventario_en_existencia.Count; j++)
                            {
                                string[] produc_EXISTENCIA = inventario_en_existencia[j].Split(caracter_separacion[0][0]);

                                if (produc_EXISTENCIA[0] == produc_INV[5])
                                {

                                    productos_BOOL_encontrados_del_inventario[j] = true;

                                    encontro_producto = true;
                                    double cant_existencia = Convert.ToDouble(produc_EXISTENCIA[2]);
                                    double cant_en_el_inventario = Convert.ToDouble(produc_INV[6]);
                                    if (cant_existencia > cant_en_el_inventario)
                                    {
                                        //sobrantes
                                        bas.Agregar(vf_GG_arc_crear.GG_direccion_hacer_inventarios[1, 0], produc_INV[5] + caracter_separacion[0] + produc_INV[1] + produc_INV[2] + produc_INV[3] + caracter_separacion[0] + produc_EXISTENCIA[2] + caracter_separacion[0] + produc_INV[17]);
                                    }
                                    else if (cant_existencia < cant_en_el_inventario)
                                    {
                                        //faltantes
                                        bas.Agregar(vf_GG_arc_crear.GG_direccion_hacer_inventarios[2, 0], produc_INV[5] + caracter_separacion[0] + produc_INV[1] + produc_INV[2] + produc_INV[3] + caracter_separacion[0] + produc_EXISTENCIA[2] + caracter_separacion[0] + produc_INV[17]);
                                    }
                                    else
                                    {
                                        //esta bien
                                    }
                                    break;
                                }
                            }
                            if (encontro_producto == false)
                            {
                                int ultimo_movimiento = Convert.ToInt32(produc_INV[17]);
                                if (ultimo_movimiento < (Convert.ToInt32(año_mes_dia) - 10000))
                                {
                                    bas.Agregar(vf_GG_arc_crear.GG_direccion_hacer_inventarios[3, 0], produc_INV[5] + caracter_separacion[0] + produc_INV[1] + produc_INV[2] + produc_INV[3] + caracter_separacion[0] + produc_INV[6] + caracter_separacion[0] + produc_INV[17]);
                                }
                                else
                                {
                                    bas.Agregar(vf_GG_arc_crear.GG_direccion_hacer_inventarios[4, 0], produc_INV[5] + caracter_separacion[0] + produc_INV[1] + produc_INV[2] + produc_INV[3] + caracter_separacion[0] + produc_INV[6] + caracter_separacion[0] + produc_INV[17]);
                                }

                            }
                        }

                        //si esta en existencia pero no en el inventario hay que agregar el producto al inventario
                        for (int j = 0; j < productos_BOOL_encontrados_del_inventario.Length; j++)
                        {

                            if (productos_BOOL_encontrados_del_inventario[j] == false)
                            {
                                string[] produc_inv_esp = inventario_en_existencia[j].Split(caracter_separacion[0][0]);
                                //1|PRODUCTO|200|ML|100|COD_BAR|                                                                                                                                                                                                                   -7                   |                            100             |PROVEDOR¬0                                    |            PRODUCTO_PIEZA|10                              |INDIVIDUAL|CODIGO_BARRAS_PAQUETE                                           |COD_BAR_INDIVIDUAL_ES_PAQ|1|IVA||                                                                                                              20240606|20240605|sucursal¬0°¬2024070308|BEBIDA_ALCOLICA|||
                                string producto_a_agregar = produc_inv_esp[1] + caracter_separacion[0] + "CANT_MEDIDA" + caracter_separacion[0] + "NOSE" + caracter_separacion[0] + "PRECIO_PENDIENTE" + caracter_separacion[0] + produc_inv_esp[0] + caracter_separacion[0] + produc_inv_esp[2] + caracter_separacion[0] + "PRECIO_PENDIENTE" + caracter_separacion[0] + "PROVEDOR¬0" + caracter_separacion[0] + "PRODUCTO_PIEZA" + caracter_separacion[0] + "1" + caracter_separacion[0] + "INDIVIDUAL" + caracter_separacion[0] + "" + caracter_separacion[0] + "" + caracter_separacion[0] + "" + caracter_separacion[0] + "NOSE" + caracter_separacion[0] + "" + caracter_separacion[0] + año_mes_dia + caracter_separacion[0] + año_mes_dia + caracter_separacion[0] + "sucursal¬0" + caracter_separacion[0] + "" + caracter_separacion[0] + caracter_separacion[0] + caracter_separacion[0] + caracter_separacion[0] + caracter_separacion[0] + caracter_separacion[0];
                                agregar_producto(G_direcciones[0], producto_a_agregar);

                            }
                        }



                    }


                    break;

                default:
                    break;
            }


            return info_retornar;

        }

        public string dar_el_inventario_string_caracter_sep(string direccion_archivo, object caracter_separacion_obj = null)
        {
            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion_funciones_especificas(caracter_separacion_obj);
            string[] res_inv = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo).Split(G_caracter_para_confirmacion_o_error[0][0]);
            int indice = Convert.ToInt32(res_inv[1]);

            string inventario = op_tex.join_paresido_simple(caracter_separacion[0][0], Tex_base.GG_base_arreglo_de_arreglos[indice]);

            return inventario;

        }

    }
}
