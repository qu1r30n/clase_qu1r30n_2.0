using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas;

using CLASE_QU1R30N_2.sin_internet.sin_formulario.modelos.sub_modelo;
using CLASE_QU1R30N_2.sin_internet.sin_formulario.procesos;

namespace CLASE_QU1R30N_2.sin_internet.sin_formulario.modelos
{
    internal class _03_mod_negocios
    {
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;
        string[] G_caracter_para_enter = var_fun_GG.GG_caracter_para_usar_como_enter_y_nuevo_mensaje;


        public string operacion_a_hacer(string info)
        {
            string info_a_retornar = null;


            string[] datos_spliteados = info.Split(G_caracter_separacion_funciones_espesificas[1][0]);
            string proceso = datos_spliteados[0];
            string datos = datos_spliteados[1];

            

            if (proceso == "TIENDA")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"
                _03_sub_mod_negocio_tienda sub_mod_tienda = new _03_sub_mod_negocio_tienda();
                info_a_retornar = EjecutarFuncionEnDatos_SUB_MODELO(sub_mod_tienda.operacion_a_hacer, datos);
            }
            else if (proceso == "RESTAURANTE")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"
                _03_sub_mod_negocio_restaurante sub_mod_restaurante = new _03_sub_mod_negocio_restaurante();
                info_a_retornar = EjecutarFuncionEnDatos_SUB_MODELO(sub_mod_restaurante.operacion_a_hacer, datos);
            }

            else if (proceso == "VENTAS")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"
                _03_proc_negocios proc_neg= new _03_proc_negocios();
                info_a_retornar = EjecutarFuncionEnDatos(proc_neg.ventas, datos);
            }


            return info_a_retornar;
        }

        private string EjecutarFuncionEnDatos_SUB_MODELO(Func<string, string> funcion, string datos)
        {
            string info_a_retornar = null;

            info_a_retornar = funcion(datos);
            

            return info_a_retornar;
        }

        private string EjecutarFuncionEnDatos(Func<string, string> funcion, string datos)
        {
            string info_a_retornar = null;
            string[] cant_datos = datos.Split(G_caracter_separacion_funciones_espesificas[2][0]);
            for (int i = 0; i < cant_datos.Length; i++)
            {
                // Llamar a un método `funcion_prueba` de la clase `_00_proc_inicial`
                info_a_retornar = funcion(cant_datos[i]);
            }

            return info_a_retornar;
        }


        public string mostrar_procesos()
        {
            string info_a_retornar = "";


            info_a_retornar =
                "TIENDA" + G_caracter_para_enter[0] +
                "  EXTRAER_INVENTARIO" + G_caracter_para_enter[0] +


                "RESTAURANTE" + G_caracter_para_enter[0] +
                "  EXTRAER_INVENTARIO" + G_caracter_para_enter[0] 



            ;




            return info_a_retornar;
        }



        //fin clase--------------------------------------------------------
    }
}
