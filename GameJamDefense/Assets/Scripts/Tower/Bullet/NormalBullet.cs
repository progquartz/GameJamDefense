using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    [SerializeField]
    private int damage = 3;
    [SerializeField]
    private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1,0,0) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyTargetingAndMoving a = collision.gameObject.GetComponent<EnemyTargetingAndMoving>();
            if(a != null)
            {
                a.GetDamage(damage);
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }

        }

    }


}
