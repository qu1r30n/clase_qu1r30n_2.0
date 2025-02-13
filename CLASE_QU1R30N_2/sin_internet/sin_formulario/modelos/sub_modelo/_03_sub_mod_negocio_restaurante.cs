﻿using CLASE_QU1R30N_2.sin_internet.sin_formulario.procesos._03_proc_sub_mod_negocio;
using CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE_QU1R30N_2.sin_internet.sin_formulario.modelos.sub_modelo
{
    internal class _03_sub_mod_negocio_restaurante
    {
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;
        string[] G_caracter_para_enter = var_fun_GG.GG_caracter_para_usar_como_enter_y_nuevo_mensaje;


        public string operacion_a_hacer(string info)
        {
            string info_a_retornar = null;


            string[] datos_spliteados = info.Split(G_caracter_separacion_funciones_espesificas[3][0]);
            string proceso = datos_spliteados[0];
            string datos = datos_spliteados[1];

            _03_proc_sub_mod_tienda proc_tienda = new _03_proc_sub_mod_tienda();

            if (proceso == "EXTRAER_INVENTARIO")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(proc_tienda.extraer_inventario, datos);
            }

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

                "extraer_inventario" + G_caracter_para_enter[0] +
                    "*direccion_archivo" + G_caracter_para_enter[0] +
                    "valor_inicial" + G_caracter_para_enter[0] +
                    "filas_iniciales" 

            ;




            return info_a_retornar;
        }

    }
}
