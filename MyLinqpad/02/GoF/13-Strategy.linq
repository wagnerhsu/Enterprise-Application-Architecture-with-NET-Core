<Query Kind="Program">
  <NuGetReference>Microsoft.Extensions.DependencyInjection</NuGetReference>
  <Namespace>System.Collections.Concurrent</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
</Query>

void Main()
{
	string pointA = "Berlin";
	string pointB = "Frankfurt";
	TimeSpan timeSpan;
	var durationCalculator = new TravelDurationCalculator();

	durationCalculator.SetCalculator(new
	  PublicTransportDurationCalculator());
	timeSpan = durationCalculator.Measure(pointA, pointB);
	Console.WriteLine(pointA + " to " + pointB + " takes " +
	  timeSpan.ToString() + " using public transport.");

	durationCalculator.SetCalculator(new CarDurationCalculator());
	timeSpan = durationCalculator.Measure(pointA, pointB);
	Console.WriteLine(pointA + " to " + pointB + " takes " +
	timeSpan.ToString() + " using car.");
}

// Define other methods and classes here
public class TravelDurationCalculator
{
	private IDurationCalculator strategy;

	public TimeSpan Measure(string pointA, string pointB)
	{
		return strategy.Measure(pointA, pointB);
	}

	//Change the strategy 
	public void SetCalculator(IDurationCalculator strategy)
	{
		this.strategy = strategy;
	}
}
public interface IDurationCalculator
{
	TimeSpan Measure(string pointA, string pointB);
}

/// <summary> 
/// Travel duration calculating strategy using car 
/// </summary> 
public class CarDurationCalculator : IDurationCalculator
{
	public TimeSpan Measure(string pointA, string pointB)
	{
		//Calculate and return the time duration value.. 
		return new TimeSpan(4, 46, 0);
	}
}
/// <summary> 
/// Travel duration calculating strategy using public transport(bus, tram, train..)
/// </summary> 
public class PublicTransportDurationCalculator :
	  IDurationCalculator
{
	public TimeSpan Measure(string pointA, string pointB)
	{
		//Calculate and return the time duration value.. 
		return new TimeSpan(6, 02, 0);
	}
}