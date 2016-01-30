using UnityEngine;
using System.Collections;

public class Biome : MonoBehaviour {
	public VillageCenter center;


	//has some stuff it produces
	//can be collided with by events
	public enum product {Elk, Wood, Daisy, Rot, StinkWeed, Frog, Potatoe, Carrot, Bean, Cow, Chicken, Marure,
	Fish, Seaweed, WaterLilly, MountainHerb, Silver, Gold};

	public product[] resources = new product[3];

	//A productivity for each of the three resources
	public float[] productivityOfResources = new float[3];
	//between 0 - 1 usually
	//is function of population in town and the effects

	virtual public void Start(){
	}
	//should initialize the enum for reasources for each biome.

	public void Cycle(){
		//giveResourceToVillage(produceResources());  //!!!!!!!!!!!!
	}
	//will produce resource based on productivity of resource and type of resource
	//will send to village center

	public void produceResources(){
		//uses productivity to calulate yeild
		//sends goods to warehourse
		for (int counter = 0; counter < 3; counter++) {
			giveResourceToVillage (resources [counter], grossProduce(productivityOfResources[counter]));
		}
	}
		
	public int grossProduce(float productivity){
		return Mathf.FloorToInt(center.population * Globals.populationProductivityBonus * productivity * Globals.biomeProductivityCoefficient);
	}


	public void giveResourceToVillage(product resource, int amount){
		center.addResourceToStorage (resource, amount);
	}

	virtual public void isCollidedWith(){ 	}
	//inputs event type and somehow interprets 
}