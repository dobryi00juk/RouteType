using Domain.Entities;
using Domain.Enums;

namespace Domain.Strategies;

internal class MultiModalRouteTypeStrategy : IRouteTypeStrategy
{
    public bool TryHandle(Route route)
    {
        if (route == null) throw new ArgumentNullException(nameof(route));

        var distinctTransports = route.Points
            .Select(p => p.TransportType)
            .Distinct()
            .Count();

        if (distinctTransports <= 1)
            return false;

        route.Type = RouteType.MultiModal;

        return true;
    }
}