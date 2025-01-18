using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;

namespace CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas
{
    class Tex_base
    {
        

        public string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        public string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        public string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;
        public string[] G_caracter_para_transferencia_entre_archivos = var_fun_GG.GG_caracter_para_transferencia_entre_archivos;

        string[] G_linea, G_buscar, G_remplasar;
        string G_palabra = "", G_entrando = "", G_temp = "";

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        operaciones_arreglos op_arr = new operaciones_arreglos();
        operaciones_textos op_tex = new operaciones_textos();
        principal enl_princ = new principal();
        public void Crear_archivo_y_directorio(string direccion_archivo, string valor_inicial = null, string[] filas_iniciales = null, object caracter_separacion_fun_esp_objeto = null)
        {

            char[] parametro2 = { '/', '\\' };//estos seran los parametros de separacion de el split
            string acumulador_directorios_y_archvo = "";
            string[] direccion_espliteada = direccion_archivo.Split(parametro2);//spliteamos la direccion


            for (int i = 0; i < direccion_espliteada.Length; i++)//pasamos por todas las los directorios y archivo
            {
                if (i < direccion_espliteada.Length - 1)//el path muestra 6 palabras que fueron espliteadas se le resta uno por que los arreglos empiesan desde 0 y solo se le pone el menor que por que la ultima palabra es el archivo
                {
                    acumulador_directorios_y_archvo = acumulador_directorios_y_archvo + direccion_espliteada[i] + "\\"; // va acumulando los directorios a los que va a entrar ejemplo: ventas\\   ventas\\2016    ventas\\2016\\        ventas\\2016\\11      ventas\\2016\\11\\dias\\  y no muestra el ultimo por que es el archivo y en el if  le dijimos que lo dejara en el penultimo
                    if (!Directory.Exists(acumulador_directorios_y_archvo))//si el directorio no existe entrara y lo creara
                    {

                        Directory.CreateDirectory(acumulador_directorios_y_archvo);//crea el directorio

                    }
                }
            }

            if (direccion_espliteada[direccion_espliteada.Length - 1] != "")//checa si escribio tambien el archivo o solo carpetas
            {
                if (!File.Exists(direccion_archivo))//si el archivo no existe entra y lo crea
                {

                    FileStream fs0 = new FileStream(direccion_archivo, FileMode.CreateNew);//crea una variable tipo filestream "fs0"  y crea el archivo
                    fs0.Close();//cierra fs0 para que se pueda usar despues



                    if (valor_inicial != null)// si al llamar a la funcion  le pusiste valor_inicial las escribe //se utilisa para que sea como un titulo o un eslogan pero lo utilisaremos en este prog
                    {
                        Agregar(direccion_archivo, valor_inicial);//escribe aqui el valor inicial si es que lo pusiste
                    }

                    if (filas_iniciales != null)//si al llamar a la funcion le pusistes columnas a agregar//recuerda que se separan por comas
                    {
                        if (filas_iniciales.Length == 1 && filas_iniciales[0] == "")
                        {

                        }
                        else
                        {
                            for (int i = 0; i < filas_iniciales.Length; i++)
                            {
                                Agregar(direccion_archivo, filas_iniciales[i]);//agrega las filas
                            }
                        }

                    }



                }

            }

        }

        
        public void Agregar(string direccion_archivos, string agregando)
        {
            StreamWriter sw = new StreamWriter(direccion_archivos, true);
            sw.WriteLine(agregando);
            sw.Close();

        }
        
        public string[] Leer(string direccion_archivo, string pos_string = null, string caracter_separacion = "|")
        {
            ArrayList linea = new ArrayList();
            ArrayList resultado = new ArrayList();
            string[] pos_split;
            int[] posiciones;

            StreamReader sr = new StreamReader(direccion_archivo);

            if (pos_string == null)
            {

                while ((G_palabra = sr.ReadLine()) != null)
                {
                    if (G_palabra != "")
                    {
                        linea.Add(G_palabra);
                    }
                }
            }

            else
            {
                pos_split = pos_string.Split(caracter_separacion[0]);
                posiciones = new int[pos_split.Length];
                for (int i = 0; i < posiciones.Length; i++)
                {
                    posiciones[i] = Convert.ToInt32(pos_split[i]);
                }


                for (int i = 0; (G_palabra = sr.ReadLine()) != null; i++)
                {
                    string[] spl_linea = G_palabra.Split(caracter_separacion[0]);

                    G_palabra = "";
                    for (int j = 0; j < posiciones.Length; j++)
                    {
                        if (j < posiciones.Length - 1)
                        {
                            G_palabra = G_palabra + spl_linea[posiciones[j]] + caracter_separacion;
                        }
                        else
                        {
                            G_palabra = G_palabra + spl_linea[posiciones[j]];
                        }

                    }
                    resultado.Add(G_palabra);
                }
                sr.Close();
                string[] t = new string[resultado.Count];
                for (int mnm = 0; mnm < resultado.Count; mnm++)
                {
                    t[mnm] = "" + resultado[mnm];
                }
                return t;
            }

            sr.Close();
            string[] t2 = new string[linea.Count];
            for (int mnm = 0; mnm < linea.Count; mnm++)
            {
                t2[mnm] = "" + linea[mnm];
            }
            return t2;
        }

        

