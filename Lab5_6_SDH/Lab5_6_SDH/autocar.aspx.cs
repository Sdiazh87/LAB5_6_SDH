using CapaDatos;
using CapaDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab5_6_SDH
{
    public partial class autocar : System.Web.UI.Page
    {
        GestionDatos objGestion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargaAutos();
            }
        }

        void mostrarMensaje(string txtMensaje, bool Tipo)
        {
            if (Tipo)
            {
                lblExito.Text = txtMensaje;
                lblError.Text = "";
            }
            else
            {
                lblExito.Text = "";
                lblError.Text = txtMensaje;
            }
        }

        void cargaAutos()
        {
            DataTable datoAuto = new DataTable();
            objGestion = new GestionDatos();
            datoAuto = objGestion.cargaAuto();

            if (datoAuto.Rows.Count > 0)
            {
                GridAutocar.DataSource = datoAuto;
                GridAutocar.DataBind();
            }
            else
            {
                datoAuto.Rows.Add(datoAuto.NewRow());
                GridAutocar.DataSource = datoAuto;
                GridAutocar.DataBind();
                GridAutocar.Rows[0].Cells.Clear();
                GridAutocar.Rows[0].Cells.Add(new TableCell());
                GridAutocar.Rows[0].Cells[0].ColumnSpan = datoAuto.Columns.Count;
                GridAutocar.Rows[0].Cells[0].Text = "NO HAY DATOS";
                GridAutocar.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }
        
        protected void GridAutocar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                objGestion = new GestionDatos();
                Autos objAuto = new Autos();

                if ((GridAutocar.FooterRow.FindControl("txtMarcaPie") as TextBox).Text.Trim() != ""
                    && (GridAutocar.FooterRow.FindControl("txtModeloPie") as TextBox).Text.Trim() !=""
                    && (GridAutocar.FooterRow.FindControl("txtPaisPie") as TextBox).Text.Trim() != ""
                    && (GridAutocar.FooterRow.FindControl("txtCostoPie") as TextBox).Text.Trim() != "")
                {
                    objAuto.Marca = (GridAutocar.FooterRow.FindControl("txtMarcaPie") as TextBox).Text.Trim();
                    objAuto.Modelo = (GridAutocar.FooterRow.FindControl("txtModeloPie") as TextBox).Text.Trim();
                    objAuto.Pais = (GridAutocar.FooterRow.FindControl("txtPaisPie") as TextBox).Text.Trim();
                    objAuto.Costo = (Convert.ToDouble((GridAutocar.FooterRow.FindControl("txtCostoPie") as TextBox).Text.Trim()));
                    int resultado = objGestion.registrarAuto(objAuto);

                    if (resultado == 1)
                    {
                        cargaAutos();
                        mostrarMensaje("Registro Exitoso", true);
                    }
                    else
                    {
                        mostrarMensaje("Hay un error en el registro", false);
                    }
                }
                else
                {
                    mostrarMensaje("Debe llenar todos los datos", false);
                }
               
            }
        }

        protected void GridAutocar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridAutocar.EditIndex = e.NewEditIndex;
            cargaAutos();
        }

        protected void GridAutocar_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridAutocar.EditIndex = -1;
            cargaAutos();
        }

        protected void GridAutocar_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            objGestion = new GestionDatos();
            Autos objAuto = new Autos();
            objAuto.Marca = (GridAutocar.Rows[e.RowIndex].FindControl("txtMarca") as TextBox).Text.Trim();
            objAuto.Modelo = (GridAutocar.Rows[e.RowIndex].FindControl("txtModelo") as TextBox).Text.Trim();
            objAuto.Pais = (GridAutocar.Rows[e.RowIndex].FindControl("txtPais") as TextBox).Text.Trim();
            objAuto.Costo = Convert.ToDouble((GridAutocar.Rows[e.RowIndex].FindControl("txtCosto") as TextBox).Text.Trim());
            objAuto.Id_Carro = Convert.ToInt32(GridAutocar.DataKeys[e.RowIndex].Value.ToString());
            int resultado = objGestion.actualizarAuto(objAuto);
            GridAutocar.EditIndex = -1;

            if (resultado == 1)
            {
                cargaAutos();
                mostrarMensaje("Actualización Exitosa", true);
            }
            else
            {
                mostrarMensaje("Hay un error en la actualización", false);
            }
        }

        protected void GridAutocar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objGestion = new GestionDatos();
            Autos objAuto = new Autos();
            objAuto.Id_Carro = Convert.ToInt32(GridAutocar.DataKeys[e.RowIndex].Value.ToString());
            objGestion.eliminarAuto(objAuto);
            GridAutocar.EditIndex = -1;
            cargaAutos();
            mostrarMensaje("Registro Eliminado", false);
        }
    }
}