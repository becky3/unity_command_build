using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class Builder
{
    public static void AndroidBuild()
    {
        var paths = GetBuildScenePaths();
        var fileName = "app.apk";
        var outputPath = $"./build/android/{fileName}";
        var buildTarget = BuildTarget.Android;
        var buildOptions = BuildOptions.Development;

        var buildReport = BuildPipeline.BuildPlayer(
            paths.ToArray(),
            outputPath,
            buildTarget,
            buildOptions
        );

        var summary = buildReport.summary;

        if (summary.result == UnityEditor.Build.Reporting.BuildResult.Succeeded) {
            Debug.Log("Success");
        } else {
            Debug.LogError("Error");
        }
    }

    public static void iOSBuild()
    {

        var outputDirKey = "-output-dir";

        var paths = GetBuildScenePaths();
        var outputDir = GetParameterFrom(key: outputDirKey);
        var buildTarget = BuildTarget.iOS;
        var buildOptions = BuildOptions.Development;

        Debug.Assert(!string.IsNullOrEmpty(outputDir), $"'{outputDirKey}'の取得に失敗しました");

        var buildReport = BuildPipeline.BuildPlayer(
            paths.ToArray(),
            outputDir,
            buildTarget,
            buildOptions
        );

        var summary = buildReport.summary;

        if (summary.result == UnityEditor.Build.Reporting.BuildResult.Succeeded)
        {
            Debug.Log("Success");
        }
        else
        {
            Debug.LogError("Error");
        }
    }

    private static IEnumerable<string> GetBuildScenePaths()
    {
        var scenes = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes);
        return scenes
            .Where((arg) => arg.enabled)
            .Select((arg) => arg.path);
    }

    private static string GetParameterFrom(string key)
    {
        var args = System.Environment.GetCommandLineArgs();

        args.ToList().ForEach((arg) => Debug.Log($"[arg]:{arg}"));
        

        var index = args.ToList().FindIndex((arg) => arg == key);
        var paramIndex = index + 1;

        if (index < 0 || args.Count() <= paramIndex)
        {
            return null;
        }

        return args[paramIndex];
    }
}

