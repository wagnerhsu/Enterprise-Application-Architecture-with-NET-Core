<Query Kind="Program">
  <NuGetReference>Microsoft.Extensions.DependencyInjection</NuGetReference>
  <Namespace>System.Collections.Concurrent</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
</Query>

void Main()
{
	var listener = new KeyboardListener();
	var statusBar = new StatusBar();
	var balloonNotifier = new BalloonNotifier();

	listener.AddObserver(statusBar);
	listener.AddObserver(balloonNotifier);

	listener.SartListening();

	listener.RemoveObserver(balloonNotifier);
	listener.SartListening(); //trigger a new notification again
}

// Define other methods and classes here
public interface IKeyObserver
{
	void Update(object anObject);
}

public abstract class IKeyObservable
{
	private IList<IKeyObserver> _observers = new
	  List<IKeyObserver>();

	public void AddObserver(IKeyObserver observer)
	{
		_observers.Add(observer);
	}

	public void RemoveObserver(IKeyObserver observer)
	{
		_observers.Remove(observer);
	}

	public void NotifyObservers(object anObject)
	{
		foreach (IKeyObserver observer in _observers)
		{
			observer.Update(anObject);
		}
	}
}
public class KeyboardListener : IKeyObservable
{
	public void SartListening()
	{
		ListenToKeys(); //Normally it would be a 
		// continous process..

		}

	/// <summary> 
	/// Listen and notify only the interested keys 
	/// </summary> 
	private void ListenToKeys()
	{
		ObservedKeys key;

		//Got the key, we are interested in.. 
		key = ObservedKeys.NUM_LOCK;

		NotifyObservers(key);
	}
}

public enum ObservedKeys
{
	CAPS_LOCK,
	NUM_LOCK,
	SCROLL_LOCK
}

public class StatusBar : IKeyObserver
{
	public void Update(object anObject)
	{
		Console.WriteLine("StatusBar - Key pressed: " +
		  anObject.ToString());
	}
}

public class BalloonNotifier : IKeyObserver
{
	public void Update(object anObject)
	{
		Console.WriteLine("BalloonNotifier - Key pressed: " + anObject.ToString());
	}
}