using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D rb;
    public float moveSpeed;
    public float jumpForce;
    public float steamForce;
    public float smallSteamForce;
    bool isGrounded;
    public GameObject gameManager;
    public GameObject deathParticle;

    public AudioSource coinAus;
    public AudioSource gameOverAus;

    private bool hasKey;


    // Collectables
    private int coins;

    // Use this for initialization
	void Start () {
        hasKey = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        coins = 0;
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = new Vector2(horizontal, rb.velocity.y);

        if (rb.velocity.y == 0) {
            isGrounded = true;
        } else {
            isGrounded = false;
        }

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0, jumpForce * 100));
            }
        }

        if (rb.velocity.y < -30) {
            killPlayer();
        }
	}

    //Checking collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            if (rb.velocity.y < 0)
            {
                rb.AddForce(new Vector2(0, 150 * jumpForce));
                Destroy(collision.gameObject);
            }
            else if (isGrounded) {
                killPlayer();
            }
        }

        if (collision.gameObject.tag == "Unwalkable") {
            killPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Steam") {
            rb.AddForce(new Vector2(0, steamForce * 200));
        } else if (collision.gameObject.tag == "Small Steam") {
            rb.AddForce(new Vector2(0, smallSteamForce * 200));
        }

    }

    public int getCoins() {
        return coins;
    }

    public void addCoins() {
        coinAus.Play();
        coins++;
    }

    public void killPlayer() {
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        gameOverAus.Play();
        userInterface ui = gameManager.GetComponent<userInterface>();
        ui.setActiveRestart(true);
        Destroy(gameObject);
    }

    public void setKey(bool value) {
        hasKey = value;
    }

    public bool playerHasKey() {
        return hasKey;
    }
}
