using Domain.Entities;
using Domain.Enums;
using Domain.Services;
using Domain.Strategies;

namespace Domain.Tests;

public class RouteTypeTest
{
    private static readonly Location Tiraspol = new("Tiraspol", "Sverdlova", "", "123", "Transnistria");
    private static readonly Location Chisinau = new("Chisinau", "1st", "", "123", "Moldova");
    private static readonly Location Odessa = new("Odessa", "2sd", "", "123", "Ukraine");
    private static readonly Location Hamburg = new("Hamburg", "123", "", "123", "Germany");
    private const int SimplePointCount = 2;

    private static readonly IRouteTypeStrategy[] Strategies =
    {
        new MultiModalRouteTypeStrategy(),
        new CarRouteTypeStrategy(SimplePointCount),
        new TrainRouteTypeStrategy(SimplePointCount),
        new ShipRouteTypeStrategy(SimplePointCount)
    };

    [Theory]
    [MemberData(nameof(GetRouteTestData))]
    public void DetermineType_ShouldReturnExpected(Route route, RouteType expectedRouteType)
    {
        var service = new RouteTypeService(Strategies);
        var routeType = service.GetRouteType(route);

        Assert.Equal(expectedRouteType, routeType);
    }

    public static IEnumerable<object[]> GetRouteTestData()
    {
        yield return new object[]
        {
            new Route(new Point[]
            {
                new(Tiraspol, TransportType.Car),
                new(Chisinau, TransportType.Car)
            }),
            RouteType.CarSimple
        };

        yield return new object[]
        {
            new Route(new Point[]
            {
                new(Odessa, TransportType.Ship),
                new(Hamburg, TransportType.Ship)
            }),
            RouteType.ShipSimple
        };

        yield return new object[]
        {
            new Route(new Point[]
            {
                new(Tiraspol, TransportType.Car),
                new(Chisinau, TransportType.Car),
                new(Odessa, TransportType.Ship),
                new(Hamburg, TransportType.Ship)
            }),
            RouteType.MultiModal
        };

        yield return new object[]
        {
            new Route(new Point[]
            {
                new(Tiraspol, TransportType.Car),
                new(Chisinau, TransportType.Car),
                new(Odessa, TransportType.Car)
            }),
            RouteType.CarComplex
        };

        yield return new object[]
        {
            new Route(new Point[]
            {
                new(Tiraspol, TransportType.Ship),
                new(Chisinau, TransportType.Ship),
                new(Odessa, TransportType.Ship),
                new(Hamburg, TransportType.Ship)
            }),
            RouteType.ShipComplex
        };

        yield return new object[]
        {
            new Route(new Point[]
            {
                new(Tiraspol, TransportType.Train),
                new(Chisinau, TransportType.Train)
            }),
            RouteType.TrainSimple
        };

        yield return new object[]
        {
            new Route(new Point[]
            {
                new(Tiraspol, TransportType.Train),
                new(Chisinau, TransportType.Train),
                new(Odessa, TransportType.Train),
                new(Hamburg, TransportType.Train)
            }),
            RouteType.TrainComplex
        };
    }
}