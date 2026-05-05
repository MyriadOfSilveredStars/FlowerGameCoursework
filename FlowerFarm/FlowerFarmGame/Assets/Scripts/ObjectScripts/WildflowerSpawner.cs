using UnityEngine;

public class WildflowerSpawner : MonoBehaviour
{
    public GameObject wildflower;
    public int numFlowers = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < numFlowers; i++)
        {
            SpawnFlower();
        }
    }

    public void SpawnFlower()
    {
        int spawnPointX = Random.Range(367,814);
        int spawnPointY = Random.Range(100,150);
        int spawnPointZ = Random.Range(231,649);

        Vector3 spawnPoints = new Vector3(spawnPointX, spawnPointY, spawnPointZ);

        Instantiate(wildflower, spawnPoints, Quaternion.identity);
    }
}
