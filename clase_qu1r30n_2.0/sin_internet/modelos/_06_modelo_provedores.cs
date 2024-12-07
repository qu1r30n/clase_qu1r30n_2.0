using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;
using clase_qu1r30n_2._0.sin_internet.sin_formularios.procesos;



namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.modelos
{
    internal class _06_modelo_provedores
    {

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;

        string[] G_direcciones =
        {
            /*0*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[2, 0],//"config\\inf\\dat\\provedores.TXT",
        };

        operaciones_arreglos op_arr = new operaciones_arreglos();
        operaciones_textos op_tex = new operaciones_textos();



        _06_proceso_provedores pr_provedores = new _06_proceso_provedores();
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



            string[] info_espliteada = datos.Split(G_caracter_separacion[0][0]);

            switch (proceso)
            {
                case "REGISTRO_PROVEDOR":
                    string VAR_1_NOMBRE_EMPRESA = info_espliteada[0];
                    string VAR_2_NOMBRE_ENCARGADO = info_espliteada[1];
                    string VAR_3_DIRECCIÓN_EMPRESA = info_espliteada[2];
                    string VAR_4_CIUDAD_EMPRESA = info_espliteada[3];
                    string VAR_5_ESTADO_EMPRESA = info_espliteada[4];
                    string VAR_6_CÓDIGO_POSTAL = info_espliteada[5];
                    string VAR_7_PAÍS = info_espliteada[6];
                    string VAR_8_CORREO_ELECTRÓNICO = info_espliteada[7];
                    string VAR_9_TELÉFONO_ENCARGADO = info_espliteada[8];
                    string VAR_10_TELEFONO_EMPRESA = info_espliteada[9];
                    string VAR_11_TIPO_DE_PROVEEDOR = info_espliteada[10];
                    string VAR_12_PRODUCTOS_SERVICIOS_SUMINISTRADOS = info_espliteada[11];
                    string VAR_13_CUENTA_BANCO = info_espliteada[12];
                    string VAR_14_UBICACIÓN_GPS = info_espliteada[13];
                    string VAR_15_NOTAS = info_espliteada[14];
                    string VAR_16_RECORDATORIO = info_espliteada[15];
                    string VAR_17_ACTIVO_O_NO_ACTIVO = info_espliteada[16];
                    string VAR_18_CALIFICACION_PREVENTA_0C_CALIFICACION_ENTREGA_0 = info_espliteada[17];
                    string VAR_19_COMENTARIOS_PREVENTA_ENTREGA = info_espliteada[18];
                    string VAR_20_SUCURSALES_QUE_LE_COMPRAN = info_espliteada[19];
                    string VAR_21_DINERO_A_COMPRARLE = info_espliteada[20];
                    string VAR_22_DIAS_DE_PREVENTA_0_DIAS_DE_PREVENTA_1 = info_espliteada[21];
                    string VAR_23_DIAS_DE_ENTREGA_0_DIAS_DE_ENTREGA_1 = info_espliteada[22];

                    pr_provedores.registro_provedores_cod3_r_(G_direcciones[0], datos);

                    break;

                case "EXTRAER_NOM_PROVEDORES":
                    info_a_retornar = pr_provedores.extraer_nombre_provedores(G_direcciones[0], datos);
                    break;

                case "EXTRAER_NOM_PROVEDORES_Y_DINERO":
                    info_a_retornar = pr_provedores.extraer_nombre_provedores_y_dinero(G_direcciones[0], datos);
                    break;



                default:
                    info_a_retornar = "-3" + G_caracter_para_confirmacion_o_error[0] + "no existe ese PROCESO";
                    break;
            }

            return info_a_retornar;

        }

    }
}
