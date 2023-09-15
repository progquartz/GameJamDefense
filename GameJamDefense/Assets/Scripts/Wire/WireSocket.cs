using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSocket : MonoBehaviour
{
    [SerializeField]
    public bool isSocketAttached = false;
    [SerializeField]
    private GameObject attachedObject = null;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if ((collision.gameObject.tag == "TowerAttackBase" && this.gameObject.tag == "TowerBase") || (collision.gameObject.tag == "TowerBase" && this.gameObject.tag == "TowerAttackBase") && !isSocketAttached)
        {
            attachedObject = collision.gameObject;
            isSocketAttached = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (attachedObject == collision.gameObject)
        {
            attachedObject = null;
            isSocketAttached = false;
        }
    }

    public GameObject GetObjectAttached()
    {
        return attachedObject;
    }
}
