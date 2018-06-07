using UnityEditor;
using UnityEngine;
using System.Collections;

class AutoBuildScript
{
     static void PerformWebGLBuild ()
     {
         string[] scenes = { "Assets/HomeStuff/Demo.unity" };
         BuildPipeline.BuildPlayer(scenes, "Build/VIDDemo/", BuildTarget.WebGL, BuildOptions.None);
     }
}

