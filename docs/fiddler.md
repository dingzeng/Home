
# Fiddler

在使用Fiddler对.NET程序中进行的HTTP请求进行抓包时，发现不能监视到请求响应信息，需要在应用配置文件中添加如下配置：

```XML
<system.net>
  <defaultProxy>
    <proxy proxyaddress="http://127.0.0.1:8888" />      
  </defaultProxy>
</system.net>
```
