using AppShopping.Libraries.Helpers.MVVM;
using AppShopping.Models;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.ViewModels
{
    public class NewsViewModel : BaseViewModel
    {
        private NewsService _newService { get; set; }
        public List<News> News { get; set; }
        public NewsViewModel()
        {
            _newService = new NewsService();
            News = _newService.GetNews();
        }
    }
}
