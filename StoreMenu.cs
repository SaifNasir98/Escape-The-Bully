using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreMenu : MonoBehaviour {

    public GameObject DialogBox;
    public GameObject DialogBox2;
    public GameObject DialogBox3;
    public GameObject DialogBox4;

    public GameObject CoinStoreMenu;
    public GameObject OutfitsStoreMenu;
    public GameObject PowerupStoreMenu;
    public GameObject RewardsStoreMenu;

	public void BackHome()
    {
        SceneManager.LoadScene(0);
    }

    public void BuyCoinsDialog()
    {
        DialogBox.SetActive(false);
        CoinStoreMenu.SetActive(true);
    }

    public void BuyOutfitsDialog()
    {
        DialogBox2.SetActive(false);
        OutfitsStoreMenu.SetActive(true);
    }

    public void BuyPowerUpsDialog()
    {
        DialogBox3.SetActive(false);
        PowerupStoreMenu.SetActive(true);
    }

    public void BuyRewardsDialog()
    {
        DialogBox4.SetActive(false);
        RewardsStoreMenu.SetActive(true);
    }
}
