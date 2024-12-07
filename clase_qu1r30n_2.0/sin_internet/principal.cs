using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using clase_qu1r30n_2._0.sin_internet.sin_formularios;
using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;
using clase_qu1r30n_2._0.sin_internet.sin_formularios.modelos;

namespace clase_qu1r30n_2._0.sin_internet.sin_formularios
{
    internal class principal
    {
        _00_modelo_AnalisisDeDatos mod_an_dat = new _00_modelo_AnalisisDeDatos();
        _01_modelo_compras mod_comp = new _01_modelo_compras();
        _02_modelo_ventas mod_vent = new _02_modelo_ventas();
        _03_modelo_productos_e_inventario mod_pro_inv = new _03_modelo_productos_e_inventario();
        _04_modelo_aprendices_E mod_apr_E = new _04_modelo_aprendices_E();
        _05_modelo_afiliados mod_afil = new _05_modelo_afiliados();
        _06_modelo_provedores mod_pro = new _06_modelo_provedores();
        _07_modelo_sucursales mod_suc = new _07_modelo_sucursales();
        _08_modelo_registros mod_reg = new _08_modelo_registros();
        _09_modelo_funciones_diversas mod_fun_div = new _09_modelo_funciones_diversas();
        _10_modelo_mul mod_mul = new _10_modelo_mul();
        _11_modelo_intermediario_acendente mod_int = new _11_modelo_intermediario_acendente();
        _12_modelo_publicidad mod_pub = new _12_modelo_publicidad();

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;

        var_fun_GG vf_GG = new var_fun_GG();

        // Función para manejar compras
        public string enlasador(string INFO_ENTRADA)
        {
            //ejemplo dato entrada: "analisis_datos~existe_producto§codigo"
            INFO_ENTRADA = INFO_ENTRADA.ToUpper();

            string info_a_retornar = null;

            string[] a_donde_enviara_la_informacion = INFO_ENTRADA.Split(G_caracter_separacion_funciones_espesificas[0][0]);
            string[] datos_spliteados = a_donde_enviara_la_informacion[1].Split(G_caracter_separacion_funciones_espesificas[1][0]);

            string modelo = a_donde_enviara_la_informacion[0];
            string proceso = datos_spliteados[0];
            string datos = datos_spliteados[1];
            string yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");



            switch (modelo)
            {
                case "MODELO_ANALISIS_DATOS":
                    //"existe_producto§codigo"
                    info_a_retornar = mod_an_dat.operacion_a_hacer(proceso, datos, yyyyMMddHHmmss);
                    break;
                case "MODELO_COMPRAS":
                    info_a_retornar = mod_comp.operacion_a_hacer(proceso, datos, yyyyMMddHHmmss);
                    break;
                case "MODELO_VENTAS":
                    info_a_retornar = mod_vent.operacion_a_hacer(proceso, datos, yyyyMMddHHmmss);
                    break;
                case "MODELO_PRODUCTOS_E_INVENTARIO":
                    info_a_retornar = mod_pro_inv.operacion_a_hacer(proceso, datos, yyyyMMddHHmmss);
                    break;
                case "MODELO_APRENDICES_E":
                    info_a_retornar = mod_apr_E.operacion_a_hacer(proceso, datos, yyyyMMddHHmmss);
                    break;
                case "MODELO_AFILIADOS":
                    //inscribir_simple§4|afiliados_simple|nom_pru°ap_pat_pru°ape_mat_pru°0°banco°curp°0000000000°direccion°colonia°municiopio°estado°correo@correo.com
                    info_a_retornar = mod_afil.operacion_a_hacer(proceso, datos, yyyyMMddHHmmss);
                    break;
                case "MODELO_PROVEDORES":

                    info_a_retornar = mod_pro.operacion_a_hacer(proceso, datos, yyyyMMddHHmmss);
                    break;
                case "MODELO_SUCURSALES":

                    info_a_retornar = mod_suc.operacion_a_hacer(proceso, datos, yyyyMMddHHmmss);
                    break;

                case "MODELO_FUNCIONES_DIVERSAS":

                    info_a_retornar = mod_fun_div.operacion_a_hacer(proceso, datos, yyyyMMddHHmmss);
                    break;

                case "MODELO_MUL":

                    info_a_retornar = mod_mul.operacion_a_hacer(proceso, datos, yyyyMMddHHmmss);
                    break;

                case "MODELO_INT_ACEN":

                    info_a_retornar = mod_int.operacion_a_hacer(proceso, datos, yyyyMMddHHmmss);
                    break;

                case "MODELO_PUB":

                    info_a_retornar = mod_pub.operacion_a_hacer(proceso, datos, yyyyMMddHHmmss);
                    break;

            }


            mod_reg.registro_movimiento(modelo, proceso, datos, yyyyMMddHHmmss);

            return info_a_retornar;

        }


    }
}
