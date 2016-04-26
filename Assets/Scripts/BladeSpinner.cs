using UnityEngine;
using System.Collections;

public class BladeSpinner : MonoBehaviour {

	private float propellerSpeed;

	// Use this for initialization
	void Start () {
	}

	public void setPropellerSpeed(float speed)
	{
		propellerSpeed = speed;
	}

	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate(Vector3.forward * propellerSpeed * Time.deltaTime);
	}
}
