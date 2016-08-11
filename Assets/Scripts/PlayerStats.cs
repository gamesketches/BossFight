using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public float speed;
    public float maxSpeed; 

    public int firePower;
    public int waterPower;
    public int grassPower;

    public int health = 100;

    // Use this for initialization
    void Start () {
        speed = 0.15f;
        maxSpeed = 1.0f;

    }

    // Update is called once per frame
    void Update () {
	
	}
}
