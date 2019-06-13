---
title: Git简介
date: 2017-08-02
categories:
- notes
tags:
- git
---

# 概念
## 工作目录、暂存区、本地仓库、远程仓库
- 工作目录：源代码目录
- 暂存区：下一次提交的内容的存储区域
- 本地仓库：本地仓库，分布式版本管理的最大特点就是每个本地都有一个完整的仓库
- 远程仓库：服务器端的仓库

## 分布式版本管理与集中式版本管理的区别及优势
- 每个人的本地都是一个完整的仓库，版本管理不依赖于一个集中式的服务器；
- 分支管理更为方便,SVN、CSV等需要用一个源代码的副本去保存一个分支，GIT的分支只是一个指针

## 文件的五种状态
- untracked
- staged
- committed
- unmodified
- modified

## Git配置
配置文件级别
- 仓库级 .git/config 只对当前仓库有效
- 用户级 ~/.gitcofig 只对指定用户有效
- 机器级 /etc/gitconfig windows下没找到,对该机器有效
- 优先级：仓库级>用户级>机器级

## .gitignore
包含在该文件中的文件将被git忽视
- NuGet Packages
- Build results

# 命令
## 配置管理
```
# 查看指定配置项
git config user.name
# 查看所有配置
git config --list
# 设置配置
git config user.name jery
# 保存密码
git config --global credential.helper store
```

## 基本操作
```
# Clone一个已经存在的项目
git clone http://gitlab.qidid.com/erpdev/wlwerp.git
# 初始化一个空的仓储
git init
# 重置文件的更改(修改、删除)
# 新增的文件因为是untracked状态,直接删除即可
git checkout -- .
# 将更改载入到暂存区
git add --all
# 将暂存区的内容反载入到工作空间
git reset HEAD .
# 提交暂存区的内容到本地仓库
git commit -m "提交的注释"
# 跳过暂存区直接将工作区的内容提交到本地仓库
git commit -a -m "提交的注释"
# 推送至远程仓库
git push
```

## 分支操作
本地
```
# 查看本地分支
git branch
# 查看所有分支(包括本地和远程)
git branch -a
# 创建新的本地分支
git branch new_branch
# 删除本地分支
git branch -d old_branch
# 切换本地分支
git checkout local_branch_name
# 创建新的本地分支并切换至该分支
git checkout -b new_branch
```
远程
```
# 查看远程仓库
git remote
# 添加远程仓库
git remote add remote_repo_name http://gitlab.qidid.com/erpdev/testdemo.git
# 显示远程仓库详细信息
git remote show origin
# 重命名远程分支
git remote rename origin origin1
# 移除远程分支
git remote rm origin
# 获取远程仓库代码到本地仓库
git fetch origin
# 拉取远程仓库代码到本地仓库并更新工作目录
git pull
# 推送指定的本地分支到远程仓库
git push origin dev
# 删除远端分支
git branch -r -d origin/del_branch
git push origin :del_branch
or
git push origin --delete del_branch
```