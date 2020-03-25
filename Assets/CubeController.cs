using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
    private float speed = -12f;
    private float deadLine = -10f;
    public AudioClip Block1;
    private AudioSource audiosource;
    
    // Use this for initialization
    void Start () {
        audiosource=gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(this.speed * Time.deltaTime, 0, 0);
        if (transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Cube"||collision.gameObject.tag == "ground")
        {
            audiosource.PlayOneShot(Block1);
        }
    }
    
}
