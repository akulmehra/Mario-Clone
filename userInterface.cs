using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class userInterface : MonoBehaviour {

    public Text coinsScore;
    public Image coinsSymbol;
    public GameObject player;
    Player playerScript;

    bool activeRestart;
    public Button restartBtn;

    // Use this for initialization
    void Start () {
        playerScript = player.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        coinsScore.text = playerScript.getCoins().ToString();

        restartBtn.gameObject.SetActive(activeRestart);
	}

    public void setActiveRestart (bool set) {
        activeRestart = set;
    }

    public void restartGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
