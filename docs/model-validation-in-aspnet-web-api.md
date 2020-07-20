# ASP.NET中的模型验证

参考：[model-validation-in-aspnet-web-api](https://www.asp.net/web-api/overview/formats-and-model-binding/model-validation-in-aspnet-web-api)
ASP.NET WebAPI中可以使用`DataAnnotations`的方式进行数据模型验证，常用的特性有：

- 必填项验证特性：RequiredAttribute
```
[Required]
public string Name { get; set; }
```

- 指定显示的错误消息：DisplayAttribute
```
[Display(Name = "年龄")]
public int Age { get; set; }
```

- 字符串或数组长度验证特性：MaxLengthAttribute、MinLengthAttribute、StringLengthAttribute
```
[MaxLength(1000)]
[MinLength(50)]
public string Remark { get; set; }

[MaxLength(10)]
public List<int> ProductIds { get; set; }

[StringLength(12, MinimumLength = 6)]
public string LoginName { get; set; }
```

- 范围验证特性：RangeAttribute
```
[Range(0, 100)]
//[Range(0.01, 9.99)]
//[Range(typeof(DateTime), "1990-01-01", "2016-01-01")]
public DateTime Birthday { get; set; }
```

- 电子邮件地址验证特性：EmailAddressAttribute
```
[EmailAddress]
public string Email { get; set; }
```

- 电话号码验证特性：PhoneAttribute
```
[Phone]
public string Phone { get; set; }
```

- Url验证特性：UrlAttribute
```
[Url]
public string Link { get; set; }
```

- 时间戳验证特性：TimestampAttribute
```
[Timestamp]
public int CreateTime { get; set; }
```

- 属性值比较验证特性：CompareAttribute
```
public string NewPassword { get; set; }

[Compare("NewPassword", ErrorMessage = "两次输入的密码不一致")]
public string ConfirmPassword { get; set; }
```

- 数据类型验证特性：DataTypeAttribute
```
[DataType(DataType.Url)]
public int UrlProp { get; set; }

[DataType(DataType.DateTime)]
public DateTime DateTimeProp { get; set; }
```
前面的DataType是DataTypeAttribute类的简写，后面的DataType是一个枚举，定义如下：
```
public enum DataType
{
    Custom = 0,
    DateTime = 1,
    Date = 2,
    Time = 3,
    Duration = 4,
    PhoneNumber = 5,
    Currency = 6,
    Text = 7,
    Html = 8,
    MultilineText = 9,
    EmailAddress = 10,
    Password = 11,
    Url = 12,
    ImageUrl = 13,
    CreditCard = 14,
    PostalCode = 15,
    Upload = 16
}
```

- 枚举类型验证特性：EnumDataTypeAttribute
```
[EnumDataType(typeof(OrderStatus))]
public OrderStatus Status { get; set; }

public enum OrderStatus
{
    WaitingPay,
    Paid,
    Canceled,
    Completed
}
```

- 正则表达式验证特性：RegularExpressionAttribute
```
[RegularExpression("[1-9]d{5}(?!d)")]
public string ZipCode { get; set; }
```

- 自定义验证特性：CustomValidationAttribute
```
[CustomValidation(typeof(MyCustomValidation), "ValidateClass1")]
public class Class1
{
    [CustomValidation(typeof(MyCustomValidation), "ValidateProperty1")]
    public string MyProperty { get; set; }
}

public class MyCustomValidation
{
    public static ValidationResult ValidateClass1(Class1 model)
    {
        bool isValid = true;

        //TODO 添加验证逻辑代码

        if (isValid)
        {
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult("fail");
        }
    }

    public static ValidationResult ValidateProperty1(string value)
    {
        throw new NotImplementedException();
    }
}
```
以上特性都在`System.ComponentModel.DataAnnotations`命名空间中定义，[点击查看](https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.aspx)