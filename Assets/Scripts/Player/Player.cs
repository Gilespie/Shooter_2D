using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health = 100f;
    [SerializeField] private int _ammoCount = 30;
    public float Health { get; set; }


    private void Start()
    {
        Health = _health;
    }

    private void Update()
    {

    }

    public void Damage(float damage)
    {
        if (damage <= 0 || Health <= 0) return;

        Health -= damage;

        if (Health <= 0)
        {
            Health = 0;
        }
    }

    public void Shoot()
    {
        _ammoCount--;
    }
}