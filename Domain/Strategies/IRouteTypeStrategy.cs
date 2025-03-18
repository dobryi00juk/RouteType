using Domain.Entities;
using Domain.Enums;

namespace Domain.Strategies;

public interface IRouteTypeStrategy
{
    bool TryHandle(Route route);
}