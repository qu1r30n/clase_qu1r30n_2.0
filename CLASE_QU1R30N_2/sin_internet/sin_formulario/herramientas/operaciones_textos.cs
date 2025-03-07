using System;
using System.Linq;

namespace CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas
{
    class operaciones_textos
    {

        public string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        public string[] G_caracter_separacion_para_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        public string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_para_confirmacion_o_error;


        principal enl_princ = new principal();





        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        var_fun_GG vf_GG = new var_fun_GG();

        public string join_paresido_simple(char caracter_union_filas, string[] texto, string columna_extraer = null, string caracter_union_columnas = null)
        {
            string resultado = "";
            if (columna_extraer != null)
            {
                char caracter_union_columnas_caracter = Convert.ToChar(caracter_union_columnas);
                for (int i = 0; i < texto.Length; i++)
                {
                    string[] columnas_extraer_arreglo = columna_extraer.Split(caracter_union_columnas_caracter);
                    for (int j = 0; j < columnas_extraer_arreglo.Length; j++)
                    {
                        string[] temp;
                        temp = texto[i].Split(caracter_union_columnas_caracter);
                        resultado = resultado + temp[Convert.ToInt32(columnas_extraer_arreglo[j])] + caracter_union_columnas;

                    }
                    resultado = Trimend_paresido(resultado, caracter_union_columnas_caracter);
                    resultado = resultado + caracter_union_filas;

                }
            }
            else
            {

                for (int i = 0; i < texto.Length; i++)
                {
                    resultado = resultado + texto[i] + caracter_union_filas;
                }
            }
            resultado = Trimend_paresido(resultado, caracter_union_filas);

            return resultado;
        }

        public string joineada_paraesida_y_quitador_de_extremos_del_string(object arreglo_objeto, object caracter_separacion_objeto = null, int restar_cuantas_ultimas_o_primeras_celdas = 0, bool restar_primera_celda = false)
        {
            
            string[] arreglo = null;

            if (arreglo_objeto is string)
            {

                arreglo = arreglo_objeto.ToString().Split(G_caracter_separacion[0][0]);
                if (arreglo.Length <= 1)
                {
                    char[] arreglo_letras = arreglo_objeto.ToString().ToCharArray();
                    arreglo = new string[arreglo_letras.Length];
                    for (int i = 0; i < arreglo.Length; i++)
                    {
                        arreglo[i] = "" + arreglo_letras[i];
                    }


                }
            }
            else if (arreglo_objeto is string[])
            {
                arreglo = (string[])arreglo_objeto;
            }


            string a_retornar = "";

            if (restar_primera_celda)
            {
                if (arreglo != null)
                {


                    for (int i = restar_cuantas_ultimas_o_primeras_celdas; i < arreglo.Length; i++)
                    {
                        if (arreglo_objeto is string)
                        {
                            a_retornar = a_retornar + arreglo[i];
                        }
                        else
                        {


                            if (i < arreglo.Length - 1)
                            {

                                a_retornar = a_retornar + arreglo[i] + G_caracter_separacion[0];
                            }
                            else
                            {
                                a_retornar = a_retornar + arreglo[i];
                            }
                        }
                    }
                }


            }

            else
            {
                int cantidad_celdas_a_retornar_del_arreglo = arreglo.Length - restar_cuantas_ultimas_o_primeras_celdas;
                for (int i = 0; i < cantidad_celdas_a_retornar_del_arreglo; i++)
                {
                    if (i < cantidad_celdas_a_retornar_del_arreglo - 1)
                    {
                        a_retornar = a_retornar + arreglo[i] + G_caracter_separacion[0];
                    }
                    else
                    {
                        a_retornar = a_retornar + arreglo[i];
                    }
                }
            }

            return a_retornar;
        }


        public string joineada_paraesida_SIN_NULOS_y_quitador_de_extremos_del_string(object arreglo_objeto, object caracter_separacion_objeto = null, int restar_cuantas_ultimas_o_primeras_celdas = 0, bool restar_primera_celda = false)
        {
            
            string[] arreglo = null;

            if (arreglo_objeto is string)
            {

                arreglo = arreglo_objeto.ToString().Split(G_caracter_separacion[0][0]);
                if (arreglo.Length <= 1)
                {
                    char[] arreglo_letras = arreglo_objeto.ToString().ToCharArray();
                    arreglo = new string[arreglo_letras.Length];
                    for (int i = 0; i < arreglo.Length; i++)
                    {
                        arreglo[i] = "" + arreglo_letras[i];
                    };


                }
            }

            else if (arreglo_objeto is string[])
            {
                arreglo = (string[])arreglo_objeto;
            }


            string a_retornar = "";

            if (restar_primera_celda)
            {
                for (int i = restar_cuantas_ultimas_o_primeras_celdas; i < arreglo.Length; i++)
                {
                    if (i == 0)
                    {
                        if (arreglo[i] != null)
                        {
                            a_retornar = a_retornar + arreglo[i];
                        }

                    }
                    else
                    {
                        if (arreglo[i] != null)
                        {
                            a_retornar = a_retornar + G_caracter_separacion[0] + arreglo[i];

                        }

                    }
                }

            }

            else
            {
                if (arreglo != null)
                {
                    int cantidad_celdas_a_retornar_del_arreglo = arreglo.Length - restar_cuantas_ultimas_o_primeras_celdas;
                    for (int i = 0; i < cantidad_celdas_a_retornar_del_arreglo; i++)
                    {
                        if (i == 0)
                        {
                            if (arreglo[i] != null)
                            {
                                a_retornar = a_retornar + arreglo[i];
                            }
                        }
                        else
                        {
                            if (arreglo[i] != null)
                            {
                                a_retornar = a_retornar + G_caracter_separacion[0] + arreglo[i];
                            }
                        }
                    }
                }

            }

            return a_retornar;
        }

