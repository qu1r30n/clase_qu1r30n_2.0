﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using CLASE_QU1R30N_2.sin_internet.sin_formularios;
using CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas;

namespace CLASE_QU1R30N_2.conexion.herramientas_internet
{
    internal class conexiones
    {

        public string[] G_dir_arch_transferencia =
        {
            var_fun_GG_dir_arch_crear.GG_dir_arch_transferencia[0,0],
            var_fun_GG_dir_arch_crear.GG_dir_arch_transferencia[1,0],
            var_fun_GG_dir_arch_crear.GG_dir_arch_transferencia[2,0],
        };



        operaciones_arreglos op_arr = new operaciones_arreglos();
        operaciones_textos op_tex = new operaciones_textos();

        //Tex_base bas = new Tex_base();

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_transferencia_entre_archivos = var_fun_GG.GG_caracter_para_transferencia_entre_archivos;

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        conmutador conmut = new conmutador();
        principal enl_princ = new principal();
        public int[] checar_numero_de_direccion_de_archivo_atras_actual_adelante(int posicion_bandera)
        {
            
            //string[] banderas = bas.Leer(G_dir_arch_transferencia[0]);
            string[] banderas = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "LEER_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[0]).Split(G_caracter_separacion_funciones_espesificas[4][0]);


            int numero_actual_posision = Convert.ToInt32(banderas[posicion_bandera]);
            int numero_adelante_posision = numero_actual_posision + 3;
            int numero_atras_posision = numero_actual_posision - 3;
            int[] arr_devolver = { -1, -1, -1 };


            if (G_dir_arch_transferencia.GetLength(0) <= numero_adelante_posision)
            {
                if (numero_adelante_posision < 3)
                {
                    numero_adelante_posision = posicion_bandera;
                }
                else
                {
                    numero_adelante_posision = posicion_bandera;
                    while (numero_adelante_posision > 3)
                    {
                        numero_adelante_posision = numero_adelante_posision - 3;
                    }
                }
            }
            if (1 > numero_actual_posision - 3)
            {
                numero_atras_posision = (G_dir_arch_transferencia.GetLength(0) - 4) + posicion_bandera;
            }
            arr_devolver[0] = numero_atras_posision;
            arr_devolver[1] = numero_actual_posision;
            arr_devolver[2] = numero_adelante_posision;




            return arr_devolver;

        }


        public void datos_a_enviar(string folio_o_palbra_clave_a_del_que_lo_recibira, string info, string programa_enviar = "NEXOPORTALARCANO")
        {
            //E_2_5_ia
            //segun 3_6 es para peticiones o talves otro programa como otra conexion ws pero creo que es exesivo

            string info_a_enviar = programa_enviar + G_caracter_para_transferencia_entre_archivos[0] + var_fun_GG.GG_id_programa + G_caracter_para_transferencia_entre_archivos[1] + folio_o_palbra_clave_a_del_que_lo_recibira + G_caracter_para_transferencia_entre_archivos[1] + info;


            //bas.Agregar(G_dir_arch_transferencia[2], info_a_enviar);

            string resp_del_agregue = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_USO_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia + G_caracter_separacion_funciones_espesificas[4] + info_a_enviar);

        }

        public void datos_recibidos_a_procesar_y_borrar()
        {
            // S_1_4_ia
            // Leer datos de usuarios desde un archivo
            //string[] usuarios_lectura = bas.Leer(G_dir_arch_transferencia[0]);
            string[] usuarios_lectura = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "LEER_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[0]).Split(G_caracter_separacion[0][0]);

            // Verificar si el ID del programa actual coincide con el primer usuario en el archivo
            if (usuarios_lectura[0] == var_fun_GG.GG_id_programa)
            {
                // Leer las respuestas IA desde otro archivo
                //string[] respuestas_ia = bas.Leer(G_dir_arch_transferencia[1]);
                string[] respuestas_ia = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "LEER_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[1]).Split(G_caracter_separacion[0][0]);

                // Verificar si hay más de una línea en las respuestas
                if (respuestas_ia.Length > 1)
                {
                    // Iterar sobre las respuestas comenzando desde una posición específica
                    for (int i = G_donde_inicia_la_tabla; i < respuestas_ia.Length; i++)
                    {
                        // Dividir la línea en elementos usando un carácter delimitador
                        string[] id_programa_comparar = respuestas_ia[i].Split(G_caracter_para_transferencia_entre_archivos[0][0]);

                        // Procesar datos si el ID coincide con el programa actual
                        if (id_programa_comparar[0] == var_fun_GG.GG_id_programa)
                        {
                            // Llamar a una función para manejar los datos
                            conmut.conmutar_datos(id_programa_comparar[1]);
                        }
                    }

                    // Eliminar filas relacionadas con múltiples programas del archivo
                    /*
                    bas.eliminar_fila_PARA_MULTIPLES_PROGRAMAS(
                        G_dir_arch_transferencia[1],
                        0,
                        var_fun_GG.GG_id_programa,
                        G_caracter_para_transferencia_entre_archivos[0]
                    );
                    */
                    string resp_del_agregue = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "ELIMINAR_FILA_PARA_MULTIPLES_PROGRAMAS_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[1] + G_caracter_separacion_funciones_espesificas[4] + "0" + G_caracter_separacion_funciones_espesificas[4] + var_fun_GG.GG_id_programa + G_caracter_separacion_funciones_espesificas[4] + G_caracter_para_transferencia_entre_archivos[0]);


                    // Comentado: Reemplazo del archivo con un mensaje de "sin información"
                    // bas.cambiar_archivo_con_arreglo(G_dir_arch_transferencia[id_atras_actual_adelante_2[1]], new string[] { "sin_informacion" });
                }

                // Cambiar al siguiente ID de programa en la lista de usuarios
                cambiar_id_programa_al_siguiente(usuarios_lectura);
            }
        }



