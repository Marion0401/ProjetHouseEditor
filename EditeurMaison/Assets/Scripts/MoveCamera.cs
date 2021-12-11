using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCamera : MonoBehaviour
{

	public float sensitivity;
	private float zoom = 5;
	private Vector3 rotateValue;
	private float zoomCamera;
	


	private void Start()
    {
		zoomCamera = GetComponent<Camera>().fieldOfView;
    }

    public void Update()
	{


		

		if (Input.GetMouseButton(1))
		{
			float xDirection = Input.GetAxis("Mouse X");
			float yDirection = Input.GetAxis("Mouse Y");
			
			float horizontalOffset = sensitivity * xDirection * Time.deltaTime;
			float verticalOffset = sensitivity * yDirection  * Time.deltaTime;

			
			if (transform.position.x > 26f)
			{
				
				transform.position = new Vector3(26, transform.position.y, transform.position.z);
			}
			else if (transform.position.x < -3f)
			{
				transform.position = new Vector3(-3, transform.position.y, transform.position.z);
			}
			else if (transform.position.y > 15f)
			{
				transform.position = new Vector3(transform.position.x, 15, transform.position.z);
			}
			else if (transform.position.y < 4f)
			{
				transform.position = new Vector3(transform.position.x, 4, transform.position.z);
			}
			else if (transform.position.z < -3f)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, -3);
			}
			else if (transform.position.y > 22f)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, 22);
			}

			
			transform.Translate(horizontalOffset, verticalOffset, 0);

			
		}

		if (Input.GetMouseButton(2))
        {
			
			float xDirection = Input.GetAxis("Mouse X");
			float yDirection = Input.GetAxis("Mouse Y");
			rotateValue = new Vector3(yDirection, xDirection * -1, 0);
			transform.eulerAngles = transform.eulerAngles - rotateValue;
			transform.eulerAngles += rotateValue * sensitivity/2;
		}

		if (Input.GetAxis("Mouse ScrollWheel") > 0f)
		{
			
			zoomCamera -= zoom;
			zoomCamera = Mathf.Clamp(zoomCamera, 40, 100);
			GetComponent<Camera>().fieldOfView = zoomCamera;

		}

		if (Input.GetAxis("Mouse ScrollWheel") < 0f)
		{
			zoomCamera += zoom;
			zoomCamera = Mathf.Clamp(zoomCamera, 40, 100);
			GetComponent<Camera>().fieldOfView =zoomCamera;

		}



	}
}
