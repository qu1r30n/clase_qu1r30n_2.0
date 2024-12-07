using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;
using clase_qu1r30n_2._0.sin_internet.sin_formularios.procesos;

namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.modelos
{
    internal class _11_modelo_intermediario_acendente
    {
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;

        _11_proceso_intermediario_acendente pr_int_ace = new _11_proceso_intermediario_acendente();

        string[] G_direcciones =
        {
            //direccion_archivo//Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[1, 0]//"config\\inf\\inventario\\inventario.TXT",
        };

        public string operacion_a_hacer(string proceso, string datos, string fecha_hora)
        {
            string info_a_retornar = null;

            string[] cant_datos = datos.Split(G_caracter_separacion[1][0]);


            for (int i = 0; i < cant_datos.Length; i++)
            {
                string[] info_espliteada = cant_datos[i].Split(G_caracter_separacion[2][0]);
                
                switch (proceso)
                {
                    case "AGREGAR_PRODUCTO_SERVICIO":
                            pr_int_ace.agregar_producto_servicio(info_espliteada);
                        break;

                    case "VENTA_PRODUCTO_SERVICIO":
                            pr_int_ace.venta_producto_servicio(info_espliteada);
                        break;

                    case "INVENTARIO_COMPLETO":
                        pr_int_ace.obtenerInventarioCompleto(info_espliteada);
                        break;

                    case "PONER_IMAGEN_A_PRODUCTO":
                        pr_int_ace.poner_imagen_a_producto(info_espliteada);
                        break;


                    default:

                        info_a_retornar = "-1" + G_caracter_para_confirmacion_o_error[0] + "no existe ese PROCESO";
                        break;
                }

            }
            return info_a_retornar;
        }

    }
}
