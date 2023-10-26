using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceDigitalBank.Models
{
    public class Usuarios
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
       
    }
}