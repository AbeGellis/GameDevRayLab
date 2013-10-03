using UnityEngine;
using System.Collections;

public class NPCBot : MonoBehaviour {
	
	public float speed = 1f;
	
	void FixedUpdate() {
		rigidbody.AddForce(speed * transform.forward);
	}
	
	void Update () {
		Ray blockDetect = new Ray(transform.position, transform.forward);
		RaycastHit blockHit = new RaycastHit();
		
		//Calculates how fast it's going in the direction it's moving
		float checkDistance = Vector3.Dot(transform.forward, rigidbody.velocity);
		
		if (rigidbody.velocity.magnitude > 0 && Physics.Raycast(blockDetect, out blockHit, Mathf.Max(1, checkDistance))) {
			if (Random.Range(0, 2) == 0) 
				transform.Rotate(Vector3.up, 90f);
			else 
				transform.Rotate(Vector3.up, -90f);
			
		}
	}
}
