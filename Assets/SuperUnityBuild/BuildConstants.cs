using System;

// This file is auto-generated. Do not modify or move this file.

namespace SuperUnityBuild.Generated
{
    public enum ReleaseType
    {
        None,
        NewReleaseType,
    }

    public enum Platform
    {
        None,
        PC,
    }

    public enum ScriptingBackend
    {
        None,
        Mono,
        IL2CPP,
    }

    public enum Architecture
    {
        None,
        Windows_x86,
        Windows_x64,
    }

    public enum Distribution
    {
        None,
        DistributionName,
    }

    public static class BuildConstants
    {
        public static readonly DateTime buildDate = new DateTime(638618428591476597);
        public const string version = "1.0.0.1";
        public const int buildCounter = 1;
        public const ReleaseType releaseType = ReleaseType.NewReleaseType;
        public const Platform platform = Platform.PC;
        public const ScriptingBackend scriptingBackend = ScriptingBackend.Mono;
        public const Architecture architecture = Architecture.Windows_x86;
        public const Distribution distribution = Distribution.DistributionName;
    }
}

