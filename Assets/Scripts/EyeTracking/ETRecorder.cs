using System;
using System.Collections.Generic;
using Tobii.XR;
using UnityEngine;

public class ETRecorder : MonoBehaviour
{
    public GameObject player; // to access the player
    private Vector3 headPosition; // used to save head-tracking data
    private Vector3 noseVector; // used to save head-tracking data
    private TobiiXR_EyeTrackingData _eyeTrackingWorld;
    private TobiiXR_EyeTrackingData _eyeTrackingLocal;

    private float rayVal;

    // private variables 
    private TobiiXR_Settings settings;

    private void Start()
    {
        // get eye tracker started
        settings = new TobiiXR_Settings();
        // settings.FieldOfUse = FieldOfUse.Interactive; // new API, not working with ours
        TobiiXR.Start(settings);
    }


    // Save Data through LSL (streams defined in LSLStreams)
    void SaveHeadTracker(float[] headTracking)
    {
        LSLStreams.Instance.lslOHeadTracking.push_sample(headTracking);
    }

    void SaveEyeTrackingWorld(float[] eyeTrackingValues)
    {
        LSLStreams.Instance.lslOEyeTrackingWorld.push_sample(eyeTrackingValues);
    }

    void SaveHitObjects(string[] objectNames, string[] objectGroups, float[] objectPositions, float[] positionOnObject)
    {
        LSLStreams.Instance.lslOHitObjectNames.push_sample(objectNames);
        LSLStreams.Instance.lslOHitObjectGroups.push_sample(objectGroups);
        LSLStreams.Instance.lslOHitObjectPositions.push_sample(objectPositions);
        LSLStreams.Instance.lslOHitPositionOnObjects.push_sample(positionOnObject);
    }

    void SaveHeadTrackingObjects(string[] objectNames, string[] objectGroups, float[] objectPositions,
        float[] positionOnObject)
    {
        LSLStreams.Instance.lslOHeadTrackingObjectNames.push_sample(objectNames);
        LSLStreams.Instance.lslOHeadTrackingObjectGroups.push_sample(objectGroups);
        LSLStreams.Instance.lslOHeadTrackingObjectPositions.push_sample(objectPositions);
        LSLStreams.Instance.lslOHeadTrackingPositionOnObjects.push_sample(positionOnObject);
    }

    void SaveEyeTrackingLocal(float[] eyeTrackingValues)
    {
        LSLStreams.Instance.lslOEyeTrackingLocal.push_sample(eyeTrackingValues);
    }

    private void GetHitObjectsFromGaze(Vector3 gazeOrigin, Vector3 gazeDirection)
    {
        // origin: The starting point of the ray in world coordinates.; direction: The direction of the ray.
        RaycastHit[] hitColliders = Physics.RaycastAll(gazeOrigin, gazeDirection, 250.0f);

        // lists to save information of hit objects
        List<string> hitObjectNames = new List<string>();
        List<string> hitObjectGroups = new List<string>();
        List<float> hitObjectPositions = new List<float>();
        List<float> hitPositionOnObject = new List<float>();

        // you calculate to collider hit and add the object that was hit (name, position, where on the object it was hit)
        foreach (var colliderhit in hitColliders)
        {
            hitObjectNames.Add(colliderhit.collider.gameObject.name);
            hitObjectGroups.Add(colliderhit.collider.transform.root.name);
            hitObjectPositions.Add(colliderhit.collider.transform.position.x);
            hitObjectPositions.Add(colliderhit.collider.transform.position.y);
            hitObjectPositions.Add(colliderhit.collider.transform.position.z);
            hitPositionOnObject.Add(colliderhit.point.x);
            hitPositionOnObject.Add(colliderhit.point.y);
            hitPositionOnObject.Add(colliderhit.point.z);
        }
        // we created lists of 30 objects to be pushed to LSL, so we have to create lists of 30 objects 
        // therefore we fill up the rest of the list with placeholders ("empty"; 0)
        for (int i = hitObjectNames.Count; i < 30; i++) hitObjectNames.Add("Empty");
        for (int i = hitObjectGroups.Count; i < 30; i++) hitObjectGroups.Add("Empty");
        for (int i = hitObjectPositions.Count; i < 90; i++)
        {
            hitObjectPositions.Add(0);
            hitPositionOnObject.Add(0);
        }

        // transform the lists to arrays so we can push them to LSL (LSL does not accept lists)
        string[] names = hitObjectNames.GetRange(0, 30).ToArray();
        string[] groups = hitObjectGroups.GetRange(0, 30).ToArray();
        float[] positions = hitObjectPositions.GetRange(0, 90).ToArray();
        float[] positionOnObject = hitPositionOnObject.GetRange(0, 90).ToArray();
        //Debug.Log(hitObjectNames[0]);
        // call the function to push the samples to LSL
        SaveHitObjects(names, groups, positions, positionOnObject);
    }

