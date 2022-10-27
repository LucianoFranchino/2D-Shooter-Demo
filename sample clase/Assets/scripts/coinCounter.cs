using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinCounter : MonoBehaviour
{
    public Text coinText;
    private int coins;

    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        coinText.text = "Monedas: " + coins;

    }
   
    private void OnTriggerEnter2D(Collider2D Moneda)
    {
        if(Moneda.tag == "Coin")
        {
            coins += 1;
            Destroy(Moneda.gameObject);
            coinText.text = "Monedas: " + coins;
        }
    }
}
