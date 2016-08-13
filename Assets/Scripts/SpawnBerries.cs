using UnityEngine;
using System.Collections;

public class SpawnBerries : MonoBehaviour {

    public GameObject spareBerriesPF;

    public GameObject[] spareBerriesArray;
    public int spareBerriesPieces;

    float xPos, yPos;

    // Use this for initialization
    void Start () {

        for (int i = 0; i < spareBerriesPieces; i++)   {
            xPos = Random.RandomRange(-8.0f, 8.0f);
            yPos = Random.RandomRange(-5.0f, 5.0f);

            spareBerriesArray[i] = (GameObject)Instantiate(spareBerriesPF, new Vector2(xPos, yPos), Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
