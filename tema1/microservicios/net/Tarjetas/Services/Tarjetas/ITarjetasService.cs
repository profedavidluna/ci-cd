using MicroServiciosBccr.Modelos;

namespace MicroServiciosBccr.Services.Tarjetas
{
    public interface ITarjetasService
    {
        List<Tarjeta> ObtengaTarjetas();
        Tarjeta ObtengaTarjetaPorID(int elIdTarjeta);
        List<Tarjeta> ObtengaTarjetasPorCliente(int elIdCliente);
        Tarjeta CreeLaTarjeta(Tarjeta laTarjeta);
        bool ActualiceLaTarjeta(Tarjeta laTarjeta, int elIdTarjeta);
        bool ElimineLaTarjeta(int elIdTarjeta);
        void Migracion();

    }
}
