# 单例模式

单例模式保证一个类只有一个实例，并提供一个全局访问点

## 懒汉式单例模式

```
public class SingletonA
{
    private static SingletonA instance;
    private static readonly object lockObj = new object();

    private SingletonA()
    {

    }

    public static SingletonA GetInstance()
    {
        if (instance == null)
        {
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = new SingletonA();
                }
            }
        }

        return instance;
    }
}
```

关键点：
- 私有构造函数，保证只能在类内部new对象
- 线程锁保证多线程下的安全
- 双重锁定优化加锁带来的性能问题

## 饿汉式单例模式

```
public sealed class SingletonB
{
    private static readonly SingletonB instance = new SingletonB();

    private SingletonB()
    {

    }

    public static SingletonB GetInstance()
    {
        return instance;
    }
}
```
利用.NET的静态初始化特性实现单例模式