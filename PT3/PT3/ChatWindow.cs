using System;
namespace PT3
{
    public partial class ChatWindow : Gtk.Window
    {
        private string Username, Password, Interlocutor;
        private PT3.Database database;


        public ChatWindow(string _Username, string _Password, string _Interlocutor, PT3.Database _database) :
                base(Gtk.WindowType.Toplevel)
        {
            database = _database;
            Interlocutor = _Interlocutor;
            Password = _Password;
            Username = _Username;
            this.Build();
        }

        protected void LogoutButtonChatWindowClicked(object sender, EventArgs e)
        {
            MainWindow LogoutSucces = new MainWindow();
            LogoutSucces.Show();
            this.Hide();
            this.Dispose();

        }
        protected void BackToUserListClicked(object sender, EventArgs e)
        {   
            PT3.Userlist BackToUserList = new Userlist(Username,Password,database);
            BackToUserList.Show();
            this.Hide();
            this.Dispose();
        }

        protected void SendButtonClicked(object sender, EventArgs e)
        {
            string text = this.textview8.Buffer.Text;
            text = "Me @ " + DateTime.Now.ToString() + " >> " + text + "\n";
            this.textview7.Buffer.Text += text ;
            this.textview8.Buffer.Clear();
        }
    }
}
