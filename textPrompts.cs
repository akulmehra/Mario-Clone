using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textPrompts : MonoBehaviour {

    public float time;
    public string text;

    // Use this for initialization
	void Start () {
        gameObject.GetComponent<Text>().text = text;	
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0) {
            gameObject.SetActive(false);
        }
	}
}
