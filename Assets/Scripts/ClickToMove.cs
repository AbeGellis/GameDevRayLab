using UnityEngine;
using System.Collections.Generic;

//Can click to make visitable nodes

public class ClickToMove : MonoBehaviour {
	
	public float speed;
	public GameObject node;
	public Terrain ground;
	public Queue<GameObject> destinations;
	
	
	void Start() {
		destinations = new Queue<GameObject>();
	}
	
	void FixedUpdate() {
		if (destinations.Count > 0) {
			Vector3 target = destinations.Peek().transform.position;
			float dist = Vector3.Distance(transform.position, target);
			Vector3 move = Vector3.Normalize(target - transform.position);
			
			//If it still needs to move further than the distance it travels each frame
			if (dist > Mathf.Max(0.1f, speed * Time.fixedDeltaTime)) {
				rigidbody.velocity = move * speed;
				transform.rotation = Quaternion.LookRotation(move);
			}
			else {
				//Lock to the destination
				transform.position = target;
				rigidbody.velocity = Vector3.zero;
				Destroy(destinations.Peek().gameObject);
				destinations.Dequeue();
			}
		}
		
		transform.position = new Vector3(transform.position.x, 
			ground.SampleHeight(transform.position) + transform.localScale.y / 2, transform.position.z);
	}
	
	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit clickHit = new RaycastHit();
			
			if (Physics.Raycast(clickRay, out clickHit, Camera.main.farClipPlane)) {
				GameObject newnode = Instantiate(node, clickHit.point, Quaternion.identity) as GameObject;
				newnode.transform.Translate(0f, transform.localScale.y / 2, 0f);
				destinations.Enqueue(newnode);
			}
		}
	}
}
