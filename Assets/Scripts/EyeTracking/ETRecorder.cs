using Tobii.XR;
using UnityEngine;

public class ETRecorder : MonoBehaviour
{
    public GameObject player; // to access the player
    public ETM etm;
    private Vector3 headPosition; // used to save head-tracking data
    private Vector3 noseVector; // used to save head-tracking data
    private TobiiXR_EyeTrackingData _eyeTrackingWorld;
    private TobiiXR_EyeTrackingData _eyeTrackingLocal;
    private float rayVal;


    // Save Data through LSL (streams defined in LSLStreams)
    void SaveHeadTracker(float[] headTracking)
    {
        LSLStreams.Instance.lslOHeadTracking.push_sample(headTracking);
    }
    void SaveEyeTrackingWorld(float[] eyeTrackingValues)
    {
        LSLStreams.Instance.lslOEyeTrackingWorld.push_sample(eyeTrackingValues);
    }
    void SaveEyeTrackingLocal(float[] eyeTrackingValues)
    {
        LSLStreams.Instance.lslOEyeTrackingLocal.push_sample(eyeTrackingValues);
    }

    // function to end recording called in ETM when Validation is launched
    public void StopRecording()
    {
        // end recording 
        //ETM.recording = false;
    }

    void FixedUpdate()
    {
          // while the Coroutine is going on
        if (etm.recording)
        {
            /* GetEyeTrackingData():
             * Gets eye tracking data in the selected tracking space. Unless the underlying eye tracking provider does
             * prediction, this data is not predicted. Subsequent calls within the same frame will return the same
             * value.
             */
            _eyeTrackingWorld = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World);
            _eyeTrackingLocal = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.Local);
            // if you have an eye-tracking sample in world space:
            rayVal = (float) (_eyeTrackingWorld.GazeRay.IsValid ? 1.0 : 0.0);
            // check if left or right eye are detected as blinking
            float leftEyeBlinking = _eyeTrackingWorld.IsLeftEyeBlinking ? 1f : 0f;
            float rightEyeBlinking = _eyeTrackingWorld.IsRightEyeBlinking ? 1f : 0f;
            // add things into array to push to LSL
            float[] worldData =
            {
                _eyeTrackingWorld.Timestamp,
                _eyeTrackingWorld.GazeRay.Origin.x,
                _eyeTrackingWorld.GazeRay.Origin.y,
                _eyeTrackingWorld.GazeRay.Origin.z,
                _eyeTrackingWorld.GazeRay.Direction.x,
                _eyeTrackingWorld.GazeRay.Direction.y,
                _eyeTrackingWorld.GazeRay.Direction.z,
                leftEyeBlinking,
                rightEyeBlinking,
                rayVal
            };
            // call function to push world-space data to LSL
            SaveEyeTrackingWorld(worldData);


            // add things into array to push to LSL
            float[] localData =
            {
                _eyeTrackingLocal.GazeRay.Origin.x,
                _eyeTrackingLocal.GazeRay.Origin.y,
                _eyeTrackingLocal.GazeRay.Origin.z,
                _eyeTrackingLocal.GazeRay.Direction.x,
                _eyeTrackingLocal.GazeRay.Direction.y,
                _eyeTrackingLocal.GazeRay.Direction.z,
            };
            // call function to push local-space data to LSL
            SaveEyeTrackingLocal(localData);
        
            
            // Get HeadTracking Data: save the position and the direction
            headPosition = player.transform.position;
            noseVector = player.transform.forward;
            // put head-tracking data into array that can be saved with LSL (both vectors in same array)
            float[] headTracker =
            {
                headPosition.x, headPosition.y, headPosition.z, noseVector.x, noseVector.y, noseVector.z
            };
            // call function to push head-tracking data to LSL
            SaveHeadTracker(headTracker);
        }
    }
    
}
