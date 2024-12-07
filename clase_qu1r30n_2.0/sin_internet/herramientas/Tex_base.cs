using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Microsoft.SqlServer.Server;
using System.Windows.Forms;

namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas
{
    class Tex_base
    {


        string G_direccion_base_archivos_bandera = "BANDERAS_ARCH\\";

        //para funciones globales

        var_fun_GG vf_GG = new var_fun_GG();

        //bases de datos
        static public string[][] GG_base_arreglo_de_arreglos = null;

        //direcciones_de_las_bases
        static public string[,] GG_dir_bd_y_valor_inicial_bidimencional = null;

        //[0]=indice desde donde comensara desde el 0 nombre de las columnas y es mejor empesar desde el 1
        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        //caracteres de separacion//el primero lo usaremos diferente NO USAR LOS MISMOS QUE G_separador_para_funciones_espesificas;
        /*
        public string[] G_caracter_separacion = { "|", "°", "¬", "^" };
        public string[] G_separador_para_funciones_espesificas = { "~", "§", "¶", "╣"};
        */
        public string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        public string[] G_separador_para_funciones_espesificas_ = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        public string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;
        public string[] G_caracter_para_transferencia_entre_archivos = var_fun_GG.GG_caracter_para_transferencia_entre_archivos;

        /*Aquí poner las funciones de las otras clases Si te vas a llevar esta clase solamente --------------------------------
       Ver poniendo también los nombres de las funciones que estás usando para no pasar toda la clase -----------------------
       Próstata también el nombre de la clase para saber de qué clase se está sacando las funciones -------------------------
       */
        operaciones_arreglos op_arr = new operaciones_arreglos();
        operaciones_textos op_tex = new operaciones_textos();

        //fin Aquí poner las funciones de las otras clases Si te vas a llevar esta clase solamente --------------------------------

        //filas: es para filas iniciales valor_inicial: se utilisa para poner filas inicial normalmente se usa para poner el nombre de las columnas
        public string Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(string direccion_archivo, string valor_inicial = null, string[] filas_iniciales = null, object caracter_separacion_fun_esp_objeto = null, bool leer_y_agrega_al_arreglo = true)
        {
            string[] caracter_separacion_fun_esp = vf_GG.GG_funcion_caracter_separacion_funciones_especificas(caracter_separacion_fun_esp_objeto);

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
                    fs0.Close();//cierra fs0 para que se pueda usar despues



                    if (valor_inicial != null)// si al llamar a la funcion  le pusiste valor_inicial las escribe //se utilisa para que sea como un titulo o un eslogan pero lo utilisaremos en este prog
                    {
                        Agregar(direccion_archivo, valor_inicial, false);//escribe aqui el valor inicial si es que lo pusiste
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
                                Agregar(direccion_archivo, filas_iniciales[i], false);//agrega las filas
                            }
                        }

                    }


                    creo_algo = true;
                }
                //si crea ele archivo lee el archivo
                if (leer_y_agrega_al_arreglo)
                {
                    GG_dir_bd_y_valor_inicial_bidimencional = op_arr.agregar_registro_del_array_bidimensional(GG_dir_bd_y_valor_inicial_bidimencional, direccion_archivo + caracter_separacion_fun_esp[0] + valor_inicial, caracter_separacion_fun_esp);
                    GG_base_arreglo_de_arreglos = op_arr.agregar_arreglo_a_arreglo_de_arreglos(GG_base_arreglo_de_arreglos, leer(direccion_archivo));
                    return direccion_archivo + G_caracter_separacion[0] + "leido";
                }
            }
            if (creo_algo)
            {
                registro_cambio_datos_archivo_para_actualisacion_en_multiples_programas(direccion_archivo, "CREACION_ARCHIVO", "");
                return direccion_archivo;
            }

            return null;
        }

        public string Agregar(string direccion_archivos, string agregando, bool con_arreglo_GG = true)
        {

            string info_a_retornar = "";

            if (con_arreglo_GG)
            {
                string resultado_indice_de_direccion = sacar_indice_del_arreglo_de_direccion(direccion_archivos);
                string[] res_indice_espliteado = resultado_indice_de_direccion.Split(G_caracter_para_confirmacion_o_error[0][0]);
                if (Convert.ToInt32(res_indice_espliteado[0]) > 0)
                {


                    if (res_indice_espliteado[0] == "1")
                    {

                        int num_indice_de_direccion_int = Convert.ToInt32(res_indice_espliteado[1]);
                        GG_base_arreglo_de_arreglos[num_indice_de_direccion_int] = op_arr.agregar_registro_del_array(GG_base_arreglo_de_arreglos[num_indice_de_direccion_int], agregando);

                        info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + agregando;

                    }
                }

                else
                {
                    if (res_indice_espliteado[1] == "0")
                    {
                        return "0" + G_caracter_para_confirmacion_o_error[0] + "no encontro archivo";
                    }
                    else if (res_indice_espliteado[1] == "-1")
                    {
                        info_a_retornar = "2" + G_caracter_para_confirmacion_o_error[0] + "no se encontro la direccion en la lista de direcciones pero lo agrego al archivo";
                    }

                }
            }

            StreamWriter sw = new StreamWriter(direccion_archivos, true);
            try
            {

                sw.WriteLine(agregando);
                sw.Close();

                registro_cambio_datos_archivo_para_actualisacion_en_multiples_programas(direccion_archivos, "AGREGAR", agregando);
            }
            catch
            {
                sw.Close();

            }


            return info_a_retornar;

        }


        public string buscar(string direccion_archivo, string dato_a_buscar, int columna, string id_posicion_informacion = "")
        {
            string inf_retornar = "";
            string[] res_busq = sacar_indice_del_arreglo_de_direccion(direccion_archivo).Split(G_caracter_para_confirmacion_o_error[0][0]);
            int indice = Convert.ToInt32(res_busq[1]);

            if (id_posicion_informacion != "")
            {
                int id_producto = Convert.ToInt32(id_posicion_informacion);
                string[] info_produc_esp = GG_base_arreglo_de_arreglos[indice][id_producto].Split(G_caracter_separacion[0][0]);
                if (dato_a_buscar == info_produc_esp[columna])
                {
                    inf_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + GG_base_arreglo_de_arreglos[indice][id_producto] + G_caracter_para_confirmacion_o_error[0] + id_producto;
                }
                else
                {
                    bool encontro_producto = false;
                    int indice_iniciar_busqueda = id_producto;
                    if (id_producto > 9) { indice_iniciar_busqueda = indice_iniciar_busqueda - 10; }
                    else { indice_iniciar_busqueda = G_donde_inicia_la_tabla; }

                    for (int i = indice_iniciar_busqueda; i < id_producto; i++)
                    {
                        string[] info_prod_bas = GG_base_arreglo_de_arreglos[indice][i].Split(G_caracter_separacion[0][0]);
                        if (dato_a_buscar == info_prod_bas[columna])
                        {
                            inf_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + GG_base_arreglo_de_arreglos[indice][i] + G_caracter_para_confirmacion_o_error[0] + i;
                            encontro_producto = true;
                            break;
                        }
                    }
                    if (encontro_producto == false)
                    {

                        for (int i = G_donde_inicia_la_tabla; i < GG_base_arreglo_de_arreglos[indice].Length; i++)
                        {
                            string[] info_prod_bas = GG_base_arreglo_de_arreglos[indice][i].Split(G_caracter_separacion[0][0]);

                            if (dato_a_buscar == info_prod_bas[columna])
                            {
                                inf_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + GG_base_arreglo_de_arreglos[indice][i] + G_caracter_para_confirmacion_o_error[0] + i;
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
                for (int i = 0; i < GG_base_arreglo_de_arreglos[indice].Length; i++)
                {
                    string[] info_produc_esp = GG_base_arreglo_de_arreglos[indice][i].Split(G_caracter_separacion[0][0]);
                    if (dato_a_buscar == info_produc_esp[columna])
                    {
                        inf_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + GG_base_arreglo_de_arreglos[indice][i] + G_caracter_para_confirmacion_o_error[0] + i;
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


        public string seleccionar(string direccion_archivo, int num_column_comp, string comparar, object caracter_separacion_objeto = null)
        {
            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            string[] res_sacar_indice = sacar_indice_del_arreglo_de_direccion(direccion_archivo).Split(G_caracter_para_confirmacion_o_error[0][0]);

            if (Convert.ToInt32(res_sacar_indice[0]) > 0)
            {
                int num_indice_de_direccion_int = Convert.ToInt32(res_sacar_indice[1]);

                for (int i = G_donde_inicia_la_tabla; i < GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
                {
                    string[] columnas = GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i].Split(caracter_separacion[0][0]);

                    if (columnas[num_column_comp] == comparar)
                    {

                        return GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i];
                    }
                }

            }
            return null;
        }

        public string[] leer(string direccionArchivo, string posString = null, object caracter_separacion_objeto = null, int iniciar_desde_que_fila = 0)
        {

            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);


            // Declaración de variables
            string[] linea = null;      // Almacenará todas las líneas cuando posString sea null
            string[] resultado = null;  // Almacenará el resultado final cuando posString no sea null
            string[] posSplit;
            int[] posiciones;

            string palabra = null;

            // Crear un objeto StreamReader para leer el archivo
            StreamReader sr = null;
            while (sr == null)
            {


                try
                {
                    sr = new StreamReader(direccionArchivo);

                }
                catch (Exception e)
                {
                    string[] checador = leer(var_fun_GG.GG_direccion_control_errores_try);
                    chequeo_error_try(direccionArchivo, e, checador[1]);
                }
            }
            try
            {
                // Si posString es null, se lee el archivo línea por línea y se agrega cada línea a "linea"
                if (posString == null)
                {
                    while ((palabra = sr.ReadLine()) != null)
                    {
                        if (palabra != "")
                        {
                            linea = op_arr.agregar_registro_del_array(linea, palabra);
                        }
                    }
                }
                // Si posString no es null, se extraen las columnas especificadas y se agregan a "resultado"
                else
                {
                    posSplit = posString.Split(caracter_separacion[0][0]);
                    posiciones = new int[posSplit.Length];

                    // Convertir las posiciones de las columnas de string a int
                    for (int i = 0; i < posiciones.Length; i++)
                    {
                        posiciones[i] = Convert.ToInt32(posSplit[i]);
                    }

                    // Leer el archivo línea por línea y procesar según las posiciones especificadas
                    for (int i = 0; (palabra = sr.ReadLine()) != null; i++)
                    {
                        string[] splLinea = palabra.Split(caracter_separacion[0][0]);

                        palabra = "";
                        for (int j = 0; j < posiciones.Length; j++)
                        {
                            if (j < posiciones.Length - 1)
                            {
                                palabra = palabra + splLinea[posiciones[j]] + caracter_separacion[0];
                            }
                            else
                            {
                                palabra = palabra + splLinea[posiciones[j]];
                            }
                        }

                        // Agregar la palabra procesada al arreglo "resultado"
                        linea = op_arr.agregar_registro_del_array(linea, palabra);
                    }

                }

                // Cerrar el StreamReader ya que se ha completado el procesamiento
                sr.Close();
            }
            catch
            {
                sr.Close();
            }



            if (linea != null)
            {

                if ((linea.Length - iniciar_desde_que_fila) > 0)
                {


                    // Copiar el contenido de "linea" a un nuevo arreglo para evitar referencias no deseadas
                    string[] arreglo_a_retornar = new string[linea.Length - iniciar_desde_que_fila];
                    for (int k = iniciar_desde_que_fila; k < linea.Length; k++)
                    {
                        arreglo_a_retornar[k - iniciar_desde_que_fila] = "" + linea[k];
                    }

                    // Devolver el resultado
                    return arreglo_a_retornar;
                }
                else { return null; }
            }
            else
            {
                return null;
            }
        }

        public string[] Ordenar(string direccion_archivo, int columna_comparar, string tipo = "numero", string orden = "mayor_menor", char caracter_separacion = '|', int fila_donde_comiensa = 0)
        {
            string[] res_indice = sacar_indice_del_arreglo_de_direccion(direccion_archivo).Split(G_caracter_para_confirmacion_o_error[0][0]);

            string[] lineas = null;
            if (res_indice[0] == "1")
            {
                int indice = Convert.ToInt32(res_indice[1]);
                lineas = GG_base_arreglo_de_arreglos[indice];
            }
            else
            {
                lineas = leer(direccion_archivo);
            }


            if (tipo == "numero")
            {
                if (orden == "mayor_menor")
                {


                    string temporal_apoyo;
                    for (int i = fila_donde_comiensa; i < lineas.Length; i++)
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
                }//if orden

                else if (orden == "menor_mayor")
                {
                    string temporal_apoyo;
                    for (int i = fila_donde_comiensa; i < lineas.Length; i++)
                    {
                        for (int j = i + 1; j < lineas.Length; j++)
                        {

                            string[] num1 = lineas[i].Split(caracter_separacion);
                            decimal num1_decimal = Convert.ToDecimal(num1[columna_comparar]);
                            string[] num2 = lineas[j].Split(caracter_separacion);
                            decimal num2_decimal = Convert.ToDecimal(num2[columna_comparar]);
                            if (num1_decimal > num2_decimal)
                            {
                                temporal_apoyo = lineas[j];
                                lineas[j] = lineas[i];
                                lineas[i] = temporal_apoyo;
                            }
                            else if (num1_decimal <= num2_decimal)
                            {
                                //no_hacer_nada
                            }
                            else
                            {
                                //error
                            }





                        }//for linea_de_abajo
                    }//for linea_de_arriba
                }//if orden alrreves
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

            registro_cambio_datos_archivo_para_actualisacion_en_multiples_programas(direccion_archivo, "ORDENAR", "");

            return lineas;
        }

        public void eliminar_fila_PARA_MULTIPLES_PROGRAMAS(string direccion_archivo, int columna_a_comparar, string comparar, object caracter_separacion_objeto = null, int donde_inica = 0)
        {
            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);






            StreamReader sr = null;
            while (sr == null)
            {


                try
                {
                    sr = new StreamReader(direccion_archivo);

                }
                catch (Exception e)
                {
                    string[] checador = leer(var_fun_GG.GG_direccion_control_errores_try);
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
                            string[] linea_espliteada = linea.Split(caracter_separacion[0][0]);
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

                registro_cambio_datos_archivo_para_actualisacion_en_multiples_programas(direccion_archivo, "ELIMINAR_MULTIPLE_FILA", "");





            }
            catch (Exception error)
            {
                sr.Close();
                sw.Close();
                File.Delete(dir_tem);//borramos el archivo temporal


            }


        }

        public string sacar_indice_del_arreglo_de_direccion(string direccion_archivo)
        {
            if (File.Exists(direccion_archivo))
            {

                string num_indice_de_direccion = null;
                for (int i = G_donde_inicia_la_tabla; i < GG_dir_bd_y_valor_inicial_bidimencional.GetLength(0); i++)
                {
                    if (GG_dir_bd_y_valor_inicial_bidimencional[i, 0] == direccion_archivo)
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




        public string Agregar_sino_existe
            (string direccion_archivo_a_checar, int num_column_comp, string comparar, string texto_a_agregar_si_no_esta = "", object caracter_separacion_obj = null)
        {
            /*
            //---------------------------------------------------------------------------------------------------------
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
                string resultado_archivo = sacar_indice_del_arreglo_de_direccion(direccion_archivo);

                if (resultado_archivo == null)
                {
                    resultado_archivo = "-1";
                }
                string[] res_esp_archivo = resultado_archivo.Split(G_caracter_para_confirmacion_o_error[0][0]);

                //encontro o no archivo
                if (Convert.ToInt32(res_esp_archivo[0]) > 0)//si res es mayor a 0 la operacioon fue exitosa si no hubo un error
                {
                    //encontro archivo y direccion en la lista
                    if (res_esp_archivo[0] == "1")
                    {

                        int num_indice_de_direccion_int = Convert.ToInt32(res_esp_archivo[1]);
                        bool encotro_info = false;

                        for (int i = G_donde_inicia_la_tabla; i < GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
                        {

                            string resul_busqueda = op_tex.busqueda_con_YY_profunda_texto(GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i], "" + num_column_comp, comparar);
                            string[] res_esp = resul_busqueda.Split(G_caracter_para_confirmacion_o_error[0][0]);
                            //encontro la informacion?
                            if (Convert.ToInt32(res_esp[0]) > 0)
                            {
                                if (res_esp[0] == "1")
                                {
                                    info_a_retornar = "-4" + G_caracter_para_confirmacion_o_error[0] + "la informacion ya existe";
                                    encotro_info = true;
                                    break;
                                }
                            }


                        }
                        //no encontro la info
                        if (encotro_info == false)
                        {
                            if (texto_a_agregar_si_no_esta != "")
                            {
                                Agregar(direccion_archivo, texto_a_agregar_si_no_esta);
                                info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + "agrego_la_informacion";
                            }
                            else
                            {
                                info_a_retornar = "-3" + G_caracter_para_confirmacion_o_error[0] + "no encontro el dato y no se puede agregar por que la variable texto_a_agregar_si_no_esta esta vacia";
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
                        bool esta = false;

                        string[] info_archivo = leer(direccion_archivo);
                        if (info_archivo == null)
                        {
                            info_archivo = new string[] { "" };
                        }
                        for (int i = G_donde_inicia_la_tabla; i < info_archivo.Length; i++)
                        {
                            string[] columnas = info_archivo[i].Split(caracter_separacion[0][0]);

                            if (columnas[num_column_comp] == comparar)
                            {


                                // cambiar_archivo_con_arreglo(direccion_archivo, info_archivo);
                                info_a_retornar = "2" + G_caracter_para_confirmacion_o_error[0] + "se_agrego_al_archivo";
                                esta = true;
                                break;
                            }
                        }
                        if (esta == false)
                        {
                            Agregar(direccion_archivo, texto_a_agregar_si_no_esta, false);
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


        public string Editar_incr_o_agrega_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID
            (string direccion_archivo_a_checar, int num_column_comp, string comparar, string numero_columnas_editar, string editar_columna, string comparar_columna_a_editar, string edit_0_increm_1_o_agregar_si_no_esta_2, string texto_a_agregar_si_no_esta = "", object caracter_separacion_obj = null, string posicion_fila = "")
        {
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
                string resultado_archivo = sacar_indice_del_arreglo_de_direccion(direccion_archivo);
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
                            if (GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length > posicion_posible)
                            {
                                resul_busqueda = op_tex.busqueda_profunda_string(GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_posible], "" + num_column_comp, comparar);
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
                                for (int i = G_donde_inicia_la_tabla; i < GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
                                {

                                    resul_busqueda = op_tex.busqueda_profunda_string(GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i], "" + num_column_comp, comparar);
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
                            for (int i = G_donde_inicia_la_tabla; i < GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
                            {

                                resul_busqueda = op_tex.busqueda_profunda_string(GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i], "" + num_column_comp, comparar);
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

                            GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_confirmada_del_producto] =
                                op_tex.editar_inc_agregar_edicion_profunda_multiple_comparacion_final_string
                                (
                                    info_a_procesar,
                                    numero_columnas_editar,
                                    editar_columna,
                                    comparar_columna_a_editar,
                                    edit_0_increm_1_o_agregar_si_no_esta_2
                                    );


                            cambiar_archivo_con_arreglo(direccion_archivo, GG_base_arreglo_de_arreglos[num_indice_de_direccion_int]);
                            info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_confirmada_del_producto];
                            encotro_info = true;


                        }
                        //no encontro la info
                        else
                        {
                            if (texto_a_agregar_si_no_esta != "")
                            {
                                Agregar(direccion_archivo, texto_a_agregar_si_no_esta);
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
                        string[] inventario = leer(direccion_archivo);
                        for (int i = G_donde_inicia_la_tabla; i < inventario.Length; i++)
                        {
                            string[] columnas = inventario[i].Split(caracter_separacion[0][0]);

                            if (columnas[num_column_comp] == comparar)
                            {

                                inventario[i] = op_tex.editar_inc_edicion_profunda_multiple_string(inventario[i], numero_columnas_editar, editar_columna, edit_0_increm_1_o_agregar_si_no_esta_2);

                                cambiar_archivo_con_arreglo(direccion_archivo, inventario);
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

        public string Editar_incr_o_agrega_MULTIPLESCOMPARACIONES_AL_FINAL_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_BUSQUEDA_ID
            (string direccion_archivo, int num_column_comp, string comparar, string numero_columnas_editar, string comparar_y_edicion_COMPARACION_FINAL, string edit_0_increm_1_o_agregar_si_no_esta_2, string texto_a_agregar_si_no_esta = "", object caracter_separacion_obj = null, string posicion_fila = "")
        {
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


                string resultado_archivo = sacar_indice_del_arreglo_de_direccion(direccion_archivo);
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
                            resul_busqueda = op_tex.busqueda_profunda_string(GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_posible], "" + num_column_comp, comparar);
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
                                for (int i = G_donde_inicia_la_tabla; i < GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
                                {

                                    resul_busqueda = op_tex.busqueda_profunda_string(GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i], "" + num_column_comp, comparar);
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
                            for (int i = G_donde_inicia_la_tabla; i < GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
                            {

                                resul_busqueda = op_tex.busqueda_profunda_string(GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i], "" + num_column_comp, comparar);
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


                            GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_confirmada_del_producto] =
                                op_tex.editar_inc_agregar_edicion_profunda_multiple_comparacion_final_MULTIPLE_A_CHECAR_string
                                (res_esp[1], numero_columnas_editar, comparar_y_edicion_COMPARACION_FINAL, edit_0_increm_1_o_agregar_si_no_esta_2);


                            cambiar_archivo_con_arreglo(direccion_archivo, GG_base_arreglo_de_arreglos[num_indice_de_direccion_int]);
                            info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_confirmada_del_producto];
                        }

                        //no encontro la info
                        else
                        {
                            if (texto_a_agregar_si_no_esta != "")
                            {
                                Agregar(direccion_archivo, texto_a_agregar_si_no_esta);
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
                        string[] inventario = leer(direccion_archivo);
                        for (int i = G_donde_inicia_la_tabla; i < inventario.Length; i++)
                        {
                            string[] columnas = inventario[i].Split(caracter_separacion[0][0]);

                            if (columnas[num_column_comp] == comparar)
                            {

                                inventario[i] = op_tex.editar_inc_edicion_profunda_multiple_string(inventario[i], numero_columnas_editar, comparar_y_edicion_COMPARACION_FINAL, edit_0_increm_1_o_agregar_si_no_esta_2);

                                cambiar_archivo_con_arreglo(direccion_archivo, inventario);
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
        public string Editar_incr_o_agrega_COMPARACION_YY_info_dentro_de_celda_Y_AGREGA_fila_SI_NO_ESTA_y_no_es_vacia_la_variable_es_multiple_con_comparacion_final_BUSQUEDA_ID
            (string direccion_archivo_a_checar, string num_column_comp, string comparar__, string numero_columnas_editar, string comparar_con_editar_columna, string edit_0_increm_1_o_agregar_si_no_esta_2, string texto_a_agregar_si_no_esta = "", object caracter_separacion_obj = null, string posicion_fila = "")
        {
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
                string resultado_archivo = sacar_indice_del_arreglo_de_direccion(direccion_archivo);
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
                            resul_busqueda = op_tex.busqueda_profunda_string(GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_posible], "" + num_column_comp, comparar__);
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
                                for (int i = G_donde_inicia_la_tabla; i < GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
                                {

                                    resul_busqueda = op_tex.busqueda_con_YY_profunda_texto(GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i], "" + num_column_comp, comparar__);
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
                            for (int i = G_donde_inicia_la_tabla; i < GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
                            {

                                resul_busqueda = op_tex.busqueda_con_YY_profunda_texto(GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i], "" + num_column_comp, comparar__);
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


                            string checador = GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_confirmada_del_producto]
                                            =
                                            op_tex.editar_inc_agregar_edicion_profunda_multiple_comparacion_final_MULTIPLE_A_CHECAR_string

                                            (res_esp[1],
                                            numero_columnas_editar,
                                            comparar_con_editar_columna,
                                            edit_0_increm_1_o_agregar_si_no_esta_2);


                            cambiar_archivo_con_arreglo(direccion_archivo, GG_base_arreglo_de_arreglos[num_indice_de_direccion_int]);
                            info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_confirmada_del_producto];
                        }


                        else
                        {
                            if (texto_a_agregar_si_no_esta != "")
                            {
                                Agregar(direccion_archivo, texto_a_agregar_si_no_esta);
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
                    string[] checador = leer(var_fun_GG.GG_direccion_control_errores_try);
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

                registro_cambio_datos_archivo_para_actualisacion_en_multiples_programas(direccion_archivo, "EDITAR", "" + num_fila);


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

        public string Editar_fila_espesifica(string direccion_archivo, int num_fila, string editar_info, bool con_arreglo = true)
        {

            if (con_arreglo == true)
            {
                string[] res_indice = sacar_indice_del_arreglo_de_direccion(direccion_archivo).Split(G_caracter_para_confirmacion_o_error[0][0]);
                int indice = Convert.ToInt32(res_indice[1]);
                GG_base_arreglo_de_arreglos[indice][num_fila] = editar_info;
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
                    string[] checador = leer(var_fun_GG.GG_direccion_control_errores_try);
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


                registro_cambio_datos_archivo_para_actualisacion_en_multiples_programas(direccion_archivo, "EDITAR", "" + num_fila);


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

        public string[] Editar_o_incr_espesifico_si_no_esta_agrega_linea(string direccion_archivo, int num_column_comp, string comparar, string numero_columnas_editar, string editar_columna, string edit_0_o_increm_1 = null, string linea_a_agregar_si_no_lo_encuentra = null, object caracter_separacion_objeto = null, string posicion_fila = "")
        {
            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);



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

            int num_indice_de_direccion_int = Convert.ToInt32(sacar_indice_del_arreglo_de_direccion(direccion_archivo));

            try
            {




                bool encotro_info = false;
                string info_a_procesar = "";
                string resul_busqueda = null;
                string[] res_esp = null;
                int posicion_confirmada_del_producto = -1;

                if (posicion_fila != "")
                {
                    int posicion_posible = Convert.ToInt32(posicion_fila);
                    resul_busqueda = op_tex.busqueda_profunda_string(GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_posible], "" + num_column_comp, comparar);
                    res_esp = resul_busqueda.Split(G_caracter_para_confirmacion_o_error[0][0]);

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
                        for (int i = G_donde_inicia_la_tabla; i < GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
                        {
                            string[] columnas = GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i].Split(caracter_separacion[0][0]);

                            resul_busqueda = op_tex.busqueda_profunda_string(GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i], "" + num_column_comp, comparar);
                            res_esp = resul_busqueda.Split(G_caracter_para_confirmacion_o_error[0][0]);


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
                    for (int i = G_donde_inicia_la_tabla; i < GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
                    {
                        string[] columnas = GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i].Split(caracter_separacion[0][0]);

                        resul_busqueda = op_tex.busqueda_profunda_string(GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i], "" + num_column_comp, comparar);
                        res_esp = resul_busqueda.Split(G_caracter_para_confirmacion_o_error[0][0]);


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
                    GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_confirmada_del_producto] = op_arr.editar_incr_string_funcion_recursiva(GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][posicion_confirmada_del_producto], numero_columnas_editar, editar_columna, edit_0_o_increm_1);

                    cambiar_archivo_con_arreglo(direccion_archivo, GG_base_arreglo_de_arreglos[num_indice_de_direccion_int]);
                }
                else
                {
                    if (linea_a_agregar_si_no_lo_encuentra != null)
                    {
                        Agregar(direccion_archivo, linea_a_agregar_si_no_lo_encuentra);
                    }

                }

                sw_bandera.Close();
            }
            catch
            {
                sw_bandera.Close();
            }





            return GG_base_arreglo_de_arreglos[num_indice_de_direccion_int];
        }


        public string cambiar_archivo_con_arreglo(string direccion_archivo, string[] arreglo, object caracter_separacion_objeto = null, object stream_reader_o_write = null)
        {
            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);


            string[] dir_sep = extraer_separado_carpetas_nombreArchivo_extencion(direccion_archivo);
            dir_sep[0] = dir_sep[0] + "\\" + G_direccion_base_archivos_bandera;
            string dir_bandera = dir_sep[0] + "\\" + dir_sep[1] + "." + dir_sep[2];
            //este archivo bandera es para que no se agarre el archivo otro programa antes de sustituirlo
            dir_bandera = dir_bandera + direccion_archivo.Replace(".TXT", "_BANDERA_CAA.TXT");
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


                registro_cambio_datos_archivo_para_actualisacion_en_multiples_programas(direccion_archivo, "EDITAR_MULTIPLE_FILAS", "");
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


        private string[] G_direcciones_no_rara_registros =
            {
            var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[3,0],//archivo_donde_se_hacen_los_registros
            var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[0,0],
            var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[1,0],
            var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[2, 0],
            };
        public void registro_cambio_datos_archivo_para_actualisacion_en_multiples_programas(string direccion_archivo_modificado, string operacion, string num_fila_o_si_es_agregue_datos)
        {

            //operacion= CREACION_ARCHIVO  AGREGAR ORDENAR EDITAR     EDITAR_MULTIPLE_FILAS  BORRAR_DATOS  ELIMINAR_FILA ELIMINAR_MULTIPLE_FILA  
            num_fila_o_si_es_agregue_datos = num_fila_o_si_es_agregue_datos.Replace("\n", G_caracter_para_transferencia_entre_archivos[1]);
            Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[3, 0]);
            string hora = DateTime.Now.ToString("HHmmss");
            string datos = hora + G_caracter_para_transferencia_entre_archivos[0] + direccion_archivo_modificado + G_caracter_para_transferencia_entre_archivos[0] + operacion + G_caracter_para_transferencia_entre_archivos[0] + num_fila_o_si_es_agregue_datos;

            bool es_archivo_que_debe_registrar = true;
            for (int i = 0; i < G_direcciones_no_rara_registros.Length; i++)
            {
                string temp_direccion_bandera = G_direcciones_no_rara_registros[i].Replace(".TXT", "_BANDERA.TXT");
                if (direccion_archivo_modificado == G_direcciones_no_rara_registros[i] || direccion_archivo_modificado == temp_direccion_bandera)
                {
                    es_archivo_que_debe_registrar = false;
                    break;
                }
            }
            if (es_archivo_que_debe_registrar)
            {
                string archivo_donde_se_registran = var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[3, 0];
                Agregar(archivo_donde_se_registran, datos);
            }

        }

        public void chequeo_error_try(string direccionArchivo, Exception e, string numero_chequeo)
        {
            DialogResult result = MessageBox.Show(e.Message, e.Message + "\nError quieres crear el archivo sie es el error \"No\" para volver a intentar \"cancelar\" para cerrar el programa", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);

            if (result == DialogResult.Yes)
            {
                Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(direccionArchivo, "sin informacion");
            }
            else if (result == DialogResult.No)
            {

            }
            else if (result == DialogResult.Cancel)
            {
                Environment.Exit(0);
            }
        }


        //fin clase------------------------------------------------------------------
    }
}
