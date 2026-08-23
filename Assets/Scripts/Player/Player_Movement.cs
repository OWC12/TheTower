using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
    public float speed = 8;
    public float sprint_coefficient = 2f;
    public Rigidbody2D rb;

    public Image staminaBar;

    [Header("Stamina")]
    public float maxStamina = 100f;
    public float currentStamina;

    public float staminaDrainRate = 25f;
    public float staminaRecoveryRate = 12f;

    public float exhaustionDelay = 2f;
    public float normalDelay = 1f;

    private float recoveryTimer;
    private bool exhausted;

    private RectTransform staminaRect;
    private float maxEnergyBarWidth;

    [Header("Health")]
    public float maxHealth = 100f;
    public float currentHealth;

    private RectTransform healthRect;
    private float maxHealthBarWidth;


    //add drain and recovery rates for gages like poison, bleed, etc.



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentStamina = maxStamina;

        staminaRect = staminaBar.GetComponent<RectTransform>();
        maxEnergyBarWidth = staminaRect.sizeDelta.x;
        
    }

    // Update is called once per frame
    //Can alternatiely switch to FixedUpdate() which is called 50x per frame rather than a variable frame rate
    void Update()
    {
        //left = -1, right = +1, no_input = 0
        float horizontal = Input.GetAxis("Horizontal");  
        //down = -1, up = =1, no_input = 0 
        float vertical = Input.GetAxis("Vertical");

        Vector2 r = new Vector2(horizontal, vertical) * speed;

        //Vector2 = (x, y)

        bool wantsToSprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool sprinting = (horizontal != 0f || vertical != 0f) && wantsToSprint && !exhausted && currentStamina > 0;
        

        if(sprinting){
            r *= sprint_coefficient;
        }
        rb.linearVelocity = r;

        if(sprinting){
            currentStamina -= staminaDrainRate * Time.deltaTime;
            recoveryTimer = 0f;

            if(currentStamina <= 0){
                currentStamina = 0;
                exhausted = true;
            }
        }
        //else if(currentStamina == 0 || (horizontal == 0 && vertical == 0)){
            if(currentStamina < maxStamina){
                recoveryTimer += Time.deltaTime;

                if(recoveryTimer >= exhaustionDelay || (!exhausted && recoveryTimer > normalDelay)){
                    currentStamina += staminaRecoveryRate * Time.deltaTime;
                }
            }
        //

        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        if(exhausted){
            speed = 0;
            if(currentStamina > 0){
                exhausted = false;
                speed = 8;
            }
        }

        float percent = currentStamina / maxStamina;

        staminaRect.sizeDelta = new Vector2(maxEnergyBarWidth * percent, staminaRect.sizeDelta.y);
    }
}
