using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public GameObject player;
    public Transform triggerPoint;
    public GameObject enemy;

    private bool hasKey;

    // Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        hasKey = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Player playerScript = player.GetComponent<Player>();
            gunProjectile gp = player.GetComponent<gunProjectile>();
            if (gameObject.tag == "Coin")
            {
                AudioSource aus = gameObject.GetComponent<AudioSource>();
                aus.Play();
                playerScript.addCoins();
            }
            if (gameObject.tag == "Gun")
            {
                gp.shootProjectile();
            }
            if (gameObject.tag == "Key") {
                enemy.SetActive(true);
                playerScript.setKey(true);
            }

            Destroy(gameObject);
        }
    }

    public bool key () {
        return hasKey;
    }
}
