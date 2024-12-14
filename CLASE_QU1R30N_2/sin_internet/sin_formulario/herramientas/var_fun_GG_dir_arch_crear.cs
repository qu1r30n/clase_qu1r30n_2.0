using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas
{
    internal class var_fun_GG_dir_arch_crear
    {


        
        //funciones y restricciones txt y cmb ventana_emergente cod:poison
        ////////////////////////////////////////////////////////////////////////
        //                                SI EDITAS                           //
        //                      [,] GG_ventana_emergente_                     //
        //                             TIENES QUE EDITAR                      //
        //                      RecargarVentanaEmergente                      //
        //                          ES EL DE ABAJITO A ESTE                   //
        //           TIENE QUE SER EL MISMO ARREGLO UNO QUE EL OTRO           //
        ////////////////////////////////////////////////////////////////////////

        //datos configuracio

        static public string[,] GG_ventana_datos_conf = new string[,]
        {
                /*0*/ { "2", "dato_de_configuracion", "" , "TEXTO" },
                /*1*/ { "2", "descripcion_de_configuracion", "" , "TEXTO" },
        };
        
        

        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        public static string columnas_concatenadas(string[,] arreglo_bidimencional, int id_columna, string caracter_separacion = null)
        {
            if (caracter_separacion == null)
            {
                caracter_separacion = var_fun_GG.GG_caracter_separacion[0];
            }
            string nombresConcatenados = "";

            for (int i = 0; i < arreglo_bidimencional.GetLength(0); i++)
            {
                string nombre = arreglo_bidimencional[i, id_columna];
                nombresConcatenados += nombre + Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]);
            }

            if (!string.IsNullOrEmpty(nombresConcatenados))
            {
                nombresConcatenados = nombresConcatenados.TrimEnd(Convert.ToChar(var_fun_GG.GG_caracter_separacion[0]));
            }

            return nombresConcatenados;
        }


        static public string[] GG_direccion_carpetas_base = { "" };



        static public string[,] GG_dir_nom_archivos =
        {
            /*0*/{ GG_direccion_carpetas_base[0] + "ARCHIVOS_INICIALES\\INICIO.TXT",columnas_concatenadas(GG_ventana_datos_conf,1,var_fun_GG.GG_caracter_separacion[0]),"|DIA_SE_ABRIO§1|ULTIMO_ID_VEND"},
            

    };

        static public string[,] GG_dir_nom_archivos_SIN_ARREGLOS_GG =
        {
            //archivos transferencia informacion
            /*0*/{ "C:\\XEROX\\CONFIG\\INF\\BKLKFJC\\BANDERAS.TXT", var_fun_GG.GG_id_programa, var_fun_GG.GG_id_programa},//no_hacer_caso
            /*1*/{ "C:\\XEROX\\CONFIG\\INF\\BKLKFJC\\1.TXT", "SIN_INFO", ""},//preguntas
            /*2*/{"C:\\XEROX\\CONFIG\\INF\\BKLKFJC\\2.TXT", "SIN_INFO", ""},//respuestas

        };

        
    }
}