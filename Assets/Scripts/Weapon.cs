using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Weapons/Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName {get; set;}
    public Sprite weaponSprite {get; set;}
    public Dictionary<string, int> BaseDamage {get; set;} = new Dictionary<string, int>();
    public Dictionary<string, string> Attributes{get; set;} = new Dictionary<string, string>();

}