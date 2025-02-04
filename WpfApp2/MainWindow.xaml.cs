using System;
using System.IO;
using System.Windows;
using System.Xml.Linq;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Método para actualizar la UI y habilitar/deshabilitar el botón
        private void TextChanged_UpdateUI(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            lblNombrePreview.Text = txtNombre.Text;
            lblTelefonoPreview.Text = txtTelefono.Text;

            // Habilita el botón solo si ambas cajas de texto tienen contenido
            btnGuardar.IsEnabled = !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                                   !string.IsNullOrWhiteSpace(txtTelefono.Text);
        }

        // Método para guardar en XML
        private void GuardarEnXML(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string telefono = txtTelefono.Text;
            string filePath = "contactos.xml";

            XDocument doc;

            // Si el archivo XML ya existe, lo cargamos; si no, lo creamos
            if (File.Exists(filePath))
            {
                doc = XDocument.Load(filePath);
            }
            else
            {
                doc = new XDocument(new XElement("Contactos"));
            }

            // Crear nuevo elemento de contacto
            XElement nuevoContacto = new XElement("Contacto",
                new XElement("Nombre", nombre),
                new XElement("Telefono", telefono));

            doc.Root.Add(nuevoContacto);
            doc.Save(filePath);

            MessageBox.Show("Contacto guardado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
