using UnityEngine;

public class PlaneInfrontOfCam : MonoBehaviour
{
    public float distance; // distance to plane
    public Transform cam; // the camera it should be infront of

    void Update ()
    {
        // to ensure the plane is always in front of the camera
        // disadvantage: it will also rotate if the camera is rotated 
        transform.position = cam.position + cam.forward * distance; 
    }
}
