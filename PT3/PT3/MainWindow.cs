using System;
using Gtk;
public partial class MainWindow : Gtk.Window
{
    
    private string username, password;
    private PT3.Userlist Loginsucces;
    private PT3.Database databaseFunc = new PT3.Database("test.db");

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnLoginRegisterButtonClicked(object sender, EventArgs e)
    {
        Console.WriteLine("testasdf");
        //databaseFunc.Register("test1", "test2");
        Console.WriteLine(databaseFunc.CheckUsername(Username.Text)); 
        Console.WriteLine(databaseFunc.CheckPassword(Username.Text, Password.Text));

        if (databaseFunc.CheckUsername(Username.Text)==true && !databaseFunc.CheckPassword(Username.Text, Password.Text) )// TODO :(Als Wachtwoord fout) 
        {
            MessageDialog dialog = new MessageDialog(
                this,
                DialogFlags.Modal,
                MessageType.Info,
                ButtonsType.Ok,
                Username.Text + " is al in gebruik, of wachtwoord is fout"
            );
            dialog.Run();
            dialog.Destroy();
        }
        else
        {

            //database.CreateDatabase();
            // Console.WriteLine("testasdf");
            username = Username.Text;
            password = Password.Text;
            this.Hide();
            Loginsucces = new PT3.Userlist(username, password,databaseFunc);
            //Loginsucces.Show();
            Console.WriteLine("checkusername is ");
            Console.WriteLine(databaseFunc.CheckUsername(username));
            if (!databaseFunc.CheckUsername(username))
                databaseFunc.Register(username,password);
            Console.WriteLine(databaseFunc.CheckPassword(username,password));
            databaseFunc.switchOnlinestatus(username,true);//zet online

            this.Dispose();
        }

    }
}
