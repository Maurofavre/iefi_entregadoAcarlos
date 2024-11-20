using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEFI_ED
{
    public partial class Form1 : Form
    {

        private Arbol Personajes  = new Arbol();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbTipo.Items.Clear();
            
            cmbTipo.Items.Add("Oficial");
            cmbTipo.Items.Add("Soldado");
            cmbTipo.SelectedIndex = 0;


            ElegirTipo();



        }
        
 

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ElegirTipo();
        }

        private void ElegirTipo()
        {
            cmbRango.Items.Clear();


            if (cmbTipo.SelectedIndex == 0)
            {
            
                cmbRango.Items.Add("Coronel");
                cmbRango.Items.Add("Capitán");
                cmbRango.Items.Add("Teniente");
                cmbRango.Items.Add("Sargento");

                cmbRango.Enabled = true;
            
            }
            if (cmbTipo.SelectedIndex == 1)
            {
                cmbRango.Items.Add("Soldado");
                cmbRango.SelectedIndex = 0;

                cmbRango.Enabled = false;
            }
            
            if (cmbRango.Items.Count > 0)
            {
                cmbRango.SelectedIndex = 0;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string rango = cmbRango.Text;
            string tipo = cmbTipo.Text;

            if (txtCodigo.Text == "" || !int.TryParse(txtCodigo.Text, out _) || txtNombre.Text == "" || txtNombre.Text.Length < 3)
            {

                MessageBox.Show("Verifique que los datos estén correctos", "Cuidado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Text = "";
                txtNombre.Text = "";

            }
            else
            {

                Nodo personaje = new Nodo();

                personaje.Codigo = int.Parse(txtCodigo.Text);
                personaje.Nombre = txtNombre.Text;

                personaje.Rango = rango;
                personaje.Tipo = tipo;
                Personajes.Insertar(personaje);

               
                txtNombre.Text = "";
                txtCodigo.Text = "";

             
                grPersonajes.Rows.Clear();
                List<Nodo> guerrero = new List<Nodo>();

                guerrero = Personajes.Listar(Personajes.Raiz);
                foreach (Nodo n in guerrero)
                {
                    grPersonajes.Rows.Add(n.Codigo.ToString(), n.Nombre, n.Tipo, n.Rango);
                }
                
            }
        }
    }
}
