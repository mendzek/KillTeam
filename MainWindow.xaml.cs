using System.Windows;

namespace Kill_Team
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





        void Exit_Button(object sender, RoutedEventArgs e) { Close(); Naming_List naming_list = new(); naming_list.Close(); }

        void Create_KT_List(object sender, RoutedEventArgs e)
        {
            Naming_List naming_list = new();
            naming_list.Show();


        }
        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            List list = new();
            Naming_List naming_list = new();
            Open_KillTeam_List op_KT_list = new();
            //MainWindow mainWindow = new();
            e.Cancel = true;
            naming_list.Close();
            list.Close();
            op_KT_list.Close();
            Close();
        }

        private void Open_KillTeam_Click(object sender, RoutedEventArgs e)
        {
            Open_KillTeam_List op_KT_list = new();
            op_KT_list.Show();


        }
    }
}
