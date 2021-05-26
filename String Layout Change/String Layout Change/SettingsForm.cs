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

        private SettingsForm()
        {
            InitializeComponent();
        }
    }
}
