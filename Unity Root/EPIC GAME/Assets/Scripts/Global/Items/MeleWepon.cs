using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "NewMeleWepon", menuName = "Items/Wepons/Melee")]
public class MeleWepon : ScriptableObject
{
    public string weponName;
    public string weponDescription;
    public float damage;
    public float critChance;
    public float critMultiplyer;
    public Sprite invintorySprite;
    public Sprite quickMenuSprite;
    public int meleWeponType;
    //0 light 1 heavy 2 utility 3 perminant ability 4 temporary ability 5 debug
}
