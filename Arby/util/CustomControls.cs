using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Arby.util
{
    class SettingsTextBox : FlowLayoutPanel
    {
        public Label SettingsLabel;
        public TextBox SettingsBox;

        public SettingsTextBox() : base()
        {
            AutoSize = true;

            SettingsLabel = new Label();
            SettingsLabel.AutoSize = true;
            SettingsLabel.Anchor = AnchorStyles.Left;
            SettingsLabel.TextAlign = ContentAlignment.MiddleLeft;
            Controls.Add(SettingsLabel);

            SettingsBox = new TextBox();
            Controls.Add(SettingsBox);
        }
    }
}
