<Query Kind="Program" />

void Main()
{
	var allLoadableSettings = new List<IReadableSettings>();
	var allSaveableSettings = new List<IWriteableSettings>();

	var userSettings = new UserSettings();
	allLoadableSettings.Add(userSettings);
	allSaveableSettings.Add(userSettings);

	var machineSettings = new MachineSettings();
	allLoadableSettings.Add(machineSettings);
	allSaveableSettings.Add(machineSettings);

	var readOnlySettings = new ReadOnlySettings();
	allLoadableSettings.Add(readOnlySettings);
	//allSaveableSettings.Add(readOnlySettings); Cannot
	//compile this line;
	// readOnlySettings is not save - able / writable settings

	//Load all types of settings 
	allLoadableSettings.ForEach(s => s.Load());

	//Do some changes to settings objects.. 

	allSaveableSettings.ForEach(s => s.Save()); //Now this line clearly does not fail:) 
}

// Define other methods and classes here
public interface IReadableSettings
{
	void Load();
}
public interface IWriteableSettings
{
	void Save();
}

public class UserSettings : IReadableSettings, IWriteableSettings
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
public class ReadOnlySettings : IReadableSettings
{
	public void Load()
	{
		//Loads the machine settings
	}
}
public class MachineSettings : IReadableSettings, IWriteableSettings
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