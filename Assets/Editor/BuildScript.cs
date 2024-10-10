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

    #region Dev
    public static void BuildWindowsDev()
    {
        string buildName = System.Environment.GetEnvironmentVariable("BUILD_NAME");
        string buildPath = System.Environment.GetEnvironmentVariable("BUILD_PATH");
        

        // Setup new options
        BuildPlayerOptions options = new BuildPlayerOptions();
        options.scenes = EditorBuildSettings.scenes.Where(s => s.path.Contains("SampleScene")).Select(ss => ss.path).ToArray();

        // Setup new path or new folder
        buildPath += $"/{buildName}";
        Directory.CreateDirectory(buildPath);

        // LOG
        string logPath = Path.Combine(buildPath, "Editor.log");
        LogToEditorLog("Starting build for Windows Dev...", logPath);

        try
        {
            options.locationPathName = buildPath;
            options.target = BuildTarget.StandaloneWindows;
            options.options = BuildOptions.Development;

            // Build call
            BuildReport report = BuildPipeline.BuildPlayer(options.scenes, Path.Combine(buildPath, "MyGame 1_0.exe"), BuildTarget.StandaloneWindows, BuildOptions.None);
            BuildSummary summary = report.summary;

            LogToEditorLog("Build succeeded: " + summary.totalSize + " bytes", logPath);
        }
        catch(Exception ex)
        {
            LogToEditorLog($"Build failed {ex}", logPath);
        }
    }

    #endregion
/*COMENT
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
*/


    private static void LogToEditorLog(string message, string logPath)
    {
        message += "[Debug BuildScript]";
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
