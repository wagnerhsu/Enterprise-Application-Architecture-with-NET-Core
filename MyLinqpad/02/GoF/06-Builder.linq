<Query Kind="Program">
  <NuGetReference>Microsoft.Extensions.DependencyInjection</NuGetReference>
  <NuGetReference>Microsoft.Extensions.Logging</NuGetReference>
  <Namespace>Microsoft.Extensions.Logging</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
</Query>

void Main()
{
	var serviceProvider = ConfigureServices();
	var wizard = CreateWizard(serviceProvider);
	
}

IServiceProvider ConfigureServices()
{
	IServiceCollection services = new ServiceCollection();
	services.AddSingleton<IWizardBuilder,FakeWizardBuilder>();
	return services.BuildServiceProvider();
}
// Define other methods and classes here
public IWizard CreateWizard(IServiceProvider provider)
{
	//Director code for builder pattern 
	var wizardBuilder =
	  provider.GetRequiredService<IWizardBuilder>();
	wizardBuilder.CreateWizardSteps(4);
	wizardBuilder.AddFrontScreen();
	wizardBuilder.AddFinalScreen();

	var wizard = wizardBuilder.GetResult();

	ApplyThemeOnWizard(wizard);

	return wizard;
}

private void ApplyThemeOnWizard(IWizard wizard)
{
	Console.WriteLine("ApplyThemeOnWizard");
}

public interface IWizardBuilder
{
	void CreateWizardSteps(int screenSteps);
	void AddFrontScreen();
	void AddFinalScreen();

	IWizard GetResult();
}

public class FakeWizardBuilder : IWizardBuilder
{
	public void AddFinalScreen()
	{
		//throw new NotImplementedException();
	}

	public void AddFrontScreen()
	{
		//throw new NotImplementedException();
	}

	public void CreateWizardSteps(int screenSteps)
	{
		//throw new NotImplementedException();
	}

	public IWizard GetResult()
	{
		return new FakeWizard();
	}
}

public interface IWizard {}
public class FakeWizard : IWizard {}