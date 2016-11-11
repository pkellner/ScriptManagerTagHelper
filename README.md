
# Script Module Tag Helper

Combine script tags into output html above bottom body tag.  
Optionally combine JavaScript and optionally minimize.

**Classes Built**  
  ScriptManager.cs  
    Maintains Unique List of Scripts
  ScriptManagerOptions.cs
    Minimized;CDN;CombinedSRC  

**Tag Helpers**  
    BodyTagHelper.cs  
      Puts Script Tags at bottom of body
    MyTagHelper.cs 
      References ScriptManager Through DI to add script

HOME  
```html  
<script src='jquery.js' ></script>    
<script src='jqueryui.js' ></script>
```
VIDEOS
```html 
  <script src='jquery.js' ></script>
  <script src='jqueryui.js' ></script>
  <script src='videos.js'></script>
  ```
ABOUT
  {no scripts}


videos.js 





[![Join the chat at https://gitter.im/aspnet/Home](https://badges.gitter.im/aspnet/Home.svg)](https://gitter.im/aspnet/Home?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

https://github.com/NTaylorMullen/WebCampsTV_TagHelpers1/blob/master/src/WebApplication70/ControllerNavigationTagHelper.cs


