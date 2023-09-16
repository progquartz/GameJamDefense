using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerModuleWireEnd : MonoBehaviour
{
    [SerializeField]
    private Transform powerModule;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > -10.0f)
        {
            transform.position = new Vector3(-10f, transform.position.y, transform.position.z);
        }
        if(Mathf.Abs( transform.position.y - powerModule.position.y) > 0.2f)
        {
            transform.position = new Vector3(-10f, Mathf.Lerp(transform.position.y, powerModule.position.y, Time.deltaTime * 2f ) , 0);
        }
        transform.LookAt(powerModule);
    }
}
