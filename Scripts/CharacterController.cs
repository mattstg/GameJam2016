using UnityEngine;
using System.Collections;


public class CharacterController : MonoBehaviour {

    public float characterSpeed = 3f;
    public Cauldron cauldron;
    Rigidbody2D rigidbody2D;
    

    public void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        float deltaTime = Time.deltaTime;
        
        if(Input.anyKey)
            HandleMovement(deltaTime);
        if (Input.GetKeyDown(KeyCode.F))
            DropIngredient();
	}

    void HandleMovement(float deltaTime)
    {
        Vector2 moveDir = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            moveDir += new Vector2(-characterSpeed * deltaTime, 0);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
             moveDir += new Vector2(0, characterSpeed * deltaTime);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
             moveDir += new Vector2(characterSpeed * deltaTime, 0);
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
             moveDir += new Vector2(0,-characterSpeed * deltaTime);
        Move(moveDir);
    }

    void Move(Vector2 moveDir)
    {
        Vector2 toMove = new Vector2(transform.position.x + moveDir.x, transform.position.y + moveDir.y);                      //to improve, add operator overload instead?
        rigidbody2D.MovePosition(toMove);
    }

    void DropIngredient()
    {

    }

    void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.CompareTag("Cauldron"))
            cauldron = coli.GetComponent<Cauldron>();
    }

    void OnTriggerExit2D(Collider2D coli)
    {
        if (coli.CompareTag("Cauldron"))
            cauldron = null;
    }
}
