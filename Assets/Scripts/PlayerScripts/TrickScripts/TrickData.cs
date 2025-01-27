using UnityEngine;

[CreateAssetMenu(fileName = "TrickData", menuName = "Scriptable Objects/TrickData")]
public class TrickData : ScriptableObject
{
    //Trick damage after the player's trick multiplier to it.
    public float trickDmg;
    //Tricks base damage before the player's trick multiplier.
    public float trickBaseDmg;
    //Trick point value
    public float trickPoints;
    //Trick mult value
    public float trickMult;
    //Trick knockback applied to the enemy.
    public float trickKnockback;
    //Trick animation parameter name
    public string trickParam;
}
