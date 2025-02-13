using CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CLASE_QU1R30N_2.sin_internet.sin_formularios;

using System.Diagnostics.Contracts;
using System.Windows.Forms;
using System.Drawing;

namespace CLASE_QU1R30N_2.conexion.herramientas_internet
{
    internal class conmutador
    {

        operaciones_arreglos op_arr = new operaciones_arreglos();
        operaciones_textos op_tex = new operaciones_textos();

        //Tex_base bas = new Tex_base();

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_transferencia_entre_archivos = var_fun_GG.GG_caracter_para_transferencia_entre_archivos;

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        principal enlace_principal = new principal();

        public void conmutar_datos(string parametro)
        {
            // Dividir el parámetro de entrada en partes utilizando un carácter delimitador
            string[] res_espliteada = parametro.Split(G_caracter_para_transferencia_entre_archivos[1][0]);

            // Procesar la información específica eliminando espacios
            string info_a_procesar = res_espliteada[1].Replace(" ", "");

            // Dividir la información en líneas usando un delimitador para saltos de línea
            





            // Enlazar y procesar la información utilizando el método `enlasador`
            //ESTE ES LA PRINCIPAL FUNCION DONDE TU PROGRAMARAS
            string res = enlace_principal.enlasador(info_a_procesar);





            // Extraer el contacto del parámetro dividido
            string contacto = res_espliteada[3];

            // Procesar el texto eliminando separadores específicos
            string[] temp1 = info_a_procesar.Split(G_caracter_separacion_funciones_espesificas[1][0]);
            string[] proceso = temp1[0].Split(G_caracter_separacion_funciones_espesificas[0][0]);

            // Crear la información a enviar combinando múltiples datos y delimitadores
            string info_a_enviar = proceso[1] + G_caracter_para_transferencia_entre_archivos[1] +
                                   res + G_caracter_para_transferencia_entre_archivos[1] + 
                                   contacto;

            
            
            // Crear una instancia de la clase `conexiones` para manejar las conexiones
            conexiones con = new conexiones();
            // Enviar los datos procesados mediante el método `datos_a_enviar`
            con.datos_a_enviar(res_espliteada[1], info_a_enviar, res_espliteada[0]);
        }


        //procesos---------------------------------------------------------------------------------------------

        public void punt_venta(string id_prog_a_enviar, string proceso, string folio_o_palbra_clave_a_del_que_lo_recibira, string info_a_procesar, string contacto = "")
        {
            info_a_procesar = info_a_procesar.Replace(" ", "");
            string[] lineas_del_mensaje = info_a_procesar.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            conexiones con = new conexiones();

            string res = enlace_principal.enlasador(info_a_procesar);
            string info_a_enviar = res + G_caracter_para_transferencia_entre_archivos[1] + contacto;
            con.datos_a_enviar(folio_o_palbra_clave_a_del_que_lo_recibira, info_a_enviar, id_prog_a_enviar);


            /*
            switch (proceso)
            {
                case "VENTA":

                    string res = enlace_principal.enlasador(info_a_procesar);
                    con.datos_a_enviar(folio_o_palbra_clave_a_del_que_lo_recibira, res + G_caracter_para_transferencia_entre_archivos[1] + contacto, id_prog_a_enviar);
                    break;

                case "COMICION_UNIFICADA_VENTA":

                    string res_COMICION_VENTA = enlace_principal.enlasador(info_a_procesar);
                    con.datos_a_enviar(folio_o_palbra_clave_a_del_que_lo_recibira, res_COMICION_VENTA + G_caracter_para_transferencia_entre_archivos[1] + contacto, id_prog_a_enviar);
                    break;



                default:
                    break;
            }
            */
        }


        public void producto(string id_prog_a_enviar, string proceso, string folio_o_palbra_clave_a_del_que_lo_recibira, string info_a_procesar)
        {
            info_a_procesar = info_a_procesar.Replace(" ", "");
            string[] lineas_del_mensaje = info_a_procesar.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            conexiones con = new conexiones();
            switch (proceso)
            {
                case "EXTRAER_INVENTARIO":
                    string inventario = enlace_principal.enlasador("MODELO_PRODUCTOS_E_INVENTARIO~EXTRAER_INVENTARIO_STRING§");
                    con.datos_a_enviar(folio_o_palbra_clave_a_del_que_lo_recibira, inventario, id_prog_a_enviar);
                    break;

                case "PREDICCION_COMPRA":
                    string PREDICCION = enlace_principal.enlasador("MODELO_ANALISIS_DATOS~PREDICCION_NECESIDADES_COMPRA§");
                    con.datos_a_enviar(folio_o_palbra_clave_a_del_que_lo_recibira, PREDICCION, id_prog_a_enviar);
                    break;




                default:
                    break;
            }
        }

