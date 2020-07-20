# Git Flow

Git拥有强大而且灵活的分支管理功能，但是灵活也会带来许多问题，所以需要有一个清晰的分支管理规范，Git Flow是一套被广为使用和认同的分支模型。

参考:[a-successful-git-branching-model/](http://nvie.com/posts/a-successful-git-branching-model/)
![gitflow](http://nvie.com/img/git-model@2x.png)

- 主要包含如下几类分支:
    - master
    - develop
    - feature/*
    - hotfix/*
    - release/*
- master分支为主干分支，只能从hotfix、release分支合并过来，不可以直接在该分支上进行提交；
- master的每一次提交都需要打上版本标签，该版本不同于产品的版本号，生产环境运行的代码为最后一次提交的代码；
- develop为主开发分支，所有的开发任务都是基于该分支和子分支进行；
- feature分支从develop分支上拉下来，用来进行一个大的功能模块开发，小的修改可直接在develop上进行，开发人员在feature上开发完成后需要合并到develop上；
- hotfix用来修复线上bug，从master分支上拉下来，修复、测试、发布、回归通过后合并回master，并合并到develop上；
- release分支为发布使用的分支，当一次迭代进入测试阶段时，从develop分支拉出，期间有bug可直接在release上进行修改，之后再将修改合并回develop，测试、发布后合并到master并打上标签；
- 除了master和develop为永久分支外，其它所有分支都为临时分支，完成所在阶段的任务后都应该删除；