        public string Trimend_paresido(string texto, object caracter_separacion_objeto = null)
        {

            string texto_editado = "";
            string[] texto_spliteado = texto.Split(G_caracter_separacion[0][0]);

            if (texto_spliteado[texto_spliteado.Length - 1] == "")
            {
                for (int i = 0; i < texto_spliteado.Length; i++)
                {
                    if (i < texto_spliteado.Length - 2)
                    {
                        texto_editado = texto_editado + texto_spliteado[i] + G_caracter_separacion[0];
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
                        texto_editado = texto_editado + texto_spliteado[i] + G_caracter_separacion[0];
                    }

                    else
                    {
                        texto_editado = texto_editado + texto_spliteado[i];
                    }
                }
            }


            return texto_editado;
        }

        public string concatenacion_filas_de_un_archivo(string direccion_archivo, bool poner_num_fila = false, object caracter_separacion_obj = null)
        {
            //Tex_base bas = new Tex_base();
            
            string texto_a_agregar_concatenacion = "";


            //string[] info_a_concarenar = bas.Leer(direccion_archivo);
            string[] info_a_concarenar = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "LEER_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + direccion_archivo).Split(G_caracter_separacion_funciones_espesificas[4][0]);

            for (int i = G_donde_inicia_la_tabla; i < info_a_concarenar.Length; i++)
            {
                string num_fil = "";
                if (poner_num_fila)
                {
                    num_fil = i + ") ";
                }
                texto_a_agregar_concatenacion = concatenacion_caracter_separacion(texto_a_agregar_concatenacion, num_fil + info_a_concarenar[i], G_caracter_separacion[0]);

            }
            return texto_a_agregar_concatenacion;
        }

        public string concatenacion_filas_de_un_arreglo(string[] arreglo, bool poner_num_fila = false, object caracter_separacion_obj = null)
        {

            string mensaje_de_bienvenida_a_enviar = "";
            for (int i = G_donde_inicia_la_tabla; i < arreglo.Length; i++)
            {
                string num_fil = "";
                if (poner_num_fila)
                {
                    num_fil = i + ") ";
                }
                mensaje_de_bienvenida_a_enviar = concatenacion_caracter_separacion(mensaje_de_bienvenida_a_enviar, num_fil + arreglo[i], G_caracter_separacion[0]);

            }
            return mensaje_de_bienvenida_a_enviar;
        }

        public string concatenacion_filas_de_un_arreglo_bidimencional(string[,] arreglo, bool poner_num_fila = false, object caracter_separacion_obj = null)
        {



            string mensaje_de_bienvenida_a_enviar = "";

            for (int i = 0; i < arreglo.GetLength(0); i++)
            {
                string tiene_informacion = arreglo[i, 0];
                if (tiene_informacion != null)
                {
                    string concatenado = "";
                    for (int j = 0; j < arreglo.GetLength(1); j++)
                    {

                        concatenado = concatenacion_caracter_separacion(concatenado, arreglo[i, j], caracter_separacion_obj);

                    }


                    string num_fil = "";
                    if (poner_num_fila)
                    {
                        num_fil = i + ") ";
                    }
                    mensaje_de_bienvenida_a_enviar = concatenacion_caracter_separacion(mensaje_de_bienvenida_a_enviar, num_fil + concatenado, '\n');
                }

            }
            return mensaje_de_bienvenida_a_enviar;
        }

        public string concatenacion_caracter_separacion(string tex_a_cambiar, string tex_a_agregar, object caracter_separacion_objeto = null, string tipo_concatenacion = "CONCATENACION_NORMAL")
        {

            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            if (tex_a_cambiar != "" && tex_a_cambiar != null)
            {
                if (tipo_concatenacion== "CONCATENACION_NORMAL")
                {
                    tex_a_cambiar = tex_a_cambiar + caracter_separacion[0] + tex_a_agregar;
                }
                else if(tipo_concatenacion == "CONCATENACION_INVERSA")
                {
                    tex_a_cambiar = tex_a_agregar + caracter_separacion[0] + tex_a_cambiar;
                }
                
            }
            else
            {
                if (tex_a_cambiar == null)
                {
                    tex_a_cambiar = "";
                }
                tex_a_cambiar = tex_a_cambiar + tex_a_agregar;
            }



            return tex_a_cambiar;



        }


