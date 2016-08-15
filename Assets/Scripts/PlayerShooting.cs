using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

    public GameObject basicBulletPrefab;
    PlayerStats playerStats;
    public float fireLifetime, waterLifetime, grassLifetime;


    // Use this for initialization
    void Start () {
        playerStats = GetComponent<PlayerStats>();
        fireLifetime = 1.0f;
        waterLifetime = 1.5f;
        grassLifetime = 3.0f;
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
        bulletStats.lifetime = fireLifetime;
    }

    void GrassShot() //drop a persistent grass to spawn more i hope
    {

        GameObject bullet = null;
        BulletStats bulletStats;

        bullet = ((GameObject)Instantiate(basicBulletPrefab, transform.position,
            Quaternion.Euler(0.0f, 0.0f, 0.0f)));
        bulletStats = bullet.GetComponent<BulletStats>();
        bullet.GetComponent<SpriteRenderer>().sprite = bullet.GetComponent<BulletStats>().BulletSprites[1];
        bulletStats.type = BulletStats.BulletType.Grass;
        bulletStats.dir = (BulletStats.Dir)playerStats.currentDir;
        bulletStats.lifetime = grassLifetime;
        bulletStats.shotIndex = 0;
    }

    void WaterShot() // fire 3 bullets in spread
    {

        GameObject[] bullets;
        BulletStats[] bulletsStats;

        bullets = new GameObject[3];
        bulletsStats = new BulletStats[3];
        for (int i = 0; i < 3; i++) //jiujitsu
        {
            bullets[i] = ((GameObject)Instantiate(basicBulletPrefab, transform.position,
                Quaternion.Euler(0.0f, 0.0f, 0.0f)));
            bulletsStats[i] = bullets[i].GetComponent<BulletStats>();
            bullets[i].GetComponent<SpriteRenderer>().sprite = bullets[i].GetComponent<BulletStats>().BulletSprites[2];
            bulletsStats[i].type = BulletStats.BulletType.Water;
            bulletsStats[i].dir = (BulletStats.Dir)playerStats.currentDir;
            bulletsStats[i].lifetime = waterLifetime;
            bulletsStats[i].shotIndex = i;
        }

    }

}
