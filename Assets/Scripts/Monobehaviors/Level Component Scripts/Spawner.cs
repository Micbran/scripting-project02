using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnpoints = null;
    [SerializeField] private GameObject[] prefabsToSpawn = null;
    [SerializeField] private float startDelay = 0f;
    [SerializeField] private float tickRate = 0.5f;

    private bool spawned = false;
    private GameObject spawnedObject = null;

    private void Start()
    {
        InvokeRepeating(nameof(Tick), startDelay, tickRate);
    }

    private void Tick()
    {
        spawned = spawnedObject != null;

        if(spawned)
            return;

        Transform randomTransform = SelectRandomSpawnpoint();
        GameObject randomGameObject = SelectRandomPrefab();
        spawnedObject = Instantiate(randomGameObject, randomTransform.position, randomTransform.rotation);
    }

    private Transform SelectRandomSpawnpoint()
    {
        return spawnpoints[Random.Range(0, spawnpoints.Length)];
    }

    private GameObject SelectRandomPrefab()
    {
        return prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];
    }

}
