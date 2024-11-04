using BLL;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    internal class ModoHandler
    {
        private Button _btnAgregar;
        private Button _btnModificar;
        private Button _btnEliminar;
        private Button _btnAplicar;
        private Button _btnCancelar;
        private GroupBox _grpDatos;
        private Label _lblModo;
        internal Modo modoActual;

        public ModoHandler(Button btnAgregar, Button btnModificar, Button btnEliminar,
                           Button btnAplicar, Button btnCancelar, GroupBox grpDatos, Label lblModo)
        {
            _btnAgregar = btnAgregar;
            _btnModificar = btnModificar;
            _btnEliminar = btnEliminar;
            _btnAplicar = btnAplicar;
            _btnCancelar = btnCancelar;
            _grpDatos = grpDatos;
            _lblModo = lblModo;

            CambiarModo(Modo.Consulta);
        }

        public void CambiarModo(Modo nuevoModo)
        {
            modoActual = nuevoModo;
            //_lblModo.Text = Translation.GetEnumTranslation(modoActual);

            switch (modoActual)
            {
                case Modo.Consulta:
                    ControlHelper.EnableControls(_btnAgregar, _btnModificar, _btnEliminar);
                    ControlHelper.DisableControls(_btnAplicar, _btnCancelar, _grpDatos);
                    ControlHelper.ClearTextBoxes(_grpDatos);
                    break;
                case Modo.Agregar:
                    ControlHelper.EnableControls(_btnCancelar, _btnAplicar, _grpDatos);
                    ControlHelper.DisableControls(_btnModificar, _btnEliminar);
                    ControlHelper.ClearTextBoxes(_grpDatos);
                    break;
                case Modo.Modificar:
                    ControlHelper.EnableControls(_btnCancelar, _btnAplicar, _grpDatos);
                    ControlHelper.DisableControls(_btnAgregar, _btnEliminar);
                    break;
                case Modo.Eliminar:
                    ControlHelper.EnableControls(_btnCancelar, _btnAplicar);
                    ControlHelper.DisableControls(_btnAgregar, _btnModificar);
                    break;
            }
        }
    }
}
