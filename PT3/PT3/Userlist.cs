using System;
using System.Data;
using Gtk;
using System.Collections.Generic;
using System.Windows;

namespace PT3
{
    public partial class Userlist : Gtk.Window
    {
        //haal alle naam en bericht van alle online members op
        //en zet ze in Listentries. Zet aantal online vrienden in aantalonline
        private string Username, Password;
        private PT3.Database database;
        public static int aantalonline; //TODO: ophalen uit database
        List<string> onlinemembers = new List<string>();

        private void update()
        {   
            onlinemembers = database.ReturnOnlineUsernames();
            aantalonline = onlinemembers.Count;
            Console.WriteLine(aantalonline);
            Button button = new Button();
            for (int i = 0; i < aantalonline; i++)
            {
                Console.WriteLine(i + " daf ");
                button.Name = onlinemembers[i];
                button.Show();
            }

            //System.Threading.Thread.Sleep(5000);
        }
        public Userlist(string _Username, string _Password, PT3.Database _database) :
                base(Gtk.WindowType.Toplevel)
        {
            database = _database;
            Password = _Password;
            Username = _Username;
            //  update(); //TODO: 
            Console.WriteLine("in constructor van userlist");
            this.Build();

        }

        protected void LogoutButtonUserlistClicked(object sender, EventArgs e)
        {
            MainWindow LogoutSucces = new MainWindow();
            LogoutSucces.Show();
            this.Hide();
            this.Dispose();

        }

        protected void ChatButtonClicked(object sender, EventArgs e)
        {
            PT3.ChatWindow chatwindow = new ChatWindow(Username,Password,"interlucotor",database);
            chatwindow.Show();
            this.Hide();
        }
    }
  
}