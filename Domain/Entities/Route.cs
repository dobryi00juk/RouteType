namespace Domain.Entities;

public class Route : Entity
{
    private readonly List<Point> _points = new();
    public IReadOnlyCollection<Point> Points => _points;

    public Route(IEnumerable<Point> points)
    {
        if (points == null) throw new ArgumentNullException(nameof(points));

        //TODO: validation

        _points.AddRange(points);
    }
}