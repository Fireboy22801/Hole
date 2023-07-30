using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    public static PlayerSize Instance { get; private set; }

    [Header("Settings")]
    public float ScaleIncreaseTreshold;
    public float scaleStep;

    [HideInInspector] public float scaleValue;

    private void Awake()
    {
        Instance = this;
    }

    public void CollectibleCollected(float objectSize)
    {
        GameManager.Instance.points += objectSize;

        GameManager.Instance.CheckPoints();
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
