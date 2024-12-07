using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CLASE_QU1R30N_2.sin_internet.sin_formularios;
using CLASE_QU1R30N_2.sin_internet.sin_formularios.herramientas;


namespace CLASE_QU1R30N_2.sin_internet.sin_formularios
{
    internal class principal
    {
        

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;

        var_fun_GG vf_GG = new var_fun_GG();

        // Función para manejar compras
        public string enlasador(string INFO_ENTRADA)
        {
            //ejemplo dato entrada: "analisis_datos~existe_producto§codigo"
            INFO_ENTRADA = INFO_ENTRADA.ToUpper();

            string info_a_retornar = null;

            string[] a_donde_enviara_la_informacion = INFO_ENTRADA.Split(G_caracter_separacion_funciones_espesificas[0][0]);
            string[] datos_spliteados = a_donde_enviara_la_informacion[1].Split(G_caracter_separacion_funciones_espesificas[1][0]);

            string modelo = a_donde_enviara_la_informacion[0];
            string proceso = datos_spliteados[0];
            string datos = datos_spliteados[1];
            string yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");



            switch (modelo)
            {
                case "MODELO_ANALISIS_DATOS":
                    //"existe_producto§codigo"
                    //info_a_retornar = mod_an_dat.operacion_a_hacer(proceso, datos, yyyyMMddHHmmss);
                    break;
                
            }


            

            return info_a_retornar;

        }


    }
}
