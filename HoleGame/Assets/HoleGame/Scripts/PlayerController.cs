using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float screenPositionFollowThreshold;
    [SerializeField] private float moveSpeed;
    private Vector3 clickedPositionScreen;

    private void Update()
    {
        ManageControl();
    }

    private void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedPositionScreen = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 difference = Input.mousePosition - clickedPositionScreen;

            Vector3 direction = difference.normalized;

            float maxScreenDistance = screenPositionFollowThreshold * Screen.height;

            if(difference.magnitude > maxScreenDistance)
            {
                clickedPositionScreen = Input.mousePosition - direction * maxScreenDistance;
                difference = Input.mousePosition - clickedPositionScreen;
            }

            difference /= Screen.width;

            difference.z = difference.y;
            difference.y = 0;

            Vector3 targetPosition = transform.position + difference * moveSpeed * Time.deltaTime;

            transform.position = targetPosition;
        }
    }
}
