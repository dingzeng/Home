
> 抽象工厂模式，提供一个创建一系列相关或相互依赖对象的接口，而无需指定它们具体的类

下面通过示例代码说明抽象工厂模式(只是进行说明，不代表ADO.NET实际的实现):
```
// Abstruct Factory
public abstract class DbProviderFactory
{
    public abstract IDbConnection CreateDbConnection();

    public abstract IDataReader CreateDataReader();
}

// Concrete Factory(for MySql)
public class MySqlProviderFactory : DbProviderFactory
{
    public override IDbConnection CreateDbConnection()
    {
        return new MySqlConnection();
    }
    public override IDataReader CreateDataReader()
    {
        return new MySqlDataReader();
    }
}

// Concrete Factory(for SqlServer)
public class SqlServerProviderFactory : DbProviderFactory
{
    public override IDataReader CreateDataReader()
    {
        return new SqlServerDataReader();
    }

    public override IDbConnection CreateDbConnection()
    {
        return new SqlServerConnection();
    }
}

#region Abstruct Products
public interface IDbConnection
{

}

public interface IDataReader
{

}
#endregion

#region Concrete Products(for MySql)
public class MySqlConnection : IDbConnection
{

}

public class MySqlDataReader : IDataReader
{

}
#endregion

#region Concrete Products(for SqlServer)
public class SqlServerConnection : IDbConnection
{

}

public class SqlServerDataReader : IDataReader
{

}
#endregion
```

客户端代码:
```
void Main()
{
    DbProviderFactory dbProvider = null;//TODO 反射出具体的工厂对象

    IDataReader reader = dbProvider.CreateDataReader();
    IDbConnection conn = dbProvider.CreateDbConnection();

    //client code...
}
```

UML图：
![abstract-factory](http://p1.bpimg.com/1949/649795e707c5bac3.png)