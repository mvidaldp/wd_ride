﻿using UnityEngine;
using LSL;

public class LSLStreams : MonoBehaviour
{
    public static LSLStreams Instance { get; private set; } // used to allow easy access of this script in other scripts
    private string participantUID; 
    private const double NominalRate = liblsl.IRREGULAR_RATE; // irregular sampling rate
    // variables to save date to LSL
    public liblsl.StreamInfo lslIValidationError; 
    public liblsl.StreamOutlet lslOValidationError; // saved in Validation.cs
    public liblsl.StreamInfo lslIEyeTrackingWorld;
    public liblsl.StreamOutlet lslOEyeTrackingWorld; // saved in ETRecorder.cs
    public liblsl.StreamInfo lslIEyeTrackingLocal;
    public liblsl.StreamOutlet lslOEyeTrackingLocal; // saved in ETRecorder.cs
    public liblsl.StreamInfo lslIHeadTracking;
    public liblsl.StreamOutlet lslOHeadTracking; // saved in ETRecorder.cs
    public liblsl.StreamInfo lslIHitObjectNames;
    public liblsl.StreamOutlet lslOHitObjectNames; // saved in ETRecorder.cs
    public liblsl.StreamInfo lslIHitObjectGroups;
    public liblsl.StreamOutlet lslOHitObjectGroups; // saved in ETRecorder.cs
    public liblsl.StreamInfo lslIHitObjectPositions;
    public liblsl.StreamOutlet lslOHitObjectPositions; // saved in ETRecorder.cs
    public liblsl.StreamInfo lslIHitPositionOnObjects;
    public liblsl.StreamOutlet lslOHitPositionOnObjects; // saved in ETRecorder.cs
 
    private void Awake()
    {
        // TODO -------------
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
       // Validation Error
        // saved: 3 coordinates of the error
        participantUID = WestdriveSettings.ParticipantUID;
        lslIValidationError = new liblsl.StreamInfo(
            "ValidationError",
            "Markers",
            3,
            NominalRate,
            liblsl.channel_format_t.cf_float32,
            participantUID);
        lslIValidationError.desc().append_child("ValX");
        lslIValidationError.desc().append_child("ValY");
        lslIValidationError.desc().append_child("ValZ");
        lslOValidationError = new liblsl.StreamOutlet(lslIValidationError);
        // World Coordinates
        // saved: Tobii timestamps (1); origin coordinates (3); direction coordinates (3), Left & right eye blinks (2), Check if ray is valid (1)
        lslIEyeTrackingWorld = new liblsl.StreamInfo(
            "EyeTrackingWorld",
            "Markers",
            10,
            NominalRate,
            liblsl.channel_format_t.cf_float32,
            participantUID);
        lslIEyeTrackingWorld.desc().append_child("ETWTime");
        lslIEyeTrackingWorld.desc().append_child("ETWoriginX");
        lslIEyeTrackingWorld.desc().append_child("ETWoriginY");
        lslIEyeTrackingWorld.desc().append_child("ETWoriginZ");
        lslIEyeTrackingWorld.desc().append_child("ETWdirectionX");
        lslIEyeTrackingWorld.desc().append_child("ETWdirectionY");
        lslIEyeTrackingWorld.desc().append_child("ETWdirectionZ");
        lslIEyeTrackingWorld.desc().append_child("leftBlink");
        lslIEyeTrackingWorld.desc().append_child("rightBlink");
        lslIEyeTrackingWorld.desc().append_child("valid");
        lslOEyeTrackingWorld = new liblsl.StreamOutlet(lslIEyeTrackingWorld);
        // Hit Object Names
        // saved: max 10 objects that the participant could potentially have looked up 
        lslIHitObjectNames = new liblsl.StreamInfo(
            "HitObjectNames",
            "Markers",
            30,
            NominalRate,
            liblsl.channel_format_t.cf_string,
            participantUID);
        lslIHitObjectNames.desc().append_child("HON");
        lslOHitObjectNames = new liblsl.StreamOutlet(lslIHitObjectNames);
        // Hit Object Groups 
        // saved: max 10 object groups that the participant could potentially have looked up 
        lslIHitObjectGroups = new liblsl.StreamInfo(
            "HitObjectGroups",
            "Markers",
            30,
            NominalRate,
            liblsl.channel_format_t.cf_string,
            participantUID);
        lslIHitObjectGroups.desc().append_child("HOG");
        lslOHitObjectGroups = new liblsl.StreamOutlet(lslIHitObjectGroups);
        // Hit Object Coordinates (in World Coordinates)
        // saved: 3 coordinates for each object that was potentially looked up (obj1_x, obj1_y, obj1_z, obj2_x, ...)
        lslIHitObjectPositions = new liblsl.StreamInfo(
            "HitObjectPositions",
            "Markers",
            90,
            NominalRate,
            liblsl.channel_format_t.cf_float32,
            participantUID);
        lslIHitObjectPositions.desc().append_child("HOPX");
        lslIHitObjectPositions.desc().append_child("HOPY");
        lslIHitObjectPositions.desc().append_child("HOPZ");
        lslOHitObjectPositions = new liblsl.StreamOutlet(lslIHitObjectPositions);
        // Hit Positions on Objects (in World Coordinates)
        // saved: 3 coordinates on each object that was potentially looked up (obj1_x, obj1_y, obj1_z, obj2_x, ...)
        lslIHitPositionOnObjects = new liblsl.StreamInfo(
            "HitPositionOnObjects",
            "Markers",
            90,
            NominalRate,
            liblsl.channel_format_t.cf_float32,
            participantUID);
        lslIHitPositionOnObjects.desc().append_child("HPOOX");
        lslIHitPositionOnObjects.desc().append_child("HPOOY");
        lslIHitPositionOnObjects.desc().append_child("HPOOZ");
        lslOHitPositionOnObjects = new liblsl.StreamOutlet(lslIHitPositionOnObjects);
        // Local Coordinates
        // saved: origin coordinates (3); direction coordinates (3)
        lslIEyeTrackingLocal = new liblsl.StreamInfo(
            "EyeTrackingLocal",
            "Markers",
            6,
            NominalRate,
            liblsl.channel_format_t.cf_float32,
            participantUID);
        lslIEyeTrackingLocal.desc().append_child("ETLoriginX");
        lslIEyeTrackingLocal.desc().append_child("ETLoriginY");
        lslIEyeTrackingLocal.desc().append_child("ETLoriginZ");
        lslIEyeTrackingLocal.desc().append_child("ETLdirectionX");
        lslIEyeTrackingLocal.desc().append_child("ETLdirectionY");
        lslIEyeTrackingLocal.desc().append_child("ETLdirectionZ");
        lslOEyeTrackingLocal = new liblsl.StreamOutlet(lslIEyeTrackingLocal);

        // Head Tracking
        // saved: Head (camera) position (3); nose vector (3)
        lslIHeadTracking = new liblsl.StreamInfo(
            "HeadTracking",
            "Markers",
            6,
            NominalRate,
            liblsl.channel_format_t.cf_float32,
            participantUID);
        lslIHeadTracking.desc().append_child("HToriginX");
        lslIHeadTracking.desc().append_child("HToriginY");
        lslIHeadTracking.desc().append_child("HToriginZ");
        lslIHeadTracking.desc().append_child("HTdirectionX");
        lslIHeadTracking.desc().append_child("HTdirectionY");
        lslIHeadTracking.desc().append_child("HTdirectionZ");
        lslOHeadTracking = new liblsl.StreamOutlet(lslIHeadTracking);
    }
}
