using Domain.Entities;
using Domain.Enums;

namespace Domain.Strategies;

public class TrainRouteTypeStrategy : IRouteTypeStrategy
{
    private readonly int _simplePointCount;

    public TrainRouteTypeStrategy(int simplePointCount)
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

        return distinctTransports.Count == 1 && distinctTransports[0] == TransportType.Train;
    }

    public RouteType Determine(Route route)
    {
        return route.Points.Count == _simplePointCount
            ? RouteType.TrainSimple
            : RouteType.TrainComplex;
    }
}