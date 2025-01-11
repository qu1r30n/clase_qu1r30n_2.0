using CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE_QU1R30N_2.sin_internet.sin_formulario.procesos
{
    internal class _01_proc_tex_base
    {
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;
        operaciones_textos op_tex = new operaciones_textos();

        string[] G_solo_para_consultas_relacionadas_encontrar_el_id;


        public string Crear_archivo_y_directorio(string datos)
        {
            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            string direccion_archivo = datos_epliteados[0];
            string valor_inicial = datos_epliteados[1];
            string[] filas_iniciales = datos_epliteados[2].Split(G_caracter_separacion_funciones_espesificas[4][0]);
            
            


            
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

        public string Agregar(string datos)
        {
            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            string direccion_archivos = datos_epliteados[0];
            string agregando = datos_epliteados[1];


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




        public string Agregar_info_dividida(string datos)
        {
            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            //parametros------------------------------------------------------------------
            string direccion_archivos = datos_epliteados[0];
            string agregando = datos_epliteados[1];
            string nom_columnas_si_no_existe_archivo = datos_epliteados[2];
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
            




            string linea;
            string id_total = null;
            string columnas = null;
            string cantidad_filas_por_archivo = "100";
            while ((linea = sr.ReadLine()) != null)
            {

                string[] linea_esp = linea.Split(G_caracter_separacion[0][0]);

                if (linea_esp[0] == "ID_TOT")
                {
                    id_total = linea_esp[1];

                }
                if (linea_esp[0] == "COLUMNAS")
                {
                    columnas = linea_esp[1].Replace(G_caracter_separacion[1], G_caracter_separacion[0]);
                }
                if (linea_esp[0] == "CANT_POR_ARCH")
                {
                    cantidad_filas_por_archivo = linea_esp[1];

                }

            }



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
                    Incrementa_celda(datos_enviar,fs);

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

            string direccion_archivos = datos_epliteados[0];


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





            return info_retornar;
        }


        public string leer_info_dividida(string datos)
        {
            string info_retornar = "";

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            string direccion_archivos = datos_epliteados[0];

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


        public string Incrementa_celda(string datos, FileStream fs = null)
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


        //fin clase---------------------------------------------------------------------------
    }
}
