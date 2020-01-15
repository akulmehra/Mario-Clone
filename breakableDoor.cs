using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableDoor : MonoBehaviour {

    public float health;
    public GameObject particle;

    // Use this for initialization
	void Start () {
        health = 30;	
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0) {
            breakDoor();
        }
	}

    // Checking collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet") {
            takeDamage(10);
        }
    }

    public void takeDamage(float damage) {
        health -= damage;
    }

    void breakDoor () {
        Instantiate(particle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
