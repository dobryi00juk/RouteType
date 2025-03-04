using Domain.Entities;
using Domain.Enums;

namespace Domain.Strategies;

public class MultiModalRouteTypeStrategy : IRouteTypeStrategy
{
    public bool CanHandle(Route route)
    {
        if (route == null) throw new ArgumentNullException(nameof(route));

        var distinctTransports = route.Points
            .Select(p => p.TransportType)
            .Distinct()
            .Count();

        return distinctTransports > 1;
    }

    public RouteType Determine(Route route)
    {
        return RouteType.MultiModal;
    }
}