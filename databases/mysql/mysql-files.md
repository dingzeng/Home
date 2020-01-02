Mysql中的各种文件
================

# 参数文件

## 什么是参数文件？
存储Mysql实例启动和运行所需的参数信息，是key-value的文本文件
可以使用下面的命令查看mysql配置文件的存储位置：
```
mysql --help | grep my.cnf
```

## 参数类型
1. 动态参数，允许允许过程中修改
2. 静态参数，实例启动后不允许修改，相当于只读参数

## 参数有效范围
1. 会话(@@session)，当前会话有效
2. 全局(@@global)，当前实例有效
3. 持久，文件中的参数，实例重启后始终有效

## 查看参数
1. show variables like 'keyword'\G;
2. use information_schema;select * from global_variables where variable_name like 'keyword'\G;
3. select [@@global. | @@session.]variable_name;
4. vim */my.cnf

## 设置参数
1. set [@@global. | @@session.]variable_name;
2. vim */my.cnf

# 日志文件

## 错误日志
错误日志记录mysql实例在启动、运行和停止时的错误、警告信息，当数据库无法启动时首先要查看错误日志文件
错误日志文件的文件位置在参数文件中的key为log_error的参数指定

## 慢查询日志
### 相关参数
1. log_slow_queries
2. long_query_time
3. slow_query_log_file
4. log_queries_not_using_indexes
5. log_output

### 查询慢查询日志
1. mysqldumpslow
2. select * from mysql.slow_log;
3. tial */*-slow.log

## 查询日志
### 相关参数
1. general_log
2. general_log_file

### 查询查询日志
1. select * from mysql.general_log;
2. tail */*.log

### binlog
### 相关参数
- **max_binlog_size**
binlog文件的最大存储空间，默认1G，当超过该值时生成一个新的文件
- **binlog_cache_size**
binlog缓冲大小，默认32KB，在使用事务的存储引擎中(InnoDB)，未提交的数据修改先将binlog写到一个缓冲文件中，事务提交后才写到真实的binlog文件
- **binlog_format**
binlog文件的格式，取值范围为：STATEMENT、ROW、MIXED

### 查询binlog
mysqlbinlog [options] log_files

## 套接字文件
不懂。。。
show variables like 'socket'

## pid文件
存储mysql进程Id的文件
select @@global.pid_file;

## 表结构定义文件
每个表、视图都有一个.frm文件记录