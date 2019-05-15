using System;
using Gtk;

namespace PT3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
               
            MainWindow win = new MainWindow();
            //win.Show();
            Application.Run();
          
            //Application.Init();
            //Console.WriteLine("hallo2");
            //Userlist win2 = new Userlist();
            //win2.Show();  
            //Application.Run();

        }
    }
}
