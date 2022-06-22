using AppShopping.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.Services
{
    public class NewsService
    {
        private static List<News> fakeNews = new List<News>()
        {
            new News() { Title = "EVENTO DE COSPLAY", Description = "Vem de roupinha."},
            new News() { Title = "DIA DOS NAMORADOS", Description = "O Dia dos Namorados é comemorado em 12 de junho no Brasil. É muito comum nessa data a troca de cartões-postais e presentes especiais entre namorados."}
        };
        public List<News> GetNews()
        {
            return fakeNews;
        }
    }
}
