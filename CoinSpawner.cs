using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

    public Transform Coin;

    // Use this for initialization
    void Start () {

        InstantiateCoins();
    }

    void InstantiateCoins()
    {
        int laneNumber = 0;
        for (int i=0; i< CoinValues.TotalPerBlock; i++)
        {
            if (CoinValues.TotalPerBlock % i == 0) laneNumber++;

            Vector3 coinPosition = new Vector3(GetCoinXPosition(laneNumber), CoinValues.CoinYValue, CoinValues.CoinStartingZValue + i);
            Instantiate(Coin, coinPosition, Quaternion.identity);
        }
    }

    float GetCoinXPosition(int laneNumber)
    {
        float coinXPosition = 0;
        switch (laneNumber)
        {
            case 0:
                coinXPosition = CoinValues.CoinLeftXValue;
                break;

            case 1:
                coinXPosition = CoinValues.CoinMiddleXValue;
                break;

            case 2:
                coinXPosition = CoinValues.CoinRightXValue;
                break;
        }

        return coinXPosition;
    }
}

public class CoinValues
{
    public static float CoinLeftXValue = -2.5f;
    public static float CoinMiddleXValue = -0.4f;
    public static float CoinRightXValue = 3.1f;

    public static float CoinYValue = 3.8f;

    public static float CoinStartingZValue = 20;

    public static int CoinsPerLane = 10;
    public static int TotalPerBlock = 30;
}
