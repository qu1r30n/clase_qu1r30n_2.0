using CLASE_QU1R30N_2.sin_internet.sin_formularios;
using CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLASE_QU1R30N_2.sin_internet.sin_formulario.procesos
{
    internal class _01_proc_tex_base
    {
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;
        operaciones_textos op_tex = new operaciones_textos();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        string[] G_solo_para_consultas_relacionadas_encontrar_el_id;

        principal enl_princ = new principal();

        public string Crear_archivo_y_directorio(string datos)
        {
            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);
            //parametros-------------------------------------------------------------------------
            string direccion_archivo = datos_epliteados[0];
            
            string valor_inicial = null;
            if (datos_epliteados.Length>=2)
            {
                if (datos_epliteados[1] != "")
                {
                    valor_inicial = datos_epliteados[1];
                }
            }
            
            string[] filas_iniciales = null;
            if (datos_epliteados.Length >= 3)
            {
                if (datos_epliteados[2] != "")
                {
                    filas_iniciales = datos_epliteados[2].Split(G_caracter_separacion_funciones_espesificas[4][0]);
                }
            }
            //fin_parametros--------------------------------------------------------------------------------
            
            


            
            char[] parametro2 = { '/', '\\' };//estos seran los parametros de separacion de el split
            string acumulador_directorios_y_archvo = "";
            string[] direccion_espliteada = direccion_archivo.Split(parametro2);//spliteamos la direccion
            bool creo_algo = false;

            for (int i = 0; i < direccion_espliteada.Length; i++)//pasamos por todas las los directorios y archivo
            {
                if (i < direccion_espliteada.Length - 1)//el path muestra 6 palabras que fueron espliteadas se le resta uno por que los arreglos empiesan desde 0 y solo se le pone el menor que por que la ultima palabra es el archivo
                {
                    acumulador_directorios_y_archvo = acumulador_directorios_y_archvo + direccion_espliteada[i] + "\\"; // va acumulando los directorios a los que va a entrar ejemplo: ventas\\   ventas\\2016    ventas\\2016\\        ventas\\2016\\11      ventas\\2016\\11\\dias\\  y no muestra el ultimo por que es el archivo y en el if  le dijimos que lo dejara en el penultimo
                    if (!Directory.Exists(acumulador_directorios_y_archvo))//si el directorio no existe entrara y lo creara
                    {

                        Directory.CreateDirectory(acumulador_directorios_y_archvo);//crea el directorio
                        creo_algo = true;
                    }
                }
            }

            if (direccion_espliteada[direccion_espliteada.Length - 1] != "")//checa si escribio tambien el archivo o solo carpetas
            {
                if (!File.Exists(direccion_archivo))//si el archivo no existe entra y lo crea
                {

                    FileStream fs0 = new FileStream(direccion_archivo, FileMode.CreateNew);//crea una variable tipo filestream "fs0"  y crea el archivo
                    StreamWriter sw = new StreamWriter(fs0);
                    if (valor_inicial != null)// si al llamar a la funcion  le pusiste valor_inicial las escribe //se utilisa para que sea como un titulo o un eslogan pero lo utilisaremos en este prog
                    {
                        sw.WriteLine(valor_inicial);
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
                                
                                sw.WriteLine(filas_iniciales[i]);
                            }
                        }

                    }




                    fs0.Close();//cierra fs0 para que se pueda usar despues



                    

                    


                    creo_algo = true;
                }
            }

            if (creo_algo)
            {
                return "1" + G_caracter_para_confirmacion_o_error[0] + direccion_archivo;
            }

            return "0" + G_caracter_para_confirmacion_o_error[0] + "ya existe";
        }


        public string Agregar_solo_prog(string datos)
        {
            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            //parametros--------------------------------------------------------------

            string direccion_archivos = datos_epliteados[0];

            string agregando = "\n";
            if (datos_epliteados.Length >= 2)
            {
                if (datos_epliteados[1] != "")
                {
                     agregando = datos_epliteados[1];
                }
                
            }

            //fin de parametros---------------------------------------------------------
            FileStream fs = null;
            StreamWriter sw = null;

            while (fs == null)
            {
                try
                {
                    fs = new FileStream(direccion_archivos, FileMode.Open, FileAccess.ReadWrite);
                }
                catch
                {


                }
            }
            fs.Seek(0, SeekOrigin.End);
            sw = new StreamWriter(fs);

            

            try
            {

                sw.WriteLine(agregando);
                sw.Close();
                fs.Close();
                return "1" + G_caracter_para_confirmacion_o_error[0] + agregando;
            }
            catch (Exception)
            {

                sw.Close();
                fs.Close();
                return "0" + G_caracter_para_confirmacion_o_error[0] + "error no pudo guardar";
            }

        }

        public string Agregar_sino_existe_solo_prog(string datos)
        {

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            //PARAMETROS---------------------------------------------------------------------------
            string direccion_archivo_a_checar = datos_epliteados[0];

            Int64 num_column_comp = 0;
            if (datos_epliteados.Length >= 2)
            {
                if (datos_epliteados[1] != "")
                {
                    num_column_comp = Convert.ToInt64(datos_epliteados[1]);
                }
            }

            string comparar = null;
            if (datos_epliteados.Length >= 3)
            {
                if (datos_epliteados[2] != "")
                {
                    comparar = datos_epliteados[2];
                }
            }

            string texto_a_agregar_si_no_esta = "";
            if (datos_epliteados.Length >= 4)
            {
                if (datos_epliteados[3] != "")
                {
                    texto_a_agregar_si_no_esta = datos_epliteados[3];
                }
            }

            object caracter_separacion_obj = null;
            if (datos_epliteados.Length >= 5)
            {
                if (datos_epliteados[4] != "")
                {
                    caracter_separacion_obj = datos_epliteados[4];
                }
            }


            operaciones_textos op_tex = new operaciones_textos();


            string info_a_retornar = "";

            try
            {
                string[] caracter_separacion = G_caracter_separacion;


                string direccion_archivo = direccion_archivo_a_checar;


                bool esta = false;

                string[] info_archivo = LEER_SOLO_PROG(direccion_archivo).Split(G_caracter_separacion_funciones_espesificas[4][0]);

                if (info_archivo == null)
                {
                    info_archivo = new string[] { "" };
                }

                for (int i = G_donde_inicia_la_tabla; i < info_archivo.Length; i++)
                {
                    string[] columnas = info_archivo[i].Split(caracter_separacion[0][0]);

                    if (columnas[num_column_comp] == comparar)
                    {


                        //cambiar_archivo_con_arreglo(direccion_archivo, info_archivo);
                        info_a_retornar = "2" + G_caracter_para_confirmacion_o_error[0] + "no se agrego porque ya existia";
                        esta = true;
                        break;
                    }
                }
                if (esta == false)
                {
                    Agregar_solo_prog(direccion_archivo + G_caracter_separacion_funciones_espesificas[3] + texto_a_agregar_si_no_esta);
                }

            }


            catch
            {


            }



            return info_a_retornar;
        }


        public string Agregar_info_dividida(string datos)
        {
            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            //parametros------------------------------------------------------------------
            string direccion_archivos = datos_epliteados[0];
            string agregando = null;
            if (datos_epliteados.Length >= 2)
            {
                if (datos_epliteados[1] != "")
                {
                    agregando = datos_epliteados[1];
                }

            }
            string nom_columnas_si_no_existe_archivo = null;
            if (datos_epliteados.Length >= 3)
            {
                if (datos_epliteados[2] != "")
                {
                    nom_columnas_si_no_existe_archivo = datos_epliteados[2];
                }

            }
            //fin parametros-------------------------------------------------------------

            string[] temp_colum = agregando.Split(G_caracter_separacion[0][0]);

            Crear_archivo_y_directorio(direccion_archivos + G_caracter_separacion_funciones_espesificas[3] + "tipo_info|info" + G_caracter_separacion_funciones_espesificas[3] + "ID_TOT|0\nCOLUMNAS|" + nom_columnas_si_no_existe_archivo + "\nCANT_POR_ARCH|100");

            string[] direccion_extencion_espliteada = direccion_archivos.Split('.');
            char[] separadores_de_directorios = { '/', '\\' };//estos seran los parametros de separacion de el split

            string[] carpetas_ultimo_nom_archivo = direccion_extencion_espliteada[0].Split(separadores_de_directorios);
            string nombre_archivo = carpetas_ultimo_nom_archivo[carpetas_ultimo_nom_archivo.Length - 1];

            FileStream fs = null;
            StreamReader sr = null;
            



            while (fs == null)
            {
                try
                {
                    fs = new FileStream(direccion_archivos, FileMode.Open, FileAccess.ReadWrite);
                }
                catch 
                {

                   
                }
            }
            sr = new StreamReader(fs);
            




            List<string> lista_datos = new List<string>();
            string linea;
            string id_total = null;
            string columnas = null;
            string cantidad_filas_por_archivo = "100";
            while ((linea = sr.ReadLine()) != null)
            {
                lista_datos.Add(linea);
            }

            string resul = orden_informacion(lista_datos);


            string dir_info_bas = direccion_extencion_espliteada + "_dat_\\" + generar_ruta_archivo(id_total,cantidad_filas_por_archivo);

            string res_crear_archivo = Crear_archivo_y_directorio(dir_info_bas + G_caracter_separacion_funciones_espesificas[3] + columnas + G_caracter_separacion_funciones_espesificas[3] + agregando);
            
            string[] res_esp = res_crear_archivo.Split(G_caracter_para_confirmacion_o_error[0][0]);
            if (res_esp[0] == "1")
            {

            }
            else
            {
                
                StreamWriter sw = null;
                while (sw == null)
                {
                    try
                    {
                        sw = new StreamWriter(dir_info_bas, true);
                    }
                    catch 
                    {

                        
                    }
                    
                }
                try
                {

                    sw.WriteLine((Convert.ToInt64(id_total) + 1) + G_caracter_separacion[0] + agregando);
                    
                    string datos_enviar = direccion_archivos + G_caracter_separacion_funciones_espesificas[3] + "0" + G_caracter_separacion_funciones_espesificas[3] + "ID_TOT" + G_caracter_separacion_funciones_espesificas[3] + "1" + G_caracter_separacion_funciones_espesificas[3] + "1" + G_caracter_separacion_funciones_espesificas[3] + "";
                    INCREMENTA_CELDA(datos_enviar,fs);

                    sw.Close();
                    sr.Close();
                    fs.Close();


                    return "1" + G_caracter_para_confirmacion_o_error[0] + agregando;
                }
                catch (Exception)
                {

                    sw.Close();
                    sr.Close();
                    fs.Close();
                    return "0" + G_caracter_para_confirmacion_o_error[0] + "error no pudo guardar";
                }

            }
            
            sr.Close();
            fs.Close();
            return "0" + G_caracter_para_confirmacion_o_error[0] + "error no pudo guardar";
        }
        
        public string seleccionar_id(string datos)
        {
            string info_retornar = "";

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            //parametros------------------------------------------------------------------------------------
            string direccion_archivos = datos_epliteados[0];
            string id = datos_epliteados[1];
            
            string info_a_comparar = null;
            if (datos_epliteados.Length >= 3)
            {
                if (datos_epliteados[2] != "")
                {
                    info_a_comparar = datos_epliteados[2];
                }

            }
            string columna_comparar = null;
            if (datos_epliteados.Length >= 4)
            {
                if (datos_epliteados[3] != "")
                {
                    columna_comparar = datos_epliteados[3];
                }

            }
            //fin parametros-----------------------------------------------------------------------------

            string[] direccion_espliteada = direccion_archivos.Split('.');
            string carpetas = direccion_espliteada[0];

            FileStream fs = null;
            StreamReader sr = null;
            while (fs == null)
            {
                try
                {
                    fs = new FileStream(direccion_archivos, FileMode.Open, FileAccess.ReadWrite);
                }
                catch
                {


                }
            }
            sr = new StreamReader(fs);

            string linea;
            List<string> filas_configuaracion = new List<string>();
            // Lee cada línea del archivo hasta el final
            while ((linea = sr.ReadLine()) != null)
            {
                // Aquí puedes procesar cada línea
                filas_configuaracion.Add(linea);
            }

            sr.Close();
            fs.Close();

            string datos_ordenados_configuracion = orden_informacion(filas_configuaracion, "CANT_POR_ARCH");
            string[] datos_config_esp = datos_ordenados_configuracion.Split(G_caracter_separacion[0][0]);

            string cantidad_por_archivo = datos_config_esp[0];
            string direccion = carpetas + "\\" + generar_ruta_archivo(id, cantidad_por_archivo);






            FileStream fs2 = null;
            StreamReader sr2 = null;
            while (fs2 == null)
            {
                try
                {
                    fs2 = new FileStream(direccion, FileMode.Open, FileAccess.ReadWrite);
                }
                catch
                {


                }
            }
            sr2 = new StreamReader(fs2);


            string linea2;
            bool encontro_informacion = false;
            while ((linea2 = sr2.ReadLine()) != null)
            {
                string[] linea2_esp = linea2.Split(G_caracter_separacion[0][0]);
                string id_fila = linea2_esp[0];

                if (info_a_comparar != null && columna_comparar != null)
                {

                    try
                    {
                        int col = Convert.ToInt32(columna_comparar);

                        if (linea2_esp[col]==info_a_comparar)
                        {
                            info_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + linea2;
                            encontro_informacion = true;
                        }

                    }
                    catch 
                    { 
                        info_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "error";
                        break;
                    }

                }

                else if (id == id_fila)
                {
                    info_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + linea2;
                    encontro_informacion = true;
                }

            }
            if (encontro_informacion == false)
            {
                info_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no_se_encontro_informacion";
            }
            return info_retornar;
        }

        public string editar_id(string datos)
        {
            string info_retornar = "";

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // Parametros------------------------------------------------------------------------------------
            string direccion_archivos = datos_epliteados[0];
            string id = datos_epliteados[1];
            string info_a_comparar = datos_epliteados[2];
            string columna_comparar = datos_epliteados[3];
            string nuevos_datos = datos_epliteados[4];  // Nuevos datos que se desean establecer
            string numero_de_columna_a_editar = datos_epliteados[5]; // Número de columna a editar
                                                                     // Fin parametros-----------------------------------------------------------------------------

            string[] direccion_espliteada = direccion_archivos.Split('.');
            string carpetas = direccion_espliteada[0];

            FileStream fs = null;
            StreamReader sr = null;
            while (fs == null)
            {
                try
                {
                    fs = new FileStream(direccion_archivos, FileMode.Open, FileAccess.ReadWrite);
                }
                catch
                {
                    // Esperamos que el archivo se abra correctamente.
                }
            }
            sr = new StreamReader(fs);

            string linea;
            List<string> filas_configuaracion = new List<string>();
            // Lee cada línea del archivo hasta el final
            while ((linea = sr.ReadLine()) != null)
            {
                // Aquí puedes procesar cada línea
                filas_configuaracion.Add(linea);
            }

            sr.Close();
            fs.Close();

            string datos_ordenados_configuracion = orden_informacion(filas_configuaracion, "CANT_POR_ARCH");
            string[] datos_config_esp = datos_ordenados_configuracion.Split(G_caracter_separacion[0][0]);

            string cantidad_por_archivo = datos_config_esp[0];
            
            
            
            
            

            
            
            string direccion = carpetas + "\\" + generar_ruta_archivo(id, cantidad_por_archivo);

            FileStream fs2 = null;
            StreamReader sr2 = null;
            while (fs2 == null)
            {
                try
                {
                    fs2 = new FileStream(direccion, FileMode.Open, FileAccess.ReadWrite);
                }
                catch
                {
                    // Esperamos que el archivo se abra correctamente.
                }
            }
            sr2 = new StreamReader(fs2);

            string linea2;
            bool encontro_informacion = false;
            List<string> nuevas_lineas = new List<string>();

            while ((linea2 = sr2.ReadLine()) != null)
            {
                string[] linea2_esp = linea2.Split(G_caracter_separacion[0][0]);
                string id_fila = linea2_esp[0];

                if (info_a_comparar != "" && columna_comparar != "")
                {
                    try
                    {
                        int col = Convert.ToInt32(columna_comparar);

                        if (linea2_esp[col] == info_a_comparar)
                        {
                            // Si se encuentra la coincidencia, actualizamos la columna especificada con los nuevos datos
                            int colEdicion = Convert.ToInt32(numero_de_columna_a_editar);

                            // Verificar que la columna a editar esté dentro del rango
                            if (colEdicion >= 0 && colEdicion < linea2_esp.Length)
                            {
                                linea2_esp[colEdicion] = nuevos_datos;  // Editamos la columna indicada

                                string nueva_linea_str = string.Join(G_caracter_separacion[0][0].ToString(), linea2_esp);
                                nuevas_lineas.Add(nueva_linea_str);
                                encontro_informacion = true;
                            }
                            else
                            {
                                info_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "columna_fuera_de_rango";
                                break;
                            }
                        }
                        else
                        {
                            nuevas_lineas.Add(linea2);
                        }
                    }
                    catch
                    {
                        info_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "error";
                        break;
                    }
                }
                else if (id == id_fila)
                {
                    // Si encontramos el id, actualizamos la columna especificada con los nuevos datos
                    int colEdicion = Convert.ToInt32(numero_de_columna_a_editar);

                    // Verificar que la columna a editar esté dentro del rango
                    if (colEdicion >= 0 && colEdicion < linea2_esp.Length)
                    {
                        linea2_esp[colEdicion] = nuevos_datos;  // Editamos la columna indicada

                        string nueva_linea_str = string.Join(G_caracter_separacion[0][0].ToString(), linea2_esp);
                        nuevas_lineas.Add(nueva_linea_str);
                        encontro_informacion = true;
                    }
                    else
                    {
                        info_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "columna_fuera_de_rango";
                        break;
                    }
                }
                else
                {
                    nuevas_lineas.Add(linea2);
                }
            }


            // Si encontramos la información, guardamos los cambios
            StreamWriter sw = new StreamWriter(fs2);
            if (encontro_informacion)
            {
                
                

                foreach (string nueva_linea in nuevas_lineas)
                {
                    sw.WriteLine(nueva_linea);
                }

                sw.Close();
                

                info_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + "informacion_editada";
            }
            else
            {
                sw.Close();
                info_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no_se_encontro_informacion";
            }
            sr2.Close();
            fs2.Close();
            return info_retornar;
        }


        public string borrar_contenido_excepto_id(string datos)
        {
            string info_retornar = "";

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // Parametros------------------------------------------------------------------------------------
            string direccion_archivos = datos_epliteados[0];
            string id = datos_epliteados[1];
            string info_a_comparar = datos_epliteados[2];
            string columna_comparar = datos_epliteados[3];
            // Fin parametros-----------------------------------------------------------------------------

            string[] direccion_espliteada = direccion_archivos.Split('.');
            string carpetas = direccion_espliteada[0];

            FileStream fs = null;
            StreamReader sr = null;
            while (fs == null)
            {
                try
                {
                    fs = new FileStream(direccion_archivos, FileMode.Open, FileAccess.ReadWrite);
                }
                catch
                {
                    // Esperamos que el archivo se abra correctamente.
                }
            }
            sr = new StreamReader(fs);

            string linea;
            List<string> filas_configuaracion = new List<string>();
            // Lee cada línea del archivo hasta el final
            while ((linea = sr.ReadLine()) != null)
            {
                // Aquí puedes procesar cada línea
                filas_configuaracion.Add(linea);
            }

            sr.Close();
            fs.Close();

            string datos_ordenados_configuracion = orden_informacion(filas_configuaracion, "CANT_POR_ARCH");
            string[] datos_config_esp = datos_ordenados_configuracion.Split(G_caracter_separacion[0][0]);

            string cantidad_por_archivo = datos_config_esp[0];
            string direccion = carpetas + "\\" + generar_ruta_archivo(id, cantidad_por_archivo);

            FileStream fs2 = null;
            StreamReader sr2 = null;
            while (fs2 == null)
            {
                try
                {
                    fs2 = new FileStream(direccion, FileMode.Open, FileAccess.ReadWrite);
                }
                catch
                {
                    // Esperamos que el archivo se abra correctamente.
                }
            }
            sr2 = new StreamReader(fs2);

            string linea2;
            bool encontro_informacion = false;
            List<string> nuevas_lineas = new List<string>();

            while ((linea2 = sr2.ReadLine()) != null)
            {
                string[] linea2_esp = linea2.Split(G_caracter_separacion[0][0]);
                string id_fila = linea2_esp[0];

                if (info_a_comparar != "" && columna_comparar != "")
                {
                    try
                    {
                        int col = Convert.ToInt32(columna_comparar);

                        if (linea2_esp[col] == info_a_comparar)
                        {
                            // Si se encuentra la coincidencia, borramos el contenido de las columnas, excepto el id
                            for (int i = 1; i < linea2_esp.Length; i++)
                            {
                                linea2_esp[i] = "";  // Borra el contenido de la columna (puedes poner "BORRADO" o cualquier otro valor)
                            }

                            string nueva_linea_str = string.Join(G_caracter_separacion[0][0].ToString(), linea2_esp);
                            nuevas_lineas.Add(nueva_linea_str);
                            encontro_informacion = true;
                        }
                        else
                        {
                            nuevas_lineas.Add(linea2);
                        }
                    }
                    catch
                    {
                        info_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "error";
                        break;
                    }
                }
                else if (id == id_fila)
                {
                    // Si encontramos el id, borramos el contenido de las columnas, excepto el id
                    for (int i = 1; i < linea2_esp.Length; i++)
                    {
                        linea2_esp[i] = "";  // Borra el contenido de la columna (puedes poner "BORRADO" o cualquier otro valor)
                    }

                    string nueva_linea_str = string.Join(G_caracter_separacion[0][0].ToString(), linea2_esp);
                    nuevas_lineas.Add(nueva_linea_str);
                    encontro_informacion = true;
                }
                else
                {
                    nuevas_lineas.Add(linea2);
                }
            }

            // Si encontramos la información, guardamos los cambios
            StreamWriter sw = new StreamWriter(fs2);
            if (encontro_informacion)
            {
                
                

                foreach (string nueva_linea in nuevas_lineas)
                {
                    sw.WriteLine(nueva_linea);
                }

                sw.Close();
                
                info_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + "informacion_borrada";
            }
            else
            {
                sw.Close();
                info_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no_se_encontro_informacion";
            }

            sr2.Close();
            fs2.Close();
            return info_retornar;
        }



        public string LEER_INFO_DIVIDIDA(string datos)
        {
            string info_retornar = "";

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);
            // parametros-------------------------------------------------------------------------------
            string direccion_archivos = datos_epliteados[0];

            //fin parametros----------------------------------------------------------------------------
            FileStream fs = null;
            StreamReader sr = null;
            while (fs == null)
            {
                try
                {
                    fs = new FileStream(direccion_archivos, FileMode.Open, FileAccess.ReadWrite);
                 }
                catch
                {


                }
            }
            sr = new StreamReader(fs);


            string[] temp = direccion_archivos.Split('.');
            string carpetas = temp[0];


            string linea;
            Int64 id_total=-1;
            Int64 cantidad_filas_por_archivo = 100;

            while ((linea = sr.ReadLine()) != null)
            {

                string[] linea_esp = linea.Split(G_caracter_separacion[0][0]);

                if (linea_esp[0] == "ID_TOT")
                {
                    id_total = Convert.ToInt64(linea_esp[1]);

                }

                if (linea_esp[0] == "CANT_POR_ARCH")
                {
                    cantidad_filas_por_archivo = Convert.ToInt64(linea_esp[1]);

                }

            }
            


            for (int i = 1; i < id_total; i++)
            {
                string ruta_archivo = generar_ruta_archivo("" + i,cantidad_filas_por_archivo+"");
                FileStream fs2 = null;
                StreamReader sr2 = null;

                while (fs2 == null)
                {
                    try
                    {
                        fs2 = new FileStream(ruta_archivo, FileMode.Open, FileAccess.ReadWrite);
                    }
                    catch
                    {


                    }
                }
                sr2 = new StreamReader(fs2);
                
                string linea2;
                Int32 cont = 0;
                
                while ((linea2 = sr2.ReadLine()) != null)
                {
                    if (cont < cantidad_filas_por_archivo)
                    {


                        if (cont > 0)
                        {
                            info_retornar = op_tex.concatenacion_caracter_separacion(info_retornar, linea2, G_caracter_separacion_funciones_espesificas[3]);
                        }
                        cont++;
                    }
                }

                i = i + cont;
                //fin for total ids----------------------------------------------------
                
                sr2.Close();
                fs2.Close();
                
            }
            sr.Close();
            fs.Close();

            G_solo_para_consultas_relacionadas_encontrar_el_id = info_retornar.Split(G_caracter_separacion_funciones_espesificas[3][0]);
            return info_retornar;
        }


        public string LEER_SOLO_PROG(string datos)
        {
            string info_a_retornar = "";
            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            //PARAMETROS---------------------------------------------------------------------------
            string direccion_archivo = datos_epliteados[0];
            string pos_string = null;
            if (datos_epliteados.Length >= 2)
            {
                if (datos_epliteados[1] != "")
                {
                    pos_string = datos_epliteados[1];
                }
            }
            string caracter_separacion = G_caracter_separacion[0];
            if (datos_epliteados.Length >= 3)
            {
                if (datos_epliteados[2] != "")
                {
                    caracter_separacion = datos_epliteados[2];
                }
            }



            //FIN PARAMETROS-----------------------------------------------------------------------

            ArrayList linea = new ArrayList();
            ArrayList resultado = new ArrayList();
            string[] pos_split;
            int[] posiciones;
            string palabra = "";


            FileStream fs = null;
            StreamReader sr = null;
            while (fs == null)
            {
                try
                {
                    fs = new FileStream(direccion_archivo, FileMode.Open, FileAccess.ReadWrite);
                }
                catch
                {


                }
            }
            sr = new StreamReader(fs);






            if (pos_string == null)
            {

                while ((palabra = sr.ReadLine()) != null)
                {
                    if (palabra != "")
                    {
                        linea.Add(palabra);
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


                for (int i = 0; (palabra = sr.ReadLine()) != null; i++)
                {
                    string[] spl_linea = palabra.Split(caracter_separacion[0]);

                    palabra = "";
                    for (int j = 0; j < posiciones.Length; j++)
                    {
                        palabra = op_tex.concatenacion_caracter_separacion(palabra, spl_linea[posiciones[j]], G_caracter_separacion_funciones_espesificas[4]);

                    }
                    resultado.Add(palabra);
                }
                sr.Close();
                fs.Close();

                for (int mnm = 0; mnm < resultado.Count; mnm++)
                {
                    info_a_retornar = op_tex.concatenacion_caracter_separacion(info_a_retornar, "" + resultado[mnm], G_caracter_separacion_funciones_espesificas[4]);

                }
                return info_a_retornar;
            }

            sr.Close();
            fs.Close();

            for (int mnm = 0; mnm < linea.Count; mnm++)
            {
                info_a_retornar = op_tex.concatenacion_caracter_separacion(info_a_retornar, "" + linea[mnm], G_caracter_separacion_funciones_espesificas[3]);

            }
            return info_a_retornar;
        }


        public string INCREMENTA_CELDA(string datos, FileStream fs = null)
        {
            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);


            string direccion_archivo = datos_epliteados[0];
            int num_column_comp = Convert.ToInt32(datos_epliteados[1]);
            string comparar = datos_epliteados[2];
            string numero_columnas_editar = datos_epliteados[3];
            string cantidad_a_sumar = datos_epliteados[4];
            string caracter_separacion = datos_epliteados[5];
            if (datos_epliteados[5] == "")
            {
                caracter_separacion = G_caracter_separacion[0];
            }



            StreamReader sr = null;

            if (fs == null)
            {


                Crear_archivo_y_directorio(direccion_archivo);



                

                while (fs == null)
                {
                    try
                    {
                        fs = new FileStream(direccion_archivo, FileMode.Open, FileAccess.ReadWrite);
                    }
                    catch
                    {


                    }
                }
            }

            sr = new StreamReader(fs);
            
            
            StreamWriter sw = new StreamWriter(fs);
            
            string exito_o_fallo;


            string concatenador_temporal = "";

            try
            {

                while (sr.Peek() >= 0)//verificamos si hay mas lineas a leer
                {
                    string linea = sr.ReadLine();//leemos linea y lo guardamos en linea
                    if (linea != null)
                    {
                        string[] palabra = linea.Split(caracter_separacion[0]);

                        if (palabra[num_column_comp] == comparar)
                        {
                            string linea_editada = "";
                            string[] columnas_editar = numero_columnas_editar.Split(caracter_separacion[0]);
                            string[] cantidades_sumara = cantidad_a_sumar.Split(caracter_separacion[0]);

                            for (int i = 0; i < columnas_editar.Length; i++)
                            {
                                palabra[Convert.ToInt64(columnas_editar[i])] = "" + (Convert.ToDouble(palabra[Convert.ToInt64(columnas_editar[i])]) + Convert.ToDouble(cantidades_sumara[i]));//esta largo lo se. pero significa que a la columna a editar le va a sumar la cantidad señalada
                            }
                            for (int i = 0; i < palabra.Length; i++)
                            {
                                linea_editada = linea_editada + palabra[i] + caracter_separacion;
                            }
                            linea_editada = linea_editada.TrimEnd(caracter_separacion[0]);
                            concatenador_temporal = op_tex.concatenacion_caracter_separacion(concatenador_temporal, linea_editada, G_caracter_separacion_funciones_espesificas[4]);
                            

                        }
                        else
                        {

                            concatenador_temporal = op_tex.concatenacion_caracter_separacion(concatenador_temporal, linea, G_caracter_separacion_funciones_espesificas[4]);
                            
                        }
                    }
                }
                string[] todo_el_archivo = concatenador_temporal.Split(G_caracter_separacion_funciones_espesificas[4][0]);
                fs.SetLength(0);//esto borra todo el contenido del archivo
                for (int i = 0; i < todo_el_archivo.Length; i++)
                {
                    sw.WriteLine(todo_el_archivo);
                }

                sr.Close();
                sw.Close();
                fs.Close();
                exito_o_fallo = "1" + G_caracter_para_confirmacion_o_error[0] + "exito";
                
                
            }
            catch (Exception error)
            {
                sr.Close();
                sw.Close();
                fs.Close();
                exito_o_fallo = "0" + G_caracter_para_confirmacion_o_error[0] + "error:" + error;
                
            }
            return exito_o_fallo;
        }


        public string ELIMINAR_FILA_PARA_MULTIPLES_PROGRAMAS_SOLO_PROG(string datos)
        {
            string info_a_retornar = "2" + G_caracter_para_confirmacion_o_error[0] + "no_se_encontro_info_a_eliminar";

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            //PARAMETROS---------------------------------------------------------------------------
            string direccion_archivo = datos_epliteados[0];

            Int64 columna_a_comparar = 0;
            if (datos_epliteados.Length >= 2)
            {
                if (datos_epliteados[1] != "")
                {
                    columna_a_comparar = Convert.ToInt64(datos_epliteados[1]);
                }
            }
            string comparar = null;
            if (datos_epliteados.Length >= 3)
            {
                if (datos_epliteados[2] != "")
                {
                    comparar = datos_epliteados[2];
                }
            }

            object caracter_separacion_objeto = null;
            if (datos_epliteados.Length >= 4)
            {
                if (datos_epliteados[3] != "")
                {
                    caracter_separacion_objeto = datos_epliteados[3];
                }
            }

            Int64 donde_inica = 0;
            if (datos_epliteados.Length >= 5)
            {
                if (datos_epliteados[4] != "")
                {
                    donde_inica = Convert.ToInt64(datos_epliteados[4]);
                }
            }


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
                    CHEQUEO_ERROR_TRY_SOLO_PROG(direccion_archivo, e, checador[1]);
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
                            else
                            {
                                info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + "eliminacion_exitosa";
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

            return info_a_retornar;
        }

        public string EDITAR_FILA_ESPESIFICA_SIN_ARREGLO_GG_SOLO_PROG(string datos)
        {
            string info_a_retornar;

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            //PARAMETROS---------------------------------------------------------------------------
            string direccion_archivo = datos_epliteados[0];

            Int64 num_fila = 0;
            if (datos_epliteados.Length >= 2)
            {
                if (datos_epliteados[1] != "")
                {
                    num_fila = Convert.ToInt64(datos_epliteados[1]);
                }
            }

            string editar_info = null;
            if (datos_epliteados.Length >= 3)
            {
                if (datos_epliteados[2] != "")
                {
                    editar_info = datos_epliteados[2];
                }
            }


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

                    CHEQUEO_ERROR_TRY_SOLO_PROG(direccion_archivo, e, checador[1]);
                }
            }
            string dir_tem = direccion_archivo.Replace(".TXT", "_TEM.TXT");
            StreamWriter sw = new StreamWriter(dir_tem, true);
            

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
                info_a_retornar = "1)exito";
                sr.Close();
                sw.Close();
                File.Delete(direccion_archivo);//borramos el archivo original
                File.Move(dir_tem, direccion_archivo);//renombramos el archivo temporal por el que tenia el original


            }
            catch (Exception error)
            {
                sr.Close();
                sw.Close();
                info_a_retornar = "2)error:" + error;
                File.Delete(dir_tem);//borramos el archivo original


            }
            return info_a_retornar;
        }



        public void CHEQUEO_ERROR_TRY_SOLO_PROG(string direccionArchivo, Exception e, string numero_chequeo)
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


        public string EXTRAER_SEPARADO_CARPETAS_NOMBREARCHIVO_EXTENCION_SOLO_PROG(string datos)
        {
            string info_a_retornar = "";
            

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            //PARAMETROS---------------------------------------------------------------------------
            string direccion_archivo = datos_epliteados[0];

            //fin parametros-----------------------------------------------------------------------------
            string[] direccion_esp = direccion_archivo.Split('\\');
            string[] nom_ext_esp = direccion_esp[direccion_esp.Length - 1].Split('.');
            if (nom_ext_esp.Length > 1)
            {
                string carpetas = op_tex.joineada_paraesida_SIN_NULOS_y_quitador_de_extremos_del_string(direccion_archivo, '\\', 1);
                string nombre = nom_ext_esp[0];
                string extencion = nom_ext_esp[1];
                info_a_retornar = carpetas + G_caracter_separacion_funciones_espesificas[4] + nombre + G_caracter_separacion_funciones_espesificas[4] + extencion;
            }
            else
            {

            }


            return info_a_retornar;
        }





        public string generar_ruta_archivo(string id, string cantidad_ids_por_archivo_potenciade10 = "100")
        {
            string carpetas = "";
            Int64 potencia = Convert.ToInt64(cantidad_ids_por_archivo_potenciade10);
            string base_num = "";

            for (int i = 0; i < cantidad_ids_por_archivo_potenciade10.Length - 1; i++) 
            {
                base_num = base_num+ cantidad_ids_por_archivo_potenciade10[i];
            }

            for (int i = 2; i <= id.Length; i++)
            {
                carpetas += potencia + "\\";  // añadimos la potencia actual a la ruta de carpetas
                potencia *= Convert.ToInt32(base_num);  // multiplicamos la potencia por 10 para la siguiente iteración
            }

            // generación del nombre del archivo
            string nom_archivo_donde_va = "";
            int cantidad_de_ceros = cantidad_ids_por_archivo_potenciade10.Length - 1;

            for (int i = 0; i < id.Length - cantidad_de_ceros; i++)  // excluimos los últimos dos elementos del array
            {
                nom_archivo_donde_va = nom_archivo_donde_va + id[i];
            }

            string temp = "";
            for (int i = 0; i < cantidad_de_ceros; i++)
            {
                temp = temp + "0";
            }
            nom_archivo_donde_va = nom_archivo_donde_va + temp +".txt";  // agregamos "00.txt" al final

            // devolvemos la ruta completa
            return carpetas + nom_archivo_donde_va;
        }

        private string orden_informacion(List<string> resultados, string orden = "ID_TOT|COLUMNAS|CANT_POR_ARCH", string caracter_separacion = null)
        {
            string info_a_retornar = "";
            
            if (caracter_separacion == null)
            {
                caracter_separacion = G_caracter_separacion[0];
            }
            string[] orden_espliteado = orden.Split(caracter_separacion[0]);
            

            // Recorremos las líneas procesadas

            for (int k = 0; k < orden_espliteado.Length; k++)
            {


                bool encontro_info = false;
                // Aquí comparamos cada valor dividido con el arreglo de comparación
                for (int i = 0; i < resultados.Count; i++)
                {
                    // Dividir la línea actual en partes utilizando el separador
                    string[] linea_esp = resultados[i].Split(caracter_separacion[0]);

                    if (linea_esp[0] == orden_espliteado[k])
                    {
                        // Si se encuentra una coincidencia, hacer algo
                        info_a_retornar = op_tex.concatenacion_caracter_separacion(info_a_retornar, linea_esp[1], caracter_separacion[0]);
                        encontro_info = true;
                        break;
                    }
                }
                if (encontro_info == false)
                {
                    info_a_retornar = info_a_retornar + caracter_separacion;
                }
            }



            return info_a_retornar;
        }


        //fin clase---------------------------------------------------------------------------
    }
}
