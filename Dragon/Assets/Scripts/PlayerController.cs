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
    private bool facingRight;

    public Animator animator;

    //Player Health
    public static float Health = 100f;
    public static float maxHealth = 100f;

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    //Collectibles
    public int coinCount;        //Integer to store the number of coins collected so far.
    public Text coinCountText;    //Store a reference to the UI Text component which will display the number of coins collected.

    //Displaying Lives on Screen
    public Text livesCountText;

    //Audio
    public AudioClip dashSoundEffect;
    private AudioSource source;
    private bool shouldContinue = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        coinCount = 0;            //Initialize coinCount to zero.
        setCoinCountText();
        setLivesCountText();
        facingRight = true;
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        //Player Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        // check if player is moving for animation to play
        if (Mathf.Abs(moveHorizontal) > 0.1)
        {
            animator.SetBool("movingHorizontal", true);

        }
        else if (Mathf.Abs(moveVertical) > 0.1)
        {
            animator.SetBool("movingVertical", true);
        }
        else
        {
            animator.SetBool("movingHorizontal", false);
            animator.SetBool("movingVertical", false);
        }

        Dash();
        checkCoins();
        Flip(moveHorizontal);
        checkCombatAnim();
    }

    void checkCombatAnim()
    {
        if (Input.GetKey(KeyCode.Space))
            animator.SetBool("inCombat", true);
        else
            animator.SetBool("inCombat", false);
    }

    void Flip(float moveHorizontal)
    {
        if ((moveHorizontal > 0 && !facingRight) || (moveHorizontal < 0 && facingRight))
        {
            facingRight = !facingRight;
            // when ScaleX value on player gameobject becomes -1, the player sprites flips horizontally
            Vector3 playerScale = transform.localScale;
            playerScale.x *= -1;
            transform.localScale = playerScale;
        }
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
        if (Health <= 0 && MainMenu.lives == 1)
        {
            Health = 100f; //reset health
            MainMenu.lives = 3; // reset lives
            SceneManager.LoadScene("00_TitleScreen"); //send player back to Main Menu
        }
        else if (Health <= 0 && MainMenu.lives > 1)
        {
            MainMenu.lives = MainMenu.lives - 1;
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
            if (Health <= 80)
            {
                other.gameObject.SetActive(false);
                Health = Health + 20;
            }
            else if (Health != 100 && Health > 80)
            {
                other.gameObject.SetActive(false);
                Health = 100f;
            }
        }
        //Enemy Collision
        else if (other.gameObject.CompareTag("Enemy"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                other.gameObject.SetActive(false);
            }
            else
            {
                jellyFishDamagePlayer(20);
            }
        }
        //Spike Coral Collision
        else if (other.gameObject.CompareTag("Coral"))
        {
            coralDamagePlayer(5);
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

    public void checkCoins()
    {
        if (coinCount >= 9)
        {
            MainMenu.lives = MainMenu.lives + 1;
            coinCount = 0;
            setCoinCountText();
            setLivesCountText();
            extraLifeScript.playExtraLifeSoundEffect();
        }
    }

    public void setLivesCountText()
    {
        livesCountText.text = "Lives: " + MainMenu.lives.ToString();
    }

    //Collectible text displayed on screen
    public void setCoinCountText()
    {
        coinCountText.text = "Coins: " + coinCount.ToString();
    }
}