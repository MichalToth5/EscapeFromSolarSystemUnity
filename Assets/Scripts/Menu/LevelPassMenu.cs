using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPassMenu : MonoBehaviour
{
    public GameObject levelPassMenuUI;
    public Image Head1;
    public Image Head2;
    public Image Head3;
    private CoinSystem coinSystem;
    private GameObject player;
    public Text messageText;
    private PlayerGui playerGui;
    public AudioSource levelpassSound;

    //kontrola pre odomknutie levelu
    public static bool mercuryFinished = false;
    public static bool venusFinished = false;
    public static bool earthFinished = false;
    public static bool marsFinished = false;
    public static bool jupiterFinished = false;
    public static bool saturnFinished = false;
    public static bool uranusFinished = false;
    public static bool neptuneFinished = false;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        coinSystem = player.GetComponent<CoinSystem>();
        playerGui = player.GetComponent<PlayerGui>();
        levelpassSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && coinSystem.hasKey == true)
        {
            ShowLevelPassMenu();
            levelpassSound.Play();
        }
        else
        {
            playerGui.ShowText("To finish the level you need to find the key!", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerGui.ShowText("", false);
    }

    public void ShowLevelPassMenu()
    {
        levelPassMenuUI.SetActive(true);
        UnlockLevel();
        Time.timeScale = 0f;
        ShowStars();
    }

    
    // spravit metodu so vstupnym argumentom pocet hviezd
    // podla cisla budes resolvovat obrazky
    public void ShowStars()
    {
        Head1.enabled = false;
        Head2.enabled = false;
        Head3.enabled = false;
        
        
        if (coinSystem.numOfCoins > 0)
        {
            Head1.GetComponent<Image>().enabled = true;
            Debug.Log("0 minci");
        }
        if (coinSystem.numOfCoins > 1)
        {
            Debug.Log("1 minci");
            Head2.GetComponent<Image>().enabled = true;
        }
        if (coinSystem.numOfCoins > 2)
        {
            Head3.GetComponent<Image>().enabled = true;
        }
    }
    public void UnlockLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Mercury")
        {
            mercuryFinished = true;
        }
        if(scene.name == "Venus")
        {
            venusFinished = true;
        }
        if(scene.name == "Earth")
        {
            earthFinished = true;
        }
        if(scene.name == "Mars")
        {
            marsFinished = true;
        }
        if(scene.name == "Jupiter")
        {
            jupiterFinished = true;
        }
        if(scene.name == "Saturn")
        {
            saturnFinished = true;
        }
        if(scene.name == "Uranus")
        {
            uranusFinished = true;
        }
        if(scene.name == "Neptune")
        {
            neptuneFinished = true;
        }
    }
}
