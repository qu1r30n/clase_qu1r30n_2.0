using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;
using clase_qu1r30n_2._0.sin_internet.sin_formularios.procesos;

namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.modelos
{
    internal class _00_modelo_AnalisisDeDatos
    {
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;

        string[] G_direcciones =
        {
            /*0*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[1, 0],//"config\\tienda\\inf\\inventario\\inventario.TXT",
            /*1*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[4,0],//"config\\afiliados\\afiliados_simple.TXT",
            /*2*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[6,0],//"config\\afiliados\\niveles_e_id_horisontal_afiliados_simple.TXT",
            /*3*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[5,0],//"config\\afiliados\\afiliados_complejo.TXT",
            /*4*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[7,0],//"config\\afiliados\\niveles_e_id_horisontal_afiliados_complejo.TXT",
            /*5*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[8,0],//"config\\afiliados\\afiliados_unificado.TXT",
            /*6*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[9,0],//"config\\afiliados\\niveles_e_id_horisontal_afiliados_unificado.TXT",
            /*7*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[14,0],//CONFIG\\INF\\REGISTROS\\ACUMULADO_REGISTRO.TXT
            /*8*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[18,0],//CONFIG\\INF\\REGISTROS\\ACUMULADO_PRODUC_REGISTRO.TXT



        };


        _00_proceso_AnalisisDeDatos pr_an_dat = new _00_proceso_AnalisisDeDatos();
        public string operacion_a_hacer(string proceso, string datos, string fecha_hora)
        {
            string info_a_retornar = null;

            string año_mes_dia_hora_minuto_segundo = fecha_hora;
            string año_mes_dia_hora_minuto = "";
            string año_mes_dia_hora = "";
            string año_mes_dia = "";
            string año_mes = "";
            string año = "";

            for (int i = 0; i < fecha_hora.Length; i++)
            {
                if (i < fecha_hora.Length - 2)
                {
                    año_mes_dia_hora_minuto = año_mes_dia_hora_minuto + fecha_hora[i];
                }
                if (i < fecha_hora.Length - 4)
                {
                    año_mes_dia_hora = año_mes_dia_hora + fecha_hora[i];
                }
                if (i < fecha_hora.Length - 6)
                {
                    año_mes_dia = año_mes_dia + fecha_hora[i];
                }
                if (i < fecha_hora.Length - 8)
                {
                    año_mes = año_mes + fecha_hora[i];
                }
                if (i < fecha_hora.Length - 10)
                {
                    año = año + fecha_hora[i];
                }
            }



            string[] datos_spliteados = datos.Split(G_caracter_separacion[0][0]);

            switch (proceso)
            {
                case "EXISTE_PRODUCTO":
                    info_a_retornar = pr_an_dat.existe_informacion(G_direcciones[0], datos_spliteados[0], "5");
                    break;

                case "EXISTE_CURP_UNIFICADO_COD3_R_":
                    info_a_retornar = pr_an_dat.existe_informacion(G_direcciones[5], datos_spliteados[0], "4|4");
                    break;

                case "EXISTE_CLAVE_LECTOR_UNIFICADO_COD3_R_":
                    info_a_retornar = pr_an_dat.existe_informacion(G_direcciones[5], datos_spliteados[0], "4|5");
                    break;
                case "EXISTE_OTRA_IDENTIFICACION_OFICIAL_UNIFICADO_COD3_R_":
                    info_a_retornar = pr_an_dat.existe_informacion(G_direcciones[5], datos_spliteados[0], "4|6");
                    break;

                case "PREDICCION_NECESIDADES_COMPRA":


                    info_a_retornar = pr_an_dat.prediccion_archivo_compra(G_direcciones[8], 4, 5, 6, 7);

                    break;



                default:
                    info_a_retornar = "-1" + G_caracter_para_confirmacion_o_error[0] + "no existe ese PROCESO";
                    break;
            }
            return info_a_retornar;
        }
    }
}
