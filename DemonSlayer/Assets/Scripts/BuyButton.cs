using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public int weaponID;
    public Text buyText;
    public void Buy()
    {
        for (int i = 0; i < ShopManager.shop.weaponList.Count; i++)
        {
            if (ShopManager.shop.weaponList[i].weaponID == weaponID && !ShopManager.shop.weaponList[i].bought && ShopManager.shop.weaponList[i].price <= ShopManager.shop.gold)
            {
                ShopManager.shop.weaponList[i].bought = true;
                ShopManager.shop.gold -= ShopManager.shop.weaponList[i].price;
                for (int j = 0; j < ShopManager.shop.shopSlotList.Count; j++)   
                {
                    if (ShopManager.shop.shopSlotList[j].itemID == weaponID)
                    {
                        ShopManager.shop.shopSlotList[j].price.text = "SOLD";
                    }
                }
                ShopManager.shop.currentWeaponID = weaponID;
                UpdateButton();
            }
            else if (ShopManager.shop.weaponList[i].weaponID == weaponID && !ShopManager.shop.weaponList[i].bought && !(ShopManager.shop.weaponList[i].price <= ShopManager.shop.gold))
            {
                Debug.Log("Not Enough Gold");
            }
            else if(ShopManager.shop.weaponList[i].weaponID == weaponID && ShopManager.shop.weaponList[i].bought)
            {
                ShopManager.shop.currentWeaponID = weaponID;
                UpdateButton();
            }
        } 
    }

    void UpdateButton()
    {
        buyText.text = "Equipped";
        for (int i = 0; i < ShopManager.shop.buyButtonList.Count; i++)
        {
            BuyButton script = ShopManager.shop.buyButtonList[i].GetComponent<BuyButton>();
            for (int j = 0; j < ShopManager.shop.weaponList.Count; j++)
            {
                if (ShopManager.shop.weaponList[j].weaponID == script.weaponID && ShopManager.shop.weaponList[j].bought && ShopManager.shop.weaponList[j].weaponID != weaponID)
                {
                    script.buyText.text = "Equip";
                }
            }
        }
    }
}
