using UnityEngine;
using System.Collections;

public class Platformer : MonoBehaviour {
	
	public float jumpForce;
	public float runForce;
	
	bool moveLeft, moveRight, jump;
	
	void FixedUpdate() {
		if (moveLeft && !moveRight)
			rigidbody.AddForce(Vector3.left * runForce);
		if (moveRight && !moveLeft)
			rigidbody.AddForce(Vector3.right * runForce);
		if (jump)
			rigidbody.AddForce(Vector3.up * jumpForce);
	}
	
	// Update is called once per frame
	void Update() {
		moveLeft = Input.GetKey(KeyCode.LeftArrow);
		moveRight = Input.GetKey(KeyCode.RightArrow);
		if (Input.GetKey(KeyCode.Space) && rigidbody.velocity.y >= 0) {
			Ray checkFloor = new Ray(transform.position, Vector3.down);
			jump = Physics.Raycast(checkFloor, transform.localScale.y + .2f);
		}
		else 
			jump = false;
	}
}
