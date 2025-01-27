using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [Header("Player Data")]
    [SerializeField] float health;
    //Add player ui stuff
    [Header("Trick Combos")]
    [SerializeField] float comboLength;
    float comboTimer;
    public float comboPoints;
    public float comboMult;
    [Header("UI Attributes")]
    //combo ui game object
    [SerializeField] GameObject comboUIGO;

    private void Update()
    {
        if (comboTimer > 0)
        {
            comboTimer -= Time.deltaTime;
        }
        //Check if the player health is at or below 0
        if (health <= 0)
        {
            //Kills the player
            OnDeath();
        }
    }

    //Player takes damage
    public void OnTakeDamage(float dmg)
    {
        health -= dmg;
    }

    //Player dies
    public void OnDeath()
    {

    }

    //Start the combo timer
    public void StartCombo()
    {
        if (comboTimer <= 0)
        {
            comboTimer = comboLength;
        }
    }

    public void AddToCombo(float points,  float mult)
    {
        StartCombo();
        comboMult += mult;
        comboPoints += points;
    }
}
