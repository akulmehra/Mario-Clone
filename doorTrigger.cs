using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour {

    public Animator anim;
    public GameObject player;
    // Use this for initialization
	void Start () {
       	
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player playerScript = player.GetComponent<Player>();
        if(playerScript.playerHasKey()) {
            anim.SetBool("open", true);
        }
    }
}
