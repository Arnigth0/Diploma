using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
