using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowPanel : MonoBehaviour
{
    public GameObject manPanel;
    public GameObject boyPanel;
    public GameObject grandpaPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Man")
        {
            manPanel.SetActive(true);
        }
        if (collision.gameObject.tag == "Boy")
        {
            boyPanel.SetActive(true);
        }
        if (collision.gameObject.tag == "Grandpa")
        {
            grandpaPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Man")
        {
            manPanel.SetActive(false);
        }
        if (collision.gameObject.tag == "Boy")
        {
            boyPanel.SetActive(false);
        }
        if (collision.gameObject.tag == "Grandpa")
        {
            grandpaPanel.SetActive(false);
        }
    }
}
