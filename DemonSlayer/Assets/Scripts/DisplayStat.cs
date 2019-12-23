using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayStat : MonoBehaviour
{
    public Text playerAttack;
    public Text playerHealth;
    public Text skill1;
    public Text skill2;
    public Text skill3;

    string skill1Desc = "1. Striking Tide: A vertical slash that launches enemy into the air. Dealing ";
    string skill2Desc = "2. Water Wheel: Leaps and spins in the air while releasing an flowing attack in a circular motion, Dealing ";
    string skill3Desc = "3. Twisting Whirlpool: Create a Tornado that cuts anything caught in it. Dealing ";
    //void Start()
    //{
    //    playerAttack.text = "Damage: " + Player.baseAttack.ToString() + "(+" + ShopManager.shop.weaponList[ShopManager.shop.currentWeaponID].bonusAttack.ToString() + ")";
    //    playerHealth.text = "Max HP: " + Player.maxHealth.ToString() + "/" + Player.maxHealth.ToString();
    //    skill1.text = skill1Desc + (Player.baseAttack + ShopManager.shop.weaponList[ShopManager.shop.currentWeaponID].bonusAttack + 10).ToString() + " damage.";
    //    skill2.text = skill2Desc + (Player.baseAttack + ShopManager.shop.weaponList[ShopManager.shop.currentWeaponID].bonusAttack + 30).ToString() + " damage.";
    //    skill3.text = skill3Desc + (Player.baseAttack + ShopManager.shop.weaponList[ShopManager.shop.currentWeaponID].bonusAttack + 50).ToString() + " damage.";
    //}
    void Update()
    {
        if (ShopManager.shop.currentWeaponID != 0)
        {
            playerAttack.text = "Damage: " + Player.baseAttack.ToString() + "(+" + ShopManager.shop.weaponList[ShopManager.shop.currentWeaponID-1].bonusAttack.ToString() + ")";
            playerHealth.text = "Max HP: " + Player.maxHealth.ToString() + "/" + Player.maxHealth.ToString();
            skill1.text = skill1Desc + (Player.baseAttack + ShopManager.shop.weaponList[ShopManager.shop.currentWeaponID-1].bonusAttack + 10).ToString() + " damage.";
            skill2.text = skill2Desc + (Player.baseAttack + ShopManager.shop.weaponList[ShopManager.shop.currentWeaponID-1].bonusAttack + 30).ToString() + " damage.";
            skill3.text = skill3Desc + (Player.baseAttack + ShopManager.shop.weaponList[ShopManager.shop.currentWeaponID-1].bonusAttack + 50).ToString() + " damage.";
        }
        else
        {
            playerAttack.text = "Damage: " + Player.baseAttack.ToString() + "(+0)";
            playerHealth.text = "Max HP: " + Player.maxHealth.ToString() + "/" + Player.maxHealth.ToString();
            skill1.text = skill1Desc + (Player.baseAttack + 10).ToString() + " damage.";
            skill2.text = skill2Desc + (Player.baseAttack + 30).ToString() + " damage.";
            skill3.text = skill3Desc + (Player.baseAttack + 50).ToString() + " damage.";
        }
    }
}
