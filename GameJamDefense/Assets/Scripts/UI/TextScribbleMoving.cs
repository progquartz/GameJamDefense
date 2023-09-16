using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScribbleMoving : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI font;
    public int frame = 10;
    private int realframe = 0;
    private bool isReverse = true;
    // Start is called before the first frame update
    void Start()
    {
        font = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        realframe++;
        if(realframe >= frame)
        {
            realframe = 0;
            if(isReverse)
            {
                
                GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(-3.0f, 5.0f)));
            }
            else
            {
                GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(3, -5.0f)));
            }
            isReverse = !isReverse;
        }
    }
}
