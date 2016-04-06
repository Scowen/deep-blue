using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private float Speed = 0;

    private Rigidbody rb;
    [Range(1,50)]
	public float submergedSpeed = 30;
    [Range(1, 50)]
    public float surfacedSpeed = 15;
    [Range(1, 100)]
    public float realismSpeedMultiplier = 3;
    public float turningSpeed = 60;
    public float pitchYawSpeed = 60;

    public GameObject water;

    void Start ()
	{
        rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
	{
        // Change this to recognize if the Sub is surfaced or submerged.
        Speed = submergedSpeed;
        // The Speed also needs to be changed ever so slightly to match the realistic in game speed.
        Speed *= realismSpeedMultiplier;

        // Get the horizontal and vertical input.

        /* Todo on controls:  
         * Make it so the player chooses the desired direction and the ship then goes to follow it.
         */

        if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(transform.up * Speed);
        }
        if (Input.GetKey(KeyCode.S)) {
            rb.AddForce(-(transform.up * Speed));
        }
        if (Input.GetKey(KeyCode.Q)) {
            transform.Rotate(Vector3.forward * turningSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E)) {
            transform.Rotate(Vector3.forward * -(turningSpeed) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            transform.Rotate(Vector3.right * turningSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.Rotate(Vector3.right * -(turningSpeed) * Time.deltaTime);
        }
        
        // Now for the Gravity. The sub should not go floating above the water.
        if (transform.position.y > water.transform.position.y)
            rb.useGravity = true;
        else
            rb.useGravity = false;
    }
}
