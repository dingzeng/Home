---
title: 设计模式-策略模式
categories:
- notes
tags:
- design-pattern
---

策略模式，它定义了算法家族，分别封装起来，让他们之间可以相互替换，此模式让算法的变化，不会影响到使用算法的客户。

下面将缓存处理的一般方法封装为一个抽象"策略"进行说明
![design-pattern-strategy](http://p1.bqimg.com/1949/1cd52268453a01c5.png)
缓存策略接口：
```
public interface ICacheStrategy
{
    void SetCache(string key, object obj);

    object GetCache(string key);

    // 其它算法
}
```

Redis的缓存策略实现：
```
public class RedisCacheStrategy : ICacheStrategy
{
    public void SetCache(string key, object obj)
    {
        throw new NotImplementedException();
    }
    public object GetCache(string key)
    {
        throw new NotImplementedException();
    }
}

```

Memcached的缓存策略实现：
```
public class MemcachedCacheStrategy : ICacheStrategy
{
    public void SetCache(string key, object obj)
    {
        throw new NotImplementedException();
    }
    public object GetCache(string key)
    {
        throw new NotImplementedException();
    }
}
```

策略上下文:
```
public class CacheContext
{
    private readonly ICacheStrategy _cacheStrategy;

    public CacheContext(ICacheStrategy cacheStrategy)
    {
        _cacheStrategy = cacheStrategy;
    }

    public void Set(string key, string obj)
    {
        if (string.IsNullOrEmpty(key))
            throw new ArgumentNullException(nameof(key));

        if (string.IsNullOrEmpty(obj))
            throw new ArgumentNullException(nameof(obj));

        _cacheStrategy.SetCache(key, obj);
    }

    public object Get(string key)
    {
        if (string.IsNullOrEmpty(key))
            throw new ArgumentNullException(nameof(key));

        return _cacheStrategy.GetCache(key);
    }
}
```

客户端程序：
```
class Program
{
    void Main(string[] args)
    {
        var cacheContext = new CacheContext(new RedisCacheStrategy());
        cacheContext.Set("hello", "world");
    }
}
```