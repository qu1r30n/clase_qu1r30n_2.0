using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clase_qu1r30n_2._0.con_internet.herramientas_internet;
using clase_qu1r30n_2._0.sin_internet.sin_formularios.herramientas;

namespace clase_qu1r30n_2._0.sin_internet.sin_formularios.procesos
{

    internal class _04_proceso_aprendices_E
    {
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;
        string[] G_caracter_para_transferencia_entre_archivos = var_fun_GG.GG_caracter_para_transferencia_entre_archivos;

        var_fun_GG vf_GG = new var_fun_GG();

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        Tex_base bas = new Tex_base();
        operaciones_textos op_tex = new operaciones_textos();
        operaciones_arreglos op_arr = new operaciones_arreglos();

        public string registro_aprendices_E_cod3_r_(string direccion_archivo, string datos, object caracter_separacion_obj = null)
        {

            string[] caracter_separacion_string = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string info_a_retornar = "";


            string direccion_archivo_aprendices_E = direccion_archivo;
            string resultado_archivo_aprendices_E = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo_aprendices_E);
            string[] res_esp_archivo_E = resultado_archivo_aprendices_E.Split(G_caracter_para_confirmacion_o_error[0][0]);
            if (Convert.ToInt32(res_esp_archivo_E[0]) > 0)//si res es mayor a 0 la operacioon fue exitosa si no hubo un error
            {

                string[] datos_espliteado = datos.Split(caracter_separacion_string[2][0]);


                string ID = "";
                string resul_agregue = "";
                bool esta_arreglo = false;
                if (res_esp_archivo_E[0] == "1")
                {
                    int indic_aprendiz_E = Convert.ToInt32(res_esp_archivo_E[1]);
                    ID = "" + Tex_base.GG_base_arreglo_de_arreglos[indic_aprendiz_E].Length;
                    resul_agregue = "1";
                    esta_arreglo = true;

                }
                else if (res_esp_archivo_E[0] == "-1")
                {
                    ID = "" + bas.leer(direccion_archivo_aprendices_E).Length;
                    resul_agregue = "2";
                    esta_arreglo = false;
                }



                string Nombre = datos_espliteado[0];
                string Apellido_paterno = datos_espliteado[1];
                string Apellido_materno = datos_espliteado[2];
                string Fecha_de_nacimiento = datos_espliteado[3];
                string Género = datos_espliteado[4];
                string Dirección = datos_espliteado[5];
                string Ciudad = datos_espliteado[6];
                string Estado_Provincia = datos_espliteado[7];
                string Código_postal = datos_espliteado[8];
                string País = datos_espliteado[9];
                string Correo_electrónico = datos_espliteado[10];
                string Teléfono = datos_espliteado[11];

                string Fecha_de_ingreso = "TODAVIA_NO_A_SIDO_ACEPTADO";
                string Sueldo = "NO_DEFINIDO";
                string Cargo = "NO_DEFINIDO";
                string Estado_de_aprendis_E = "NO_DEFINIDO";
                string Supervisor = "NO_DEFINIDO";
                string Notas = "";
                string Afiliado = "";
                string Fecha_de_terminación = "NO_DEFINIDO";
                string Motivo_de_terminación = "";
                string Horas_trabajadas = "NO_DEFINIDO";
                string Evaluaciones_de_desempeño = "NO_DEFINIDO";

                string Habilidades_y_certificaciones = datos_espliteado[12];
                string Idiomas = datos_espliteado[13];

                string Fecha_de_última_promoción = "NO_DEFINIDO";
                string ID_del_departamento_de_supervisión = "NO_DEFINIDO";
                string Historial_de_capacitación = "NO_DEFINIDO";
                string Último_aumento_de_salario = "NO_DEFINIDO";
                string tipo_de_aprendis_E = "NO_DEFINIDO";


                string datos_a_agregar = ID + caracter_separacion_string[0] + Nombre + caracter_separacion_string[0] + Apellido_paterno + caracter_separacion_string[0] + Apellido_materno + caracter_separacion_string[0] + Fecha_de_nacimiento + caracter_separacion_string[0] + Género + caracter_separacion_string[0] + Dirección + caracter_separacion_string[0] + Ciudad + caracter_separacion_string[0] + Estado_Provincia + caracter_separacion_string[0] + Código_postal + caracter_separacion_string[0] + País + caracter_separacion_string[0] + Correo_electrónico + caracter_separacion_string[0] + Teléfono + caracter_separacion_string[0] + Fecha_de_ingreso + caracter_separacion_string[0] + Sueldo + caracter_separacion_string[0] + Cargo + caracter_separacion_string[0] + Estado_de_aprendis_E + caracter_separacion_string[0] + Supervisor + caracter_separacion_string[0] + Notas + caracter_separacion_string[0] + Afiliado + caracter_separacion_string[0] + Fecha_de_terminación + caracter_separacion_string[0] + Motivo_de_terminación + caracter_separacion_string[0] + Horas_trabajadas + caracter_separacion_string[0] + Evaluaciones_de_desempeño + caracter_separacion_string[0] + Habilidades_y_certificaciones + caracter_separacion_string[0] + Idiomas + caracter_separacion_string[0] + Fecha_de_última_promoción + caracter_separacion_string[0] + ID_del_departamento_de_supervisión + caracter_separacion_string[0] + Historial_de_capacitación + caracter_separacion_string[0] + Último_aumento_de_salario + caracter_separacion_string[0] + tipo_de_aprendis_E;
                bas.Agregar(direccion_archivo_aprendices_E, datos_a_agregar, esta_arreglo);
                info_a_retornar = resul_agregue + G_caracter_para_confirmacion_o_error[0] + "agregado si es 2 solo al archivo si es 1 tambien al arreglo";
            }
            else
            {
                info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se encontro la direccion";
            }
            return info_a_retornar;
        }

