using System.Windows;
using System.Windows.Input;

namespace Account_Tool_2._1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string StoredPassword = "Password";
            if (StoredPassword == Password.Password)
            {
                MainWindow window = new MainWindow();
                window.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please try again");
            }
        }

        private void Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string StoredPassword = "xxx";
                if (StoredPassword == Password.Password)
                {
                    MainWindow window = new MainWindow();
                    window.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please try again");
                }
            }
        }
    }
}