        public string busqueda_profunda_string(string texto, string columnas_a_recorrer, string comparar___, string columnas_a_retornar = null, object caracter_separacion_objeto = null)
        {

            string[] arr_col_rec = null;
            //caracter_separacion[0][0] el primer [0] es la celda y el segundo [0] es el caracter para no usar convert.tochar
            arr_col_rec = columnas_a_recorrer.Split(G_caracter_separacion[0][0]);

            string tem_linea = texto;
            string[] espliteado = null;
            int j = 0;
            do
            {

                espliteado = tem_linea.Split(G_caracter_separacion[j][0]);
                //caracter_separacion[j][0] el primer [j] es la celda y el segundo [0] es el caracter para no usar convert.tochar
                tem_linea = espliteado[Convert.ToInt32(arr_col_rec[j])];

                j++;
            } while (j < arr_col_rec.Length);


            //comparacion--------------------------------------------------------------------------
            if (tem_linea == comparar___)
            {
                return "1" + G_caracter_separacion_funciones_espesificas[0] + texto;
            }


            return "0" + G_caracter_separacion_funciones_espesificas[0] + "no se_encontro";
        }

        public string busqueda_profunda_comparacion_final_string(string texto, string columnas_a_recorrer, string comparar___, string columnas_a_retornar = null, object caracter_separacion_objeto = null)
        {

            string[] arr_col_rec = null;
            //caracter_separacion[0][0] el primer [0] es la celda y el segundo [0] es el caracter para no usar convert.tochar
            arr_col_rec = columnas_a_recorrer.Split(G_caracter_separacion[0][0]);

            string tem_linea = texto;
            string[] espliteado = null;
            int j = 0;
            do
            {

                espliteado = tem_linea.Split(G_caracter_separacion[j][0]);
                //caracter_separacion[j][0] el primer [j] es la celda y el segundo [0] es el caracter para no usar convert.tochar
                tem_linea = espliteado[Convert.ToInt32(arr_col_rec[j])];

                j++;
            } while (j < arr_col_rec.Length);


            //comparacion--------------------------------------------------------------------------
            if (tem_linea == comparar___)
            {
                return "1" + G_caracter_separacion_funciones_espesificas[0] + texto;
            }


            return "0" + G_caracter_separacion_funciones_espesificas[0] + "no se_encontro";
        }

        public string busqueda_con_YY_profunda_texto(string texto, string columnas_a_recorrer, string comparaciones, object caracter_separacion_objeto = null, object caracter_separacion_para_busqueda_multiple_profuda_obj = null)
        {
            operaciones_arreglos op_arr = new operaciones_arreglos();
            //editar_busqueda_multiple_edicion_profunda_arreglo(texto, "2|1|1~2|1|0", "5~9", "2|1|1~1~2|1|0", "10~10~10","1~1~0");

            

            //caracter_separacion[0][0] el primer [0] es la celda y el segundo [0] es el caracter para no usar convert.tochar
            string[] arr_comparaciones_a_rec = columnas_a_recorrer.Split(G_caracter_separacion_para_funciones_espesificas[0][0]);
            string[] arr_comparaciones___ = comparaciones.Split(G_caracter_separacion_para_funciones_espesificas[0][0]);


                    

            bool[] chequeo_todas_las_comparaciones = new bool[arr_comparaciones_a_rec.Length];

            string[][] niveles_de_profundidad = null;
            for (int l = 0; l < arr_comparaciones_a_rec.Length; l++)
            {
                string tem_linea = texto;
                string[] arr_col_rec = arr_comparaciones_a_rec[l].Split(G_caracter_separacion[0][0]);



                if (arr_col_rec.Length > 1)
                {

                    string temp_opciones_comp = joineada_paraesida_y_quitador_de_extremos_del_string(arr_comparaciones_a_rec[l], restar_cuantas_ultimas_o_primeras_celdas: 1);
                    string[] arr_info = op_arr.extraer_arreglo_dentro_de_un_string(tem_linea, temp_opciones_comp);
                    for (int m = 0; m < arr_info.Length; m++)
                    {
                        string[] elemento_espliteado = arr_info[m].Split(G_caracter_separacion[arr_col_rec.Length][0]);
                        tem_linea = elemento_espliteado[Convert.ToInt32(arr_col_rec[arr_col_rec.Length - 1])];
                    }

                }
                else
                {
                    niveles_de_profundidad = op_arr.agregar_arreglo_a_arreglo_de_arreglos(niveles_de_profundidad, tem_linea.Split(G_caracter_separacion[0][0]));
                    tem_linea = niveles_de_profundidad[0][Convert.ToInt32(arr_col_rec[0])];
                }
                //string tem_linea_2 = "";
                //comparacion--------------------------------------------------------------------------
                chequeo_todas_las_comparaciones[l] = false;
                if (tem_linea == arr_comparaciones___[l])
                {
                    chequeo_todas_las_comparaciones[l] = true;


                }

            }
            bool estan_todas_las_comparaciones = true;
            for (int m = 0; m < chequeo_todas_las_comparaciones.Length; m++)
            {
                if (chequeo_todas_las_comparaciones[m] == false)
                {
                    estan_todas_las_comparaciones = false;
                    break;
                }
            }
            if (estan_todas_las_comparaciones)
            {


                return "1" + G_caracter_separacion_funciones_espesificas[0] + texto;
            }



            return "0" + G_caracter_separacion_funciones_espesificas[0] + "no se_encontro";

        }


