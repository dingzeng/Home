---
title: 设计模式-建造者模式
date: 2017-12-28
categories:
- notes
tags:
- design-pattern
---

建造者模式将一个复杂对象的构建与它的表示分离，使得同样的构建过程可以创建不同的表示

下面通过创建一个Http请求报文建造者来演示该设计模式的基本用法:

```
public class DefaultHttpRequestBuilder
{
    private HttpMethod _method = HttpMethod.Get;
    private string _url;
    private IDictionary<string, string> _headers = new Dictionary<string, string>();
    private string _body;

    public DefaultHttpRequestBuilder Method(HttpMethod method)
    {
        _method = method;
        return this;
    }

    public DefaultHttpRequestBuilder Url(string url)
    {
        _url = url;
        return this;
    }

    public DefaultHttpRequestBuilder Header(string key, string value)
    {
        if (_headers.ContainsKey(key))
        {
            _headers[key] = value;
        }
        else
        {
            _headers.Add(key, value);
        }

        return this;
    }

    public DefaultHttpRequestBuilder Body(string body)
    {
        _body = body;
        return this;
    }

    public byte[] Build()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"{_method} {_url} HTTP/1.1");

        foreach (var item in _headers)
        {
            if (!string.IsNullOrEmpty(item.Value))
            {
                stringBuilder.AppendLine($"{item.Key}: {item.Value}");
            }
        }

        stringBuilder.AppendLine();

        if (!string.IsNullOrEmpty(_body))
            stringBuilder.Append(_body);

        return Encoding.UTF8.GetBytes(stringBuilder.ToString());
    }
}
```

当需要一个Http请求报文的对象时，用户不需要关心对象建造的具体细节，只需要告诉建造者一些关键的参数:

```
static void Main(string[] args)
{
    var request = new DefaultHttpRequestBuilder()
        .Method(HttpMethod.Get)
        .Url("http://www.baidu.com")
        .Header("Connection", "keep-alive")
        .Build();

    var content = Encoding.UTF8.GetString(request);
    Console.Write(content);
}
```

输出如下:
```
GET http://www.baidu.com HTTP/1.1
Connection: keep-alive

```

为了简化建造对象时的写法，建造对象的方法返回对象本身，是链式编程的一种写法。