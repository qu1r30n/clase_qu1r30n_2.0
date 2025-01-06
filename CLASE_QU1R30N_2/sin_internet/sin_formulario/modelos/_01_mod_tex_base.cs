using CLASE_QU1R30N_2.sin_internet.sin_formulario.procesos;
using CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE_QU1R30N_2.sin_internet.sin_formulario.modelos
{
    internal class _01_mod_tex_base
    {

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;


        
        public string operacion_a_hacer(string info)
        {
            // Variable para almacenar la información que se devolverá al final del método
            string info_a_retornar = null;

            string[] datos_spliteados = info.Split(G_caracter_separacion_funciones_espesificas[1][0]);
            string proceso = datos_spliteados[0];
            string datos = datos_spliteados[1];



            // Seleccionar el flujo de operación basado en el valor del parámetro `proceso`
            switch (proceso)
            {
                // Caso específico para un proceso llamado "FUNCION_PRUEBA"
                case "FUNCION_PRUEBA":

                    _00_proc_inicial fun = new _00_proc_inicial();
                    EjecutarFuncionEnDatos(fun.funcion_prueba, datos);

                    break;

                // Caso específico para un proceso llamado "FUNCION_PRUEBA"
                case "CREAR_ARCHIVO":

                    _01_proc_tex_base tex_base = new _01_proc_tex_base();
                    EjecutarFuncionEnDatos(tex_base.Crear_archivo_y_directorio, datos);

                    break;

                    
                // Caso por defecto si no se reconoce el proceso
                default:
                    // Asignar un mensaje de error indicando que el proceso no existe
                    info_a_retornar = "-1" + G_caracter_para_confirmacion_o_error[0] + "no existe ese PROCESO";
                    break;
            }


            // Devolver la información procesada o el mensaje de error
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



        //fin clase----------------------------------------------------
    }
}
