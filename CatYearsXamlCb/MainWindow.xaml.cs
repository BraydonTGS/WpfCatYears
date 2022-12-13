using System;
using System.Collections.Generic;
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

namespace CatYearsXamlCb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InputCatAge_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                try
                {
                    int inputCatAge = Int32.Parse(InputCatAge.Text);
                    string resultHumanAge = "";

                    if (inputCatAge >= 0 && inputCatAge <= 1)
                    {
                        resultHumanAge = "0-15";
                        ResultTextBlock.Text = $"Your cat is {resultHumanAge} years old";
                    }
                    else if (inputCatAge >= 2 && inputCatAge < 25)
                    {
                        resultHumanAge = (((inputCatAge - 2) * 4) + 24).ToString();
                        ResultTextBlock.Text = $"Your cat is {resultHumanAge} years old";
                    }
                    else
                    {
                        ResultTextBlock.Text = $"Your Cat is Super Old!!!";
                    }

                }
                catch(Exception exc)
                {
                    MessageBox.Show("Not a valid number, please enter a numeric value! " + exc.Message); 
                }
            }
        }
    }
}
