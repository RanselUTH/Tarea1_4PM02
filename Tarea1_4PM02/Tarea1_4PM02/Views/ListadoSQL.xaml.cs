using System;
using System.Threading.Tasks;
using Tarea1_4PM02;
using Tarea1_4PM02.Models;
using Tarea1_4PM02.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea1_4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListadoSQL : ContentPage
    {
        public ListadoSQL()
        {
            InitializeComponent();

            Title = "IMG SQL";
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                listaImagen2.ItemsSource = await App.dba.getListFotos();
            }
            catch (Exception)
            {
                await DisplayAlert("ERROR", "OCURRIO UN ERROR AL CARGAR LA LISTA", "OK");
            }
        }
        private async void listaImagen2_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selected = e.Item as Foto;
            Vista2 viewEmple = new Vista2();
            viewEmple.BindingContext = selected;
            viewEmple.Title = "" + selected.titulo;
            await Navigation.PushAsync(viewEmple);
        }

        private async void listaImagen2_Refreshing(object sender, EventArgs e)
        {
            listaImagen2.BackgroundColor = Color.Blue;
            listaImagen2.Opacity = 0.2;
            try
            {
                listaImagen2.ItemsSource = await App.dba.getListFotos();
            }
            catch (Exception)
            {
                await DisplayAlert("ERROR", "OCURRIO UN ERROR AL CARGAR LA LISTA", "OK");
            }
            await Task.Delay(2000);
            listaImagen2.IsRefreshing = false;
            listaImagen2.BackgroundColor = Color.Transparent;
            listaImagen2.Opacity = 1;
        }
    }
}