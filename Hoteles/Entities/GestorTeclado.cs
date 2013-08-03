using System;
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

        static public Boolean ProcesarTecla(Keys tecla,fPrincipal2 formPrincipal)
        {       
            
            if (tecla == Keys.Escape)
            {
                for (int nH = 101; nH < 121; nH++)
                {
                    formPrincipal.estadoHabitaciones[nH] = 0;
                }                             
                return true;
            }
            if(tecla == Keys.Alt)
            {
                return true;
            }
            if (tecla == Keys.M)
            {
                FormCierreTurnoCliente asignarHab = new FormCierreTurnoCliente();
                asignarHab.Owner = formPrincipal;
                asignarHab.Show();
                formPrincipal.Hide();
                asignarHab.Activate();
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
                            asignarHab.Show();                            
                            asignarHab.Activate();
                            asignarHab.tbNroHab.Focus();
                            
                            
                            break;
                        case Keys.F2:                            
                            FormCancelarHab cancelarHab = new FormCancelarHab();
                            cancelarHab.Owner = formPrincipal;                            
                            cancelarHab.Show();
                            formPrincipal.Hide();
                            cancelarHab.Activate();
                            cancelarHab.tbNroHab.Focus();
                            LoggerProxy.Info("Ingreso Cancelar Habitación");
                            break;
                        case Keys.F3:
                            FormAdelantoDinero fAdelantoDinero = new FormAdelantoDinero();
                            fAdelantoDinero.Owner = formPrincipal;
                            fAdelantoDinero.Show();
                            formPrincipal.Hide();
                            fAdelantoDinero.Activate();
                            fAdelantoDinero.tbNroHab.Focus();
                            LoggerProxy.Info("Ingreso Adelanto Dinero");
                            break;
                        case Keys.F4:
                            FormCierreTurno fCierreTurno = new FormCierreTurno();
                            fCierreTurno.Owner = formPrincipal;
                            fCierreTurno.Show();
                            formPrincipal.Hide();
                            fCierreTurno.Activate();
                            fCierreTurno.tbNroHab.Focus();
                            LoggerProxy.Info("Ingreso Cerrar Turno");
                            break;
                        case Keys.F5:
                            FormPedidoBar pedidoBar = new FormPedidoBar();
                            pedidoBar.Owner = formPrincipal;
                            pedidoBar.Show();
                            formPrincipal.Hide();
                            pedidoBar.Activate();
                            pedidoBar.tbNroHab.Focus();
                            LoggerProxy.Info("Ingreso Pedido de Bar");
                            break;
                        case Keys.F6:
                            FormAnularPedidoBar anuPedidoBar = new FormAnularPedidoBar();                            
                            anuPedidoBar.Show();
                            anuPedidoBar.Owner = formPrincipal;
                            formPrincipal.Hide();
                            anuPedidoBar.Activate();
                            anuPedidoBar.tbNroHab.Focus();
                            LoggerProxy.Info("Ingreso Anular Pedido Bar");
                            break;
                        case Keys.F7:
                            FormAvisosHorarios avisosHorarios = new FormAvisosHorarios();
                            avisosHorarios.Owner = formPrincipal;
                            avisosHorarios.Show();
                            formPrincipal.Hide();
                            avisosHorarios.Activate();
                            avisosHorarios.tbNroHab.Focus();
                            LoggerProxy.Info("Ingreso Avisos Horarios");
                            
                            break;
                        case Keys.F8:
                            FormCambiarEstado fCambEst = new FormCambiarEstado();
                            fCambEst.Owner = formPrincipal;
                            fCambEst.Show();
                            formPrincipal.Hide();
                            fCambEst.Activate();
                            fCambEst.tbNroHab.Focus();
                            LoggerProxy.Info("Ingreso Cambiar Estado Habitación");

                            break;
                        case Keys.F9:
                            FormExtraccionDinero extraccionDinero = new FormExtraccionDinero();
                            extraccionDinero.Owner = formPrincipal;
                            extraccionDinero.Show();
                            formPrincipal.Hide();
                            extraccionDinero.Activate();
                            extraccionDinero.tbNroHab.Focus();
                            LoggerProxy.Info("Ingreso Extracción Dinero");

                            break;
                        case Keys.F10:
                            FormClavesOpcionales fClavesOp = new FormClavesOpcionales();
                            fClavesOp.Owner = formPrincipal;
                            fClavesOp.Show();
                            formPrincipal.Hide();
                            fClavesOp.Activate();
                            fClavesOp.tbNroHab.Focus();
                            LoggerProxy.Info("Ingreso Claves Opcionales");
                            
                            break;
                        case Keys.F11:
                            FormEstadoCaja fEstCaja = new FormEstadoCaja();
                            fEstCaja.Owner = formPrincipal;
                            fEstCaja.Show();
                            formPrincipal.Hide();
                            fEstCaja.Activate();
                            LoggerProxy.Info("Ingreso Estado Caja");

                            break;
                        case Keys.F12:
                            FormCierrePlanilla cierrePlanilla = new FormCierrePlanilla();
                            cierrePlanilla.Owner = formPrincipal;
                            cierrePlanilla.Show();
                            formPrincipal.Hide();
                            cierrePlanilla.Activate();
                            cierrePlanilla.tbNroHab.Focus();
                            LoggerProxy.Info("Ingreso Cierre Caja");
                            
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
