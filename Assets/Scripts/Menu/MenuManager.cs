using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MercuryInfoUI;
    public GameObject VenusInfoUI;
    public GameObject EarthInfoUI;
    public GameObject MarsInfoUI;
    public GameObject JupiterInfoUI;
    public GameObject SaturnInfoUI;
    public GameObject UranusInfoUI;
    public GameObject NeptuneInfoUI;
    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void AboutPlanets()
    {
        SceneManager.LoadScene("AboutPlanets");
    }

    public void MercuryInfo()
    {
        MercuryInfoUI.SetActive(true);
    }
    public void VenusInfo()
    {
        VenusInfoUI.SetActive(true);
    }
    public void EarthInfo()
    {
        EarthInfoUI.SetActive(true);
    }
    public void MarsInfo()
    {
        MarsInfoUI.SetActive(true);
    }
    public void JupiterInfo()
    {
        JupiterInfoUI.SetActive(true);
    }
    public void SaturnInfo()
    {
        SaturnInfoUI.SetActive(true);
    }
    public void UranusInfo()
    {
        UranusInfoUI.SetActive(true);
    }
    public void NeptuneInfo()
    {
        NeptuneInfoUI.SetActive(true);
    }

    public void ZavriMercury()
    {
        MercuryInfoUI.SetActive(false);
    }
    public void ZavriVenus()
    {
        VenusInfoUI.SetActive(false);
    }
    public void ZavriEarth()
    {
        EarthInfoUI.SetActive(false);
    }
    public void ZavriMars()
    {
        MarsInfoUI.SetActive(false);
    }
    public void ZavriJupiter()
    {
        JupiterInfoUI.SetActive(false);
    }
    public void ZavriSaturn()
    {
        SaturnInfoUI.SetActive(false);
    }
    public void ZavriUranus()
    {
        UranusInfoUI.SetActive(false);
    }
    public void ZavriNeptune()
    {
        NeptuneInfoUI.SetActive(false);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void BackToLevelSelection()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelect");
    }
}
