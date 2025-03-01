using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilBulletController : MonoBehaviour
{

  public float lifeTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

          if(lifeTime < 0) {
            Destroy(gameObject);
          }
    }

    void OnTriggerEnter(Collider other)
    {
            other.gameObject.GetComponent<HealthBar>().TakeDamage();
            Destroy(gameObject);

        
    }
}
