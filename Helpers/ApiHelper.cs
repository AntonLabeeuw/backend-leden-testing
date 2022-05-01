namespace Testing.Helpers;

public class Helper
{

    public static WebApplicationFactory<Program> CreateApi()
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(ILidRepository));
                services.Remove(descriptor);

                var fakeLidRepository = new ServiceDescriptor(typeof(ILidRepository), typeof(FakeLidRepository), ServiceLifetime.Transient);
                services.Add(fakeLidRepository);

                var fakeTakRepository = new ServiceDescriptor(typeof(ITakRepository), typeof(FakeTakRepository), ServiceLifetime.Transient);
                services.Add(fakeTakRepository);

                var fakeGroepRepository = new ServiceDescriptor(typeof(IGroepRepository), typeof(FakeGroepRepository), ServiceLifetime.Transient);
                services.Add(fakeGroepRepository);
            });
        });

        return application;

    }
}