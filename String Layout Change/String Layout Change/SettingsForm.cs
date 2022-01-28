using String_Layout_Change.Properties;
using System.IO;
using System.Windows.Forms;

namespace String_Layout_Change
{
    public partial class SettingsForm : Form
    {
        private static SettingsForm instance = null;
        public static SettingsForm Instance 
        { 
            get
            {
                if(instance == null)
                {
                    instance = new SettingsForm();
                }
                return instance;
            }
        }
        private FileInfo[] layoutFiles;

        private SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Shown(object sender, System.EventArgs e)
        {            
            DirectoryInfo dir = new DirectoryInfo(@"Layouts/");
            var layf = dir.GetFiles("*.layout");

            if (!layf.Equals(layoutFiles))
            {
                layoutFiles = layf;
                comboBox1.Items.Clear();
                foreach (var info in layoutFiles)
                {
                    comboBox1.Items.Add(info.Name);
                }
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var path = @"Layouts\" + comboBox1.SelectedItem.ToString();
            File.WriteAllText(Resources.settingsPath, path);
            LayoutChanger.SetCurrentLayout(path);
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Visible = false;
        }
    }
}
