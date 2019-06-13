---
title: Redis实现的分布式锁
date: 2017-11-10
categories:
- notes
tags:
- redis
- distributed-lock
---

在高并发的分布式系统中，很大可能需要使用到分布式锁，来解决共享资源在同一时间段内被单一线程占有的问题

## 参考文章
[https://www.oschina.net/translate/redis-distlock](https://www.oschina.net/translate/redis-distlock)

## 锁的封装
```
public class Redislock
{
    /// <summary>
    /// Redis Key
    /// </summary>
    private string _redisKey;

    /// <summary>
    /// 锁的唯一标识
    /// </summary>
    private string _identity;

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="lockParams">锁范围参数</param>
    public Redislock(params object[] lockParams)
    {
        if (lockParams == null || lockParams.Length == 0)
        {
            throw new ArgumentNullException(nameof(lockParams));
        }

        _identity = Guid.NewGuid().ToString();
        _redisKey = string.Format("common.lock.{0}", string.Join("-", lockParams));
    }

    private IDatabase GetRedis()
    {
        var connect = ConnectionMultiplexer.Connect(new ConfigurationOptions()
        {

        });

        return connect.GetDatabase();
    }

    /// <summary>
    /// 设置阻塞
    /// </summary>
    /// <param name="sleepTime">等待时间</param>
    /// <param name="expiredSecond">缓存key的过期时间（秒）</param>
    public void SetBlock(TimeSpan sleepTime, int expiredSecond = 2)
    {
        var redis = GetRedis();
        var expiry = TimeSpan.FromSeconds(expiredSecond);

        while (redis.StringSet(_redisKey, _identity, expiry, When.NotExists))
        {
            Thread.Sleep(sleepTime);
        }
    }

    /// <summary>
    /// 释放锁
    /// </summary>
    /// <returns></returns>
    public bool Release()
    {
        var redis = GetRedis();

        var val = redis.StringGet(_redisKey);
        if (val == _identity)
        {
            return redis.KeyDelete(_redisKey);
        }

        return false;
    }
}
```

## 使用锁
```
Redislock redisLock = new Redislock("p1", "p2");
redisLock.SetBlock(TimeSpan.FromSeconds(1));

try
{
    // DO Something

}
catch (Exception)
{

    throw;
}
finally
{
    redisLock.Release();
}
```

## 说明
- 实例化一个锁对象时，需要传递一些参数，用来拼接一个Redis的Key，要保证锁的Key不要有冲突；
- `SetBlock` 方法用来获取锁，只有当Key不存在时才可以成功获取到锁，锁失败时将等待，直至获取到，我们需要给定一个相对合适的等待时间；
- `Release` 方法用来在操作执行完成后，释放掉锁，即删除对应的Key，而在删除前会判断Key保存的值是否为实例化锁对象时生成的唯一标识，保证释放的安全性；
