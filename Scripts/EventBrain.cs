using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//magic values everyhwere, times running low

public class EventBrain : MonoBehaviour {
    enum stormType{Fire,Water};
    enum critterType{Insect,Frogs,Cow,Wolf};
    enum auraType{Light,Dark};
	//going to have set/get for radius and vector
    List<Transform> objectsToIgnore;
	public Vector2 directionVector; //vector which keeps track of movement direction and speed
	public float scale; //radius defining the sive of the collision box
	public float totalPower = 0; //power rating of Event
	public float speed;
    
	//power will effect radius and movementVector
	//decays over time

	// Use this for initialization
    
    public void Initialize(Dictionary<Globals.energySubTypes, float> initialEnergies)
    {
        foreach (Globals.energySubTypes subType in System.Enum.GetValues(typeof(Globals.energySubTypes))) //since used to fill all values, need to fill missing ones to zero or will crash
        {
            if (!initialEnergies.ContainsKey(subType))
                initialEnergies.Add(subType, 0);
        }
        foreach (KeyValuePair<Globals.energySubTypes, float> kv in initialEnergies) //since used to fill all values, need to fill missing ones to zero or will crash
        {
            totalPower += kv.Value;
        }

        if (initialEnergies[Globals.energySubTypes.ether] > 0)
        {
            float powerMultiplier = 1 + initialEnergies[Globals.energySubTypes.ether]/15f;
            totalPower*= powerMultiplier;
        }
        else
            speed = (initialEnergies[Globals.energySubTypes.air] <= 0) ? 1f : initialEnergies[Globals.energySubTypes.air];

        // Globals.energySubTypes.beast; Globals.energySubTypes.critter; Globals.energySubTypes.dark; Globals.energySubTypes.ether; Globals.energySubTypes.fire; Globals.energySubTypes.light; Globals.energySubTypes.water;
        
        
        if (initialEnergies[Globals.energySubTypes.fire] >= 4f)
            CreateStorm(stormType.Fire);
        else if (initialEnergies[Globals.energySubTypes.water] >= 4f)
            CreateStorm(stormType.Water);

        if (initialEnergies[Globals.energySubTypes.light] >= 4f)
            CreateAuraEvent(auraType.Light);
        else if (initialEnergies[Globals.energySubTypes.dark] >= 4f)
            CreateAuraEvent(auraType.Dark);

        if (initialEnergies[Globals.energySubTypes.critter] >= 15f)
            CreateCritterEvent(critterType.Insect);
        else if (initialEnergies[Globals.energySubTypes.critter] >= 4f)
            CreateCritterEvent(critterType.Frogs);
        else if (initialEnergies[Globals.energySubTypes.beast] >= 4f)
            CreateCritterEvent(critterType.Cow);
        else if (initialEnergies[Globals.energySubTypes.beast] >= 15f)
            CreateCritterEvent(critterType.Wolf);

        scale = totalPower/10;
        scale = (scale < 1) ? 1 : scale;
        directionVector = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
    }

    public void Initialize(float pow, float spd, float scle, Vector2 dirVec)
    {
		totalPower = pow;
		speed = spd;
		scale = scle;
		directionVector = dirVec;
	}
	
	// Update is called once per frame
	void Update () {
		//refresh power, some decay or gain
		if (totalPower < Globals.minimumPower) {
			Destroy(gameObject);
		}
		refreshPower();
		//need to refreshRadius
		//and with new radius scale sprite and scale radius of circle collider
		//refreshSize();
		refreshScale ();

		//then need to refresh movementVector
		refreshDirectionVector();
		//Debug.Log ("movementVector = " + directionVector);

		//then need to apply movementVector with Delta Time
		moveEvent();
		}

	public void refreshScale (){
        
		scale *= (1 - (Globals.eventDecay * Time.deltaTime));
		//GetComponent<Transform>().localScale = new Vector3(scale,scale,scale);
		transform.localScale = new Vector3(scale,scale,scale);
	}

    private void CreateCritterEvent(critterType _critterType)
    {

    }
    private void CreateAuraEvent(auraType _auraType)
    {

    }


    private void CreateStorm(stormType _stormType)
    {
        float stormsToMake = totalPower/10f;
        Debug.Log("power at storms to make: " + totalPower);
        stormsToMake = (stormsToMake<1)?1:stormsToMake;
        for(int i = 0; i < stormsToMake; ++i)
        {
            GameObject go = Instantiate(Resources.Load("SpellEvents/Storm"),this.transform.position,Quaternion.identity) as GameObject;
            go.transform.SetParent(this.transform);
            go.GetComponent<SpriteRenderer>().sortingOrder = i;
        }

        if(_stormType == stormType.Fire)
            CreateFireStorm();
        else
            CreateWaterStorm();
    }

    private void CreateFireStorm()
    {
        Storm[] storms = GetComponentsInChildren<Storm>();
        foreach (Storm s in storms)
        {
            s.GetComponent<SpriteRenderer>().color = new Color(1, Random.Range(0, .33f), 0);
        }
        /*float stormsToMake = power/20f;   //when fix fire bug
        stormsToMake = (stormsToMake<1)?1:stormsToMake;
        for(int i = 0; i < stormsToMake; ++i)
        {
            GameObject go = Instantiate(Resources.Load("SpellEvents/FireParticle"), this.transform.position, Quaternion.identity) as GameObject;
            go.transform.SetParent(this.transform);
        }*/
    }


    private void CreateWaterStorm()
    {
        Storm[] storms = GetComponentsInChildren<Storm>();
        foreach (Storm s in storms)
        {
            s.GetComponent<SpriteRenderer>().color = new Color(Random.Range(.55f, .1f), 1, 1);
        }
        /*float stormsToMake = power/20f;   //when fix fire bug
        stormsToMake = (stormsToMake<1)?1:stormsToMake;
        for(int i = 0; i < stormsToMake; ++i)
        {
            GameObject go = Instantiate(Resources.Load("SpellEvents/SnowParticle"), this.transform.position, Quaternion.identity) as GameObject;
            go.transform.SetParent(this.transform);
        }*/
    }

	public void moveEvent(){
		GetComponent<Rigidbody2D>().MovePosition(Globals.AddVec(transform.position, directionVector * Time.deltaTime));
	}

	public void refreshPower(){
		//some decay per update, probably %loss until dissolve at some base power.
		totalPower *= (1 - (Globals.eventDecay * Time.deltaTime));
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