using CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas;
using CLASE_QU1R30N_2.sin_internet.sin_formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CLASE_QU1R30N_2.sin_internet.sin_formulario.procesos
{
    internal class _05_proc_aprobaciones_de_proceso
    {

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;
        
        string[,] G_dir_de_archivos_tipo_1_solo_archivo = var_fun_GG_dir_arch_crear.GG_dir_de_archivos_tipo_1_solo_archivo;

        operaciones_textos op_tex = new operaciones_textos();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        string[] G_solo_para_consultas_relacionadas_encontrar_el_id;

        principal enl_princ = new principal();

        var_fun_GG vf_GG = new var_fun_GG();

        operaciones_arreglos op_arr = new operaciones_arreglos();



        public string GuardarPedidoAConfirmar(string datos)
        {
            string info_a_retornar = null;


            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS ---------------------------------------------------------------------------
            string prosesos_a_guardar = datos_epliteados[0];


            string nivel_de_aprobacion_0_es_el_maximo = "";
            if (datos_epliteados.Length >= 2)
            {
                if (datos_epliteados[1] != "")
                {
                    nivel_de_aprobacion_0_es_el_maximo = datos_epliteados[1];
                }
            }

            string aprobadores_espesificos_que_lo_aprobaran = "0";

            if (datos_epliteados.Length >= 3)
            {
                if (datos_epliteados[2] != "")
                {
                    aprobadores_espesificos_que_lo_aprobaran = datos_epliteados[2];
                }
            }

            string folio = op_tex.generar_folio();
            if (datos_epliteados.Length >= 4)
            {
                if (datos_epliteados[3] != "")
                {
                    folio = datos_epliteados[3];
                }
            }
            //-----------------------------------------------------------------------------------------
            info_a_retornar = folio + G_caracter_separacion_funciones_espesificas[4]+ prosesos_a_guardar + G_caracter_separacion_funciones_espesificas[4] + DateTime.Now.ToString("yyMMddHHmmss") + G_caracter_separacion_funciones_espesificas[4] + nivel_de_aprobacion_0_es_el_maximo + G_caracter_separacion_funciones_espesificas[4] + aprobadores_espesificos_que_lo_aprobaran;
            string resp_del_agregue = enl_princ.enlasador("TEX_BASE" + G_caracter_separacion_funciones_espesificas[0] + "AGREGAR_USO_SOLO_PROG" + G_caracter_separacion_funciones_espesificas[1] + G_dir_de_archivos_tipo_1_solo_archivo[0,0] + G_caracter_separacion_funciones_espesificas[3] + info_a_retornar);


            return info_a_retornar;
        }

        public string Confirmar(string datos)
        {
            string info_a_retornar = null;


            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS ---------------------------------------------------------------------------
            string folio = datos_epliteados[0];


            string nivel_del_aprobador = "";
            if (datos_epliteados.Length >= 2)
            {
                if (datos_epliteados[1] != "")
                {
                    nivel_del_aprobador = datos_epliteados[1];
                }
            }

            string aprobador = "";

            if (datos_epliteados.Length >= 3)
            {
                if (datos_epliteados[2] != "")
                {
                    aprobador = datos_epliteados[2];
                }
            }

            //-----------------------------------------------------------------------------------------
            
            // Crear el StreamReader manualmente
            FileStream fs = null;
            StreamReader sr = null;
            StreamWriter sw = null;
            string direccion_archivos = G_dir_de_archivos_tipo_1_solo_archivo[0, 0];
            while (fs == null)
            {
                try
                {
                    fs = new FileStream(direccion_archivos, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                }
                catch
                {
                    // Esperar o loguear si el archivo está en uso
                }
            }

            // Leer todo con StreamReader
            sr = new StreamReader(fs);
            List<string> lista_datos = new List<string>();
            string linea;
            int contador = 0;

            while ((linea = sr.ReadLine()) != null)
            {
                bool lo_encontro = false;
                if (contador > 0)
                {
                    string[] info_a_aprobar = linea.Split(G_caracter_separacion_funciones_espesificas[4][0]);
                    string[] procesos_a_hacer = info_a_aprobar[1].Split(G_caracter_separacion_funciones_espesificas[5][0]);
                    if (folio == info_a_aprobar[0])
                    {
                        if (Convert.ToInt32(info_a_aprobar[3]) >= Convert.ToInt32(nivel_del_aprobador))
                        {
                            for (int j = 0; j < procesos_a_hacer.Length; j++)
                            {
                                string proc = op_tex.recorrer_caracter_separacion_funciones_espesificas(procesos_a_hacer[j], "izquierda", 7);
                                enl_princ.enlasador(proc);

                            }
                            lo_encontro = true;
                        }
                        else
                        {
                            string[] aprobadores = info_a_aprobar[4].Split(G_caracter_separacion_funciones_espesificas[5][0]);
                            for (int i = 0; i < aprobadores.Length; i++)
                            {
                                if (aprobadores[i] == aprobador)
                                {
                                    info_a_aprobar[2] = "PROCESADO"; // Modificación
                                    linea = string.Join(G_caracter_separacion_funciones_espesificas[4][0].ToString(), info_a_aprobar);
                                    for (int j = 0; j < procesos_a_hacer.Length; j++)
                                    {
                                        string proc = op_tex.recorrer_caracter_separacion_funciones_espesificas(procesos_a_hacer[j], "izquierda", 7);
                                        enl_princ.enlasador(proc);
                                    }
                                    break;
                                }

                            }
                            lo_encontro = true;
                        }
                    }
                }

                if (lo_encontro == false) 
                {
                    lista_datos.Add(linea);
                }
                contador++;
            }

            

            // Reposicionar el FileStream al inicio y truncar el archivo
            fs.Seek(0, SeekOrigin.Begin);
            fs.SetLength(0);

            // Escribir con StreamWriter reutilizando el mismo FileStream
            sw = new StreamWriter(fs);
            for (int i = 0; i < lista_datos.Count; i++)
            {
                sw.WriteLine(lista_datos[i]);
            }
            sw.Flush();
            sw.Close();
            sr.Close(); // Cierra para reposicionar el stream
            fs.Close();


            return info_a_retornar;
        }

        public string Eliminar(string datos)
        {
            string info_a_retornar = null;


            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS ---------------------------------------------------------------------------
            string folio = datos_epliteados[0];


            string nivel_del_aprobador = "";
            if (datos_epliteados.Length >= 2)
            {
                if (datos_epliteados[1] != "")
                {
                    nivel_del_aprobador = datos_epliteados[1];
                }
            }

            string aprobador = "";

            if (datos_epliteados.Length >= 3)
            {
                if (datos_epliteados[2] != "")
                {
                    aprobador = datos_epliteados[2];
                }
            }

            //-----------------------------------------------------------------------------------------

            // Crear el StreamReader manualmente
            FileStream fs = null;
            StreamReader sr = null;
            StreamWriter sw = null;
            string direccion_archivos = G_dir_de_archivos_tipo_1_solo_archivo[0, 0];
            while (fs == null)
            {
                try
                {
                    fs = new FileStream(direccion_archivos, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                }
                catch
                {
                    // Esperar o loguear si el archivo está en uso
                }
            }

            // Leer todo con StreamReader
            sr = new StreamReader(fs);
            List<string> lista_datos = new List<string>();
            string linea;
            int contador = 0;

            while ((linea = sr.ReadLine()) != null)
            {
                bool lo_encontro = false;
                if (contador > 0)
                {
                    string[] info_a_aprobar = linea.Split(G_caracter_separacion_funciones_espesificas[4][0]);
                    string[] procesos_a_hacer = info_a_aprobar[1].Split(G_caracter_separacion_funciones_espesificas[5][0]);
                    if (folio == info_a_aprobar[0])
                    {
                        if (Convert.ToInt32(info_a_aprobar[3]) >= Convert.ToInt32(nivel_del_aprobador))
                        {
                            lo_encontro = true;
                        }
                        else
                        {
                            string[] aprobadores = info_a_aprobar[4].Split(G_caracter_separacion_funciones_espesificas[5][0]);
                            for (int i = 0; i < aprobadores.Length; i++)
                            {
                                if (aprobadores[i] == aprobador)
                                {
                                    lo_encontro = true;
                                    break;
                                }

                            }
                            
                        }
                    }
                }

                if (lo_encontro == false)
                {
                    lista_datos.Add(linea);
                }
                contador++;
            }



            // Reposicionar el FileStream al inicio y truncar el archivo
            fs.Seek(0, SeekOrigin.Begin);
            fs.SetLength(0);

            // Escribir con StreamWriter reutilizando el mismo FileStream
            sw = new StreamWriter(fs);
            for (int i = 0; i < lista_datos.Count; i++)
            {
                sw.WriteLine(lista_datos[i]);
            }
            sw.Flush();
            sw.Close();
            sr.Close(); // Cierra para reposicionar el stream
            fs.Close();


            return info_a_retornar;
        }

        public string Editar(string datos)
        {
            string info_a_retornar = null;


            string[] datos_epliteados = datos.Split(G_caracter_separacion_funciones_espesificas[3][0]);

            // PARAMETROS ---------------------------------------------------------------------------
            string folio = datos_epliteados[0];


            string nivel_del_aprobador = "";
            if (datos_epliteados.Length >= 2)
            {
                if (datos_epliteados[1] != "")
                {
                    nivel_del_aprobador = datos_epliteados[1];
                }
            }

            string aprobador = "";

            if (datos_epliteados.Length >= 3)
            {
                if (datos_epliteados[2] != "")
                {
                    aprobador = datos_epliteados[2];
                }
            }
            string[] num_fila_editar = { "" };

            if (datos_epliteados.Length >= 4)
            {
                if (datos_epliteados[3] != "")
                {
                    num_fila_editar = datos_epliteados[3].Split(G_caracter_separacion_funciones_espesificas[4][0]);
                }
            }

            string[] info_edicion = { "" };

            if (datos_epliteados.Length >= 5)
            {
                if (datos_epliteados[4] != "")
                {
                    info_edicion = datos_epliteados[4].Split(G_caracter_separacion_funciones_espesificas[4][0]);
                }
            }

            //-----------------------------------------------------------------------------------------

            // Crear el StreamReader manualmente
            FileStream fs = null;
            StreamReader sr = null;
            StreamWriter sw = null;
            string direccion_archivos = G_dir_de_archivos_tipo_1_solo_archivo[0, 0];
            while (fs == null)
            {
                try
                {
                    fs = new FileStream(direccion_archivos, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                }
                catch
                {
                    // Esperar o loguear si el archivo está en uso
                }
            }

            // Leer todo con StreamReader
            sr = new StreamReader(fs);
            List<string> lista_datos = new List<string>();
            string linea;
            int contador = 0;

            while ((linea = sr.ReadLine()) != null)
            {
                bool lo_encontro = false;
                if (contador > 0)
                {
                    string[] info_a_aprobar = linea.Split(G_caracter_separacion_funciones_espesificas[4][0]);
                    string[] procesos_a_hacer = info_a_aprobar[1].Split(G_caracter_separacion_funciones_espesificas[5][0]);
                    if (folio == info_a_aprobar[0])
                    {
                        if (Convert.ToInt32(info_a_aprobar[3]) >= Convert.ToInt32(nivel_del_aprobador))
                        {
                            for (int j = 0; j < num_fila_editar.Length; j++)
                            {

                                if (info_edicion[j] != "")
                                {
                                    procesos_a_hacer[Convert.ToInt32(num_fila_editar[j])] = info_edicion[j];

                                    info_a_aprobar[1] = string.Join(G_caracter_separacion_funciones_espesificas[5][0].ToString(), procesos_a_hacer);
                                    linea = string.Join(G_caracter_separacion_funciones_espesificas[4][0].ToString(), info_a_aprobar);
                                }
                            }

                            
                        }
                        else
                        {
                            string[] aprobadores = info_a_aprobar[4].Split(G_caracter_separacion_funciones_espesificas[5][0]);
                            for (int i = 0; i < aprobadores.Length; i++)
                            {
                                if (aprobadores[i] == aprobador)
                                {
                                    info_a_aprobar[2] = "PROCESADO"; // Modificación
                                    linea = string.Join(G_caracter_separacion_funciones_espesificas[4][0].ToString(), info_a_aprobar);
                                    for (int j = 0; j < num_fila_editar.Length; j++)
                                    {
                                        if (info_edicion[j] != "")
                                        {
                                            procesos_a_hacer[Convert.ToInt32(num_fila_editar[j])] = info_edicion[j];

                                            info_a_aprobar[1] = string.Join(G_caracter_separacion_funciones_espesificas[5][0].ToString(), procesos_a_hacer);
                                            linea = string.Join(G_caracter_separacion_funciones_espesificas[4][0].ToString(), info_a_aprobar);
                                        }
                                    }
                                    break;
                                }
                                
                            }

                        }
                    }
                }

                lista_datos.Add(linea);

                contador++;
            }



            // Reposicionar el FileStream al inicio y truncar el archivo
            fs.Seek(0, SeekOrigin.Begin);
            fs.SetLength(0);

            // Escribir con StreamWriter reutilizando el mismo FileStream
            sw = new StreamWriter(fs);
            for (int i = 0; i < lista_datos.Count; i++)
            {
                sw.WriteLine(lista_datos[i]);
            }
            sw.Flush();
            sw.Close();
            sr.Close(); // Cierra para reposicionar el stream
            fs.Close();


            return info_a_retornar;
        }

        //fin clase---------------------------------------------------------------------------------------------

    }
}
