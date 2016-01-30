using UnityEngine;
using System.Collections;


public class Villager : MonoBehaviour {

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
        if (hp <= 0)
            hp = .1f;
        float moveX = (Random.Range(-1f, 1f) * speed);
        float moveY = (Random.Range(-1f, 1f) * speed);
        moveDir = new Vector2(moveX, moveY);
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
            UpdateHp();
            UpdateHappiness();
            UpdateHealthiness();
        }
        Wander(dt);
    }

    private void UpdateHealthiness()
    {
        healthiness += (healthiness - Globals.valueOfGoodHealth) * Globals.healthyLossDueToIllness;
        healthiness = limit(healthiness);
        
    }

    private void UpdateHappiness()
    {
        float hpBonus = (hp - hp * Globals.contentThreshold) * Globals.contentExcessMultiplier;
        float healthyBonus = (healthiness - healthiness * Globals.contentThreshold) * Globals.contentExcessMultiplier;
        happiness += hpBonus + healthyBonus;
        happiness = limit(happiness);
    }

    private void UpdateHp()
    {
        hp += (healthiness - Globals.healthinessContent) * Globals.bonusHpPerHealthinessExcessMultiplier;
        hp = limit(hp);
    }

    public void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.CompareTag("Event"))
        {
            Debug.Log("Is dealing with an event");
        }

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
}
