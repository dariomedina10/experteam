

namespace Experteam
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class guia
    {
        public int IdGuia { get; set; }
        public string NumeroGuía { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]

        public System.DateTime FechaEnvio { get; set; }
        public string PaisOrigen { get; set; }
        public string NombreRemitente { get; set; }
        public string DireccionRemitente { get; set; }
        public string TelefonoRemitente { get; set; }
        public string EmailRemitente { get; set; }
        public string PaisDestino { get; set; }
        public string NombreDestinatario { get; set; }
        public string DireccionDestinatario { get; set; }
        public string TelefonoDestinatario { get; set; }
        public string EmailDestinatario { get; set; }
        public decimal Total { get; set; }
    }
}
