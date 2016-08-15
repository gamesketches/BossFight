using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {


    BulletStats bulletStats;
    float fireSpeed = 0.075f;
    
    private PlayerStats playerStats;
	// Use this for initialization
	void Start () {
        bulletStats = GetComponent<BulletStats>();
	}
	
	// Update is called once per frame
	void Update () {

        switch (bulletStats.type)
        {
            case BulletStats.BulletType.Fire:
                //fire behavior
                switch(bulletStats.dir)
                {
                    case BulletStats.Dir.right:
                        transform.position += new Vector3(fireSpeed, 0.0f, 0.0f);
                        break;
                    case BulletStats.Dir.left:
                        transform.position += new Vector3(-fireSpeed, 0.0f, 0.0f);
                        break;
                    case BulletStats.Dir.down:
                        transform.position += new Vector3(0.0f, -fireSpeed, 0.0f);
                        break;
                    case BulletStats.Dir.up:
                        transform.position += new Vector3(0.0f, fireSpeed, 0.0f);
                        break;
                    default:
                        Debug.Log("Fire bullet behavior error");
                        break;
                }
                break;
            default:
                Debug.Log("Undefined bullet behavior error");
                break;
        }
	
	}
}
