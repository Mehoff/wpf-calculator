using System;
using System.Windows;
using System.Windows.Controls;


namespace MyWPFProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string inputString { get; set; } = "0";
        private string storedValue { get; set; } = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        private string GetVal(int left_value, int right_value, char doWhat)
        {
            try
            {
                switch (doWhat)
                {
                    case '+': return (left_value + right_value).ToString();
                    case '-': return (left_value - right_value).ToString();
                    case '/': return (left_value / right_value).ToString();
                    case '*': return (left_value * right_value).ToString();

                    default: throw new Exception($"Unexpected dowhat ex: {doWhat}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private string Calculate() 
        {
            bool isLeft = true;
            char operand = ' ';
            string leftValue = string.Empty;
            string rightValue = string.Empty;
            string answer = string.Empty;

            foreach (char c in inputString) 
            {
                if (char.IsDigit(c)) 
                {
                    if (isLeft)
                        leftValue += c;
                    else rightValue += c;
                }
                else 
                {
                    // Если это не число - значит это операнд
                    if (operand != ' ')
                    {
                        try
                        {
                            // Если мы встретили еще один операнд, значит что пора посчитать левую часть
                            leftValue = GetVal(int.Parse(leftValue), int.Parse(rightValue), operand);
                            rightValue = string.Empty;
                        }
                        catch 
                        {
                            MessageBox.Show("Некорректный ввод");
                            return null;
                        }
                        operand = c;
                    }
                    else
                    {
                        operand = c;
                        isLeft = false;
                    }
                }
            }
            try
            {
                answer = GetVal(int.Parse(leftValue), int.Parse(rightValue), operand);
            }
            catch 
            {
                MessageBox.Show("Некорректный ввод");
                return null;
            }
            Clear();
            return answer; 
        }

        private void Clear()
        {
            inputString = string.Empty;
        }
        private string GetSymbol(Button btn)
        {
            if (inputString == "0")
                inputString = string.Empty;


                switch (btn.Name)
            {
                case "oneBtn": return "1";
                case "twoBtn": return "2";                    
                case "threeBtn": return "3";                    
                case "fourBtn": return "4";                    
                case "fiveBtn": return "5";                    
                case "sixBtn": return "6";                    
                case "sevenBtn": return "7";                    
                case "eightBtn": return "8";                    
                case "nineBtn": return "9";                    
                case "zeroBtn": return "0";
                case "equalsBtn": return Calculate();
                case "plusBtn": return "+";
                case "minusBtn": return "-";
                case "multiplyBtn": return "*";
                case "divideBtn": return "/";

                case "deleteBtn":
                    {
                        try
                        {
                            var cpy = inputString;
                            Clear();
                            return cpy.Remove(cpy.Length - 1, 1);
                        }
                        catch { return null; }
                    }
                case "clearAllBtn": { Clear(); return "0"; }

                case "memoryRecall": { return storedValue; }
                case "memoryStore": { storedValue = inputString; return null; }

                default: return null;
            }
        }
        private void btnClick(object sender, RoutedEventArgs e)
        {
            var btn = e.Source as Button;
            var symbol = GetSymbol(btn);
            inputString += symbol;
            InputLabel.Text = inputString;
        }
    }
}
