using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kill_Team
{
    /// <summary>
    /// Логика взаимодействия для Open_KillTeam_List.xaml
    /// </summary>
    public partial class Open_KillTeam_List : Window
    {
        public int current_file { get; set; }
        int i = 0;
        public static string? file_text { get; set; }
        List<string> files = new List<string>();
        OpenFileDialog ofd = new();
        Button button = new();
        Border border = new();
        public ObservableCollection<object> Items { get; } = new();
        public static string file_Path = "D:\\Visual studio\\C#\\Kill Team\\Kill Team\\KT_Lists";
        public static string? filePathForTextBox;
        public static string? tacOpsLine;
        public static string? equipLine;
        public static string? otherLine;
        public static string? activeLine;
        public static string? tacOpsContent;
        public static string? equipContent;
        public static string? otherContent;
        public static string? activeContent;
        int first;
        int lust;


        public Open_KillTeam_List()
        {
            InitializeComponent();
            DataContext = this;
            Loaded += Op_KT_list_loaded;

        }


        void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
        void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
        public void Op_KT_list_loaded(object sender, RoutedEventArgs e)
        {
            int directory = file_Path.IndexOf("KT_Lists");
            Range range = 0..directory;




            foreach (string file_name in Directory.GetFiles(file_Path))
            {
                button.Content = file_name.Remove(0, directory + 9);
                button.Uid = Convert.ToString(i);
                i++;
                files.Add(file_name);
                Items.Add(button.Content);
            }
            // 32 символа нужно убрать
        }
        
        void Item_Button_Click(object sender, RoutedEventArgs e)
        {
            //Button btn = (Button)sender;
            //MessageBox.Show((string)btn.DataContext);
            //current_file = sender.;
            string senderString = Convert.ToString(sender);
            senderString = senderString.Remove(0, 32);
            filePathForTextBox = file_Path + "\\" + senderString;
            StreamReader? streamReader = new(file_Path + "\\" + senderString, false);
            tacOpsLine = streamReader.ReadLine();
            CheckIfLineHaveAndOfLine(tacOpsLine);               //line почему то null
            equipLine = streamReader.ReadLine();
            CheckIfLineHaveAndOfLine(equipLine);
            otherLine = streamReader.ReadLine();
            CheckIfLineHaveAndOfLine(otherLine);
            activeLine = streamReader.ReadLine();
            CheckIfLineHaveAndOfLine(activeLine);
            tacOpsContent = streamReader.ReadLine();
            CheckIfLineHaveAndOfLine(tacOpsContent);
            equipContent = streamReader.ReadLine();
            CheckIfLineHaveAndOfLine(equipContent);
            otherContent = streamReader.ReadLine();
            CheckIfLineHaveAndOfLine(otherContent);
            activeContent = streamReader.ReadLine();
            CheckIfLineHaveAndOfLine(activeContent);

            //file_text = File.ReadAllText(file_Path + "\\" + senderString); //"D:\Visual studio\C#\Kill Team\Kill Team\KT_Lists\Tau Pathfinders.txt"
            List.source = "opKTlist";
            List list = new();
            MainWindow main_window = new();
            main_window.Hide();
            list.Show();
            Close();
        }

        private void Open_Explorer_Click(object sender, RoutedEventArgs e)
        {
            ofd.ShowDialog();
            string senderString = ofd.FileName;
            filePathForTextBox = file_Path + "\\" + senderString;
            file_text = File.ReadAllText(senderString); //"D:\Visual studio\C#\Kill Team\Kill Team\KT_Lists\Tau Pathfinders.txt" <-- Пример пути
            List.source = "opKTlist";
            List list = new();
            MainWindow main_window = new();
            main_window.Hide();
            list.Show();
            Close();
        }
        private void CheckIfLineHaveAndOfLine(string? line)                  //line почему то null
        {
            if (line.Contains("^and^"))
            {
                Range range = first..lust;
                line.Replace("^and^", "\n");
            }
        }

    }
}
