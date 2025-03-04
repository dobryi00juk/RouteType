using Domain.Entities;
using Domain.Enums;
using Domain.Strategies;

namespace Domain.Services;

public class RouteTypeService : IRouteTypeService
{
    private readonly IEnumerable<IRouteTypeStrategy> _strategies;

    public RouteTypeService(IEnumerable<IRouteTypeStrategy> strategies)
    {
        _strategies = strategies;
    }

    public RouteType GetRouteType(Route route)
    {
        if (route == null) throw new ArgumentNullException(nameof(route));

        foreach (var strategy in _strategies)
        {
            if (strategy.CanHandle(route))
            {
                return strategy.Determine(route);
            }
        }

        throw new InvalidOperationException($"Route type {route.GetType()} is not supported");
    }
}