using System;
using System.Collections.Generic;

namespace examenelgin3p.Models
{
    public class Notas
    {
        private List<string> invalidData = new List<string>();
        private int id;
        private string descripcion;
        private byte[] foto;
        private byte[] audio;

        public DateTime Fecha { get; set; } = DateTime.Now;

        public string FechaMOD
        {
            get
            {
                return this.Fecha.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }

        public Notas() { }

        public Notas(int id, string descripcion, byte[] foto, byte[] audio)
        {
            this.Id_nota = id;
            this.Descripcion = descripcion;
            this.Photo_record = foto;
            this.Audio_record = audio;
        }

        public List<string> GetDatosInvalidos()
        {
            return this.invalidData;
        }

        public int Id_nota
        {
            get { return this.id; }
            set
            {
                if (value != 0)
                {
                    this.id = value;
                }
                else
                {
                    this.invalidData.Add("Nota id");
                }
            }
        }

        public string Descripcion
        {
            get { return this.descripcion; }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.descripcion = value;
                }
                else
                {
                    this.invalidData.Add("Descripcion");
                }
            }
        }

        public byte[] Photo_record
        {
            get { return this.foto; }

            set
            {
                if (value != null && value.Length > 0)
                {
                    this.foto = value;
                }
                else
                {
                    this.invalidData.Add("Foto");
                }
            }
        }

        public byte[] Audio_record
        {
            get { return this.audio; }

            set
            {
                if (value != null && value.Length > 0)
                {
                    this.audio = value;
                }
                else
                {
                    this.invalidData.Add("Audio");
                }
            }
        }
    }
}
