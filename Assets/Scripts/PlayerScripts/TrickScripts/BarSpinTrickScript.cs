using UnityEngine;

public class BarSpinTrickScript : MonoBehaviour, ITrick
{
    public float trickDmg => 1f;

    public float trickBaseDmg => 1f;

    public float trickKnockback => 2f;

    public string trickParam => "BarSpin";

    public float TrickPerformed(float dmgMult)
    {
        return trickBaseDmg * dmgMult;
    }
}
