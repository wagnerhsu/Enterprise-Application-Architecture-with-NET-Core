<Query Kind="Program">
  <NuGetReference>Microsoft.Extensions.DependencyInjection</NuGetReference>
  <Namespace>System.Collections.Concurrent</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
</Query>

private static IServiceProvider Provider { get; set; }

void Main()
{
	RegisterServices();
	FlyweightClient();
}

private void FlyweightClient()
{
	var flightReservationSystem =
	  Provider.GetRequiredService<FlightReservation>();

	flightReservationSystem.MakeReservation("Qureshi",
	  "NRJ445", "332");
	flightReservationSystem.MakeReservation("Senthilvel",
	  "NRI339", "333");
	flightReservationSystem.MakeReservation("Khan",
	  "KLM987", "333");

	flightReservationSystem.DisplayReservations();
}

/// <summary> 
/// Initializing & populating DI container 
/// </summary> 
private void RegisterServices()
{
	IServiceCollection services = new ServiceCollection();

	//Adding required dependencies to the DI Container 
	services.AddSingleton<FlightList>();
	services.AddTransient<FlightReservation>();

	Provider = services.BuildServiceProvider();
}

// Define other methods and classes here
public class FlightList
{
	/// <summary> 
	/// Thread-safe internal storage 
	/// </summary> 
	private readonly ConcurrentDictionary<string, Flight> _cache = new ConcurrentDictionary<string, Flight>();

	public FlightList()
	{
		PopulateFlightList(); // List of available flights
							  // by the given carrier(airline)

	}

	/// <summary> 
	/// Returns immutable (and shareable flyweights) instances 
	/// </summary> 
	/// <param name="flightNumber"></param> 
	/// <returns></returns> 
	public Flight GetFlight(string flightNumber)
	{
		Flight flight = null;
		if (_cache.TryGetValue(flightNumber, out flight))
			return flight;
		throw new FlightDoesNotExistException();
	}

	public void AddFlight(string flightNumber, string from,
	string to, string planeType)
	{
		var flight = new Flight(flightNumber, from, to,
		  planeType);
		_cache.AddOrUpdate(flightNumber, flight,
		(key, oldFlight) => flight);
	}
	
	/// <summary>
	/// Data feed - could be done via injection..
	/// This generation of objects via this factory and adding them to internal pool
	/// is shown here for demonstration purposes. Normally its done outside the factory class itself.
	/// </summary>
	private void PopulateFlightList()
	{
		//Fetches from some data source and add
		AddFlight("332", "DXB", "MNL", "B777");
		AddFlight("333", "MNL", "DXB", "B777");

		AddFlight("432", "ABC", "XYZ", "A320");
		AddFlight("433", "XYZ", "ABC", "A320");

		AddFlight("532", "KHI", "LHR", "A330");
		AddFlight("533", "LHR", "KHI", "A330");

		AddFlight("632", "DXB", "JFK", "A380");
		AddFlight("633", "JFK", "DXB", "A380");
	}
}
public class FlightDoesNotExistException : Exception
{
}

public class FlightReservation
{
	private readonly IList<Reservation> _reservations = new
	  List<Reservation>();
	private FlightList _flightList;

	public FlightReservation(FlightList flightList)
	{
		_flightList = flightList;
	}

	public void MakeReservation(string lastName, string id,
	string flightNumber)
	{
		int pnr = PNRAllocator.AllocatePNR(lastName, id);

		//Flyweight-Immutable object is returned which will be 
		// shared between all instances 
		Flight flight = _flightList.GetFlight(flightNumber);

		_reservations.Add(new Reservation(pnr, flight));
	}

	public void DisplayReservations()
	{
		//Print Total Reservations: _reservations.Count; 
		foreach (var reservation in _reservations)
			reservation.Display();
	}
}
/// <summary>
/// Flight (immutable) objects will be the Flyweights
/// 
/// To make a type immutable you simply need to
/// - Make all fields readonly and assign them in the constructor
/// - Any method that change data or state of the object let it create and return a new (another immutable) instance instead
/// </summary>
public class Flight
{
	private const string FLIGHT_CARRIER = "KE";
	private readonly string _flightNumber;
	private readonly string _from;
	private readonly string _to;
	private readonly string _planeType;

	public Flight(string flightNumber, string from, string to, string planeType)
	{
		_flightNumber = flightNumber;
		_from = from;
		_to = to;
		_planeType = planeType;
	}

	public string FlightNumber
	{
		get { return FLIGHT_CARRIER + _flightNumber; }
	}

	public override bool Equals(object obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		return obj is Flight && Equals((Flight)obj);
	}

	public bool Equals(Flight other)
	{
		return (string.Equals(FlightNumber, other.FlightNumber) &&
			string.Equals(_from, other._from) &&
			string.Equals(_to, other._to) &&
			string.Equals(_planeType, other._planeType));
	}

	public override int GetHashCode()
	{
		return (FlightNumber != null ? FlightNumber.GetHashCode() : 0);
	}

	public static bool operator ==(Flight a, Flight b)
	{
		return Equals(a, b);
	}

	public static bool operator !=(Flight a, Flight b)
	{
		return !Equals(a, b);
	}
}
public class Reservation
{
	private readonly int _pnr;
	private readonly Flight _flight;

	public Reservation(int pnr, Flight flight)
	{
		_pnr = pnr;
		_flight = flight;
	}

	public string Display()
	{
		//concat all properties and return as a single string
		return "";
	}
}
/// <summary>
/// Utility class just for demonstration purposes
/// (not directly related to pattern implementation)
/// </summary>
public static class PNRAllocator
{
	private static Random random = new Random(99999);

	public static int AllocatePNR(string lastName, string id)
	{
		//Generate PNR number
		return random.Next(10000, int.MaxValue);
	}
}
