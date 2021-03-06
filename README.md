# UniFramework

UniFramework is a personal framework for the games I make (mainly mobile and desktop games). It contains lots of cool stuff I made and scripts/plugins from other people aswell.

*Disclaimer: UniFramework is still in development. Each version upgrade may break a few things, so only upgrade the version of UniFramework in your project if you know what you're doing.*

## How To Use
Download the latest .unitypackage file [from the Packages folder](https://github.com/sampaiodias/UniFramework/tree/master/Packages) and open it on your project. After committing the changes, the next person to pull these changes should import the .unitypackage and commit again (because of DLLs being deleted after the first pull on another machine).

## Requirements
* Scripting Runtime .NET 4.x or higher
* Unity 2017.3 or higher (older versions might work but were not fully tested)

Using UniFramework with [Odin](https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041) (UniExplorer, OdinHierarchy, bonus features for GameEvent, additional Setters and better inspectors) and [UniTween](https://github.com/sampaiodias/UniTween) is recommended (but not required).

## Contents
* SmartDebug
* ScriptableVariable system with component setters (improved from [Unite Austin 2017 - Game Architecture with Scriptable Objects](https://www.youtube.com/watch?v=raQ3iHhE_Kk))
* GameEvent (improved from [Unite Austin 2017 - Game Architecture with Scriptable Objects](https://www.youtube.com/watch?v=raQ3iHhE_Kk))
* UniExplorer and GameEventListener Explorer (requires [Odin](https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041))
* UIScreen system by [Allan Oliveira](https://github.com/allanolivei) and me
* Many utility scripts (ObjectPool, SplashScreen, LoadScreen with ProgressBar, etc.) by me (and a few open-source ones found in various places)
#### Plugins
* [DOTween](https://assetstore.unity.com/packages/tools/visual-scripting/dotween-pro-32416) by [Demigiant](http://www.demigiant.com/)
* [TextMesh Pro](https://assetstore.unity.com/packages/essentials/beta-projects/textmesh-pro-84126) by [Unity Technologies](https://unity3d.com/)
* [RainbowFolders](https://github.com/PhannGor/unity3d-rainbow-folders) by [PhannGor](https://github.com/PhannGor)
* [SuperUnityBuild](https://github.com/Chaser324/unity-build) by [Chaser324](https://github.com/Chaser324) (and a few modifications by me)
* [ExtendedTransform](https://github.com/bradsc0tt/Unity-Extended-Transform-Editor) by [bradsc0tt](https://github.com/bradsc0tt/)
* [Extension Methods for Unity](https://assetstore.unity.com/packages/tools/utilities/extension-methods-for-unity-24876) by [ROCKET GAMES](https://assetstore.unity.com/publishers/2191) (and a few modifications by me)
* [RangedValues](https://github.com/TobiasWehrum/unity-utilities) by [Tobias Wehrum](https://github.com/TobiasWehrum)
* [OdinHierarchy](https://github.com/5argon/E7Unity/tree/master/-EditorScripts/OdinHierarchy) by [5argon/Exceed7](https://github.com/5argon) (and a few modifications by me)

## Special Thanks
* [Paullo Cesar "PC"](https://github.com/paullocesarpc)
* [Allan Oliveira](https://github.com/allanolivei)

## License
**Each plugin has its own license, check the links on the 'Contents' section. Stuff I made (Setters, SmartDebug, etc.) is MIT licensed.**

Copyright 2018 Lucas Sampaio Dias

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
