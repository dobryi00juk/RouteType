using Domain.Entities;
using Domain.Enums;

namespace Domain.Strategies;

internal class ShipRouteTypeStrategy : IRouteTypeStrategy
{
    private readonly int _simplePointCount;

    public ShipRouteTypeStrategy(int simplePointCount)
    {
        _simplePointCount = simplePointCount;
    }

    public bool TryHandle(Route route)
    {
        if (route == null) throw new ArgumentNullException(nameof(route));

        var distinctTransports = route.Points
            .Select(p => p.TransportType)
            .Distinct()
            .ToList();

        if (!(distinctTransports.Count == 1 && distinctTransports[0] == TransportType.Ship))
            return false;

        route.Type = route.Points.Count == _simplePointCount
            ? RouteType.ShipSimple
            : RouteType.ShipComplex;

        return true;
    }
}