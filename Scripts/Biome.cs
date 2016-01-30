using UnityEngine;
using System.Collections;

public class Biome : MonoBehaviour {

	//has some stuff it produces
	//can be collided with by events
	public enum product {Elk, Wood, Daisy, Rot, StinkWeed, Frog, Potatoe, Carrot, Bean, Cow, Chicken, Marure,
	Fish, Seaweed, WaterLilly, MountainHerb, Silver, Gold};

	public product[] resources = new product[3];

	//A productivity for each of the three resources
	public float[] productivityResources = new float[3]; 
	//between 0 - 1 usually
	//is function of population in town and the effects

	virtual public void Start(){
	}
	//should initialize the enum for reasources for each biome.

	virtual public void Update(){
	}
		//will send resources to player

	virtual public void isCollidedWith(){
	}
		//inputs event type and somehow interprets 

	virtual public  void produceResources(){
	}
		//uses productivity to calulate yeild
		//sends goods to warehourse

}