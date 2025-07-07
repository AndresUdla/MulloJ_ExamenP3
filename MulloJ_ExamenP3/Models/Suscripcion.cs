using SQLite;

namespace MulloJ_ExamenP3.Models
{
    public class Suscripcion
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        [MaxLength(100)]
        public string Servicio { get; set; }

        [NotNull]
        [MaxLength(100)]
        public string CorreoAsociado { get; set; }

        [NotNull]
        public decimal CostoMensual { get; set; }

        [NotNull]
        public bool RenovacionAutomatica { get; set; }
    }
}
