using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    public GameObject targetPlayer;
    public float zOffset;
    public float yOffset;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (targetPlayer != null)
        {
            transform.position = new Vector3(targetPlayer.transform.position.x,
                                                 targetPlayer.transform.position.y + yOffset,
                                                 targetPlayer.transform.position.z + zOffset);
        }

    }
}
