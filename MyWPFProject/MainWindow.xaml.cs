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
        public string inputString { get; set; } = "0";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Calculate()
        {

        }
        private string GetSymbol(Button btn)
        {
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
                default: return string.Empty;
            }
        }
        private void btnClick(object sender, RoutedEventArgs e)
        {
            var btn = e.Source as Button;
            MessageBox.Show(GetSymbol(btn));
            inputString.Insert(0, GetSymbol(btn));
            MainTextBlock.Text = inputString;
        }
    }
}
