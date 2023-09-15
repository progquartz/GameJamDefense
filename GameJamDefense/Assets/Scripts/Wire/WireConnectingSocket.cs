using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ParentModuleType
{
    TOWERBASEMODULE,
    POWERMODULE,
    MULTIPLIERMODULE
}
public class WireConnectingSocket : MonoBehaviour
{
    [SerializeField]
    public bool isSocketAttached = false;
    [SerializeField]
    private GameObject attachedSocket = null;
    private GameObject ownParentModule = null;
    private ParentModuleType parentModuleType;


    private void Start()
    {
        ownParentModule = transform.parent.parent.gameObject;
        switch (ownParentModule.name)
        {
            case "TowerBaseModule":
                parentModuleType = ParentModuleType.TOWERBASEMODULE;
                break;
            case "PowerModule":
                parentModuleType = ParentModuleType.POWERMODULE;
                break;
        }
    }

    public Transform GetConnectorPosition()
    {
        return this.transform.GetChild(0).GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WireSocket" && !isSocketAttached)
        {
            attachedSocket = collision.gameObject;
            isSocketAttached = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (attachedSocket == collision.gameObject)
        {
            attachedSocket = null;
            isSocketAttached = false;
        }
    }

    public GameObject GetObjectAttached()
    {
        return attachedSocket;
    }

    public void SendEnergy(int amount)
    {
        attachedSocket.GetComponent<WireSocket>().SendEnergy(amount);
    }

    public void GetEnergy(int amount)
    {
        if(parentModuleType == ParentModuleType.TOWERBASEMODULE)
        {
            ownParentModule.GetComponent<TowerBase>().GetEnergy(amount);
        }
    }
}
