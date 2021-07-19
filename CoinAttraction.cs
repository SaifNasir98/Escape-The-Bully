using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAttraction : MonoBehaviour {

    public Transform player;
    public float speed;
	
	// Update is called once per frame
	void Update () {
        CoinMovement();
    }

    void CoinMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
