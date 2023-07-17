using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;
using System.IO;


namespace stoapantaS7.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        public static IEnumerable<Estudiante> select_where (SQLiteConnection db, string usuario, string contrasena) 
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usuario=? and Contrasena=?", usuario, contrasena);
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = select_where(db, txtUsuario.Text, txtContraseña.Text);

                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else 
                {
                    DisplayAlert("Alerta", "Usuario o Contraseña Incorrecto","Cerrar") ;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Cerrar");
            }
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}