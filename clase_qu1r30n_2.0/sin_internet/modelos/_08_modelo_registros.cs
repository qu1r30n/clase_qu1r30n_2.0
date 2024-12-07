using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;
using clase_qu1r30n_2._0.sin_internet.sin_formularios.procesos;

namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.modelos
{
    internal class _08_modelo_registros
    {

        string[] G_direcciones_REGISTROS =
        {
            Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[11,0],//reg_año_mes_dia
            Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[12,0],//reg_año_mes
            Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[13,0],//reg_año
            Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[14,0],//reg_total
            //productos
            Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[15,0],//reg_año_mes_dia
            Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[16,0],//reg_año_mes
            Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[17,0],//reg_año
            Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[18,0],//reg_total
        };

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;

        //proceso al que se dirigira//_7_procesos_sucursales pr_sucursales = new _7_procesos_sucursales();
        _08_proceso_registros pr_reg = new _08_proceso_registros();
        public string registro_movimiento(string modelo, string proceso, string datos, string fecha_yyyyMMddHHmmss)
        {
            string info_a_retornar = null;

            string año_mes_dia_hora_minuto_segundo = fecha_yyyyMMddHHmmss;
            string año_mes_dia_hora_minuto = "";
            string año_mes_dia_hora = "";
            string año_mes_dia = "";
            string año_mes = "";
            string año = "";

            for (int i = 0; i < fecha_yyyyMMddHHmmss.Length; i++)
            {
                if (i < fecha_yyyyMMddHHmmss.Length - 2)
                {
                    año_mes_dia_hora_minuto = año_mes_dia_hora_minuto + fecha_yyyyMMddHHmmss[i];
                }
                if (i < fecha_yyyyMMddHHmmss.Length - 4)
                {
                    año_mes_dia_hora = año_mes_dia_hora + fecha_yyyyMMddHHmmss[i];
                }
                if (i < fecha_yyyyMMddHHmmss.Length - 6)
                {
                    año_mes_dia = año_mes_dia + fecha_yyyyMMddHHmmss[i];
                }
                if (i < fecha_yyyyMMddHHmmss.Length - 8)
                {
                    año_mes = año_mes + fecha_yyyyMMddHHmmss[i];
                }
                if (i < fecha_yyyyMMddHHmmss.Length - 10)
                {
                    año = año + fecha_yyyyMMddHHmmss[i];
                }
            }




            if (modelo == "MODELO_ANALISIS_DATOS")
            {
                if (proceso == "EXISTE_PRODUCTO")
                {
                    // Código correspondiente al caso "EXISTE_PRODUCTO"
                }
                else if (proceso == "EXISTE_CURP_UNIFICADO_COD3_R_")
                {
                    // Código correspondiente al caso "EXISTE_CURP_UNIFICADO_COD3_R_"
                }
                else if (proceso == "EXISTE_CLAVE_LECTOR_UNIFICADO_COD3_R_")
                {
                    // Código correspondiente al caso "EXISTE_CLAVE_LECTOR_UNIFICADO_COD3_R_"
                }
                else if (proceso == "EXISTE_OTRA_IDENTIFICACION_OFICIAL_UNIFICADO_COD3_R_")
                {
                    // Código correspondiente al caso "EXISTE_OTRA_IDENTIFICACION_OFICIAL_UNIFICADO_COD3_R_"
                }




                else
                {
                    // Código correspondiente al caso default
                }
            }
            else if (modelo == "MODELO_COMPRAS")
            {
                if (proceso == "COMPRA")
                {
                    // registro DINERO DIA
                    string res_regist = pr_reg.registrar_compra(G_direcciones_REGISTROS[0], datos, año_mes_dia_hora_minuto_segundo);
                    string[] res_regist_esp = res_regist.Split(G_caracter_para_confirmacion_o_error[0][0]);

                    if (Convert.ToInt32(res_regist_esp[0]) > 0)
                    {
                        if (res_regist_esp[0] == "1")
                        {
                            // registro PRODUCTO dia
                            string res_regist_pr = pr_reg.registrar_movimiento_productos(G_direcciones_REGISTROS[4], modelo, proceso, datos, año_mes_dia_hora_minuto_segundo);
                            string[] res_regist_pr_esp = res_regist_pr.Split(G_caracter_para_confirmacion_o_error[0][0]);



                            // registro dinero
                            pr_reg.registro_incrementar_compra(G_direcciones_REGISTROS[1], res_regist_esp[1], año_mes_dia);//registros del MES
                            pr_reg.registro_incrementar_compra(G_direcciones_REGISTROS[2], res_regist_esp[1], año_mes);//registros del AÑO
                            pr_reg.registro_incrementar_compra(G_direcciones_REGISTROS[3], res_regist_esp[1], año);//registros del TOTAL


                            //modificar historial ranking
                            pr_reg.modificar_historial_ranking(G_direcciones_REGISTROS[5], res_regist_pr_esp[1], año_mes_dia);//
                            pr_reg.modificar_historial_ranking(G_direcciones_REGISTROS[6], res_regist_pr_esp[1], año_mes);
                            pr_reg.modificar_historial_ranking(G_direcciones_REGISTROS[7], res_regist_pr_esp[1], año);


                            // registro productos
                            pr_reg.registro_incrementar_productos(G_direcciones_REGISTROS[5], res_regist_pr_esp[1], año_mes_dia);//registros del MES
                            pr_reg.registro_incrementar_productos(G_direcciones_REGISTROS[6], res_regist_pr_esp[1], año_mes);//registros del AÑO
                            pr_reg.registro_incrementar_productos(G_direcciones_REGISTROS[7], res_regist_pr_esp[1], año);//registros del TOTAL




                            info_a_retornar = res_regist;
                        }
                        else
                        {
                            info_a_retornar = res_regist;
                        }
                    }
                    else
                    {
                        info_a_retornar = res_regist;
                    }
                }
                else if (proceso == "COMPRA_MAYOREO")
                {
                    // Código correspondiente al caso "COMPRA_MAYOREO"
                }
                else if (proceso == "COMPRA_CON_PROMOCION")
                {
                    // Código correspondiente al caso "COMPRA_CON_PROMOCION"
                }
                else if (proceso == "CANCELAR")
                {
                    // Código correspondiente al caso "CANCELAR"
                }
                else
                {
                    // Código correspondiente al caso default
                }
            }
            else if (modelo == "MODELO_VENTAS")
            {
                // registro DINERO DIA

                string res_regist = pr_reg.registrar_venta(G_direcciones_REGISTROS[0], datos, año_mes_dia_hora_minuto_segundo);
                string[] res_regist_esp = res_regist.Split(G_caracter_para_confirmacion_o_error[0][0]);

                if (proceso == "VENTA")
                {
                    if (Convert.ToInt32(res_regist_esp[0]) > 0)
                    {
                        if (res_regist_esp[0] == "1")
                        {
                            // registro PRODUCTO DIA
                            string res_regist_pr = pr_reg.registrar_movimiento_productos(G_direcciones_REGISTROS[4], modelo, proceso, datos, año_mes_dia_hora_minuto_segundo);
                            string[] res_regist_pr_esp = res_regist_pr.Split(G_caracter_para_confirmacion_o_error[0][0]);

                            // registro dinero
                            pr_reg.registro_incrementar_venta(G_direcciones_REGISTROS[1], res_regist_esp[1], año_mes_dia);//registros del MES
                            pr_reg.registro_incrementar_venta(G_direcciones_REGISTROS[2], res_regist_esp[1], año_mes);//registros del AÑO
                            pr_reg.registro_incrementar_venta(G_direcciones_REGISTROS[3], res_regist_esp[1], año);//registros del TOTAL
                            // registro productos
                            pr_reg.registro_incrementar_productos(G_direcciones_REGISTROS[5], res_regist_pr_esp[1], año_mes_dia);//registros del MES
                            pr_reg.registro_incrementar_productos(G_direcciones_REGISTROS[6], res_regist_pr_esp[1], año_mes);//registros del AÑO
                            pr_reg.registro_incrementar_productos(G_direcciones_REGISTROS[7], res_regist_pr_esp[1], año);//registros del TOTAL
                            info_a_retornar = res_regist;
                        }
                        else
                        {
                            info_a_retornar = res_regist;
                        }
                    }
                    else
                    {
                        info_a_retornar = res_regist;
                    }
                }
            }
            else if (modelo == "MODELO_INVENTARIO")
            {
                if (proceso == "AGREGAR")
                {
                    // Código correspondiente al caso "AGREGAR"
                }
                else
                {
                    // Código correspondiente al caso default
                }
            }
            else if (modelo == "MODELO_APRENDICES_E")
            {
                if (proceso == "REGISTRO_APRENDICES_E")
                {
                    // Código correspondiente al caso "REGISTRO_APRENDICES_E"
                }
                else
                {
                    // Código correspondiente al caso default
                }
            }
            else if (modelo == "MODELO_AFILIADOS")
            {
                if (proceso == "INSCRIBIR_UNIFICADO_COD3_R_")
                {
                    // Código correspondiente al caso "INSCRIBIR_UNIFICADO_COD3_R_"
                }
                else if (proceso == "INSCRIBIR_SIMPLE_COD1")
                {
                    // Código correspondiente al caso "INSCRIBIR_SIMPLE_COD1"
                }
                else if (proceso == "INSCRIBIR_COMPLEJO_COD2")
                {
                    // Código correspondiente al caso "INSCRIBIR_COMPLEJO_COD2"
                }
                else
                {
                    // Código correspondiente al caso default
                }
            }
            else if (modelo == "MODELO_PROVEDORES")
            {
                if (proceso == "REGISTRO_PROVEDOR")
                {
                    // Código correspondiente al caso "REGISTRO_PROVEDOR"
                }
                else
                {
                    // Código correspondiente al caso default
                }
            }
            else if (modelo == "MODELO_SUCURSALES")
            {
                if (proceso == "REGISTRO_SUCURSAL")
                {
                    // Código correspondiente al caso "REGISTRO_SUCURSAL"
                }
                else
                {
                    // Código correspondiente al caso default
                }
            }
            else
            {
                // Código correspondiente al caso default
            }


            return info_a_retornar;

        }

    }
}
