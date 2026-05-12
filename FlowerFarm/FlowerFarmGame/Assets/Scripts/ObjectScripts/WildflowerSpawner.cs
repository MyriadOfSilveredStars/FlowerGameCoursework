using UnityEngine;

public class WildflowerSpawner : MonoBehaviour
{
    public GameObject wildflower; //the prefab to spawn in
    public int numFlowers = 100; //the number to spawn in
    
    void Start()
    {
        for (int i = 0; i < numFlowers; i++) //run the spawner the set amount of times
        {
            SpawnFlower();
        }
    }

    public void SpawnFlower() //spawns the flowers
    {
        int spawnPointX = Random.Range(367,814); //gets the x, y, and z points
        int spawnPointY = Random.Range(100,150); //for the flower spawns
        int spawnPointZ = Random.Range(231,649); //these are spread across the map

        Vector3 spawnPoints = new Vector3(spawnPointX, spawnPointY, spawnPointZ); //creates a spawn vector

        Instantiate(wildflower, spawnPoints, Quaternion.identity); //creates a new instance of the wildflower
    }
}
