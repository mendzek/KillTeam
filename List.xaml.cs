using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Kill_Team
{
    public partial class List : Window
    {

        public List()
        {
            InitializeComponent();
            DataContext = this;
            Loaded += for_textBox_TacOps;
            Loaded += for_textBox_Equipment;
            Loaded += for_textBox_Other;
            Loaded += for_textBox_Active;
            NameOfKT.Text = Open_KillTeam_List.filePathForTextBox.Remove(0, directory + 9);
        }

        public ObservableCollection<string> Collection_For_TextBox { get; } = new();
        //public string? text = Open_KillTeam_List.file_text;
        public string textFromTextBox;
        public static string source;
        static int directory = Open_KillTeam_List.file_Path.IndexOf("KT_Lists");




        private void On_Main_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main_window = new();
            main_window.Activate();
            Hide();
        }
        void for_textBox_TacOps(object sender, RoutedEventArgs e)
        {
            if (source == "namingList") Open_KillTeam_List.tacOpsLine = null;           
            TacOps.Text = Open_KillTeam_List.tacOpsLine;
            TacOps.Text += Open_KillTeam_List.tacOpsContent;
        }
        void for_textBox_Equipment(object sender, RoutedEventArgs e)
        {
            if (source == "namingList") Open_KillTeam_List.equipLine = null;           
            Equipment.Text = Open_KillTeam_List.equipLine;
        }
        void for_textBox_Other(object sender, RoutedEventArgs e)
        {
            if (source == "namingList") Open_KillTeam_List.otherLine = null;           
            Other.Text = Open_KillTeam_List.otherLine;
        }
        void for_textBox_Active(object sender, RoutedEventArgs e)
        {
            if (source == "namingList") Open_KillTeam_List.activeLine = null;           
            Active.Text = Open_KillTeam_List.activeLine;
        }
        public void Save_Click(object sender, RoutedEventArgs e)
        {
            if (source == "namingList")
            {
                StreamWriter? streamWriter = new(Naming_List.file_Path, false);
                streamWriter.WriteLine(TacOps.Text);
                streamWriter.WriteLine(Equipment.Text);
                streamWriter.WriteLine(Other.Text);
                streamWriter.WriteLine(Active.Text);
                Open_KillTeam_List.tacOpsLine = null;
                streamWriter.Close();
                streamWriter = null;
            }
            if (source == "opKTlist")
            {
                StreamWriter? streamWriter = new(Open_KillTeam_List.filePathForTextBox, false);
                streamWriter.WriteLine(TacOps.Text);
                streamWriter.WriteLine(Equipment.Text);
                streamWriter.WriteLine(Other.Text);
                streamWriter.WriteLine(Active.Text);
                Open_KillTeam_List.tacOpsLine = null;
                streamWriter.Close();
                streamWriter = null;
            }
        }

    }
}
