using UnityEngine;

public class Chushka : Enemy, IDamageable
{
    [SerializeField] private LivesInfo _livesBar;
    public float Health { get; set; }

    private new void Start()
    {
        base.Start();
        Health = base.health;
        _livesBar.UpdateLives(Health, health);
        _livesBar.UpdatePersonInfo(nickName, level);
    }

    public void GetDamage(float damage)
    {
        if (damage <= 0 || Health <= 0) return;

        Health -= damage;
        _livesBar.UpdateLives(Health, health);

        if (Health <= 0)
        {
            SpawnDrop();
            Health = 0;
            Death();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}