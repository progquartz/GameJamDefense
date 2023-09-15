using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireConnectingSocket : MonoBehaviour
{
    [SerializeField]
    public bool isSocketAttached = false;
    [SerializeField]
    private GameObject attachedObject = null;

    public Transform GetConnectorPosition()
    {
        return this.transform.GetChild(0).GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "WireSocket" && !isSocketAttached)
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
