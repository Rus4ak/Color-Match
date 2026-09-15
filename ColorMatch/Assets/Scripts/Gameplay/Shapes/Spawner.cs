using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;

    private float _spawnRate;
    private float _shapeFallSpeed;
    private BoxCollider _spawnZone;

    public void Initialize(float spawnRate, float shapeFallSpeed)
    {
        _spawnRate = spawnRate;
        _shapeFallSpeed = shapeFallSpeed;
    }

    private void Awake()
    {
        _spawnZone = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnRate);

            Vector3 randomPos = GetRandomPoint();
            int randomIndex = Random.Range(0, _prefabs.Length);

            GameObject shape = Instantiate(_prefabs[randomIndex], randomPos, 
                _prefabs[randomIndex].transform.rotation);

            shape.GetComponent<ShapeMovement>().Initialize(_shapeFallSpeed);
        }
    }

    private Vector3 GetRandomPoint()
    {
        float randomX = Random.Range(-_spawnZone.size.x / 2, _spawnZone.size.x / 2);
        float y = transform.position.y;

        Vector3 position = _spawnZone.transform.TransformPoint(
            new Vector3(randomX, 0f, 0f));

        return position;
    }
}
