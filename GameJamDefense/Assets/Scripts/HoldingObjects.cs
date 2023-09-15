using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoldingObjects : MonoBehaviour
{
    [Header("Ŭ���� ������Ʈ")]
    public GameObject clickedObject;
    [Header("��� ������Ʈ")]
    public GameObject holdingObject;

    private float holdingTime = 0.0f;
    [SerializeField]
    private float holdTimeNeeded = 1.0f;

    public bool isHoldingObject = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
        }
        if(Input.GetMouseButtonUp(0))
        {
            if (holdingObject != null)
            {
                // holdingObject.GetComponent<> // holdingobject�� hold Ǯ�� �������� �Լ� �ݾ�.
                holdingObject = null;
            }
            clickedObject = null;
            holdingTime = 0;
            isHoldingObject = false;
            
        }

        if(clickedObject != null)
        {
            if(clickedObject.tag == "Rotatable")
            {
                holdingObject = clickedObject;
                isHoldingObject = true;
            }
            else if(clickedObject.tag == "Movable")
            {
                holdingTime += Time.deltaTime;
                if (holdingTime >= holdTimeNeeded)
                {
                    isHoldingObject = true;
                    holdingObject = clickedObject;
                }
            }

        }
        if(holdingObject != null)
        {
            InteractObject();
        }
    }

    private void InteractObject()
    {
        if(holdingObject.tag == "Movable")
        {
            MoveObject();
        }
        if(holdingObject.tag == "Rotatable")
        {
            RotateObject();
        }
    }

    private void MoveObject()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        holdingObject.transform.position = mousePos;

    }

    private void RotateObject()
    {
        // 1. ���� object�� rotation ���ϱ�. v
        // 2. ���� object�߽����� �������� �� mousepos�� rotation ���ϱ�. v
        // 3. ���� object�� 2�� ����������.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 objectMidPos = holdingObject.transform.position;
        Vector2 normVec = (mousePos - objectMidPos).normalized;

        float angle;
        if (normVec.x < 0)
        {
            angle =  360 - (Mathf.Atan2(normVec.x, normVec.y) * Mathf.Rad2Deg * -1);
        }
        else
        {
            angle =  Mathf.Atan2(normVec.x, normVec.y) * Mathf.Rad2Deg;
        }
        Debug.Log(angle);
        holdingObject.transform.rotation = Quaternion.Euler(0, 0, -angle);
    }


    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit.collider != null)
        {
            if(hit.collider.gameObject.tag == "Movable" || hit.collider.gameObject.tag == "Rotatable")
            {
                clickedObject = hit.collider.gameObject;
                Debug.Log(hit.collider.gameObject.name);
            }
            else
            {
                clickedObject = null; // ����.
            }
        }

    }
}
