using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float speedMovement;
    [SerializeField] protected float damageAmount;
    [SerializeField] protected float detectRadius;
    [SerializeField] protected float stopDistance;

    protected Player player;

    protected void Start()
    {
        player = FindObjectOfType<Player>();
    }

    protected virtual void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance < detectRadius)
        {
            Movement();

            if(distance < stopDistance)
            {
                Attack();
            }
        }
    }

    protected virtual void Movement()
    {
        Vector3 targetDirection = player.transform.position - transform.position;

        transform.Translate(targetDirection * speedMovement * Time.deltaTime);
    }

    protected virtual void Attack()
    {

    }
}