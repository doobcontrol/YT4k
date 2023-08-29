简单YouTube下载器  
  
功能：  
简单点击粘贴地址后即开始下载该地址最高清晰度的视频  
  
外部引用：libvideo Nuget名：VideoLibrary （gitHub https://github.com/omansak/libvideo ）  
  
引用：  
com.xiyuansoft.pub.log  
com.xiyuansoft.xyConfig  
  
对有年龄认证要求的视频会返回异常，获取视频信息失败，从而不能下载。目前未找到方法绕过    
  
技术备忘：  
1，在label中显示多行内容  
2，对大文件进行分块下载（CustomYouTube类 来自libvideo库）  
3，使用定制的用户控件来下载单个任务  
4，监视剪贴板的youtube链接提示下载  