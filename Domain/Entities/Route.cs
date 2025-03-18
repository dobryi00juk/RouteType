using Domain.Enums;

namespace Domain.Entities;

public class Route : Entity
{
    private readonly List<Point> _points = new();
    public IReadOnlyCollection<Point> Points => _points;

    public RouteType Type { get; set; }

    public Route(IEnumerable<Point> points)
    {
        if (points == null) throw new ArgumentNullException(nameof(points));

        _points.AddRange(points);
    }
}