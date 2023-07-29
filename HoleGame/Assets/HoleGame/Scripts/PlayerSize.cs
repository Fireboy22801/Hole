using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]private float scaleIncreaseTreshold;
    [SerializeField]private float scaleStep;
    private float scaleValue;

    public void CollectibleCollected(float objectSize)
    {
        scaleValue += objectSize;

        if(scaleValue >= scaleIncreaseTreshold)
        {
            IncreaseScale();
            scaleValue = scaleValue % scaleIncreaseTreshold;
        }
    }

    private void IncreaseScale()
    {
        transform.localScale += scaleStep * Vector3.one;
    }
}