        public string Trimend_paresido(string texto, char caracter_separacion = '|')
        {
            string texto_editado = "";
            string[] texto_spliteado = texto.Split(caracter_separacion);

            if (texto_spliteado[texto_spliteado.Length - 1] == "")
            {
                for (int i = 0; i < texto_spliteado.Length; i++)
                {
                    if (i < texto_spliteado.Length - 2)
                    {
                        texto_editado = texto_editado + texto_spliteado[i] + caracter_separacion;
                    }
                    else
                    {
                        texto_editado = texto_editado + texto_spliteado[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < texto_spliteado.Length; i++)
                {
                    if (i < texto_spliteado.Length - 1)
                    {
                        texto_editado = texto_editado + texto_spliteado[i] + caracter_separacion;
                    }

                    else
                    {
                        texto_editado = texto_editado + texto_spliteado[i];
                    }
                }
            }


            return texto_editado;
        }

        

        //del texbase mas nuevo

        public void eliminar_fila_PARA_MULTIPLES_PROGRAMAS(string direccion_archivo, int columna_a_comparar, string comparar, object caracter_separacion_objeto = null, int donde_inica = 0)
        {

            StreamReader sr = null;
            while (sr == null)
            {


                try
                {
                    sr = new StreamReader(direccion_archivo);

                }
                catch (Exception e)
                {
                    //string[] checador = Leer(var_fun_GG.GG_direccion_control_errores_try);
                    string[] checador = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "LEER_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + var_fun_GG.GG_direccion_control_errores_try).Split(G_caracter_separacion_funciones_espesificas[4][0]);
                    chequeo_error_try(direccion_archivo, e, checador[1]);
                }
            }

            string dir_tem = direccion_archivo.Replace(".TXT", "_TEM.TXT");
            StreamWriter sw = new StreamWriter(dir_tem, true);


            try
            {
                int cont = 0;
                while (sr.Peek() >= 0)//verificamos si hay mas lineas a leer
                {

                    string linea = sr.ReadLine();//leemos linea y lo guardamos en linea

                    if (linea != null)
                    {
                        if (cont >= donde_inica)
                        {
                            string[] linea_espliteada = linea.Split(G_caracter_separacion[0][0]);
                            if (linea_espliteada[columna_a_comparar] != comparar)
                            {
                                sw.WriteLine(linea);
                            }
                        }
                        else
                        {
                            sw.WriteLine(linea);
                        }
                    }
                    cont++;
                }



                sr.Close();
                sw.Close();

                File.Delete(direccion_archivo);//borramos el archivo original
                File.Move(dir_tem, direccion_archivo);//renombramos el archivo temporal por el que tenia el original

                





            }
            catch (Exception error)
            {
                sr.Close();
                sw.Close();
                File.Delete(dir_tem);//borramos el archivo temporal


            }


        }

        public string Editar_fila_espesifica_SIN_ARREGLO_GG(string direccion_archivo, int num_fila, string editar_info)
        {

            StreamReader sr = null;
            while (sr == null)
            {


                try
                {
                    sr = new StreamReader(direccion_archivo);

                }
                catch (Exception e)
                {
                    //string[] checador = Leer(var_fun_GG.GG_direccion_control_errores_try);
                    string[] checador = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "LEER_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + var_fun_GG.GG_direccion_control_errores_try).Split(G_caracter_separacion_funciones_espesificas[4][0]);

                    chequeo_error_try(direccion_archivo, e, checador[1]);
                }
            }
            string dir_tem = direccion_archivo.Replace(".TXT", "_TEM.TXT");
            StreamWriter sw = new StreamWriter(dir_tem, true);
            string exito_o_fallo;

            try
            {
                int id_linea = 0;

                while (sr.Peek() >= 0)//verificamos si hay mas lineas a leer
                {
                    string linea = sr.ReadLine();//leemos linea y lo guardamos en palabra
                    if (linea != null)
                    {

                        if (id_linea == num_fila)
                        {
                            sw.WriteLine(editar_info);

                        }
                        else
                        {
                            sw.WriteLine(linea);
                        }

                        id_linea++;
                    }
                }
                exito_o_fallo = "1)exito";
                sr.Close();
                sw.Close();
                File.Delete(direccion_archivo);//borramos el archivo original
                File.Move(dir_tem, direccion_archivo);//renombramos el archivo temporal por el que tenia el original


            }
            catch (Exception error)
            {
                sr.Close();
                sw.Close();
                exito_o_fallo = "2)error:" + error;
                File.Delete(dir_tem);//borramos el archivo original


            }
            return exito_o_fallo;
        }

        public void chequeo_error_try(string direccionArchivo, Exception e, string numero_chequeo)
        {
            DialogResult result = MessageBox.Show(e.Message, e.Message + "\nError quieres crear el archivo sie es el error \"No\" para volver a intentar \"cancelar\" para cerrar el programa", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);

            if (result == DialogResult.Yes)
            {
                //Crear_archivo_y_directorio(direccionArchivo, "sin informacion");
                
                enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "CREAR_ARCHIVO" + G_caracter_separacion_funciones_espesificas[1] + direccionArchivo + G_caracter_separacion_funciones_espesificas[4] + "SIN_INFORMACION");
            }
            else if (result == DialogResult.No)
            {

            }
            else if (result == DialogResult.Cancel)
            {
                Environment.Exit(0);
            }
        }


        public string[] extraer_separado_carpetas_nombreArchivo_extencion(string direccion_archivo)
        {
            string[] arreglo_retornar = new string[3];


            string[] direccion_esp = direccion_archivo.Split('\\');
            string[] nom_ext_esp = direccion_esp[direccion_esp.Length - 1].Split('.');
            if (nom_ext_esp.Length > 1)
            {
                string carpetas = op_tex.joineada_paraesida_SIN_NULOS_y_quitador_de_extremos_del_string(direccion_archivo, '\\', 1);
                string nombre = nom_ext_esp[0];
                string extencion = nom_ext_esp[1];
                arreglo_retornar[0] = carpetas;
                arreglo_retornar[1] = nombre;
                arreglo_retornar[2] = extencion;
            }
            else
            {

            }


            return arreglo_retornar;
        }

        



        //fin clase----------------------------------------------------------------------------------------
    }

}
