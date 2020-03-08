using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour
{
    public GameObject rainDrop;
    public int dropsPerSecond;
    private float leftSpawnBound = -30f;
    private float rightSpawnBound = 30f;
    private float minSpawnHeight = 30f;
    private float maxSpawnHeight = 40f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RenderDrops", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void RenderDrops()
    {
        for (int i = 0; i < dropsPerSecond; i++)
        {
            Vector3 position = new Vector3(Random.Range(leftSpawnBound, rightSpawnBound), Random.Range(minSpawnHeight, maxSpawnHeight), 5);
            Instantiate(rainDrop, position, Quaternion.identity);
        }
    }
}
