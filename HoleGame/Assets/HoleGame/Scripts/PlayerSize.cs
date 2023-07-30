using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    public static PlayerSize Instance { get; private set; }

    [Header("Settings")]
    public float ScaleIncreaseTreshold;
    public float scaleStep;

    [HideInInspector] public float scaleValue;

    public float points;

    private void Awake()
    {
        Instance = this;
    }

    public void CollectibleCollected(float objectSize)
    {
        points += objectSize;
        scaleValue += objectSize;

        if (scaleValue >= ScaleIncreaseTreshold)
        {
            scaleValue -= ScaleIncreaseTreshold;
            IncreaseScale();
        }
    }

    private void IncreaseScale()
    {
        ScaleIncreaseTreshold *= 2f;
        transform.localScale += scaleStep * Vector3.one;
        FindObjectOfType<CameraController>().IncreaseDistance();
    }
}
