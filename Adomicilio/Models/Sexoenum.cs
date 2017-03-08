using System;
using System.ComponentModel.DataAnnotations;

namespace Adomicilio.Models
{
    public static  class DataExtension
   {
    public static DateTime MinValue()
    {
        return new DateTime(1900, 01, 01, 00, 00, 00);
    }
    }
    public enum Tipocasaenum { Casa = 0,  Apartamento = 2, Residencia = 3,  }
    public enum Tipodelivery {Afiliado=0, Propio = 1, Externo = 2, Taxi= 3 }
    public enum Sexoenum { Masculino=1,Femenino=2 }
    public enum TipoAfiliacion { Usuario=0, Administrador=2,Comercio = 1,Master=99  }
    public enum Telefonoenum { Casa= 0, Trabajo= 1, Movil = 2, Otro=3 }
    public enum TipoPago { Online = 0, PuntodeVenta = 1, Transferencia = 2, MercadoPago = 3, PLataforma= 4,Otro=5  }
    public enum Procesadostat { Ingresada = 0, EnCurso = 1, Preparandose = 2, EnCamino= 3,Entregada=4, SeCancela=5 }
    public enum tipodenotificacionenum
    {
        Contacto = 1,
        Remesa = 2,
        Registro = 3,
        Agradecimiento = 5,
        Promocion = 9
    }
    public enum tipodecontacto
    {
        [Display(Name = "Solicitud de Informacion")]
        General=0,
        [Display(Name = "Informacion de registro")]
        Registro = 1,
        [Display(Name = "Informacion para Comercios")]
        Comercios = 2,
        [Display(Name = "Problemas o Errores con la pagina")]
        Inconveniente = 3,
        [Display(Name = "Sugerencias")]
        Mensaje = 4,
        [Display(Name = "Reclamos")]
        reclamo = 5,
        [Display(Name = "Otro")]
        Otro = 6
      

    }
} 
