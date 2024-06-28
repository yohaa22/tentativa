using System;

namespace LojaAPI.Dto
{
    public class ContratoDto
    {
        public int ClienteId { get; set; }
        public int ServicoId { get; set; }
        public decimal PrecoCobrado { get; set; }
        public DateTime DataContratacao { get; set; }
    }
}
