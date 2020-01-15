using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour {

    public float moveSpeed;
    Vector2 startPos;
    Vector2 posForward;
    Vector2 posBackward;
    Vector2 targetPos;
    public bool startFront;

    public float xMovement;
    public float yMovement;

    // Use this for initialization
	void Start () {
        startPos = transform.position;
        posForward = new Vector2(startPos.x + xMovement, startPos.y + yMovement);
        posBackward = new Vector2(startPos.x - xMovement, startPos.y - yMovement);
        if (startFront) {
            targetPos = posForward;
        } else {
            targetPos = posBackward;
        }

	}
	
	// Update is called once per frame
	void Update () {
        if ((Vector2)transform.position == posForward) {
            targetPos = posBackward;
        } else if ((Vector2)transform.position == posBackward) {
            targetPos = posForward;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
	}
}
