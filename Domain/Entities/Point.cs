using Domain.Enums;

namespace Domain.Entities;

public class Point : Entity
{
    public Location Location { get; private set; }
    public TransportType TransportType { get; private set; }

    public Point(Location location, TransportType transportType)
    {
        Location = location;
        TransportType = transportType;
    }
}