using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalcWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _inputValue = "0";
        private double _result;
        private double _previousNumber = 0.0f;
        private Operations _operation = Operations.None;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            _inputValue = ((Button)sender).Content.ToString();
            UpdateUI();
        }

        private void UpdateUI()
        {
            if(_inputValue.Equals(".") && !resultLabel.Content.ToString().Contains('.'))
            {
                resultLabel.Content += _inputValue;
                return;
            }
            if (resultLabel.Content.ToString().Equals("0"))
            {
                resultLabel.Content = _inputValue;
            }
            else if(!_inputValue.Equals("."))
            {
                resultLabel.Content += _inputValue;
            }
        }

        private void UpdateUI(string value)
        {
            resultLabel.Content = value;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            var operation = ((Button)sender).Content.ToString();
            switch (operation)
            {
                case "C":
                    DeleteLastContent();
                    break;
                case "+/-":
                    SwitchSign();
                    break;
                case "+":
                    _operation = Operations.Add;
                    ChangePreviousNumber();
                    break;
                case "/":
                    _operation = Operations.Divide;
                    ChangePreviousNumber();
                    break;
                case "=":
                    Calculate();
                    break;
                case "-":
                    _operation = Operations.Subtract;
                    ChangePreviousNumber();
                    break;
                case "%":
                    _operation = Operations.Percent;
                    ChangePreviousNumber();
                    break;
                case "X":
                    _operation = Operations.Multiply;
                    ChangePreviousNumber();
                    break;
            }
        }

        private void ChangePreviousNumber()
        {
            _previousNumber = Convert.ToDouble(resultLabel.Content);
            resultLabel.Content = "0";
        }

        private void Calculate()
        {
            switch (_operation)
            {
                case Operations.None:
                    break;
                case Operations.Add:
                    var currentNumber = Convert.ToDouble(resultLabel.Content);
                    var result = MathOperations.Sum(_previousNumber, currentNumber);
                    UpdateUI(result);
                    break;
                case Operations.Divide:
                    var current = Convert.ToDouble(resultLabel.Content);
                    if (current == 0)
                    {
                        UpdateUI("Ошибка"); 
                    }
                    else
                    {
                        var res = MathOperations.Divide(_previousNumber, current);
                        UpdateUI(res);
                    }
                    break;
                case Operations.Multiply:
                    currentNumber = Convert.ToDouble(resultLabel.Content);
                    result = MathOperations.Multiply(_previousNumber, currentNumber);
                    UpdateUI(result);
                    break;
                case Operations.Subtract:
                    currentNumber = Convert.ToDouble(resultLabel.Content);
                    result = MathOperations.Subtract(_previousNumber, currentNumber);
                    UpdateUI(result);
                    break;
                case Operations.Percent:
                    currentNumber = Convert.ToDouble(resultLabel.Content);
                    result = MathOperations.Percent(_previousNumber, currentNumber);
                    UpdateUI(result);
                    break;
            }
        }

        private void SwitchSign()
        {
            double number = Convert.ToDouble(resultLabel.Content.ToString());
            number *= -1;
            resultLabel.Content = number.ToString();
        }

        private void DeleteLastContent()
        {
            _inputValue = "0";
            _previousNumber = 0.0f;
            _operation = Operations.None;
            resultLabel.Content = _inputValue;  
        }
    }
}
    

