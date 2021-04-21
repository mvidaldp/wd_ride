using Tobii.XR;
using UnityEngine;
using ViveSR.anipal.Eye;


public class ETM : MonoBehaviour
{
    // https://vr.tobii.com/sdk/develop/unity/documentation/api-reference/core/
    // http://developer.tobiipro.com/unity/unity-getting-started.html

    //public static ETM Instance { get; private set; } // to make it easy to call this script within other scripts

    // public variables assigned in the inspector
    public Validation validation; // call to validation script
    public bool valOngoing = false;
    public bool recording = false;
    
    // private variables 
    private TobiiXR_Settings settings; 

    
    void Start()
    {
        // get eye tracker started
        settings = new TobiiXR_Settings();
        // settings.FieldOfUse = FieldOfUse.Interactive; // new API, not working with ours
        TobiiXR.Start(settings);
        
        // Start the experiment with calibration and then validation 
        //SRanipal_Eye_v2.LaunchEyeCalibration();
        valOngoing = true;
        // validation.ValidationRoutine();
        validation.StartValidation();
    }
    
    void FixedUpdate()
    {
        // manually start Calibration when pressing C
        if (Input.GetKeyDown(KeyCode.C))
        {
            // start calibration
            SRanipal_Eye_v2.LaunchEyeCalibration();
        } 
        // manually start validation when pressing V
        else if (Input.GetKeyDown(KeyCode.V)) // TODO: add something to check you are not doing validation
        {
            // change the variables to ensure that the timer is paused
            recording = false;
            valOngoing = true;
            validation.StartValidation();
        }

        if (!valOngoing && !recording)
        {
            
            recording = true;
        }
    }
    
}