﻿using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class Builder
{
    public static void Build()
    {
        var paths = GetBuildScenePaths();
        var fileName = "app.apk";
        var androidOutputPath = $"./build/android/{fileName}";
        var buildTarget = BuildTarget.Android;
        var buildOptions = BuildOptions.Development;

    var buildReport = BuildPipeline.BuildPlayer(
        paths.ToArray(),
        androidOutputPath,
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

    private static IEnumerable<string> GetBuildScenePaths()
    {
        var scenes = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes);
        return scenes
            .Where((arg) => arg.enabled)
            .Select((arg) => arg.path);
    }
}
