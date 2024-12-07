using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;

namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.procesos
{
    internal class _02_proceso_ventas
    {
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;



        var_fun_GG vf_GG = new var_fun_GG();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        Tex_base bas = new Tex_base();
        operaciones_textos op_tex = new operaciones_textos();
        operaciones_arreglos op_arr = new operaciones_arreglos();

        public string ventas(string direccion_archivo, string codigos, string cantidades, string plataforma = "")
        {
            string info_a_retornar = null;


            DateTime fecha_hora = DateTime.Now;
            string año_mes_dia_hora = fecha_hora.ToString("yyyyMMddHH");
            string año = fecha_hora.ToString("yyyy");

            string res_indise = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo);
            string[] res_esp_indice = res_indise.Split(G_caracter_para_confirmacion_o_error[0][0]);

            string[] codigos_espliteados = codigos.Split(G_caracter_separacion[1][0]);
            string[] cantidades_espliteados = cantidades.Split(G_caracter_separacion[1][0]);

            //se encontro el archivo?
            if (Convert.ToInt32(res_esp_indice[0]) > 0)
            {
                if (res_esp_indice[0] == "1")
                {
                    int indice = Convert.ToInt32(res_esp_indice[1]);


                    string productos_no_encontrados = "";
                    for (int i = 0; i < codigos_espliteados.Length; i++)
                    {

                        string res_bus = op_arr.busqueda_profunda_arreglo(Tex_base.GG_base_arreglo_de_arreglos[indice], "5", codigos_espliteados[i], donde_iniciar: G_donde_inicia_la_tabla);
                        string[] res_esp_bus = res_bus.Split(G_caracter_para_confirmacion_o_error[0][0]);

                        //se encontro el producto?
                        if (Convert.ToInt32(res_esp_bus[0]) > 0)
                        {
                            if (res_esp_bus[0] == "1")
                            {
                                string[] info_esp = res_esp_bus[1].Split(G_caracter_separacion[0][0]);
                                double cantidad_doubl = Convert.ToDouble(cantidades_espliteados[i]);
                                double precio_unitario = Convert.ToDouble(info_esp[4]);
                                double total_pagar = cantidad_doubl * precio_unitario;

                                //grupo_al_que_forma_el_producto
                                if (info_esp[9] == "PRODUCTO_PIEZA")
                                {
                                    //edita inventario
                                    info_a_retornar = bas.Editar_incr_o_agrega_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID
                                        (direccion_archivo, 5, codigos_espliteados[i]
                                        ,
                                          //columnas a editar
                                          /*0*/"6"//cantidad
                                        + G_caracter_separacion_funciones_espesificas[0]
                                         /*1*/+ "17"//_17_ultimo_movimiento

                                        ,
                                          //info a editar o incrementar o agregar
                                          /*0*/"" + (cantidad_doubl * -1) //cantidad
                                          + G_caracter_separacion_funciones_espesificas[0]
                                          /*1*/+ DateTime.Now.ToString("yyyyMMddHH") //_17_ultimo_movimiento

                                          ,
                                          //comparacion para edicion dejar en blanco si no hay comparacion
                                          // si cuando se hace el espliteo de la info extraida del archivo solo es 1 celda no comparara
                                          // ejemplo correcto "a¬1" ejemplo donde no comparara  "provedor" y este sera comparado con la info de edicion
                                          /*0*/  "" //cantidad
                                          + G_caracter_separacion_funciones_espesificas[0]
                                          /*1*/+ "" //_17_ultimo_movimiento

                                        ,
                                          // 0:editar  1:incrementar 2:agregar
                                          /*0*/"1"//incrementar//cantidad
                                          + G_caracter_separacion_funciones_espesificas[0]
                                          /*1*/+ "0"//editar//_17_ultimo_movimiento




                                     );



                                }

                                else if (info_esp[9] == "PRODUCTO_CANTIDAD")
                                {
                                    //edita inventario
                                    info_a_retornar = bas.Editar_incr_o_agrega_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID(direccion_archivo, 5, codigos_espliteados[i]
                                        ,
                                          //columnas a editar
                                          /*0*/"6"//cantidad
                                        + G_caracter_separacion_funciones_espesificas[0]
                                         /*1*/+ "17"//_17_ultimo_movimiento

                                        ,
                                          //info a editar o incrementar o agregar
                                          /*0*/"" + (cantidad_doubl * -1) //cantidad
                                          + G_caracter_separacion_funciones_espesificas[0]
                                          /*1*/+ DateTime.Now.ToString("yyyyMMddHH") //_17_ultimo_movimiento

                                          ,
                                          //comparacion para edicion dejar en blanco si no hay comparacion
                                          // si cuando se hace el espliteo de la info extraida del archivo solo es 1 celda no comparara
                                          // ejemplo correcto "a¬1" ejemplo donde no comparara  "provedor" y este sera comparado con la info de edicion
                                          /*0*/  "" //cantidad
                                          + G_caracter_separacion_funciones_espesificas[0]
                                          /*1*/+ "" //_17_ultimo_movimiento

                                        ,
                                          // 0:editar  1:incrementar 2:agregar
                                          /*0*/"1"//incrementar//cantidad
                                          + G_caracter_separacion_funciones_espesificas[0]
                                          /*1*/+ "0"//editar//_17_ultimo_movimiento




                                     );



                                }

                                else if (info_esp[9] == "PRODUCTO_ELABORADO")
                                {
                                    //edita inventario
                                    info_a_retornar = bas.Editar_incr_o_agrega_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID
                                        (direccion_archivo, 5, codigos_espliteados[i]
                                        ,
                                          //columnas a editar
                                          /*0*/"6"//cantidad
                                        + G_caracter_separacion_funciones_espesificas[0]
                                         /*1*/+ "17"//_17_ultimo_movimiento

                                        ,
                                          //info a editar o incrementar o agregar
                                          /*0*/"" + (cantidad_doubl * -1) //cantidad
                                          + G_caracter_separacion_funciones_espesificas[0]
                                          /*1*/+ DateTime.Now.ToString("yyyyMMddHH") //_17_ultimo_movimiento

                                          ,
                                          //comparacion para edicion dejar en blanco si no hay comparacion
                                          // si cuando se hace el espliteo de la info extraida del archivo solo es 1 celda no comparara
                                          // ejemplo correcto "a¬1" ejemplo donde no comparara  "provedor" y este sera comparado con la info de edicion
                                          /*0*/  "" //cantidad
                                          + G_caracter_separacion_funciones_espesificas[0]
                                          /*1*/+ "" //_17_ultimo_movimiento

                                        ,
                                          // 0:editar  1:incrementar 2:agregar
                                          /*0*/"1"//incrementar//cantidad
                                          + G_caracter_separacion_funciones_espesificas[0]
                                          /*1*/+ "0"//editar//_17_ultimo_movimiento




                                     );



                                }
                            }



                        }



                        else
                        {
                            if (res_esp_bus[0] == "0")
                            {
                                productos_no_encontrados = op_tex.concatenacion_caracter_separacion(productos_no_encontrados, "-1" + G_caracter_para_confirmacion_o_error[0] + codigos_espliteados, G_caracter_para_confirmacion_o_error[1]);

                            }
                        }

                    }
                }
            }
            else
            {
                if (res_esp_indice[0] == "0")
                {
                    info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se encontro el archivo";
                }
            }




            return info_a_retornar;
        }


    }
}
