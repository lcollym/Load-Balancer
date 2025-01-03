namespace loanBalancer.Models;

public class LoadBalancerConfig
{
    public List<string> BackendServers { get; set; }
    public int HealthCheckIntervalSeconds { get; set; }
}