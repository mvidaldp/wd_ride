using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastingTest : MonoBehaviour
{
    // Start is called before the first frame update
    // public Camera;
    public GameObject cam;
    void Start()
    {
        
    }

    // Update is called once per frame
private void Update()
    {
        // if (isTracking)
        // {
        //     PositionRotationType dataPoint = new PositionRotationType();
        //     dataPoint.position = gameObject.transform.position;
        //     dataPoint.rotaion = gameObject.transform.rotation;
        //     if (!recordedData.Data.ContainsKey(Time.frameCount - WestdriveSettings.frameCorrection))
        //         recordedData.Data.Add(Time.frameCount - WestdriveSettings.frameCorrection, dataPoint);
        //     else
        //         recordedData.Data[Time.frameCount - WestdriveSettings.frameCorrection] = dataPoint;
        // }

        // else if (isRayCasting && WestdriveSettings.isPlaying)
        // {
        //     if (currentFrame <= lastFrame)
        //     {
                
                AnalyzableData frameData = new AnalyzableData();
                HitPositionType hitPositions = new HitPositionType();
                // frameData.frameNumber = currentFrame;
                // transform.position = recordedData.Data[currentFrame].position;
                // transform.rotation = recordedData.Data[currentFrame].rotaion;
                frameData.trackerPosition = transform.position;
                frameData.trackerRotation = transform.rotation;
                hitPositions.cameraPosition = transform.position;
                hitPositions.cameraRotation = transform.rotation;
                Ray imaginaryMiddleEye =
                    cam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                

                RaycastHit centerHit;
                Debug.DrawRay(imaginaryMiddleEye.origin, imaginaryMiddleEye.direction * 1000, Color.red);
                
                if (Physics.Raycast(imaginaryMiddleEye, out centerHit,Mathf.Infinity,1 <<WestdriveSettings.trackableLayerMask))
                {
                    frameData.centerHit = centerHit.transform.name;
                    // Debug.Log("Object: " + frameData.centerHit);
                    hitPositions.centerHitPostion =  centerHit.point;
                    frameData.centerHitPosition = centerHit.point;
                    frameData.centerHitGroup = centerHit.transform.root.name;
                    //Debug.Log("Group: " + frameData.centerHitGroup);
                    
                    
                }
                else
                {
                    frameData.centerHit = "null";
                    hitPositions.centerHitPostion = Vector3.zero;
                    frameData.centerHitPosition = Vector3.zero;
                    frameData.centerHitGroup = "null";
                    
                }
                RaycastHit boxHit;
                if (Physics.BoxCast(transform.position, new Vector3(5,5,5), transform.forward, out boxHit,
                    transform.rotation, Mathf.Infinity, 1 << WestdriveSettings.trackableLayerMask))
                {
                    frameData.boxHit = boxHit.transform.name;
                    hitPositions.boxHitPostion =  boxHit.point;
                    frameData.boxHitPosition = boxHit.point;
                    frameData.boxHitGroup = boxHit.transform.root.name;
                    
                }
                else
                {
                    frameData.boxHit = "null";
                    hitPositions.boxHitPostion = Vector3.zero;
                    frameData.boxHitPosition = Vector3.zero;
                    frameData.boxHitGroup = "null";
                     
                }
                Collider[] environment = Physics.OverlapBox(transform.position, new Vector3(5,5,Mathf.Infinity), 
                    transform.rotation, 1 << WestdriveSettings.trackableLayerMask);
                frameData.presentObjectName = "";
                frameData.presentObjectGroup = "";
                if (environment.Length == 0)
                {
                    frameData.presentObjectName += "null";
                    frameData.presentObjectGroup += "null";
                    
                }
                else
                {
                    foreach (Collider presentObject in environment)
                    {
                        frameData.presentObjectName += (presentObject.transform.name + "*");
                        frameData.presentObjectGroup += (presentObject.transform.root.name + "*");
                       
                    }
                }
                // }
        }
}
