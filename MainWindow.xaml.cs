using CalculadoraProgramacion.Clases;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculadoraProgramacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClsCalculator Calculator = null;

        private List<string> CharsList = null;
        private bool ButtonEqualsClicked { get; set; }
        private bool IsCurrentResult { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Calculator = new ClsCalculator();

            CharsList = new List<string> { "0" };

            ButtonEqualsClicked = false;

            IsCurrentResult = false;
        }

        private bool LastCharIsAOperator()
        {
            return Calculator.Operators.Contains(CharsList.Last());
        }

        private void SetValueToTextBlock(string value)
        {
            if(ButtonEqualsClicked)
            {
                txbHistory.Text = string.Empty;

                ButtonEqualsClicked = false;
            }

            if (IsCurrentResult)
            {
                txbResultado.Text = string.Empty;

                IsCurrentResult = false;
            }

            if(txbResultado.Text == "0")
            {
                txbResultado.Text = value;
            }
            else
            {
                txbResultado.Text += value;
            }

            CharsList.Add(value);
        }

        private void ExecuteOperation(string pOperator)
        {
            if (LastCharIsAOperator())
            {
                txbResultado.Text = "Syntax Error";

                txbHistory.Text = string.Empty;

                Calculator.Reset();

                return;
            }
            else
            {
                if (!Calculator.IsFirstOperator)
                {
                    Calculator.SetValue(double.Parse(txbResultado.Text, CultureInfo.InvariantCulture.NumberFormat));
                    
                    Calculator.ExecuteOperation();

                    Calculator.Operator = pOperator;
                }
                else
                {
                    Calculator.Operator = pOperator;

                    Calculator.SetValue(double.Parse(txbResultado.Text, CultureInfo.InvariantCulture.NumberFormat));

                    Calculator.ExecuteOperation();
                }
            }

            CharsList.Add(pOperator);

            if (ButtonEqualsClicked)
            {
                txbHistory.Text = string.Empty;

                ButtonEqualsClicked = false;
            }

            txbHistory.Text += $"{txbResultado.Text}{pOperator}";

            txbResultado.Text = Convert.ToString(Calculator.Result);

            IsCurrentResult = true;
        }

        private void btnIgual_Click(object sender, RoutedEventArgs e)
        {
            Calculator.SetValue(double.Parse(txbResultado.Text, CultureInfo.InvariantCulture.NumberFormat));

            Calculator.ExecuteOperation();

            txbHistory.Text += $"{txbResultado.Text}=";

            txbResultado.Text = Convert.ToString(Calculator.Result);

            Calculator.Reset();

            IsCurrentResult = true;

            ButtonEqualsClicked = true;
        }

        private void btnMas_Click(object sender, RoutedEventArgs e)
        {
            ExecuteOperation("+");
        }

        private void btnMenos_Click(object sender, RoutedEventArgs e)
        {
            ExecuteOperation("-");
        }

        private void btnDivision_Click(object sender, RoutedEventArgs e)
        {
            ExecuteOperation("÷");
        }

        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {
            ExecuteOperation("×");
        }

        private void btnPunto_Click(object sender, RoutedEventArgs e)
        {
            SetValueToTextBlock(".");
        }

        private void btnCero_Click(object sender, RoutedEventArgs e)
        {
            SetValueToTextBlock("0");
        }

        private void btnUno_Click(object sender, RoutedEventArgs e)
        {
            SetValueToTextBlock("1");
        }

        private void btnDos_Click(object sender, RoutedEventArgs e)
        {
            SetValueToTextBlock("2");
        }

        private void btnTres_Click(object sender, RoutedEventArgs e)
        {
            SetValueToTextBlock("3");
        }

        private void btnCuatro_Click(object sender, RoutedEventArgs e)
        {
            SetValueToTextBlock("4");
        }

        private void btnCinco_Click(object sender, RoutedEventArgs e)
        {
            SetValueToTextBlock("5");
        }

        private void btnSeis_Click(object sender, RoutedEventArgs e)
        {
            SetValueToTextBlock("6");
        }

        private void btnSiete_Click(object sender, RoutedEventArgs e)
        {
            SetValueToTextBlock("7");
        }

        private void btnOcho_Click(object sender, RoutedEventArgs e)
        {
            SetValueToTextBlock("8");
        }

        private void btnNueve_Click(object sender, RoutedEventArgs e)
        {
            SetValueToTextBlock("9");
        }

        private void btnDEL_Click(object sender, RoutedEventArgs e)
        {
            int txbLength = txbResultado.Text.Length;

            if(txbLength > 1)
            {
                txbResultado.Text = txbResultado.Text.Remove(txbLength - 1, 1);
            }
            else
            {
                txbResultado.Text = "0";
            }
        }

        private void btnAC_Click(object sender, RoutedEventArgs e)
        {
            txbResultado.Text = "0";

            Calculator.Reset();

            txbHistory.Text = string.Empty;
        }
    }
}
