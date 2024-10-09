using System.Diagnostics;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditor.Build.Reporting;
using System.Linq;
using UnityEditor.Build;

public class BuildScript
{
    static string buildPath = "C:/Build/BuildWindows/";

    #region Dev
    [MenuItem("Tools/BuildWindows/Dev")]
    public static void BuildWindowsDev()
    {
        BuildPlayerOptions options = new BuildPlayerOptions();
        options.scenes = EditorBuildSettings.scenes.Where(s=>s.path.Contains("SampleScene")).Select(ss => ss.path).ToArray();

        buildPath += "_Dev";

        options.locationPathName = buildPath;
        options.target = BuildTarget.StandaloneWindows;
        options.options = BuildOptions.Development;

        BuildReport report = BuildPipeline.BuildPlayer(options);
        BuildSummary summary = report.summary;

        if(summary.result == BuildResult.Succeeded)
        {
            LogToEditorLog ("Build succeeded: " + summary.totalSize + " bytes");
        }
        else if(summary.result == BuildResult.Failed)
        {
            LogToEditorLog ("Build failed");
        }
        
    }
    #endregion

    #region Master
    [MenuItem("Tools/BuildWindows/Master")]
    public static void BuildWindowsMaster()
    {
        //LogToEditorLog("[BuildScript] Start Build Process");
        try
        {
            BuildPlayerOptions options = new BuildPlayerOptions();
            options.scenes = EditorBuildSettings.scenes.Where(s => s.path.Contains("SampleScene")).Select(ss=>ss.path).ToArray();

            buildPath += "_Master";

            options.locationPathName = buildPath;
            options.target = BuildTarget.StandaloneWindows;
            options.options = BuildOptions.None;

            BuildReport report = BuildPipeline.BuildPlayer(options);
        }
        catch (System.Exception ex)
        {
            LogToEditorLog($"[BuildScripts]Build failed: {ex}");
        }

    }
    #endregion

    #region Realease
    [MenuItem("Tools/BuildWindows/Realease")]
    public static void BuildWindowsRealease()
    {
        //LogToEditorLog("[BuildScript] Start Build Process");
        try
        {
            BuildPlayerOptions options = new BuildPlayerOptions();
            options.scenes = EditorBuildSettings.scenes.Where(s => s.path.Contains("SampleScene")).Select(ss => ss.path).ToArray();

            buildPath += "_Realease";

            options.locationPathName = buildPath;
            options.target = BuildTarget.StandaloneWindows;
            options.options = BuildOptions.None;

            BuildReport report = BuildPipeline.BuildPlayer(options);
        }
        catch (System.Exception ex)
        {
            LogToEditorLog($"[BuildScripts]Build failed: {ex}");
        }

    }
    #endregion

    static void Build(bool development,IPostBuildPlayerScriptDLLs compilerConfiguration)
    {

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

enum BUILDTYPE
{
    Development,
    Realease,
    Master
}
