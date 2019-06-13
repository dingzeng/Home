---
title: Redis命令之Lists
date: 2016-11-29
categories:
- notes
tags:
- redis
---

# Lists
Redis的Lists是通过链表来实现的，有许多应用场景，可以用来存储字符串集合、作为分布式消息队列等

## LINDEX key index
- 获取索引对应的元素
```
redis> LPUSH mylist "World"
(integer) 1
redis> LPUSH mylist "Hello"
(integer) 2
redis> LINDEX mylist 0
"Hello"
redis> LINDEX mylist -1
"World"
redis> LINDEX mylist 3
(nil)
redis>
```


## LINSERT key BEFORE|AFTER pivot value
- 在指定元素前/后插入新元素
- pivot参数为列表中元素的value,不是索引,如果列表中存在多个pivot，只在第一个前/后插入
```
redis> RPUSH mylist "Hello"
(integer) 1
redis> RPUSH mylist "World"
(integer) 2
redis> LINSERT mylist BEFORE "World" "There"
(integer) 3
redis> LRANGE mylist 0 -1
1) "Hello"
2) "There"
3) "World"
redis> 
```

## LLEN key
- 获取列表的长度
```
redis> LPUSH mylist "World"
(integer) 1
redis> LPUSH mylist "Hello"
(integer) 2
redis> LLEN mylist
(integer) 2
redis> 
```

## LPOP key
- 移除并返回列表中的第一个元素
```
redis> RPUSH mylist "one"
(integer) 1
redis> RPUSH mylist "two"
(integer) 2
redis> RPUSH mylist "three"
(integer) 3
redis> LPOP mylist
"one"
redis> LRANGE mylist 0 -1
1) "two"
2) "three"
redis>
```

## LPUSH key value [value ...]
- 列表前面Push一个值
```
redis> LPUSH mylist "world"
(integer) 1
redis> LPUSH mylist "hello"
(integer) 2
redis> LRANGE mylist 0 -1
1) "hello"
2) "world"
redis> 
```

## LRANGE key start stop
- 获取列表指定范围内的元素集合
```
redis> RPUSH mylist "one"
(integer) 1
redis> RPUSH mylist "two"
(integer) 2
redis> RPUSH mylist "three"
(integer) 3
redis> LRANGE mylist 0 0
1) "one"
redis> LRANGE mylist -3 2
1) "one"
2) "two"
3) "three"
redis> LRANGE mylist -100 100
1) "one"
2) "two"
3) "three"
redis> LRANGE mylist 5 10
(empty list or set)
redis> 
```

## LREM key count value
- 移除列表中的元素
- count:移除数量，正数从前往后数，负数从后往前数，0为全部
- value:用来比较的值
```
redis> RPUSH mylist "hello"
(integer) 1
redis> RPUSH mylist "hello"
(integer) 2
redis> RPUSH mylist "foo"
(integer) 3
redis> RPUSH mylist "hello"
(integer) 4
redis> LREM mylist -2 "hello"
(integer) 2
redis> LRANGE mylist 0 -1
1) "hello"
2) "foo"
redis>
```

## LSET key index value
- 设置列表指定位置的值
- 索引参数超过范围时报错
```
redis> RPUSH mylist "one"
(integer) 1
redis> RPUSH mylist "two"
(integer) 2
redis> RPUSH mylist "three"
(integer) 3
redis> LSET mylist 0 "four"
"OK"
redis> LSET mylist -2 "five"
"OK"
redis> LRANGE mylist 0 -1
1) "four"
2) "five"
3) "three"
redis> 
```


## LTRIM key start stop
- trim存在的列表，只保留指定的范围
```
redis> RPUSH mylist "one"
(integer) 1
redis> RPUSH mylist "two"
(integer) 2
redis> RPUSH mylist "three"
(integer) 3
redis> LTRIM mylist 1 -1
"OK"
redis> LRANGE mylist 0 -1
1) "two"
2) "three"
redis> 
```

## RPOP key
- 尾部弹出

## RPUSH key value [value ...]
- 尾部push