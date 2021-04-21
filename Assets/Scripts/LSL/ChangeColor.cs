using System;
using LSL;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Color32 colorOne;
    private Color32 colorTwo;
    private float referenceTime; 
    private AudioSource audioSource; // to play an audio clip
    private Renderer renderer1;
    private bool isPlaying;
    private bool colorChanged;

    private const int LslChannelCount = 2;
    private Guid uuidColor;
    private Guid uuidAudio;
    private const double NominalRate = liblsl.IRREGULAR_RATE;
    private const liblsl.channel_format_t LslChannelFormat = liblsl.channel_format_t.cf_int32;
    private liblsl.StreamInfo lslStreamInfoColor;
    private liblsl.StreamOutlet lslOutletColor;
    private liblsl.StreamInfo lslStreamInfoAudio;
    private liblsl.StreamOutlet lslOutletAudio;
    // Assuming that markers are never send in regular intervals
        

    void Start()
    {
        colorOne = Color.black;
        colorTwo = Color.white;
        referenceTime = 0.5f;
        audioSource = GetComponent<AudioSource>();
        renderer1 = GetComponent<Renderer>();
        isPlaying = false;
        colorChanged = false;
            
        uuidColor = Guid.NewGuid();
        liblsl.StreamInfo streamInfoColor = new liblsl.StreamInfo(
            "Diode",
            "Markers",
            LslChannelCount,
            NominalRate,
            LslChannelFormat,
            uuidColor.ToString());
        
        uuidAudio = Guid.NewGuid();
        liblsl.StreamInfo streamInfoAudio = new liblsl.StreamInfo(
            "Audio",
            "Markers",
            LslChannelCount,
            NominalRate,
            LslChannelFormat,
            uuidAudio.ToString());
        
        lslOutletColor = new liblsl.StreamOutlet(streamInfoColor);
        lslOutletAudio = new liblsl.StreamOutlet(streamInfoAudio);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        referenceTime -= Time.deltaTime;
        if (referenceTime < 0)
        {
            renderer1.material.color = colorTwo;
            audioSource.Play();
            referenceTime = 0.5f;
        }
        else
        {
            renderer1.material.color = colorOne;
        }
        
        colorChanged = renderer1.material.color == colorTwo;
        isPlaying = audioSource.isPlaying;
        
        var cFrame = Time.frameCount;
        
        var dataColor = new int[2];
        var dataAudio = new int[2];
        dataColor[0] = cFrame;
        dataAudio[0] = cFrame;
        dataColor[1] = colorChanged ? 1 : 0;
        dataAudio[1] = isPlaying ? 1 : 0;

        lslOutletColor.push_sample(dataColor);
        lslOutletAudio.push_sample(dataAudio);
    }
}