using Tobii.XR;
using UnityEngine;
using ViveSR.anipal.Eye;


public class ETM : MonoBehaviour
{
    // https://vr.tobii.com/sdk/develop/unity/documentation/api-reference/core/
    // http://developer.tobiipro.com/unity/unity-getting-started.html

    //public static ETM Instance { get; private set; } // to make it easy to call this script within other scripts

    // public variables assigned in the inspector
    public bool recording = true;
    public Validation validation; // call to validation script

    // private variables 
    //private TobiiXR_Settings settings; 

    
    void FixedUpdate()
    {
        // manually start Calibration when pressing C
        if (Input.GetKeyDown(KeyCode.C))
        {
            // start calibration
            SRanipal_Eye_v2.LaunchEyeCalibration();
        } 
        // manually start validation when pressing V
        else if (Input.GetKeyDown(KeyCode.V)) 
        {
            // change the variables to ensure that the timer is paused
            recording = false;
            validation.valOngoing = true;
            validation.StartValidation();
        }

        if (!validation.valOngoing && !recording)
        {
            
            recording = true;
        }
    }
    
}