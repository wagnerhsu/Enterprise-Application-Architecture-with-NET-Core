<Query Kind="Program">
  <NuGetReference>Microsoft.Extensions.Logging</NuGetReference>
  <Namespace>Microsoft.Extensions.Logging</Namespace>
</Query>

void Main()
{
	LoggerFactory loggerFactory = new LoggerFactory();
	IAirportFlightSchedulesFactory factory = new GenevaAirportFlightSchedulesFactory(loggerFactory.CreateLogger("Main"));
	IAirportFlightSchedules schedule = factory.CreateAirportFlightSchedules();
	// Use schedule here
}

// Define other methods and classes here
public interface IAirportFlightSchedulesFactory
{
	IAirportFlightSchedules CreateAirportFlightSchedules();
}
public interface IAirportFlightSchedules
{
	
}

public class GenevaAirportFlightSchedules : IAirportFlightSchedules
{
	public GenevaAirportFlightSchedules(ILogger logger)
	{
		
	}
}
public class GenevaAirportFlightSchedulesFactory :
	IAirportFlightSchedulesFactory
{
	private ILogger _logger;

	public GenevaAirportFlightSchedulesFactory(ILogger logger)
	{
		_logger = logger;
	}

	public IAirportFlightSchedules CreateAirportFlightSchedules()
	{
		return new GenevaAirportFlightSchedules(_logger);
	}
}