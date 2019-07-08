<Query Kind="Program">
  <NuGetReference>Microsoft.Extensions.DependencyInjection</NuGetReference>
  <Namespace>System.Collections.Concurrent</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
</Query>

void Main()
{
	WeatherStructure weatherStructure = new WeatherStructure(new
		ForecastIOWeatherBuilder());
	weatherStructure.BuildWeatherStructure();
}

// Define other methods and classes here
public class Temperature : IWeatherElement
{
	protected internal int CentigradeTemperature;
	protected internal int FahrenheihtTemperature;

	public void ManipulateMe(IWeatherManipulator weatherManipulator) //aka accept
	{
		if (weatherManipulator != null) weatherManipulator.ManipulateElement(this); //aka visitor.visit(this)
	}

	public void ManipulateMe(IAnotherWeatherManipulator anotherWeatherManipulator) //aka accept
	{
		if (anotherWeatherManipulator != null) anotherWeatherManipulator.ManipulateElement(this); //aka visitor.visit(this)
	}
}

/// <summary>
/// Vistable class (The class to be visited by the visitor class)
/// </summary>
public class Map : IWeatherElement
{
	protected internal string MapURL;
	protected internal byte[] ThumbnailImage;

	public void ManipulateMe(IWeatherManipulator weatherManipulator)
	{
		if (weatherManipulator != null) weatherManipulator.ManipulateElement(this);
	}

	public void ManipulateMe(IAnotherWeatherManipulator anotherWeatherManipulator) //aka accept
	{
		if (anotherWeatherManipulator != null) anotherWeatherManipulator.ManipulateElement(this); //aka visitor.visit(this)
	}
}

/// <summary>
/// Interface for the Visitor object
/// </summary>
public interface IWeatherManipulator
{
	void ManipulateElement(IWeatherElement weatherElement);
}

/// <summary>
/// Interface for the Visitable class (The class to be visited by the visitor class)
/// </summary>
public interface IWeatherElement
{
	void ManipulateMe(IWeatherManipulator weatherManipulator);

	void ManipulateMe(IAnotherWeatherManipulator anotherWeatherManipulator);
}
/// <summary>
/// Another Interface for the Visitor object
/// </summary>
public interface IAnotherWeatherManipulator
{
	void ManipulateElement(Map map);
	void ManipulateElement(Temperature temperature);
	void ManipulateElement(WeatherDescription weatherDescription);
	void ManipulateElement(WeatherThumbnail weatherThumbnail);
}
public class ForecastIOWeatherBuilder : WeatherManipulator
{

	public override void BuildMap(IWeatherElement map)
	{
		//
	}

	public override void BuildTemperature(IWeatherElement temperature)
	{
		//
	}

	public override void BuildWeatherDescription(IWeatherElement weatherDescription)
	{
		//
	}

	public override void BuildWeatherThumbnail(IWeatherElement weatherThumbnail)
	{
		//
	}
}
public class AnotherWeatherManipulator : IAnotherWeatherManipulator
{
	public void ManipulateElement(WeatherDescription weatherDescription)
	{
		weatherDescription.ShortDescription = "Sunny";
		weatherDescription.Description = "Nice sunny weather is expected which is not so hot";
	}

	public void ManipulateElement(WeatherThumbnail weatherThumbnail)
	{
		weatherThumbnail.ThumbnailImage = new byte[3] { 2, 2, 2 };
	}

	public void ManipulateElement(Temperature temperature)
	{
		temperature.CentigradeTemperature = 30;
		temperature.FahrenheihtTemperature = 86;
	}

	public void ManipulateElement(Map map)
	{
		map.MapURL = "https://www.bing.com";
	}
}
public class YahooWeatherBuilder : WeatherManipulator
{
	public override void BuildMap(IWeatherElement map)
	{
		var m = map as Map;
		m.MapURL = "https://maps.google.com/";
	}

	public override void BuildTemperature(IWeatherElement temperature)
	{
		var t = temperature as Temperature;
		t.CentigradeTemperature = 30;
		t.FahrenheihtTemperature = 86;
	}

	public override void BuildWeatherDescription(IWeatherElement weatherDescription)
	{
		var wd = weatherDescription as WeatherDescription;
		wd.ShortDescription = "Sunny";
		wd.Description = "Nice sunny weather is expected which is not so hot";
	}

