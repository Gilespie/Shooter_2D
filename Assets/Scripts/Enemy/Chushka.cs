using UnityEngine;

public class Chushka : Enemy, IDamageable
{
    public float Health { get; set; }

    private new void Start()
    {
        base.Start();
        Health = base.health;   
    }

    public void Damage(float damage)
    {
        if (damage <= 0 || Health <= 0) return;

        Health -= damage;

        if(Health <= 0)
        {
            Health = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}