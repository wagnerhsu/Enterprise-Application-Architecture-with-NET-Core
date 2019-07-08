<Query Kind="Program">
  <NuGetReference>FluentAssertions</NuGetReference>
  <Namespace>FluentAssertions</Namespace>
</Query>

void Main()
{
	SimpleSingleton s1 = SimpleSingleton.Instance;
	SimpleSingleton s2 = SimpleSingleton.Instance;
	s1.Should().BeSameAs(s1);
}

// Define other methods and classes here
/// <summary>
/// A very simple Singleton class
/// Its a sealed class just to prevent derivation that could potentially add instances
/// </summary>
public sealed class SimpleSingleton
{
	/// <summary>
	/// Privately hidden app wide single static instance - self managed
	/// </summary>
	private static readonly SimpleSingleton instance = new SimpleSingleton();

	/// <summary>
	/// Private constructor to hinder clients to create the objects of <see cref="SimpleSingleton"/>
	/// </summary>
	private SimpleSingleton() { }

	/// <summary>
	/// Publicly accessible method to supply the only instace of <see cref="SimpleSingleton"/>
	/// </summary>
	/// <returns></returns>
	public static SimpleSingleton Instance => instance;
}