using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clase_qu1r30n_2._0.sin_internet.sin_formularios;
using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;

namespace clase_qu1r30n_2._0
{

    internal class iniciar_archivos
    {

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;




        Tex_base bas = new Tex_base();
        public void iniciar()
        {
            bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(
                var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[0, 0],
                var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[0, 1],
                var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[0, 2].Split(G_caracter_separacion_funciones_espesificas[1][0]));



            // Crear archivos del programa
            for (int i = G_donde_inicia_la_tabla; i < var_fun_GG_dir_arch_crear.GG_dir_nom_archivos.GetLength(0); i++)
            {

                bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(
                    var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[i, 0],
                    var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[i, 1],
                    var_fun_GG_dir_arch_crear.GG_dir_nom_archivos[i, 2].Split(G_caracter_separacion_funciones_espesificas[1][0]));
            }



            bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[0, 0], var_fun_GG.GG_id_programa, new string[] { var_fun_GG.GG_id_programa }, leer_y_agrega_al_arreglo: false);
            // Crear archivos del programa SIN ARREGLO GG
            for (int i = G_donde_inicia_la_tabla; i < var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG.GetLength(0); i++)
            {
                bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(
                    var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[i, 0],
                    var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[i, 1],
                    var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[i, 2].Split(G_caracter_separacion_funciones_espesificas[1][0]), leer_y_agrega_al_arreglo: false);
            }

            string[] inf_arc = bas.leer(var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[0, 0]);

            if (inf_arc == null)
            {
                bas.Agregar_sino_existe(var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[0, 0], 0, var_fun_GG.GG_id_programa, var_fun_GG.GG_id_programa + "\n" + var_fun_GG.GG_id_programa);
            }
            else if (inf_arc.Length == 1 && inf_arc[0] == "")
            {
                bas.Agregar_sino_existe(var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[0, 0], 0, var_fun_GG.GG_id_programa, var_fun_GG.GG_id_programa + "\n" + var_fun_GG.GG_id_programa);
            }
            else
            {
                bas.Agregar_sino_existe(var_fun_GG_dir_arch_crear.GG_dir_nom_archivos_SIN_ARREGLOS_GG[0, 0], 0, var_fun_GG.GG_id_programa, var_fun_GG.GG_id_programa);
            }




            string[] res_indice = bas.sacar_indice_del_arreglo_de_direccion(Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[1, 0]).Split(G_caracter_para_confirmacion_o_error[0][0]);
            int indice = Convert.ToInt32(res_indice[1]);


            for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[indice].Length; i++)
            {
                string[] info_esp = Tex_base.GG_base_arreglo_de_arreglos[indice][i].Split(G_caracter_separacion[0][0]);
                var_fun_GG.GG_autoCompleteCollection_codbar_venta.Add(info_esp[5] + G_caracter_separacion[0] + info_esp[1] + " " + info_esp[2] + info_esp[3] + G_caracter_separacion[0] + i);
                var_fun_GG.GG_autoCompleteCollection_nom_produc_venta.Add(info_esp[1] + " " + info_esp[2] + info_esp[3] + G_caracter_separacion[0] + info_esp[5] + G_caracter_separacion[0] + i);
            }
            var_fun_GG.GG_inv_solo_lect = Array.AsReadOnly(Tex_base.GG_base_arreglo_de_arreglos[indice]);





        }






        //fin clase-----------------------------------------------------------------------------
    }
}