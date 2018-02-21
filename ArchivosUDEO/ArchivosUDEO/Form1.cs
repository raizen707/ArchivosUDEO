using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchivosUDEO
{
    public partial class Form1 : Form
    {
        Stack<Cliente> pilaCliente = new Stack<Cliente>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog cuadroDialogoAbrieArchivo = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Archivos de Texto (*.txt)|*.txt|Todos Los Archivos (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (cuadroDialogoAbrieArchivo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((cuadroDialogoAbrieArchivo.OpenFile()) != null)
                    {
                        string ubicacionArchivo = cuadroDialogoAbrieArchivo.FileName;

                        string linea;
                        StringBuilder sbArchivos = new StringBuilder();

                        StreamReader archivo = new StreamReader(ubicacionArchivo);
                        while ((linea = archivo.ReadLine()) != null)
                        {
                            sbArchivos.AppendLine(linea);
                            var lineaArray = linea.ToString().Split(',');
                            if (lineaArray.Length == 5)
                            {
                                AgregarCLiente( Convert.ToInt32(lineaArray[0]), lineaArray[1], lineaArray[2], Convert.ToInt32(lineaArray[3]), Convert.ToInt32(lineaArray[4]));
                            }
                            else if (lineaArray.Length == 6)
                            {
                                AgregarCLiente(Convert.ToInt32(lineaArray[0]), lineaArray[1], lineaArray[2], Convert.ToInt32(lineaArray[3]), Convert.ToInt32(lineaArray[4]),Convert.ToChar(lineaArray[5]));
                            }
                        }
                        richTextBox1.Text = sbArchivos.ToString();
                    }
                    MessageBox.Show("Total de clientes agregados: " + pilaCliente.Count);
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show("Error: No se puede leer el archivo desde el disco duro: " + ex.Message);
                }
            }
        }

        private void AgregarCLiente(int Carne, string Nombre, string Apellido, int Edad, int AnioNacimiento) {
            Cliente cliente = new Cliente
            {
                Carne = Carne,
                Nombre = Nombre,
                Apellido = Apellido,
                Edad = Edad,
                AnioNacimiento = AnioNacimiento
            };
            pilaCliente.Push(cliente);
        }
        private void AgregarCLiente(int Carne, string Nombre, string Apellido, int Edad, int AnioNacimiento, char Sexo)
        {
            Cliente cliente = new Cliente
            {
                Carne = Carne,
                Nombre = Nombre,
                Apellido = Apellido,
                Edad = Edad,
                AnioNacimiento = AnioNacimiento,
                Sexo = Sexo
            };
            pilaCliente.Push(cliente);
        }
    }
}
