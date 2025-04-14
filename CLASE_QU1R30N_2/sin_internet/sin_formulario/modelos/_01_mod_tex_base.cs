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
        string[] G_caracter_para_enter = var_fun_GG.GG_caracter_para_usar_como_enter_y_nuevo_mensaje;



        public string operacion_a_hacer(string info)
        {
            // Variable para almacenar la información que se devolverá al final del método
            string info_a_retornar = null;

            string[] datos_spliteados = info.Split(G_caracter_separacion_funciones_espesificas[1][0]);
            string proceso = datos_spliteados[0];
            string datos = datos_spliteados[1];

            _01_proc_tex_base bas = new _01_proc_tex_base();

            // Seleccionar el flujo de operación basado en el valor del parámetro `proceso`
            if (proceso == "FUNCION_PRUEBA")
            {
                // Caso específico para un proceso llamado "FUNCION_PRUEBA"
                _00_proc_inicial fun = new _00_proc_inicial();
                info_a_retornar = EjecutarFuncionEnDatos(fun.funcion_prueba, datos);
            }

            else if (proceso == "CREAR_ARCHIVO")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.Crear_archivo_y_directorio, datos);
            }
            else if (proceso == "AGREGAR_USO_SOLO_PROG")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.Agregar_solo_prog, datos);
            }
            else if (proceso == "AGREGAR_SINO_EXISTE_SOLO_PROG")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.Agregar_sino_existe_solo_prog, datos);
            }
            else if (proceso == "AGREGAR_SINO_EXISTE_INFO_DIV")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.Agregar_sino_existe_info_dividida, datos);
            }
            else if (proceso == "AGREGAR_INFO_DIV")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.Agregar_info_dividida, datos);
            }
            else if (proceso == "LEER_SOLO_PROG")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.LEER_SOLO_PROG, datos);

            }
            else if (proceso == "LEER_INFO_DIVIDIDA")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.LEER_INFO_DIVIDIDA, datos);

            }
            else if (proceso == "SELECCIONAR_ID_INFO_DIVIDIDA")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.seleccionar_id_info_dividida, datos);

            }

            else if (proceso == "SELECCIONAR_ID_INFO_DIVIDIDA_EXTRAE_INFO_ARCHIVO_Y_FILA")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.seleccionar_id_info_dividida_extrae_info_archivo_y_fila, datos);
            }

            else if (proceso == "INCREMENTA_CELDA_ID_FILA_SOLO_PROG")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.INCREMENTA_CELDA_ID_FILA_SOLO_PROG, datos);

            }

            else if (proceso == "INCREMENTA_CELDA_ID_INFO_DIVIDIDA")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.INCREMENTA_CELDA_ID_INFO_DIVIDIDA, datos);

            }

            else if (proceso == "EDITAR_CELDA_ID_FILA_SOLO_PROG")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.EDITAR_CELDA_ID_FILA_SOLO_PROG, datos);

            }

            else if (proceso == "EDITAR_CELDA_ID_INFO_DIVIDIDA")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.EDITAR_CELDA_ID_INFO_DIVIDIDA, datos);

            }


            else if (proceso == "INCREMENTA_CELDA_BUSQUEDA_INFO_DIVIDIDA")
            {


                info_a_retornar = EjecutarFuncionEnDatos(bas.INCREMENTA_CELDA_BUSQUEDA_INFO_DIVIDIDA, datos);

            }

            else if (proceso == "ELIMINAR_FILA_PARA_MULTIPLES_PROGRAMAS_SOLO_PROG")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.ELIMINAR_FILA_PARA_MULTIPLES_PROGRAMAS_SOLO_PROG, datos);

            }
            else if (proceso == "EDITAR_FILA_ESPESIFICA_SIN_ARREGLO_GG_SOLO_PROG")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.EDITAR_FILA_ESPESIFICA_SIN_ARREGLO_GG_SOLO_PROG, datos);


            }
            else if (proceso == "EXTRAER_SEPARADO_CARPETAS_NOMBREARCHIVO_EXTENCION_SOLO_PROG")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.EXTRAER_SEPARADO_CARPETAS_NOMBREARCHIVO_EXTENCION_SOLO_PROG, datos);

            }
            else if (proceso == "SACAR_INDICE_DEL_ARREGLO_DE_DIRECCION_SOLO_PROG")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.SACAR_INDICE_DEL_ARREGLO_DE_DIRECCION_SOLO_PROG, datos);

            }

            else if (proceso == "EDITAR_INCR_O_AGREGA_COMPARACION_YY_INFO_DENTRO_DE_CELDA_Y_AGREGA_FILA_SI_NO_ESTA_Y_NO_ES_VACIA_LA_VARIABLE_ES_MULTIPLE_CON_COMPARACION_FINAL_BUSQUEDA_ID")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.SOLO_PROG_Editar_incr_o_agrega_COMPARACION_YY_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID, datos);

            }

            else if (proceso == "EDITAR_INCR_O_AGREGA_INFO_DENTRO_DE_CELDA_Y_AGREGA_FILA_SI_NO_ESTA_Y_NO_ES_VACIA_LA_VARIABLE_ES_MULTIPLE_CON_COMPARACION_FINAL_BUSQUEDA_ID")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.SOLO_PROG_Editar_incr_o_agrega_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID, datos);

            }

            else if (proceso == "EDITAR_INCR_O_AGREGA_MULTIPLESCOMPARACIONES_AL_FINAL_INFO_DENTRO_DE_CELDA_Y_AGREGA_FILA_SI_NO_ESTA_Y_NO_ES_VACIA_LA_VARIABLE_BUSQUEDA_ID")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.SOLO_PROG_Editar_incr_o_agrega_MULTIPLESCOMPARACIONES_AL_FINAL_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_BUSQUEDA_ID, datos);

            }

            else if (proceso == "BUSCAR_SOLO_PROG")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.BUSCAR_SOLO_PROG, datos);

            }

            else if (proceso == "BUSCAR_INFO_DIVIDIDA")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.BUSCAR_INFO_DIVIDIDA, datos);

            }



            else if (proceso == "GENERAR_RUTA_ARCHIVO")
            {
                // Caso específico para un proceso llamado "CREAR_ARCHIVO"

                info_a_retornar = EjecutarFuncionEnDatos(bas.GENERAR_RUTA_ARCHIVO, datos);

            }

            else if (proceso == "MOSTRAR_PROCESOS")
            {

                info_a_retornar = mostrar_procesos();

            }
            else
            {
                // Caso por defecto si no se reconoce el proceso
                // Asignar un mensaje de error indicando que el proceso no existe
                info_a_retornar = "-1" + G_caracter_para_confirmacion_o_error[0] + "no existe ese PROCESO";
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

        public string mostrar_procesos()
        {
            string info_a_retornar = "";


            info_a_retornar =
                "FUNCION_PRUEBA" +

                G_caracter_para_enter[1] + "CREAR_ARCHIVO" + G_caracter_para_enter[0] +
                    "*direccion_archivo" + G_caracter_para_enter[0] +
                    "valor_inicial" + G_caracter_para_enter[0] +
                    "filas_iniciales" +


                G_caracter_para_enter[1] + "AGREGAR_INFO_DIV" + G_caracter_para_enter[0] +
                "  *direccion_archivos" + G_caracter_para_enter[0] +
                "  *agregando" + G_caracter_para_enter[0] +
                "  *nom_columnas_si_no_existe_archivo" +



                G_caracter_para_enter[1] + "AGREGAR_USO_SOLO_PROG" + G_caracter_para_enter[0] +
                    "*direccion_archivos" + G_caracter_para_enter[0] +
                    "*agregando" +

                    G_caracter_para_enter[1] + "AGREGAR_USO_SOLO_PROG" + G_caracter_para_enter[0] +
                    "*direccion_archivos" + G_caracter_para_enter[0] +
                    "*num_column_comp" + G_caracter_para_enter[0] +
                    "*comparar" + G_caracter_para_enter[0] +
                    "*texto_a_agregar_si_no_esta" + G_caracter_para_enter[0] +
                    "caracter_separacion_obj" +

                    G_caracter_para_enter[1] + "AGREGAR_SINO_EXISTE_INFO_DIV" + G_caracter_para_enter[0] +
                    "*direccion_archivos" + G_caracter_para_enter[0] +
                    "*num_column_comp" + G_caracter_para_enter[0] +
                    "comparar" + G_caracter_para_enter[0] +
                    "texto_a_agregar_si_no_esta" + G_caracter_para_enter[0] +
                    "caracter_separacion_obj" +

                G_caracter_para_enter[1] + "LEER_SOLO_PROG" + G_caracter_para_enter[0] +
                    "*direccion_archivo" + G_caracter_para_enter[0] +
                    "pos_string" + G_caracter_para_enter[0] +
                    "caracter_separacion" +

                G_caracter_para_enter[1] + "LEER_INFO_DIVIDIDA" + G_caracter_para_enter[0] +
                    "*direccion_archivo" +

                    G_caracter_para_enter[1] + "SELECCIONAR_ID_INFO_DIVIDIDA" + G_caracter_para_enter[0] +
                    "*direccion_archivos" + G_caracter_para_enter[0] +
                    "*id" + G_caracter_para_enter[0] +
                    "info_a_comparar" + G_caracter_para_enter[0] +
                    "columna_comparar" +


                    G_caracter_para_enter[1] + "ELIMINAR_FILA_PARA_MULTIPLES_PROGRAMAS_SOLO_PROG" + G_caracter_para_enter[0] +
                    "*direccion_archivo" + G_caracter_para_enter[0] +
                    "*columna_a_comparar" + G_caracter_para_enter[0] +
                    "*comparar" + G_caracter_para_enter[0] +
                    "caracter_separacion_objeto" + G_caracter_para_enter[0] +
                    "donde_inica" +

                    G_caracter_para_enter[1] + "EDITAR_FILA_ESPESIFICA_SIN_ARREGLO_GG_SOLO_PROG" + G_caracter_para_enter[0] +
                    "*direccion_archivo" + G_caracter_para_enter[0] +
                    "num_fila" + G_caracter_para_enter[0] +
                    "editar_info"+

                    G_caracter_para_enter[1] + "EXTRAER_SEPARADO_CARPETAS_NOMBREARCHIVO_EXTENCION_SOLO_PROG" + G_caracter_para_enter[0] +
                    "*direccion_archivo" +

                    G_caracter_para_enter[1] + "GENERAR_RUTA_ARCHIVO" + G_caracter_para_enter[0] +
                    "*id" + G_caracter_para_enter[0] +
                    "cantidad_ids_por_archivo_potenciade10"


            ;




            return info_a_retornar;
        }


        //fin clase----------------------------------------------------
    }
}
