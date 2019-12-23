using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Weapon
{
    public string name;
    public int weaponID;

    //public Sprite sprite;
    public string spriteName;

    public int price;

    public int bonusAttack;

    public bool bought;
}
