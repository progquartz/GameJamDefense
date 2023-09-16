using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSocket : MonoBehaviour
{
    [SerializeField]
    public bool isSocketAttached = false;
    public bool checkSum = false;
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
            StartCoroutine(LightupWire());
            ownWireConnector.GetCounterSideConnector().GetWireSocket().GetEnergy(amount);
        }
    }

    IEnumerator LightupWire()
    {
        transform.parent.parent.GetComponent<LineRenderer>().startColor = new Color(0.6f, 0.6f, 0.2f);
        transform.parent.parent.GetComponent<LineRenderer>().endColor = new Color(0.6f, 0.6f, 0.2f);

        yield return new WaitForSeconds(0.2f);

        transform.parent.parent.GetComponent<LineRenderer>().startColor = new Color(0.4f, 0.45f, 0.15f);
        transform.parent.parent.GetComponent<LineRenderer>().endColor = new Color(0.4f, 0.45f, 0.15f);

        yield return null;
    }


}
