using System.Diagnostics;
using UnityEditor;

public class BuildScript
{
    static void BuildWindows()
    {
        string[] scenes = { "Assets/Scenes/SampleScene.unity" };
        BuildPipeline.BuildPlayer(scenes, "../Jenkins/WindowsBuild",BuildTarget.StandaloneWindows,BuildOptions.None);
    }
}
