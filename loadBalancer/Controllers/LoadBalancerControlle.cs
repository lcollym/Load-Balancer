using Microsoft.AspNetCore.Mvc;
using loanBalancer.Services;


    [ApiController]
    [Route("[controller]")]
    public class LoadBalancerController : ControllerBase
    {
        private readonly LoadBalancerService _loadBalancerService;
        private readonly HttpClient _httpClient;

        // Constructor para inyectar los servicios necesarios
        public LoadBalancerController(LoadBalancerService loadBalancerService)
        {
            _loadBalancerService = loadBalancerService;  // Servicio que maneja el balanceo de carga.
            _httpClient = new HttpClient();  // Cliente HTTP para hacer solicitudes a los servidores backend.
        }

        // Método que maneja las solicitudes entrantes
        [HttpGet]
        public async Task<IActionResult> HandleRequest()
        {
            // Obtenemos el siguiente servidor disponible del servicio de balanceo de carga
            var server = _loadBalancerService.GetNextServer();

            if (server == null) 
                return StatusCode(503, "No backend servers available");  // Si no hay servidores disponibles, retornamos un error 503.

            try
            {
                // Realizamos una solicitud HTTP GET al servidor backend seleccionado
                var response = await _httpClient.GetAsync(server);

                // Leemos la respuesta del servidor
                var content = await response.Content.ReadAsStringAsync();

                // Retornamos la respuesta al cliente
                return Content(content, "application/json");
            }
            catch
            {
                // Si hay un error al conectar con el servidor backend, retornamos un error 502
                return StatusCode(502, "Failed to connect to backend server");
            }
        }
    }
