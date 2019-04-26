using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class Test : Editor
{
	
	[MenuItem("Custom Editor/Create AssetBunldes Main")]
	static void CreateAssetBunldesMain ()
	{
        //获取在Project视图中选择的所有游戏对象
		Object[] SelectedAsset = Selection.GetFiltered (typeof(Object), SelectionMode.DeepAssets);

        AssetBundleBuild[] abbs = new AssetBundleBuild[SelectedAsset.Length];
        //遍历所有的游戏对象
        for(int i = 0; i < SelectedAsset.Length; ++i) 
		{
            //本地测试：建议最后将Assetbundle放在StreamingAssets文件夹下，如果没有就创建一个，因为移动平台下只能读取这个路径
            //StreamingAssets是只读路径，不能写入
            //服务器下载：就不需要放在这里，服务器上客户端用www类进行下载。
            //string targetPath = Application.dataPath + "/StreamingAssets/" + obj.name + ".assetbundle";
            string bundlename = SelectedAsset[i].name + ".assetbundle";
            abbs[i].assetBundleName = bundlename;
            var asset_path = AssetDatabase.GetAssetPath(SelectedAsset[i]);
            int index = asset_path.IndexOf("Assets");
            abbs[i].assetNames = new string[] { asset_path.Substring(index) };
		}

        var target_path = Application.dataPath + "/StreamingAssets";
        if( !Directory.Exists(target_path))
        {
            Directory.CreateDirectory(target_path);
        }

        if (BuildPipeline.BuildAssetBundles(target_path, abbs, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.Android))
        {
            Debug.Log( "资源打包成功");
        }
        else
        {
            Debug.Log("资源打包失败");
        }

        //刷新编辑器
        AssetDatabase.Refresh ();		
	}
	
    //将预设打包成一个assetbundle
	[MenuItem("Custom Editor/Create AssetBunldes ALL")]
	static void CreateAssetBunldesALL ()
	{
		Caching.ClearCache ();

        var target_path = Application.dataPath + "/StreamingAssets";

        AssetBundleBuild[] abbs = new AssetBundleBuild[1];
        abbs[0].assetBundleName = "ALL.assetbundle";

        Object[] SelectedAsset = Selection.GetFiltered (typeof(Object), SelectionMode.DeepAssets);
        abbs[0].assetNames = new string[SelectedAsset.Length];

        for (int i = 0; i < SelectedAsset.Length; ++i) 
		{
			Debug.Log ("Create AssetBunldes name :" + SelectedAsset[i].name);
            string temp_path = AssetDatabase.GetAssetPath(SelectedAsset[i]);
            int temp_index = temp_path.IndexOf("Assets");
            abbs[0].assetNames[i] = temp_path.Substring(temp_index);
		}

        BuildPipeline.BuildAssetBundles(target_path, abbs, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.Android);
	}
	
    //打包场景
	[MenuItem("Custom Editor/Create Scene")]
	static void CreateSceneALL ()
	{
		//清空一下缓存
		Caching.ClearCache();
		string Path = Application.dataPath + "/MyScene.unity3d";
		string  []levels = {"Assets/Level.unity"};
    	//打包场景
    	BuildPipeline.BuildPlayer( levels, Path,BuildTarget.Android, BuildOptions.BuildAdditionalStreamedScenes);
		AssetDatabase.Refresh ();
	}	
}
