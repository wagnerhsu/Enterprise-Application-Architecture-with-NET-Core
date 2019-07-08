<Query Kind="Program" />

void Main()
{
	List<ISettings> allSettings = new List<ISettings>();

	ISettings setting = new UserSettings();
	allSettings.Add(setting);

	setting = new MachineSettings();
	allSettings.Add(setting);

	setting = new ReadOnlySettings();
	allSettings.Add(setting);

	//Load all types of settings 
	allSettings.ForEach(s => s.Load());

	//Do some changes to settings objects.. 

	//Following line fails because client (actually) 
	// does not know it has to catch

	allSettings.ForEach(s => s.Save());
}

// Define other methods and classes here
public interface ISettings
{
	void Load();
	void Save();
}
public class UserSettings : ISettings
{
	public void Load()
	{
		//Loads the user settings 
	}

	public void Save()
	{
		//Saves the user settings 
	}
}
public class MachineSettings : ISettings
{
	public void Load()
	{
		//Loads the machine settings 
	}

	public void Save()
	{
		//Saves the machine settings 
	}
}
/// <summary> 
/// Says this class holds readonly or constant settings / configuration parameters to the software
/// </summary> 
public class ReadOnlySettings : ISettings
{
	public void Load()
	{
		//Loads some readonly/constant settings 
	}

	public void Save()
	{
		throw new NotImplementedException();
	}
}