        public void compras(string id_prog_a_enviar, string proceso, string folio_o_palbra_clave_a_del_que_lo_recibira, string info_a_procesar, string contacto)
        {
            info_a_procesar = info_a_procesar.Replace(" ", "");
            string[] lineas_del_mensaje = info_a_procesar.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            conexiones con = new conexiones();

            string res = enlace_principal.enlasador(info_a_procesar);
            string info_a_enviar = res + G_caracter_para_transferencia_entre_archivos[1] + contacto;
            con.datos_a_enviar(folio_o_palbra_clave_a_del_que_lo_recibira, info_a_enviar, id_prog_a_enviar);


            /*
            if (proceso=="COMPRA")
            {
                string res = enlace_principal.enlasador(info_a_procesar);
                con.datos_a_enviar(folio_o_palbra_clave_a_del_que_lo_recibira, res + G_caracter_para_transferencia_entre_archivos[1] + contacto, id_prog_a_enviar);
            }
            else if (proceso == "PREDICCION_COMPRA")
            {
                string res = enlace_principal.enlasador(info_a_procesar);
                con.datos_a_enviar(folio_o_palbra_clave_a_del_que_lo_recibira, res + G_caracter_para_transferencia_entre_archivos[1] + contacto, id_prog_a_enviar);

            }
            */
        }

        public void administracion(string id_prog_a_enviar, string proceso, string folio_o_palbra_clave_a_del_que_lo_recibira, string info_a_procesar, string contacto = "")
        {
            info_a_procesar = info_a_procesar.Replace(" ", "");
            string[] lineas_del_mensaje = info_a_procesar.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            conexiones con = new conexiones();

            string res = enlace_principal.enlasador(info_a_procesar);
            string info_a_enviar = res + G_caracter_para_transferencia_entre_archivos[1] + contacto;
            con.datos_a_enviar(folio_o_palbra_clave_a_del_que_lo_recibira, info_a_enviar, id_prog_a_enviar);

            /*
            if (proceso == "VENTAS_DEL_DIA")
            {
                
                

            }
            else if (proceso == "VENTAS_DEL_MES")
            {
                
                con.datos_a_enviar(folio_o_palbra_clave_a_del_que_lo_recibira, info_a_enviar, id_prog_a_enviar);

            }
            else if (proceso == "VENTAS_DEL_AÑO")
            {
                
                con.datos_a_enviar(folio_o_palbra_clave_a_del_que_lo_recibira, info_a_enviar, id_prog_a_enviar);

            }
            else if (proceso == "VENTAS_DEL_DIA")
            {
                
                con.datos_a_enviar(folio_o_palbra_clave_a_del_que_lo_recibira, info_a_enviar, id_prog_a_enviar);

            }
            else if (proceso == "PREDICCION_COMPRA")
            {
                
                
                con.datos_a_enviar(folio_o_palbra_clave_a_del_que_lo_recibira, info_a_enviar, id_prog_a_enviar);

            }
            */

        }

        public void repetidor(string id_prog_a_enviar, string proceso, string folio_o_palbra_clave_a_del_que_lo_recibira, string info_a_procesar, string contacto = "")
        {
            info_a_procesar = info_a_procesar.Replace(" ", "");
            string[] lineas_del_mensaje = info_a_procesar.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            conexiones con = new conexiones();

            string res = enlace_principal.enlasador(info_a_procesar);
            string info_a_enviar = res + G_caracter_para_transferencia_entre_archivos[1] + contacto;
            con.datos_a_enviar(folio_o_palbra_clave_a_del_que_lo_recibira, info_a_enviar, id_prog_a_enviar);

            /*
            switch (proceso)
            {
                case "PETICIONES":
                    break;




                default:
                    break;
            }
            */
        }

        public void inteligencia_artificial(string id_prog_a_enviar, string proceso, string folio_o_palbra_clave_a_del_que_lo_recibira, string info_a_procesar, string contacto = "")
        {
            info_a_procesar = info_a_procesar.Replace(" ", "");
            string[] lineas_del_mensaje = info_a_procesar.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            conexiones con = new conexiones();
            string res = enlace_principal.enlasador(info_a_procesar);
            string info_a_enviar = res + G_caracter_para_transferencia_entre_archivos[1] + contacto;
            con.datos_a_enviar(folio_o_palbra_clave_a_del_que_lo_recibira, info_a_enviar, id_prog_a_enviar);

            /*
            switch (proceso)
            {
                case "PETICIONES":
                    break;




                default:
                    break;
            }
            */
        }

        //fin procesos-------------------------------------------------------------------------------------------
    }
}
