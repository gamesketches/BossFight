using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

    public GameObject basicBulletPrefab;
    PlayerStats playerStats;

    // Use this for initialization
    void Start () {
        playerStats = GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            FireShot();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            GrassShot();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            WaterShot();
        }

    }

    void FireShot()
    {

        GameObject bullet = null;
        BulletStats bulletStats;
        //fireshot
        bullet = ((GameObject)Instantiate(basicBulletPrefab, transform.position,
            Quaternion.Euler(0.0f, 0.0f, 0.0f)));
        bulletStats = bullet.GetComponent<BulletStats>();
        bullet.GetComponent<SpriteRenderer>().sprite = bullet.GetComponent<BulletStats>().BulletSprites[0];
        bulletStats.type = BulletStats.BulletType.Fire;
        bulletStats.dir = (BulletStats.Dir)playerStats.currentDir;
    }

    void GrassShot()
    {

        GameObject bullet = null;
        BulletStats bulletStats;
        //fireshot
        bullet = ((GameObject)Instantiate(basicBulletPrefab, transform.position,
            Quaternion.Euler(0.0f, 0.0f, 0.0f)));
        bulletStats = bullet.GetComponent<BulletStats>();
        bullet.GetComponent<SpriteRenderer>().sprite = bullet.GetComponent<BulletStats>().BulletSprites[1];
        bulletStats.type = BulletStats.BulletType.Grass;

    }

    void WaterShot()
    {

        GameObject bullet = null;
        BulletStats bulletStats;
        //fireshot
        bullet = ((GameObject)Instantiate(basicBulletPrefab, transform.position,
            Quaternion.Euler(0.0f, 0.0f, 0.0f)));
        bulletStats = bullet.GetComponent<BulletStats>();
        bullet.GetComponent<SpriteRenderer>().sprite = bullet.GetComponent<BulletStats>().BulletSprites[2];
        bulletStats.type = BulletStats.BulletType.Water;

    }

}
