using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speedMovement;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal") * _speedMovement * Time.deltaTime;

        Vector2 direction = new Vector2(horizontalInput, 0);

        transform.Translate(direction);
    }
}