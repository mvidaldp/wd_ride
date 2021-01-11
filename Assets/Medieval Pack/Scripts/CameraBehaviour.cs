using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	// Use this for initialization
	public float ScrWidth;
	public float ScrHeight;
	public float mousepositionX;
	private Vector3 temp;
	private float time;
	public float MovingSpeed = 1.0f;



	void Start () {

		ScrWidth = Screen.width;
		ScrHeight = Screen.height;
	
	}
	
	// Update is called once per frame
	void Update () {
		mousepositionX = Input.mousePosition.x;
		if (Input.mousePosition.x >= ScrWidth-5)
		{
			gameObject.transform.position += transform.right * MovingSpeed;
		
		}
		if (Input.mousePosition.x <= 0)
		{
			gameObject.transform.position += (transform.right * -1) * MovingSpeed;
			
		}
		if (Input.mousePosition.y >= ScrHeight-5)
		{
			gameObject.transform.position += transform.forward * MovingSpeed;
			
		}
		if (Input.mousePosition.y <= 0)
		{
			gameObject.transform.position += (transform.transform.forward * -1) * MovingSpeed;
			
		}
		if (Input.GetAxis("Mouse ScrollWheel")< 0)
		{
			gameObject.transform.position += transform.transform.up * MovingSpeed;
			
		}
		if (Input.GetAxis("Mouse ScrollWheel")> 0)
		{
			gameObject.transform.position += (transform.transform.up * -1) * MovingSpeed;
			
		}

	
	}
}
