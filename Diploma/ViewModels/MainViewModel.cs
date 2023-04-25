using Diploma.Models;
using Diploma.Repositories;
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
    public partial class MainViewModel
    {
        private readonly ClientForShowRepository _clientForShowRepository;
        public ObservableCollection<ClientForShow> clientsForShow { get; set; } = new ObservableCollection<ClientForShow>();
        

        public MainViewModel(ClientForShowRepository clientForShowRepository)
        {
            _clientForShowRepository = clientForShowRepository;
            //clientsForShow = (ObservableCollection<ClientForShow>)_clientForShowRepository.GetData();
        }
        

    }
}
