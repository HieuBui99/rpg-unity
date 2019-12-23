using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShopManager : MonoBehaviour
{
    public static ShopManager shop;
    public int currentWeaponID = 0;
    public int gold;
    public Text goldDisplay;
    public GameObject itemSlot;

    public Transform itemSlotGrid;

    public List<Weapon> weaponList = new List<Weapon>();
    public List<ShopSlot> shopSlotList = new List<ShopSlot>();
    public List<GameObject> buyButtonList = new List<GameObject>();
    void Awake()
    {
        shop = this;
        currentWeaponID = PlayerPrefs.GetInt("Current Weapon", 0);
        LoadShop();
        DisplayShop();

    }
    void Update()
    {
        goldDisplay.text = gold.ToString();
        
    }

    void DisplayShop()
    {
        for (int i = 0; i < weaponList.Count; i++)
        {
            GameObject slot = Instantiate(itemSlot, itemSlotGrid);
            ShopSlot shopSlot = slot.GetComponent<ShopSlot>();
            shopSlot.itemName.text = weaponList[i].name;
            shopSlot.price.text = "Price: " + weaponList[i].price.ToString();
            shopSlot.bonusStat.text = "+" + weaponList[i].bonusAttack.ToString() + "Attack";
            shopSlot.itemImage.sprite =Resources.Load<Sprite>(weaponList[i].spriteName);
            shopSlot.buyButton.GetComponent<BuyButton>().weaponID = weaponList[i].weaponID;
            shopSlot.itemID = weaponList[i].weaponID;
            shopSlotList.Add(shopSlot);
            buyButtonList.Add(shopSlot.buyButton);
        }

        for (int i = 0; i < buyButtonList.Count; i++)
        {
            BuyButton script = buyButtonList[i].GetComponent<BuyButton>();
            for (int j = 0; j < weaponList.Count; j++)
            {
                if (weaponList[j].weaponID == script.weaponID && weaponList[j].weaponID != currentWeaponID && weaponList[j].bought)
                {
                    script.buyText.text = "Equip";
                }
                else if (weaponList[j].weaponID == script.weaponID && weaponList[j].weaponID == currentWeaponID && weaponList[j].bought )
                {
                    script.buyText.text = "Equipped";
                }
            }
        }
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void SaveShopState()
    {
        if (currentWeaponID != 0)
        {
            PlayerPrefs.SetInt("Bonus Attack", weaponList[currentWeaponID - 1].bonusAttack);
        }
        PlayerPrefs.SetInt("Current Weapon", currentWeaponID);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/shop.dat", FileMode.Create);
        bf.Serialize(stream, weaponList);
        stream.Close();
    }

    void LoadShop()
    {
        if (File.Exists(Application.persistentDataPath + "/shop.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/shop.dat", FileMode.Open);
            weaponList.Clear();
            weaponList = (List<Weapon>)bf.Deserialize(stream);
            stream.Close();
        }
    }
}
