using AppShopping.Models;
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

namespace AppShopping.ViewModels
{
    public class StoresViewModel:BaseViewModel
    {
        public string SearchWord { get; set; }
        public ICommand SearchCommand{ get; set; }
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

        public StoresViewModel()
        {
            SearchCommand = new Command(Search);
            DetailCommand = new Command<Establishment>(Detail);

            var allEstablishments = new EstablishmentServices().GetEstablishment();
            var allStores = allEstablishments.Where(a=>a.Type == EstablishmentType.Store).ToList();
            Establishments = allStores;
            _allEstablishments = allStores;
        }
        private void Search()
        {
            //Lógica de Filtrar a lista de Lojas
            Establishments = _allEstablishments.Where(a => a.Name.ToLower().Contains(SearchWord.ToLower())).ToList();
        }
        private void Detail(Establishment establishment)
        {
            string establishmentSerialized = JsonConvert.SerializeObject(establishment);

            //Shell > GoTo > EstablishmentDetail (como o objeto recebido)
            Shell.Current.GoToAsync($"establishment/detail?establishmentSerialized={Uri.EscapeDataString(establishmentSerialized)}");
        }
    }
}
