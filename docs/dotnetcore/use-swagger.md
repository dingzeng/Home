# 在ASP.NET Core中使用Swagger生成API文档

该工具可以基于我们的代码生成Swagger标准的JSON数据，并内置了一个好看的UI用来显示我们的API,还可以直接将它作为测试客户端进行接口测试

## 基础用法

1.在WebApi项目中安装所需要的依赖

```
Install-Package Swashbuckle.AspNetCore -Version 5.5.0
```
or
```
dotnet add package --version 5.5.0 Swashbuckle.AspNetCore
```

2.在`ConfigureServices `方法中注册Swagger的生成器，定义Swagger文档
```C#
services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "use-swagger demo1",
        Version = "v1",
        Description = "use-swagger description1"
    });
});
```

3.确保Action和参数有明确的`Http*`、`From*`绑定
```C#
[HttpPost]
public void CreateProduct([FromBody]Product product)
```

4.在`Configure`方法中添加中间件，暴露出Swagger JSON数据
```C#
app.UseSwagger(options =>
{
    options.RouteTemplate = "{documentName}/swagger.json";
});
```

5.添加UI中间件
```C#
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/v1/swagger.json", "API V1");
});
```

## 扩展阅读
- [https://swagger.io/](https://swagger.io/)
- [https://swagger.io/specification/](https://swagger.io/specification/)
- [好RESTful API的设计原则](https://www.cnblogs.com/moonz-wu/p/4211626.html)
- [https://github.com/domaindrivendev/Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)