using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireConnector : MonoBehaviour
{
    private WireSocket wireSocket;
    [SerializeField]
    private GameObject counterSideConnector;
    public bool isBeingHolded = false;
    // Start is called before the first frame update
    void Start()
    {
        wireSocket = GetComponentInChildren<WireSocket>();
        wireSocket.ownWireConnector = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!wireSocket.isSocketAttached)
        {
            Vector3 look = transform.InverseTransformPoint(counterSideConnector.transform.position);
            float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;

            transform.Rotate(0, 0, angle);
        }
        else if(!isBeingHolded)
        {
            this.transform.position = wireSocket.GetObjectAttached().GetComponent<WireConnectingSocket>().GetConnectorPosition().position;
            Vector3 rot = wireSocket.GetObjectAttached().GetComponent<WireConnectingSocket>().GetConnectorPosition().rotation.eulerAngles;
            Vector3 newRot = new Vector3(rot.x, rot.y, rot.z + 180);

            this.transform.rotation = Quaternion.Euler( newRot);
        }
    }

    public bool IsConnectorConnected()
    {
        return wireSocket.isSocketAttached;
    }

    public WireConnector GetCounterSideConnector()
    {
        return counterSideConnector.GetComponent<WireConnector>();
    }

    public WireSocket GetWireSocket()
    {
        Debug.Log("WireConnectorGetWireSocket");
        return wireSocket;
    }

    
    public void UnholdFromMouse()
    {
        isBeingHolded = false;
    }
}
