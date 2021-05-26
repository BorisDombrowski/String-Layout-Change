using String_Layout_Change.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace String_Layout_Change
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Context());
        }
    }

    public class Context : ApplicationContext
    {
        private NotifyIcon trayIcon;

        public Context()
        {
            trayIcon = new NotifyIcon()
            {
                Icon = Resources.AppIcon,
                ContextMenu = new ContextMenu(new MenuItem[] 
                {
                    new MenuItem("Settings", OpenSettings),
                    new MenuItem("Exit", Exit)                    
                }),
                Visible = true
            };
        }

        void OpenSettings(object sender, EventArgs e)
        {
            SettingsForm.Instance.ShowDialog();
        }

        void Exit(object sender, EventArgs e)
        {            
            trayIcon.Visible = false;
            Application.Exit();
        }
    }
}
