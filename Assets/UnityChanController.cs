using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

    // Use this for initialization
    private float groundLevel = -3.0f;
    Animator animator;
    Rigidbody2D rigidbody2d;
    private float dump = 0.8f;
    float jumpVelocity = 20;
    private float deadLine = -9;
    void Start () {
        this.animator = GetComponent<Animator>();
        this.rigidbody2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        this.animator.SetFloat("Horizontal",1);
        bool isGround = (this.transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            this.rigidbody2d.velocity = new Vector2(0, this.jumpVelocity);
        }
        if (Input.GetMouseButton(0) == false)
        {
            if(rigidbody2d.velocity.y > 0)
            {
                this.rigidbody2d.velocity *= this.dump;
            }
            
        }
        if(transform.position.x < this.deadLine)
        {
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            Destroy(gameObject);
        }
    }
}
