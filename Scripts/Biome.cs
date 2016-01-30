using UnityEngine;
using System.Collections;

public class Biome : MonoBehaviour {

	//has some stuff it produces
	//can be collided with by events
	public enum product {Elk, Wood, Daisy, Rot, StinkWeed, Frog, Potatoe, Carrot, Bean, Cow, Chicken, Marure,
	Fish, Seaweed, WaterLilly, MountainHerb, Silver, Gold};

	public product[] resources = new product[3];

	//A productivity for each of the three resources
	public float[3] productivityResources = new float[3]; 
	//between 0 - 1 usually
	//is function of population in town and the effects

	abstract void Start ();
	//should initialize the enum for reasources for each biome.

	abstract void Update ();
		//will send resources to player

	abstract void isCollidedWith ();
		//inputs event type and somehow interprets 

	abstract void produceResources();
		//uses productivity to calulate yeild
		//sends goods to warehourse

}