        public void cambiar_id_programa_al_siguiente(string[] usuarios)
        {

            if (usuarios[0] == var_fun_GG.GG_id_programa)
            {
                int id_nuevo = 0;
                for (int i = G_donde_inicia_la_tabla; i < usuarios.Length; i++)
                {
                    if (usuarios[i] == var_fun_GG.GG_id_programa)
                    {
                        if (i >= (usuarios.Length - 1))
                        {
                            id_nuevo = 1;
                            break;
                        }
                        else
                        {
                            id_nuevo = i + 1;
                            break;
                        }
                    }
                }
                if (usuarios.Length > 2)
                {
                    //bas.Editar_fila_espesifica_SIN_ARREGLO_GG(G_dir_arch_transferencia[0], 0, usuarios[id_nuevo]);
                    string resp_del_agregue = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "EDITAR_FILA_ESPESIFICA_SIN_ARREGLO_GG_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia + G_caracter_separacion_funciones_espesificas[4] + "0" + G_caracter_separacion_funciones_espesificas[4] + usuarios[id_nuevo]);
                }


            }

        }

        public void quitar_id_prog_del_archivo()
        {
            string direccion_base_archivos_bandera = "BANDERAS_ARCH\\";
            //string[] dir_sep = bas.extraer_separado_carpetas_nombreArchivo_extencion(G_dir_arch_transferencia[0]);
            string[] dir_sep = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "EXTRAER_SEPARADO_CARPETAS_NOMBREARCHIVO_EXTENCION_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[0]).Split(G_caracter_separacion_funciones_espesificas[4][0]);
            dir_sep[0] = dir_sep[0] + "\\" + direccion_base_archivos_bandera;
            string dir_bandera = dir_sep[0] + "\\" + dir_sep[1] + "." + dir_sep[2];
            //este archivo bandera es para que no se agarre el archivo otro programa antes de sustituirlo
            dir_bandera = dir_bandera.Replace(".TXT", "_BANDERA.TXT");


            //bas.Crear_archivo_y_directorio(dir_bandera);
            enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "CREAR_ARCHIVO" + G_caracter_separacion_funciones_espesificas[1] + dir_bandera);
            


            StreamWriter sw_bandera = null;
            bool esta_libre = false;
            while (esta_libre == false)
            {
                try
                {
                    sw_bandera = new StreamWriter(dir_bandera);
                    esta_libre = true;
                }
                catch { }
            }
            //------------------------------------------------------------------------------------------

            try
            {
                //string[] vieja_info_arch = bas.Leer(G_dir_arch_transferencia[0]);
                string[] vieja_info_arch = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "LEER_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[0]).Split(G_caracter_separacion_funciones_espesificas[4][0]);
                //bas.eliminar_fila_PARA_MULTIPLES_PROGRAMAS(G_dir_arch_transferencia[0], 0, var_fun_GG.GG_id_programa);
                string resp_del_eliminacion = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "ELIMINAR_FILA_PARA_MULTIPLES_PROGRAMAS_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[0] + G_caracter_separacion_funciones_espesificas[4] + "0" + G_caracter_separacion_funciones_espesificas[4] + var_fun_GG.GG_id_programa);
                //string[] nueva_info_arch = bas.Leer(G_dir_arch_transferencia[0]);
                string[] nueva_info_arch = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "LEER_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[0]).Split(G_caracter_separacion_funciones_espesificas[4][0]);

                if (vieja_info_arch[0] == var_fun_GG.GG_id_programa)
                {
                    if (nueva_info_arch != null)
                    {
                        //bas.Agregar(G_dir_arch_transferencia[0], nueva_info_arch[0]);
                        string resp_del_agregue = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_USO_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_arch_transferencia[0] + G_caracter_separacion_funciones_espesificas[4] + nueva_info_arch[0]);
                    }

                }
                sw_bandera.Close();
                
            }
            catch
            {

                sw_bandera.Close();
            }




        }





    }
}
