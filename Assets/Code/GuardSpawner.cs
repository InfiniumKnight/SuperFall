using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSpawner : MonoBehaviour
{

    float timePassed = 0f;
public GameObject prefabGuard;
public Transform guardSpawnTransform;

    // Start is called before the first frame update
    void Start()
    {
          Instantiate(prefabGuard, guardSpawnTransform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
          timePassed += Time.deltaTime;

           if(timePassed > 30f)
    {
 Instantiate(prefabGuard, guardSpawnTransform.position, Quaternion.identity);
 timePassed = 0f;
    }
}

}