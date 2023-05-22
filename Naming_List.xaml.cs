using System.IO;
using System.Windows;

namespace Kill_Team
{
    /// <summary>
    /// Логика взаимодействия для Naming_List.xaml
    /// </summary>
    public partial class Naming_List : Window
    {


        public Naming_List()
        {
            InitializeComponent();
        }

        public static string file_Path;

        void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
        public void Create_list(object sender, RoutedEventArgs e)
        {

            string text_from_TextBox = Text_Box.Text;
            if (text_from_TextBox == "")
            {
                MessageBox.Show("There is nothing");
            }
            else
            {
                text_from_TextBox = Text_Box.Text;

                File.Create($"D:\\Visual studio\\C#\\Kill Team\\Kill Team\\KT_Lists\\{text_from_TextBox}.txt");
                file_Path = $"D:\\Visual studio\\C#\\Kill Team\\Kill Team\\KT_Lists\\{text_from_TextBox}.txt";
                List.source = "namingList";
                List list = new();
                MainWindow main_window = new();

                main_window.Hide();
                list.Show();
                Close();
            }
        }
        void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

    }
}
