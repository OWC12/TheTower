using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField] private Image weaponImage;
    [SerializeField] private TMP_Text weaponName;

    public void SetWeapon(Weapon weapon)
    {
        if (weapon == null)
        {
            weaponImage.enabled = false;
            weaponName.text = "";
            return;
        }

        weaponImage.enabled = true;
        weaponImage.sprite = weapon.weaponSprite;
        weaponName.text = weapon.weaponName;
    }
}