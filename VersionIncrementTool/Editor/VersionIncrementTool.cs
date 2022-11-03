
using UnityEditor;
using UnityEngine;

namespace SolClovser.VersionIncrementTool
{
    /// <summary>
    /// A static class for incrementing version from Tools > Increase Version menu
    /// </summary>
    public static class VersionIncrementTool
    {
        // Debug.LogWarning(PlayerSettings.bundleVersion); // the 1.26.0

        // # Android
        // Debug.LogWarning(PlayerSettings.applicationIdentifier); // the com.company.game
        // Debug.LogWarning(PlayerSettings.Android.bundleVersionCode); // the 126

        [MenuItem("Tools/Increment Version/Patch", priority = 1)]
        public static void IncrementPatch()
        {
            string[] oldVersions = GetOldVersionMajorMinorPatch();
            int patch = int.Parse(oldVersions[2]);
            int newPatch = patch + 1;

            string newVersion = $"{oldVersions[0]}.{oldVersions[1]}.{newPatch}";

            PlayerSettings.bundleVersion = newVersion;

#if UNITY_ANDROID
            PlayerSettings.Android.bundleVersionCode++;
            Debug.LogWarning($"Android bundle version updated to {PlayerSettings.Android.bundleVersionCode}");
#endif

            Debug.LogWarning($"Version updated to {newVersion}");
        }

        [MenuItem("Tools/Increment Version/Minor", priority = 0)]
        public static void IncrementMinor()
        {
            string[] oldVersions = GetOldVersionMajorMinorPatch();
            int minor = int.Parse(oldVersions[1]);
            int newMinor = minor + 1;

            string newVersion = $"{oldVersions[0]}.{newMinor}.{0}";

            PlayerSettings.bundleVersion = newVersion;

#if UNITY_ANDROID
            PlayerSettings.Android.bundleVersionCode++;
            Debug.LogWarning($"Android bundle version updated to {PlayerSettings.Android.bundleVersionCode}");
#endif

            Debug.LogWarning($"Version updated to {newVersion}");
        }

//     [MenuItem("Tools/Increment Version/Major", priority = 3)]
//     public static void IncrementMajor()
//     {
//         string[] oldVersions = GetOldVersionMajorMinorPatch();
//         int major = int.Parse(oldVersions[0]);
//         int newMajor = major + 1;
//         
//         string newVersion = $"{newMajor}.{0}.{0}";
//
//         PlayerSettings.bundleVersion = newVersion;
//         
// #if UNITY_ANDROID
//         PlayerSettings.Android.bundleVersionCode++;
//         Debug.LogWarning($"Android bundle version updated to {PlayerSettings.Android.bundleVersionCode}"); 
// #endif
//         
//         Debug.LogWarning($"Version updated to {newVersion}"); 
//     }

        private static string[] GetOldVersionMajorMinorPatch()
        {
            string oldVersionString = PlayerSettings.bundleVersion;
            return oldVersionString.Split('.');
        }
    }
}
