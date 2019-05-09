using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

class AssetsMenu
{
    [MenuItem("Assets/Custom/Export_Unity_Package", true)]
    static bool ExportPackageValidation()
    {
        for (var i = 0; i < Selection.objects.Length; i++)
        {
            if (AssetDatabase.GetAssetPath(Selection.objects[i]) != "")
            {
                GameLogger.LogBlue("Continue");
                return true;
            }
        }

        GameLogger.LogGreen("Abort");
        return false;
    }

    [MenuItem("Assets/Custom/Export_Unity_Package")]
    static void ExportPackage()
    {
        var path = EditorUtility.SaveFilePanel("Save unitypackage", "", "", "unitypackage");
        if (path == "")
            return;

        var assetPathNames = new string[Selection.objects.Length];
        for (var i = 0; i < assetPathNames.Length; i++)
        {
            assetPathNames[i] = AssetDatabase.GetAssetPath(Selection.objects[i]);
        }

        assetPathNames = AssetDatabase.GetDependencies(assetPathNames);

        AssetDatabase.ExportPackage(assetPathNames, path, ExportPackageOptions.Interactive | ExportPackageOptions.Recurse | ExportPackageOptions.IncludeDependencies);
    }
}
