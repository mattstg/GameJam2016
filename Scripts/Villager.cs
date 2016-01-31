using UnityEngine;
using System.Collections;


public class Villager : MonoBehaviour {

    bool dropsUnderPlagueThreshold = false;
    public float hp; //range from 0 - 1 (is multiplied by Globals.maximumVillagerHealthPoints)
    public float happiness; //range from 0 - 1
    public float healthiness; //range from 0 - 1
    public float speed = .5f;
    public float counter = 0;
    Vector2 moveDir = new Vector2(0, 0);


    public void Initialize(float _hp, float _happiness, float _healthiness)
    {
        hp = _hp + Random.Range(-Globals.PopulationMutationRate,Globals.PopulationMutationRate);
        happiness = _happiness + Random.Range(-Globals.PopulationMutationRate,Globals.PopulationMutationRate);
        healthiness = _healthiness + Random.Range(-Globals.PopulationMutationRate, Globals.PopulationMutationRate);
        hp = limit(hp);
        happiness = limit(happiness);
        healthiness = limit(healthiness); 
        float moveX = (Random.Range(-1f, 1f) * speed);
        float moveY = (Random.Range(-1f, 1f) * speed);
        moveDir = new Vector2(moveX, moveY);
        CheckSickness();
    }

    public void Update()
    {
        float dt = Time.deltaTime;
        counter += dt;
        if (counter >= Globals.villageUpdateCounterMax - .5f)
        {
            float moveX = (Random.Range(-1f, 1f) * speed);
            float moveY = (Random.Range(-1f, 1f) * speed);
            moveDir = new Vector2(moveX, moveY);
            counter = 0;
        }
        Wander(dt);
        if (hp <= 0)
        {
            Debug.Log("Villager has died");
            GameObject.Destroy(this.gameObject);
        }
    }

    public void UpdateStats()
    {
        float dif = (hp + happiness + healthiness - (Globals.contentThreshold * 3)) * Globals.contentExcessMultiplier;
        //Debug.Log("Difference in stats will be: " + dif);
        hp += dif;
        happiness += dif;
        healthiness += dif;
        hp = limit(hp);
        happiness = limit(happiness);
        healthiness = limit(healthiness);
        if (GetComponentInChildren<Plague>())
            hp /= 2;
    }

    public void InteractWithEvent(Globals.energySubTypes eventType, float power)
    {
        float[] multiplier = EventEffectsMatrix.Instance.GetEventAndVillagerMultiplier(eventType);
        hp += power * multiplier[0] * Globals.worldDamageReduction;
        happiness += power * multiplier[1] * Globals.worldDamageReduction;
        healthiness += power * multiplier[2] * Globals.worldDamageReduction;
        Globals.limit(ref hp,0,1);
        Globals.limit(ref happiness,0,1);
        Globals.limit(ref healthiness,0,1);
        CheckSickness();
        Debug.Log("Villager interacted with " + eventType + " event, [hp,hapiness,healthiness] = [ " + hp + "," + happiness + "," + healthiness + "]");

        //Debug.Log("Villager interacted with " + eventType + " event, [hp,hapiness,healthiness] = [ " + hp + "," + happiness + "," + healthiness + "]");
    }

    public void TakePlagueDamage()
    {
        //by touching a plague person, you have 50% of infection chance to catch it, 200% if your below the threshold
        float valueToBeat = (healthiness>= Globals.plagueThreshold)?Globals.plagueChanceOfInfection/2:Globals.plagueChanceOfInfection*2;
        if (Random.Range(0, 1f) < valueToBeat)
            GetPlague();
        else
            healthiness *= .9f;
    }

    public void Wander(float dt)
    {
        GetComponent<Rigidbody2D>().MovePosition(Globals.AddVec(transform.position, moveDir * dt * speed)); ///why at center
    }

    private float limit(float value)
    {
        if (value < 0)
            return 0;
        if (value > 1)
            return 1;
        return value;
    }

    private void CheckSickness()
    {
        if (!dropsUnderPlagueThreshold && healthiness < Globals.plagueThreshold)
        {
            dropsUnderPlagueThreshold = true;
            if (Random.Range(0, 1f) < Globals.plagueChanceOfInfection)
                GetPlague();
        }
        if((GetComponent<Plague>() && healthiness > Globals.plagueThreshold*1.5f) || healthiness > .9f)
        {
            Destroy(GetComponent<Plague>().gameObject);
             GameObject.FindObjectOfType<VillageCenter>().TheListener.RecordStringWithCountNumber(" being cured by of plague!");
        }
        
    }

    private void GetPlague()
    {
        gameObject.AddComponent<Plague>();
        GameObject plagueObject = Instantiate(Resources.Load("Plague")) as GameObject;
        plagueObject.transform.SetParent(transform);
        plagueObject.transform.localPosition = new Vector2(0, 0);
        GameObject.FindObjectOfType<VillageCenter>().TheListener.RecordStringWithCountNumber(" a plague is spreading!");
    }

   
}
