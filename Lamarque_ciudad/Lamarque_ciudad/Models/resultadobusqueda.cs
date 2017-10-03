using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lamarque_ciudad.Models
{
    public class resultadobusqueda
    {
       public List<eventos_bd> eventos { get; set; }
        public List<servicios_bd> servicios { get; set; }
    }
}