using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;

namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.procesos
{
    internal class _00_proceso_AnalisisDeDatos
    {
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;

        var_fun_GG vf_GG = new var_fun_GG();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        Tex_base bas = new Tex_base();
        operaciones_arreglos op_arr = new operaciones_arreglos();

        string[] G_direcciones =
        {
            Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[1, 0]//"config\\inf\\inventario\\inventario.TXT",
        };


        public string existe_informacion(string direccion_archivo, string informacion, string columnas_a_recorrer)
        {
            string info_a_retornar = null;



            string[] resultado = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo).ToString().Split(G_caracter_para_confirmacion_o_error[0][0]);

            if (Convert.ToInt32(resultado[0]) > 0)
            {
                if (resultado[0] == "1")
                {
                    int indice_arreglo = Convert.ToInt32(resultado[1]);

                    for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[indice_arreglo].Length; i++)
                    {
                        string[] info_espliteado = Tex_base.GG_base_arreglo_de_arreglos[indice_arreglo][i].Split(G_caracter_separacion[0][0]);
                        if (informacion == info_espliteado[4])
                        {
                            info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + "encontrado";
                            return info_a_retornar;
                        }
                    }
                    info_a_retornar = "-1" + G_caracter_para_confirmacion_o_error[0] + "no_encontrado";
                    return info_a_retornar;
                }
            }
            else
            {
                if (resultado[0] == "-1")
                {

                }
                else if (resultado[0] == "-1")
                {
                    string[] contenido_archivo = bas.leer(direccion_archivo);

                    for (int i = G_donde_inicia_la_tabla; i < contenido_archivo.Length; i++)
                    {
                        string[] info_espliteado = contenido_archivo[i].Split(G_caracter_separacion[0][0]);
                        if (informacion == info_espliteado[4])
                        {
                            info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + "encontrado";
                            return info_a_retornar;
                        }
                    }
                    info_a_retornar = "-1" + G_caracter_para_confirmacion_o_error[0] + "no_encontrado";

                    return info_a_retornar;
                }
            }


            info_a_retornar = resultado[0] + G_caracter_para_confirmacion_o_error[0] + resultado[1];

            return info_a_retornar;

        }



        string[] inventario;
        public string[] prediccion_arreglo_compra(string[] todo_el_ranking, int columna_historial, int columna_ranking, int columna_promedio_compra, int columna_veses_supera_promedio)
        {
            //ranikng //0_codigo|1_nombre_producto|2_cantidad_vendida_estos_7_dias|3_provedores|4_historial_por_semana°|5_ranking|6_promedio_normal|7_cantidad_veses_supera_el_promedio|8_usomulti_cant_invent|9_usomulti_tipo_de_producto|10_multi_costo_compra|11_

            string dir_invent = G_direcciones[0];
            inventario = bas.leer(dir_invent, "3|1|4|5|7");
            List<string> ranking_con_cant_invent = new List<string>();

            for (int i = 0; i < todo_el_ranking.Length; i++)
            {
                string[] ranking_espliteado = todo_el_ranking[i].Split(G_caracter_separacion[0][0]);
                string[] historial_producto = ranking_espliteado[columna_historial].Split(G_caracter_separacion[1][0]);

                if (ranking_espliteado[columna_promedio_compra] == "" && historial_producto[0] != "")
                {
                    ranking_espliteado[columna_promedio_compra] = historial_producto[0];
                }

                for (int k = 0; k < inventario.Length; k++)
                {
                    string[] invent_split = inventario[k].Split(G_caracter_separacion[0][0]);
                    if (ranking_espliteado[0] == invent_split[0])
                    {
                        ranking_espliteado[8] = invent_split[2];
                        ranking_espliteado[9] = invent_split[4];
                        ranking_espliteado[10] = invent_split[3];
                    }
                }

                double primera_sem_cantidad = Convert.ToDouble(historial_producto[0]);
                double promedio_normal_compra = Convert.ToDouble(ranking_espliteado[columna_promedio_compra]);
                for (int j = 0; j < historial_producto.Length; j++)
                {
                    if (historial_producto[j] == "")
                    {
                        break;
                    }
                    if (j < 3)
                    {
                        if (primera_sem_cantidad > promedio_normal_compra)
                        {
                            ranking_espliteado[columna_promedio_compra] = "" + primera_sem_cantidad;
                        }
                    }
                    else
                    {
                        if (primera_sem_cantidad > promedio_normal_compra)
                        {
                            int veses_sup_prom = Convert.ToInt32(ranking_espliteado[columna_veses_supera_promedio]);
                            int limite_veses_supera_promedio = 4;

                            if (veses_sup_prom < limite_veses_supera_promedio)
                            {
                                ranking_espliteado[columna_veses_supera_promedio] = (veses_sup_prom + 1) + "";
                            }
                            else
                            {
                                double promedio = 0;
                                for (int k = 0; k < limite_veses_supera_promedio; k++)
                                {
                                    promedio = promedio + Convert.ToDouble(historial_producto[k]);
                                }
                                ranking_espliteado[columna_promedio_compra] = "" + promedio;
                            }


                        }
                        else
                        {
                            ranking_espliteado[columna_veses_supera_promedio] = "0";
                        }
                    }
                }
                todo_el_ranking[i] = string.Join(G_caracter_separacion[0], ranking_espliteado);
            }



            string[] lista_final = calculo_pred_compra(todo_el_ranking);

            for (int i = 0; i < lista_final.Length; i++)
            {
                //ranikng //0_codigo|1_nombre_producto|2_cantidad_vendida_estos_7_dias|3_provedores|4_historial_por_semana°|5_ranking|6_promedio_normal|7_cantidad_veses|8_usomulti_cant_invent|9_usomulti_tipo_de_producto|10_multi_costo_compra|
                string[] a_cambiar = lista_final[i].Split(G_caracter_separacion[0][0]);

                lista_final[i] = a_cambiar[11] + G_caracter_separacion[0] + a_cambiar[1] + G_caracter_separacion[0] + a_cambiar[0] + G_caracter_separacion[0] + a_cambiar[3] + G_caracter_separacion[0] + a_cambiar[8] + G_caracter_separacion[0] + a_cambiar[10] + G_caracter_separacion[0];
                //lista_final//0_codigo|1_nombre_producto|2_codigo_de_barras|3_provedor|4_uso_multi_cantidad_invent|5_costo_compra|
            }
            return lista_final;
        }

        public string prediccion_archivo_compra(string direccion_ranking, int columna_historial, int columna_ranking, int columna_promedio_compra, int columna_veses_supera_promedio)
        {

            bas.Ordenar(direccion_ranking, 5, fila_donde_comiensa: 1);

            //ranikng //0_codigo|1_nombre_producto|2_cantidad_vendida_estos_7_dias|3_provedores|4_historial_por_semana°|5_ranking|6_promedio_normal|7_cantidad_veses_supera_el_promedio|8_usomulti_cant_invent|9_usomulti_tipo_de_producto|10_multi_costo_compra|11_

            string[] todo_el_ranking = bas.leer(direccion_ranking, "2|0|6|3|4|5|6|7|8|9|10|11", iniciar_desde_que_fila: G_donde_inicia_la_tabla);
            string dir_invent = G_direcciones[0];
            inventario = bas.leer(dir_invent, "5|1|6|7|9", iniciar_desde_que_fila: G_donde_inicia_la_tabla);
            List<string> ranking_con_cant_invent = new List<string>();

            for (int i = 0; i < todo_el_ranking.Length; i++)
            {
                string[] ranking_espliteado = todo_el_ranking[i].Split(G_caracter_separacion[0][0]);
                string[] historial_producto = ranking_espliteado[columna_historial].Split(G_caracter_separacion[1][0]);

                if (ranking_espliteado[columna_promedio_compra] == "" && historial_producto[0] != "")
                {
                    ranking_espliteado[columna_promedio_compra] = historial_producto[0];
                }

                for (int k = 0; k < inventario.Length; k++)
                {
                    string[] invent_split = inventario[k].Split(G_caracter_separacion[0][0]);
                    if (ranking_espliteado[0] == invent_split[0])
                    {
                        ranking_espliteado[8] = invent_split[2];
                        ranking_espliteado[9] = invent_split[4];
                        ranking_espliteado[10] = invent_split[3];
                    }
                }

                double primera_sem_cantidad = Convert.ToDouble(historial_producto[0]);
                double promedio_normal_compra = Convert.ToDouble(ranking_espliteado[columna_promedio_compra]);
                for (int j = 0; j < historial_producto.Length; j++)
                {
                    if (historial_producto[j] == "")
                    {
                        break;
                    }
                    if (j < 3)
                    {
                        if (primera_sem_cantidad > promedio_normal_compra)
                        {
                            ranking_espliteado[columna_promedio_compra] = "" + primera_sem_cantidad;
                        }
                    }
                    else
                    {
                        if (primera_sem_cantidad > promedio_normal_compra)
                        {
                            int veses_sup_prom = Convert.ToInt32(ranking_espliteado[columna_veses_supera_promedio]);
                            int limite_veses_supera_promedio = 4;

                            if (veses_sup_prom < limite_veses_supera_promedio)
                            {
                                ranking_espliteado[columna_veses_supera_promedio] = (veses_sup_prom + 1) + "";
                            }
                            else
                            {
                                double promedio = 0;
                                for (int k = 0; k < limite_veses_supera_promedio; k++)
                                {
                                    promedio = promedio + Convert.ToDouble(historial_producto[k]);
                                }
                                ranking_espliteado[columna_promedio_compra] = "" + promedio;
                            }


                        }
                        else
                        {
                            ranking_espliteado[columna_veses_supera_promedio] = "0";
                        }
                    }
                }
                todo_el_ranking[i] = string.Join(G_caracter_separacion[0], ranking_espliteado);
            }

            string[] lista_final = calculo_pred_compra(todo_el_ranking);
            for (int i = 0; i < lista_final.Length; i++)
            {

                //ranikng //0_codigo|1_nombre_producto|2_cantidad_vendida_estos_7_dias|3_provedores|4_historial_por_semana°|5_ranking|6_promedio_normal|7_cantidad_veses|8_usomulti_cant_invent|9_usomulti_tipo_de_producto|10_multi_costo_compra|
                string[] a_cambiar = lista_final[i].Split(G_caracter_separacion[0][0]);
                double posible_cantidad_a_comprar = Convert.ToDouble(a_cambiar[6]) - Convert.ToDouble(a_cambiar[8]);
                lista_final[i] = posible_cantidad_a_comprar + G_caracter_separacion[0] + a_cambiar[1] + G_caracter_separacion[0] + a_cambiar[0] + G_caracter_separacion[0] + a_cambiar[3] + G_caracter_separacion[0] + a_cambiar[8] + G_caracter_separacion[0] + a_cambiar[10] + G_caracter_separacion[0];
                //lista_final//0_codigo|1_nombre_producto|2_codigo_de_barras|3_provedor|4_uso_multi_cantidad_invent|5_costo_compra|
            }


            string info_a_retornar = string.Join(G_caracter_separacion_funciones_espesificas[0], lista_final);
            info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + info_a_retornar;
            return info_a_retornar;
        }


        private string[] calculo_pred_compra(string[] rank_y_cant_inv)
        {
            //0_codigo|1_nombre_producto|2_cantidad_vendida_estos_7_dias|3_provedores|4_historial_por_semana°|5_ranking|6_promedio_normal|7_cantidad_veses|8_uso_multiple| 
            //en caso de uso multiple en prediccion de compra se utilisa como el cantidad en el inventario

            List<string> lista_final = new List<string>();
            for (int i = 0; i < rank_y_cant_inv.Length; i++)
            {

                string[] rank_y_cant_inv_split = rank_y_cant_inv[i].Split(G_caracter_separacion[0][0]);
                double cantidad_en_inventario = Convert.ToDouble(rank_y_cant_inv_split[8]);
                double posicion_ranking = Convert.ToDouble(rank_y_cant_inv_split[5]);
                double promedio_normal_compra = Convert.ToDouble(rank_y_cant_inv_split[6]);
                string tipo_producto = rank_y_cant_inv_split[9];

                int rango_de_necesidad = posicion_rango_nesecidad(promedio_normal_compra, cantidad_en_inventario);

                for (int j = i + 1; j < rank_y_cant_inv.Length; j++)
                {
                    string[] rank_y_cant_inv_split2 = rank_y_cant_inv[j].Split(G_caracter_separacion[0][0]);
                    double cantidad_en_inventario2 = Convert.ToDouble(rank_y_cant_inv_split2[8]);
                    double posicion_ranking2 = Convert.ToDouble(rank_y_cant_inv_split2[5]);
                    double promedio_normal_compra2 = Convert.ToDouble(rank_y_cant_inv_split2[6]);
                    string tipo_producto2 = rank_y_cant_inv_split2[9];

                    int rango_de_necesidad2 = posicion_rango_nesecidad(promedio_normal_compra2, cantidad_en_inventario2);

                    //rango_de_nesecidad----------------------------------------
                    if (rango_de_necesidad > rango_de_necesidad2)
                    {
                        string tem;
                        tem = rank_y_cant_inv[i];
                        rank_y_cant_inv[i] = rank_y_cant_inv[j];
                        rank_y_cant_inv[j] = tem;
                        //recarga de variables al hacer cambio de posicion-----------------------------------------
                        rank_y_cant_inv_split = rank_y_cant_inv[i].Split(G_caracter_separacion[0][0]);
                        cantidad_en_inventario = Convert.ToDouble(rank_y_cant_inv_split[8]);
                        posicion_ranking = Convert.ToDouble(rank_y_cant_inv_split[5]);
                        promedio_normal_compra = Convert.ToDouble(rank_y_cant_inv_split[6]);
                        tipo_producto = rank_y_cant_inv_split[9];
                        rango_de_necesidad = posicion_rango_nesecidad(promedio_normal_compra, cantidad_en_inventario);

                        rank_y_cant_inv_split2 = rank_y_cant_inv[j].Split(G_caracter_separacion[0][0]);
                        cantidad_en_inventario2 = Convert.ToDouble(rank_y_cant_inv_split2[8]);
                        posicion_ranking2 = Convert.ToDouble(rank_y_cant_inv_split2[5]);
                        promedio_normal_compra2 = Convert.ToDouble(rank_y_cant_inv_split2[6]);
                        tipo_producto2 = rank_y_cant_inv_split2[9];
                        rango_de_necesidad2 = posicion_rango_nesecidad(promedio_normal_compra2, cantidad_en_inventario2);
                        //----------------------------------------------------------------------------

                    }

                    //----------------------------------------------------------

                }

            }

            return rank_y_cant_inv;
        }

        private int posicion_rango_nesecidad(double promedio_compra, double cantidad_inventario)
        {
            int rango_de_nesecidad = 0;

            if ((promedio_compra * 0.3) > cantidad_inventario)
            {
                rango_de_nesecidad = 1;
            }
            if ((promedio_compra * 0.6) > cantidad_inventario)
            {
                rango_de_nesecidad = 2;
            }
            if ((promedio_compra * 0.9) > cantidad_inventario)
            {
                rango_de_nesecidad = 3;
            }
            if ((promedio_compra * 0.9) < cantidad_inventario)
            {
                rango_de_nesecidad = 4;
            }

            return rango_de_nesecidad;
        }



    }
}
    