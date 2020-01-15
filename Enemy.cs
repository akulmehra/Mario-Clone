using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float moveSpeed;
    public GameObject targetPlayer;
    public float minDis;
    Rigidbody2D rb;

    public GameObject enemyDeathParticle;

    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (targetPlayer != null)
        {
            if (Vector2.Distance(transform.position, targetPlayer.transform.position) < minDis)
            {
                rb.velocity = new Vector2(moveSpeed * -1, rb.velocity.y);
                Debug.Log(rb.velocity.x);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet") {
            Instantiate(enemyDeathParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
