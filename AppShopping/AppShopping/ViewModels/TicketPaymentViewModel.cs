using AppShopping.Libraries.Helpers.MVVM;
using AppShopping.Models;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    [QueryProperty("Number", "number")]
    public class TicketPaymentViewModel : BaseViewModel
    {
        private string _number;
        public String Number
        {
            set
            {
                SetProperty(ref _number, value);
                Ticket = _ticketService.GetTicketInfo(value);
                              
            }
        }
        private Ticket _ticket;

        public Ticket Ticket
        {
            get { return _ticket; }
            set { SetProperty(ref _ticket, value); }
        }

        private CreditCard _creditCard;

        public CreditCard CreditCard
        {
            get { return _creditCard; }
            set { SetProperty(ref _creditCard, value); }
        }


        public ICommand PaymentCommand { get; set; }

        private void Payment()
        {

        }

        private TicketService _ticketService;
        public TicketPaymentViewModel()
        {
            _ticketService = new TicketService();
            PaymentCommand = new Command(Payment);
            PayCommand = new Command(Pay);

            CreditCard = new CreditCard();
        }

        public ICommand PayCommand {get; set; }
        public async void Pay()
        {
            try
            {                               
                if (!string.IsNullOrEmpty(CreditCard.Number))
                { 
                    if(CreditCard.Number.Length < 19)
                        throw new Exception("Número do cartão incompleto");
                }
                else
                    throw new Exception("Campo do Número do cartão vazio");
                if (!string.IsNullOrEmpty(CreditCard.Document))
                {
                    if (CreditCard.Document.Length < 14)
                        throw new Exception("Número do CPF incompleto");
                }
                else
                    throw new Exception("Campo Número do CPF vazio");
                if (!string.IsNullOrEmpty(CreditCard.SecurityCode))
                {
                    if (CreditCard.SecurityCode.Length < 3)
                        throw new Exception("Número de segurança incompleto");
                }
                else
                    throw new Exception("Campo Número de segurança vazio");
                if (!string.IsNullOrEmpty(CreditCard.ExpireDate))
                {
                    if (CreditCard.ExpireDate.Length < 7)
                        throw new Exception("Data de validade incompleto");
                }
                else
                    throw new Exception("Campo validade vazio");

                var expiredString = CreditCard.ExpireDate.Split('/');
                var month = int.Parse(expiredString[0]);
                var year = int.Parse(expiredString[1]);

                var dataExpiracao = new DateTime(year, month, 28);

                if (dataExpiracao < DateTime.Today)
                    throw new Exception("Validade expirada");

                Ticket.Status = Libraries.Enums.TicketStatus.Paid;
                await Shell.Current.DisplayAlert("Pago", "Ticket Pago", "OK");
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                 await Shell.Current.DisplayAlert("Atenção!", ex.Message, "Ok");
            }                      
        }
    }
}
