using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAgent : MonoBehaviour
{
    public GameObject targetGameObject;
    [SerializeField]
    private GameObject spawnAgent;
    private int spawncounter = 0;
    private bool isTriggered = false;

    private Vector3 RandomRangePos()
    {
        float randomx = Random.Range(-6.0f, 4.5f);
        float randomy = Random.Range(-4.0f, 4.0f);
        return new Vector3(randomx, randomy, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject.tag == "TowerAttackBase")
            || (collision.gameObject.tag == "WireSocket") 
            || (collision.gameObject.tag == "TowerBase") 
            || (collision.gameObject.tag == "Power"))
        {
            Debug.Log("겹친다아아아!");
            isTriggered = true;
            spawncounter++;
            this.transform.position = RandomRangePos();
            if(spawncounter >= 100000)
            {
                Debug.Log("난 죽음을 택하겠다.");
                Destroy(this.gameObject);
            }
        }
    }

    private void Update()
    {
        if(!isTriggered)
        {
            Instantiate(targetGameObject, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void LateUpdate()
    {
        if(isTriggered)
        {
            isTriggered = false;
        }
    }
}
