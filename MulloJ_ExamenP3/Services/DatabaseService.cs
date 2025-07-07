using MulloJ_ExamenP3.Repositories;

namespace MulloJ_ExamenP3.Services
{
    public class DatabaseService
    {
        private static SuscripcionRepository _suscripcionRepository;

        public static SuscripcionRepository SuscripcionRepository
        {
            get
            {
                if (_suscripcionRepository == null)
                {
                    var dbPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "suscripciones_MulloJ.db3"
                    );

                    _suscripcionRepository = new SuscripcionRepository(dbPath);
                }

                return _suscripcionRepository;
            }
        }
    }
}
