---
title: Redis命令之String
date: 2016-11-25
categories:
- notes
tags:
- redis
---

# Binary-safe strings

## APPEND key
- 如果`key`存在且是一个字符串类型，这个命令将`value`附加到字符串的末端，如果`key`不存在，将创建它并设置为空字符串，再附加到末端，所以`APPEND`类似于特殊的`SET`
- 返回一个表示最终字符串长度的整型

```
redis> EXISTS mykey
(integer) 0
redis> APPEND mykey "Hello"
(integer) 5
redis> APPEND mykey " World"
(integer) 11
redis> GET mykey
"Hello World"
redis> 
```

##   GET key
- 获取指定`key`的值，如果key不存在则返回`nil`，如果存储的值不是字符串类型，因为`GET`命令只处理字符串类型的值
- 返回最终的字符串

```
redis> GET nonexisting
(nil)
redis> SET mykey "Hello"
OK
redis> GET mykey
"Hello"
redis> 
```

## SET key
- 设置`key`指向字符串`value`，如果key已经存在将覆盖它，不管它的类型是什么
- 选项
    - EX seconds : 过期秒数
    - PX milliseconds : 过期毫秒数
    - NX : 只允许key不存在时执行
    - XX : 只允许key存在时执行
- 执行成功时返回`OK`，失败时返回`nil`

```
redis> SET mykey "Hello"
OK
redis> GET mykey
"Hello"
redis>
```

## SETRANGE key offset value
- 设置key指向的字符串指定范围的值
- 当指定的偏移量大于原来字符串的长度时填充二进制`0`

```
redis> SET key1 "Hello World"
OK
redis> SETRANGE key1 6 "Redis"
(integer) 11
redis> GET key1
"Hello Redis"
redis>
```

```
redis> SETRANGE key2 6 "Redis"
(integer) 11
redis> GET key2
"\u0000\u0000\u0000\u0000\u0000\u0000Redis"
redis>
```

## DECR key
- 将指定的key指向的value减1，当key不存在时设置一个value为0的再减1
- 支持64位有符号数值
- 执行成功返回减1后的值，value不是字符串或字符串不能表示数值或数值超出范围时将报错

```
OK
redis> DECR mykey
(integer) 9
redis> SET mykey "234293482390480948029348230948"
OK
redis> DECR mykey
ERR value is not an integer or out of range
redis> 
```

## DECRBY key decrement
- 指定key的value自减`decrement`

```
redis> SET mykey "10"
OK
redis> DECRBY mykey 3
(integer) 7
redis>
```

## INCR key
- 自增

```
redis> SET mykey "10"
OK
redis> INCR mykey
(integer) 11
redis> GET mykey
"11"
redis> 
```

## INCRBY key increment
- 指定key的value自减`increment`

```
redis> SET mykey "10"
OK
redis> INCRBY mykey 5
(integer) 15
redis>
```

## GETRANGE key start end
- 获取指定范围的字符串，version 2.0之后由`SUBSTR`改为了`GETRANGE`
- start、end表示字符串截取的偏移量,正数表示从开始计算，负数表示从结尾计算
- 截取返回的字符串包含`start`、`end`位置的字符

```
redis> SET mykey "This is a string"
OK
redis> GETRANGE mykey 0 3
"This"
redis> GETRANGE mykey -3 -1
"ing"
redis> GETRANGE mykey 0 -1
"This is a string"
redis> GETRANGE mykey 10 100
"string"
redis> 
```

## MGET key[key,...]
- 获取多个key的字符串

```
redis> SET key1 "Hello"
OK
redis> SET key2 "World"
OK
redis> MGET key1 key2 nonexisting
1) "Hello"
2) "World"
3) (nil)
redis>
```

## MSET key value[key value,...]
- 设置多个key的字符串

```
redis> MSET key1 "Hello" key2 "World"
OK
redis> GET key1
"Hello"
redis> GET key2
"World"
redis>
```