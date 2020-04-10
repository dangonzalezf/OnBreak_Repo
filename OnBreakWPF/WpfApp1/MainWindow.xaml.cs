using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BibliotecaClientes;


namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Enumeradores para combos Box
        /// </summary>
        public enum TipoEmpresa
        {
            SPA,
            EIRL,
            LIMITADA,
            SA
        }
        public enum ActividadEmpresa
        {

            AGROPECUARIA,
            MINERIA,
            MANUFACUTURA,
            COMERCIO,
            HOTELERIA,
            ALIMENTOS,
            TRANSPORTES,
            SERVICIOS
        }
        /// <summary>
        /// Instanciamiento  de las Colecciones:
        /// </summary>
        ClientesCollection Registro = new ClientesCollection();
        ContratoCollection RegContrato = new ContratoCollection();
        /// <summary>
        /// método main
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            //Pruebas con Datos
            Clientes n1 = new Clientes("1234567");
            Clientes n2 = new Clientes("1432526");
            Clientes n3 = new Clientes("1234563");
            Clientes n4 = new Clientes("1674432");
            Registro.Add(n1);
            Registro.Add(n2);
            Registro.Add(n3);
            Registro.Add(n4);
            Contrato nc1 = new Contrato("1");
            Contrato nc2 = new Contrato("11");
            Contrato nc3 = new Contrato("111");
            RegContrato.Add(nc1);
            RegContrato.Add(nc2);
            RegContrato.Add(nc3);
            foreach (var i in Enum.GetValues(typeof(TipoEmpresa)))
            {
                cb_tipoEmpresa.Items.Add(i);
            }
            foreach(var i in Enum.GetValues(typeof(ActividadEmpresa)))
            {
                cb_actiEmpresa.Items.Add(i);
            }
        }
        /// <summary>
        ///COMIENZA BLOQUE DE EVENTOS TAB ADMINISTRACION DE CLIENTES  ********************************************************************
        ///Evento Boton Registrar CLIENTE:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtRegistrar_Click_1(object sender, RoutedEventArgs e)
        {

            Clientes nuevo = new Clientes();
            if (ValRut(tb_rut.Text) ==true)
            {
                nuevo.Rut = tb_rut.Text;
                nuevo.Razon = tb_razonSocial.Text;
                nuevo.Direccion = tb_direccion.Text;
                nuevo.Telefono = tb_telefono.Text;
                nuevo.Actividad = cb_actiEmpresa.Text;
                nuevo.Tipo = cb_tipoEmpresa.Text;

                Registro.Add(nuevo);
                LimpiarCampos();
                MessageBox.Show("Datos Guardados Correctamente");

            }           
        }
        /// <summary>
        /// Evento Boton Actualizar:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clientes nuevo = new Clientes();           

            if (tbRutC.Text != "" && tb_razonSocial.Text != "" && tb_direccion.Text != "")
            {
                try
                {
                    Clientes Nu = Registro.First(c => c.Rut == tbRutC.Text);
                    Nu.Razon = tb_razonSocial.Text;
                    Nu.Direccion = tb_direccion.Text;
                    Nu.Telefono = tb_telefono.Text;
                    Nu.Actividad = tb_actividad.Text;
                    Nu.Tipo = tb_tipo.Text;
                    MessageBox.Show("Usuario" + Nu.Rut + " Actualizado","Actualizar",MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    //MessageBox.Show("mensaje","encabezado","MessageBoxButton.",MessageBoxImage.");
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    SinRut();
                }
            }
            else
            {
                LlenarCampos();
            }
        }
        /// <summary>
        /// Evento Boton Buscar:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtBuscar_Click(object sender, RoutedEventArgs e)
        {
            MostrarGrid();
            if (tbRutC.Text != String.Empty)
            {
                try
                {
                    Clientes Nu = Registro.First(c => c.Rut == tbRutC.Text);
                    tb_rut.IsEnabled = false;
                    tb_rut.Text = Nu.Rut;
                    MessageBox.Show("hola");
                    tb_razonSocial.Text = Nu.Razon;
                    tb_direccion.Text = Nu.Direccion;
                    tb_telefono.Text = Nu.Telefono;
                    tb_actividad.Text = Nu.Actividad;
                    tb_tipo.Text = Nu.Tipo;                    
                }
                catch (Exception ex)
                {
                    SinRut();
                    LimpiarCampos();
                }
            }
            else
            {
                LlenarRut();
            }
        }        
        /// <summary>
        /// Evento Boton Limpiar:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }
        private void BtEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (tbRutC.Text != String.Empty)
            {
                try
                {
                    Clientes Nu = Registro.First(n => n.Rut == tbRutC.Text);
                    Registro.Remove(Nu);
                    MessageBox.Show("Registro eliminado");
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    SinRut();
                }

            }
            else
            {
                LlenarRut();
            }            
        }
        /// <summary>
        ///Métodos Personalizados: Mensajes y alertas
        /// </summary>
        /// 
        public bool ValRut(String rut)
        {
            bool val = false;

            foreach (Clientes i in Registro)
            {
                if (i.Rut == rut)
                {
                    val = false;
                    MessageBox.Show("El rut ingresado ya existe");
                    break;
                }
                else if (rut == String.Empty)
                {
                    MessageBox.Show("Ingresa un rut");
                    val = false;
                    break;
                }
                else
                {
                    val = true;
                }
            }
            return val;
        }
        private void LlenarCampos()
        {
            MessageBox.Show("Debes llenar todo los campos", "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
        private void LlenarRut()
        {
            MessageBox.Show("Ingrese un rut","Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
        private void Refrescar()
        {
            dgClientes.Items.Refresh();
        }
        private void SinRut()
        {
            MessageBox.Show("No se encontro el cliente rut " + tbRutC.Text);
        }
        /// <summary>
        /// Método limpiar campos
        /// </summary>
        private void LimpiarCampos()
        {
            tb_rut.IsEnabled = true;
            tb_rut.Text = "";
            tb_razonSocial.Text = String.Empty;
            tb_direccion.Text = "";
            tb_telefono.Text = String.Empty;
            tb_actividad.Text = "";
            tb_tipo.Text = String.Empty;
            tbRutC.Text = String.Empty;
            cb_actiEmpresa.SelectedIndex = -1;
            cb_tipoEmpresa.SelectedIndex = -1;
        }
        private void MostrarGrid()
        {
            dgClientes.ItemsSource = Registro;
            dgClientes.Items.Refresh();
        }
        private void LimpiarGrid()
        {
            dgClientes.Columns.Clear();
        }

        /// <summary>
        /// COMIENZO DE BLOQUE DE CODIGO CONTROLADOR DE EVENTOS DEL TAB ADMINISTRACION DE CONTRATOS:------------------------------------
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        ///REGISTRO DE CONTRATO
        private void Button_Click_RegContrato(object sender, RoutedEventArgs e)
        {
            Contrato Con = new Contrato();
            if (ValCon(tbContrato.Text)==true /* && tbDirecContrato.Text != String.Empty && dpCreacion.Text!="" && dpTermino.Text!="" 
                && tbTipoContrato.Text != String.Empty && tbObservaciones.Text != String.Empty*/)
            {
                Con.NumeroContraro= tbContrato.Text;
                Con.FechaHoraIni=dpCreacion.SelectedDate.ToString();
                Con.FechaHoraTer=dpTermino.SelectedDate.ToString();
                Con.DireContrato=tbDirecContrato.Text;
                if(cbVigencia.IsChecked==true)
                {
                    Con.EstadoVig = "VIGENTE";
                }
                else
                {
                    Con.EstadoVig = "NO VIGENTE";
                }
                Con.Tipo=tbTipoContrato.Text;
                Con.Observaciones=tbObservaciones.Text;
                RegContrato.Add(Con);
                MessageBox.Show("Contrato Registrado con Exito", "Notificación", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarCamposContrato();
                MostrarContratos();
            }
            /*else
            {
                LlenarCampos();
            }*/
        }
        /// <summary>
        /// EVENTO BOTON BUSCAR CONTRATO:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtBuscarContrato_Click(object sender, RoutedEventArgs e)
        {
            Contrato Con = new Contrato();
            if(tbBusNumContrato.Text != String.Empty)
            {
                try
                {
                    Con = RegContrato.First(con => con.NumeroContraro == tbBusNumContrato.Text);                    
                    tbContrato.Text = Con.NumeroContraro;
                    tbDirecContrato.Text = Con.DireContrato;
                    if (Con.EstadoVig.Equals("VIGENTE"))
                    {
                        cbVigencia.IsChecked = true;
                    } 
                    else
                    {
                        cbVigencia.IsChecked = false;
                    }
                    tbTipoContrato.Text = Con.Tipo;
                    tbObservaciones.Text = Con.Observaciones;
                    String ini = Con.FechaHoraIni.ToString();
                    String fin = Con.FechaHoraTer.ToString();
                    dpCreacion.SelectedDate=DateTime.Parse(ini);
                    dpTermino.SelectedDate = DateTime.Parse(fin);
                    tbContrato.IsEnabled = false;
                    MostrarContratos();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("No hay Resultados", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
            else
            {
                SinNumero();
            }
        }

        private void SinNumero()
        {
            MessageBox.Show("Debes Ingresar un numero de contrato", "Alerta", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// MÉTODO MOSTRAR DATAGRID CONTRATOS
        /// </summary>
        private void MostrarContratos()
        {
            dgContrato.ItemsSource=RegContrato;
            dgContrato.Items.Refresh();
        }        
        private void BtLimContrato_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
            tbContrato.IsEnabled = true;
        }
        /// <summary>
        /// EVENTO ACTUALIZAR CONTRATO:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtActContrato_Click(object sender, RoutedEventArgs e)
        {
            Contrato Con = new Contrato();

            if (tbContrato.Text != String.Empty)
            {
                try
                {

                    Con = RegContrato.First(c => c.NumeroContraro == tbContrato.Text);                    
                    Con.FechaHoraIni = dpCreacion.SelectedDate.ToString();
                    Con.FechaHoraTer = dpTermino.SelectedDate.ToString();
                    Con.DireContrato = tbDirecContrato.Text;
                    if (cbVigencia.IsChecked == true)
                    {
                        Con.EstadoVig = "VIGENTE";
                    }
                    else
                    {
                        Con.EstadoVig = "NO VIGENTE";
                    }
                    Con.Tipo = tbTipoContrato.Text;
                    Con.Observaciones = tbObservaciones.Text;
                    MessageBox.Show("Contrato Registrado con Exito", "Notificación", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposContrato();
                    MostrarContratos();
                }
                catch (Exception ex)
                {
                    SinRut();
                }
            }
            else
            {
                SinNumero();

            }

        }
        /// <summary>
        /// LIMPIAR CAMPOS FORM CONTRATO
        /// </summary>
        private void LimpiarCamposContrato()
        {
            tbContrato.Text = String.Empty;
            tbDirecContrato.Text = String.Empty;
            cbVigencia.IsChecked = false;
            tbTipoContrato.Text = String.Empty;
            tbObservaciones.Text = String.Empty;
            dpCreacion.SelectedDate = DateTime.Today;
            dpTermino.SelectedDate = DateTime.Today;
        }
        public bool ValCon(String num)
        {
            bool val = false;

            foreach (Contrato i in RegContrato)
            {
                if (i.NumeroContraro == num)
                {
                    val = false;
                    MessageBox.Show("El N° de Contrato ingresado ya existe");
                    break;
                }
                else if (num == String.Empty)
                {
                    MessageBox.Show("Ingresa un N° de contrato");
                    val = false;
                    break;
                }
                else
                {
                    val = true;
                }
            }
            return val;
        }
    }
}
