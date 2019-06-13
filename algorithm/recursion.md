---
title: 算法-递归
date: 2016-02-15
categories:
- code-snippet
tags:
- algorithm
---


递归，函数调用函数本身的一种算法

应用一：斐波那契数列(F(0)=0，F(1)=1, F(n)=F(n-1)+F(n-2))
```
private static int Fibonacci(int num)
{
    if (num < 0)
        throw new Exception($"{nameof(num)}不能小于0");

    if (num == 0)
        return 0;

    if (num == 1)
        return 1;

    return Fibonacci(num - 1) + Fibonacci(num - 2);
}

public static void Run()
{
    Console.Write("输入一个数求它的斐波那契数列：");
    num = Convert.ToInt32(Console.ReadLine());
    for (int i = 0; i <= num; i++)
        Console.Write($"{Fibonacci(i)} ");
}
```

![Fibonacci](http://p1.bqimg.com/1949/b12d18178899c944.png)


应用二：求N的阶乘(n!=1×2×3×...×n (0!=1,n!=(n-1)!×n))
```
private static int Factorial(int num)
{
    if (num < 0)
        throw new Exception($"{nameof(num)}不能小于0");

    if (num == 0)
        return 1;

    return Factorial(num - 1) * num;
}

public static void Run()
{
    Console.Write("输入一个数求它的阶乘：");
    var num = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"{num}的阶乘为:{Factorial(num)}");
}

```

![Factorial](http://p1.bqimg.com/1949/2e4ced9ff4b8d270.png)

说明：
- 递归在树结构中广泛使用，用来做树节点的遍历
- 递归需要一个中止条件，不然会出现死循环
- 虽然递归大大简化了程序的编写，但使用不当会有性能问题


