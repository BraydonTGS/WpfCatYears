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

        public TextBlock ResultTextBlock;
        public TextBox InputCatAge;
        public TextBlock UserQuestion; 
        public MainWindow()
        {
            InitializeComponent();

            // Set up our UI in the Main Window CTOR // 

            // Created a new BackGround Image //
            Image backgroundImage = new Image()
            {
                Source = new BitmapImage(
                new Uri(Environment.CurrentDirectory + @"\..\..\Images\cats.jpg", UriKind.RelativeOrAbsolute))
            };

            // Creating a Text Block and a Text Box //
            ResultTextBlock = new TextBlock() { Text = "Your cat is ", FontSize = 18 };

            InputCatAge = new TextBox()
            {
                Width = 120,
                TextAlignment = TextAlignment.Center,
                FontSize = 18,
                Margin = new Thickness(5, 0, 0, 0)
            };

            InputCatAge.KeyDown += InputCatAge_KeyDown;

            // New Text Block for User Input //
            UserQuestion = new TextBlock() { Text = "How old is your cat? ", FontSize = 18 };

            StackPanel HorizontalStackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(1, 5, 0, 0)
            }; 

            // These will now be inside the HorizonalStackPanel //
            HorizontalStackPanel.Children.Add(UserQuestion);
            HorizontalStackPanel.Children.Add(InputCatAge);

            // Creating a New Stack Pannel //
            StackPanel MainVerticalStackPanel = new StackPanel();
            MainVerticalStackPanel.Children.Add(HorizontalStackPanel);
            MainVerticalStackPanel.Children.Add(ResultTextBlock);
            MainVerticalStackPanel.Children.Add(backgroundImage);


            MyMainWindow.Content = MainVerticalStackPanel;
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
