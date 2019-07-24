iview笔记
============

> [https://github.com/iview/iview/blob/v3.4.2/src/utils/dom.js](https://github.com/iview/iview/blob/v3.4.2/src/utils/dom.js)

## 1.导入和导出多个对象

导出：
```
export const a
export const b
```
导入：
```
import { a, b } from a.js
```

## 2.加载时执行函数

```
(function(){
  ...
})();
```
函数内部根据条件返回不同的Function:
```
(function(){
  if(expression){
    return function() {
      // function 1
    }
  }else{
    return function() {
      // function 2
    }
  }
})();
```
note:利用这个写法,可以根据不同的“环境”(如Vue.prototype.$isServer)返回不同的函数实现

## 3.addEventListener和removeEventListener

**addEventListener**
```
element.addEventListener(event,handler,false)
```
[addEventListener](https://developer.mozilla.org/zh-CN/docs/Web/API/EventTarget/addEventListener)为指定对象(element、document、window或任何支持事件的对象)添加一个事件监听

**removeEventListener**
```
element.removeEventListener(event, handler, false);
```
[removeEventListener](https://developer.mozilla.org/zh-CN/docs/Web/API/EventTarget/removeEventListener)为指定对象移除一个事件监听


## 扩展
- Object.defineProperty
