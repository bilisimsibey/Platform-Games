using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class anamenu : MonoBehaviour
{
    public GameObject image; //gameobje türünden image değişkeni tanımlandı
    private void Start()
    {
        image.SetActive(false); //image objesini deaktif yap
    }
    public void basla()
    {
        
        SceneManager.LoadScene("level_01"); //level01 sahnesini yükle
    }
    public void market()
    {
        image.SetActive(true); //image objesini aktif yap
    }
    public void okkey()
    {

        image.SetActive(false); //image objesini kapat
    }
}
