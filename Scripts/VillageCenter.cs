using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class VillageCenter : MonoBehaviour {


	public Dictionary<Biome.product,int> resourceStorage;
	public void startStorage(){
		//should initialize the start state of the Resource Storage System
		resourceStorage.Add(Biome.product.Fish, 10);
		resourceStorage.Add(Biome.product.Carrot, 10);
		resourceStorage.Add (Biome.product.Wood, 50);
	}

	// Use this for initialization
	void Start () {
		//need to initialize the starting resources
		startStorage();
	}
	
	// Update is called once per frame
	//void Update () {
	//
	//}



	public void addResourceToStorage(Biome.product resource, int amount){
		//check first if it is in the dictionary
			//if not, then add with amount = 0 then proceed to avoid error
		if (!resourceStorage.ContainsKey(resource)) {
			//then we need to initialize it first
			resourceStorage.Add(resource, 0);
		}
		resourceStorage[resource] = amount + resourceStorage[resource];
			//will add resource to resourceStorage, adding amount to add with current amount in storage
	}

	public void subtractResourceFromStorage(Biome.product resource, int amount){
		//check first if resource has amount in storage
		if (resourceStorage.ContainsKey(resource) && resourceStorage[resource] > amount) {
			//then we have enough to take the amount we want of said resource
			//resourceStorage[resource]
		}
		//then remove said amount
	}

	public void giveResourcesToWitch(){
		//for each loop which goes through each resources in storage and allocates a certain percent to the witch
		//need some function to determine amount given to witch
		//need to actually give amounts to witch
		//need to subtract amount given from resourceStorage
	}
}
