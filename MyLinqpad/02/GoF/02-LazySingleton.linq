<Query Kind="Program">
  <NuGetReference>FluentAssertions</NuGetReference>
  <Namespace>FluentAssertions</Namespace>
</Query>

void Main()
{
	LazySingleton s1 = LazySingleton.Instance;
	LazySingleton s2 = LazySingleton.Instance;
	s1.Should().BeSameAs(s1);
}

// Define other methods and classes here
public sealed class LazySingleton
{
	private static LazySingleton instance = null;
	private LazySingleton() { }

	public static LazySingleton Instance
	{
		get
		{
			if (instance == null) instance = new LazySingleton();
			return instance;
		}
	}
}