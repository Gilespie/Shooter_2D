using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float speedMovement;
    [SerializeField] protected float damageAmount;
    [SerializeField] protected float detectRadius;
    [SerializeField] protected float stopDistance;
    [SerializeField] protected string nickName;
    [SerializeField] protected int level;
    [SerializeField] protected GameObject[] _dropPrefabs;

    protected int randomIndex;
    protected Player player;

    protected void Start()
    {
        player = FindObjectOfType<Player>();
    }

    protected virtual void Update()
    {
        MovementToTarget();
    }

    protected virtual void MovementToTarget()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < detectRadius)
        {
            if (distance > stopDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedMovement * Time.deltaTime);
            }
            else
            {
                Attack();
            }
        }
    }

    protected virtual void Attack()
    {

    }

    protected virtual void Death()
    {
        Destroy(gameObject, 0.2f);
    }

    protected virtual void SpawnDrop()
    {
        if (_dropPrefabs.Length <= 0) return;

        randomIndex = Random.Range(0, _dropPrefabs.Length);

        Instantiate(_dropPrefabs[randomIndex], transform.position, Quaternion.identity);
    }
}