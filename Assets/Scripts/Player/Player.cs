using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health = 100f;
    [SerializeField] private int _ammoCount = 30;
    [SerializeField] private string _nickName;
    [SerializeField] private LivesInfo _livesBar;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;

    private float _detectRadius = 6f;
    private PlayerAnimation _playerAnimation;
    private Chushka _enemy;

    public float Health { get; set; }

    private void Start()
    {
        _playerAnimation = GetComponentInChildren<PlayerAnimation>();
        _enemy = GameObject.Find("Bug").GetComponent<Chushka>();

        Health = _health;
        _livesBar.UpdateLives(Health, _health);
        _livesBar.UpdatePersonInfo(_nickName, 1);
        UIManager.Instance.UpdateAmmo(_ammoCount);
    }

    private void Update()
    {
        ReadyToAttack();
    }

    public void GetDamage(float damage)
    {
        if (damage <= 0 || Health <= 0) return;

        Health -= damage;
        _livesBar.UpdateLives(Health, _health);

        if (Health <= 0)
        {
            Health = 0;
        }
    }

    public void Shoot()
    {
        if(_ammoCount <= 0) return;

        _ammoCount--;
        UIManager.Instance.UpdateAmmo(_ammoCount);

        Instantiate(_bulletPrefab, _shootPoint.position, _bulletPrefab.transform.rotation);
    }

    private void ReadyToAttack()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, _detectRadius, Vector2.one);

        if(hit.collider != null)
        {
            _enemy = hit.collider.GetComponent<Chushka>();

            if(_enemy != null)
            {
                float distance = Vector3.Distance(transform.position, _enemy.transform.position);

                if (distance <= _detectRadius)
                {
                    _playerAnimation.ChangeIdleToAttack();
                }
                else if (distance > _detectRadius && _enemy != null)
                {
                    _playerAnimation.ChangeIdleToStand();
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _detectRadius);
    }
}