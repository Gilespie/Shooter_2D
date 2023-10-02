using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speedMovement = 15f;
    [SerializeField] private float _damageAmount = 23.5f;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        Vector2 direction = -transform.right * _speedMovement * Time.deltaTime;

        transform.Translate(direction);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            IDamageable enemy = other.GetComponent<IDamageable>();

            if (enemy != null)
            {
                enemy.GetDamage(_damageAmount);
                Destroy(gameObject);
            }
        }
    }
}