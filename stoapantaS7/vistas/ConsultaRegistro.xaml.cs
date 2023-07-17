using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace stoapantaS7.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> tabla;
        public ConsultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            Obtener();
        }

        public async void Obtener() 
        {
            var Resultado = await con.Table<Estudiante>().ToListAsync();
            tabla = new ObservableCollection<Estudiante>(Resultado);
            listaEstudiante.ItemsSource = tabla;

        }
        private void listaEstudiante_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoEstudiante = (Estudiante)e.SelectedItem;
            Navigation.PushAsync(new Elemento(objetoEstudiante));
        }
    }
}