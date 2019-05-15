using System;
namespace PT3.Properties
{
    public partial class chatscreen : Gtk.Window
    {
        public chatscreen(string username, string interlocutor) :
                base(Gtk.WindowType.Toplevel)
        {
            
            this.Build();
        }
    }
}
