using UnityEngine;
using System.Collections;

public class PhysicalIngredient : MonoBehaviour {

	//Ingredient carried by which
    Biome.product ingredient;

    public void Start()
    {
        DEBUG_CreateDefault();
    }

    public void InitializeIngredient(Biome.product _ingredient)
    {
        ingredient = _ingredient;
        SetIngredientGraphic();
    }

    private void SetIngredientGraphic()
    {
        Sprite toLoad = Resources.Load<Sprite>(ingredient.ToString());
        if (toLoad)
            GetComponent<SpriteRenderer>().sprite = toLoad;
        else
        {
            Debug.LogError("Sprite " + ingredient.ToString() + " not found");
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("DefaultIngr");
        }
    }

    public Biome.product getIngredient()
    {
        return ingredient;
    }

    public void DEBUG_CreateDefault()
    {
        InitializeIngredient(Biome.product.Bean);
    }

    public void Dropped()
    {
        RaycastHit2D[] allHit = Physics2D.RaycastAll(transform.position, -Vector2.up);
        foreach(RaycastHit2D hit in allHit)
        {
            if (hit.transform.CompareTag("Cauldron"))
            {
                hit.transform.gameObject.GetComponent<Cauldron>().AddIngredient(ingredient);
                Destroy(gameObject);
                break;
            }
        }
    }
}
