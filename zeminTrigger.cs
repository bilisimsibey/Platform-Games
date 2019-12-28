using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zeminTrigger : MonoBehaviour
{
    karakter kr;

    private void Start()
    {
        kr = transform.root.gameObject.GetComponent<karakter>(); //karakteri bulmak için root kullanıldı

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        kr.yerdemi = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        kr.yerdemi = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        kr.yerdemi = false;
    }
}
