﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hoteles.Entities
{
    public class tools
    {
        public static int calcularAltoFila(fPrincipal form,int cantFilas,int maxFilas)
        {
            if(cantFilas>maxFilas)
                cantFilas=maxFilas+1;
            return (form.dataGridView1.Height - form.dataGridView1.ColumnHeadersHeight) / cantFilas;
        }


        public static DataGridView CopyDataGridView(DataGridView dgv_in,DataGridView dgv_out)
        {
            //DataGridView dgv_copy = new DataGridView();
            try
            {
                if (dgv_out.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn dgvc in dgv_in.Columns)
                    {
                        dgv_out.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                    }
                }

                DataGridViewRow row = new DataGridViewRow();

                for (int i = 0; i < dgv_in.Rows.Count; i++)
                {
                    row = (DataGridViewRow)dgv_in.Rows[i].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dgv_in.Rows[i].Cells)
                    {
                        row.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }
                    dgv_out.Rows.Add(row);
                }
                dgv_out.AllowUserToAddRows = false;
                dgv_out.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Copy DataGridViw"+ex.Message);
            }
            return dgv_out;
        }

        public static FlowLayoutPanel crearFormIngreso()
        {
            FlowLayoutPanel fIngresos = new System.Windows.Forms.FlowLayoutPanel();
            Label lTitulo = new Label();

            fIngresos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            fIngresos.Controls.Add(lTitulo);
            
            fIngresos.Dock = System.Windows.Forms.DockStyle.Fill;
            //fIngresos.Location = new System.Drawing.Point(323, 403);
            fIngresos.Name = "fIngresos";
            //fIngresos.Size = new System.Drawing.Size(314, 49);
            fIngresos.TabIndex = 6;

            return fIngresos;
            
        }

        //public static DataGridView crearFormIngreso()
        //{
        //    FlowLayoutPanel fIngresos = new System.Windows.Forms.FlowLayoutPanel();
        //    Label lTitulo = new Label();

        //    fIngresos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        //    fIngresos.Controls.Add(lTitulo);

        //    fIngresos.Dock = System.Windows.Forms.DockStyle.Fill;
        //    //fIngresos.Location = new System.Drawing.Point(323, 403);
        //    fIngresos.Name = "fIngresos";
        //    //fIngresos.Size = new System.Drawing.Size(314, 49);
        //    fIngresos.TabIndex = 6;

        //    return fIngresos;

        //}

    }
}