using UnityEngine;
using System.Collections;

public class EventBrain : MonoBehaviour {

	//going to have set/get for radius and vector

	public Vector2 directionVector; //vector which keeps track of movement direction and speed
	public float scale; //radius defining the sive of the collision box
	public float power; //power rating of Event
	public float speed;
	//power will effect radius and movementVector
	//decays over time

	// Use this for initialization
	void Start () {
		power = 10f;
		scale = 4f;
		directionVector = new Vector2(Random.Range(-10, 10),Random.Range(-10, 10));
		speed = 5f;

	}

	void Start(float pow, float spd, float scle, Vector2 dirVec){
		power = pow;
		speed = spd;
		scale = scle;
		directionVector = dirVec;
	}
	
	// Update is called once per frame
	void Update () {
		//refresh power, some decay or gain
		if (power < Globals.minimumPower) {
			Destroy(gameObject);
		}
		refreshPower();
		//need to refreshRadius
		//and with new radius scale sprite and scale radius of circle collider
		//refreshSize();
		refreshScale ();

		//then need to refresh movementVector
		refreshDirectionVector();
		Debug.Log ("movementVector = " + directionVector);

		//then need to apply movementVector with Delta Time
		moveEvent();
		}

	public void refreshScale (){
		scale *= (1 - (Globals.eventDecay * Time.deltaTime));
		//GetComponent<Transform>().localScale = new Vector3(scale,scale,scale);
		transform.localScale = new Vector3(scale,scale,scale);
	}
		
	public void moveEvent(){
		GetComponent<Rigidbody2D>().MovePosition(Globals.AddVec(transform.position, directionVector * Time.deltaTime));
	}

	public void refreshPower(){
		//some decay per update, probably %loss until dissolve at some base power.
		power *= (1 - (Globals.eventDecay * Time.deltaTime));
	}

	public float randomPosFloat(float multiplier){
		return (Random.Range(1, 10) * multiplier);
	}
		
	public void refreshDirectionVector(){
		/// NEEDS TO BE MORE RANDOM ///
		//going to alter direction vector slightly based on random variables
		directionVector.x += Random.Range(1 - Globals.eventSwerveVariance, 1 + Globals.eventSwerveVariance);
		directionVector.y += Random.Range(1 - Globals.eventSwerveVariance, 1 + Globals.eventSwerveVariance);
		directionVector.Normalize ();
	}

	public void refreshSpeed(){
		speed *= (1 - (Globals.eventDecay * Time.deltaTime));
	}
}