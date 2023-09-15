using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireConnector : MonoBehaviour
{
    private WireSocket wireSocket;
    [SerializeField]
    private Transform counterSideConnector;
    // Start is called before the first frame update
    void Start()
    {
        wireSocket = GetComponentInChildren<WireSocket>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!wireSocket.isSocketAttached)
        {
            Vector3 look = transform.InverseTransformPoint(counterSideConnector.transform.position);
            float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg + 180;

            transform.Rotate(0, 0, angle);
        }
    }

    public void UnholdFromMouse()
    {
        if(wireSocket.isSocketAttached)
        {
            this.transform.position = wireSocket.GetObjectAttached().GetComponent<WireConnectingSocket>().GetConnectorPosition().position;
            this.transform.rotation = wireSocket.GetObjectAttached().GetComponent<WireConnectingSocket>().GetConnectorPosition().rotation;
        }
    }
}
