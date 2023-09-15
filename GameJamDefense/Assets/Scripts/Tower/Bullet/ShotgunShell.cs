using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShell : MonoBehaviour
{
    public GameObject[] bullets;
    public Transform bulletParent;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < bullets.Length; i++)
        {
            bullets[i].transform.SetParent(bulletParent);
        }
        Destroy(this.gameObject);
    }
}
