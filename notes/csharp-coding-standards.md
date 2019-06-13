---
title: C#编码标准和命名规范
date: 2016-12-12
categories:
- standard
tags:
- C#
---

建立编码标准和命名规范的直接目的是保持代码可读性和可维护性，而可读性和可维护性对软件质量、开发效率有着至关重要的作用;
本文档主要依据微软官方编码规范，并参考几个优秀开源框架的源码风格整理而成;

## 1.类成员在文件中的顺序
0. 静态成员
1. 私有字段
2. 构造函数
3. 公有属性
4. 共有方法
5. 私有方法

**下面的代码片段只演示各类成员在类中的编排顺序，并不演示注释方式**
```
public class ProductController
{
    //0. 静态成员
    public static int StaticField1;
    public static int StaticField2;

    //1. 私有字段
    private readonly IProductService _productService;

    // 2. 构造函数
    public ProductController()
    {

    }

    //3. 公有属性
    public int PublicProperty;

    //4. 共有方法
    public void Publish()
    {

    }

    //5. 私有方法
    private void PrivateMethod()
    {

    }
}
```

## 2.命名规范
- 类名称采用`PascalCasing`风格

```
//正确
public class HomeController
{

}
```
```
//错误
public class homeController
{

}
```
- 方法参数和局部变量采用`camelCasing`风格

```
//正确
public void LoadProductPage(int pageIndex, int pageSize)
{
    var productList = new List<Product>();

    //do something
}
```
```
//错误
public void LoadProductPage(int PageIndex, int PageSize)
{
    var ProductList = new List<Product>();

    //do something
}
```

- 避免使用单词缩写，除非它非常通用

```
//错误
UserGroup userGrp = new UserGroup();
ProductDocument productDoc = new ProductDocument();

//正确
UserGroup userGroup = new UserGroup();
ProductDocument productDocument = new ProductDocument();

//例外
int productId = 1;//Id = Identity
XmlDocument xmlDocument = new XmlDocument();//xml = Extensive Markup Language
```

- 除了私有字段使用下划线以外，其它任何名称都不得使用下划线

```
//正确
public class OrderService
{
    private readonly OrderRepository _orderRepository;
    private readonly LogRepository _logRepository;

    //...
}

//错误:参数
public void SubmitOrder(Order _order)
{
    //do something
}

//错误:参数&局部变量
public void CancelOrder(int _orderId)
{
    var _order = GetOrderById(_orderId);

    //do something
}
```

- 使用预定义的类型名称，而不要使用系统类型名

```
//正确
int orderId = 1;
string number = "D16121101234";
bool isSuccess = false;

//错误
Int32 orderId = 1;
String number = "D16121101234";
Boolean isSuccess = false;
```

- 除原生类型(int、string、DateTime etc)外，请使用`var`来声明局部变量

```
int pageIndex = 1;
bool isOpen = false;
string sometext = "";

var order = GetOrderById(orderId);
var product = new Product();
```

- 使用名词或名词短语去命名一个类名

```
public class ServiceProvider
{

}

public class PriceFormatter
{

}
```

- 使用名词或形容词去命名一个接口名，并带上前缀`I`

```
public class IUserService
{

}

public class IEnumerable
{

}
```
- 方法名称使用动词做前缀，如：

```
public void SubmitOrder() { }

public void CancelOrder() { }

public void GetOrderById() { }

public void LoadOrders() { }

public void QueryOrders() { }

public void ParseDateFormater() { }

public void InsertDocument() { }

public void DeleteDocument() { }

public void UpdateDocument() { }

public void CalculatePrice() { }

public void HasChild() { }

public void IsOver() { }
```
- 源文件使用文件中的主要类型名称，除非是分部类
- 命名空间
    - 格式：`{公司名称}.{项目名称}.{程序集名称}.{文件夹名称1}.{文件夹名称2}.*`，如`Wolianw.Erp.Servcie.Catalog`
    - 命名空间与文件所在文件夹层次及名称保持一致，扩展方法除外
    - 命名空间层次结构保持在6层以内，及文件夹不要超过3层

## 3.异常处理
- 一定**不要**catch了异常而什么都不做！

```
try
{
    //do something
}
catch (Exception)
{

}
```
- 应用程序最外层需**要有**全局异常处理，包括错误日志记录和输出友好提示
- 函数开始**要有**参数检查，检查不通过直接抛出相应异常

```
public void PublishProduct(Product product)
{
    if (product == null)
        throw new ArgumentNullException("product");

    //do publish
}
```

## 4.注释
- 保持适度的注释，注意简明扼要
- 方法必须提供XML注释，说明函数用途、所需参数的意义和返回值
- 使用任务列表标记
    - TODO
    - HACK
    - UNDONE

## 5.正确使用#region
- 按类成员的类型划分region，如：Constants(常量)、Fields(私有只读字段)、Ctors(构造函数)、Methods(公共方法)、Utilities(私有方法) etc
- 尽量不要在Region中嵌套Region，需要嵌套时要清晰的划分
- 不要一个方法一个region，首先方法是可以折叠的，其次那多半是方法太长了，需要拆分

**如下所示**
![region](http://p1.bpimg.com/1949/b29bd0eec627c9ba.png)
## 6.花括弧
- 另起一行保持垂直对齐
- 括弧内只有一行语句时花括弧不需要

```
//正确
public class BaseController
{
    public BaseController()
    {
        if (true)
        {
            //do something
        }

        //省略只包含一条语句的花括弧有更好的可读性
        if (false)
            throw new Exception();
    }
}

//错误
public class AdminController{
    public AdminController(){
        if (true){
            //do something
        }
    }
}
```