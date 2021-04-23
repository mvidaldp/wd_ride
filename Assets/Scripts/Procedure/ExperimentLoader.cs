using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;
using Tobii.XR;
using ViveSR.anipal.Eye;

/// <summary>
/// Loads the First announcement and loads the City in the background
/// </summary>
public class ExperimentLoader : MonoBehaviour {


    private bool startSceneLoad = false;
    private TobiiXR_Settings settings; 
    public Validation validation; // call to validation script


    public bool isLoading
    {
        get
        {
            return startSceneLoad;
        }
    }
    [Header("Components")]
    //public VideoPlayer loadingVideoOne;
    //public VideoPlayer loadingVideoTwo;
    public GameObject mainCamera;
    public CanvasGroup screen;
    public GameObject loader;
    [Space]
    [Header("parameters")]
    [Range(0,1)]
    public float fadeSpeed = 0.05f;
    public float frameWaitSpeed = 0.01f;
    public float pauseForFirstVideo = 10f;
    public float logoPauseTime = 3f;
    // Stops all coroutines and loads the startNewScene Method
    private void Awake()
    {
        StopAllCoroutines();
        
        //Invoke("StartNewScene", logoPauseTime);
        StartCoroutine(StartNewScene());
    }
    //Starts the new Scene and loads the City in the background
    IEnumerator StartNewScene()
    {
        if (!startSceneLoad)
        {
                Debug.Log("Input Detected!");
                startSceneLoad = true;
                //DO EYE STUFF HERE
                // get eye tracker started
                settings = new TobiiXR_Settings();
                // settings.FieldOfUse = FieldOfUse.Interactive; // new API, not working with ours
                TobiiXR.Start(settings);
                
        
                // Start the experiment with calibration and then validation 
                //SRanipal_Eye_v2.LaunchEyeCalibration();
                validation.valOngoing = true;
                validation.StartValidation();
                while (validation.valOngoing)
                    yield return null;
                if (!validation.valOngoing) StartCoroutine(loadCityAsync());
        }
    }
    //loads the City in the background without switching scenes
    IEnumerator loadCityAsync()
    {
        Debug.Log("Loading coroutine started");
        /*float fadeAlpha = 1f;
        while(fadeAlpha >=0f)
        {
            screen.alpha = fadeAlpha;
            fadeAlpha -= fadeSpeed;
            yield return new WaitForSeconds(frameWaitSpeed);
        }
        screen.alpha = 0f;
        fadeAlpha = 0f;
        yield return new WaitForEndOfFrame();
        */
        
        Debug.Log("loading city scene in background started");        
        loader.GetComponent<Valve.VR.SteamVR_LoadLevel>().Trigger();
        yield return null;
    }
    //stops all Coroutines
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
