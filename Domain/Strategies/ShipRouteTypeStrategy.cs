using Domain.Entities;
using Domain.Enums;

namespace Domain.Strategies;

public class ShipRouteTypeStrategy : IRouteTypeStrategy
{
    private readonly int _simplePointCount;

    public ShipRouteTypeStrategy(int simplePointCount)
    {
        _simplePointCount = simplePointCount;
    }

    public bool CanHandle(Route route)
    {
        if (route == null) throw new ArgumentNullException(nameof(route));

        var distinctTransports = route.Points
            .Select(p => p.TransportType)
            .Distinct()
            .ToList();

        return distinctTransports.Count == 1 && distinctTransports[0] == TransportType.Ship;
    }

    public RouteType Determine(Route route)
    {
        return route.Points.Count == _simplePointCount
            ? RouteType.ShipSimple
            : RouteType.ShipComplex;
    }
}