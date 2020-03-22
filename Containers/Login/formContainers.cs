using BL.Containers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class formContainers : Form
    {
        ContainersBL _containers;

        public formContainers()
        {
            InitializeComponent();

            _containers = new ContainersBL();
            listaContainersBindingSource.DataSource = _containers.ObtenerContainers();
        }

        //Guardar
        private void listaContainersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaContainersBindingSource.EndEdit();
            var container = (BL.Containers.Container)listaContainersBindingSource.Current;
            var resultado = _containers.GuardarProducto(container);

            if (resultado.Exitoso == true)
            {
                listaContainersBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        //Agregar

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _containers.AgregarProducto();
            listaContainersBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }

        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;

            toolStripButtonCancelar.Visible = !valor;
        }

        //Eliminar

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
           
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
            }
        }

        private void Eliminar(int id)
        {
            
            var resultado = _containers.EliminarProducto(id);

            if (resultado == true)
            {
                listaContainersBindingSource.ResetBindings(false);
            }

            else
            {
                MessageBox.Show("Ocurrio un error al eleminar el producto");
            }
        }

        //Cancelar

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);
        }

        private void formContainers_Load(object sender, EventArgs e)
        {

        }
    }
}
