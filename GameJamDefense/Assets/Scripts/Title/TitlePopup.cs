using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePopup : MonoBehaviour
{
    public float titleMaxY = 50f;
    public float titleMinY = -25f;
    public float timeInterval = 2.0f;
    public float currentTop = 0.0f;
    public bool isGoingUp = true;
    public RectTransform title;
    // Update is called once per frame
    void Update()
    {
        if(isGoingUp)
        {
            currentTop += (titleMaxY - titleMinY) * Time.deltaTime / timeInterval;
            title.offsetMax = new Vector2(title.offsetMax.x, currentTop);
            if(currentTop > titleMaxY)
            {
                isGoingUp = false;
            }
        }
        else
        {
            currentTop -= (titleMaxY - titleMinY) * Time.deltaTime / timeInterval;
            title.offsetMax = new Vector2(title.offsetMax.x, currentTop);
            if (currentTop < titleMinY)
            {
                isGoingUp = true;
            }
        }
        
    }
}
