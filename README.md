# WPFProgramEffect

WPF 项目中使用的各种有效的开源库

方便快速有效使用WPF进行桌面端的开发

使用到的技术及地址

## MahApps.Metro

一套优秀的UI框架，涉及到Window, childWindw
 在VS里直接用NuGet安装使用，同时可以查看MahApps 其他的相关组件  
[MahApps.Metro 项目地址](https://github.com/MahApps/MahApps.Metro)  
[MahApps.Metro 快速开始](https://mahapps.com/docs/guides/quick-start)  
[MahApps.Metro 使用手册](https://mahapps.com/docs/controls/HamburgerMenu)  

## Prism

一个MVVM框架，DI,Commands,EventAggregator,Models,Region  
可以在vs扩展包中安装 Prism Template Pack 模板，来创建相关项目  
Install Prism.Wpf  
Install Prism.DryIoc, 等同Unity  
[Prism 项目地址](https://github.com/PrismLibrary/Prism)  
[Prism 快速开始](https://prismlibrary.com/docs/)

## Serilog  

日志记录 Serilog, Nlog 差不多,帮助我们记录信息，调试程序

[Serilog 项目地址](https://github.com/serilog/serilog)  
[Serilog 快速开始](https://github.com/serilog/serilog/wiki/Getting-Started)

## SVG图标  

SharpVectors
图标属性改为Resource  
添加命名空间 xmlns:svgc = "http://sharpvectors.codeplex.com/svgc/"  
<svgc:SvgViewbox IsHitTestVisible="False"  Source="pack://application:,,,/Images/file.svg"/>  

[SharpVectors 项目地址](https://github.com/ElinamLLC/SharpVectors)  
[SharpVectors 快速开始](https://elinamllc.github.io/SharpVectors/articles/getting_started.html)  

## GIF播放  

WpfAnimatedGif.在WPF中播放gif图标
图标属性改为Resource  
添加命名空间

```c#
 xmlns:gif="http://wpfanimatedgif.codeplex.com"  
<Image gif:ImageBehavior.RepeatBehavior="3x"gif:ImageBehavior.AnimatedSource="Images/animated.gif" />    
```

[WpfAnimatedGif 项目地址](https://github.com/XamlAnimatedGif/WpfAnimatedGif)  
[WpfAnimatedGif 快速开始](https://github.com/XamlAnimatedGif/WpfAnimatedGif)