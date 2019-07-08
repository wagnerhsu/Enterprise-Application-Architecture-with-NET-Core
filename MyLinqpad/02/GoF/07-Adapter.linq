<Query Kind="Program">
  <NuGetReference>Microsoft.Extensions.DependencyInjection</NuGetReference>
  <NuGetReference>Microsoft.Extensions.Logging</NuGetReference>
  <Namespace>Microsoft.Extensions.Logging</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
</Query>

void Main()
{
	
}

// Define other methods and classes here
public class DBAdapter
{
	private OracleDBDriver dbDriver = null;
	private bool bDBInitialized;
	private readonly string initializationDBParameters;

	public DBAdapter()
	{
		//dbDriver = new OracleDBDriverImpl();
		initializationDBParameters = "XYZ, ABC";
	}

	public DataTable ExecuteSQL(string strSQL)
	{
		if (string.IsNullOrWhiteSpace(strSQL)) throw new InvalidSQLException();

		if (!bDBInitialized) bDBInitialized = dbDriver.Initialize(initializationDBParameters);

		if (!dbDriver.ValidateSQL(strSQL)) throw new InvalidSQLException();

		var dbConnection = dbDriver.CreateNewPooledConnection();

		SomeDBFormat dbData = dbDriver.ExecuteSQL(dbConnection, strSQL);

		return TransformDBDataType(dbData);
	}

	private DataTable TransformDBDataType(SomeDBFormat dbData)
	{
		DataTable dbTable = null;

		//dbTable = dbData; do some conversions

		return dbTable;
	}
}

public class InvalidSQLException : Exception
{
}
public interface OracleDBDriver
{
	bool Initialize(string parameters);

	IOracleDBConnection CreateNewConnection();
	IOracleDBConnection CreateNewPooledConnection();

	bool ValidateSQL(string validSQL);

	SomeDBFormat ExecuteSQL(IOracleDBConnection dbCon, string validSQL);
	int ExecuteScalarSQL(IOracleDBConnection dbCon, string validSQL);
}

/// <summary>
/// Connection Object
/// </summary>
public interface IOracleDBConnection
{
}

public class SomeDBFormat
{
}