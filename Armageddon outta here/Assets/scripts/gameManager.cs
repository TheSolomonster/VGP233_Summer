using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject winWords;
    public GameObject winImage;
    public GameObject player;
    public AudioSource source;
    public AudioClip clip;
    private playerController playerC;
    public int timer = 213;
    public GameObject charger;
    public GameObject shooter;
    public bool GameOver = false;
    public bool GameWon = false;
    private bool[] waves = new bool[] { false, false, false, false, false, false, false, false};
    // Start is called before the first frame update
    void Start()
    {
        
        playerC = player.GetComponent<playerController>();
        source.PlayOneShot(clip);
        InvokeRepeating("decreaseTimer", .5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerC.gameWon) gameWon();
        else if (timer == 0 && playerC.health <= 0) gameOver();
        else
        {
            if (player.transform.position.z > 35 && !waves[0])
            {
                Debug.Log("wave 1");
                Instantiate(charger, new Vector3( 225.3666f, 10.31222f, 134.5762f), Quaternion.Euler( 0,90,0));
                Instantiate(charger, new Vector3(272.3436f, 10.31222f, 134.5762f), Quaternion.Euler(0, 270, 0));
                Instantiate(shooter, new Vector3(248.9746f, 11.42421f, 135.78f), Quaternion.Euler(0, 180, 0));
                Instantiate(shooter, new Vector3(166.1f, 10.31221f, 186.7169f), Quaternion.Euler(0, 180, 0));
                Instantiate(shooter, new Vector3(338f, 10.31221f, 186.7169f), Quaternion.Euler(0, 180, 0));
                Instantiate(shooter, new Vector3(134.1347f, 15.05361f, 184.8452f), Quaternion.Euler(0, 180, 0));
                Instantiate(shooter, new Vector3(363.2f, 15.05361f, 184.8452f), Quaternion.Euler(0, 180, 0));
                Instantiate(charger, new Vector3(139.5349f, 10.31222f, 121.2738f), Quaternion.Euler(0, 180, 0));
                Instantiate(charger, new Vector3(199.8f, 10.31222f, 164.5665f), Quaternion.Euler(0, 180, 0));
                Instantiate(charger, new Vector3(356.7f, 10.31222f, 124.3f), Quaternion.Euler(0, 180, 0));
                Instantiate(charger, new Vector3(298.1f, 10.31222f, 164.5665f), Quaternion.Euler(0, 180, 0));
                waves[0] = true;
            }
            if(player.transform.position.x > 110 && player.transform.position.z > 190 && !waves[1])
            {
                Debug.Log("wave 2");
                Instantiate(shooter, new Vector3(178.8f, 15.58597f, 280.1f), Quaternion.Euler(0, 180, 0));
                Instantiate(shooter, new Vector3(315.3f, 15.58597f, 279.4f), Quaternion.Euler(0, 180, 0));
                Instantiate(shooter, new Vector3(249.8f, 15.58597f, 240f), Quaternion.Euler(0, 180, 0));
                Instantiate(charger, new Vector3(269.9496f, 15.58597f, 240f), Quaternion.Euler(0, 180, 0));
                Instantiate(charger, new Vector3(227.8f, 15.58597f, 240f), Quaternion.Euler(0, 180, 0));
                Instantiate(charger, new Vector3(157.8f, 15.58597f, 295.3f), Quaternion.Euler(0, 180, 0));
                Instantiate(charger, new Vector3(338.8f, 15.58597f, 295.3f), Quaternion.Euler(0, 180, 0));
                Instantiate(shooter, new Vector3(212.1f, 15.58597f, 270.9f), Quaternion.Euler(0, 180, 0));
                Instantiate(shooter, new Vector3(286.5f, 15.58597f, 270.9f), Quaternion.Euler(0, 180, 0));
                waves[1] = true;
            }
            if (player.transform.position.x < 185 && player.transform.position.z > 288 && player.transform.position.z <= 347 && !waves[2])
            {
                Instantiate(charger, new Vector3(184.8249f, 15.58595f, 301.911f), Quaternion.Euler(0, 270, 0));
                Instantiate(shooter, new Vector3(37.02486f, 15.58597f, 310.9154f), Quaternion.Euler(0, 90, 0));
                Debug.Log("wave 3");
                waves[2] = true;
            }
            if (player.transform.position.x < 185 && player.transform.position.z > 347 && !waves[3])
            {
                Instantiate(charger, new Vector3(201.7f, 15.58595f, 397.8f), Quaternion.Euler(0, 270, 0));
                Instantiate(shooter, new Vector3(106.1067f, 15.58597f, 362.3343f), Quaternion.Euler(0, 270, 0));
                Debug.Log("wave 4");
                waves[3] = true;
            }
            if (player.transform.position.x > 320 && player.transform.position.z > 288 && player.transform.position.z <= 347 && !waves[4])
            {
                Instantiate(charger, new Vector3(367.3f, 15.58595f, 301.911f), Quaternion.Euler(0, 270, 0));
                Instantiate(shooter, new Vector3(451.5611f, 15.58597f, 310.9154f), Quaternion.Euler(0, 270, 0));
                Debug.Log("wave 5");
                waves[4] = true;
            }
            if (player.transform.position.x > 320 && player.transform.position.z > 347 && !waves[5])
            {
                Instantiate(charger, new Vector3(376.4435f, 15.58599f, 382.5098f), Quaternion.Euler(0, 90, 0));
                Instantiate(charger, new Vector3(377.0615f, 15.58599f, 370.9679f), Quaternion.Euler(0, 90, 0));
                Instantiate(charger, new Vector3(375.8549f, 15.58599f, 360.4f), Quaternion.Euler(0, 90, 0));
                Instantiate(charger, new Vector3(375.5457f, 15.58599f, 349.0226f), Quaternion.Euler(0, 90, 0));
                Instantiate(shooter, new Vector3(357.8517f, 15.58597f, 346.2452f), Quaternion.Euler(0, 90, 0));
                Instantiate(shooter, new Vector3(289.1839f, 15.58597f, 371f), Quaternion.Euler(0, 0, 0));
                Debug.Log("wave 6");
                waves[5] = true;
            }
            if (player.transform.position.x < 295f && player.transform.position.x > 195f && player.transform.position.z > 357 && !waves[6])
            {
                Instantiate(shooter, new Vector3(218.9574f, 15.58597f, 461.595f), Quaternion.Euler(0, 180, 0));
                Instantiate(shooter, new Vector3(270.3328f, 15.58597f, 461.595f), Quaternion.Euler(0, 180, 0));
                Instantiate(shooter, new Vector3(228.7f, 15.58597f, 446.1968f), Quaternion.Euler(0, 180, 0));
                Instantiate(shooter, new Vector3(260.9222f, 15.58597f, 446.1968f), Quaternion.Euler(0, 180, 0));
                Instantiate(shooter, new Vector3(236.3f, 15.58597f, 433.6022f), Quaternion.Euler(0, 180, 0));
                Instantiate(shooter, new Vector3(251.8866f, 15.58597f, 433.6022f), Quaternion.Euler(0, 180, 0));
                Instantiate(charger, new Vector3(244.2738f, 15.58599f, 466.1235f), Quaternion.Euler(0, 180, 0));
                Debug.Log("wave 7");
                waves[6] = true;
            }
            if (player.transform.position.x < 116.5f && player.transform.position.z > 150 && player.transform.position.z <= 238f && !waves[7])
            {
                Debug.Log("wave 8");
                Instantiate(charger, new Vector3(52.14417f, 10.31221f, 183.7665f), Quaternion.Euler(0, 180, 0));
                Instantiate(charger, new Vector3(83.61043f, 10.31221f, 183.7665f), Quaternion.Euler(0, 180, 0));
                waves[7] = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    void decreaseTimer()
    {
        if(timer>0 && !playerC.gameWon && playerC.health > 0) timer--;
    }
    void gameOver()
    {
        GameOver = true;
    }
    void gameWon()
    {
        GameWon = true;
        winWords.SetActive(true);
        winImage.SetActive(true);
        winWords.GetComponent<TextMeshProUGUI>().text = "You Won!!!\n\nif you manged to escape purgatory with "+ (timer - (timer % 60)) / 60 + ":" + timer % 60 + " to spare!\n\nIf you'd like to play again press 'R'";
    }
}
