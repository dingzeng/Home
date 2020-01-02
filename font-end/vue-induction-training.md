Vue入门培训
==========

# 名词解释：
- [node](https://nodejs.org/en/) - js execute env (io、process)
- [npm](https://www.npmjs.com/) - node package manager NuGet
- [webpack](http://webpack.github.io/) - node package 前端构建工具
- [vue-cli](https://www.npmjs.com/package/vue-cli) - vue脚手架工具
- package - run on node or browser?

# 前端框架层次结构：渐进式的
- [vue](https://cn.vuejs.org/) - font-end MVVM framework
- [iview](https://www.iviewui.com/) - component library elements & control
- [iview-admin](https://github.com/iview/iview-admin) - admin project template
- framework - public components
- biz code
- 各个层次在项目中的具体体现

# 项目结构及总要文件讲解：
- build - webpack的配置文件
- dist - 默认的构建输出目录
- iview - iview框架源代码
- node_modules - node包文件存放目录
- src - 源代码目录
- package.json - 文件内容讲解
- webpack.*.config.js
- npm run dev/build 命令讲解

# 开始使用Vue
- 文件引入 - https://cdn.jsdelivr.net/npm/vue/dist/vue.js
- DIY
- vue-cli
- git clone iview-admin

# Vue基础
## 指令
- v-bind (:)
- v-show
- v-if、v-else、v-else-if
- v-for(数组、对象)
- v-on (@)
- v-model双向数据绑定

## 组件基础
- 组件示例
- 生命周期钩子:created、mounted、updated、destroyed
- data、methods、props、computer计算属性、watch属性
- 样式的绑定：calss\style
- 单向数据流与父子组件通信
- `$parent、$emit、$refs`
- 插槽
- 动态组件component :is
- 全局注册和局部注册

## ES6模块加载方式export、import

## Router - 路由

## Vuex - 状态管理

## 组件通信