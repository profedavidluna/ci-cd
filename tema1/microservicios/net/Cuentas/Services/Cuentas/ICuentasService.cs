using MicroServiciosBccr.Modelos;

namespace MicroServiciosBccr.Services.Cuentas
{
    public interface ICuentasService
    {
        List<Cuenta> ObtengaCuentasPorIdCliente(int elIdCliente);
        Cuenta ObtengaCuentaPorIdCuenta(int elIdCuenta);
        Cuenta CreeLaCuenta(Cuenta laCuenta);
        bool ActualiceLaCuenta(Cuenta laCuenta, int elIdCuenta);
        bool BloqueeLaCuenta(int elIdCuenta);
        bool ElimineLaCuenta(int elIdCuenta);
        List<Cuenta> ObtengaTodasLasCuentas();
    }
}
