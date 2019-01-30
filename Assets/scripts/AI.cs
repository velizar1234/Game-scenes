using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    public float speed;
    private float waitTime;
    public float startWaitTime;

    private Transform target;
    public float distance;

    public Transform[] moveSpots;
    private int randomSpot;

	void Start () {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0,moveSpots.Length);
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update () {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,transform.right, distance); //line of sight
        if(hitInfo.collider.gameObject.tag == "Player")                 //detecting the player
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        }


        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position,moveSpots[randomSpot].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            randomSpot = Random.Range(0, moveSpots.Length);
        }
        else
        {
            if(collision.gameObject.tag == "Player")
            {
                Destroy(collision.gameObject);
                speed = 0f;
            }
        }
    }
}
