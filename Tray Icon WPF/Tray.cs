using System.Windows.Forms;
using System;

public class Tray
{
    private NotifyIcon _notico;
    private bool _Animate = false;
    private ContextMenu _contextMenu = new ContextMenu();

    public Tray()
    {
        Initialize();
    }
    public Tray(System.Drawing.Icon pIcon)
    {
        Initialize();
        _notico.Icon = pIcon;
    }
    /// <summary>
    /// Initialisiert das NotifyIcon
    /// </summary>
    private void Initialize()
    {
        // NotifyIcon erzeugen
        _notico = new NotifyIcon();
        _notico.Visible = true;

        ContextMenu contextMenu = new ContextMenu();

        // Kontextmenüeinträge erzeugen

        _notico.ContextMenu = _contextMenu;

    }
    public void CreateMenuItem(String pName)
    {
        MenuItem menuItem = new MenuItem();
        menuItem = new MenuItem();
        menuItem.Index = 1;
        menuItem.Name = pName;
        menuItem.Text = "&" + menuItem.Name;

        _contextMenu.MenuItems.Add(menuItem);
    }
    public void CreateMenuItem(String pName, bool pTrue)
    {
        MenuItem menuItem = new MenuItem();
        menuItem.Index = 2;
        menuItem.Name = pName;
        menuItem.Text = "&" + menuItem.Name;
        menuItem.Click += (sender, e) =>
        {
            MenuItem m = (MenuItem)sender;
            m.Checked = !m.Checked;
        };
        menuItem.Checked = pTrue;

        _contextMenu.MenuItems.Add(menuItem);
    }
    public NotifyIcon NotifyIcon
    {
        get
        {
            return _notico;
        }
    }
}