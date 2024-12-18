using examenelgin3p.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace examenelgin3p.Controllers
{
    public class FirebaseController
    {
        private readonly string url = "https://examenelgin3p-acb6b-default-rtdb.firebaseio.com/";
        private readonly FirebaseClient client;
        private string deleteBugRecord;


        public FirebaseController()
        {
            this.client = new FirebaseClient(url);
        }


        public async Task<int> NewId()
        {
            List<Notas> lista = new List<Notas>();
            var dataList = await client.Child("Notas").OnceAsync<Notas>();
            foreach (var dl in dataList)
            {
                lista.Add(dl.Object);
            }

            if (lista.Count == 0)
            {
                deleteBugRecord = (await client.Child("Notas").PostAsync(new Notas())).Key;
                return 2;
            }

            return (lista.Count + 1);
        }


        /*public async Task<bool> crearnotas(Notas vnotas) {

            if (string.IsNullOrEmpty(vnotas.Key)) {

                try
                {
                    Console.WriteLine("creando nota");
                    var VNotas = await client.Child("Notas").OnceAsync<Notas>();
                    Console.WriteLine($"Número de Notas: {VNotas.Count}");
                    if (VNotas.Count == 0 || VNotas != null)
                    {
                        Console.WriteLine("No hay Notas existentes. Creando una nueva Nota...");
                        await client.Child("Nota").PostAsync(new Notas
                        {
                            Id_nota = Notas,
                            Descripcion = Notas.descripcion,
                            Fecha = Notas.Fecha,
                            Foto_record = Notas.foto,
                            Audio_record = Notas.Audio
                        }
            }
        }*/

        public async Task Insert(Notas nota)
        {
            string newId = (await NewId()).ToString();
            await client.Child("Notas").Child(newId).PutAsync(nota);
        }

        public async Task<List<Notas>> SelectAll()
        {
            List<Notas> lista = new List<Notas>();
            var dataList = await client.Child("Notas").OnceAsync<Notas>();
            foreach (var dl in dataList)
            {
                if (int.TryParse(dl.Key, out int result))
                {
                    lista.Add(dl.Object);
                }
            }
            return lista;
        }

        public async Task<Notas> SelectById(int id)
        {
            return await client.Child("Notas").Child(id.ToString()).OnceSingleAsync<Notas>();
        }

        public async void Update<Notas>(int id, Notas nota)
        {
            await client.Child("Notas").Child(id.ToString()).PutAsync(nota);
        }

        public async void Delete(int id)
        {
            await client.Child("Notas").Child(id.ToString()).DeleteAsync();
        }


    }
}
