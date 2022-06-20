using AppShopping.Libraries.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.ViewModels
{
    internal class RestaurantViewModel : EstablishmentViewModel
    {
        public RestaurantViewModel(EstablishmentType establishmentType) : base(establishmentType)
        {
        }
    }
}
