using Firebase.Database;
using Firebase.Database.Query;
using PM2E2GRUPO2.Modelos;
namespace EjemploFireBase
{
    public partial class MainPage : ContentPage
    {
        FirebaseClient client = new FirebaseClient("https://ejemplofirebase-82627-default-rtdb.firebaseio.com/");
        private Empleado alumnosService;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            alumnosService = new Empleado();
        }

        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dic.Text) || string.IsNullOrEmpty(Nota.Text) || string.IsNullOrEmpty(txtDesc.Text))
            {
                alertN();
            }
            else
            {
                int currentCounter = await alumnosService.GetCounterAsync();
                int newId = currentCounter + 1;

                await client.Child("Empleados").Child(newId.ToString()).PutAsync(new Empleado
                {
                    Nombre = txtDesc.Text,
                    Direccion = dic.Text,
                    Nota = Nota.Text,
                });
                await alumnosService.UpdateCounterAsync(newId);
                await Shell.Current.GoToAsync("..");
                alertP();


            }
        }

        private async void alertP()
        {
            await DisplayAlert("Registro añadido Correctamente", "Correctamente", "OK");
        }

        private async void alertN()
        {
            await DisplayAlert("Registro no Realizado", "Rellene todo los campos", "OK");
        }
    }

}
