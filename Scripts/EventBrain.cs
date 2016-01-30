using UnityEngine;
using System.Collections;

public class EventBrain : MonoBehaviour {

	//going to have some vector
	//going to have some type
	//going to have some radius

	//going to have set/get for radius and vector

	public Vector2 movementVector; //vector which keeps track of movement direction and speed
	public float radius; //radius defining the sive of the collision box
	public float power; //power rating of Event
	//power will effect radius and movementVector
	//decays over time


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public void refreshHitbox(){
		GetComponentInParent<CircleCollider2D> ().radius = radius;
	}

	public void resetRadius(float newRadius){
		radius = newRadius;
		refreshHitbox ();
	}
}
