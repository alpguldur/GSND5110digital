using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed;             //Floating point variable to store the player's movement speed.

    //Player Health
    public static float Health = 100f;
    public static float maxHealth = 100f;

    //Audio
    public AudioClip PickUpSoundClip;
    public AudioSource PickUpSoundSource;

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    //Collectibles
    private int pickUpCount;        //Integer to store the number of pickups collected so far.
    public Text PickUpCountText;    //Store a reference to the UI Text component which will display the number of pickups collected.

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        pickUpCount = 0;            //Initialize pickUpCount to zero.
        setPickUpCountText();
        PickUpSoundSource.clip = PickUpSoundClip;   //Audio
    }

    void FixedUpdate()
    {
        //Player Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed); 
    }

    //Damage the player
    public void damagePlayer(int damage)
    {
        Health -= damage;   //subtract damage from health
        CalculateDead();
    }

    //Check if Health is equal or less than zero.
    public void CalculateDead()
    {
        if (Health <= 0)
        {
            Debug.Log("The player has died!");
            Health = 100f;  //reset health
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //reload current level
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //PickUp collision
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            pickUpCount = pickUpCount + 1;    //Add one to the current value of our PickUpCount variable.
            setPickUpCountText();            //Reset pickUp count text
            PickUpSoundSource.Play();       //Play sound effect after collision
        }
        //Enemy Collision
        else if (other.gameObject.CompareTag("Enemy"))
        {
            damagePlayer(20);
            Debug.Log(Health);
        }
    }

    //Collectible text displayed on screen
    void setPickUpCountText()
    {
        PickUpCountText.text = "Count: " + pickUpCount.ToString();
    }
}
