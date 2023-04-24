using Diploma.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Diploma.ViewModels
{
    public partial class MainViewModel : Window
    {
        public ObservableCollection<ClientForShow> ClientsForShow { get; set; }

    }
}
