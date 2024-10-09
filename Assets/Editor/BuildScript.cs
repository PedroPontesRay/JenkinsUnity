using System.Diagnostics;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditor.Build.Reporting;
using System.Linq;
using UnityEditor.Build;
using System;

public class BuildScript
{
    static string buildPath = "C:/Build/BuildWindows/";

    #region Dev
    public static void BuildWindowsDev(string buildName, string buildPath)
    {
        // Setup new options
        BuildPlayerOptions options = new BuildPlayerOptions();
        options.scenes = EditorBuildSettings.scenes.Where(s => s.path.Contains("SampleScene")).Select(ss => ss.path).ToArray();

        // Setup new path or new folder
        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string finalBuildPath = Path.Combine(buildPath, buildName + "_" + timestamp);
        Directory.CreateDirectory(finalBuildPath);

        // LOG
        string logPath = Path.Combine(finalBuildPath, "Editor.log");
        LogToEditorLog("Starting build for Windows Dev...", logPath);

        options.locationPathName = finalBuildPath;
        options.target = BuildTarget.StandaloneWindows;
        options.options = BuildOptions.Development;

        // Build call
        BuildReport report = BuildPipeline.BuildPlayer(options.scenes, Path.Combine(finalBuildPath, "MyGame.exe"), BuildTarget.StandaloneWindows, BuildOptions.None);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            LogToEditorLog("Build succeeded: " + summary.totalSize + " bytes", logPath);
        }
        else if (summary.result == BuildResult.Failed)
        {
            LogToEditorLog("Build failed", logPath);
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
            options.scenes = EditorBuildSettings.scenes.Where(s => s.path.Contains("SampleScene")).Select(ss => ss.path).ToArray();

            buildPath += "_Master";

            options.locationPathName = buildPath;
            options.target = BuildTarget.StandaloneWindows;
            options.options = BuildOptions.None;

            BuildReport report = BuildPipeline.BuildPlayer(options);
        }
        catch (System.Exception ex)
        {
            //LogToEditorLog($"[BuildScripts]Build failed: {ex}");
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
            //LogToEditorLog($"[BuildScripts]Build failed: {ex}");
        }

    }
    #endregion

    static void Build(bool development, IPostBuildPlayerScriptDLLs compilerConfiguration)
    {

    }

    private static void LogToEditorLog(string message, string logPath)
    {
        using (StreamWriter writer = new StreamWriter(logPath, true))
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