        public string editar_incr_string_funcion_recursiva(string texto, object columnas_a_recorrer, string info_a_sustituir, string edit_0_o_increm_1 = null, object caracter_separacion_objeto = null, object caracter_separacion_funciones_especificas_obj = null)
        {
            //string texto="0|1|2¬3°4¬5|6", object columnas_a_recorrer="2°1°1", string info_a_sustituir="10", string edit_0_o_increm_1 = "1",  string[] caracter_separacion = null, string caracter_separacion_dif_a_texto = "°"

            /*ejemplo puesto
                    string[] indices_espliteado = indices_a_editar.Split(caracter_separacion[0][0]);
                    string[] info_editar_espliteado = info_editar.Split(caracter_separacion[0][0]);
                    string[] edit_0_o_increm_1_espliteado = edit_0_o_increm_1.Split(caracter_separacion[0][0]);
                    for (int k = 0; k < indices_espliteado.Length; k++)
                    {
                        areglo[i] = editar_incr_string_funcion_recursiva(areglo[i], indices_espliteado[k], info_editar_espliteado[k], edit_0_o_increm_1_espliteado[k], caracter_separacion_dif_a_texto:"°");
                    }
            
            */
            
            

            string[] espliteado_columnas_recorrer = { };

            //Sí es un string lo splitea Este normalmente es al inicio de la función 
            if (columnas_a_recorrer is string)
            {
                if (caracter_separacion_funciones_especificas_obj == null)
                {
                    espliteado_columnas_recorrer = columnas_a_recorrer.ToString().Split(G_caracter_separacion[0][0]);

                }
                else
                {
                    espliteado_columnas_recorrer = columnas_a_recorrer.ToString().Split(G_caracter_separacion_para_funciones_espesificas[0][0]);
                }

            }
            else if (columnas_a_recorrer is string[] temp)
            {

                espliteado_columnas_recorrer = temp;
            }
            string[] espliteado_texto = null;
            if (espliteado_columnas_recorrer.Length > 0)
            {
                espliteado_texto = texto.Split(G_caracter_separacion[0][0]);
            }
            else
            {
                espliteado_texto = new string[] { texto };

            }


            //En esta parte Se inicia desde el segundo elemento y se guardan los caracteres y
            //las columnas para sí hay otro elemento En el arreglo múltiple 
            string texto_a_retornar = "";

            string[] tem_array_caracter_separacion = G_caracter_separacion;
            if (espliteado_columnas_recorrer.Length > 0)
            {
                string[] tem_array_col_recorrer = espliteado_columnas_recorrer;
                //espliteado_texto = texto.Split(Convert.ToChar(tem_array_caracter_separacion[0]));
                texto_a_retornar = espliteado_texto[Convert.ToInt32(tem_array_col_recorrer[0])];

                tem_array_col_recorrer = new string[espliteado_columnas_recorrer.Length - 1];
                tem_array_caracter_separacion = new string[G_caracter_separacion.Length - 1];
                for (int i = 1; i < espliteado_columnas_recorrer.Length; i++)
                {

                    tem_array_col_recorrer[i - 1] = espliteado_columnas_recorrer[i];

                }
                for (int i = 1; i < G_caracter_separacion.Length; i++)
                {
                    tem_array_caracter_separacion[i - 1] = G_caracter_separacion[i];
                }


                espliteado_texto[Convert.ToInt32(espliteado_columnas_recorrer[0])] = editar_incr_string_funcion_recursiva(texto_a_retornar, tem_array_col_recorrer, info_a_sustituir, edit_0_o_increm_1, tem_array_caracter_separacion); // Llamada recursiva


            }
            else
            {
                if (edit_0_o_increm_1 == "1")
                {
                    espliteado_texto[0] = "" + (Convert.ToDouble(espliteado_texto[0]) + Convert.ToDouble(info_a_sustituir));
                }
                else
                {
                    espliteado_texto[0] = info_a_sustituir;
                }

            }

            string retornar = string.Join(G_caracter_separacion[0], espliteado_texto);
            return retornar;
        }

