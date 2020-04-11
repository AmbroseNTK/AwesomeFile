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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AwesomeFile.Controls
{
    public delegate void CheckboxHandler(FluentCheckBox sender, bool isChecked);
    /// <summary>
    /// Interaction logic for FluentCheckBox.xaml
    /// </summary>
    public partial class FluentCheckBox : UserControl
    {
        Storyboard animCheck;
        Storyboard animUncheck;
        public event CheckboxHandler CheckChanged;
        public static readonly DependencyProperty IsCheckProperty =
        DependencyProperty.Register("IsCheck", typeof(bool),
                                    typeof(FluentCheckBox),
                                    new PropertyMetadata(false));

        private bool isChecked;
        public bool IsChecked
        {
            get => (bool)(GetValue(IsCheckProperty));
            set
            {
                isChecked = value;
                CheckChanged?.Invoke(this, isChecked);
                SetValue(IsCheckProperty, isChecked);
                if (isChecked)
                {
                    animCheck.Begin();
                }
                else
                {
                    animUncheck.Begin();
                }
            }
        }
        public FluentCheckBox()
        {
            InitializeComponent();
            animCheck = FindResource("AnimCheck") as Storyboard;
            animUncheck = FindResource("AnimUncheck") as Storyboard;
            mainGrid.MouseDown += MainEllipse_MouseDown;
            
        }

        private void MainEllipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isChecked = !isChecked;
            CheckChanged?.Invoke(this,isChecked);
            if (isChecked)
            {
                animCheck.Begin();
            }
            else
            {
                animUncheck.Begin();
            }
        }
    }
}
