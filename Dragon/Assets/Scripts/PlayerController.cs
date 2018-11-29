using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class PlayerController : MonoBehaviour {

    public float speed;             //Floating point variable to store the player's movement speed.
    public float smooth = 2f;
    public float dashSpeed = 2f;
    public float dashTime = 1.2f;
    public static bool isDashing = false;

    //Player Health
    public static float Health = 100f;
    public static float maxHealth = 100f;

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    //Collectibles
    public int coinCount;        //Integer to store the number of coins collected so far.
    public Text coinCountText;    //Store a reference to the UI Text component which will display the number of coins collected.

    //Audio
    public AudioClip dashSoundEffect;
    private AudioSource source;
    private bool shouldContinue = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        coinCount = 0;            //Initialize coinCount to zero.
        setCoinCountText();
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Update ()
    {
        
    }

    void FixedUpdate()
    {
        //Player Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        Dash();
    }

    void Dash ()
    {
        if (dashTime > 1)
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.F))
            {
                Vector2 dashPosition = new Vector2(transform.position.x, transform.position.y + dashSpeed);
                transform.position = Vector2.Lerp(transform.position, dashPosition, Time.deltaTime * smooth);
                dashTime -= Time.deltaTime;
                isDashing = true;
                while (shouldContinue == true)
                {
                    source.Play();
                    shouldContinue = false;
                }
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.F))
            {
                Vector2 dashPosition = new Vector2(transform.position.x, transform.position.y - dashSpeed);
                transform.position = Vector2.Lerp(transform.position, dashPosition, Time.deltaTime * smooth);
                dashTime -= Time.deltaTime;
                isDashing = true;
                while (shouldContinue == true)
                {
                    source.Play();
                    shouldContinue = false;
                }
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.F))
            {
                Vector2 dashPosition = new Vector2(transform.position.x - dashSpeed, transform.position.y);
                transform.position = Vector2.Lerp(transform.position, dashPosition, Time.deltaTime * smooth);
                dashTime -= Time.deltaTime;
                isDashing = true;
                while (shouldContinue == true)
                {
                    source.Play();
                    shouldContinue = false;
                }
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.F))
            {
                Vector2 dashPosition = new Vector2(transform.position.x + dashSpeed, transform.position.y);
                transform.position = Vector2.Lerp(transform.position, dashPosition, Time.deltaTime * smooth);
                dashTime -= Time.deltaTime;
                isDashing = true;
                while (shouldContinue == true)
                {
                    source.Play();
                    shouldContinue = false;
                }
            }
        }
        else if (dashTime < 1 && dashTime >= 0)
        {
            dashTime -= Time.deltaTime;
        }
        else
            while (dashTime < 1.2f)
            {
                dashTime += Time.deltaTime;
                shouldContinue = true;
                isDashing = false;
            }
    }

    //Damage the player
    public void jellyFishDamagePlayer(int damage)
    {
        Health -= damage;   //subtract damage from health
        CalculateDead();
    }

    public void coralDamagePlayer(int damage)
    {
        Health -= damage;
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
        //Coin collision
        if (other.gameObject.CompareTag("Coin"))
        {
            coinCount = coinCount + 1;    //Add one to the current value of our coinCount variable.
            setCoinCountText();            //Reset Coin count text
            other.gameObject.SetActive(false);
        }
        // Health Pickup Collision
        if (other.gameObject.CompareTag("HealthPickUp"))
        {
            if (Health != 100)
            {
                other.gameObject.SetActive(false);
                Health = Health + 20;
            }
        }
        //Enemy Collision
        else if (other.gameObject.CompareTag("Enemy"))
        {
            jellyFishDamagePlayer(20);
            Debug.Log(Health);
        }
        //Spike Coral Collision
        else if (other.gameObject.CompareTag("Coral"))
        {
            coralDamagePlayer(5);
            Debug.Log(Health);
        }
        //Virtue Collision
        else if (other.gameObject.CompareTag("Virtue"))
        {
            other.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("breakableCoral"))
        {
            if (isDashing == true)
            {
                other.gameObject.SetActive(false);
            }
        }
    }

    //Collectible text displayed on screen
    public void setCoinCountText()
    {
        coinCountText.text = "Coins: " + coinCount.ToString();
    }
}