        public string editar_inc_agregar_edicion_profunda_multiple_comparacion_final_string
            (
                string texto,
                string indices_a_editar,
                string info_editar,
                string comparacion_antes_para_saber_cual_editar,
                string edit_0_o_increm_1 = null,
                object caracter_separacion_objeto = null,
                object caracter_separacion_para_busqueda_multiple_profuda_objeto = null
            )
        {
            operaciones_arreglos op_arr = new operaciones_arreglos();

            // Obtener caracteres de separación
            
            
            string[] indices_a_editar_esp = indices_a_editar.Split(G_caracter_separacion_para_funciones_espesificas[0][0]);
            string[] info_editar_esp = info_editar.Split(G_caracter_separacion_para_funciones_espesificas[0][0]);
            string[] edit_0_o_increm_1_agrega_2_espliteado = edit_0_o_increm_1.Split(G_caracter_separacion_para_funciones_espesificas[0][0]);
            string[] comparacion_esplit = comparacion_antes_para_saber_cual_editar.Split(G_caracter_separacion_para_funciones_espesificas[0][0]);

            for (int k = 0; k < indices_a_editar_esp.Length; k++)
            {
                string res_ext = op_arr.extraer_arreglo_dentro_de_un_string_y_ponerolo_en_string(texto, indices_a_editar_esp[k]);
                string[] res_ext_esp = res_ext.Split(G_caracter_separacion_funciones_espesificas[0][0]);
                int indice_caracter = Convert.ToInt32(res_ext_esp[2]);

                if (Convert.ToInt32(res_ext_esp[0]) > 0)//si res es mayor a 0 la operacioon fue exitosa si no hubo un error
                {
                    if (res_ext_esp[0] == "1")
                    {
                        string[] info_extraida = res_ext_esp[1].Split(G_caracter_separacion[indice_caracter][0]);
                        bool encontro_dato_a_editar = false;

                        string num_celdas = "0";
                        for (int l = 0; l < info_extraida.Length; l++)
                        {
                            string[] datos_a_checar_para_editar = info_extraida[l].Split(G_caracter_separacion[indice_caracter + 1][0]);
                            num_celdas = "" + datos_a_checar_para_editar.Length;
                            if (info_extraida[l] != "")
                            {
                                //si solo es 1 va a editar agregar o incrementar la celda ejemplo ceda provedor1°provedor2
                                //o 1°2 e incrementara creo 
                                //pero  si son mas comparara e incrementara el siguiente provedor1¬1°provedor2¬5 e incrementara 1 y 5 o editara o agregara masomenos recuerdo
                                if (datos_a_checar_para_editar.Length == 1)
                                {
                                    //si lo encuentra y tiene el numero 2 lo agrega
                                    if (edit_0_o_increm_1_agrega_2_espliteado[k] == "2")
                                    {
                                        //datos_a_checar_para_editar = editar_o_incrementar_agrega_informacion(datos_a_checar_para_editar, info_editar_esp[k], edit_0_o_increm_1_agrega_2_espliteado[k], 0, caracter_separacion[indice_caracter]);
                                        //asi estaba antes if (datos_a_checar_para_editar[0] == info_editar_esp[k])
                                        if (datos_a_checar_para_editar[0] == comparacion_esplit[k])
                                        {

                                            edit_0_o_increm_1_agrega_2_espliteado[k] = "0";
                                            encontro_dato_a_editar = true;
                                        }
                                        else
                                        {

                                        }

                                    }
                                    else
                                    {
                                        datos_a_checar_para_editar = editar_o_incrementar_agrega_informacion(datos_a_checar_para_editar, info_editar_esp[k], edit_0_o_increm_1_agrega_2_espliteado[k], 0, G_caracter_separacion[indice_caracter]);
                                        info_extraida[l] = string.Join(G_caracter_separacion[indice_caracter + 1], datos_a_checar_para_editar);
                                        edit_0_o_increm_1_agrega_2_espliteado[k] = "0";
                                        encontro_dato_a_editar = true;

                                    }


                                }
                                else if (datos_a_checar_para_editar[0] == comparacion_esplit[k])
                                {
                                    //si tiene el 2 no hace nada por que ya esta
                                    if (edit_0_o_increm_1_agrega_2_espliteado[k] == "2")
                                    {

                                    }
                                    //si encuentra incrementa
                                    else
                                    {
                                        datos_a_checar_para_editar = editar_o_incrementar_agrega_informacion(datos_a_checar_para_editar, info_editar_esp[k], edit_0_o_increm_1_agrega_2_espliteado[k], 1);

                                    }
                                    info_extraida[l] = string.Join(G_caracter_separacion[indice_caracter + 1], datos_a_checar_para_editar);
                                    encontro_dato_a_editar = true;
                                    edit_0_o_increm_1_agrega_2_espliteado[k] = "0";
                                    break;
                                }
                            }
                        }

                        res_ext_esp[1] = string.Join(G_caracter_separacion[indice_caracter], info_extraida);
                        if (!encontro_dato_a_editar)
                        {
                            //si no lo encuentra agrega
                            if (edit_0_o_increm_1_agrega_2_espliteado[k] == "2")
                            {
                                res_ext_esp[1] = agregar_nueva_informacion(res_ext_esp[1], comparacion_esplit[k], info_editar_esp[k], num_celdas, new string[] { G_caracter_separacion[indice_caracter], G_caracter_separacion[indice_caracter + 1] });
                            }
                            else
                            {
                                res_ext_esp[1] = agregar_nueva_informacion(res_ext_esp[1], comparacion_esplit[k], info_editar_esp[k], num_celdas, new string[] { G_caracter_separacion[indice_caracter], G_caracter_separacion[indice_caracter + 1] });
                                edit_0_o_increm_1_agrega_2_espliteado[k] = "0";
                            }

                        }


                        //texto = editar_incr_string_funcion_recursiva(texto, indices_a_editar_esp[k], res_ext_esp[1], edit_0_o_increm_1_agrega_2_espliteado[k], caracter_separacion_funciones_especificas_obj: caracter_separacion_profunda);
                        texto = editar_incr_string_funcion_recursiva(texto, indices_a_editar_esp[k], res_ext_esp[1], edit_0_o_increm_1_agrega_2_espliteado[k], caracter_separacion_funciones_especificas_obj: G_caracter_separacion);
                    }
                }
            }

            return texto;
        }



