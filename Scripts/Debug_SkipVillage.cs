using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Debug_SkipVillage : MonoBehaviour {

    

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (SceneManager.GetActiveScene().name == "VillageMap")
                GameObject.FindObjectOfType<VillageCenter>().worldTime = Globals.lengthOfScenario - 1;
            else if (SceneManager.GetActiveScene().name == "RitualScene")
            {
                Element e = new Element(-15, Globals.energyTypes.fire_water);
                GameObject.FindObjectOfType<Cauldron>().DEBUG_AddIngredient(e);
            }
        }
        if (SceneManager.GetActiveScene().name == "RitualScene")
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                Element e = new Element(5, Globals.energyTypes.fire_water);
                GameObject.FindObjectOfType<Cauldron>().DEBUG_AddIngredient(e);
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                Element e = new Element(-5, Globals.energyTypes.fire_water);
                GameObject.FindObjectOfType<Cauldron>().DEBUG_AddIngredient(e);
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                Element e = new Element(5, Globals.energyTypes.critter_beast);
                GameObject.FindObjectOfType<Cauldron>().DEBUG_AddIngredient(e);
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                Element e = new Element(-5, Globals.energyTypes.critter_beast);
                GameObject.FindObjectOfType<Cauldron>().DEBUG_AddIngredient(e);
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                Element e = new Element(5, Globals.energyTypes.dark_light);
                GameObject.FindObjectOfType<Cauldron>().DEBUG_AddIngredient(e);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                Element e = new Element(-5, Globals.energyTypes.dark_light);
                GameObject.FindObjectOfType<Cauldron>().DEBUG_AddIngredient(e);
            }
        }
    }
}
