using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Internal;

public class RunScript : MonoBehaviour
{
    public GameObject m_objParent;
    //不同平台下StreamingAssets的路径是不同的，这里需要注意一下。
    public static string PathURL = "";
    private void Awake()
    {
        if(Application.isEditor)
        {
            PathURL = "file://" + Application.streamingAssetsPath + Path.DirectorySeparatorChar;
        }
        else
        {
            PathURL =
#if UNITY_ANDROID
        "jar:file://" + Application.dataPath + "!/assets/";
#elif UNITY_IPHONE
		Application.dataPath + "/Raw/";
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
	"file://" + Application.streamingAssetsPath + Path.DirectorySeparatorChar;
#else
        string.Empty;
#endif
        }
    }

    void OnGUI()
	{
		if(GUILayout.Button("Main Assetbundle"))
		{
			StartCoroutine(LoadMainCacheGameObject(PathURL + "prefab0.assetbundle"));
			StartCoroutine(LoadMainCacheGameObject(PathURL + "prefab1.assetbundle"));
		}
		
		if(GUILayout.Button("ALL Assetbundle"))
		{
			StartCoroutine(LoadALLGameObject(PathURL + "ALL.assetbundle"));
		}
		
		if(GUILayout.Button("Open Scene"))
		{
			StartCoroutine(LoadScene());
		}
	}
	
	//读取全部资源
	
	private IEnumerator LoadALLGameObject(string path)
	{
		 WWW bundle = new WWW(path);
		 
		 yield return bundle;
		 
		 //通过Prefab的名称把他们都读取出来
		 UnityEngine.Object  obj0 =  bundle.assetBundle.LoadAsset("Prefab0");
         UnityEngine.Object obj1 =  bundle.assetBundle.LoadAsset("Prefab1");
		
		 //加载到游戏中
		 yield return Instantiate(obj0);
		 yield return Instantiate(obj1);
		 bundle.assetBundle.Unload(false);
	}
	
	private IEnumerator LoadMainCacheGameObject(string path)
	{
		 WWW bundle = WWW.LoadFromCacheOrDownload(path,10);
		 
		 yield return bundle;
        //mainAsset已经是弃用的
        if(bundle.assetBundle != null)
        {
            //加载到游戏中
            AssetBundleRequest abr = bundle.assetBundle.LoadAllAssetsAsync();
            yield return null;
            for(int i = 0; i < abr.allAssets.Length; ++i)
            {
                GameObject go = (GameObject)Instantiate(abr.allAssets[i]);
                go.transform.parent = m_objParent.transform;
            }
            yield return null;
            bundle.assetBundle.Unload(false);
        }
        else
        {
            Debug.LogError("bundle.assetBundle == null");
            Debug.LogError("path = " + path);
            bundle.assetBundle.Unload(false);
        }
	}

    private IEnumerator LoadScene()
	{
		 WWW download = WWW.LoadFromCacheOrDownload ("file://"+Application.dataPath + "/MyScene.unity3d", 1);
		yield return download;
		var bundle = download.assetBundle;
  		//Application.LoadLevel ("Level");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level");

        /*
         */
	}
	
}
