using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunProjectile : MonoBehaviour {

    public GameObject bullet;
    public float bulletForce;
    bool shootable;
    public AudioSource shootSoundAus;

    // Use this for initialization
	void Start () {
        shootable = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (shootable) {
            if (Input.GetKeyDown(KeyCode.E)) {
                GameObject instant = Instantiate(bullet, new Vector2(transform.position.x + 1, transform.position.y), transform.rotation);
                shootSoundAus.Play();
                instant.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletForce, 0));
                Destroy(instant, 5);
            }
        }   
	}

    public void shootProjectile () {
        shootable = true;
    }
}
