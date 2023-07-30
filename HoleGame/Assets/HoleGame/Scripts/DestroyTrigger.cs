using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private PlayerSize playerSize;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Collectible collectible))
        {
            playerSize.CollectibleCollected(collectible.GetSize());

            UI.Instance.AddText((int)other.gameObject.GetComponent<Collectible>().size, transform.position);
            UI.Instance.IncreaseText();
            Destroy(other.gameObject);
        }
    }

}