	public override void BuildWeatherThumbnail(IWeatherElement weatherThumbnail)
	{
		var wt = weatherThumbnail as WeatherThumbnail;
		wt.ThumbnailImage = new byte[3] { 1, 1, 1 };
	}
}
public class WeatherThumbnail : IWeatherElement
{
	protected internal byte[] ThumbnailImage;

	public void ManipulateMe(IWeatherManipulator weatherManipulator)
	{
		if (weatherManipulator != null) weatherManipulator.ManipulateElement(this);
	}

	public void ManipulateMe(IAnotherWeatherManipulator anotherWeatherManipulator) //aka accept
	{
		if (anotherWeatherManipulator != null) anotherWeatherManipulator.ManipulateElement(this); //aka visitor.visit(this)
	}

}

/// <summary>
/// The object structure of the visitor pattern.
/// It delegates the functionality of building the weather information to the
/// (external class) visitor class without exposing its internal objects as public properties
/// but as a proper agreed contract as per visitor pattern
/// </summary>
public class WeatherStructure
{
	private Temperature _temperature;
	private Map _map;
	private WeatherThumbnail _weatherThumbnail;
	private WeatherDescription _weatherDescription;

	private IWeatherManipulator _weatherBuilder;

	public WeatherStructure(IWeatherManipulator weatherBuilder)
	{
		_weatherBuilder = weatherBuilder;

		_temperature = new Temperature();
		_map = new Map();
		_weatherThumbnail = new WeatherThumbnail();
		_weatherDescription = new WeatherDescription();
	}

	internal void BuildWeatherStructure()
	{
		_temperature.ManipulateMe(_weatherBuilder);
		_map.ManipulateMe(_weatherBuilder);
		_weatherThumbnail.ManipulateMe(_weatherBuilder);
		_weatherDescription.ManipulateMe(_weatherBuilder);
	}

	public void BuildWeatherStructure2()
	{
		_weatherBuilder.ManipulateElement(_temperature);
		_weatherBuilder.ManipulateElement(_map);
		_weatherBuilder.ManipulateElement(_weatherThumbnail);
		_weatherBuilder.ManipulateElement(_weatherDescription);
	}

	internal void BuildAnotherWeatherStructure(IAnotherWeatherManipulator anotherWeatherBuilder)
	{
		anotherWeatherBuilder.ManipulateElement(_temperature);
		anotherWeatherBuilder.ManipulateElement(_map);
		anotherWeatherBuilder.ManipulateElement(_weatherThumbnail);
		anotherWeatherBuilder.ManipulateElement(_weatherDescription);
	}

	internal void BuildAnotherWeatherStructure2(IAnotherWeatherManipulator anotherWeatherBuilder)
	{
		_temperature.ManipulateMe(anotherWeatherBuilder);
		_map.ManipulateMe(anotherWeatherBuilder);
		_weatherThumbnail.ManipulateMe(anotherWeatherBuilder);
		_weatherDescription.ManipulateMe(anotherWeatherBuilder);
	}
}

/// <summary>
/// Abstract base class for IWeatherManipulator acting as a Visitor for the visitor pattern.
/// Exposes abstract methods to be implemented by derived classes as a template method pattern.
/// </summary>
public abstract class WeatherManipulator : IWeatherManipulator
{
	public void ManipulateElement(IWeatherElement weatherElement)
	{
		if (weatherElement is Map)
			BuildMap(weatherElement);
		else if (weatherElement is Temperature)
			BuildTemperature(weatherElement);
		else if (weatherElement is WeatherDescription)
			BuildWeatherDescription(weatherElement);
		else if (weatherElement is WeatherThumbnail)
			BuildWeatherThumbnail(weatherElement);
	}

	public abstract void BuildMap(IWeatherElement map);

	public abstract void BuildTemperature(IWeatherElement temperature);

	public abstract void BuildWeatherDescription(IWeatherElement weatherDescription);

	public abstract void BuildWeatherThumbnail(IWeatherElement weatherThumbnail);
}

public class WeatherDescription : IWeatherElement
{
	protected internal string ShortDescription;
	protected internal string Description;

	public void ManipulateMe(IWeatherManipulator weatherManipulator)
	{
		if (weatherManipulator != null) weatherManipulator.ManipulateElement(this);
	}

	public void ManipulateMe(IAnotherWeatherManipulator anotherWeatherManipulator) //aka accept
	{
		if (anotherWeatherManipulator != null) anotherWeatherManipulator.ManipulateElement(this); //aka visitor.visit(this)
	}
}