using MicroServiciosBccr.Modelos;
using MicroServiciosBccr.Services.Clientes;
using Microsoft.AspNetCore.Mvc;


namespace MicroServiciosBccr.Clientes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly IClientesService IClientesService;

        public ClientesController(ILogger<ClientesController> logger, IClientesService _IClientesService)
        {
            _logger = logger;
            IClientesService = _IClientesService;
        }

        [HttpGet("{idCliente}")]
        public ActionResult<Cliente> Get(int idCliente)
        {
            Cliente elCliente= IClientesService.ObtengaClientePorId(idCliente);
            if(elCliente != null)
            {
                return Ok(elCliente);
            }
            else
            {
                return NotFound("Cliente no encontrado");
            }
        }
        [HttpGet("{idCliente}/tarjetas")]
        public ActionResult<List<Tarjeta>> TarjetasPorCliente(int idCliente)
        {
            List<Tarjeta> lasTarjetasDelCliente = IClientesService.ObtengaTarjetasPorCliente(idCliente);
            if (lasTarjetasDelCliente != null)
            {
                return Ok(lasTarjetasDelCliente);
            }
            else
            {
                return NotFound($"Tarjetas del cliente {idCliente} no encontradas");
            }
        }

        [HttpGet("{idCliente}/cuentas")]
        public ActionResult<List<Cuenta>> CuentasPorCliente(int idCliente)
        {
            List<Cuenta> lasCuentasDelCliente = IClientesService.ObtengaCuentasPorCliente(idCliente);
            if (lasCuentasDelCliente != null)
            {
                return Ok(lasCuentasDelCliente);
            }
            else
            {
                return NotFound($"Cuentas del cliente {idCliente} no encontradas");
            }
        }
    }
}
