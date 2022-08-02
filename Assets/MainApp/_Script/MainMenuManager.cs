using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
//using UnityEngine.ResourceManagement.ResourceProviders;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using System;

public class MainMenuManager : MonoBehaviour
{
    //public AssetReference[] SimulationScenes;
    //public AsyncOperationHandle<SceneInstance> handle;
    public bool unloaded = false;
    public static MainMenuManager Instance;
    public int CurrentSceneIndex;
    [Header("#### UI SCREENS ####")]
    public GameObject HomeScreen;
    public GameObject SimulationListScreen;
    public GameObject DownloadingScreen;
    public GameObject ReloadingScreen;

    [Header("#### MAIN SCREEN COMPONENT ####")]
    public GameObject CanvasObj;
    public GameObject EventSystemObj;
    public GameObject CameraObj;
    public TextMeshProUGUI DownloadingText;
    public Image SliderImage;

    //public List<AsyncOperationHandle> LoadedScene = new List<AsyncOperationHandle>();


    [Header("#### API ####")]
    public GetSimulationData GetSimulationDataResponse;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    void HideAllScreen()
    {
        HomeScreen.SetActive(false);
        SimulationListScreen.SetActive(false);
        DownloadingScreen.SetActive(false);
    }


    void Start()
    {
        //print("Sample Response Payload : " + JsonUtility.ToJson(GetSimulationDataResponse));
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        HideAllScreen();
        HomeScreen.SetActive(true);

    }

    //public void SceneLoadComplated(AsyncOperationHandle<SceneInstance> Obj)
    //{
    //    if(Obj.Status == AsyncOperationStatus.Succeeded)
    //    {
    //        CanvasObj.SetActive(false);
    //        CameraObj.SetActive(false);
    //        EventSystemObj.SetActive(false);
    //        print("Loaded : " + Obj.Result.Scene.name);
    //        handle = Obj;
    //    }
    //}

   

    //public void LoadSelectedSimulation(int Sim_Index)
    //{
    //    HideAllScreen();
    //    DownloadingScreen.SetActive(true);
    //    DownloadingText.text = "0%";
    //    SliderImage.fillAmount = 0;
    //    CurrentSceneIndex = Sim_Index;
    //    //Addressables.LoadSceneAsync(SimulationScenes[Sim_Index], LoadSceneMode.Additive).Completed += SceneLoadComplated;
    //    StartCoroutine(SceneLoadComplatedCo());
    //}

    //IEnumerator SceneLoadComplatedCo()
    //{
    //    var downloadScene = Addressables.LoadSceneAsync(SimulationScenes[CurrentSceneIndex], LoadSceneMode.Additive);
    //    downloadScene.Completed += OnSceneDownloadComplete;
    //    while (!downloadScene.IsDone)
    //    {
    //        print("Downloaded : " + downloadScene.GetDownloadStatus().Percent);
    //        SliderImage.fillAmount = downloadScene.GetDownloadStatus().Percent;
    //        DownloadingText.text = (downloadScene.GetDownloadStatus().Percent*100).ToString("F2");
    //        yield return null;
    //    }
    //}

    //public void OnSceneDownloadComplete(AsyncOperationHandle<SceneInstance> Obj)
    //{
    //    if (Obj.Status == AsyncOperationStatus.Succeeded)
    //    {
    //        CanvasObj.SetActive(false);
    //        CameraObj.SetActive(false);
    //        EventSystemObj.SetActive(false);
    //        print("Loaded : " + Obj.Result.Scene.name);
    //        handle = Obj;
    //        //LoadedScene.Add(handle);
    //    }
    //}

    //public void UnloadScene(bool DoShowMenu)
    //{
    //    unloaded = true;
    //    DOTween.KillAll();
    //    Addressables.UnloadSceneAsync(handle, true).Completed += op =>
    //    {
    //        if (op.Status == AsyncOperationStatus.Succeeded)
    //        {
    //            print("Unload done");
    //            CanvasObj.SetActive(true);
    //            CameraObj.SetActive(true);
    //            EventSystemObj.SetActive(true);
    //            if(DoShowMenu)
    //            {
    //                OnClickLetStart();
    //            }

    //        }
    //    };
    //}

    //public void ClearLoadedSimulation()
    //{
    //    foreach (AsyncOperationHandle handle in LoadedScene)
    //    {
    //        if (handle.Result != null)
    //        {
    //            Addressables.ReleaseInstance(handle);
    //        }
    //    }
    //    LoadedScene.Clear();
    //}

    public void OnClickLetStart()
    {
        HideAllScreen();
        SimulationListScreen.SetActive(true);
    }

    public void BackToHomeScreen()
    {
        HideAllScreen();
        HomeScreen.SetActive(true);
    }

    //public void ReloadScene()
    //{
    //    DOTween.KillAll();
    //    Addressables.UnloadSceneAsync(handle, true).Completed += op =>
    //    {
    //        if (op.Status == AsyncOperationStatus.Succeeded)
    //        {
    //            print("Unload done");
    //            HideAllScreen();
    //            CanvasObj.SetActive(true);
    //            ReloadingScreen.SetActive(true);
    //            CameraObj.SetActive(true);
    //            StartCoroutine(ReloadSceneCo());
    //        }
    //    };
    //}

    //IEnumerator ReloadSceneCo()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    var downloadScene = Addressables.LoadSceneAsync(SimulationScenes[CurrentSceneIndex], LoadSceneMode.Additive);
    //    downloadScene.Completed += OnSceneReloadComplete;
    //}

    //public void OnSceneReloadComplete(AsyncOperationHandle<SceneInstance> Obj)
    //{
    //    if (Obj.Status == AsyncOperationStatus.Succeeded)
    //    {
    //        HideAllScreen();
    //        CanvasObj.SetActive(false);
    //        ReloadingScreen.SetActive(false);
    //        CameraObj.SetActive(false);
    //        EventSystemObj.SetActive(false);
    //        handle = Obj;
    //    }
    //}


}


[Serializable]
public class GetSimulationData
{
    public string result;
    public Sim_data[] data;
}

[Serializable]
public class Sim_data
{
    public string simulation_name;
    public string logo_url;
}