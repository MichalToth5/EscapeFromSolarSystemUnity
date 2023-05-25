using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSystem : MonoBehaviour
{

    public Text coinText;
    public int numOfCoins = 0;
    public bool hasKey = false;
    [SerializeField]private AudioSource collectKeyOrCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            numOfCoins++;
            coinText.text = "" + numOfCoins;
            collectKeyOrCoin.Play();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            hasKey = true;
            collectKeyOrCoin.Play();
            Destroy(collision.gameObject);
        }
    }
}
