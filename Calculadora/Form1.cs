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

        //variable para almacenar el numero actual
        private string numeroActual = "";

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
            numeroActual += btn.Text;
            textBox1.Text = numeroActual;
        }

        private void btnOperador_Click(object sender, EventArgs e)
        {
            // Manejar los eventos de los botones de operadores (+, -, *, /)
            Button btn = (Button)sender;

            // Si ya hay un número en el TextBox, realiza la operación pendiente
            if (!string.IsNullOrEmpty(numeroActual))
            {
                double numero = double.Parse(numeroActual);
                // Si ya hay un operador en el TextBox, realiza la operación pendiente
                if (!string.IsNullOrEmpty(operador))
                    RealizarOperacion(numero);
                else
                    acumulado = numero;

                // Muestra el número y el operador en el TextBox
                textBox1.Text = acumulado.ToString() + btn.Text;
                operador = btn.Text;
                numeroActual = "";
            }
        }
        private void RealizarOperacion(double numero)
        {
            switch (operador)
            {
                case "+":
                    acumulado += numero;
                    break;
                case "-":
                    acumulado -= numero;
                    break;
                case "x":
                    acumulado *= numero;
                    break;
                case "÷":
                    acumulado /= numero;
                    break;
                case "1/x":
                    
                    break;
                case "x^2":
                    acumulado *=acumulado;
                    break;
                case "√":
                    
                    break;
                case "%":
                    break;
            }
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

        private void button17_Click_1(object sender, EventArgs e)
        {
            btnNumero_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnNumero_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnNumero_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnNumero_Click(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            btnNumero_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            btnNumero_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnNumero_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            btnOperador_Click(sender, e);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            btnOperador_Click(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            btnOperador_Click(sender, e);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(numeroActual) && !string.IsNullOrEmpty(operador))
            {
                double numero = double.Parse(numeroActual);
                RealizarOperacion(numero);
                textBox1.Text = acumulado.ToString();
                operador = "";
                numeroActual = "";
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            btnOperador_Click(sender, e);
        }
    }
}
