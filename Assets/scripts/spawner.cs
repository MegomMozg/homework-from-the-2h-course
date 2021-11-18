using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemy;
    public int количество = 10;
    private Vector3 whereTosSpawn;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    public void Update()
    {

    }
    void Spawn()
    {
        
        for (int i = 1; i <= количество; i++)
        {
            whereTosSpawn = new Vector3(Random.Range(0f, 0.1f), Random.Range(0.1f, 0.1f), Random.Range(10f, 0.1f));
            Instantiate(enemy, whereTosSpawn, Quaternion.identity);

        }
    }
}
