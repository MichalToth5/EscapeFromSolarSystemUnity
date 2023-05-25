using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGui : MonoBehaviour
{
    public Text messageText;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TextOvladanie")
        {
            ShowText("Movement - A D\nJump - Space", true);
        }
        if (collision.gameObject.tag == "MeleeText")
        {
            ShowText("Melee attack - left mouse button", true);
        }
        if (collision.gameObject.tag == "HealthText")
        {
            ShowText("Health potion - recover one health\nUse with 1,2 or 3 button", true);
        }
        if (collision.gameObject.tag == "CoinText")
        {
            ShowText("Collect gold coins for better rating at the end of the level!", true);
        }
        if (collision.gameObject.tag == "NewEnemyText")
        {
            ShowText("Be aware! This enemy can shoot toxic projectiles!", true);
        }
        if (collision.gameObject.tag == "JumpadText")
        {
            ShowText("Some places can only be reached with the help of jumpad boost. Try it now!", true);
        }
        if (collision.gameObject.tag == "JupiterCloudText")
        {
            ShowText("This planet is gas, but in some places the gas is thicker and I can walk on it!", true);
        }
        if (collision.gameObject.tag == "JupiterSpodokText")
        {
            ShowText("I am very deep, if I go lower, the gas pressure can be dangerous for me!", true);
        }
        if (collision.gameObject.tag == "JupiterNextPText")
        {
            ShowText("The next planet is as gassy as this one, I should prepare for any situation!", true);
        }
        if (collision.gameObject.tag == "SaturnWhereText")
        {
            ShowText("Which way should I go? I have no idea...", true);
        }
        if (collision.gameObject.tag == "UranInfoText")
        {
            ShowText("This planet is very cold even for me. I have to leave her as soon as possible!", true);
        }
        if (collision.gameObject.tag == "NeptuneStartText")
        {
            ShowText("Finally, this is the last planet of the solar system! Soon my adventure will end.", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TextOvladanie")
        {
            ShowText("", false);
        }
        if (collision.gameObject.tag == "MeleeText")
        {
            ShowText("", false);
        }
        if (collision.gameObject.tag == "HealthText")
        {
            ShowText("", false);
        }
        if (collision.gameObject.tag == "CoinText")
        {
            ShowText("", false);
        }
        if (collision.gameObject.tag == "NewEnemyText")
        {
            ShowText("", false);
        }
        if (collision.gameObject.tag == "JumpadText")
        {
            ShowText("", false);
        }
        if (collision.gameObject.tag == "JupiterCloudText")
        {
            ShowText("", false);
        }
        if (collision.gameObject.tag == "JupiterSpodokText")
        {
            ShowText("", false);
        }
        if (collision.gameObject.tag == "JupiterNextPText")
        {
            ShowText("", false);
        }
        if (collision.gameObject.tag == "SaturnWhereText")
        {
            ShowText("", false);
        }
        if (collision.gameObject.tag == "UranInfoText")
        {
            ShowText("", false);
        }
        if (collision.gameObject.tag == "NeptuneStartText")
        {
            ShowText("", false);
        }
    }


    public void ShowText(string message, bool enebled)
    {
        messageText.text = message;
        messageText.transform.gameObject.SetActive(enabled);
    }
}
