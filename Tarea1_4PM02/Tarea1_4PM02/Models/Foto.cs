using SQLite;
using System;

namespace Tarea1_4PM02.Models
{
    public class Foto
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String titulo { get; set; }
        public String desc { get; set; }
        public Byte[] img { get; set; }

        public string lblid { get { return $"ID: {id}"; } }
        public string lbltitulo { get { return $"Titulo: {titulo}"; } }
        public string lbldesc { get { return $"Descripcion: {desc}"; } }
    }
}

