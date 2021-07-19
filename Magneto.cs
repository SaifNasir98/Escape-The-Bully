using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magneto : MonoBehaviour {

    public GameObject[] Coins;
    public ParticleSystem magnetWaves;

    public AudioSource magnetSource;
    public AudioClip magnetClip;
    
    // Use this for initialization
    void Start () {
        magnetSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "player")
        {
            magnetWaves.Play();
            magnetSource.PlayOneShot(magnetClip);
            Activate();
        }
    }

    void Activate()
    {
        foreach (GameObject c in Coins)
        {
            c.GetComponent<CoinAttraction>().enabled = true;
        }
        Destroy(this.gameObject);
    }
}
