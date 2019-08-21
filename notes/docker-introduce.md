
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
