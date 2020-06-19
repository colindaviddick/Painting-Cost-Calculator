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

namespace Painting_Cost_Calculator
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RunCalculation();
        }

        private void RunCalculation()
        {

            if (float.TryParse(InchesWidth.Text, out float width) && float.TryParse(InchesHeight.Text, out float height) && float.TryParse(Discount.Text, out float discountEntry))
            {
                float faces = 1;
                float medium = 0;
                float discountSum = 1;

                if (discountEntry != 0)
                {
                    discountSum = ((100 - discountEntry) / 100);
                }

                switch (Selected_Faces.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                        faces = 40f;
                        break;
                    case 2:
                        faces = 60f;
                        break;
                    case 3:
                        faces = 80f;
                        break;
                    case 4:
                        faces = 100f;
                        break;
                }
                switch (Selected_Medium.SelectedIndex)
                {
                    case 0: // Oil
                        medium = 1f;
                        break;
                    case 1: // Charcoal
                        medium = 0.4f;
                        break;
                    case 2: // Watercolour
                        medium = 0.7f;
                        break;
                    case 3: // Other
                        MessageBox.Show("This price is dependant on the medium and you will need to explain what you want to get an accurate price.");
                        medium = 1;
                        break;
                }
                TotalPrice.Text = ("£" + (((((width / 2) * (height / 2)) + faces) * medium) * discountSum).ToString());
            }
            else
            {
                MessageBox.Show("Can only accept numbers");
            }
        }

        private void InchesWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!float.TryParse(InchesWidth.Text, out float width))
            {
                InchesWidth.Background = Brushes.PaleVioletRed;
            }
            else
            {
                InchesWidth.Background = Brushes.PaleGreen;
            }
        }

        private void InchesHeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!float.TryParse(InchesHeight.Text, out float height))
            {
                InchesHeight.Background = Brushes.Red;
            }
            else
            {
                InchesHeight.Background = Brushes.PaleGreen;
            }
        }

        private void Discount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!float.TryParse(Discount.Text, out float discount))
            {
                Discount.Background = Brushes.Red;
            }
            else
            {
                Discount.Background = Brushes.PaleGreen;
            }
        }
    }
}
