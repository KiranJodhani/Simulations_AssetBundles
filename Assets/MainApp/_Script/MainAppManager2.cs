using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MainAppManager2 : MonoBehaviour
{
    public static MainAppManager2 Instance;
    public string[] url, sceneNames;

    static AssetBundle assetBundle;
    WWW www;
    public Text percent, percent2;
    public Image fg, fg2;
    public   bool loadingStart = false;
    public int game = 8;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }

    string PathX = "file:///Users/kiran/Documents/Extra/microscope";

    void Start()
    {
        //var myLoadedAssetBundle = AssetBundle.LoadFromFile(PathX);
        //if (myLoadedAssetBundle == null)
        //{
        //    Debug.Log("Failed to load AssetBundle!");
        //    return;
        //}

        //string[] scenes = assetBundle.GetAllScenePaths();

        //foreach (string s in scenes)
        //{
        //    print(Path.GetFileNameWithoutExtension(s));
        //    if (Path.GetFileNameWithoutExtension(s) == "microscope")
        //    {
        //        SceneManager.LoadScene(Path.GetFileNameWithoutExtension(s));
        //    }
        //}

        StartCoroutine(s(0));
    }

  

    private void Update()
    {
        if (loadingStart)
        {
            double v = www.progress;
            print("P : " + (float)v);
            //fg2.fillAmount = (float)v;//landscape

            //v = System.Math.Round(v, 2);

            //v *= 100;
            //percent2.text = "" + v + "%";//landscape
        }

    }

    IEnumerator s(int i)
    {
        if (!assetBundle)
        {
            using (www = new WWW(url[i]))
            {
                loadingStart = true;
                yield return www;
                if (!string.IsNullOrEmpty(www.error))
                {
                    print(www.error);
                    yield break;

                }
                assetBundle = www.assetBundle;
            }
        }
        loadingStart = false;
        string[] scenes = assetBundle.GetAllScenePaths();
        foreach (string s in scenes)
        {
            print(Path.GetFileNameWithoutExtension(s));
            if (Path.GetFileNameWithoutExtension(s) == sceneNames[i])
            {
                SceneManager.LoadScene(Path.GetFileNameWithoutExtension(s));
            }
        }
    }
}
