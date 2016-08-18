using UnityEngine;
using System.Collections;

public class BatStats : MonoBehaviour {


    public float flDuration;
    public float flSpeed;
    public float flTimeout;
    public float damage;
    public bool isFlying;

    // Use this for initialization
    void Start () {
        damage = 1.0f;
        isFlying = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
