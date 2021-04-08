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
    public liblsl.StreamInfo lslIHitObjectNames;
    public liblsl.StreamOutlet lslOHitObjectNames; // saved in ETRecorder.cs
    public liblsl.StreamInfo lslIHitObjectPositions;
    public liblsl.StreamOutlet lslOHitObjectPositions; // saved in ETRecorder.cs
    public liblsl.StreamInfo lslIHitPositionOnObjects;
    public liblsl.StreamOutlet lslOHitPositionOnObjects; // saved in ETRecorder.cs
    public liblsl.StreamInfo lslIAgentPosition;
    public liblsl.StreamOutlet lslOAgentPosition; // saved in NPCPatrol.cs && NPCPatrolAfterSpawn.cs
    public liblsl.StreamInfo lslIStaticAgentPosition;
    public liblsl.StreamOutlet lslOStaticAgentPosition; // saved in StaticNPCSave.cs 
    public liblsl.StreamInfo lslIPlayerPosition;
    public liblsl.StreamOutlet lslOPlayerPosition; // saved in PlayerPositionTracker.cs
    public liblsl.StreamInfo lslIHeadTracking;
    public liblsl.StreamOutlet lslOHeadTracking; // saved in ETRecorder.cs
    public liblsl.StreamInfo lslIButtonPresses;
    public liblsl.StreamOutlet lslOButtonPresses; // saved in MovementInput.cs

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
        //participantUID = ExpManager.Instance.participantID.ToString();
        participantUID = "FIX THIS";
        lslIValidationError = new liblsl.StreamInfo(
            "ValidationError",
            "Markers",
            3,
            NominalRate,
            liblsl.channel_format_t.cf_float32,
            participantUID);
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
        lslOEyeTrackingWorld = new liblsl.StreamOutlet(lslIEyeTrackingWorld);
        // Hit Objects 
        // saved: max 10 objects that the participant could potentially have looked up 
        lslIHitObjectNames = new liblsl.StreamInfo(
            "HitObjectNames",
            "Markers",
            10,
            NominalRate,
            liblsl.channel_format_t.cf_string,
            participantUID);
        lslOHitObjectNames = new liblsl.StreamOutlet(lslIHitObjectNames);
        // Hit Object Coordinates (in World Coordinates)
        // saved: 3 coordinates for each object that was potentially looked up (obj1_x, obj1_y, obj1_z, obj2_x, ...)
        lslIHitObjectPositions = new liblsl.StreamInfo(
            "HitObjectPositions",
            "Markers",
            30,
            NominalRate,
            liblsl.channel_format_t.cf_float32,
            participantUID);
        lslOHitObjectPositions = new liblsl.StreamOutlet(lslIHitObjectPositions);
        // Hit Positions on Objects (in World Coordinates)
        // saved: 3 coordinates on each object that was potentially looked up (obj1_x, obj1_y, obj1_z, obj2_x, ...)
        lslIHitPositionOnObjects = new liblsl.StreamInfo(
            "HitPositionOnObjects",
            "Markers",
            30,
            NominalRate,
            liblsl.channel_format_t.cf_float32,
            participantUID);
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
        lslOEyeTrackingLocal = new liblsl.StreamOutlet(lslIEyeTrackingLocal);
        // Agent Positions
        // saved: Agent ID (1); agent position (3)
        lslIAgentPosition = new liblsl.StreamInfo(
            "AgentPosition",
            "Markers",
            4,
            NominalRate,
            liblsl.channel_format_t.cf_float32,
            participantUID);
        lslOAgentPosition = new liblsl.StreamOutlet(lslIAgentPosition);
        // Static Agent Positions
        // saved at the beginning once: Agent ID (1); agent position (3)
        lslIStaticAgentPosition = new liblsl.StreamInfo(
            "StaticAgentPosition",
            "Markers",
            4,
            NominalRate,
            liblsl.channel_format_t.cf_float32,
            participantUID);
        lslOStaticAgentPosition = new liblsl.StreamOutlet(lslIStaticAgentPosition);
        // Player Positions
        // saved: Player position (3)
        lslIPlayerPosition = new liblsl.StreamInfo(
            "PlayerPosition",
            "Markers",
            3,
            NominalRate,
            liblsl.channel_format_t.cf_float32,
            participantUID);
        lslOPlayerPosition = new liblsl.StreamOutlet(lslIPlayerPosition);
        // Head Tracking
        // saved: Head (camera) position (3); nose vector (3)
        lslIHeadTracking = new liblsl.StreamInfo(
            "HeadTracking",
            "Markers",
            6,
            NominalRate,
            liblsl.channel_format_t.cf_float32,
            participantUID);
        lslOHeadTracking = new liblsl.StreamOutlet(lslIHeadTracking);
        // Button Presses
        // saved: y-position of controller input and -2 if there is no input
        lslIButtonPresses = new liblsl.StreamInfo(
            "ButtonPresses",
            "Markers",
            1,
            NominalRate,
            liblsl.channel_format_t.cf_float32,
            participantUID);
        lslOButtonPresses = new liblsl.StreamOutlet(lslIButtonPresses);
    }
}
