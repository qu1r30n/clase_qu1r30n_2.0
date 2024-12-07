using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;

namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.procesos
{
    internal class _01_proceso_compras
    {
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;


        var_fun_GG vf_GG = new var_fun_GG();
        var_fun_GG_dir_arch_crear vf_GG_arc_cr = new var_fun_GG_dir_arch_crear();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        Tex_base bas = new Tex_base();

        _00_proceso_AnalisisDeDatos pr_analisis = new _00_proceso_AnalisisDeDatos();
        _03_proceso_productos_e_inventario pr_prod_inv = new _03_proceso_productos_e_inventario();

        public string compras(string direccion_archivo, string codigos_cantidad_precio_id, string provedores, string sucursales = "", double porcentage_ganancia = 20)
        {
            string info_a_retornar = "";

            DateTime fecha_hora = DateTime.Now;
            string año_mes_dia_hora = fecha_hora.ToString("yyyyMMddHH");
            string año = fecha_hora.ToString("yyyy");



            string[] info_produc = codigos_cantidad_precio_id.Split(G_caracter_separacion[1][0]);



            for (int i = 0; i < info_produc.Length; i++)
            {
                string[] cod_cant_precio_id_split = info_produc[i].Split(G_caracter_separacion[2][0]);
                double nuevo_precio_venta = Convert.ToDouble(cod_cant_precio_id_split[2]) * (1 + (porcentage_ganancia / 100));
                info_a_retornar = bas.Editar_incr_o_agrega_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID
                    (direccion_archivo, 5, cod_cant_precio_id_split[0]
                    ,
                      //columnas a editar
                      /*0*/"6"//cantidad
                    + G_caracter_separacion_funciones_espesificas[0]
                     /*1*/+ "7"//costo de compra
                    + G_caracter_separacion_funciones_espesificas[0]
                     /*2*/+ "8"//provedor
                     + G_caracter_separacion_funciones_espesificas[0]
                     /*3*/+ "18"//ultimo movimiento
                     + G_caracter_separacion_funciones_espesificas[0]
                     /*4*/+ "19"//sucursal


                    ,
                      //info a editar o incrementar o agregar
                      /*0*/cod_cant_precio_id_split[1] //cantidad
                      + G_caracter_separacion_funciones_espesificas[0]
                      /*1*/+ cod_cant_precio_id_split[2] //costo de compra
                      + G_caracter_separacion_funciones_espesificas[0]
                      /*2*/+ provedores //provedor
                      + G_caracter_separacion_funciones_espesificas[0]
                      /*3*/+ año_mes_dia_hora  //ultimo movimiento
                      + G_caracter_separacion_funciones_espesificas[0]
                      /*4*/+ sucursales  //sucursal

                      ,
                      //comparacion para edicion dejar en blanco si no hay comparacion
                      // si cuando se hace el espliteo de la info extraida del archivo solo es 1 celda no comparara
                      // ejemplo correcto "a¬1" ejemplo donde no comparara  "provedor" y este sera comparado con la info de edicion
                      /*0*/  "" //cantidad
                      + G_caracter_separacion_funciones_espesificas[0]
                      /*1*/+ "" //costo de compra
                      + G_caracter_separacion_funciones_espesificas[0]
                      /*2*/+ provedores //provedor
                      + G_caracter_separacion_funciones_espesificas[0]
                      /*3*/+ "" //ultimo movimiento
                      + G_caracter_separacion_funciones_espesificas[0]
                      /*4*/+ sucursales  //sucursal

                    ,
                      // 0:editar  1:incrementar 2:agregar
                      /*0*/"1"//incrementar//cantidad
                      + G_caracter_separacion_funciones_espesificas[0]
                      /*1*/+ "0"//editar//costo compra
                      + G_caracter_separacion_funciones_espesificas[0]
                      /*2*/+ "2"//editar//provedor
                      + G_caracter_separacion_funciones_espesificas[0]
                      /*3*/+ "0"//editar//ultimo movimiento
                      + G_caracter_separacion_funciones_espesificas[0]
                      /*4*/+ "0"  //sucursal
                      ,
                      ""
                      , posicion_fila: cod_cant_precio_id_split[3]

                      );

                string[] res_esp = info_a_retornar.Split(G_caracter_para_confirmacion_o_error[0][0]);

                //edicion fue exitosa?
                if (Convert.ToInt32(res_esp[0]) > 0) //si res es mayor a 0 la operacioon fue exitosa si no hubo un error
                {
                    if (res_esp[0] == "1")
                    {
                        string[] info_res = res_esp[1].Split(G_caracter_separacion[0][0]);
                        //presio de venta es menor o igual al costo de compra?
                        if (Convert.ToDouble(info_res[4]) <= Convert.ToDouble(cod_cant_precio_id_split[2]))
                        {

                            string[] temp = bas.Editar_incr_o_agrega_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID(direccion_archivo, 5, cod_cant_precio_id_split[0], "4", nuevo_precio_venta + "", "", "0").Split(G_caracter_para_confirmacion_o_error[0][0]);
                            if (temp[0] == "1")
                            {
                                info_a_retornar = info_a_retornar + G_caracter_para_confirmacion_o_error[0] + nuevo_precio_venta;
                            }

                        }

                    }
                }
                //agregar nueva fila
                else
                {

                    string texto_o_fila_que_ingresara_si_no_esta_el_producto = var_fun_GG_dir_arch_crear.GG_NUEVA_INFO_DEFAUL(var_fun_GG_dir_arch_crear.GG_ventana_emergente_productos,
                        "1|4|5|6|7|8|17"
                        ,
                        cod_cant_precio_id_split[4] +//1_producto
                        G_caracter_separacion[0] +
                        nuevo_precio_venta +//4_precio_venta
                        G_caracter_separacion[0] +
                        cod_cant_precio_id_split[0] +//5_cod_barras
                        G_caracter_separacion[0] +
                        cod_cant_precio_id_split[1] +//6_cantidad
                        G_caracter_separacion[0] +
                        cod_cant_precio_id_split[2] +//7_costo_comp
                        G_caracter_separacion[0] +
                        provedores + G_caracter_separacion[2] + cod_cant_precio_id_split[2] +//8_provedor
                        G_caracter_separacion[0] +
                        sucursales + G_caracter_separacion[2] + nuevo_precio_venta//17_sucursal_vent¬cost_vent
                        , "0"
                        );




                    //no encontro archivo
                    if (res_esp[0] == "0")
                    {
                        info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se_encontro_archivo";
                    }
                    else if (res_esp[0] == "-1")
                    {


                        info_a_retornar = pr_prod_inv.agregar_producto(direccion_archivo, texto_o_fila_que_ingresara_si_no_esta_el_producto);

                        info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + "no se_encontro_dato pero ya se agrego";
                    }
                }

            }

            return info_a_retornar;
        }


    }
}
