using Domain.Entities;
using Domain.Enums;

namespace Domain.Strategies;

public class CarRouteTypeStrategy : IRouteTypeStrategy
{
    private readonly int _simplePointCount;

    public CarRouteTypeStrategy(int simplePointCount)
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

        return distinctTransports.Count == 1 && distinctTransports[0] == TransportType.Car;
    }

    public RouteType Determine(Route route)
    {
        if (route == null) throw new ArgumentNullException(nameof(route));

        //TODO: количество точек может меняться

        return route.Points.Count == _simplePointCount
            ? RouteType.CarSimple
            : RouteType.CarComplex;
    }
}