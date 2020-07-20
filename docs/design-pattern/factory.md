# 简单工厂模式

简单工厂模式,工厂类中包含了必要的逻辑判断，根据客户端的选择条件动态的实例化相关的类，对于客户端来说，去除了与具体产品的依赖

下面通过一个计算器的程序来说明简单工厂模式：
**面向过程方案**
```C#
Console.WriteLine("请输入第一个数字：");
int number1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("请输入操作符：");
string operatorChar = Console.ReadLine();

Console.WriteLine("请输入第二个数字：");
int number2 = Convert.ToInt32(Console.ReadLine());

object result;
switch (operatorChar)
{
    case "+":
        result = number1 + number2;
        break;
    case "-":
        result = number1 - number2;
        break;
    case "*":
        result = number1 * number2;
        break;
    case "/":
        result = number1 / number2;
        break;
    default:
        result = "unkonw";
        break;
}

Console.WriteLine("result:" + result);
```

**简单工厂方案**
```C#
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

public class OperatorSubtruct : OperatorBase
{
    public override double Calculate(double number1, double number2)
    {
        return number1 - number2;
    }
}

public class OperatorMultiply : OperatorBase
{
    public override double Calculate(double number1, double number2)
    {
        return number1 * number2;
    }
}

public class OperatorDivide : OperatorBase
{
    public override double Calculate(double number1, double number2)
    {
        if (number2==0)
        {
            throw new Exception();
        }

        return number1 / number2;
    }
}

public class OperatorFactory
{
    public static OperatorBase CreateOperator(string operatorChar)
    {
        switch (operatorChar)
        {
            case "+":
                return new OperatorAdd();
            case "-":
                return new OperatorSubtruct();
            case "*":
                return new OperatorMultiply();
            case "/":
                return new OperatorDivide();
            default:
                throw new Exception();
        }
    }
}
```

客户端代码：
```C#
Console.WriteLine("请输入第一个数字：");
int number1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("请输入操作符：");
string operatorChar = Console.ReadLine();

Console.WriteLine("请输入第二个数字：");
int number2 = Convert.ToInt32(Console.ReadLine());

var opt = OperatorFactory.CreateOperator(operatorChar);
var result = opt.Calculate(number1, number2);

Console.WriteLine("result:" + result);
```