        public string editar_inc_agregar_edicion_profunda_multiple_comparacion_final_MULTIPLE_A_CHECAR_string
            (
                string texto,
                string indices_a_editar,
                string comparacion_con_edicion_antes_para_saber_cual_editar,
                string edit_0_o_increm_1 = null,
                object caracter_separacion_objeto = null,
                string caracter_separacion_para_busqueda_multiple_profuda_objeto = null
            )
        {
            operaciones_arreglos op_arr = new operaciones_arreglos();

            // Obtener caracteres de separación
            
            
            string[] indices_a_editar_esp = indices_a_editar.Split(G_caracter_separacion_para_funciones_espesificas[0][0]);

            string[] edit_0_o_increm_1_agrega_2_espliteado = edit_0_o_increm_1.Split(G_caracter_separacion_para_funciones_espesificas[0][0]);
            string[] comparacion_con_edicion_esp = comparacion_con_edicion_antes_para_saber_cual_editar.Split(G_caracter_separacion_para_funciones_espesificas[0][0]);

            for (int k = 0; k < indices_a_editar_esp.Length; k++)
            {
                string res_ext = op_arr.extraer_arreglo_dentro_de_un_string_y_ponerolo_en_string(texto, indices_a_editar_esp[k]);
                string[] res_ext_esp = res_ext.Split(G_caracter_separacion_funciones_espesificas[0][0]);
                int indice_caracter = Convert.ToInt32(res_ext_esp[2]);
                //extrajo el arreglo
                if (Convert.ToInt32(res_ext_esp[0]) > 0)//si res es mayor a 0 la operacioon fue exitosa si no hubo un error
                {
                    if (res_ext_esp[0] == "1")
                    {

                        string[] info_extraida = res_ext_esp[1].Split(G_caracter_separacion[indice_caracter][0]);
                        bool encontro_dato_a_editar = false;

                        string num_celdas = "0";
                        for (int l = 0; l < info_extraida.Length; l++)
                        {
                            string[] datos_a_checar_para_editar = info_extraida[l].Split(G_caracter_separacion[indice_caracter + 1][0]);
                            num_celdas = "" + datos_a_checar_para_editar.Length;
                            //dato a checar es diferente de ""
                            if (info_extraida[l] != "")
                            {
                                //si solo es 1 va a editar agregar o incrementar la celda ejemplo ceda provedor1°provedor2
                                //o 1°2 e incrementara creo 
                                //pero  si son mas comparara e incrementara el siguiente provedor1¬1°provedor2¬5 e incrementara 1 y 5 o editara o agregara masomenos recuerdo

                                string[] opciones_dentro_comparacion = comparacion_con_edicion_esp[k].Split(G_caracter_separacion[1][0]);
                                for (int m = 0; m < opciones_dentro_comparacion.Length; m++)
                                {

                                    string[] info_opc_com = opciones_dentro_comparacion[m].Split(G_caracter_separacion[2][0]);


                                    if (info_opc_com.Length == 1)
                                    {
                                        //si lo encuentra y tiene el numero 2 lo agrega
                                        if (edit_0_o_increm_1_agrega_2_espliteado[k] == "2")
                                        {
                                            //datos_a_checar_para_editar = editar_o_incrementar_agrega_informacion(datos_a_checar_para_editar, info_editar_esp[k], edit_0_o_increm_1_agrega_2_espliteado[k], 0, caracter_separacion[indice_caracter]);
                                            //asi estaba antes if (datos_a_checar_para_editar[0] == info_editar_esp[k])
                                            if (datos_a_checar_para_editar[0] == info_opc_com[0])
                                            {

                                                edit_0_o_increm_1_agrega_2_espliteado[k] = "0";
                                                encontro_dato_a_editar = true;
                                            }
                                            else
                                            {

                                            }

                                        }
                                        else
                                        {

                                            datos_a_checar_para_editar = editar_o_incrementar_agrega_informacion(datos_a_checar_para_editar, comparacion_con_edicion_esp[k], edit_0_o_increm_1_agrega_2_espliteado[k], 0, G_caracter_separacion[indice_caracter]);
                                            info_extraida[l] = string.Join(G_caracter_separacion[indice_caracter + 1], datos_a_checar_para_editar);
                                            edit_0_o_increm_1_agrega_2_espliteado[k] = "0";
                                            encontro_dato_a_editar = true;

                                        }


                                    }

                                    else if (datos_a_checar_para_editar[0] == info_opc_com[0])
                                    {
                                        //si tiene el 2 no hace nada por que ya esta
                                        if (edit_0_o_increm_1_agrega_2_espliteado[k] == "2")
                                        {

                                        }
                                        //si encuentra incrementa
                                        else
                                        {

                                            datos_a_checar_para_editar = editar_o_incrementar_agrega_informacion(datos_a_checar_para_editar, info_opc_com[1], edit_0_o_increm_1_agrega_2_espliteado[k], 1);

                                        }
                                        info_extraida[l] = string.Join(G_caracter_separacion[indice_caracter + 1], datos_a_checar_para_editar);
                                        encontro_dato_a_editar = true;
                                        edit_0_o_increm_1_agrega_2_espliteado[k] = "0";
                                        break;
                                    }


                                    else
                                    {
                                        for (int i = 0; i < opciones_dentro_comparacion.Length; i++)
                                        {
                                            string[] info_de_opciones_esp = opciones_dentro_comparacion[i].Split(G_caracter_separacion[2][0]);

                                            if (datos_a_checar_para_editar.Length == 1)
                                            {
                                                //si lo encuentra y tiene el numero 2 lo agrega
                                                if (edit_0_o_increm_1_agrega_2_espliteado[k] == "2")
                                                {
                                                    //datos_a_checar_para_editar = editar_o_incrementar_agrega_informacion(datos_a_checar_para_editar, info_editar_esp[k], edit_0_o_increm_1_agrega_2_espliteado[k], 0, caracter_separacion[indice_caracter]);
                                                    //asi estaba antes if (datos_a_checar_para_editar[0] == info_editar_esp[k])
                                                    if (datos_a_checar_para_editar[0] == info_de_opciones_esp[0])
                                                    {

                                                        edit_0_o_increm_1_agrega_2_espliteado[k] = "0";
                                                        encontro_dato_a_editar = true;
                                                    }
                                                    else
                                                    {

                                                    }

                                                }

                                                else
                                                {
                                                    datos_a_checar_para_editar = editar_o_incrementar_agrega_informacion(datos_a_checar_para_editar, comparacion_con_edicion_esp[k], edit_0_o_increm_1_agrega_2_espliteado[k], 0, G_caracter_separacion[indice_caracter]);
                                                    info_extraida[l] = string.Join(G_caracter_separacion[indice_caracter + 1], datos_a_checar_para_editar);
                                                    edit_0_o_increm_1_agrega_2_espliteado[k] = "0";
                                                    encontro_dato_a_editar = true;

                                                }


                                            }

                                            else if (datos_a_checar_para_editar[0] == comparacion_con_edicion_esp[k])
                                            {
                                                //si tiene el 2 no hace nada por que ya esta
                                                if (edit_0_o_increm_1_agrega_2_espliteado[k] == "2")
                                                {

                                                }
                                                //si encuentra incrementa
                                                else
                                                {
                                                    datos_a_checar_para_editar = editar_o_incrementar_agrega_informacion(datos_a_checar_para_editar, comparacion_con_edicion_esp[k], edit_0_o_increm_1_agrega_2_espliteado[k], 1);

                                                }
                                                info_extraida[l] = string.Join(G_caracter_separacion[indice_caracter + 1], datos_a_checar_para_editar);
                                                encontro_dato_a_editar = true;
                                                edit_0_o_increm_1_agrega_2_espliteado[k] = "0";
                                                break;
                                            }
                                        }
                                    }
                                }

                            }
                        }

                        res_ext_esp[1] = string.Join(G_caracter_separacion[indice_caracter], info_extraida);
                        //si no encuentra dato_a_editar lo agrega
                        if (!encontro_dato_a_editar)
                        {
                            //si no lo encuentra agrega
                            if (edit_0_o_increm_1_agrega_2_espliteado[k] == "2")
                            {
                                if (comparacion_con_edicion_esp[k] != "" || comparacion_con_edicion_esp.Length > 1)
                                {
                                    res_ext_esp[1] = agregar_nueva_informacion(res_ext_esp[1], comparacion_con_edicion_esp[k], comparacion_con_edicion_esp[k], num_celdas, new string[] { G_caracter_separacion[indice_caracter], G_caracter_separacion[indice_caracter + 1] });
                                }

                            }
                            else
                            {
                                //no se si recuerdo como funciona el comentado pero para efectos practicos  use el segundo por que lo nesesito
                                //res_ext_esp[1] = agregar_nueva_informacion(res_ext_esp[1], comparacion_con_edicion_esp[k], comparacion_con_edicion_esp[k], num_celdas, new string[] { caracter_separacion[indice_caracter], caracter_separacion[indice_caracter + 1] });
                                //lo puse para resolver rapido el problema pero hay que checar
                                if (comparacion_con_edicion_esp[k] != "" || comparacion_con_edicion_esp.Length > 1)
                                {
                                    if (res_ext_esp[1] == "")
                                    {
                                        res_ext_esp[1] = comparacion_con_edicion_esp[k];
                                    }
                                    else
                                    {
                                        res_ext_esp[1] = res_ext_esp[1] + G_caracter_separacion[indice_caracter] + comparacion_con_edicion_esp[k];
                                    }

                                }
                                edit_0_o_increm_1_agrega_2_espliteado[k] = "0";
                            }

                        }


                        texto = editar_incr_string_funcion_recursiva(texto, indices_a_editar_esp[k], res_ext_esp[1], edit_0_o_increm_1_agrega_2_espliteado[k], caracter_separacion_funciones_especificas_obj: G_caracter_separacion_para_funciones_espesificas[0]);
                    }


                }
            }

            return texto;
        }




