using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Joystick joystick;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
