﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hoteles;
using Hoteles.Properties;
using System.Drawing;

namespace Hoteles.Entities
{
    static class GestorTeclado
    {
        static bool fPresionada = false;
        static string funcion;
        static int luz = 1;

        static public Boolean ProcesarTecla(Keys tecla,fPrincipal formPrincipal)
        {       
            
            if (tecla == Keys.Escape)
            {
                fPresionada = false;
                //formPrincipal.fIngresos.Visible = false;
                //formPrincipal.lTitulo.Text = "";
                //formPrincipal.input1.Text = "";
                return true;
            }
            if(tecla == Keys.Alt)
            {
                return true;
            }
            if (tecla == Keys.L)
            {
                if (luz == 0)
                {
                    ((DataGridViewImageCell)formPrincipal.dataGridView1.Rows[0].Cells["luz"]).Value = Resources.luzOn;
                    luz = 1;
                }
                else
                if (luz == 1)
                {
                    ((DataGridViewImageCell)formPrincipal.dataGridView1.Rows[0].Cells["luz"]).Value = Resources.luzOff3;
                    luz = 0;
                }
                return true;
            }

            if (tecla == Keys.F1 || tecla == Keys.F2 || tecla == Keys.F3 || tecla == Keys.F4 || tecla == Keys.F5
                || tecla == Keys.F6 || tecla == Keys.F7 || tecla == Keys.F8 || tecla == Keys.F9 || tecla == Keys.F10
                || tecla == Keys.F11 || tecla == Keys.F12)
            {
                //if (!fPresionada)
                {
                    fPresionada = true;
                    
                    
                    switch (tecla)
                    {
                        case Keys.F1:
                            funcion = "F1";
                            FormAsignarHab asignarHab = new FormAsignarHab();
                            asignarHab.Owner = formPrincipal;
                            //formPrincipal.AddOwnedForm(asignarHab);
                            asignarHab.Show();
                            asignarHab.Activate();
                            
                            //formPrincipal.fIngresos.Size = new System.Drawing.Size(1,1);
                            ////formPrincipal.tableLayoutPanel1.Controls.Add(tools.crearFormIngreso(),1,2);
                            //formPrincipal.lTitulo.Text = "Asignación de Habitaciones";
                            Habitacion.asignar(formPrincipal);
                            //formPrincipal.lTitulo.Width = formPrincipal.lTitulo.Parent.Width;
                            break;
                        case Keys.F2:
                            //formPrincipal.lTitulo.Text = "Cancelacion de Habitaciones";
                            Habitacion.cancelar(formPrincipal);
                            break;
                        case Keys.F3:
                            Alarma.activar(formPrincipal);
                            //formPrincipal.tableLayoutPanel1.Controls.Add(formPrincipal.dataGridView1, 0, 1);
                            //formPrincipal.tableLayoutPanel1.SetRowSpan(formPrincipal.dataGridView1, 2);
                            break;
                        case Keys.F4:
                            Alarma.desactivar();
                            break;
                        case Keys.F5:
                            break;
                        case Keys.F6:
                            break;
                        case Keys.F7:
                            break;
                        case Keys.F8:
                            break;
                        case Keys.F9:
                            break;
                        case Keys.F10:
                            break;
                        case Keys.F11:
                            formPrincipal.dataGridView1.FirstDisplayedScrollingRowIndex = formPrincipal.dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Displayed);
                            break;
                        case Keys.F12:
                            formPrincipal.dataGridView1.FirstDisplayedScrollingRowIndex = 0;
                            break;
                        default:
                            return false;
                    }
                    
                    return true;
                }
            }
            
            return false;            
        }

    }
}
