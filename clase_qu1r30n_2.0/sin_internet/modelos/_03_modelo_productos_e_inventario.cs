using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;
using clase_qu1r30n_2._0.sin_internet.sin_formularios.procesos;

namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.modelos
{
    internal class _03_modelo_productos_e_inventario
    {
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;


        string[] G_direcciones =
        {
            /*0*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[1, 0],//"config\\tienda\\inf\\inventario\\inventario.TXT",
        };

        Tex_base bas = new Tex_base();

        _03_proceso_productos_e_inventario proc_inventario = new _03_proceso_productos_e_inventario();
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

            string[] res_ind_ar = null;
            int indice = -1;

            switch (proceso)
            {
                case "AGREGAR_SINO_EXISTE":

                    res_ind_ar = bas.sacar_indice_del_arreglo_de_direccion(G_direcciones[0]).Split(G_caracter_para_confirmacion_o_error[0][0]);
                    indice = Convert.ToInt32(res_ind_ar[1]);
                    if (datos != "")
                    {
                        info_a_retornar = proc_inventario.agrega_si_no_existe(G_direcciones[indice], datos);
                    }



                    break;

                case "AGREGAR":

                    res_ind_ar = bas.sacar_indice_del_arreglo_de_direccion(G_direcciones[0]).Split(G_caracter_para_confirmacion_o_error[0][0]);
                    indice = Convert.ToInt32(res_ind_ar[1]);
                    info_a_retornar = proc_inventario.agregar_producto(G_direcciones[indice], datos);

                    break;


                case "BUSCAR":

                    if (info_espliteada.Length > 1)
                    {
                        info_a_retornar = proc_inventario.buscar(G_direcciones[0], info_espliteada[0], info_espliteada[1]);
                    }
                    else
                    {
                        info_a_retornar = proc_inventario.buscar(G_direcciones[0], info_espliteada[0]);
                    }

                    break;

                case "EXTRAER_INVENTARIO_STRING":

                    res_ind_ar = bas.sacar_indice_del_arreglo_de_direccion(G_direcciones[0]).Split(G_caracter_para_confirmacion_o_error[0][0]);
                    indice = Convert.ToInt32(res_ind_ar[1]);
                    info_a_retornar = proc_inventario.dar_el_inventario_string_caracter_sep(Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[indice, 0]);

                    break;

                case "CREAR_ARCHIVOS_HACER_INVENT":

                    proc_inventario.archivos_inicio_hacer_inventario();

                    break;

                case "HACER_INVENTARIO":

                    info_a_retornar = proc_inventario.hacer_inventario(datos, año_mes_dia);

                    break;



                default:
                    info_a_retornar = "-1" + G_caracter_para_confirmacion_o_error[0] + "no existe ese PROCESO";
                    break;
            }

            return info_a_retornar;
        }


    }
}
