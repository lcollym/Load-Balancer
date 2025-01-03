using loanBalancer.Models;
using Microsoft.Extensions.Options;

namespace loanBalancer.Services;

public class LoadBalancerService
{
    private readonly List<string> _servers;
    private int _currentServerIndex = 0;

    public LoadBalancerService(IOptions<LoadBalancerConfig> config)
    {
        _servers = config.Value.BackendServers;  // Cargamos la lista de servidores desde la configuración.
    }

    public string GetNextServer()
    {
        if (_servers.Count == 0) return null;  // Si no hay servidores disponibles, retorna null.

        var server = _servers[_currentServerIndex];  // Obtenemos el servidor actual.
        _currentServerIndex = (_currentServerIndex + 1) % _servers.Count;  // Aumentamos el índice para el siguiente servidor.

        return server;  // Retorna el servidor seleccionado.
    }
}
