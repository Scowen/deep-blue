using UnityEngine;
using System.Collections;


using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
    public GameObject target;
    public float rotateSpeed = 150;

    void Start()
    {
        // transform.parent = target.transform;
        transform.LookAt(target.transform);
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxisRaw("Mouse X") * rotateSpeed * Time.deltaTime;
        float vertical = Input.GetAxisRaw("Mouse Y") * rotateSpeed * Time.deltaTime;

        transform.RotateAround(target.transform.position, Vector3.up, horizontal);
        transform.RotateAround(target.transform.position, Vector3.left, vertical);

        transform.LookAt(target.transform);
		/*
		// POSITION CAMERA:
		Vector3 position = target.position - (rotation * Vector3.forward * distance + new Vector3(0, -targetHeight, 0));
		transform.position = position;
		*/
    }
    
}