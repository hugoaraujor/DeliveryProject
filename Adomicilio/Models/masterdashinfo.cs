using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adomicilio.Models
{
    public class Masterdashinfo
    {
        public int NroEmpresas { get; set; }
        public int NroClientes { get; set; }
        public int NroOrdenes { get; set; }
        public int NroNotificaciones{ get; set; }
        public int NroContactanos { get; set; }
        public int NroPlatos{ get; set; }
        public int NroEmpresasNuevas { get; set; }
        public int NroClientesNuevas { get; set; }
        public int NroOrdenesNuevas { get; set; }
        public int NroNotificacionesNuevas { get; set; }
        public int NroContactanosNuevas { get; set; }
        public int NroPlatosNuevas { get; set; }
        public List<Notificaciones> Listanotificaciones { get; set; }
        public List<Contacto> Listacontacto { get; set; }

    }
}