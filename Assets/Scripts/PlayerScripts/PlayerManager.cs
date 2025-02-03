using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    /*
     * Player data variables
     * Player Health
     * Player Points (gained from tricks and combos)
     * Take Damage Cooldown, essentially like invincibility frames so the player can only get hit after the cooldown
     */
    [Header("Player Data")]
    [SerializeField] float health;
    [SerializeField] float points;
    [SerializeField] float takeDmgCD;
    private float takeDmgCDTimer;
    /*trick Combo Variables
     * Combo length is how long the player has to do another trick before the combo resets
     * comboTimer is the timer that counts down, it resets by setting itself to combo length
     * comboPoints is how many points the player has accumulated during their combo
     * comboMult is the multiplier that the player has accumulated during their combo
     */
    [Header("Trick Combos")]
    [SerializeField] float comboLength;
    public float comboDmg;
    float comboTimer;
    public float comboPoints;
    public float comboMult;
    /*Player Ui Attributes
     * The temporary Combo Meter
     * The comboMeterText
     * Text for debugging how much combo damage the player has accumulated
     */
    [Header("UI Attributes")]
    [SerializeField] Image comboMeter;
    [SerializeField] TMP_Text comboMeterText;
    [SerializeField] TMP_Text healthTxt;

    private void Awake()
    {
        healthTxt.text = health.ToString();
    }

    private void Update()
    {
        //Countdown for the combo timer to count down only if it is above 0 (aka the player has started a combo)
        if (comboTimer > 0)
        {
            comboTimer -= Time.deltaTime;

        }
        else
        {
            //If the player has ended the combo it will add the points and combo dmg accumulated during the combo
            ApplyComboScore();
        }

        takeDmgCDTimer -= Time.deltaTime;

        //Check if the player health is at or below 0
        if (health <= 0)
        {
            //Kills the player
            OnDeath();
        }

        //the combo meter UI image and combo meter text is only enabled if the comboTimer is above 0
        comboMeter.enabled = comboTimer > 0;
        comboMeterText.enabled = comboTimer > 0;
        //Combo meter fill amount is the current timer / the total combo length
        comboMeter.fillAmount = comboTimer / comboLength;
        //Display combo points and combo mult
        comboMeterText.text = comboPoints + " X " + comboMult;
    }

    //Player takes damage
    public void OnTakeDamage(float dmg)
    {
        //if the take damage cooldown has run out then the player can take damage again
        if (takeDmgCDTimer <= 0)
        {
            //take the damage
            health -= dmg;
            //Reset combo attributes if the player has taken damage
            ResetComboScore(0f);
            takeDmgCDTimer = takeDmgCD;
            //Health Text UI Element Update
            healthTxt.text = Mathf.Floor(health).ToString(); ;
        }
    }

    public void OnDealDamage()
    {
        while (!gameObject.GetComponent<PlayerAnimationHandler>().animationPlaying)
        {
            ResetComboScore(0f);
        }
    }

    //Player dies
    public void OnDeath()
    {

    }

    //The player has 1 second to do a trick in the time of the combo meter going down, once the meter goes down any multiplier or points they had will be added to their total points and a reduced number will be added to the damage multiplier. If the player gets hit while trying to start a combo chain, they will lose all points and mult in the combos, get nothing added to their score, and lose any damage they had.
    //Reset combo damage over a certain amount of time

    //This is called by the trick script / player animation handler to add whatever trick the player performes to the combo points and mult
    //Additionally this resets the combo timer
    public void AddToCombo(TrickScript trick)
    {
        comboTimer = comboLength;
        comboMult += trick.trickData.trickMult;
        comboPoints += trick.trickData.trickPoints;

    }

    //Once the combo timer has run out this function is called
    private void ApplyComboScore()
    {
        //if the player accumulated points or mult during a combo
        if ((comboPoints > 0 || comboMult > 0))
        {
            //Add to the players points
            points += (comboPoints * comboMult);
            //If the player does not already have combo dmg
            if (comboDmg <= 0)
            {
                //The combo damage is purposfully reduced
                comboDmg = (comboPoints * comboMult) / 100;
            }
            //Reset combo timer, points, and mult
            ResetComboScore();
        }
    }

    //Reset combo timer, points, and mult
    public void ResetComboScore()
    {
        comboTimer = 0;
        comboMult = 0;
        comboPoints = 0;
    }
    //Reset combo timer, points, mult, and comboDmg
    public void ResetComboScore(float comboDmg)
    {
        comboTimer = 0;
        comboMult = 0;
        comboPoints = 0;
        this.comboDmg = comboDmg;
    }
}
