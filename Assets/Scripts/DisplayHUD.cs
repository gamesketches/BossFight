using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DisplayHUD : MonoBehaviour {


    private GameObject player;
    PlayerStats playerStats;

    Text statText;

    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        statText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {

        statText.text =    " HP: " + playerStats.health + "   MP: " + playerStats.magicPower + "\n ";
        statText.text += "FIR: " + playerStats.firePower + "   GRS: " + playerStats.grassPower + "   WTR: " + playerStats.waterPower;
    }

    void UpdateUI()
    {

    }
}
