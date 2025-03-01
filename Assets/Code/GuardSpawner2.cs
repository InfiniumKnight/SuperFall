using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSpawner2 : MonoBehaviour
{

    float timePassed = 0f;
public GameObject prefabGuard;
public Transform guardSpawnTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          timePassed += Time.deltaTime;

           if(timePassed > 15f)
    {
 Instantiate(prefabGuard, guardSpawnTransform.position, Quaternion.identity);
 timePassed = 0f;
    }
}

}