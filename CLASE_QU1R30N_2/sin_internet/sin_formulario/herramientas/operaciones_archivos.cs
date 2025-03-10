﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Collections;
using System.Threading;


namespace CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas
{
    internal class operaciones_archivos
    {

        public string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        public string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        public string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;
        public string[] G_caracter_para_transferencia_entre_archivos = var_fun_GG.GG_caracter_para_transferencia_entre_archivos;

        principal enl_princ = new principal();

        public string[] Contenido_directorio(string direccion_archivo, string decicion = null)
        {
            ArrayList lista = new ArrayList();
            DirectoryInfo di = new DirectoryInfo(direccion_archivo);

            if (decicion == null)
            {
                foreach (var fi in di.GetFiles())
                {
                    lista.Add("" + fi);
                }
            }

            else
            {
                foreach (var fi in di.GetFiles(direccion_archivo))
                {
                    lista.Add("" + fi);
                }
            }

            string[] list_string = new string[lista.Count];
            for (int op = 0; op < lista.Count; op++)
            {
                list_string[op] = "" + (lista[op]);
            }

            return list_string;//devuelve la lista para ser usada
        }

        public void Eliminar_carpeta(string direccion)
        {
            try
            {
                Directory.Delete(direccion, true);
            }
            catch (Exception)
            {

            }

        }

        public void remplasar_archivo(string archivo_a_cambiar, string archivo_remplaso)
        {
            File.Delete(archivo_a_cambiar);//borramos el archivo original
            Thread.Sleep(1);
            File.Move(archivo_remplaso, archivo_a_cambiar);//renombramos el archivo temporal por el que tenia el original
        }

        public void mover_archivo(string direccion_archivo, string direccion_a_mover)
        {
            File.Move(direccion_archivo, direccion_a_mover);
        }

        public void Eliminar_archivo(string direccion)
        {
            try
            {
                File.Delete(direccion);
            }
            catch (Exception)
            {

            }

        }

        public void mover_dir(string direccion_archivo, string direccion_a_mover)
        {

            if (Directory.Exists(direccion_a_mover))
            {
                Directory.Delete(direccion_a_mover, true);
            }

            Directory.Move(direccion_archivo, direccion_a_mover);

        }

        public string[] Ordenar(string direccion_archivo, int columna_comparar, string tipo, char caracter_separacion = '|')
        {

            tipo = tipo.ToUpper();

            //Tex_base bas = new Tex_base();
            //string[] lineas = bas.Leer(direccion_archivo);
            string[] lineas = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "LEER_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + direccion_archivo).Split(G_caracter_separacion_funciones_espesificas[4][0]);

            if (tipo == "NUMERO")
            {
                string temporal_apoyo;
                for (int i = 0; i < lineas.Length; i++)
                {
                    for (int j = i + 1; j < lineas.Length; j++)
                    {

                        string[] num1 = lineas[i].Split(caracter_separacion);
                        decimal num1_decimal = Convert.ToDecimal(num1[columna_comparar]);
                        string[] num2 = lineas[j].Split(caracter_separacion);
                        decimal num2_decimal = Convert.ToDecimal(num2[columna_comparar]);
                        if (num1_decimal < num2_decimal)
                        {
                            temporal_apoyo = lineas[j];
                            lineas[j] = lineas[i];
                            lineas[i] = temporal_apoyo;
                        }
                        else if (num1_decimal >= num2_decimal)
                        {
                            //no_hacer_nada
                        }
                        else
                        {
                            //error
                        }





                    }//for linea_de_abajo
                }//for linea_de_arriba
            }//if tipo


            string dir_tem = direccion_archivo.Replace(".TXT", "_TEM.TXT");
            StreamWriter sw = new StreamWriter(dir_tem, true);
            for (int k = 0; k < lineas.Length; k++)
            {
                sw.WriteLine(lineas[k]);

            }
            sw.Close();
            File.Delete(direccion_archivo);//borramos el archivo original
            File.Move(dir_tem, direccion_archivo);//renombramos el archivo temporal por el que tenia el original
            return lineas;
        }

    }
}