        // Función para editar o incrementar información en un arreglo de datos
        private string[] editar_o_incrementar_agrega_informacion(string[] datos, string info, string accion, int _0_solo_celda_1_varias_celdas, string caracter_separacion_agregar = "°")
        {
            if (accion == "0") // Si la acción es "0", se edita la información
            {
                datos[_0_solo_celda_1_varias_celdas] = info;
            }
            else if (accion == "1") // Si la acción es "1", se incrementa la información
            {
                datos[_0_solo_celda_1_varias_celdas] = (Convert.ToDouble(datos[_0_solo_celda_1_varias_celdas]) + Convert.ToDouble(info)).ToString();
            }

            else if (accion == "2") // Si la acción es "2", agrega
            {
                datos[_0_solo_celda_1_varias_celdas] = datos[_0_solo_celda_1_varias_celdas] + caracter_separacion_agregar + info;
            }
            else // Si la acción no es "0" ni "1", se lanza una excepción
            {
                throw new Exception("Error en la variable incrementar o editar");
            }
            return datos;
        }

        // Función para agregar nueva información a una cadena existente
        private string agregar_nueva_informacion(string existe_datos, string comparacion, string nueva_informacion, string numero_de_celdas, string[] separator)
        {
            // Si hay comparación y dato a modificar osea mas de 1 celda
            if (Convert.ToInt32(numero_de_celdas) > 1)
            {
                if (string.IsNullOrEmpty(existe_datos))
                {
                    return comparacion + separator[1] + nueva_informacion;
                }
                else
                {
                    return existe_datos + separator[0] + comparacion + separator[1] + nueva_informacion;
                }
            }
            else // Si solo esta la comparacion solo se agrega la comparacion
            {
                if (string.IsNullOrEmpty(existe_datos))
                {
                    return comparacion;
                }
                else
                {
                    return existe_datos + separator[0] + comparacion;
                }
            }
        }


