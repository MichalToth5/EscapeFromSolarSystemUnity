using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SelectLevelManager : MonoBehaviour
{
    public GameObject leveleLockedText;
    public GameObject wordFromCreator;
    public void LoadMercury()
    {
        SceneManager.LoadScene("Mercury");
    }
    public void LoadVenus()
    {
        if(LevelPassMenu.mercuryFinished == true)
        {
            SceneManager.LoadScene("Venus");
        }
        else
        {
            StartCoroutine(LevelLockedText());
        }  
    }
    public void LoadEarth()
    {
        if(LevelPassMenu.venusFinished == true)
        {
            SceneManager.LoadScene("Earth");
        }
        else
        {
            StartCoroutine(LevelLockedText());
        }
    }
    public void LoadMars()
    {
        if(LevelPassMenu.earthFinished == true)
        {
            SceneManager.LoadScene("Mars");
        }
        else
        {
            StartCoroutine(LevelLockedText());
        }
    }
    public void LoadJupiter()
    {
        if(LevelPassMenu.marsFinished == true)
        {
            SceneManager.LoadScene("Jupiter");
        }
        else
        {
            StartCoroutine(LevelLockedText());
        }
    }
    public void LoadSaturn()
    {
        if(LevelPassMenu.jupiterFinished == true)
        {
            SceneManager.LoadScene("Saturn");
        }else
        {
            StartCoroutine(LevelLockedText());
        }
    }
    public void LoadUranus()
    {
        if(LevelPassMenu.saturnFinished == true)
        {
            SceneManager.LoadScene("Uranus");
        }else
        {
            StartCoroutine(LevelLockedText());
        }
    }
    public void LoadNeptune()
    {
        if(LevelPassMenu.uranusFinished == true)
        {
            SceneManager.LoadScene("Neptune");
        }
        else
        {
            StartCoroutine(LevelLockedText());
        }   
    }
    public void LoadWordFromCreator()
    {
        if (LevelPassMenu.neptuneFinished == true)
        {
            wordFromCreator.SetActive(true);
        }
        else
        {
            StartCoroutine(LevelLockedText());
        }
    }
    public void ZavriWordFromCreator()
    {
        wordFromCreator.SetActive(false);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    IEnumerator LevelLockedText()
    {
        leveleLockedText.SetActive(true);
        yield return new WaitForSeconds(3);
        leveleLockedText.SetActive(false);
    }
}
