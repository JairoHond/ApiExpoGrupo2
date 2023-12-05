using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using Firebase.Database;
using Microsoft.Maui.Storage;

namespace PM2E2GRUPO2.Modelos
{
    public class Empleado
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Nota { get; set; }


        FirebaseClient client = new FirebaseClient("https://ejemplofirebase-82627-default-rtdb.firebaseio.com/");
        public async Task<int> GetCounterAsync()
        {
            var counterSnapshot = await client.Child("contador").OnceSingleAsync<int?>();
            return counterSnapshot ?? 0;
        }

        public async Task UpdateCounterAsync(int newCounterValue)
        {
            await client.Child("contador").PutAsync(newCounterValue);
        }
    }
}
