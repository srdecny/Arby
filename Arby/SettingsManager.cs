using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Arby.dataclass;
using Arby.util;

namespace Arby
{
    public partial class SettingsManager : Form
    {
        public SettingsData SettingsData;
        public SettingsManager(SettingsData Data)
        {
            InitializeComponent();
            SettingsData = Data;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            PopulateSettingsBox();
        }

        private void PopulateSettingsBox()
        {
            SettingsLayoutPanel.Controls.Clear();
            SettingsLayoutPanel.FlowDirection = FlowDirection.TopDown;
            foreach (var Setting in SettingsData.GetType().GetProperties())
            {
                SettingsTextBox Box = new SettingsTextBox();
            
                var Tooltip = Setting.GetValue(SettingsData);
                Box.SettingsLabel.Text = Tooltip.GetType().GetProperty("Description").GetValue(Tooltip).ToString();
                Box.SettingsBox.Name = Setting.Name;
                Box.SettingsBox.Text = Tooltip.GetType().GetProperty("Value").GetValue(Tooltip).ToString();
                SettingsLayoutPanel.Controls.Add(Box);
            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveSettings()
        {
            SettingsData NewSettings = SettingsHelper.GetDefaultSettingsData(); // reuse the description fields again, since they don't change, and just overwrite the values
            string SettingsName = ""; // ArgumentException doesn't contain info about what setting threw it

            try
            {
                foreach (SettingsTextBox Setting in SettingsLayoutPanel.Controls)
                {
                   // Convert the settings new field value to the respective type T
                    string TextBoxName = Setting.SettingsBox.Name;
                    var SettingsPropertyType = NewSettings.GetType().GetProperty(TextBoxName).GetValue(SettingsData).GetType().GetTypeInfo().GenericTypeArguments[0];
                    var ConvertedValue = Convert.ChangeType(Setting.SettingsBox.Text, SettingsPropertyType);
                    var ValueProperty = NewSettings.GetType().GetProperty(TextBoxName).GetValue(NewSettings).GetType().GetProperty("Value");
                    ValueProperty.SetValue(NewSettings.GetType().GetProperty(TextBoxName).GetValue(NewSettings), ConvertedValue);
                }
                SettingsData = NewSettings;

            }
            catch (FormatException ex)
            {
                GUIHelper.ThrowWarning("Invalid field value", "Invalid value was set for setting " + SettingsName);
            }

        }
    }
}
