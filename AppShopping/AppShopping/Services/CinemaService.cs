using AppShopping.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.Services
{
    public class CinemaService
    {
        public List<Film> GetFilms()
        {
            return new List<Film>()
            {
                new Film(){Name = "1917"
                ,Description = " Na Primeira Guerra Mundial, dois soldados britânicos recebem ordens aparentemente impossíveis de cumprir. Em uma corrida contra o tempo, eles precisam atravessar o território inimigo e entregar uma mensagem que pode salvar 1.600 de seus companheiros."
                , Cover = "https://cultura.estadao.com.br/blogs/p-de-pop/wp-content/uploads/sites/296/2020/01/SM-1917-Sam-Mendes.jpg",
                SessionGroups = new List<SessionGroup>
                     {
                         new SessionGroup("Legendadas", new List<string>(){"10:30h", "14:30h", "15h", "17:30h"}),
                         new SessionGroup("Dubladas", new List<string>(){"12:30h", "13:30h", "19h", "20:30h"}),
                     }
                 },

                new Film(){Name = "Morbius",
                    Description = "O bioquímico Michael Morbius tenta curar-se de uma doença rara no sangue mas, sem perceber, ele fica infectado com uma forma de vampirismo.",
                    Cover = "https://conteudo.imguol.com.br/c/splash/a7/2022/03/29/cartaz-de-morbius-1648582369158_v2_3x4.jpg",
                 SessionGroups = new List<SessionGroup>
                     {
                         new SessionGroup("Legendadas", new List<string>(){"10:30h", "14:30h", "15h", "17:30h"}),
                         new SessionGroup("Dubladas", new List<string>(){"13:30h", "19h", "20:30h"}),
                     }
                 }
            };
        }
    }
}
