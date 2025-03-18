using Domain.Entities;
using Domain.Enums;
using Domain.Strategies;

namespace Domain.Services;

public class RouteTypeService : IRouteTypeService
{
    
    private readonly IEnumerable<IRouteTypeStrategy> _strategies = new List<IRouteTypeStrategy>
    {
        new MultiModalRouteTypeStrategy(),
        new CarRouteTypeStrategy(2),
        new TrainRouteTypeStrategy(2),
        new ShipRouteTypeStrategy(2)
    };

    public RouteType GetRouteType(Route route)
    {
        if (route == null) throw new ArgumentNullException(nameof(route));

        if (_strategies.Any(strategy => strategy.TryHandle(route)))
        {
            return route.Type;
        }

        throw new InvalidOperationException($"Route type {route.GetType()} is not supported");
    }
}