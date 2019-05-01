using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Drawing;

namespace Tray_Icon_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            //Icon laden
            //Achtung Pfad zum Icon anpassen!!!!
            Icon icon = Icon.ExtractAssociatedIcon(@"C:\Users\martin\Documents\Visual Studio 2008\Blog\Tray Icon WPF\Tray Icon WPF\Icon1.ico"); 

            //trayicon erstellen und icon laden
            Tray tray = new Tray(icon);

            tray.CreateMenuItem("Fenster aufrufen");
            tray.CreateMenuItem("Beenden");

            //Menuitem Fenster aufrufen suchen, zugreifen Click Event anmelden und delegate setzen
            tray.NotifyIcon.ContextMenu.MenuItems.Find("Fenster aufrufen", true).First().Click += (sender, eargs) =>
            {
                Window1 window = new Window1();
                window.Show();

            };

            //Menuitem Beenden suchen, zugreifen Click Event anmelden und delegate setzen
            tray.NotifyIcon.ContextMenu.MenuItems.Find("Beenden", true).First().Click += (sender, eargs) =>
            {
                //Icon aus tray löschen
                tray.NotifyIcon.Dispose();
                Environment.Exit(0);
            };


            base.OnStartup(e);
        }
    }
}
