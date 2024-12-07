using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;
using clase_qu1r30n_2._0.sin_internet.sin_formularios.procesos;


namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.modelos
{
    internal class _05_modelo_afiliados
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

        };



        _05_proceso_afiliados pr_afil = new _05_proceso_afiliados();
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
                //usables-----------------------------------------------------------------------------------

                case "INSCRIBIR_UNIFICADO_COD3_R_":
                    //0_id_enc_simp|1_tabla_enc_simple|2_datos
                    //4|afiliados_simple|nom_pru°ap_pat_pru°ape_mat_pru°0°banco°curp°0000000000°direccion°colonia°municiopio°estado°correo@correo.com
                    //datos//nombre°apellido_paterno°apellido_materno°numero_cuenta°banco°curp°numero_celular°direccion°colonia°municiopio°estado°correo                    
                    info_a_retornar = pr_afil.registro_unificado_cod3_r_(G_direcciones[5], G_direcciones[6], info_espliteada[0], info_espliteada[1], info_espliteada[2]);

                    break;

                //no usables--------------------------------------------------------------------------
                /* REGISTROS
                case "INSCRIBIR_SIMPLE_COD1":
                    //0_id_enc_simp|1_tabla_enc_simple|2_datos
                    //4|afiliados_simple|nom_pru°ap_pat_pru°ape_mat_pru°0°banco°curp°0000000000°direccion°colonia°municiopio°estado°correo@correo.com
                    //datos//nombre°apellido_paterno°apellido_materno°numero_cuenta°banco°curp°numero_celular°direccion°colonia°municiopio°estado°correo                    
                    info_a_retornar = pr_afil.registro_simple_cod1(G_direcciones[1], G_direcciones[2], info_espliteada[0], info_espliteada[1], info_espliteada[2]);

                    break;

                case "INSCRIBIR_COMPLEJO_COD2":
                    //0_id_enc_simp|1_tabla_enc_simple|2_datos
                    //4|afiliados_complejo|4|afiliados_simple|nom_pru°ap_pat_pru°ape_mat_pru°0°banco°curp°0000000000°direccion°colonia°municiopio°estado°correo@correo.com
                    //datos//nombre°apellido_paterno°apellido_materno°numero_cuenta°banco°curp°numero_celular°direccion°colonia°municiopio°estado°correo
                    info_a_retornar = pr_afil.registro_complejo_cod2(G_direcciones[1], G_direcciones[2], info_espliteada[0], info_espliteada[1], info_espliteada[2], info_espliteada[3], info_espliteada[4]);

                    break;
                    */               
                //------------------------------------------------------------------------------------
                
                default:
                    info_a_retornar = "-1" + G_caracter_para_confirmacion_o_error[0] + "no existe ese PROCESO";
                    break;
            }

            return info_a_retornar;

        }
    }
}
