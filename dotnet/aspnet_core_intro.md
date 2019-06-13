---
title: ASP.NET Core 简介(翻译)
date: 2017-12-8
categories:
- translate
tags:
- C#
- ASP.NET
---

原文地址：[https://docs.microsoft.com/en-us/aspnet/core/](https://docs.microsoft.com/en-us/aspnet/core/)

ASP.NET Core是一个为构建现代的、基于云的、互联网应用的跨平台、高性能、开源框架，使用ASP.NET Core，你可以：
- 构建Web应用和服务，Iot应用和移动后端
- 在Windows、macOS、Linux上使用你喜欢的开发工具
- 部署到云上或on-permises（？）
- 运行在.NET Core或.NET Framework上

# 为什么使用ASP.NET Core
数百万开发者已经使用（并且会继续使用）ASP.NET去创建Web应用。ASP.NET Core是对ASP.NET的重新设计，架构变得和模块化。
ASP.NET Core提供了下面这些好处：
- Web界面和接口的构建变得统一
- 集成了现代的客户端框架和开发流程
- 一个云准备的、基于环境的配置系统
- 内置的依赖注入
- 一个轻量的、模块化的HTTP请求管道
- 可以宿主到IIS、或者你自己的进程上
- 可以运行在.NET Core上，which supports true side-by-side app versioning
- 简化现代Web开发的工具
- 可以在Windows、macOS和Linux上进行构建和运行
- 开源和社区关注的

ASP.NET Core整个都作为了NuGet包，着允许你去优化你的应用，只是包含你需要的NuGet包。The benefits of a smaller app surface area include tighter seurity,reduced servicing,and iproved performance.

# 使用ASP.NET Core MVC构建Web接口和界面
ASP.NET Core MVC提供下面这些特性帮助你去构建Web接口和界面应用
- MVC模式使你的应用是可测试的
- Razor Pages是基于页面的编程模型，使你构建Web页面更容易和更有生产力
- Razor syntax为Razor Pages和MVC Views提供一个有生产力的语言
- Tag Helpers在Razor文件创建和渲染时能够使用服务端代码
- 内置的多种数据格式和内容协商让你的Web接口可以应用在广泛的客户端范围，包括浏览器和移动设备
- 模型绑定自动映射数据从HTTP请求到Action方法参数
- 模型验证自动执行客户端和服务端验证

# 客户端开发
ASP.NET Core被设计成可以无缝集成多种客户端框架，包括AngularJS、KnockoutJS和Bootstrap