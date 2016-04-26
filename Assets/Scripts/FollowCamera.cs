using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	public Transform m_Target;
	public float distance = 2.8f;
	public float targetHeight = 2.0f;
	private float x = 0.0f;
	private float y = 0.0f; 

	void Start()
	{
		Vector3 angles = transform.eulerAngles;
		x = angles.x;
		y = angles.y;
	}

	void LateUpdate()
	{
		if(!m_Target)
			return;

		y = m_Target.eulerAngles.y;


		// ROTATE CAMERA:
		Quaternion rotation = Quaternion.Euler(x, y, 0);
		transform.rotation = rotation;

		// POSITION CAMERA:
		Vector3 position = m_Target.position - (rotation * Vector3.forward * distance + new Vector3(0, -targetHeight, 0));
		transform.position = position;
	}
}