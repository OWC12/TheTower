using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Weapon")]
public class Weapon : ScriptableObject
{
    public String weaponName {get; set;}
    public Sprite weaponSprite;
    public Dictionary<String, Integer> BaseDamage {get; set;}
    public Dictionary<String, String> Attributes{get; set;}

}
