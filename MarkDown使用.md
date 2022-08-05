# 这里是标题
//2022/08/05  
规则，标记后边都需要有空格

https://github.com/DavidAnson/markdownlint/blob/v0.25.1/doc/Rules.md#md040

[参考简书 ConnorLin](https://www.jianshu.com/p/82e730892d42#fn1)

空一格才能换行

空一格才能换行

```C#
//```后边是代码块， 且增加不同的描述会有不同的效果，C#,Text,Python，java,c++等
//那个符号是英文，tab键上的
public int Sum(int a, int b)
{
    return a + b;
}

```

行内代码 `show me code`

有序列表

1. wpf
2. C#
3. java
    1. java 1
    2. java 2

无序列表 "- * + 都可以"

- MahApp.Metro
- MaterialDesignInXamlToolkit
- Prism
- Shoudly
- MsTest
- Nlog
- WpfAnimatedGif
- Newtonsoft.Json
- Microsoft.Office.Interop
- CefSharp
- CalcBinding
- Vanara, PInvoke
- XamlFlair 动画库

**加粗** 

 *倾斜*

 ~~删除效果~~

> 引用作为代码块
>  
> 第二行

[WPF 有效开发](https://github.com/mamade703/WPFProgramEffect/tree/master)

![图片链接有个！号](https://pics6.baidu.com/feed/8ad4b31c8701a18bb3f1f5b09ad50d0f2938fe3c.jpeg)

测试表格

|标题|标题|标题|
|:---|:---:|---:|
|居左测试文本|居中测试文本|居右测试文本|
|居左测试文本1|居中测试文本2|居右测试文本3|
|居左测试文本11|居中测试文本22|居右测试文本33|
|居左测试文本111|居中测试文本222|居右测试文本333|

分割线
***
---
___


换行是结尾加两个空格  
这个新的一行

这是一个脚注的例子[^1]

[^1]: http://www.baidu.com

可以使用html标记来补充  
<u>下划线文本</u>
<p align="left">居左文本</p>
<p align="center">居中文本</p>
<p align="right">居右文本</p>