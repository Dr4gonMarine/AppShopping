using AppShopping.Libraries.Helpers.MVVM;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace AppShopping.ViewModels
{
    public class TicketScanViewModel : BaseViewModel
    {
        public string TicketNumber { get; set; }
        public ICommand TicketTextChangedCommand { get; set; }
        public ICommand TicketScanCommand { get; set; }
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        public ICommand TicketPaidHistoryCommand { get; set; }
        public TicketScanViewModel()
        {
            TicketScanCommand = new MvvmHelpers.Commands.AsyncCommand(TicketScan);
            TicketPaidHistoryCommand = new Command(TicketPaidHistory);
            TicketTextChangedCommand = new Command(TicketTextChanged);
        }
        private async Task TicketScan()
        {
            //Camera - Scanear o códgio de barras.
            var scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += async (result) =>
            {
                scanPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Shell.Current.Navigation.PopAsync();
                    Message = result.Text;
                    TicketProccess(result.Text);
                });                
            };

            await Shell.Current.Navigation.PushAsync(scanPage);
        }
        private void TicketProccess(string ticketNumber)
        {
            try
            {
                var ticket = new TicketService().GetTicketInfo(ticketNumber);
                Message = "";
                Shell.Current.GoToAsync($"ticket/payment?number={ticketNumber}");                

            }catch (Exception e) 
            {
                
                Message = e.Message;
            }
        }
        private void TicketTextChanged()
        {
            if (TicketNumber.Length == 15)
            {
                var ticketNumber = TicketNumber.Replace(" ",String.Empty);
                TicketProccess(ticketNumber);
            }
        }
        private void TicketPaidHistory()
        {
            Shell.Current.GoToAsync("ticket/paid/history");            
        }
    }
}
