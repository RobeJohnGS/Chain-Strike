using UnityEngine;

public class SuperManKickScript : MonoBehaviour, ITrick
{
    public float trickDmg => 2f;

    public float trickBaseDmg => 2f;

    public float trickKnockback => 4f;

    public string trickParam => "SuperManKick";

    public float TrickPerformed(float dmgMult)
    {
        return trickBaseDmg * dmgMult;
    }
}
