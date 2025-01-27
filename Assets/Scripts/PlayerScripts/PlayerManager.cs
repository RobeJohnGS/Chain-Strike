using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [Header("Player Data")]
    [SerializeField] float health;
    [SerializeField] float points;
    //Add player ui stuff
    [Header("Trick Combos")]
    [SerializeField] float comboLength;
    public float comboDmg;
    float totalPoints;
    float comboTimer;
    public float comboPoints;
    public float comboMult;
    [Header("UI Attributes")]
    //combo ui game object
    [SerializeField] Image comboMeter;
    [SerializeField] TMP_Text comboMeterText;

    private void Update()
    {
        if (comboTimer > 0)
        {
            comboTimer -= Time.deltaTime;

        }
        else
        {
            ApplyComboScore();
        }
        //Check if the player health is at or below 0
        if (health <= 0)
        {
            //Kills the player
            OnDeath();
        }

        //UI Things
        comboMeter.enabled = comboTimer > 0;
        comboMeterText.enabled = comboTimer > 0;
        comboMeter.fillAmount = comboTimer / comboLength;
        comboMeterText.text = comboPoints + " X " + comboMult;
    }

    //Player takes damage
    public void OnTakeDamage(float dmg)
    {
        health -= dmg;
        comboTimer = 0;
        comboMult = 0;
        comboPoints = 0;
    }

    //Player dies
    public void OnDeath()
    {

    }

    //The player has 1 second to do a trick in the time of the combo meter going down, once the meter goes down any multiplier or points they had will be added to their total points and a reduced number will be added to the damage multiplier. If the player gets hit while trying to start a combo chain, they will lose all points and mult in the combos, get nothing added to their score, and lose any damage they had.

    public void AddToCombo(TrickScript trick)
    {
        comboTimer = comboLength;
        if (comboDmg <= 0)
        {
            comboMult += trick.trickData.trickMult;
            comboPoints += trick.trickData.trickPoints;
        }
        
    }

    public float DealComboDamage()
    {
        if (comboDmg > 0)
        {
            return comboDmg;
        }
        return 0f;
    }

    private void ApplyComboScore()
    {
        if ((comboPoints > 0 || comboMult > 0) && comboDmg <= 0)
        {
            //If the player had any points or mult, add it to score and damage multiplier.
            points += (comboPoints * comboMult);
            comboDmg = (comboPoints * comboMult) / 100;
            Debug.Log(comboDmg);
            comboTimer = 0;
            comboMult = 0;
            comboPoints = 0;
        }
    }
}
