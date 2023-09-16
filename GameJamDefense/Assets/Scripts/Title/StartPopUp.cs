using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPopUp : MonoBehaviour
{

    public float delayTime = 0.5f;
    public float upTime = 0.5f;
    public RectTransform popup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delayTime -= Time.deltaTime;
        if(delayTime <= 0)
        {
            popup.transform.Translate((new Vector3(960, 540, 0) - popup.transform.position) * Time.deltaTime / upTime);
        }
    }
}
