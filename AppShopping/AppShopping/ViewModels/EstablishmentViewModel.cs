using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using AppShopping.Libraries.Enums;
using AppShopping.Libraries.Helpers.MVVM;
using Newtonsoft.Json;
using AppShopping.Models;

namespace AppShopping.ViewModels
{
    public abstract class EstablishmentViewModel : BaseViewModel
    {
        public string SearchWord { get; set; }
        public ICommand SearchCommand { get; set; }
        private List<Establishment> _establishments;
        public List<Establishment> Establishments
        {
            get
            {
                return _establishments;
            }
            set
            {
                SetProperty(ref _establishments, value);
            }
        }

        public List<Establishment> _allEstablishments;

        public ICommand DetailCommand { get; set; }
        private EstablishmentType _establishmentType;

        public EstablishmentViewModel(EstablishmentType establishmentType)
        {
            _establishmentType = establishmentType;
            SearchCommand = new Command(Search);
            DetailCommand = new Command<object>(Detail);

            var allEstablishments = new EstablishmentServices().GetEstablishment();
            var allStores = allEstablishments.Where(a => a.Type == _establishmentType).ToList();
            Establishments = allStores;
            _allEstablishments = allStores;
        }
        private void Search()
        {
            //Lógica de Filtrar a lista de Lojas
            Establishments = _allEstablishments.Where(a => a.Name.ToLower().Contains(SearchWord.ToLower())).ToList();
        }
        private void Detail(object establishment)
        {
            if(establishment is Establishment)
            {
                var esta = (establishment as Establishment);
                string establishmentSerialized = JsonConvert.SerializeObject(esta);

                //Shell > GoTo > EstablishmentDetail (como o objeto recebido)
                Shell.Current.GoToAsync($"establishment/detail?establishmentSerialized={Uri.EscapeDataString(establishmentSerialized)}");

            }
        }
    }
}
