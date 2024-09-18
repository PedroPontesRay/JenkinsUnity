using System.Diagnostics;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditor.Build.Reporting;

public class BuildScript
{
    static void BuildWindows()
    {
        //LogToEditorLog("[BuildScript] Start Build Process");
        try
        {
            string[] scenes = { "Assets/Scenes/SampleScene.unity" };
            string buildPath = "C:/Users/thera/Build/WindowsBuild";

            BuildPlayerOptions options = new BuildPlayerOptions();
            options.scenes = scenes;
            options.locationPathName = buildPath;
            options.target = BuildTarget.StandaloneWindows;
            options.options = BuildOptions.None;

            BuildReport report = BuildPipeline.BuildPlayer(options);

        }
        catch(System.Exception ex) 
        {
            LogToEditorLog($"[BuildScripts]Build failed: {ex}");
        }
        
    }

    static void LogToEditorLog(string message)
    {
        // Path to the Editor.log file
        string editorLogPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Unity", "Editor", "Editor.log");

        // Append the message to the Editor.log
        using (StreamWriter writer = new StreamWriter(editorLogPath, true))
        {
            writer.WriteLine(message);
        }
    }
}