    private void GetHitObjectsFromNoseVector(Vector3 gazeOrigin, Vector3 gazeDirection)
    {
        AnalyzableData frameData = new AnalyzableData();
        HitPositionType hitPositions = new HitPositionType();
        frameData.trackerPosition = transform.position;
        frameData.trackerRotation = transform.rotation;
        hitPositions.cameraPosition = transform.position;
        hitPositions.cameraRotation = transform.rotation;

        // Debug.DrawRay(imaginaryMiddleEye.origin, imaginaryMiddleEye.direction * 1000, Color.red);
        RaycastHit[] headTrackingColliders = Physics.RaycastAll(gazeOrigin, gazeDirection, 250.0f);
        // lists to save information of hit objects
        List<string> headTrackingObjectNames = new List<string>();
        List<string> headTrackingObjectGroups = new List<string>();
        List<float> headTrackingObjectPositions = new List<float>();
        List<float> headTrackingPositionOnObject = new List<float>();

        // you calculate to collider hit and add the object that was hit (name, position, where on the object it was hit)
        foreach (var colliderhit in headTrackingColliders)
        {
            headTrackingObjectNames.Add(colliderhit.collider.gameObject.name);
            headTrackingObjectGroups.Add(colliderhit.collider.transform.root.name);
            headTrackingObjectPositions.Add(colliderhit.collider.transform.position.x);
            headTrackingObjectPositions.Add(colliderhit.collider.transform.position.y);
            headTrackingObjectPositions.Add(colliderhit.collider.transform.position.z);
            headTrackingPositionOnObject.Add(colliderhit.point.x);
            headTrackingPositionOnObject.Add(colliderhit.point.y);
            headTrackingPositionOnObject.Add(colliderhit.point.z);
        }

        // we created lists of 30 objects to be pushed to LSL, so we have to create lists of 30 objects 
        // therefore we fill up the rest of the list with placeholders ("empty"; 0)
        for (int i = headTrackingObjectNames.Count; i < 30; i++) headTrackingObjectNames.Add("Empty");
        for (int i = headTrackingObjectGroups.Count; i < 30; i++) headTrackingObjectGroups.Add("Empty");
        for (int i = headTrackingObjectPositions.Count; i < 90; i++)
        {
            headTrackingObjectPositions.Add(0);
            headTrackingPositionOnObject.Add(0);
        }

        // transform the lists to arrays so we can push them to LSL (LSL does not accept lists)
        string[] names = headTrackingObjectNames.GetRange(0, 30).ToArray();
        string[] groups = headTrackingObjectGroups.GetRange(0, 30).ToArray();
        float[] positions = headTrackingObjectPositions.GetRange(0, 90).ToArray();
        float[] positionOnObject = headTrackingPositionOnObject.GetRange(0, 90).ToArray();
        // call the function to push the samples to LSL
        SaveHeadTrackingObjects(names, groups, positions, positionOnObject);
    }

    void FixedUpdate()
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

        // call function GetHitObjectsFromGaze to check which objects in the scene were fixated on
        Vector3 gazeRayOrigin = _eyeTrackingWorld.GazeRay.Origin;
        Vector3 gazeRayDirection = _eyeTrackingWorld.GazeRay.Direction;
        GetHitObjectsFromGaze(gazeRayOrigin, gazeRayDirection);

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
        // raycast headtracking (nose vector) and then push it to LSL
        GetHitObjectsFromNoseVector(headPosition, noseVector);
        // save current frame via LSL
        int[] currentFrame = {Time.frameCount};
        LSLStreams.Instance.lslOFrameTracking.push_sample(currentFrame);
    }
}