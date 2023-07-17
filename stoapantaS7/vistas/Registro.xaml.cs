using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;

namespace stoapantaS7.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var datosRegistro = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contrasena = txtContraseña.Text };
                con.InsertAsync(datosRegistro);
                Navigation.PushAsync(new Login());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
    }
}