using Domain.Entities;
using Domain.Enums;

namespace Domain.Services;

public interface IRouteTypeService
{
    RouteType GetRouteType(Route route);
}