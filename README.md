
# Manage JavaScript Files With Tag Helpers


**Uniquely including JavaScript files and JavaScript text blocks can be a challenge when combining layout pages, partials and now Tag Helpers that all can require JavaScript to run correctly.  Say for example all your pages require jQuery, some require jQueryUI and some have tag helpers that include customized JavaScript only designed for those particular tag helpers.  By simply including a reference to a body and script Tag Helper, along with a ScriptManager class, you are now able to have just the right number of script tags inserted below the body tag of your rendered HTML Page.  Concepts covered include advanced tag helper authoring as well as dependency injection.**

## Supporting Class Built - ScriptManager.cs

ScriptManager.cs is built to be injected using the built in DI engine that is part of ASP.NET Core.  It basicall has an interface (IScriptManager) that requires two collection (one that collections JavaScript src filenames and the other that collects snippets of JavaScript that will get injected into the current html page generated with razor at the bottom of the body tag.

## Tag Helpers Created



### ScriptTagHelper.cs
This enhances the ```<script src=xxx ></script>``` tags such that no output is generated from these includes, but instead, the src file is added to the collection of the instantiated ScriptManager (described above).  Because an instance of the ScriptManager is passed into the constructor of this class (that is how DI works), this tag helper can insert the src value from the JavaScript tag into the ScriptManager's collection.  It also has a method AddScript that let's other Tag Helpers directly add scripts to the collection.

### BodyTagHelper.cs
This tag helpers job is to output all the scripts (and script texts) collected as the ```<script...``` tags are processed through the razor view.  All unique script tags will be output at the bottom of the page.  Special care is taken to make sure this BodyTagHelper is run last (after the script tag helpers).

### YouTubeEmbedTagHelper.cs
This tag helper is based on the [nonSuckyYouTubeEmbed jQuery Plugin](https://github.com/mpchadwick/jquery.nonSuckyYouTubeEmbed).  By creating a tag that looks like
```<YouTubeEmbed you-tube-id="6Fg3Aj9GzNw"></YouTubeEmbed>``` a YouTube frame will be created on the page that just displays a thumbnail and not the full player YouTube would like to embed.  Then, when the viewer clicks this, the real YouTube frame replaces the simple image and starts playing.  This allows pages to come up much faster than if all the YouTube videos where in embedded on a given page.


## MVC File Setup For Running Example

## HOME  
```html  
<script src='jquery.js' ></script>    
<script src='jqueryui.js' ></script>
```

## VIDEOS
```html 
  <script src='jquery.js' ></script>
  <script src='jqueryui.js' ></script>
  <script src='videos.js'></script>
  <script src='/js/jquery.nonSuckyYouTubeEmbed.js'></script>
  ```

## ABOUT
  {no scripts}


 <hr/>
 
 [Notes From Hackathon While Working With Taylor Mullen](https://gist.github.com/NTaylorMullen/b16b4ec9bac1bfd72b6db9c54da05203)
 
 
 
 Current Project Started at MVC Summit 2016 Hackathon November 2017 by
 [Peter Kellner](http://peterkellner.net) and [Gabriel Enea](https://github.com/dotnet18) (with some early help from
 Paul Litwin).  Major help from ASP.NET team member [Taylor Mullen](https://gist.github.com/NTaylorMullen) during and after the hackathon.
 
 
![Gabriel Enea, Paul Litwin, Peter Kellner and Taylor Mullen](/images/HackathonTeamMembers.gif?raw=true)

*Gabriel Enea, Paul Litwin, Peter Kellner and Taylor Mullen*

