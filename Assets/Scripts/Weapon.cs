using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Weapon")]
public class Weapon : ScriptableObject
{
    public String weaponName {get; set;}
    public Sprite weaponSprite;
    public Dictionary<string, int> BaseDamage {get; set;}
    public Dictionary<string, string> Attributes{get; set;}

}
