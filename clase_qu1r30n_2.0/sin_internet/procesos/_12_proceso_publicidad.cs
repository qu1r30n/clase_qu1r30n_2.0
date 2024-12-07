using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;

namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.procesos
{
    internal class _12_proceso_publicidad
    {


        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;

        var_fun_GG vf_GG = new var_fun_GG();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        Tex_base bas = new Tex_base();

        operaciones_textos op_tex = new operaciones_textos();
        operaciones_arreglos op_arr = new operaciones_arreglos();


        string[] G_direcciones =
        {

        };


        public string publicar_face(string tipo, string url_sino_es_mensage, string mensage, string pageId, string accessToken)
        {
            string info_publicacion_retornar = null;
            bool published = true; // Indicador de publicación

            using (var httpClient = new HttpClient())
            {
                string requestUri;
                StringContent content;
                try
                {
                    string mensage_publish = null;
                    switch (tipo)
                    {
                        case "PUBLICAR_TEXTO_FACEBOOK":
                            requestUri = $"https://graph.facebook.com/{pageId}/feed";
                            mensage_publish = $"message={mensage}&published={published}";
                            content = new StringContent(mensage_publish, System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");
                            break;
                        case "PUBLICAR_IMAGEN_FACEBOOK":
                            requestUri = $"https://graph.facebook.com/{pageId}/photos";
                            mensage_publish = $"url={url_sino_es_mensage}&message={mensage}&published={published}";
                            content = new StringContent(mensage_publish, System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");
                            break;
                        case "PUBLICAR_VIDEO_FACEBOOK":
                            requestUri = $"https://graph.facebook.com/{pageId}/videos";
                            mensage_publish = $"file_url={url_sino_es_mensage}&message={mensage}&published={published}";
                            content = new StringContent(mensage_publish, System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");
                            break;
                        default:
                            requestUri = $"https://graph.facebook.com/{pageId}/feed";
                            mensage_publish = $"message={mensage}&published={published}";
                            content = new StringContent(mensage_publish, System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");
                            break;
                    }

                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                    // Llamada síncrona
                    var response = httpClient.PostAsync(requestUri, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Publicación exitosa en el muro de Facebook.");
                        info_publicacion_retornar = "1" + G_caracter_para_confirmacion_o_error[1] + "Publicación exitosa en el muro de Facebook.";
                    }
                    else
                    {
                        Console.WriteLine("Error al publicar en el muro de Facebook.");
                        info_publicacion_retornar = "-1" + G_caracter_para_confirmacion_o_error[1] + "Error al publicar en el muro de Facebook.";
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                    info_publicacion_retornar = "-1" + G_caracter_para_confirmacion_o_error[1] + "Error al publicar en el muro de Facebook.";
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    info_publicacion_retornar = "-1" + G_caracter_para_confirmacion_o_error[1] + "Error al publicar en el muro de Facebook.";
                }
            }
            return info_publicacion_retornar;
        }





        //fin clase---------------------------------------------------------------
    }
}
