using UnityEngine;
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