        public string editar_inc_edicion_profunda_multiple_string(string texto, string indices_a_editar, string info_editar, string edit_0_o_increm_1 = null, object caracter_separacion_objeto = null, string caracter_separacion_para_busqueda_multiple_profuda_objeto = null)
        {
            //editar_busqueda_multiple_edicion_profunda_arreglo(texto, "2|1|1~1~2|1|0", "10~10~10","1~1~0");
            
            


            string[] indices_espliteado = indices_a_editar.Split(G_caracter_separacion_para_funciones_espesificas[0][0]);
            string[] info_editar_espliteado = info_editar.Split(G_caracter_separacion_para_funciones_espesificas[0][0]);
            string[] edit_0_o_increm_1_espliteado = edit_0_o_increm_1.Split(G_caracter_separacion_para_funciones_espesificas[0][0]);
            for (int k = 0; k < indices_espliteado.Length; k++)
            {
                texto = editar_incr_string_funcion_recursiva(texto, indices_espliteado[k], info_editar_espliteado[k], edit_0_o_increm_1_espliteado[k], caracter_separacion_funciones_especificas_obj: G_caracter_separacion_para_funciones_espesificas[0]);
            }



            return texto;

        }


        public string editar_inc_edicion_profunda_multiple_AL_FINAL_string(string texto, string indices_a_editar, string info_editar, string edit_0_o_increm_1 = null, object caracter_separacion_objeto = null, string caracter_separacion_para_busqueda_multiple_profuda_objeto = null)
        {
            //editar_busqueda_multiple_edicion_profunda_arreglo(texto, "2|1|1~1~2|1|0", "10~10~10","1~1~0");
            
            


            string[] indices_espliteado = indices_a_editar.Split(G_caracter_separacion_para_funciones_espesificas[0][0]);
            string[] info_editar_espliteado = info_editar.Split(G_caracter_separacion_para_funciones_espesificas[0][0]);
            string[] edit_0_o_increm_1_espliteado = edit_0_o_increm_1.Split(G_caracter_separacion_para_funciones_espesificas[0][0]);
            for (int k = 0; k < indices_espliteado.Length; k++)
            {
                texto = editar_incr_string_funcion_recursiva(texto, indices_espliteado[k], info_editar_espliteado[k], edit_0_o_increm_1_espliteado[k], caracter_separacion_funciones_especificas_obj: G_caracter_separacion_para_funciones_espesificas[0]);
            }



            return texto;

        }

        
        public string recorrer_caracter_separacion(string contenidoFila,  string izquierda_o_derecha = "izquierda")
        {
            if (izquierda_o_derecha== "izquierda")
            {


                // Recorremos el arreglo de caracteres de separación
                for (int i = 0; i < G_caracter_separacion.Length-1; i++)
                {
                    // Reemplazamos los caracteres en contenido_fila
                    contenidoFila = contenidoFila.Replace(
                        G_caracter_separacion[i+1],
                        G_caracter_separacion[i]
                    );
                }
            }
            else
            {
                for (int i = G_caracter_separacion.Length - 1; i > 0 ; i--)
                {
                    // Reemplazamos los caracteres en contenido_fila
                    contenidoFila = contenidoFila.Replace(
                        G_caracter_separacion[i - 1],
                        G_caracter_separacion[i]
                    );
                }
            }
            // Devolvemos el contenido procesado
            return contenidoFila;
        }


        public string[] extraer_separado_carpetas_nombreArchivo_extencion_de_una_direccion(string direccion_archivo)
        {
            string[] arreglo_retornar = new string[3];


            string[] direccion_esp = direccion_archivo.Split('\\');
            string[] nom_ext_esp = direccion_esp[direccion_esp.Length - 1].Split('.');
            if (nom_ext_esp.Length > 1)
            {
                string carpetas = joineada_paraesida_SIN_NULOS_y_quitador_de_extremos_del_string(direccion_archivo, '\\', 1);
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



    }
}