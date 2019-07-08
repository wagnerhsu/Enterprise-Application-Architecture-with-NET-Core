<Query Kind="Program">
  <NuGetReference>Microsoft.Extensions.DependencyInjection</NuGetReference>
  <Namespace>System.Collections.Concurrent</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
</Query>

void Main()
{
	IWeatherInfoBuilder wInfoBuilder1 = new
		WeatherDescriptionBuilder();
	IWeatherInfoBuilder wInfoBuilder2 = new
	  WeatherMapBuilder();
	IWeatherInfoBuilder wInfoBuilder3 = new
	  WeatherTemperatureBuilder();
	IWeatherInfoBuilder wInfoBuilder4 = new
	  WeatherThumbnailBuilder();

	wInfoBuilder1.SetSuccessor(wInfoBuilder2);
	wInfoBuilder2.SetSuccessor(wInfoBuilder3);
	wInfoBuilder3.SetSuccessor(wInfoBuilder4);

	WeatherStructure weather = new WeatherStructure();
	wInfoBuilder1.BuildWeatherObject(weather);
}

// Define other methods and classes here
public class WeatherStructure
{
	public WeatherStructure()
	{
		Temperature = new Temperature();
		Map = new Map();
		WeatherThumbnail = new WeatherThumbnail();
		WeatherDescription = new WeatherDescription();
	}

	public Temperature Temperature;
	public Map Map;
	public WeatherThumbnail WeatherThumbnail;
	public WeatherDescription WeatherDescription;
}

public abstract class IWeatherInfoBuilder
{
	protected IWeatherInfoBuilder _successor;

	public void SetSuccessor(IWeatherInfoBuilder successor)
	{
		_successor = successor;
	}

	public abstract void BuildWeatherObject(WeatherStructure ws);
}



#region Elements
public class Temperature
{
	public int CentigradeTemperature;
	public int FahrenheihtTemperature;
}
public class Map
{
	public string MapURL;
	public byte[] ThumbnailImage;
}
public class WeatherThumbnail
{
	public byte[] ThumbnailImage;
}
public class WeatherDescription
{
	public string ShortDescription;
	public string Description;
}
#endregion

#region Commands
public class WeatherThumbnailBuilder : IWeatherInfoBuilder
{
	public override void BuildWeatherObject(WeatherStructure weatherStructure)
	{
		BuildThumbnail(weatherStructure.WeatherThumbnail);

		if (_successor != null)
			_successor.BuildWeatherObject(weatherStructure);
	}

	private void BuildThumbnail(WeatherThumbnail weatherThumbnail)
	{
		//construct WeatherThumbnail appropriately
		weatherThumbnail.ThumbnailImage = new byte[4] { 1, 2, 3, 4 };
	}
}

public class WeatherTemperatureBuilder : IWeatherInfoBuilder
{
	public override void BuildWeatherObject(WeatherStructure weatherStructure)
	{
		BuildTemperature(weatherStructure.Temperature);

		if (_successor != null)
			_successor.BuildWeatherObject(weatherStructure);
	}

	private void BuildTemperature(Temperature temperature)
	{
		//construct Temperature appropriately
		temperature.CentigradeTemperature = 22;
		temperature.FahrenheihtTemperature = 71;
	}
}
public class WeatherMapBuilder : IWeatherInfoBuilder
{
	public override void BuildWeatherObject(WeatherStructure ws)
	{
		BuildMap(ws.Map);

		if (_successor != null)
			_successor.BuildWeatherObject(ws);
	}

	private void BuildMap(Map map)
	{
		//construct Map appropriately 
		map.MapURL = "https://maps.google.com/";
	}
}

public class WeatherDescriptionBuilder : IWeatherInfoBuilder
{
	public override void BuildWeatherObject(WeatherStructure weatherStructure)
	{
		BuildWeatherDescription(weatherStructure.WeatherDescription);

		if (_successor != null)
			_successor.BuildWeatherObject(weatherStructure);
	}

	private void BuildWeatherDescription(WeatherDescription weatherDescription)
	{
		//construct Map appropriately
		weatherDescription.ShortDescription = "Cloudy";
		weatherDescription.Description = "Cloudy and foggy weather";
	}
}
#endregion