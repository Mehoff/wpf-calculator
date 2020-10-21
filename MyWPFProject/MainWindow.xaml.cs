using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            string left = string.Empty;
            string right = string.Empty;
            char dowhat = ' ';

            foreach (char symbol in inputString)
            {
                
                try
                {
                    int value = int.Parse(symbol.ToString());
                    if (isLeft) left += symbol;
                    else right += symbol;
                }
                catch
                {
                    // Второе действие
                    if (dowhat != ' ')
                    {
                        left = GetVal(int.Parse(left), int.Parse(right), dowhat);
                        right = string.Empty;
                    }
                    // Первое действие
                    else
                    {
                        dowhat = symbol;
                        isLeft = false;
                    }
                }

            }

            int left_value = 0;
            int right_value = 0;

            try
            {
                left_value = int.Parse(left);
                right_value = int.Parse(right);
            }
            catch
            {
                MessageBox.Show("Некорректный ввод");
                return null;
            }

            Clear();
            return GetVal(left_value, right_value, dowhat);


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

                case "equalsBtn": { return Calculate(); }
                case "plusBtn": return "+";
                case "minusBtn": return "-";
                case "multiplyBtn": return "*";
                case "divideBtn": return "/";

                case "deleteBtn": { var cpy = inputString; Clear();  return cpy.Remove(cpy.Length - 1, 1); }
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
