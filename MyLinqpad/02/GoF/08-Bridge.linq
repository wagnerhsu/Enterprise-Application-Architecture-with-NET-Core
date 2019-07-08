<Query Kind="Program">
  <NuGetReference>Microsoft.Extensions.DependencyInjection</NuGetReference>
  <NuGetReference>Microsoft.Extensions.Logging</NuGetReference>
  <Namespace>Microsoft.Extensions.Logging</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
</Query>

void Main()
{
	IServiceCollection services = new ServiceCollection();
	services.AddSingleton<INewPremiumMicrowave, NewPremiumMicrowave>();
	services.AddSingleton<IPremiumMicrowave,PremiumMicrowave>();
	services.AddSingleton<ICoreMicrowave,Microwave>();
	var serviceProvider = services.BuildServiceProvider();
}

// Define other methods and classes here
/// <summary> 
/// Core Implementation Interface 
/// </summary> 
public interface ICoreMicrowave
{
	//0 seconds to 1800 seconds 
	void AdjustTime(int seconds);

	//0 to 10 steps (10=200 degree) 
	void AdjustHeatingTemperature(int temperature);

	void Start();
}

/// <summary> 
/// It gives one touch functionality 
/// </summary> 
public interface INewPremiumMicrowave
{
	void SelectFood(FoodType foodType);
	void Start();
}

public class NewPremiumMicrowave : INewPremiumMicrowave
{
	private ICoreMicrowave _microwave;
	private int[] _temperatureValuesForFood;
	private int[] _timeValuesForFood;

	public NewPremiumMicrowave(ICoreMicrowave microwave)
	{
		_microwave = microwave;

		//Storage of pre-determined values 
		_temperatureValuesForFood = new int[] { 180, 180, 150,
			  120, 100, 90, 80 };
		_timeValuesForFood = new int[] { 300, 240, 180, 180, 150,
			  120, 60 };
	}

	public void SelectFood(FoodType foodType)
	{
		_microwave.AdjustTime(_temperatureValuesForFood[
		  (int)foodType]);
		_microwave.AdjustHeatingTemperature(
		  _temperatureValuesForFood[(int)foodType]);
	}

	public void Start()
	{
		_microwave.Start();
	}
}

public interface IPremiumMicrowave
{
	//0 seconds to 1800 seconds
	void AdjustTime(int seconds);

	void SelectFood(FoodType foodType);

	void Start();
}

public class PremiumMicrowave : IPremiumMicrowave
{
	private ICoreMicrowave _microwave;
	private int[] _temperatureValuesForFood;

	public PremiumMicrowave(ICoreMicrowave microwave)
	{
		_microwave = microwave;
		_temperatureValuesForFood = new int[] { 180, 180, 150, 120, 100, 90, 80 };
	}

	public void AdjustTime(int seconds)
	{
		_microwave.AdjustTime(seconds);
	}

	public void SelectFood(FoodType foodType)
	{
		_microwave.AdjustHeatingTemperature(_temperatureValuesForFood[(int)foodType]);
	}

	public void Start()
	{
		_microwave.Start();
	}
}

/// <summary>
/// Core/Main Implementation of Microwave
/// </summary>
public class Microwave : ICoreMicrowave
{
	public void AdjustHeatingTemperature(int temperature)
	{
		//AdjustHeatingTemperature() implementation
	}

	public void AdjustTime(int seconds)
	{
		//AdjustTime() implementation
	}

	public void Start()
	{
		//Validation checks, defaults, Start() imeplementation
	}
}

public enum FoodType
{
	Frozen,
	Beef,
	Mutton,
	Chicken,
	Fish,
	Vegetable,
	Liquid
}