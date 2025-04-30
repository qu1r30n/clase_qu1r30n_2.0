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

        var_fun_GG vf_GG = new var_fun_GG();

        principal enl_princ = new principal();

        public string Crear_archivo_y_directorio(string datos)
        {
            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);
            //parametros-------------------------------------------------------------------------
            string direccion_archivo = datos_epliteados[0];

            string valor_inicial = null;
            if (datos_epliteados.Length >= 2)
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

            //creando carpetas
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



                    sw.Close();
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

                string[] info_archivo = LEER_SOLO_PROG(direccion_archivo).Split(G_caracter_separacion[0][0]);

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

        public string Agregar_sino_existe_info_dividida(string datos)
        {
            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            //parametros------------------------------------------------------------------
            string direccion_archivos = datos_epliteados[0];

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

            string texto_a_agregar_si_no_esta = null;
            if (datos_epliteados.Length >= 4)
            {
                if (datos_epliteados[1] != "")
                {
                    texto_a_agregar_si_no_esta = datos_epliteados[3];
                }

            }

            string nom_columnas_si_no_existe_archivo = null;
            if (datos_epliteados.Length >= 5)
            {
                if (datos_epliteados[2] != "")
                {
                    nom_columnas_si_no_existe_archivo = datos_epliteados[4];
                }

            }
            //fin parametros-------------------------------------------------------------

            string[] temp_colum = texto_a_agregar_si_no_esta.Split(G_caracter_separacion[0][0]);

            Crear_archivo_y_directorio(direccion_archivos + G_caracter_separacion_funciones_espesificas[3] + "tipo_info|info" + G_caracter_separacion_funciones_espesificas[3] + "ID_TOT|0\nCOLUMNAS|" + nom_columnas_si_no_existe_archivo + "\nCANT_POR_ARCH|" + var_fun_GG.GG_cantidado_por_archivo);

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

            while ((linea = sr.ReadLine()) != null)
            {
                lista_datos.Add(linea);
            }

            sr.Close();
            fs.Close();

            string[] resul = ORDEN_INFORMACION_SOLO_PROG(lista_datos).Split(G_caracter_separacion[0][0]);
            string id_total = resul[0];
            string columnas = resul[1];
            string cantidad_filas_por_archivo = resul[2];


            string resultado_lect = LEER_INFO_DIVIDIDA(direccion_archivos);
            int id_del_producto_si_encontro = -1;
            string info_del_id = "";
            if (resultado_lect != "")
            {
                string[] res_lect = resultado_lect.Split(G_caracter_separacion_funciones_espesificas[3][0]);

                for (int i = 0; i < res_lect.Length; i++)
                {
                    string[] fila_esplit = res_lect[i].Split(G_caracter_separacion[0][0]);
                    if (fila_esplit[num_column_comp] == comparar)
                    {
                        id_del_producto_si_encontro = i + 1;
                        info_del_id = res_lect[i];
                        break;
                    }
                }

            }

            //si no se encontro el producto se agrega
            if (id_del_producto_si_encontro == -1)
            {

                string dir_info_bas = direccion_extencion_espliteada[0] + "_DAT\\" + GENERAR_RUTA_ARCHIVO(id_total + G_caracter_separacion_funciones_espesificas[3] + cantidad_filas_por_archivo);

                string res_crear_archivo = Crear_archivo_y_directorio(dir_info_bas + G_caracter_separacion_funciones_espesificas[3] + columnas + G_caracter_separacion_funciones_espesificas[3] + texto_a_agregar_si_no_esta);

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

                        sw.WriteLine((Convert.ToInt64(id_total) + 1) + G_caracter_separacion[0] + texto_a_agregar_si_no_esta);

                        string datos_enviar = direccion_archivos + G_caracter_separacion_funciones_espesificas[3] + "0" + G_caracter_separacion_funciones_espesificas[3] + "ID_TOT" + G_caracter_separacion_funciones_espesificas[3] + "1" + G_caracter_separacion_funciones_espesificas[3] + "1" + G_caracter_separacion_funciones_espesificas[3] + "";
                        sw.Close();
                        sr.Close();
                        fs.Close();

                        string[] res = INCREMENTA_CELDA_SOLO_PROG(datos_enviar).Split(G_caracter_para_confirmacion_o_error[0][0]);

                        if (res[0] == "1")
                        {
                            string[] cantidad_de_columnas_editadas = res[1].Split(G_caracter_separacion[0][0]);
                            string[] id_spliteado = cantidad_de_columnas_editadas[0].Split(G_caracter_separacion[1][0]);
                            return "1" + G_caracter_para_confirmacion_o_error[0] + id_spliteado[1] + G_caracter_separacion[0] + texto_a_agregar_si_no_esta;
                        }





                        return "1" + G_caracter_para_confirmacion_o_error[0] + texto_a_agregar_si_no_esta;
                    }
                    catch (Exception)
                    {

                        sw.Close();
                        sr.Close();
                        fs.Close();
                        return "0" + G_caracter_para_confirmacion_o_error[0] + "error no pudo guardar";
                    }

                }
            }

            sr.Close();
            fs.Close();
            return "0" + G_caracter_para_confirmacion_o_error[0] + id_del_producto_si_encontro + G_caracter_para_confirmacion_o_error[0] + "ya existe no se guardo" + G_caracter_para_confirmacion_o_error[0] + info_del_id;
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

            Crear_archivo_y_directorio(direccion_archivos + G_caracter_separacion_funciones_espesificas[3] + "tipo_info|info" + G_caracter_separacion_funciones_espesificas[3] + "ID_TOT|0\nCOLUMNAS|" + nom_columnas_si_no_existe_archivo + "\nCANT_POR_ARCH|" + var_fun_GG.GG_cantidado_por_archivo);

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

            string resul = ORDEN_INFORMACION_SOLO_PROG(lista_datos);


            string dir_info_bas = direccion_extencion_espliteada[0] + "_DAT\\" + GENERAR_RUTA_ARCHIVO(id_total + G_caracter_separacion_funciones_espesificas[3] + cantidad_filas_por_archivo);

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
                    string inf_agregar = (Convert.ToInt64(id_total) + 1) + G_caracter_separacion[0] + agregando;
                    sw.WriteLine(inf_agregar);

                    string datos_enviar = direccion_archivos + G_caracter_separacion_funciones_espesificas[3] + "0" + G_caracter_separacion_funciones_espesificas[3] + "ID_TOT" + G_caracter_separacion_funciones_espesificas[3] + "1" + G_caracter_separacion_funciones_espesificas[3] + "1" + G_caracter_separacion_funciones_espesificas[3] + "";
                    sw.Close();
                    sr.Close();
                    fs.Close();

                    INCREMENTA_CELDA_SOLO_PROG(datos_enviar);




                    return "1" + G_caracter_para_confirmacion_o_error[0] + inf_agregar;
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

        public string seleccionar_id_info_dividida(string datos)
        {
            string info_retornar = "";

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            //parametros------------------------------------------------------------------------------------
            string direccion_archivos = datos_epliteados[0];
            string id = datos_epliteados[1];

            //fin parametros-----------------------------------------------------------------------------

            string[] direccion_espliteada = direccion_archivos.Split('.');
            string carpetas = direccion_espliteada[0] + "_DAT";

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

            string datos_ordenados_configuracion = ORDEN_INFORMACION_SOLO_PROG(filas_configuaracion, "CANT_POR_ARCH");
            string[] datos_config_esp = datos_ordenados_configuracion.Split(G_caracter_separacion[0][0]);

            string cantidad_por_archivo = datos_config_esp[0];
            string direccion = carpetas + "\\" + GENERAR_RUTA_ARCHIVO(id + G_caracter_separacion_funciones_espesificas[3] + cantidad_por_archivo);






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
            Int64 posicion_id_archivo = 0;
            if (id.Length >= 2)
            {
                posicion_id_archivo = Convert.ToInt64(id[0] + "" + id[1]);
            }
            else
            {
                posicion_id_archivo = Convert.ToInt64(id[0] + "");
            }

            Int64 cont = 0;
            while ((linea2 = sr2.ReadLine()) != null)
            {

                if (posicion_id_archivo == cont)
                {

                    info_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + linea2;
                    encontro_informacion = true;
                    break;
                }

                cont++;

            }
            if (encontro_informacion == false)
            {
                info_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no_se_encontro_informacion";
            }


            fs2.Close();
            sr2.Close();
            return info_retornar;
        }

        public string seleccionar_id_info_dividida_extrae_info_archivo_y_fila(string datos)
        {
            string info_retornar = "";

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            //parametros------------------------------------------------------------------------------------
            string direccion_archivos = datos_epliteados[0];
            string id = datos_epliteados[1];

            //fin parametros-----------------------------------------------------------------------------

            string[] direccion_espliteada = direccion_archivos.Split('.');
            string carpetas = direccion_espliteada[0] + "_DAT";

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

            string datos_ordenados_configuracion = ORDEN_INFORMACION_SOLO_PROG(filas_configuaracion, "CANT_POR_ARCH");
            string[] datos_config_esp = datos_ordenados_configuracion.Split(G_caracter_separacion[0][0]);

            string cantidad_por_archivo = datos_config_esp[0];
            string direccion = carpetas + "\\" + GENERAR_RUTA_ARCHIVO(id + G_caracter_separacion_funciones_espesificas[3] + cantidad_por_archivo);






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
            Int64 posicion_id_archivo = 0;
            if (id.Length >= 2)
            {
                posicion_id_archivo = Convert.ToInt64(id[0] + "" + id[1]);
            }
            else
            {
                posicion_id_archivo = Convert.ToInt64(id[0] + "");
            }

            Int64 cont = 0;
            while ((linea2 = sr2.ReadLine()) != null)
            {

                if (posicion_id_archivo == cont)
                {

                    info_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + linea2 + G_caracter_para_confirmacion_o_error[0] + direccion + G_caracter_para_confirmacion_o_error[0] + cont;
                    encontro_informacion = true;
                    break;
                }

                cont++;

            }
            if (encontro_informacion == false)
            {
                info_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no_se_encontro_informacion";
            }


            fs2.Close();
            sr2.Close();
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

            string datos_ordenados_configuracion = ORDEN_INFORMACION_SOLO_PROG(filas_configuaracion, "CANT_POR_ARCH");
            string[] datos_config_esp = datos_ordenados_configuracion.Split(G_caracter_separacion[0][0]);

            string cantidad_por_archivo = datos_config_esp[0];








            string direccion = carpetas + "\\" + GENERAR_RUTA_ARCHIVO(id + G_caracter_separacion_funciones_espesificas[3] + cantidad_por_archivo);

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

            string datos_ordenados_configuracion = ORDEN_INFORMACION_SOLO_PROG(filas_configuaracion, "CANT_POR_ARCH");
            string[] datos_config_esp = datos_ordenados_configuracion.Split(G_caracter_separacion[0][0]);

            string cantidad_por_archivo = datos_config_esp[0];
            string direccion = carpetas + "\\" + GENERAR_RUTA_ARCHIVO(id + G_caracter_separacion_funciones_espesificas[3] + cantidad_por_archivo);

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
            string carpetas = temp[0] + "_DAT\\";


            string linea;
            Int64 id_total = -1;
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



            for (int i = 1; i <= id_total; i++)
            {
                string ruta_archivo = GENERAR_RUTA_ARCHIVO("" + i + G_caracter_separacion_funciones_espesificas[3] + cantidad_filas_por_archivo + "");
                FileStream fs2 = null;
                StreamReader sr2 = null;

                while (fs2 == null)
                {
                    try
                    {
                        fs2 = new FileStream(carpetas + ruta_archivo, FileMode.Open, FileAccess.ReadWrite);
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

            //G_solo_para_consultas_relacionadas_encontrar_el_id = info_retornar.Split(G_caracter_separacion_funciones_espesificas[3][0]);
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
                pos_split = pos_string.Split(G_caracter_separacion[0][0]);
                posiciones = new int[pos_split.Length];
                for (int i = 0; i < posiciones.Length; i++)
                {
                    posiciones[i] = Convert.ToInt32(pos_split[i]);
                }


                for (int i = 0; (palabra = sr.ReadLine()) != null; i++)
                {
                    string[] spl_linea = palabra.Split(G_caracter_separacion[0][0]);

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
                info_a_retornar = op_tex.concatenacion_caracter_separacion(info_a_retornar, "" + linea[mnm], G_caracter_separacion_funciones_espesificas[4]);

            }
            return info_a_retornar;
        }

        public string INCREMENTA_CELDA_ID_FILA_SOLO_PROG(string datos)
        {
            string info_retornar = "";

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            //parametros------------------------------------------------------------------------------------
            string direccion_archivos = datos_epliteados[0];


            string id = null;
            if (datos_epliteados.Length >= 2)
            {
                if (datos_epliteados[1] != "")
                {
                    id = datos_epliteados[1];
                }
            }

            string columnas_a_incrementar = "";
            if (datos_epliteados.Length >= 3)
            {
                if (datos_epliteados[2] != "")
                {
                    columnas_a_incrementar = datos_epliteados[2];
                }
            }

            string cantidades_a_incrementar = "";
            if (datos_epliteados.Length >= 4)
            {
                if (datos_epliteados[3] != "")
                {
                    cantidades_a_incrementar = datos_epliteados[3];
                }
            }




            //fin parametros-----------------------------------------------------------------------------

            string[] direccion_espliteada = direccion_archivos.Split('.');
            string carpetas = direccion_espliteada[0] + "_DAT";

            FileStream fs = null;
            StreamReader sr = null;
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
            sr = new StreamReader(fs);
            sw = new StreamWriter(fs);

            string linea;
            List<string> lineas = new List<string>();
            // Lee cada línea del archivo hasta el final
            while ((linea = sr.ReadLine()) != null)
            {
                // Aquí puedes procesar cada línea
                lineas.Add(linea);
            }



            Int64 posicion_id_archivo = 0;
            if (id.Length >= 2)
            {
                posicion_id_archivo = Convert.ToInt64(id[0] + "" + id[1]);
            }
            else
            {
                posicion_id_archivo = Convert.ToInt64(id[0] + "");
            }





            bool encontro_informacion = false;
            fs.Seek(0, SeekOrigin.Begin);

            for (int j = 0; j < lineas.Count; j++)
            {
                string linea2 = lineas[j];
                if (posicion_id_archivo == j)
                {
                    string[] producto_espliteado = linea2.Split(G_caracter_separacion[0][0]);
                    string[] colum_a_editar = columnas_a_incrementar.Split(G_caracter_separacion_funciones_espesificas[4][0]);
                    string[] cantidades_a_editar = cantidades_a_incrementar.Split(G_caracter_separacion_funciones_espesificas[4][0]);
                    for (int i = 0; i < colum_a_editar.Length; i++)
                    {
                        Int32 columna_int = Convert.ToInt32(colum_a_editar[i]);
                        producto_espliteado[columna_int] = "" + (Convert.ToDouble(producto_espliteado[columna_int]) + Convert.ToDouble(cantidades_a_editar[i]));
                    }
                    string producto_editado = string.Join(G_caracter_separacion[0], producto_espliteado);
                    sw.WriteLine(producto_editado);
                    sw.Flush();
                    encontro_informacion = true;
                    info_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + producto_editado;

                }

                else
                {
                    sw.WriteLine(linea2);
                    sw.Flush();
                }

            }

            if (encontro_informacion == false)
            {
                info_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no_se_encontro_informacion";
            }

            sw.Close();
            sr.Close();
            fs.Close();



            return info_retornar;
        }

        public string INCREMENTA_CELDA_ID_INFO_DIVIDIDA(string datos)
        {
            string info_retornar = "";

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            //parametros------------------------------------------------------------------------------------
            string direccion_archivos = datos_epliteados[0];


            string id = null;
            if (datos_epliteados.Length >= 2)
            {
                if (datos_epliteados[1] != "")
                {
                    id = datos_epliteados[1];
                }
            }

            string columnas_a_incrementar = "";
            if (datos_epliteados.Length >= 3)
            {
                if (datos_epliteados[2] != "")
                {
                    columnas_a_incrementar = datos_epliteados[2];
                }
            }

            string cantidades_a_incrementar = "";
            if (datos_epliteados.Length >= 4)
            {
                if (datos_epliteados[3] != "")
                {
                    cantidades_a_incrementar = datos_epliteados[3];
                }
            }




            //fin parametros-----------------------------------------------------------------------------

            string[] direccion_espliteada = direccion_archivos.Split('.');
            string carpetas = direccion_espliteada[0] + "_DAT";

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

            string datos_ordenados_configuracion = ORDEN_INFORMACION_SOLO_PROG(filas_configuaracion, "CANT_POR_ARCH");
            string[] datos_config_esp = datos_ordenados_configuracion.Split(G_caracter_separacion[0][0]);

            string cantidad_por_archivo = datos_config_esp[0];
            string direccion = carpetas + "\\" + GENERAR_RUTA_ARCHIVO(id + G_caracter_separacion_funciones_espesificas[3] + cantidad_por_archivo);






            FileStream fs2 = null;
            StreamReader sr2 = null;
            StreamWriter sw2 = null;
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
            sw2 = new StreamWriter(fs2);



            Int64 posicion_id_archivo = 0;
            if (id.Length >= 2)
            {
                posicion_id_archivo = Convert.ToInt64(id[0] + "" + id[1]);
            }
            else
            {
                posicion_id_archivo = Convert.ToInt64(id[0] + "");
            }





            List<string> lineas = new List<string>();
            bool encontro_informacion = false;

            string fila = "";
            while ((fila = sr2.ReadLine()) != null)
            {
                lineas.Add(fila);
            }

            fs2.Seek(0, SeekOrigin.Begin);

            for (int j = 0; j < lineas.Count; j++)
            {
                string linea2 = lineas[j];
                if (posicion_id_archivo == j)
                {

                    columnas_a_incrementar = columnas_a_incrementar.Replace(G_caracter_separacion_funciones_espesificas[5], G_caracter_separacion[0]);
                    string[] colum_a_editar = columnas_a_incrementar.Split(G_caracter_separacion_funciones_espesificas[4][0]);
                    string[] cant_a_inc = cantidades_a_incrementar.Split(G_caracter_separacion_funciones_espesificas[4][0]);
                    string producto_editado = linea2;
                    for (int i = 0; i < colum_a_editar.Length; i++)
                    {
                        producto_editado = op_tex.editar_inc_agregar_edicion_profunda_multiple_comparacion_final_string(producto_editado, colum_a_editar[i], cant_a_inc[i], "", "1");
                    }



                    sw2.WriteLine(producto_editado);
                    sw2.Flush();
                    encontro_informacion = true;
                    info_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + producto_editado;

                }

                else
                {
                    sw2.WriteLine(linea2);
                    sw2.Flush();
                }

            }

            if (encontro_informacion == false)
            {
                info_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no_se_encontro_informacion";
            }

            sw2.Close();
            sr2.Close();
            fs2.Close();



            return info_retornar;
        }

        public string INCREMENTA_CELDA_ID_INFO_DIVIDIDA_COPEA_CELDA_SI_ESTA_EN_0(string datos)
        {
            string info_retornar = "";

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            //parametros------------------------------------------------------------------------------------
            string direccion_archivos = datos_epliteados[0];


            string id = null;
            if (datos_epliteados.Length >= 2)
            {
                if (datos_epliteados[1] != "")
                {
                    id = datos_epliteados[1];
                }
            }

            string columnas_a_incrementar = "";
            if (datos_epliteados.Length >= 3)
            {
                if (datos_epliteados[2] != "")
                {
                    columnas_a_incrementar = datos_epliteados[2];
                }
            }

            string cantidades_a_incrementar = "";
            if (datos_epliteados.Length >= 4)
            {
                if (datos_epliteados[3] != "")
                {
                    cantidades_a_incrementar = datos_epliteados[3];
                }
            }

            string columna_a_copiar = "";
            if (datos_epliteados.Length >= 5)
            {
                if (datos_epliteados[4] != "")
                {
                    columna_a_copiar = datos_epliteados[4];
                }
            }


            //fin parametros-----------------------------------------------------------------------------

            string[] direccion_espliteada = direccion_archivos.Split('.');
            string carpetas = direccion_espliteada[0] + "_DAT";

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

            string datos_ordenados_configuracion = ORDEN_INFORMACION_SOLO_PROG(filas_configuaracion, "CANT_POR_ARCH");
            string[] datos_config_esp = datos_ordenados_configuracion.Split(G_caracter_separacion[0][0]);

            string cantidad_por_archivo = datos_config_esp[0];
            string direccion = carpetas + "\\" + GENERAR_RUTA_ARCHIVO(id + G_caracter_separacion_funciones_espesificas[3] + cantidad_por_archivo);






            FileStream fs2 = null;
            StreamReader sr2 = null;
            StreamWriter sw2 = null;
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
            sw2 = new StreamWriter(fs2);



            Int64 posicion_id_archivo = 0;
            if (id.Length >= 2)
            {
                posicion_id_archivo = Convert.ToInt64(id[0] + "" + id[1]);
            }
            else
            {
                posicion_id_archivo = Convert.ToInt64(id[0] + "");
            }





            List<string> lineas = new List<string>();
            bool encontro_informacion = false;

            string fila = "";
            while ((fila = sr2.ReadLine()) != null)
            {
                lineas.Add(fila);
            }

            fs2.Seek(0, SeekOrigin.Begin);

            for (int j = 0; j < lineas.Count; j++)
            {
                string linea2 = lineas[j];
                if (posicion_id_archivo == j)
                {

                    columnas_a_incrementar = columnas_a_incrementar.Replace(G_caracter_separacion_funciones_espesificas[5], G_caracter_separacion[0]);
                    string[] colum_a_editar = columnas_a_incrementar.Split(G_caracter_separacion_funciones_espesificas[4][0]);
                    string[] cant_a_inc = cantidades_a_incrementar.Split(G_caracter_separacion_funciones_espesificas[4][0]);
                    string[] columnas_a_cop= columna_a_copiar.Split(G_caracter_separacion_funciones_espesificas[4][0]);
                    string producto_editado = linea2;

                    bool decrementa_paquete = false;
                    int bultosCompletos_a_quitar = 0;
                    for (int i = 0; i < colum_a_editar.Length; i++)
                    {
                        string[] prod_esp = producto_editado.Split(G_caracter_separacion[0][0]);
                        
                        // Primero calculamos cuántos kilos tenemos en total (vendidos + kilos en el bulto abierto)
                        double kilosTotalesDisponibles = Convert.ToDouble(prod_esp[6]) + Convert.ToDouble(cant_a_inc[i]);
                        
                        if (kilosTotalesDisponibles <= 0 || prod_esp[Convert.ToInt32(colum_a_editar[i])] == "")
                        {
                            if ((kilosTotalesDisponibles * -1) > Convert.ToDouble(prod_esp[10]))
                            {
                                // Calcular cuántos bultos completos podemos formar
                                bultosCompletos_a_quitar = (int)(((kilosTotalesDisponibles) / Convert.ToDouble(prod_esp[10]))) + 1;

                            }

                            producto_editado = op_tex.editar_inc_agregar_edicion_profunda_multiple_comparacion_final_string(producto_editado, colum_a_editar[i], prod_esp[Convert.ToInt32(columnas_a_cop[i])], "", "0");
                            decrementa_paquete = true;
                        }
                        producto_editado = op_tex.editar_inc_agregar_edicion_profunda_multiple_comparacion_final_string(producto_editado, colum_a_editar[i], kilosTotalesDisponibles+"", "", "1");
                    }



                    sw2.WriteLine(producto_editado);
                    sw2.Flush();
                    encontro_informacion = true;
                    if (decrementa_paquete)
                    {
                        info_retornar = "2" + G_caracter_para_confirmacion_o_error[0] + producto_editado + G_caracter_para_confirmacion_o_error[0] + bultosCompletos_a_quitar;
                    }
                    else
                    {
                        info_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + producto_editado;
                    }

                }

                else
                {
                    sw2.WriteLine(linea2);
                    sw2.Flush();
                }

            }

            if (encontro_informacion == false)
            {
                info_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no_se_encontro_informacion";
            }

            sw2.Close();
            sr2.Close();
            fs2.Close();



            return info_retornar;
        }



        public string EDITAR_CELDA_ID_FILA_SOLO_PROG(string datos)
        {
            string info_retornar = "";

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            //parametros------------------------------------------------------------------------------------
            string direccion_archivos = datos_epliteados[0];


            string id = null;
            if (datos_epliteados.Length >= 2)
            {
                if (datos_epliteados[1] != "")
                {
                    id = datos_epliteados[1];
                }
            }

            string columnas_a_incrementar = "";
            if (datos_epliteados.Length >= 3)
            {
                if (datos_epliteados[2] != "")
                {
                    columnas_a_incrementar = datos_epliteados[2];
                }
            }

            string cantidades_a_incrementar = "";
            if (datos_epliteados.Length >= 4)
            {
                if (datos_epliteados[3] != "")
                {
                    cantidades_a_incrementar = datos_epliteados[3];
                }
            }




            //fin parametros-----------------------------------------------------------------------------

            string[] direccion_espliteada = direccion_archivos.Split('.');
            string carpetas = direccion_espliteada[0] + "_DAT";

            FileStream fs = null;
            StreamReader sr = null;
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
            sr = new StreamReader(fs);
            sw = new StreamWriter(fs);

            string linea;
            List<string> lineas = new List<string>();
            // Lee cada línea del archivo hasta el final
            while ((linea = sr.ReadLine()) != null)
            {
                // Aquí puedes procesar cada línea
                lineas.Add(linea);
            }



            Int64 posicion_id_archivo = 0;
            if (id.Length >= 2)
            {
                posicion_id_archivo = Convert.ToInt64(id[0] + "" + id[1]);
            }
            else
            {
                posicion_id_archivo = Convert.ToInt64(id[0] + "");
            }





            bool encontro_informacion = false;
            fs.Seek(0, SeekOrigin.Begin);

            for (int j = 0; j < lineas.Count; j++)
            {
                string linea2 = lineas[j];
                if (posicion_id_archivo == j)
                {
                    string[] producto_espliteado = linea2.Split(G_caracter_separacion[0][0]);
                    string[] colum_a_editar = columnas_a_incrementar.Split(G_caracter_separacion_funciones_espesificas[4][0]);
                    string[] cantidades_a_editar = cantidades_a_incrementar.Split(G_caracter_separacion_funciones_espesificas[4][0]);
                    for (int i = 0; i < colum_a_editar.Length; i++)
                    {
                        Int32 columna_int = Convert.ToInt32(colum_a_editar[i]);
                        producto_espliteado[columna_int] = cantidades_a_editar[i];
                    }
                    string producto_editado = string.Join(G_caracter_separacion[0], producto_espliteado);
                    sw.WriteLine(producto_editado);
                    sw.Flush();
                    encontro_informacion = true;
                    info_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + producto_editado;

                }

                else
                {
                    sw.WriteLine(linea2);
                    sw.Flush();
                }

            }

            if (encontro_informacion == false)
            {
                info_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no_se_encontro_informacion";
            }

            sw.Close();
            sr.Close();
            fs.Close();



            return info_retornar;
        }

        public string EDITAR_CELDA_ID_INFO_DIVIDIDA(string datos)
        {
            string info_retornar = "";

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            //parametros------------------------------------------------------------------------------------
            string direccion_archivos = datos_epliteados[0];


            string id = null;
            if (datos_epliteados.Length >= 2)
            {
                if (datos_epliteados[1] != "")
                {
                    id = datos_epliteados[1];
                }
            }

            string columnas_a_incrementar = "";
            if (datos_epliteados.Length >= 3)
            {
                if (datos_epliteados[2] != "")
                {
                    columnas_a_incrementar = datos_epliteados[2];
                }
            }

            string info_a_editar = "";
            if (datos_epliteados.Length >= 4)
            {
                if (datos_epliteados[3] != "")
                {
                    info_a_editar = datos_epliteados[3];
                }
            }




            //fin parametros-----------------------------------------------------------------------------

            string[] direccion_espliteada = direccion_archivos.Split('.');
            string carpetas = direccion_espliteada[0] + "_DAT";

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

            string datos_ordenados_configuracion = ORDEN_INFORMACION_SOLO_PROG(filas_configuaracion, "CANT_POR_ARCH");
            string[] datos_config_esp = datos_ordenados_configuracion.Split(G_caracter_separacion[0][0]);

            string cantidad_por_archivo = datos_config_esp[0];
            string direccion = carpetas + "\\" + GENERAR_RUTA_ARCHIVO(id + G_caracter_separacion_funciones_espesificas[3] + cantidad_por_archivo);






            FileStream fs2 = null;
            StreamReader sr2 = null;
            StreamWriter sw2 = null;
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
            sw2 = new StreamWriter(fs2);



            Int64 posicion_id_archivo = 0;
            if (id.Length >= 2)
            {
                posicion_id_archivo = Convert.ToInt64(id[0] + "" + id[1]);
            }
            else
            {
                posicion_id_archivo = Convert.ToInt64(id[0] + "");
            }





            List<string> lineas = new List<string>();
            bool encontro_informacion = false;

            string fila = "";
            while ((fila = sr2.ReadLine()) != null)
            {
                lineas.Add(fila);
            }

            fs2.Seek(0, SeekOrigin.Begin);

            for (int j = 0; j < lineas.Count; j++)
            {
                string linea2 = lineas[j];
                if (posicion_id_archivo == j)
                {
                    string[] producto_espliteado = linea2.Split(G_caracter_separacion[0][0]);
                    string[] colum_a_editar = columnas_a_incrementar.Split(G_caracter_separacion_funciones_espesificas[4][0]);
                    string[] cantidades_a_editar = info_a_editar.Split(G_caracter_separacion_funciones_espesificas[4][0]);
                    for (int i = 0; i < colum_a_editar.Length; i++)
                    {
                        Int32 columna_int = Convert.ToInt32(colum_a_editar[i]);
                        producto_espliteado[columna_int] = cantidades_a_editar[i];
                    }
                    string producto_editado = string.Join(G_caracter_separacion[0], producto_espliteado);
                    sw2.WriteLine(producto_editado);
                    sw2.Flush();
                    encontro_informacion = true;
                    info_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + producto_editado;

                }

                else
                {
                    sw2.WriteLine(linea2);
                    sw2.Flush();
                }

            }

            if (encontro_informacion == false)
            {
                info_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no_se_encontro_informacion";
            }

            sw2.Close();
            sr2.Close();
            fs2.Close();



            return info_retornar;
        }




        public string INCREMENTA_CELDA_BUSQUEDA_INFO_DIVIDIDA(string datos)
        {
            string inf_retornar = "";


            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS---------------------------------------------------------------------------
            string direccion_archivo = "";
            if (datos_epliteados.Length >= 1 && datos_epliteados[0] != "")
            {
                direccion_archivo = datos_epliteados[0];
            }

            string dato_a_buscar = "";
            if (datos_epliteados.Length >= 2 && datos_epliteados[1] != "")
            {
                dato_a_buscar = datos_epliteados[1];
            }

            string columnas = "0";
            if (datos_epliteados.Length >= 3 && datos_epliteados[2] != "")
            {
                columnas = datos_epliteados[2];
            }

            string columnas_a_incrementar = "";
            if (datos_epliteados.Length >= 4)
            {
                if (datos_epliteados[3] != "")
                {
                    columnas_a_incrementar = datos_epliteados[3];
                }
            }

            string cantidades_a_incrementar = "";
            if (datos_epliteados.Length >= 5)
            {
                if (datos_epliteados[4] != "")
                {
                    cantidades_a_incrementar = datos_epliteados[4];
                }
            }

            string agregar_si_no_lo_encuentra = "";
            if (datos_epliteados.Length >= 6)
            {
                if (datos_epliteados[5] != "")
                {
                    agregar_si_no_lo_encuentra = datos_epliteados[5];
                }
            }

            //------------------------------------------------------------

            //
            string[] operacion_incrementar = cantidades_a_incrementar.Split(G_caracter_separacion[0][0]);
            string op_inc = "";
            for (int j = 0; j < operacion_incrementar.Length; j++)
            {
                op_inc = op_tex.concatenacion_caracter_separacion(op_inc, "1", G_caracter_separacion[0]);
            }

            //busqueda


            busca_para_editar_y_agregar_en_archivos_divididos_si_los_encuentra_aplicar_funciones(direccion_archivo, dato_a_buscar, columnas, true,
                new Func<string, string>[]
                { op_tex.ARR_FUN_SOLO_TEXTO_editar_inc_agregar_edicion_profunda_multiple_comparacion_final_string }, //arreglo funciones
                new string[]
                { columnas_a_incrementar + G_caracter_separacion_funciones_espesificas[3] + cantidades_a_incrementar + G_caracter_separacion_funciones_espesificas[3] + G_caracter_separacion_funciones_espesificas[3] + op_inc },
                agregar_si_no_lo_encuentra
                );//arreglo de parametros


            return inf_retornar;
        }


        public string INCREMENTA_CELDA_SOLO_PROG(string datos, FileStream fs = null)
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
            string info_columnas_incrementadas = "";
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
                                info_columnas_incrementadas = op_tex.concatenacion_caracter_separacion(info_columnas_incrementadas, columnas_editar[i] + G_caracter_separacion[1] + palabra[Convert.ToInt64(columnas_editar[i])]);
                            }
                            for (int i = 0; i < palabra.Length; i++)
                            {
                                linea_editada = op_tex.concatenacion_caracter_separacion(linea_editada, palabra[i], caracter_separacion);
                            }

                            concatenador_temporal = op_tex.concatenacion_caracter_separacion(concatenador_temporal, linea_editada, G_caracter_separacion_funciones_espesificas[3]);


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
                    sw.WriteLine(todo_el_archivo[i]);
                }
                sw.Close();
                sr.Close();
                fs.Close();
                exito_o_fallo = "1" + G_caracter_para_confirmacion_o_error[0] + info_columnas_incrementadas;


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

        public string BUSCAR_INFO_DIVIDIDA(string datos)
        {
            string inf_retornar = "";


            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS---------------------------------------------------------------------------
            string direccion_archivo = "";
            if (datos_epliteados.Length >= 1 && datos_epliteados[0] != "")
            {
                direccion_archivo = datos_epliteados[0];
            }

            string dato_a_buscar = "";
            if (datos_epliteados.Length >= 2 && datos_epliteados[1] != "")
            {
                dato_a_buscar = datos_epliteados[1];
            }

            int columna = 0;
            if (datos_epliteados.Length >= 3 && datos_epliteados[2] != "")
            {
                int.TryParse(datos_epliteados[2], out columna);
            }

            string id_posicion_informacion = "";
            if (datos_epliteados.Length >= 4 && datos_epliteados[3] != "")
            {
                id_posicion_informacion = datos_epliteados[3];
            }
            //------------------------------------------------------------

            string[] todo_el_archivo = LEER_INFO_DIVIDIDA(direccion_archivo).Split(G_caracter_separacion_funciones_espesificas[3][0]);



            if (id_posicion_informacion != "")
            {
                int id_producto = Convert.ToInt32(id_posicion_informacion);
                string[] info_produc_esp = todo_el_archivo[id_producto].Split(G_caracter_separacion[0][0]);
                if (dato_a_buscar == info_produc_esp[columna])
                {
                    inf_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + todo_el_archivo[id_producto] + G_caracter_para_confirmacion_o_error[0] + id_producto;
                }
                else
                {
                    bool encontro_producto = false;
                    int indice_iniciar_busqueda = id_producto;
                    if (id_producto > 9) { indice_iniciar_busqueda = indice_iniciar_busqueda - 10; }
                    else { indice_iniciar_busqueda = G_donde_inicia_la_tabla; }

                    for (int i = indice_iniciar_busqueda; i < id_producto; i++)
                    {
                        string[] info_prod_bas = todo_el_archivo[i].Split(G_caracter_separacion[0][0]);
                        if (dato_a_buscar == info_prod_bas[columna])
                        {
                            inf_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + todo_el_archivo[i] + G_caracter_para_confirmacion_o_error[0] + i + 1;
                            encontro_producto = true;
                            break;
                        }
                    }
                    if (encontro_producto == false)
                    {

                        for (int i = G_donde_inicia_la_tabla; i < todo_el_archivo.Length; i++)
                        {
                            string[] info_prod_bas = todo_el_archivo[i].Split(G_caracter_separacion[0][0]);

                            if (dato_a_buscar == info_prod_bas[columna])
                            {
                                inf_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + todo_el_archivo[i] + G_caracter_para_confirmacion_o_error[0] + i;
                                encontro_producto = true;
                                break;
                            }
                        }


                    }
                    if (encontro_producto == false)
                    {
                        inf_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no encontro el producto";
                    }
                }
            }
            else
            {
                bool encontro_producto = false;
                for (int i = 0; i < todo_el_archivo.Length; i++)
                {
                    string[] info_produc_esp = todo_el_archivo[i].Split(G_caracter_separacion[0][0]);
                    if (dato_a_buscar == info_produc_esp[columna])
                    {
                        inf_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + todo_el_archivo[i] + G_caracter_para_confirmacion_o_error[0] + i;
                        encontro_producto = true;
                        break;
                    }
                }
                if (encontro_producto == false)
                {
                    inf_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no encontro el producto";
                }
            }

            return inf_retornar;
        }

        public string BUSCAR_SOLO_PROG(string datos)
        {
            string inf_retornar = "";


            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS---------------------------------------------------------------------------
            string direccion_archivo = "";
            if (datos_epliteados.Length >= 1 && datos_epliteados[0] != "")
            {
                direccion_archivo = datos_epliteados[0];
            }

            string dato_a_buscar = "";
            if (datos_epliteados.Length >= 2 && datos_epliteados[1] != "")
            {
                dato_a_buscar = datos_epliteados[1];
            }

            int columna = 0;
            if (datos_epliteados.Length >= 3 && datos_epliteados[2] != "")
            {
                int.TryParse(datos_epliteados[2], out columna);
            }

            string id_posicion_informacion = "";
            if (datos_epliteados.Length >= 4 && datos_epliteados[3] != "")
            {
                id_posicion_informacion = datos_epliteados[3];
            }



            string[] res_busq = SACAR_INDICE_DEL_ARREGLO_DE_DIRECCION_SOLO_PROG(direccion_archivo).Split(G_caracter_para_confirmacion_o_error[0][0]);
            int indice = Convert.ToInt32(res_busq[1]);

            if (id_posicion_informacion != "")
            {
                int id_producto = Convert.ToInt32(id_posicion_informacion);
                string[] info_produc_esp = var_fun_GG.GG_base_arreglo_de_arreglos[indice][id_producto].Split(G_caracter_separacion[0][0]);
                if (dato_a_buscar == info_produc_esp[columna])
                {
                    inf_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + var_fun_GG.GG_base_arreglo_de_arreglos[indice][id_producto] + G_caracter_para_confirmacion_o_error[0] + id_producto;
                }
                else
                {
                    bool encontro_producto = false;
                    int indice_iniciar_busqueda = id_producto;
                    if (id_producto > 9) { indice_iniciar_busqueda = indice_iniciar_busqueda - 10; }
                    else { indice_iniciar_busqueda = G_donde_inicia_la_tabla; }

                    for (int i = indice_iniciar_busqueda; i < id_producto; i++)
                    {
                        string[] info_prod_bas = var_fun_GG.GG_base_arreglo_de_arreglos[indice][i].Split(G_caracter_separacion[0][0]);
                        if (dato_a_buscar == info_prod_bas[columna])
                        {
                            inf_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + var_fun_GG.GG_base_arreglo_de_arreglos[indice][i] + G_caracter_para_confirmacion_o_error[0] + i;
                            encontro_producto = true;
                            break;
                        }
                    }
                    if (encontro_producto == false)
                    {

                        for (int i = G_donde_inicia_la_tabla; i < var_fun_GG.GG_base_arreglo_de_arreglos[indice].Length; i++)
                        {
                            string[] info_prod_bas = var_fun_GG.GG_base_arreglo_de_arreglos[indice][i].Split(G_caracter_separacion[0][0]);

                            if (dato_a_buscar == info_prod_bas[columna])
                            {
                                inf_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + var_fun_GG.GG_base_arreglo_de_arreglos[indice][i] + G_caracter_para_confirmacion_o_error[0] + i;
                                encontro_producto = true;
                                break;
                            }
                        }


                    }
                    if (encontro_producto == false)
                    {
                        inf_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no encontro el producto";
                    }
                }
            }
            else
            {
                bool encontro_producto = false;
                for (int i = 0; i < var_fun_GG.GG_base_arreglo_de_arreglos[indice].Length; i++)
                {
                    string[] info_produc_esp = var_fun_GG.GG_base_arreglo_de_arreglos[indice][i].Split(G_caracter_separacion[0][0]);
                    if (dato_a_buscar == info_produc_esp[columna])
                    {
                        inf_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + var_fun_GG.GG_base_arreglo_de_arreglos[indice][i] + G_caracter_para_confirmacion_o_error[0] + i;
                        encontro_producto = true;
                        break;
                    }
                }
                if (encontro_producto == false)
                {
                    inf_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no encontro el producto";
                }
            }



            return inf_retornar;
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


        public string SACAR_INDICE_DEL_ARREGLO_DE_DIRECCION_SOLO_PROG(string datos)
        {
            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            //PARAMETROS---------------------------------------------------------------------------
            string direccion_archivo = datos_epliteados[0];

            //----------------------------------------------------------------------------------
            if (File.Exists(direccion_archivo))
            {

                string num_indice_de_direccion = null;
                for (int i = G_donde_inicia_la_tabla; i < var_fun_GG.GG_dir_bd_y_valor_inicial_bidimencional.GetLength(0); i++)
                {
                    if (var_fun_GG.GG_dir_bd_y_valor_inicial_bidimencional[i, 0] == direccion_archivo)
                    {
                        num_indice_de_direccion = "" + i;
                        return "1" + G_caracter_para_confirmacion_o_error[0] + num_indice_de_direccion;
                    }
                }
                return "-1" + G_caracter_para_confirmacion_o_error[0] + "no esta dentro de la lista de nombres";

            }
            else
            {
                return "0" + G_caracter_para_confirmacion_o_error[0] + "no existe el archivo";
            }
        }


        public string GENERAR_RUTA_ARCHIVO(string datos)
        {
            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            //PARAMETROS---------------------------------------------------------------------------
            string id = datos_epliteados[0];

            string cantidad_ids_por_archivo_potenciade10 = "100";
            if (datos_epliteados.Length >= 2)
            {
                if (datos_epliteados[1] != "")
                {
                    cantidad_ids_por_archivo_potenciade10 = datos_epliteados[1];
                }
            }


            //---------------------------------------------------------------------------------------------
            string carpetas = "";
            Int64 potencia = Convert.ToInt64(cantidad_ids_por_archivo_potenciade10);
            string base_num = "";

            for (int i = 0; i < cantidad_ids_por_archivo_potenciade10.Length - 1; i++)
            {
                base_num = base_num + cantidad_ids_por_archivo_potenciade10[i];
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
            nom_archivo_donde_va = nom_archivo_donde_va + temp + ".txt";  // agregamos "00.txt" al final

            // devolvemos la ruta completa
            return carpetas + nom_archivo_donde_va;
        }

        private string ORDEN_INFORMACION_SOLO_PROG(List<string> resultados, string orden = "ID_TOT|COLUMNAS|CANT_POR_ARCH", string caracter_separacion = null)
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



        public string SOLO_PROG_Editar_incr_o_agrega_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID
          (string datos)
        {

            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS---------------------------------------------------------------------------
            string direccion_archivo_a_checar = "";
            if (datos_epliteados.Length >= 1 && datos_epliteados[0] != "")
            {
                direccion_archivo_a_checar = datos_epliteados[0];
            }

            int num_column_comp = 0;
            if (datos_epliteados.Length >= 2 && int.TryParse(datos_epliteados[1], out int valor1))
            {
                num_column_comp = valor1;
            }

            string comparar = "";
            if (datos_epliteados.Length >= 3 && datos_epliteados[2] != "")
            {
                comparar = datos_epliteados[2];
            }

            string numero_columnas_editar = "";
            if (datos_epliteados.Length >= 4 && datos_epliteados[3] != "")
            {
                numero_columnas_editar = datos_epliteados[3];
            }

            string editar_columna = "";
            if (datos_epliteados.Length >= 5 && datos_epliteados[4] != "")
            {
                editar_columna = datos_epliteados[4];
            }

            string comparar_columna_a_editar = "";
            if (datos_epliteados.Length >= 6 && datos_epliteados[5] != "")
            {
                comparar_columna_a_editar = datos_epliteados[5];
            }

            string edit_0_increm_1_o_agregar_si_no_esta_2 = "";
            if (datos_epliteados.Length >= 7 && datos_epliteados[6] != "")
            {
                edit_0_increm_1_o_agregar_si_no_esta_2 = datos_epliteados[6];
            }

            string texto_a_agregar_si_no_esta = "";
            if (datos_epliteados.Length >= 8 && datos_epliteados[7] != "")
            {
                texto_a_agregar_si_no_esta = datos_epliteados[7];
            }

            object caracter_separacion_obj = null;
            if (datos_epliteados.Length >= 9 && datos_epliteados[8] != "")
            {
                caracter_separacion_obj = datos_epliteados[8];
            }

            string posicion_fila = "";
            if (datos_epliteados.Length >= 10 && datos_epliteados[9] != "")
            {
                posicion_fila = datos_epliteados[9];
            }



            /*
            //------------------------------------------------------------------------------------------------
            string[] dir_sep = extraer_separado_carpetas_nombreArchivo_extencion(direccion_archivo_a_checar);
            dir_sep[0] = dir_sep[0] + "\\" + G_direccion_base_archivos_bandera;
            string dir_bandera = dir_sep[0] + dir_sep[1] + "." + dir_sep[2];
            //este archivo bandera es para que no se agarre el archivo otro programa antes de sustituirlo
            dir_bandera = dir_bandera.Replace(".TXT", "_BANDERA.TXT");
            Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(dir_bandera, leer_y_agrega_al_arreglo: false);


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
            */
            string info_a_retornar = "";

            try
            {


                string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);


                string direccion_archivo = direccion_archivo_a_checar;
                string resultado_archivo = SACAR_INDICE_DEL_ARREGLO_DE_DIRECCION_SOLO_PROG(direccion_archivo);
                string[] res_esp_archivo = resultado_archivo.Split(G_caracter_para_confirmacion_o_error[0][0]);

                //encontro o no archivo
                if (Convert.ToInt32(res_esp_archivo[0]) > 0)//si res es mayor a 0 la operacioon fue exitosa si no hubo un error
                {
                    //encontro archivo y direccion en la lista
                    if (res_esp_archivo[0] == "1")
                    {

                        int num_indice_de_direccion_int = Convert.ToInt32(res_esp_archivo[1]);
                        bool encotro_info = false;
                        string info_a_procesar = "";
                        string resul_busqueda = null;
                        string[] res_esp = null;
                        int posicion_confirmada_del_producto = -1;

                        //hay posicion de la fila del producto?
                        if (posicion_fila != "")
                        {
                            int posicion_posible = Convert.ToInt32(posicion_fila);
                            if (var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length > posicion_posible)
                            {
                                resul_busqueda = op_tex.busqueda_profunda_string(var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_posible], "" + num_column_comp, comparar);
                                res_esp = resul_busqueda.Split(G_caracter_para_confirmacion_o_error[0][0]);
                            }
                            else
                            {
                                string temp = "-2" + G_caracter_para_confirmacion_o_error[0] + "no esta el producto";
                                res_esp = temp.Split(G_caracter_para_confirmacion_o_error[0][0]);
                            }
                            //encontro el producto en la posicion o  lo buscara en toda la base?
                            if (Convert.ToInt32(res_esp[0]) > 0)
                            {
                                if (res_esp[0] == "1")
                                {
                                    encotro_info = true;
                                    info_a_procesar = res_esp[1];
                                    posicion_confirmada_del_producto = posicion_posible;
                                }
                            }
                            else
                            {
                                for (int i = G_donde_inicia_la_tabla; i < var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
                                {

                                    resul_busqueda = op_tex.busqueda_profunda_string(var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i], "" + num_column_comp, comparar);
                                    res_esp = resul_busqueda.Split(G_caracter_para_confirmacion_o_error[0][0]);
                                    //encontro la informacion?
                                    if (Convert.ToInt32(res_esp[0]) > 0)
                                    {
                                        if (res_esp[0] == "1")
                                        {
                                            encotro_info = true;
                                            info_a_procesar = res_esp[1];
                                            posicion_confirmada_del_producto = i;
                                            break;
                                        }
                                    }

                                }
                            }

                        }
                        else
                        {
                            for (int i = G_donde_inicia_la_tabla; i < var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
                            {

                                resul_busqueda = op_tex.busqueda_profunda_string(var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i], "" + num_column_comp, comparar);
                                res_esp = resul_busqueda.Split(G_caracter_para_confirmacion_o_error[0][0]);
                                //encontro la informacion?
                                if (Convert.ToInt32(res_esp[0]) > 0)
                                {
                                    if (res_esp[0] == "1")
                                    {
                                        encotro_info = true;
                                        info_a_procesar = res_esp[1];
                                        posicion_confirmada_del_producto = i;
                                        break;
                                    }
                                }


                            }
                        }

                        //encontro el producto?
                        if (encotro_info == true)
                        {

                            var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_confirmada_del_producto] =
                                op_tex.editar_inc_agregar_edicion_profunda_multiple_comparacion_final_string
                                (
                                    info_a_procesar,
                                    numero_columnas_editar,
                                    editar_columna,
                                    comparar_columna_a_editar,
                                    edit_0_increm_1_o_agregar_si_no_esta_2
                                    );


                            cambiar_archivo_con_arreglo_SOLO_PROG(direccion_archivo, var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int]);
                            info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_confirmada_del_producto];
                            encotro_info = true;


                        }
                        //no encontro la info
                        else
                        {
                            if (texto_a_agregar_si_no_esta != "")
                            {
                                Agregar_solo_prog(direccion_archivo + G_caracter_separacion_funciones_espesificas[3] + texto_a_agregar_si_no_esta);
                                info_a_retornar = "2" + G_caracter_para_confirmacion_o_error[0] + "agrego_la_informacion";
                            }
                            else
                            {
                                info_a_retornar = "-1" + G_caracter_para_confirmacion_o_error[0] + "no encontro el dato y no se puede agregar por que la variable texto_a_agregar_si_no_esta esta vacia";
                            }

                        }

                    }

                    else
                    {

                    }

                }

                else
                {
                    //no encontro archivo
                    if (res_esp_archivo[0] == "0")
                    {
                        info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se encontro el archivo";
                    }
                    //solo encontro archivo y no esta en la lista
                    if (res_esp_archivo[0] == "-1")
                    {
                        string[] inventario = LEER_SOLO_PROG(direccion_archivo).Split(G_caracter_separacion_funciones_espesificas[4][0]);
                        for (int i = G_donde_inicia_la_tabla; i < inventario.Length; i++)
                        {
                            string[] columnas = inventario[i].Split(caracter_separacion[0][0]);

                            if (columnas[num_column_comp] == comparar)
                            {

                                inventario[i] = op_tex.editar_inc_edicion_profunda_multiple_string(inventario[i], numero_columnas_editar, editar_columna, edit_0_increm_1_o_agregar_si_no_esta_2);

                                cambiar_archivo_con_arreglo_SOLO_PROG(direccion_archivo, inventario);
                                info_a_retornar = "2" + G_caracter_para_confirmacion_o_error[0] + inventario[i];
                                break;
                            }
                        }

                    }

                }



                //sw_bandera.Close();
            }
            catch
            {
                //sw_bandera.Close();
            }




            return info_a_retornar;
        }

        public string SOLO_PROG_Editar_incr_o_agrega_MULTIPLESCOMPARACIONES_AL_FINAL_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_BUSQUEDA_ID
            (string datos)
        {
            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS---------------------------------------------------------------------------
            string direccion_archivo = "";
            if (datos_epliteados.Length >= 1 && datos_epliteados[0] != "")
            {
                direccion_archivo = datos_epliteados[0];
            }

            int num_column_comp = 0;
            if (datos_epliteados.Length >= 2 && int.TryParse(datos_epliteados[1], out int valor1))
            {
                num_column_comp = valor1;
            }

            string comparar = "";
            if (datos_epliteados.Length >= 3 && datos_epliteados[2] != "")
            {
                comparar = datos_epliteados[2];
            }

            string numero_columnas_editar = "";
            if (datos_epliteados.Length >= 4 && datos_epliteados[3] != "")
            {
                numero_columnas_editar = datos_epliteados[3];
            }

            string comparar_y_edicion_COMPARACION_FINAL = "";
            if (datos_epliteados.Length >= 5 && datos_epliteados[4] != "")
            {
                comparar_y_edicion_COMPARACION_FINAL = datos_epliteados[4];
            }

            string edit_0_increm_1_o_agregar_si_no_esta_2 = "";
            if (datos_epliteados.Length >= 6 && datos_epliteados[5] != "")
            {
                edit_0_increm_1_o_agregar_si_no_esta_2 = datos_epliteados[5];
            }

            string texto_a_agregar_si_no_esta = "";
            if (datos_epliteados.Length >= 7 && datos_epliteados[6] != "")
            {
                texto_a_agregar_si_no_esta = datos_epliteados[6];
            }

            object caracter_separacion_obj = null;
            if (datos_epliteados.Length >= 8 && datos_epliteados[7] != "")
            {
                caracter_separacion_obj = datos_epliteados[7];
            }

            string posicion_fila = "";
            if (datos_epliteados.Length >= 9 && datos_epliteados[8] != "")
            {
                posicion_fila = datos_epliteados[8];
            }


            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string info_a_retornar = "";

            /*
            //-------------------------------------------------------------------------------------------------------
            string[] dir_sep = extraer_separado_carpetas_nombreArchivo_extencion(direccion_archivo);
            dir_sep[0] = dir_sep[0] + "\\" + G_direccion_base_archivos_bandera;
            string dir_bandera = dir_sep[0] + dir_sep[1] + "." + dir_sep[2];
            //este archivo bandera es para que no se agarre el archivo otro programa antes de sustituirlo
            dir_bandera = dir_bandera.Replace(".TXT", "_BANDERA.TXT");
            Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(dir_bandera, leer_y_agrega_al_arreglo: false);


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
            */
            try
            {


                string resultado_archivo = SACAR_INDICE_DEL_ARREGLO_DE_DIRECCION_SOLO_PROG(direccion_archivo);

                string[] res_esp_archivo = resultado_archivo.Split(G_caracter_para_confirmacion_o_error[0][0]);

                //encontro o no archivo
                if (Convert.ToInt32(res_esp_archivo[0]) > 0)//si res es mayor a 0 la operacioon fue exitosa si no hubo un error
                {
                    //encontro archivo y direccion en la lista
                    if (res_esp_archivo[0] == "1")
                    {

                        int num_indice_de_direccion_int = Convert.ToInt32(res_esp_archivo[1]);
                        bool encotro_info = false;

                        string info_a_procesar = "";
                        string resul_busqueda = null;
                        string[] res_esp = null;
                        int posicion_confirmada_del_producto = -1;

                        //hay posicion de la fila del producto?
                        if (posicion_fila != "")
                        {
                            int posicion_posible = Convert.ToInt32(posicion_fila);
                            resul_busqueda = op_tex.busqueda_profunda_string(var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_posible], "" + num_column_comp, comparar);
                            res_esp = resul_busqueda.Split(G_caracter_para_confirmacion_o_error[0][0]);
                            //encontro el producto en la posicion o  lo buscara en toda la base?
                            if (Convert.ToInt32(res_esp[0]) > 0)
                            {
                                if (res_esp[0] == "1")
                                {
                                    encotro_info = true;
                                    info_a_procesar = res_esp[1];
                                    posicion_confirmada_del_producto = posicion_posible;
                                }
                            }
                            else
                            {
                                for (int i = G_donde_inicia_la_tabla; i < var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
                                {

                                    resul_busqueda = op_tex.busqueda_profunda_string(var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i], "" + num_column_comp, comparar);
                                    res_esp = resul_busqueda.Split(G_caracter_para_confirmacion_o_error[0][0]);
                                    //encontro el dato?
                                    if (Convert.ToInt32(res_esp[0]) > 0)
                                    {
                                        if (res_esp[0] == "1")
                                        {

                                            encotro_info = true;
                                            info_a_procesar = res_esp[1];
                                            posicion_confirmada_del_producto = i;

                                            break;
                                        }
                                    }


                                }
                            }

                        }
                        else
                        {
                            for (int i = G_donde_inicia_la_tabla; i < var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
                            {

                                resul_busqueda = op_tex.busqueda_profunda_string(var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i], "" + num_column_comp, comparar);
                                res_esp = resul_busqueda.Split(G_caracter_para_confirmacion_o_error[0][0]);
                                //encontro el dato?
                                if (Convert.ToInt32(res_esp[0]) > 0)
                                {
                                    if (res_esp[0] == "1")
                                    {

                                        encotro_info = true;
                                        info_a_procesar = res_esp[1];
                                        posicion_confirmada_del_producto = i;

                                        break;
                                    }
                                }


                            }
                        }

                        if (encotro_info == true)
                        {


                            var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_confirmada_del_producto] =
                                op_tex.editar_inc_agregar_edicion_profunda_multiple_comparacion_final_MULTIPLE_A_CHECAR_string
                                (res_esp[1], numero_columnas_editar, comparar_y_edicion_COMPARACION_FINAL, edit_0_increm_1_o_agregar_si_no_esta_2);


                            cambiar_archivo_con_arreglo_SOLO_PROG(direccion_archivo, var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int]);
                            info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_confirmada_del_producto];
                        }

                        //no encontro la info
                        else
                        {
                            if (texto_a_agregar_si_no_esta != "")
                            {
                                Agregar_solo_prog(direccion_archivo + G_caracter_separacion_funciones_espesificas[3] + texto_a_agregar_si_no_esta);
                                info_a_retornar = "2" + G_caracter_para_confirmacion_o_error[0] + "agrego_la_informacion";
                            }
                            else
                            {
                                info_a_retornar = "-1" + G_caracter_para_confirmacion_o_error[0] + "no encontro el dato y no se puede agregar por que la variable texto_a_agregar_si_no_esta esta vacia";
                            }

                        }
                    }

                }

                else
                {
                    //no encontro archivo
                    if (res_esp_archivo[0] == "0")
                    {
                        info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se encontro el archivo";
                    }
                    //solo encontro archivo y no esta en la lista
                    if (res_esp_archivo[0] == "-1")
                    {
                        string[] inventario = LEER_SOLO_PROG(direccion_archivo).Split(G_caracter_separacion_funciones_espesificas[4][0]);
                        for (int i = G_donde_inicia_la_tabla; i < inventario.Length; i++)
                        {
                            string[] columnas = inventario[i].Split(caracter_separacion[0][0]);

                            if (columnas[num_column_comp] == comparar)
                            {

                                inventario[i] = op_tex.editar_inc_edicion_profunda_multiple_string(inventario[i], numero_columnas_editar, comparar_y_edicion_COMPARACION_FINAL, edit_0_increm_1_o_agregar_si_no_esta_2);

                                cambiar_archivo_con_arreglo_SOLO_PROG(direccion_archivo, inventario);
                                info_a_retornar = "2" + G_caracter_para_confirmacion_o_error[0] + inventario[i];
                                break;
                            }
                        }

                    }

                }


                //sw_bandera.Close();
            }
            catch
            {
                //sw_bandera.Close();
            }



            return info_a_retornar;
        }

        int cont_temp = 0;
        public string SOLO_PROG_Editar_incr_o_agrega_COMPARACION_YY_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID
            (string datos)
        {
            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS---------------------------------------------------------------------------
            string direccion_archivo_a_checar = "";
            if (datos_epliteados.Length >= 1 && datos_epliteados[0] != "")
            {
                direccion_archivo_a_checar = datos_epliteados[0];
            }

            string num_column_comp = "";
            if (datos_epliteados.Length >= 2 && datos_epliteados[1] != "")
            {
                num_column_comp = datos_epliteados[1];
            }

            string comparar__ = "";
            if (datos_epliteados.Length >= 3 && datos_epliteados[2] != "")
            {
                comparar__ = datos_epliteados[2];
            }

            string numero_columnas_editar = "";
            if (datos_epliteados.Length >= 4 && datos_epliteados[3] != "")
            {
                numero_columnas_editar = datos_epliteados[3];
            }

            string comparar_con_editar_columna = "";
            if (datos_epliteados.Length >= 5 && datos_epliteados[4] != "")
            {
                comparar_con_editar_columna = datos_epliteados[4];
            }

            string edit_0_increm_1_o_agregar_si_no_esta_2 = "";
            if (datos_epliteados.Length >= 6 && datos_epliteados[5] != "")
            {
                edit_0_increm_1_o_agregar_si_no_esta_2 = datos_epliteados[5];
            }

            string texto_a_agregar_si_no_esta = "";
            if (datos_epliteados.Length >= 7 && datos_epliteados[6] != "")
            {
                texto_a_agregar_si_no_esta = datos_epliteados[6];
            }

            object caracter_separacion_obj = null;
            if (datos_epliteados.Length >= 8 && datos_epliteados[7] != "")
            {
                caracter_separacion_obj = datos_epliteados[7];
            }

            string posicion_fila = "";
            if (datos_epliteados.Length >= 9 && datos_epliteados[8] != "")
            {
                posicion_fila = datos_epliteados[8];
            }


            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string info_a_retornar = "";

            /*
            //-------------------------------------------------------------------------------------------
            string[] dir_sep = extraer_separado_carpetas_nombreArchivo_extencion(direccion_archivo_a_checar);
            dir_sep[0] = dir_sep[0] + "\\" + G_direccion_base_archivos_bandera;
            string dir_bandera = dir_sep[0] + dir_sep[1] + "." + dir_sep[2];
            //este archivo bandera es para que no se agarre el archivo otro programa antes de sustituirlo
            dir_bandera = dir_bandera.Replace(".TXT", "_BANDERA.TXT");
            Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(dir_bandera, leer_y_agrega_al_arreglo: false);


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
            */
            try
            {


                string direccion_archivo = direccion_archivo_a_checar;
                string resultado_archivo = SACAR_INDICE_DEL_ARREGLO_DE_DIRECCION_SOLO_PROG(direccion_archivo);
                string[] res_esp_archivo = resultado_archivo.Split(G_caracter_para_confirmacion_o_error[0][0]);

                //encontro o no archivo
                if (Convert.ToInt32(res_esp_archivo[0]) > 0)//si res es mayor a 0 la operacioon fue exitosa si no hubo un error
                {
                    //encontro archivo y direccion en la lista
                    if (res_esp_archivo[0] == "1")
                    {

                        int num_indice_de_direccion_int = Convert.ToInt32(res_esp_archivo[1]);
                        bool encotro_info = false;
                        string info_a_procesar = "";
                        string resul_busqueda = null;
                        string[] res_esp = null;
                        int posicion_confirmada_del_producto = -1;

                        if (posicion_fila != "")
                        {
                            int posicion_posible = Convert.ToInt32(posicion_fila);
                            resul_busqueda = op_tex.busqueda_profunda_string(var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_posible], "" + num_column_comp, comparar__);
                            res_esp = resul_busqueda.Split(G_caracter_para_confirmacion_o_error[0][0]);
                            //encontro el producto en la posicion o  lo buscara en toda la base?
                            if (Convert.ToInt32(res_esp[0]) > 0)
                            {
                                if (res_esp[0] == "1")
                                {
                                    encotro_info = true;
                                    info_a_procesar = res_esp[1];
                                    posicion_confirmada_del_producto = posicion_posible;
                                }
                            }
                            else
                            {
                                for (int i = G_donde_inicia_la_tabla; i < var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
                                {

                                    resul_busqueda = op_tex.busqueda_con_YY_profunda_texto_id_archivo(var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i], "" + num_column_comp, comparar__);
                                    res_esp = resul_busqueda.Split(G_caracter_para_confirmacion_o_error[0][0]);
                                    //encontor informacion?
                                    if (Convert.ToInt32(res_esp[0]) > 0)
                                    {
                                        if (res_esp[0] == "1")
                                        {

                                            encotro_info = true;
                                            info_a_procesar = res_esp[1];
                                            posicion_confirmada_del_producto = i;
                                            break;
                                        }
                                    }


                                }
                            }
                        }
                        else
                        {
                            for (int i = G_donde_inicia_la_tabla; i < var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
                            {

                                resul_busqueda = op_tex.busqueda_con_YY_profunda_texto_id_archivo(var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i], "" + num_column_comp, comparar__);
                                res_esp = resul_busqueda.Split(G_caracter_para_confirmacion_o_error[0][0]);
                                //encontor informacion?
                                if (Convert.ToInt32(res_esp[0]) > 0)
                                {
                                    if (res_esp[0] == "1")
                                    {

                                        encotro_info = true;
                                        info_a_procesar = res_esp[1];
                                        posicion_confirmada_del_producto = i;
                                        break;
                                    }
                                }


                            }
                        }
                        //no encontro la se encontro la info?
                        if (encotro_info == true)
                        {
                            cont_temp++;
                            if (cont_temp == 6 || cont_temp == 3)
                            {

                            }


                            string checador = var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_confirmada_del_producto]
                                            =
                                            op_tex.editar_inc_agregar_edicion_profunda_multiple_comparacion_final_MULTIPLE_A_CHECAR_string

                                            (res_esp[1],
                                            numero_columnas_editar,
                                            comparar_con_editar_columna,
                                            edit_0_increm_1_o_agregar_si_no_esta_2);


                            cambiar_archivo_con_arreglo_SOLO_PROG(direccion_archivo, var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int]);
                            info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + var_fun_GG.GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_confirmada_del_producto];
                        }


                        else
                        {
                            if (texto_a_agregar_si_no_esta != "")
                            {
                                Agregar_solo_prog(direccion_archivo + G_caracter_separacion_funciones_espesificas[3] + texto_a_agregar_si_no_esta);
                                info_a_retornar = "2" + G_caracter_para_confirmacion_o_error[0] + "agrego_la_informacion";
                            }
                            else
                            {
                                info_a_retornar = "-1" + G_caracter_para_confirmacion_o_error[0] + "no encontro el dato y no se puede agregar por que la variable texto_a_agregar_si_no_esta esta vacia";
                            }

                        }
                    }

                }

                else
                {
                    //no encontro archivo
                    if (res_esp_archivo[0] == "0")
                    {
                        info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se encontro el archivo";
                    }


                }

                //sw_bandera.Close();
            }
            catch
            {
                //sw_bandera.Close();
            }




            return info_a_retornar;
        }

        string G_direccion_base_archivos_bandera = "BANDERAS_ARCH\\";
        public string cambiar_archivo_con_arreglo_SOLO_PROG(string direccion_archivo, string[] arreglo, object caracter_separacion_objeto = null, object stream_reader_o_write = null)
        {
            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);


            string[] dir_sep = extraer_separado_carpetas_nombreArchivo_extencion(direccion_archivo);
            dir_sep[0] = dir_sep[0] + "\\" + G_direccion_base_archivos_bandera;
            string dir_bandera = dir_sep[0] + "\\" + dir_sep[1] + "." + dir_sep[2];
            //este archivo bandera es para que no se agarre el archivo otro programa antes de sustituirlo
            dir_bandera = dir_bandera + direccion_archivo.Replace(".TXT", "_BANDERA_CAA.TXT");
            Crear_archivo_y_directorio(dir_bandera);


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




            string exito_o_fallo = "";
            string dir_tem = "tem.txt";
            StreamWriter sw = new StreamWriter(dir_tem, true);
            try
            {

                for (int i = 0; i < arreglo.Length; i++)
                {
                    sw.WriteLine(arreglo[i]);
                }
                exito_o_fallo = "1" + caracter_separacion[0] + "exito";
                sw.Close();


                //registro_cambio_datos_archivo_para_actualisacion_en_multiples_programas(direccion_archivo, "EDITAR_MULTIPLE_FILAS", "");
                sw_bandera.Close();
            }
            catch (Exception e)
            {

                exito_o_fallo = "2" + caracter_separacion[0] + "fallo" + caracter_separacion[0] + e;
                sw.Close();

                sw_bandera.Close();
            }


            File.Delete(direccion_archivo);//borramos el archivo original
            File.Move(dir_tem, direccion_archivo);//renombramos el archivo temporal por el que tenia el original

            return exito_o_fallo;
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

        public string busca_para_editar_y_agregar_en_archivos_divididos_si_los_encuentra_aplicar_funciones(string direccion_archivo, string datos_a_buscar, string columna, bool editar_archivo_true_false, Func<string, string>[] funcion_arr, string[] datos_arr, string agrega_si_no_lo_encuentra)
        {
            string info_retornar = "";

            //------------------------------------------------------------

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


            string[] temp = direccion_archivo.Split('.');
            string carpetas = temp[0] + "_DAT\\";


            string linea;
            Int64 id_total = -1;
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


            bool encontro_la_informacion = false;

            for (int i = 1; i <= id_total; i++)
            {
                List<string> filas_archivo = new List<string>();
                filas_archivo.Clear();

                string ruta_archivo = GENERAR_RUTA_ARCHIVO("" + i + G_caracter_separacion_funciones_espesificas[3] + cantidad_filas_por_archivo + "");
                FileStream fs2 = null;
                StreamReader sr2 = null;

                while (fs2 == null)
                {
                    try
                    {
                        fs2 = new FileStream(carpetas + ruta_archivo, FileMode.Open, FileAccess.ReadWrite);
                    }
                    catch
                    {


                    }
                }
                sr2 = new StreamReader(fs2);
                StreamWriter sw2 = new StreamWriter(fs2);

                string linea2;


                while ((linea2 = sr2.ReadLine()) != null)
                {
                    filas_archivo.Add(linea2);
                }

                Int32 filas_actual = 1;
                for (filas_actual = 1; filas_actual < filas_archivo.Count; filas_actual++)
                {

                    if (filas_actual < cantidad_filas_por_archivo)
                    {
                        if (filas_actual > 0)
                        {

                            //aqui la conparacion para la edicion

                            string[] columnas_a_comparar = columna.Split(G_caracter_separacion[0][0]);
                            string[] esp_datos_a_comparar = datos_a_buscar.Split(G_caracter_separacion[0][0]);
                            bool filas_encontradas = true;
                            string[] res = null;
                            for (int cant_col_a_checar = 0; cant_col_a_checar < columnas_a_comparar.Length; cant_col_a_checar++)
                            {
                                string temp_caracteres_separacion = "";
                                for (int k = 1; k < G_caracter_separacion.Length; k++)
                                {
                                    temp_caracteres_separacion = op_tex.concatenacion_caracter_separacion(temp_caracteres_separacion, G_caracter_separacion[k], G_caracter_separacion_funciones_espesificas[0]);
                                }



                                //checa si es el producto

                                //este es condicion ||
                                //string[] res = op_tex.busqueda_profunda_string(filas_archivo[l], columnas_a_comparar[j], esp_datos_a_comparar[j], caracter_separacion_objeto: temp_caracteres_separacion).Split(G_caracter_para_confirmacion_o_error[0][0]);
                                //este es condicion &&
                                //la comparacion del archivo
                                res = op_tex.busqueda_con_YY_profunda_texto_id_archivo(filas_archivo[filas_actual], columnas_a_comparar[cant_col_a_checar], esp_datos_a_comparar[cant_col_a_checar], caracter_separacion_objeto: temp_caracteres_separacion).Split(G_caracter_para_confirmacion_o_error[0][0]);
                                if (Convert.ToInt32(res[0]) <= 0)
                                {
                                    filas_encontradas = false;
                                }


                            }

                            if (filas_encontradas)
                            {
                                if (Convert.ToInt32(res[0]) > 0)
                                {
                                    string[] info_split = res[1].Split(G_caracter_separacion[0][0]);
                                    encontro_la_informacion = true;
                                    Int64 id_archivo_a_modificar = Convert.ToInt32(res[2]);
                                    //encontro el producto
                                    fs2.Seek(0, SeekOrigin.Begin);
                                    for (int m = 0; m < filas_archivo.Count; m++)
                                    {
                                        if (id_archivo_a_modificar == m)
                                        {
                                            //aqui la modificacion que se aran con las funciones
                                            //string info_modificada = "";
                                            string info_modificada = filas_archivo[m];
                                            for (int n = 0; n < funcion_arr.Length; n++)
                                            {
                                                //REGLA SIEMPRE TODAS LAS FUNCIONES QUE SE USEN, EL TEXTO A MODIFICAR ES EL PRIMER PARAMETRO, REGLA A CUMPLIR SIEMPRE
                                                //EL CARACTER DE SEPARACION FUNCIONES ESPECIALES [3]
                                                info_modificada = funcion_arr[n](info_modificada + G_caracter_separacion_funciones_espesificas[3] + datos_arr[n]);
                                            }


                                            if (editar_archivo_true_false == true)
                                            {
                                                //edita archivo
                                                sw2.WriteLine(info_modificada);
                                                filas_archivo[m] = info_modificada;
                                                info_retornar = op_tex.concatenacion_caracter_separacion(info_retornar, linea2, G_caracter_separacion_funciones_espesificas[3]);
                                            }
                                            else
                                            {
                                                //no edita y deja todo como esta
                                                sw2.WriteLine(filas_archivo[m]);
                                                info_retornar = op_tex.concatenacion_caracter_separacion(info_retornar, linea2, G_caracter_separacion_funciones_espesificas[3]);
                                            }


                                            //fin de las modificaciones
                                        }
                                        else
                                        {
                                            //no edita archivo
                                            sw2.WriteLine(filas_archivo[m]);
                                        }

                                    }

                                    sw2.Flush();

                                }
                            }




                            //aqui la comparacion
                            //linea2.Split(G_caracter_separacion[0][0]);

                            info_retornar = op_tex.concatenacion_caracter_separacion(info_retornar, linea2, G_caracter_separacion_funciones_espesificas[3]);
                        }
                        filas_actual++;

                    }
                }

                i = i + filas_actual;
                //fin for total ids----------------------------------------------------
                sw2.Close();
                sr2.Close();
                fs2.Close();

            }


            sr.Close();
            fs.Close();
            if (encontro_la_informacion == false)
            {

                Agregar_info_dividida(direccion_archivo + G_caracter_separacion_funciones_espesificas[3] + agrega_si_no_lo_encuentra);
            }

            //G_solo_para_consultas_relacionadas_encontrar_el_id = info_retornar.Split(G_caracter_separacion_funciones_espesificas[3][0]);





            return info_retornar;
        }

        //fin clase---------------------------------------------------------------------------
    }
}
