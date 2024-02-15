using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        // Variable para almacenar el valor acumulado
        private double acumulado = 0;

        // Variable para almacenar el operador
        private string operador = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnNumero_Click(object sender, EventArgs e)
        {
            // Manejar los eventos de los botones numéricos (0-9)
            Button btn = (Button)sender;
            textBox1.Text += btn.Text;
        }

        private void btnOperador_Click(object sender, EventArgs e)
        {
            // Manejar los eventos de los botones de operadores (+, -, *, /)
            Button btn = (Button)sender;

            // Si ya hay un operador y un número en el TextBox, realiza la operación pendiente
            if (!string.IsNullOrEmpty(operador) && !string.IsNullOrEmpty(textBox1.Text))
            {
                double numeroActual = double.Parse(textBox1.Text);

                switch (operador)
                {
                    case "+":
                        acumulado += numeroActual;

                        break;
                    case "-":
                        acumulado -= numeroActual;
                        break;
                    case "x":
                        acumulado *= numeroActual;
                        break;
                    case "÷":
                        acumulado /= numeroActual;
                        break;
                }

                // Muestra el resultado acumulado en el TextBox
                textBox1.Text = acumulado.ToString();
            }
            switch (operador)
            {
                case "+":
                    textBox1.Text += "+";
                    break;
                case "-":
                    textBox1.Text += "-";
                    break;
                case "x":
                    textBox1.Text += "*";
                    break;
                case "÷":
                    textBox1.Text += "/";
                    break;
            }
            

            // Almacena el nuevo operador
            operador = btn.Text;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            btnNumero_Click(sender, e);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            btnOperador_Click(sender, e);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            btnNumero_Click(sender, e);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            btnNumero_Click(sender, e);
        }
    }
}
