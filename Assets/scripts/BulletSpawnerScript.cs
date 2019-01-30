using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnerScript : MonoBehaviour {

    public GameObject []enemy;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    int enemyIndex;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        enemyIndex = Random.Range(0,4);

        if(Time.time>nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range (-8.4f, 8.4f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemy[enemyIndex], whereToSpawn, Quaternion.identity);
        }
	}
}
