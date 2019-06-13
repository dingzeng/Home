---
title: React基础笔记
date: 2016-05-21
categories:
- notes
tags:
- redis
---

## 引入React
```html
<script src="../build/react.js"></script>
<script src="../build/react-dom.js"></script>
<script src="../build/browser.min.js"></script>
```
`react.js` 是 React 的核心库，`react-dom.js` 是提供与 DOM 相关的功能，`browser.js` 的作用是将 JSX 语法转为 JavaScript 语法

## text/babel
由于React的JSX语法与原生的javascript语法不兼容，所以需要设置script标签的type属性为'text/babel'

## ReactDOM.render
ReactDOM.render函数是React的核心函数，用来元素转化为DOM渲染到页面中，第一个参数为组件元素，当需要渲染多个组件时需要使用一个容器包裹住，第二个参数为真实DOM节点

## JSX
JSX是一种可以混用JS和html的新语法，在解析时遇到`<`时解析为html，遇到`{`则解析为javascript

## 组件
组件是React最为重要的概念，是一种页面组织方式
- React.createClass用来创建一个组件
- `render` 方法用来定义组件该如何被渲染
- `this.props` 用来引用组件上的属性，组件的属性在使用组件时指定，类似于html标签的属性
- `this.props.children` 用来引用组件的子节点，可以使用React.Childern提供的帮助方法处理其数据结构不一致的问题（当子节点只有一个是this.props.children是一个object，没有时为null，当存在多个子节点时又是一个数组）,方法如下：
    - React.Children.map()
    - React.Children.forEach()
    - React.Children.count()
    - React.Children.only()
    - React.Children.toAttay()
- `propTypes` 用来定义属性的类型，主要是用来保证组件在重用时被正确的使用，主要类型如下：
    - React.PropTypes.array
    - React.PropTypes.bool
    - React.PropTypes.func
    - React.PropTypes.number
    - React.PropTypes.object
    - React.PropTypes.string
    - [查看更多](https://facebook.github.io/react/docs/reusable-components.html)
- `this.refs` 用来引用组件虚拟DOM对应的真实DOM元素，在render函数中定义的元素中可以指定一个ref属性，就可以在组件的其它地方通过this.refs.some_ele来引用其对应的真实DOM节点了，不过要注意的是必须在真实的DOM节点插入之后才可以访问

## 组件的状态
组件是状态驱动的，状态是组件渲染的依据，React与Jquery在开发方式上很大的区别就在于React是通过设置组件的状态去影响真实的DOM节点，而不是直接操作DOM
- `this.state` 用来引用组件的状态
- `this.setState()` 方法用来设置组件的状态

## 为组件元素设置样式
- 设置元素的className属性
- 内联样式，如下：
```
<div style={{opacity: this.state.opacity}}>
...
</div>
```

## 组件的生命周期及钩子函数
###  Mounting
- `getInitialState()` 获取组件的初始化状态
- `componentWillMount()` 组件插入DOM前触发
- `componentDidMount()` 组件插入DOM后触发
### Updating
- `componentWillReceiveProps(object nextProps)`  组件获取到新属性时调用，一般用来转换状态
- `shouldComponentUpdate(object nextProps, object nextState): boolean` 判断组件是否需要更新时调用，可以通过判断属性和状态来决定是否需要更新，返回`false`将跳过更新
- `componentWillUpdate(object nextProps, object nextState)` 组件更新前调用
- `componentDidUpdate(object prevProps, object prevState)` 组件更新后调用
### Unmounting
- `componentWillUnmount()` 组件移除DOM前调用