using System.Windows.Controls;

namespace Diploma.Services
{
    public class Checks
    {
        public Checks() { }

        public bool IsTextBoxEmpty(TextBox textBox)
        {
            return !string.IsNullOrEmpty(textBox.Text.ToString());
        }
    }
}
