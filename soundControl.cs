using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class soundControl : MonoBehaviour {

    public AudioMixer am;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        	
	}

    public void setVolume (float volume) {
        am.SetFloat("volume", volume); 
    }
}