        public string buscar_aprendices_E_cod3_r_(string direccion_archivo, string datos, object caracter_separacion_obj = null)
        {

            string[] caracter_separacion_string = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string info_a_retornar = "";


            string direccion_archivo_aprendices_E = direccion_archivo;
            string resultado_archivo_aprendices_E = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo_aprendices_E);
            string[] res_esp_archivo_E = resultado_archivo_aprendices_E.Split(G_caracter_para_confirmacion_o_error[0][0]);
            if (Convert.ToInt32(res_esp_archivo_E[0]) > 0)//si res es mayor a 0 la operacioon fue exitosa si no hubo un error
            {

                string[] datos_espliteado = datos.Split(caracter_separacion_string[2][0]);


                string ID = "";
                string resul_agregue = "";
                bool esta_arreglo = false;
                if (res_esp_archivo_E[0] == "1")
                {
                    int indic_aprendiz_E = Convert.ToInt32(res_esp_archivo_E[1]);
                    ID = "" + Tex_base.GG_base_arreglo_de_arreglos[indic_aprendiz_E].Length;
                    resul_agregue = "1";
                    esta_arreglo = true;

                }
                else if (res_esp_archivo_E[0] == "-1")
                {
                    ID = "" + bas.leer(direccion_archivo_aprendices_E).Length;
                    resul_agregue = "2";
                    esta_arreglo = false;
                }





            }
            else
            {
                info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se encontro la direccion";
            }
            return info_a_retornar;
        }

        public string extraer_aprendices_E_cod3_r_(string direccion_archivo, string datos, object caracter_separacion_obj = null)
        {

            string[] caracter_separacion_string = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string info_a_retornar = "";


            string direccion_archivo_aprendices_E = direccion_archivo;
            string resultado_archivo_aprendices_E = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo_aprendices_E);
            string[] res_esp_archivo_E = resultado_archivo_aprendices_E.Split(G_caracter_para_confirmacion_o_error[0][0]);
            if (Convert.ToInt32(res_esp_archivo_E[0]) > 0)//si res es mayor a 0 la operacioon fue exitosa si no hubo un error
            {

                string[] datos_espliteado = datos.Split(caracter_separacion_string[2][0]);


                string ID = "";
                string resul_agregue = "";
                bool esta_arreglo = false;
                if (res_esp_archivo_E[0] == "1")
                {
                    int indic_aprendiz_E = Convert.ToInt32(res_esp_archivo_E[1]);
                    ID = "" + Tex_base.GG_base_arreglo_de_arreglos[indic_aprendiz_E].Length;
                    resul_agregue = "1";
                    esta_arreglo = true;

                }
                else if (res_esp_archivo_E[0] == "-1")
                {
                    ID = "" + bas.leer(direccion_archivo_aprendices_E).Length;
                    resul_agregue = "2";
                    esta_arreglo = false;
                }





            }
            else
            {
                info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se encontro la direccion";
            }
            return info_a_retornar;
        }

        public string trabajos_eventual(string direccion_archivo_emp, string proceso, string inf_a_proc)
        {
            string info_a_retornar = null;

            string[] info_a_procesar = inf_a_proc.Split(G_caracter_separacion[1][0]);

            string id_trab = info_a_procesar[0];
            string trabajo_a_hacer = info_a_procesar[1];
            string dias = info_a_procesar[2];
            string id_prog = info_a_procesar[3];

            string[] encontro_trabajador = bas.buscar(direccion_archivo_emp, id_trab, 0, id_trab).Split(G_caracter_para_confirmacion_o_error[0][0]);

            if (Convert.ToInt32(encontro_trabajador[0]) > 0)
            {
                if (encontro_trabajador[0] == "1")
                {
                    string[] info_trabajador = encontro_trabajador[1].Split(G_caracter_separacion[0][0]);
                    string contacto = info_trabajador[12];
                    conexion con = new conexion();
                    string info_a_enviar = proceso + G_caracter_para_transferencia_entre_archivos[1] + trabajo_a_hacer + G_caracter_para_transferencia_entre_archivos[1] + contacto;
                    con.datos_a_enviar("WS_RS", info_a_enviar, id_prog);
                    info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + "trabajador_encontrado_y_enviado";
                }
            }
            else
            {
                if (encontro_trabajador[0] == "0")
                {
                    info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "trabajador_NO_encontrado";
                }
            }



            return info_a_retornar;
        }

        public string agregar_trabajos_dias(string direccion_archivo_trab_dia, string proceso, string ids_emp, string trabajos, string dias, string id_prog_a_env)
        {


            string info_a_retornar = null;

            string[] ids_empleados_esp = ids_emp.Split(G_caracter_separacion[2][0]);

            string[] trabajos_esp = trabajos.Split(G_caracter_separacion[2][0]);

            string[] dias_esp = dias.Split(G_caracter_separacion[2][0]);

            string[] res_ind = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo_trab_dia).Split(G_caracter_para_confirmacion_o_error[0][0]);
            if (res_ind[0] == "1")
            {
                int indice = Convert.ToInt32(res_ind[1]);
                for (int j = 0; j < dias_esp.Length; j++)
                {
                    for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[indice].Length; i++)
                    {
                        string[] info_dia_sem = Tex_base.GG_base_arreglo_de_arreglos[indice][i].Split(G_caracter_separacion[0][0]);
                        if (dias_esp[j] == info_dia_sem[0])
                        {
                            for (int k = 0; k < trabajos_esp.Length; k++)
                            {
                                //"dia|trabajos_cada_fila_es_un_dia°id_trabajador_sie_es_vacio_son_todos°hecho_o_no¬id_quienlo_iso_si_es_vacio_son_todos    |trabajos2_cada_fila_es_un_dia°id_trabajador_sie_es_vacio_son_todos°hecho_o_no¬id_quienlo_iso_si_es_vacio_son_todos"
                                Tex_base.GG_base_arreglo_de_arreglos[indice][i] = op_tex.concatenacion_caracter_separacion(Tex_base.GG_base_arreglo_de_arreglos[indice][i], trabajos_esp[k] + G_caracter_separacion[1] + ids_emp + G_caracter_separacion[1] + "NO_HECHO" + G_caracter_separacion[1] + "" + G_caracter_separacion[1] + id_prog_a_env);

                            }

                            bas.cambiar_archivo_con_arreglo(direccion_archivo_trab_dia, Tex_base.GG_base_arreglo_de_arreglos[indice]);
                            info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + "trabajo_agregado";
                            break;
                        }

                    }
                }

            }

            return info_a_retornar;
        }
    }
}
