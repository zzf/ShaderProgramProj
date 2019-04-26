using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class BuildMenu  {

	[MenuItem("BuildTools/Build Asset Bundles")]
    static public void BuildAssetBundles()
    {
        string luaframe_res = "LuaFramework/Resources";
        string ngui_res = "NGUI/Resources";
        AssetBundleBuild[] abbs = new AssetBundleBuild[2];
        string path = Application.dataPath + "/" + luaframe_res;
        abbs[0].assetBundleName = buildUnityEdirotPath("luaframework_res.bundle");
        abbs[0].assetNames = getByteFiles(path);

        path = Application.dataPath + "/" + ngui_res;
        abbs[1].assetBundleName = buildUnityEdirotPath("ngui_res.bundle");
        abbs[1].assetNames = getByteFiles(path);
        
        string output_path = Application.streamingAssetsPath + "/" + "res";
        if(Directory.Exists(output_path))
        {
            Directory.Delete(output_path, true);
        }
        Directory.CreateDirectory(output_path);
        BuildPipeline.BuildAssetBundles(output_path, abbs, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.Android);
        EditorUtility.DisplayDialog("Tips", "Complete", "OK", "Cancel");
    }

    [MenuItem("BuildTools/Build App")]
    static public void BuildApk()
    {
        BuildAssetBundles();

        string[] levels = new string[] { "Assets/Hawaii Environment.unity" };
        
        string full_path = buildApkDir() + Path.DirectorySeparatorChar + buildApkName();
        if (File.Exists(full_path))
        {
            File.Delete(full_path);
        }
        BuildPipeline.BuildPlayer(levels, full_path, BuildTarget.Android, BuildOptions.None);
    }

    public static string buildUnityEdirotPath(string key)
    {
        return "Assets/Resources/res/" + key;
    }

    public static string buildApkDir()
    {
        return Application.dataPath + "/../Bin";
    }

    public static string buildApkName()
    {
        return "ABTest.apk";
    }

    public static string[] getByteFiles(string path)
    {
        string[] files = null;
        ArrayList filelist = getFiles(path);
        if(filelist != null && filelist.Count > 0)
        {
            files = new string[filelist.Count];
            string prefix = "Assets";
            for(int i = 0; i < filelist.Count; ++i)
            {
                int prefix_index = ((string)filelist[i]).IndexOf(prefix);
                files[i] = ((string)filelist[i]).Substring(prefix_index);
            }
        }

        return files;
    }

    public static ArrayList getFiles(string path)
    {
        ArrayList filelist = null;
        string[] temp_filelist = Directory.GetFiles(path);
        string[] temp_dirlist = Directory.GetDirectories(path);

        if (temp_filelist.Length > 0)
        {
            filelist = new ArrayList();
            filelist.AddRange(temp_filelist);
        }
        
        if(temp_dirlist.Length >  0)
        {
            for(int i = 0; i < temp_dirlist.Length; ++i)
            {
                ArrayList al = getFiles(temp_dirlist[i]);
                if(null != al && al.Count > 0)
                {
                    filelist.AddRange(al);
                }
            }
        }       

        return filelist;
    }
}
