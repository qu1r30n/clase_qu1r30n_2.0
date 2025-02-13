using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLASE_QU1R30N_2.sin_internet.sin_formulario.modelos;
using CLASE_QU1R30N_2.sin_internet.sin_formulario.procesos;
using CLASE_QU1R30N_2.sin_internet.sin_formularios;
using CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas;


namespace CLASE_QU1R30N_2.sin_internet.sin_formularios
{
    internal class principal
    {


        
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        
        string[] G_caracter_para_enter = var_fun_GG.GG_caracter_para_usar_como_enter_y_nuevo_mensaje;

        

        // Función para manejar compras
        
        public string enlasador(string INFO_ENTRADA)
        {
            //ejemplo dato entrada: "analisis_datos~existe_producto§codigo"
            INFO_ENTRADA = INFO_ENTRADA.ToUpper();

            string info_a_retornar = null;

            string[] a_donde_enviara_la_informacion = INFO_ENTRADA.Split(G_caracter_separacion_funciones_espesificas[0][0]);
            

            string modelo = a_donde_enviara_la_informacion[0];
            string info = a_donde_enviara_la_informacion[1];

            if (modelo == "MODELO_INICIAL_PRUEBA")
            {
                _00_mod_inicial mod_inicial = new _00_mod_inicial();
                info_a_retornar = mod_inicial.operacion_a_hacer(info);
            }
            else if (modelo == "TEX_BASE")
            {
                _01_mod_tex_base mod_tex_base = new _01_mod_tex_base();
                info_a_retornar = mod_tex_base.operacion_a_hacer(info);
            }

            else if (modelo == "MODELO_PRODUCTOS_E_INVENTARIO")
            {
                _02_mod_productos_e_inventario mod_prod_inv = new _02_mod_productos_e_inventario();
                info_a_retornar = mod_prod_inv.operacion_a_hacer(info);
            }

            else if (modelo == "MODELO_NEGOCIOS")
            {
                _03_mod_negocios mod_neg = new _03_mod_negocios();
                info_a_retornar = mod_neg.operacion_a_hacer(info);
            }

            else if (modelo == "MOSTRAR_MODELOS")
            {
                info_a_retornar = mostrar_modelos();
            }

            return info_a_retornar;
        }

        public string mostrar_modelos()
        {
            string info_a_retornar = "";


            info_a_retornar =
                "MODELO_INICIAL_PRUEBA"
                + G_caracter_para_enter[0] +
                "TEX_BASE";


            return info_a_retornar;
        }


        //fin clase-------------------------------------------------------------
    }
}
