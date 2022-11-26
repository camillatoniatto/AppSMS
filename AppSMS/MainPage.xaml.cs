using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace XF_SMS1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async Task EnviaSms(string body, string recipient)
        {
            try
            {
                var sms = new SmsMessage(body, recipient);
                await Sms.ComposeAsync(sms);
            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlert("Ops...", "Essa função não é suportada em seu dispositivo.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private async void btnEnviaSms_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNumero.Text))
            {
                await EnviaSms(txtMensagem.Text, txtNumero.Text);
            }
        }
    }
}