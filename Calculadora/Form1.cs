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
        // Variable para controlar si ya se ingresó el punto decimal
        private bool puntoDecimalIngresado = false;
        //Lista para guardar los valores
        private List<double> valoresEnMemoria = new List<double>();
        //Lista para guardar el historial
        private List<string> historialOperaciones = new List<string>();
        // Variable para almacenar el valor acumulado
        private double acumulado = 0;
        //Variable de la raiz
        private bool resultadoRaizCalculado = false;

        // Variable para almacenar el operador
        private string operador = "";

        //variable para almacenar el numero actual
        private string numeroActual = "0";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnNumero_Click(object sender, EventArgs e)
        {
            // Restablecer la variable al ingresar un nuevo número
            puntoDecimalIngresado = false;
            // Manejar los eventos de los botones numéricos (0-9)
            Button btn = (Button)sender;
            numeroActual += btn.Text;
            textBox1.Text = numeroActual;
        }

        private void btnOperador_Click(object sender, EventArgs e)
        {
            // Resetear la variable al presionar un operador
            puntoDecimalIngresado = false;

            // Manejar los eventos de los botones de operadores (+, -, *, /)
            Button btn = (Button)sender;

            // Verificar si ya se ha aplicado la raíz cuadrada
            bool raizAplicada = false;

            // Si ya hay un operador en el TextBox, realiza la operación pendiente
            if (!string.IsNullOrEmpty(operador))
            {
                double numero = string.IsNullOrEmpty(numeroActual) ? 0 : double.Parse(numeroActual);

                // Si el operador es raíz cuadrada y ya se aplicó, no realizar la operación nuevamente
                if (operador == "√" && raizAplicada)
                {
                    textBox1.Text = acumulado.ToString() + btn.Text;
                    operador = btn.Text;
                    numeroActual = "";
                    return;
                }

                RealizarOperacion(numero);

                // Si el operador es raíz cuadrada, marcar como aplicada
                raizAplicada = (operador == "√");
            }
            else
            {
                // Si no hay operador, simplemente asigna el número actual al acumulado
                acumulado = string.IsNullOrEmpty(numeroActual) ? acumulado : double.Parse(numeroActual);
            }

            // Muestra el número y el operador en el TextBox
            textBox1.Text = acumulado.ToString() + btn.Text;
            operador = btn.Text;
            numeroActual = "";

            // Si el operador es raíz cuadrada y ya se aplicó, no realizar la operación nuevamente
            if (operador == "√" && raizAplicada)
            {
                return;
            }

            // Si el operador es raíz cuadrada, realiza la operación inmediatamente
            if (operador == "√")
            {
                RealizarOperacion(0);  // El segundo parámetro es arbitrario, ya que la raíz se calcula sobre el acumulado
            }
        }

        private void RealizarOperacion(double numero)
        {
            double acumuladoAntes = acumulado;
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
                    // Asegúrate de no dividir por cero
                    if (numero != 0)
                        acumulado /= numero;
                    else
                    {
                        MessageBox.Show("Error: No es posible dividir por cero.", "Error de operación");
                        LimpiarCalculadora();
                        return;
                    }
                    break;
                case "1/x":
                    // Asegúrate de no dividir por cero
                    if (numero != 0)
                        acumulado = 1 / acumulado;
                    else
                    {
                        MessageBox.Show("Error: No es posible dividir 1 por cero.", "Error de operación");
                        LimpiarCalculadora();
                        return;
                    }
                    break;
                case "x^2":
                    acumulado = Math.Pow(acumulado, 2);
                    break;
                case "√":
                    // Asegúrate de no calcular la raíz cuadrada de un número negativo
                    if (acumulado >= 0)
                        acumulado = Math.Sqrt(acumulado);
                    else
                    {
                        MessageBox.Show("Error: No es posible calcular la raíz cuadrada de un número negativo.", "Error de operación");
                        LimpiarCalculadora();
                        return;
                    }
                    break;
                case "%":
                    acumulado = acumulado * numero / 100;
                    break;
            }
            textBox1.Text = acumulado.ToString();

            // Agregar la operación al historial
            string operacionCompleta = acumuladoAntes + " " + operador + " " + numero + " = " + acumulado;
            historialOperaciones.Add(operacionCompleta);

            // Actualizar el historial en el ListBox
            ActualizarHistorial();
        }

        private void LimpiarCalculadora()
        {
            textBox1.Text = "0";
            acumulado = 0;
            operador = "";
            numeroActual = "";
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
        private void button24_Click(object sender, EventArgs e)
        {
            btnOperador_Click(sender, e);
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
            int selectedIndex = listBox2.SelectedIndex;

            // Asegurarse de que se haya seleccionado un elemento
            if (selectedIndex >= 0 && selectedIndex < valoresEnMemoria.Count)
            {
                // Obtener el valor seleccionado
                double valorSeleccionado = valoresEnMemoria[selectedIndex];

                // Verificar si hay un operador pendiente
                if (!string.IsNullOrEmpty(operador))
                {
                    // Si hay un número en el TextBox, realizar la operación pendiente antes de actualizar con el valor seleccionado
                    if (!string.IsNullOrEmpty(numeroActual))
                    {
                        double numero = double.Parse(numeroActual);
                        RealizarOperacion(numero);
                    }

                    // Mostrar el valor seleccionado y el operador en el TextBox
                    textBox1.Text = valorSeleccionado.ToString() + operador;

                    // Actualizar el número actual con el valor seleccionado
                    numeroActual = valorSeleccionado.ToString();
                }
                else
                {
                    // Si no hay operador pendiente, simplemente mostrar el valor seleccionado
                    textBox1.Text = valorSeleccionado.ToString();
                    numeroActual = valorSeleccionado.ToString();
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            btnOperador_Click(sender, e);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            btnOperador_Click(sender, e);
        }

        private void ActualizarHistorial()
        {
            listBox1.Items.Clear();
            foreach (string operacion in historialOperaciones)
            {
                listBox1.Items.Add(operacion);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            numeroActual = "";
            textBox1.Text = "0";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            LimpiarCalculadora();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(numeroActual))
            {
                // Eliminar el último carácter en la entrada actual
                numeroActual = numeroActual.Substring(0, numeroActual.Length - 1);

                // Actualizar el TextBox con la entrada actual modificada
                textBox1.Text = string.IsNullOrEmpty(numeroActual) ? "0" : numeroActual;
            }
            else if (!string.IsNullOrEmpty(operador))
            {
                // Si no hay caracteres en la entrada actual pero hay un operador, borrar el operador
                operador = "";

                // Mostrar el valor acumulado en el TextBox
                textBox1.Text = acumulado.ToString();
            }
        }

        private void CambiarSigno()
        {
            if (!string.IsNullOrEmpty(numeroActual))
            {
                // Cambiar el signo del número actual
                double numero = double.Parse(numeroActual);
                numero = -numero;
                numeroActual = numero.ToString();
                textBox1.Text = numeroActual;
            }
            else
            {
                // Cambiar el signo del acumulado
                acumulado = -acumulado;
                textBox1.Text = acumulado.ToString();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            CambiarSigno();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // Agregar el punto decimal solo si no se ha ingresado previamente
            if (!puntoDecimalIngresado)
            {
                // Si no hay número actual, agrega un cero antes del punto decimal
                if (string.IsNullOrEmpty(numeroActual))
                {
                    numeroActual = "0";
                }

                // Agregar el punto decimal al número actual
                numeroActual += ".";
                textBox1.Text = numeroActual;

                // Actualizar la variable de control
                puntoDecimalIngresado = true;
            }
        }
        private void mSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double valorActual = double.Parse(textBox1.Text);
            valoresEnMemoria.Add(valorActual);
            ActualizarValoresEnMemoria();
        }

        private void ActualizarValoresEnMemoria()
        {
            listBox2.Items.Clear();
            foreach (double valor in valoresEnMemoria)
            {
                listBox2.Items.Add(valor);
            }
        }

    }
}
