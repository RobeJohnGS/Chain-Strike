using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;


/*
 * https://youtu.be/Kxempc3fKz4?si=8nc7SckGp0vkiTee
 */
public class RailGrindScript : MonoBehaviour
{
    public bool normalDir;
    public SplineContainer railSpline;
    public float totalSplineLength;

    [SerializeField] BoxCollider boxCollider;

    private void Start()
    {
        railSpline = GetComponent<SplineContainer>();
        totalSplineLength = railSpline.CalculateLength();
        //boxCollider = GetComponent<BoxCollider>();
        //boxCollider.center = Vector3.forward * (totalSplineLength / 2);
        //boxCollider.size = Vector3.forward * totalSplineLength;
    }

    public Vector3 LocalToWorldConversion(float3 localPoint)
    {
        Vector3 worldPos = transform.TransformPoint(localPoint);
        return worldPos;
    }

    public Vector3 WorldtoLocalConversion(float3 worldPoint)
    {
        Vector3 localPos = transform.InverseTransformPoint(worldPoint);
        return localPos;
    }

    public float CalculateTargetRailPoint(Vector3 playerPos, out Vector3 worldPosOnSpline)
    {
        float3 nearestPoint;
        float time;
        SplineUtility.GetNearestPoint(railSpline.Spline, WorldtoLocalConversion(playerPos), out nearestPoint, out time);
        worldPosOnSpline = LocalToWorldConversion(nearestPoint);
        return time;
    }

    public void CalculateDirection(float3 railForward, Vector3 playerForward)
    {
        float angle = Vector3.Angle(railForward, playerForward.normalized);
        if (angle > 90f)
        {
            normalDir = false;
        }
        else
        {
            normalDir = true;
        }
    }
}
