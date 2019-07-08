<Query Kind="Program">
  <NuGetReference>FluentAssertions</NuGetReference>
  <Namespace>FluentAssertions</Namespace>
</Query>

void Main()
{
	var student = GetFakeStudent();

	IPersistor<Student> studentPersistence = new OraclePersistorDecorator<Student>(new XMLPersistorDecorator<Student>(new DefaultPersistor<Student>()));

	studentPersistence.Persist(student);
	Student GetFakeStudent()
	{
		return new Student()
		{
			Id = "1A",
			Name = "Habib Qureshi",
			DOB = new DateTime(1980, 05, 01)
		};
	}
}

// Define other methods and classes here
public class Student
{
	public string Name;
	public string Id;
	public DateTime DOB;

}
public interface IPersistor<T>
{
	bool Persist(T objToPersist);
}

public class DefaultPersistor<T> : IPersistor<T>
{
	public bool Persist(T objToPersist)
	{
		Console.WriteLine("DefaultPersistor.Persist gets called");

		return true; //Do nothing, eat up. 
	}
}

public abstract class PersistorDecorator<T> : IPersistor<T>
{
	protected IPersistor<T> objectToBeDecorated;

	public PersistorDecorator(IPersistor<T> objectToBeDecorated)
	{
		this.objectToBeDecorated = objectToBeDecorated;
	}

	public virtual bool Persist(T objToPersist)
	{
		return objectToBeDecorated.Persist(objToPersist);
	}
}

public class XMLPersistorDecorator<T> : PersistorDecorator<T>
{
	public XMLPersistorDecorator(IPersistor<T>
	objectToBeDecorated) : base(objectToBeDecorated)
	{ }

	public override bool Persist(T objToPersist)
	{
		//stacking up functionality of the decorator pattern - 
		// which basically ensures that main functionality is
		// achieved and this decorator adds up new functionality.


		if (base.Persist(objToPersist))
			return DoXMLPersistence();
		return false;
	}

	private bool DoXMLPersistence()
	{
		//Does XML conversion and persistence operation.. 

		Console.WriteLine("DoXMLPersistence gets called");

		return true;
	}
}
public class OraclePersistorDecorator<T> : PersistorDecorator<T>
{
	public OraclePersistorDecorator(IPersistor<T> objectToBeDecorated) : base(objectToBeDecorated)
	{ }

	//stacking up functionality of the decorator pattern - which basically ensures that main functionality is achieved and this decorator adds up new functionality.
	public override bool Persist(T objToPersist)
	{
		if (base.Persist(objToPersist))
			return DoOracleDBPersistence();
		return false;
	}

	private bool DoOracleDBPersistence()
	{
		//Does Oracle DB persistence operation..

		Console.WriteLine("DoOracleDBPersistence gets called");

		return true;
	}
}