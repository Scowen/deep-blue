using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
    private Rigidbody rb;

	public float maxSubmergedSpeed = 30;
    public float maxSurfacedSpeed = 15;

	public float acceleration = 3f;

	// This variable is important to simulate a realistic speed.
	private const float realismMultiplier = 0.20081f;

	public float bouyancy = 9.81f;

    public GameObject water;
	public GameObject propeller;

	private float speed = 0;
	private float rotation;
	private float pitch;
	private float desiredSpeed;
	private float desiredRotation;
	private float desiredPitch;

	private BladeSpinner bladeSpinner;

    void Start () {
        rb = GetComponent<Rigidbody>();
		bladeSpinner = propeller.GetComponent<BladeSpinner> ();
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.W))
			desiredSpeed += 5;

		if (Input.GetKeyDown (KeyCode.S))
			desiredSpeed -= 5;

		desiredSpeed = Mathf.Clamp (desiredSpeed, 0, maxSubmergedSpeed);

		float realisticDesiredSpeed = desiredSpeed * realismMultiplier;
				
		speed += acceleration * Time.deltaTime;

		if (speed > realisticDesiredSpeed)
			speed = realisticDesiredSpeed;

		bladeSpinner.setPropellerSpeed (rb.velocity.z * 100);

		Debug.Log ("RDS: " + realisticDesiredSpeed.ToString() + " | Speed: " + speed.ToString () + " | Des.Spd: " + desiredSpeed.ToString () + " | RBV: " + rb.velocity.ToString());
    }

	void FixedUpdate() {
		// Add the bouyancy effect.
		rb.AddRelativeForce ((transform.up * bouyancy), ForceMode.Acceleration);

		// Manipulate the direction the object goes.
		rb.AddForce ((transform.forward * speed), ForceMode.Acceleration);
	}

	public float getDesiredSpeed() {
		return this.desiredSpeed;
	}

	public float getCurrentSpeed() {
		return this.rb.velocity.z;
	}
}
