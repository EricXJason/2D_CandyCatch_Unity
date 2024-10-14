using System.Collections;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] _candies;
    [SerializeField] 
    private float _maxX = 7.5f;
    [SerializeField] 
    private float _spawnInterval = 1f;

    private bool _canSpawnCandies = true;

    public static CandySpawner Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartSpawningCandies();
    }

    private void SpawnCandy()
    {
        int randomIndex = Random.Range(0, _candies.Length);
        float randomX = Random.Range(-_maxX, _maxX);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);
        Instantiate(_candies[randomIndex], spawnPosition, Quaternion.identity, transform);
    }

    private IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(1f);
        while (_canSpawnCandies)
        {
            SpawnCandy();
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    public void StartSpawningCandies()
    {
        StartCoroutine(SpawnCandies());
    }

    public void StopSpawningCandies()
    {
        _canSpawnCandies = false;
    }
}