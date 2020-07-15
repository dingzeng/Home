---
title: 设计模式-工厂方法模式
categories:
- notes
tags:
- design-pattern
---

工厂方法模式，定义一个用于创建对象的接口，让子类决定实例化哪一个类。工厂方法使一个类的实例化延迟到其子类。

下面通过一个计算器的程序来说明工厂方法模式：

```
public abstract class OperatorBase
{
    public abstract double Calculate(double number1, double number2);
}

public class OperatorAdd : OperatorBase
{
    public override double Calculate(double number1, double number2)
    {
        return number1 + number2;
    }
}

public class OperatorSubstruct : OperatorBase
{
    public override double Calculate(double number1, double number2)
    {
        return number1 - number2;
    }
}

/*Factory*/

public interface OperatorFactory
{
    OperatorBase CreateOperator();
}

public class AddOperatorFactory : OperatorFactory
{
    public OperatorBase CreateOperator()
    {
        return new OperatorAdd();
    }
}

public class SubstructFactory : OperatorFactory
{
    public OperatorBase CreateOperator()
    {
        return new OperatorSubstruct();
    }
}
```

客户端代码：
```
void Main()
{
    var addOpt = new AddOperatorFactory().CreateOperator();

    addOpt.Calculate(1, 2);
}
```