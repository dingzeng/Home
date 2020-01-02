
Docker介绍
==========

容器是继虚拟机之后一个新的虚拟化技术，相比传统的虚拟机，Docker有如下这些优势：
- Docker不需要模拟硬件和完整的操作系统，资源占用更少
- 启动更快——秒级甚至毫秒级别
- 提供应用程序一致的运行环境，不管是开发、测试还是生产环境，应用都是运行在相同的容器中
- 使得应用和服务能更方便的部署、更新和扩容

# 基本概念

## 1.镜像 *Image*

镜像可以简单理解为一个特殊的文件系统，其中包含程序运行所需的文件，类比虚拟机中的系统镜像文件。
镜像有一个非常重要的概念叫“分层存储”，指的是在构建镜像时，每个构建动作都是基于上一层的镜像进行，而且每一层镜像构建完后都是不可改变的，即使在本层镜像构建的时候删除了上一层的文件，也只是在本层中表示该文件被删除，而实际上还是存在于上一层的镜像中的。

## 2.容器 *Container*

容器是基于镜像创建的具体运行实例，创建容器时会在所使用的镜像的文件系统基础上附加一层可读写的容器存储层，用于容器内进程的使用，容器存储层的数据在容器删除后就丢失了，因此不应该在容器存储层中写入应该持久化的数据，而是应该使用数据卷(Volume)挂载到宿主机上。

## 3.仓库 *Repository*

为了能方便的在多个机器上使用我们构建的镜像，需要一个容器注册中心(Docker Registry)的服务，用来保存我们构建的镜像，如公共注册中心：[hub.docker.com](https://hub.docker.com/)，它存储了全球大量的优质镜像，当然我们也可以搭建自己的私有镜像注册中心。

一个注册中心包含多个仓库，每个仓库对应“一个”镜像，每个仓库可以有多个标签，每个标签对应某个具体版本的镜像，这里的Repository、Tag和Git很相似。假如有个一仓库的名字叫 `ubuntu`，其中包含一个标签 `16.04`，那么我们可以用 `ubuntu:16.04` 来表示这个确定版本的镜像，当不指定标签的情况下默认为`latest`，即视为 `ubuntu:latest`。

**国内镜像加速器：**
- [DaoCloud](https://www.daocloud.io/mirror)
- [阿里容器镜像服务](https://cr.console.aliyun.com)

**搭建私有镜像注册中心的方案：**
- 使用官方开源的 [Docker Registry](https://hub.docker.com/_/registry)
- [HARBOR](https://goharbor.io/) (推荐)
- [sonatype](https://www.sonatype.com/)

# Ubuntu下安装Docker

> [https://yeasy.gitbooks.io/docker_practice/content/install/ubuntu.html](https://yeasy.gitbooks.io/docker_practice/content/install/ubuntu.html)

# 基本命令

## 镜像操作

### 获取镜像
格式：
`docker pull [仓库服务地址/]NAME[:TAG|@DIGEST]`

Options:
```
-a, --all-tags  下载所有标签
-q, --quiet     禁止冗长的输出   
```

获取镜像使用的标识格式和git的仓库格式很像:
- Git       https://github.com/dingzeng/Home.git
- Docker    https://hub.docker.com/library/ubuntu:latest

|服务地址|用户名|仓库名|标签|
---|:--:|:--:|---:
https://github.com|dingzeng|Home|
https://hub.docker.com|library|ubuntu|latest

获取镜像时可以指定一个镜像的名字，会默认从Docker Hub服务上下载，默认使用library作为用户名，latest作为默认标签

### 查看镜像列表
格式：  
`docker image ls [OPTIONS] [REPOSITORY[:TAG]]`

Options:
```
-a, --all               显示所有镜像（默认隐藏中间层镜像）
    --digests           显示摘要
-f, --filter filter     过滤输出，since、before、label
    --format string     格式化输出
-q, --quiet             只显示镜像编码
```

### 删除一个或多个镜像
格式：  
`docker image rm [OPTIONS] IMAGE [IMAGE...]`

Options:
```
-f, --force     强制删除
    --no-prune  不删除没有标签的镜像
```
Notes:
1. 可以同时删除多个镜像
2. 删除镜像时可以指定镜像名、ID和摘要
3. rm操作不一定发生删除行为：
    - 当镜像被容器依赖时；
    - 当镜像被其它镜像依赖时；
    - 删除实际上是删除镜像的某个标签，当该镜像下还有标签时，该镜像没有实际被删除；

### 删除空镜像
格式：  
`docker image prune`

Options:
```
-a, --all   删除所有未使用的镜像
-f, --force 强制删除
```

## 使用commit定制镜像
格式：
`docker commit [OPTIONS] CONTAINER [REPORITORY:[TAG]]`

Options:
```
-a, --author    指定作者
-m, --message   指定提交消息
```

Notes:
commit用于理解镜像的构建过程非常有用，但是不要通过commit的方式构建你有用的镜像，清使用Dockfile文件进行构建，因为基于容器构建的镜像是一个黑匣子，后面没有人能知道它是怎么构建而来的。

## 使用Dockerfile文件构建镜像
格式：
`docker build [OPTIONS] PATH | URL | -`

Options:
```
-f, --file      Dockerfile文件名，默认为：Context/Dockerfile
-t, --tag       ‘name:tag’,指定镜像的名字和标签
```

Notes:
1.docker build实际上是调用Docker Enginer提供的Remote API进行构建的，最后的路径是`构建上下文`的路径，而不是Dockerfile的文件路径；
2.Dockerfile文件中的COPY等指令使用的是相对构建上下文的相对路径；

### 1.COPY 复制文件
格式：
- `COPY `

docker system df
docker history IMAGE