using UnityEngine;

public class TailWhipScript : MonoBehaviour, ITrick
{
    public float trickDmg => 5f;
    public float trickBaseDmg => 5f;
    public float trickKnockback { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public string trickParam { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public float TrickPerformed(float dmgMult)
    {
        return trickBaseDmg * dmgMult;
    }
}
