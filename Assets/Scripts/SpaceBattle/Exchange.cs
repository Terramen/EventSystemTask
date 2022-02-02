using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exchange : MonoBehaviour
{
    private int currentCoins;
    [SerializeField] private Text coinsText;

    [SerializeField] private CellAnimation[] cells;


    // Start is called before the first frame update
    void Awake()
    {
        currentCoins = 100;
    }

    public void BuyAsteroid(int coins)
    {
        if (currentCoins > 0)
        {
            currentCoins -= coins;  
        }
    }
    
    public void SellAsteroid(int coins)
    {
        currentCoins += coins;
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = $"Coins: {currentCoins}";
    }
}
