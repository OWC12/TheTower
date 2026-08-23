using UnityEngine;
using UnityEngine.UI;

public class Player_Stats : MonoBehaviour
{
    [Header("Health")]
    public Image healthBar;
    public float maxHealth = 100f;
    public float currentHealth;

    private RectTransform healthRect;
    private float maxHealthBarWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;

        healthRect = healthBar.GetComponent<RectTransform>();
        maxHealthBarWidth = healthRect.sizeDelta.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Damage(Weapon weapon){
        return;
    }
}
