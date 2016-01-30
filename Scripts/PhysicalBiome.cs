using UnityEngine;
using System.Collections;

public class PhysicalBiome : MonoBehaviour {

    public Globals.biome bioType;
    float hp;

    public void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Biome" + bioType);
        hp = GameObject.FindObjectOfType<VillageCenter>().GetBiomeHp((int)bioType);
    }

    public void OnTriggerEnter2D(Collider2D coli)
    {
        float dmgTaken = .1f;
        GameObject.FindObjectOfType<VillageCenter>().BiomeTakesDamage((int)bioType,dmgTaken);
    }


}
