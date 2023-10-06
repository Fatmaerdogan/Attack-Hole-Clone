using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    Transform player;
    Vector3 betweenDistance;
    void Start()
    {
        player = GameObject.Find("Hole").transform;
        betweenDistance = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = player.position + betweenDistance;
        }
    }
}
