using UnityEngine;
using System.Collections;

public class BatBehavior : MonoBehaviour {


    private BatStats batStats;
    public GameObject player;

    SpriteRenderer rend;

    float birthtime, startTime, interval;

	// Use this for initialization
	void Start () {
        rend = GetComponent<SpriteRenderer>();
        batStats = GetComponent<BatStats>();
        batStats.flDuration = Random.RandomRange(1.0f, 5.0f);
        batStats.flSpeed = 0.02f;
        batStats.flTimeout = Random.RandomRange(3.0f, 7.0f);
        startTime = Time.time;
        birthtime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
        if (batStats.isFlying)
        {
            //move towards
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, batStats.flSpeed);
            if (interval >= batStats.flDuration)
            {
                //stop flying
                batStats.isFlying = false;
                startTime = Time.time;
                Debug.Log("stopping flight");
            }
        } else
        {
            // wait through timeout and turn to is flying.
            if(interval >= batStats.flTimeout)
            {
                // start flying
                batStats.isFlying = true;
                startTime = Time.time;
                Debug.Log("starting flight");
            }
        }
        interval = Time.time - startTime;
    }
}
