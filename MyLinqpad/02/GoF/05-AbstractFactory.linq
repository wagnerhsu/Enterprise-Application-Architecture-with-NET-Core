<Query Kind="Program">
  <NuGetReference>Microsoft.Extensions.Logging</NuGetReference>
  <Namespace>Microsoft.Extensions.Logging</Namespace>
</Query>

void Main()
{

}

// Define other methods and classes here
public interface IUIAbsFactory
{
	IMenu GetMenu();
	IWizard CreateWizard();
	IStatusBar CreateStatusBar();
}
public interface IMenu { }
public interface IWizard { }
public interface IStatusBar
{

}