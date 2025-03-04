using Domain.Entities;
using Domain.Enums;

namespace Domain.Strategies;

public interface IRouteTypeStrategy
{
    bool CanHandle(Route route);
    RouteType Determine(Route route);
}