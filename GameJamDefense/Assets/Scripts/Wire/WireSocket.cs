using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSocket : MonoBehaviour
{
    [SerializeField]
    public bool isSocketAttached = false;
    [SerializeField]
    private GameObject attachedConnectingSocket = null;
    public WireConnector ownWireConnector;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.gameObject.tag == "WireConnectingSocket" && !isSocketAttached)
        {
            attachedConnectingSocket = collision.gameObject;
            isSocketAttached = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (attachedConnectingSocket == collision.gameObject && isSocketAttached)
        {
            attachedConnectingSocket = null;
            isSocketAttached = false;
        }
    }

    public GameObject GetObjectAttached()
    {
        return attachedConnectingSocket;
    }

    public void GetEnergy(int amount)
    {
        attachedConnectingSocket.GetComponent<WireConnectingSocket>().GetEnergy(amount);
    }

    public void SendEnergy(int amount)
    {
        if(ownWireConnector.GetCounterSideConnector().GetWireSocket().isSocketAttached)
        {
            ownWireConnector.GetCounterSideConnector().GetWireSocket().GetEnergy(amount);
        }
    }

}
