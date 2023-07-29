using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float size;

    private void Start()
    {
        GetComponent<Rigidbody>().sleepThreshold = 0;
        size = transform.localScale.x;
    }

    public float GetSize()
    {
        return size;
    }
}
