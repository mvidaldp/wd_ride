using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using  ProtoBuf;
using System.IO;
using System.Threading.Tasks;
/// <summary>
/// Simulates a thir eye and tracks its looking direction
/// </summary>
public class HeadTracker : GenericTracker
{
    private Vector3 headPosition; // used to save head-tracking data
    private Vector3 noseVector; // used to save head-tracking data

    //private PositionRotationType dataPoint;
    
    public HeadTracker()
    {
        base.recordedData = new TrackingData();
        //this.dataPoint = new PositionRotationType();

    }

    private void Awake()
    {
        if (WestdriveSettings.SimulationMode == mode.visualize)
            GameObject.Find("EyeTrackingManager").SetActive(false);
    }

    //tracks the headposition, rotation and movement 
    
    private void Update()
    {
        if (isTracking)
        {
            PositionRotationType dataPoint = new PositionRotationType();
            dataPoint.position = gameObject.transform.position;
            dataPoint.rotaion = gameObject.transform.rotation;
            if (!recordedData.Data.ContainsKey(Time.frameCount - WestdriveSettings.frameCorrection))
                recordedData.Data.Add(Time.frameCount - WestdriveSettings.frameCorrection, dataPoint);
            else
                recordedData.Data[Time.frameCount - WestdriveSettings.frameCorrection] = dataPoint;
        }
        else if (isRayCasting && WestdriveSettings.isPlaying)
        {
            if (currentFrame <= lastFrame)
            {
                AnalyzableData frameData = new AnalyzableData();
                HitPositionType hitPositions = new HitPositionType();
                frameData.frameNumber = currentFrame;
                transform.position = recordedData.Data[currentFrame].position;
                transform.rotation = recordedData.Data[currentFrame].rotaion;
                headPosition = transform.position;
                noseVector = transform.forward; // same as => transform.rotation * Vector3.forward
                frameData.trackerPosition = transform.position;
                frameData.trackerRotation = transform.rotation;
                frameData.noseVector = noseVector;
                hitPositions.cameraPosition = transform.position;
                hitPositions.cameraRotation = transform.rotation;
                RaycastHit[] htResults = new RaycastHit[100];
                var hits = Physics.RaycastNonAlloc(recordedData.Data[currentFrame].position, (Quaternion) recordedData.Data[currentFrame].rotaion * Vector3.forward, htResults, 2200.0f);
                // lists to save information of hit objects
                List<string> headTrackingObjectNames = new List<string>();
                List<string> headTrackingObjectGroups = new List<string>();
                List<string> headTrackingObjectPositions = new List<string>();
                List<string> headTrackingPositionOnObjects = new List<string>();
                // Ray imaginaryMiddleEye =
                //     GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                // RaycastHit centerHit;
                // Debug.DrawRay(imaginaryMiddleEye.origin, imaginaryMiddleEye.direction * 1000, Color.red);
                if (hits > 0) {
                    // you calculate to collider hit and add the object that was hit (name, position, where on the object it was hit)
                    for (int i = 0; i < hits; i++)
                    { 
                        RaycastHit colliderhit = htResults[i];
                        headTrackingObjectNames.Add(colliderhit.collider.gameObject.name);
                        headTrackingObjectGroups.Add(colliderhit.collider.transform.root.name);
                        string hToP = "(" + colliderhit.collider.transform.position.x + ", " +
                                      colliderhit.collider.transform.position.y + ", " +
                                      colliderhit.collider.transform.position.z + ")";
                        string hTpOo = "(" + colliderhit.point.x + ", " +
                                       colliderhit.point.y + ", " +
                                       colliderhit.point.z + ")";
                        headTrackingObjectPositions.Add(hToP);
                        headTrackingPositionOnObjects.Add(hTpOo);
                    }
                    frameData.hitObjectNames = string.Join(", ", headTrackingObjectNames);
                    frameData.hitObjectPositions = string.Join(", ", headTrackingObjectPositions);
                    frameData.hitPositionOnObjects = string.Join(", ", headTrackingPositionOnObjects);
                    hitPositions.centerHitPostion = htResults[0].point;  // to ensure it doesn't break
                    frameData.hitObjectGroups = string.Join(", ", headTrackingObjectGroups);
                } else {
                    frameData.hitObjectNames = "null";
                    frameData.hitObjectPositions = "null";
                    frameData.hitPositionOnObjects = "null";
                    hitPositions.centerHitPostion = Vector3.zero;
                    frameData.hitObjectGroups = "null";
                }
                
                // if (Physics.Raycast(imaginaryMiddleEye, out centerHit,Mathf.Infinity,1 <<WestdriveSettings.trackableLayerMask))
                // {
                //     frameData.centerHit = centerHit.transform.name;
                //     hitPositions.centerHitPostion =  centerHit.point;
                //     frameData.centerHitPosition = centerHit.point;
                //     frameData.centerHitGroup = centerHit.transform.root.name;
                // } else {
                //     frameData.centerHit = "null";
                //     hitPositions.centerHitPostion = Vector3.zero;
                //     frameData.centerHitPosition = Vector3.zero;
                //     frameData.centerHitGroup = "null";
                    
                // }
                // RaycastHit boxHit;
                // if (Physics.BoxCast(transform.position, new Vector3(5,5,5), transform.forward, out boxHit,
                //     transform.rotation, Mathf.Infinity, 1 << WestdriveSettings.trackableLayerMask))
                // {
                //     frameData.boxHit = boxHit.transform.name;
                //     hitPositions.boxHitPostion =  boxHit.point;
                //     frameData.boxHitPosition = boxHit.point;
                //     frameData.boxHitGroup = boxHit.transform.root.name;
                    
                // }
                // else
                // {
                //     frameData.boxHit = "null";
                //     hitPositions.boxHitPostion = Vector3.zero;
                //     frameData.boxHitPosition = Vector3.zero;
                //     frameData.boxHitGroup = "null";
                     
                // }
                // Collider[] environment = Physics.OverlapBox(transform.position, new Vector3(5,5,Mathf.Infinity), 
                //     transform.rotation, 1 << WestdriveSettings.trackableLayerMask);
                // frameData.presentObjectName = "";
                // frameData.presentObjectGroup = "";
                // if (environment.Length == 0)
                // {
                //     frameData.presentObjectName += "null";
                //     frameData.presentObjectGroup += "null";
                    
                // }
                // else
                // {
                //     foreach (Collider presentObject in environment)
                //     {
                //         frameData.presentObjectName += (presentObject.transform.name + "*");
                //         frameData.presentObjectGroup += (presentObject.transform.root.name + "*");
                       
                //     }
                // }               
                WestdriveSettings.processedData.Add(frameData);
                WestdriveSettings.hitData.Data.Add(currentFrame, hitPositions);
                TimeGaurd.setCurrentFrame(currentFrame);
                currentFrame++;
            }
        }
    }

    
    
   
}
