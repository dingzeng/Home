# 自定义配置源

任何一个系统都或多或少存在一些配置数据，如数据库连接字符串、外部依赖服务的地址等。为此.NET Core提供了一套标准的配置框架，相比.NET Framework时代通过*.config文件获取配置，它使用起来更加方便，有更好的扩展性，热更新机制不用使应用重启等诸多优点。

## 配置系统

**配置源**

一个配置源表示一类配置数据的来源

接口定义如下：
```
public interface IConfigurationSource
{
  IConfigurationProvider Build(IConfigurationBuilder builder);
}
```

系统内置了多种配置源类型：
- 环境变量配置源(EnvironmentVariablesConfigurationSource)
- Azure配置源(AzureKeyVaultConfigurationSource)
- 命令行配置源(CommandLineConfigurationSource)
- 文件配置源(FileConfigurationSource)
  - Xml文件配置源(XmlConfigurationSource)
  - Ini文件配置源(IniConfigurationSource)
  - Json文件配置源(JsonConfigurationSource)
- 目录文件配置源(KeyPerFileConfigurationSource)

顾名思义，环境变量配置源是表示来自系统环境变量的配置，Azure配置源表示来自Azure服务中的配置，命令行配置源是表示在启动一个进程时提供的命令行参数，各中文件类型的配置源则是来自对应格式文件的配置，目录文件配置源可以指定一个目录，目录里面的文件名作为配置的key,而文件的内容则是配置的值。


**配置提供者**

从配置源接口的定义来看，唯一的约束方法Build接受一个`IConfigurationBuilder`的参数，返回一个`IConfigurationProvider`的对象。配置提供者是实际负责各个配置源中配置数据的获取、设置和加载的对象，一般一个数据源对应一个配置提供者：

|配置源|配置提供程序|
|---|---|
|EnvironmentVariablesConfigurationSource|EnvironmentVariablesConfigurationProvider|
|AzureKeyVaultConfigurationSource|AzureKeyVaultConfigurationProvider|
|CommandLineConfigurationSource|CommandLineConfigurationProvider|
|FileConfigurationProvider|FileConfigurationSource|
|XmlConfigurationSource|XmlConfigurationProvider|
|IniConfigurationSource|IniConfigurationProvider|
|JsonConfigurationSource|JsonConfigurationProvider|
|KeyPerFileConfigurationSource|KeyPerFileConfigurationProvider|

**IConfiguration**

一个IConfiguration对象表示从一个或多个配置源中获得的配置数据，它是一个有层次的key-value数据集合，接口定义如下：
```
public interface IConfiguration
{
    string this[string key] { get; set; }
    IConfigurationSection GetSection(string key);
    IEnumerable<IConfigurationSection> GetChildren();
    IChangeToken GetReloadToken();
}
public interface IConfigurationRoot : IConfiguration
{
    void Reload();
    IEnumerable<IConfigurationProvider> Providers { get; }
}
public interface IConfigurationSection : IConfiguration
{
  string Key { get; }
  string Path { get; }
  string Value { get; set; }
}
```

IConfigurationRoot表示一个配置的根节点，IConfigurationSection表示一个配置中具有嵌套关系的配置节点，这样一个可以有嵌套层次的key-value集合数据结构足够抽象和通用，可以用来承载我们任意的配置数据格式

**配置构建器**

在获取配置时，我们并不直接使用具体的配置源或配置提供者，而是使用Build模式来进行配置对象的构建，系统默认的内置构建器为`ConfigurationBuilder`,它实现了`IConfigurationBuilder`接口，接口定义如下：
```
public interface IConfigurationBuilder
{
    IDictionary<string, object> Properties { get; }
    IList<IConfigurationSource> Sources { get; }
    IConfigurationBuilder Add(IConfigurationSource source);
    IConfigurationRoot Build();
}
```

获取配置示例代码：
```
IConfiguration configuration = new ConfigurationBuilder()
    .AddCommandLine(args)
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();
```

> 为了方便使用，这里的`AddCommandLine`、`AddJsonFile`、`AddEnvironmentVariables`方法都是各自数据源提供的`IConfigurationBuilder`的扩展方法

## 自定义数据库配置数据源

接下来实现一个已数据库为数据源的配置源，通过上面的分析我们知道了要实现一个自定义配置源的主要工作：
1. 定义数据源类，实现`IConfigurationSource`接口
2. 定义对应的配置提供者，实现`IConfigurationProvider`接口
3. 提供一个`IConfigurationBuilder`扩展方法，将配置源添加进配置构建器中

