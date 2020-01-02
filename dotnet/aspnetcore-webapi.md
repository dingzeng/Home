# ASP.NET Core WebAPI

## 服务端管道模型
- IHttpRoute
```
public interface IHttpRoute
{
    IDictionary<string, object> Constraints { get; }
    IDictionary<string, object> DataTokens { get; }
    IDictionary<string, object> Defaults { get; }
    string RouteTemplate { get; }
    IHttpRouteData GetRouteData(string virtualPathRoot, HttpRequestMessage request);
    IHttpVirtualPathData GetVirtualPath(HttpRequestMessage request, IDictionary<string, object> values);
}
```
- HttpRouteCollection
```
public class HttpRouteCollection : ICollection<IHttpRoute>, IEnumerable<IHttpRoute>, IEnumerable, IDisposable
{
    //
}
```
- RouteData
```
public class RouteData
{
    public RouteData();
    public RouteData(RouteBase route, IRouteHandler routeHandler);
    public RouteValueDictionary DataTokens { get; }
    public RouteBase Route { get; set; }
    public IRouteHandler RouteHandler { get; set; }
    public RouteValueDictionary Values { get; }
    public string GetRequiredString(string valueName);
}
```
- HttpMessageHandler
```
public abstract class HttpMessageHandler : IDisposable
{
    protected HttpMessageHandler();
    public void Dispose();
    protected virtual void Dispose(bool disposing);
    protected internal abstract Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
}
```
- DelegatingHandler
```
public abstract class DelegatingHandler : HttpMessageHandler
{
    protected DelegatingHandler();
    protected DelegatingHandler(HttpMessageHandler innerHandler);
    public HttpMessageHandler InnerHandler { get; set; }
    protected override void Dispose(bool disposing);
    protected internal override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
}
```
- HttpControllerDispatcher
```
public class HttpControllerDispatcher : HttpMessageHandler
{
    public HttpControllerDispatcher(HttpConfiguration configuration);
    public HttpConfiguration Configuration { get; }
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
}
```
- HttpServer
```
public class HttpServer : DelegatingHandler
{
    public HttpServer(HttpConfiguration configuration);
    public HttpServer(HttpMessageHandler dispatcher);
    public HttpServer(HttpConfiguration configuration, HttpMessageHandler dispatcher);
    public HttpConfiguration Configuration { get; }
    public HttpMessageHandler Dispatcher { get; }
    protected override void Dispose(bool disposing);
    protected virtual void Initialize();
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
}
```
- HttpRequestMessage 
```
public class HttpRequestMessage : IDisposable
{
    public HttpRequestMessage();
    public HttpRequestMessage(HttpMethod method, Uri requestUri);
    public HttpRequestMessage(HttpMethod method, string requestUri);
    public HttpContent Content { get; set; }
    public HttpRequestHeaders Headers { get; }
    public HttpMethod Method { get; set; }
    public IDictionary<string, object> Properties { get; }
    public Uri RequestUri { get; set; }
    public Version Version { get; set; }
    public void Dispose();
    public override string ToString();
    protected virtual void Dispose(bool disposing);
}
```
- HttpResponseMessage
```
public class HttpResponseMessage : IDisposable
{
    public HttpResponseMessage();
    public HttpResponseMessage(HttpStatusCode statusCode);
    public HttpContent Content { get; set; }
    public HttpResponseHeaders Headers { get; }
    public bool IsSuccessStatusCode { get; }
    public string ReasonPhrase { get; set; }
    public HttpRequestMessage RequestMessage { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public Version Version { get; set; }
    public void Dispose();
    public HttpResponseMessage EnsureSuccessStatusCode();
    public override string ToString();
    protected virtual void Dispose(bool disposing);
}
```
- HttpControllerHander
```
public class HttpControllerHandler : HttpTaskAsyncHandler
{
    public HttpControllerHandler(RouteData routeData);
    public HttpControllerHandler(RouteData routeData, HttpMessageHandler handler);
    public override Task ProcessRequestAsync(HttpContext context);
}
```
- HttpConfiguration
```
public class HttpConfiguration : IDisposable
{
    public HttpConfiguration();
    public HttpConfiguration(HttpRouteCollection routes);
    public IDependencyResolver DependencyResolver { get; set; }
    public HttpFilterCollection Filters { get; }
    public MediaTypeFormatterCollection Formatters { get; }
    public IncludeErrorDetailPolicy IncludeErrorDetailPolicy { get; set; }
    public Action<HttpConfiguration> Initializer { get; set; }
    public Collection<DelegatingHandler> MessageHandlers { get; }
    public ParameterBindingRulesCollection ParameterBindingRules { get; }
    public ConcurrentDictionary<object, object> Properties { get; }
    public HttpRouteCollection Routes { get; }
    public ServicesContainer Services { get; }
    public string VirtualPathRoot { get; }
    public void Dispose();
    public void EnsureInitialized();
    protected virtual void Dispose(bool disposing);
}
```

## 控制器的激活
- HttpControllerDescriptor
```
public class HttpControllerDescriptor
{
    public HttpControllerDescriptor();
    public HttpControllerDescriptor(HttpConfiguration configuration, string controllerName, Type controllerType);
    public HttpConfiguration Configuration { get; set; }
    public string ControllerName { get; set; }
    public Type ControllerType { get; set; }
    public virtual ConcurrentDictionary<object, object> Properties { get; }
    public virtual IHttpController CreateController(HttpRequestMessage request);
    public virtual Collection<T> GetCustomAttributes<T>() where T : class;
    public virtual Collection<T> GetCustomAttributes<T>(bool inherit) where T : class;
    public virtual Collection<IFilter> GetFilters();
}
```
- IHttpController
```
public interface IHttpController
{
    Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken);
}
```
- IHttpControllerActivator
```
public interface IHttpControllerActivator
{
    IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType);
}
```
- IHttpControllerTypeResolver
```
public interface IHttpControllerTypeResolver
{
    ICollection<Type> GetControllerTypes(IAssembliesResolver assembliesResolver);
}
```
- IAssembliesResolver
```
public interface IAssembliesResolver
{
    ICollection<Assembly> GetAssemblies();
}
```
- IHttpControllerSelector
```
public interface IHttpControllerSelector
{
    IDictionary<string, HttpControllerDescriptor> GetControllerMapping();
    HttpControllerDescriptor SelectController(HttpRequestMessage request);
}
```

## 控制器的执行

## Action的选择

## Model元数据解析

- ModelMetadata
- ModelMetadataProvider
- ModelValidator
- ModelValidatorProvider

## Logging
ASP.NET Core 包含一些日志API，它们可以在多个日志提供者下工作，内建的提供者允许你发送日志到一个或更多的目的地，而且可以插入第三方的日志框架，这篇文章介绍怎样使用内建的日志API和提供者。

> 本篇文章基于ASP.NET Core 1.x编写，更多关于ASP.NET Core 2.0 的变更，见 [https://docs.microsoft.com/en-us/aspnet/core/aspnetcore-2.0#logging-update](https://docs.microsoft.com/en-us/aspnet/core/aspnetcore-2.0#logging-update)

## 怎样添加日志提供者
一个日志提供者用来在日志数据上完成一些操作的执行，例如将它显示在控制台或存储在Azure中。去使用一个提供者，你需要安装它的NuGet包，然后在 `ILogFactory`实例上调用它的扩展方法，下面是一个例子：
```
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    loggerFactory.AddDebug();
}
```

