using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] public float size;

    private void Start()
    {
        GetComponent<Rigidbody>().sleepThreshold = 0;
    }

    public float GetSize()
    {
        return size;
    }
}
