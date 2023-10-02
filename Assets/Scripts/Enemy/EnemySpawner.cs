using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemiesPrefabs;
    [SerializeField] private int _enemyCount = 0;
    private float randomPosX;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            randomPosX = Random.Range(-18, 35);
            Instantiate(_enemiesPrefabs[0], new Vector2(randomPosX, transform.position.y), Quaternion.identity);
        }
    }
}