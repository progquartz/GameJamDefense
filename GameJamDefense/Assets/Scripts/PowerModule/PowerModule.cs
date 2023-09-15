using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerModule : MonoBehaviour
{
    private float currentpowerInputTime = 0.0f;
    private int amountEachConnector = 1;
    private List<WireConnectingSocket> wireConnectingSockets = new List<WireConnectingSocket>();

    private float powerInputInterval = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Transform socketParent = transform.Find("Sockets");
        for(int i = 0; i < socketParent.childCount; i++)
        {
            wireConnectingSockets.Add(socketParent.GetChild(i).GetComponent<WireConnectingSocket>());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        currentpowerInputTime += Time.deltaTime;
        if(currentpowerInputTime >= powerInputInterval)
        {
            PutEnergyTime();
            currentpowerInputTime = 0;
        }
    }

    public void PutEnergyTime()
    {
        for(int i = 0; i < wireConnectingSockets.Count; i++)
        {
            
            if(wireConnectingSockets[i].isSocketAttached)
            {
                wireConnectingSockets[i].SendEnergy(amountEachConnector);
            }
        }
    }
}
