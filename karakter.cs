using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class karakter : MonoBehaviour
{
    public float hiz,maxhiz,ziplamagücü; //float değerinde değişkenler tanımlandı
    public bool yerdemi,ciftzipla,android,sol,sag,yukari; //bool cinsinden değişken tanımlandı (true-false için)
    public Text altinmiktar; //UI text türünde değişken tanımlandı
    public GameObject androidpanel; //gameobje türünde değişken tanımlandı
    
    Rigidbody2D agirlik; //rigidbody türünde değişken tanımlan

    Animator anim; //animator türünde değişken tanımlandı

    public int can, maxcan,altin; //int türünde inspector panelinden kontrol edilebilir değişkenler tanımlandı
    public GameObject[] canlar; //gameobjec türünde dizi oluşturuldu
    public AudioClip[] sesler; //ses türünde ses dizisi oluşturuldu
    float h; //float türünde değişken oluşturuldu
    private void Start()
    {
        agirlik = GetComponent<Rigidbody2D>(); //rigidbody değişkeni için özellik çekildi
        anim = GetComponent<Animator>(); //animator değişkeni için özellik çekildi
        can = maxcan; //can değişkeni maxcan'a eşitlendi
        cansistemi(); //cansistemi fonksiyonu çağrıldı
    }
    private void Update()
    {
        altinmiktar.text = "" +altin; //altınmiktar textine altin değeri yazdırıldı
        if (Input.GetKeyDown(KeyCode.Space)) //space tuşuna basıldığında
        {
            if (yerdemi) //yermedi aktif ise
            {
                Ziplama(); //ziplama fonksiyonunu çağır
                ciftzipla = true; //ciftzipla değişkenini true yap

            }
            else //değilse
            {
                if (ciftzipla) //ciftzipla aktif ise
                {
                    ciftzipla = false; //ciftziplayi false yap
                    agirlik.AddForce(Vector2.up *ziplamagücü/2); //agirlik'a güç ver vector2 türünden yukarıya doğru ziplama çarpı bölü 2 kadar.
                }
            }
                
           
        }

        if (can<=0) //can sıfıra eşitlenirse
        {
            olme(); //olme fonksiyonunu cagır
        }

        if (android) //android aktif ise
        {
            androidpanel.SetActive(true); //androidpaneli aktif et
        }
        else
        {
            androidpanel.SetActive(false); //androidpaneli kapat
        }
    }
    private void OnCollisionEnter2D(Collision2D nesne)
    {
        if (nesne.gameObject.tag=="Tuzak") //nesne objesinin tagı tuzak ise
        {
            can -= Random.Range(1,3); //can değişkenini 1-3 arası azalt
            agirlik.AddForce(Vector2.up * ziplamagücü); //agirlik'a güç ver vector2 türünden yukarıya doğru carpı ziplama gücü kadar.
            GetComponent<SpriteRenderer>().color = Color.red; //nesnemizin rengini kırmızı yap
            Invoke("Duzelt",0.5f); //5 saniye sonra düzelt
            cansistemi(); //cansistemi fonksiyonunu cagır
        }

    }
    private void FixedUpdate()
    {
       

        anim.SetFloat("Hiz", Mathf.Abs(h)); //animatorden kontrol ve esitleme , artı eksi dönüstürmek için mathf.abs kullanıldı 
        anim.SetBool("Yerde", yerdemi); //animatorden kontrol ve esitleme
        
        if (android) //android aktif ise
        {
            if (sol) //sol değişkeni aktif ise
            {
                h = -1; //h değişkeni -1 değerini alsın
                transform.localScale = new Vector3(-1, 1, 1); //sola doğru hareket 
                transform.Translate(h * hiz * Time.deltaTime, 0, 0); //x yönünden hiz kadar hareket
             
            }
            if (sag) //sag değişkeni aktif ise
            {
                h = 1; //h değişkeni 1 değerini alsın
                transform.localScale = new Vector3(1, 1,1); //sağa doğru hareket
                transform.Translate(h * hiz * Time.deltaTime, 0, 0); //x yönünden hiz kadar hareket
                
            }
            if (!sol && !sag) //sol ve sag değişkeni aktif değil ise
            {
                h = 0; //h değişkeni sıfır değerini alsın
            }

        }
        else
        {
             h = Input.GetAxis("Horizontal"); //sağa sola hareket girişi
            if (h > 0) //h büyük ise sıfırdan
            {
                transform.localScale = new Vector3(1, 1, 1); //sağa doğru hareket
            }
            if (h < 0) //h kücük ise sıfırdan
            {
                transform.localScale = new Vector3(-1, 1, 1); //sola doğru hareket
            }
        }
        

        //agirlik.AddForce(Vector3.right * h * hiz); //agirlik'a güc verdik, vector3 türünde sağa doğru yatay düzlemde hiz kadar

        

        if (h>0.1) //yatay düzlemde sağa doğru büyük ise
        {
            transform.Translate(h * hiz * Time.deltaTime, 0, 0);
        }
        if (h<-0.1) //yatay düzlemde sola doğru büyük ise
        {
            transform.Translate(h * hiz * Time.deltaTime, 0, 0);
        }
        if (agirlik.velocity.x>maxhiz) //agirlik'in hizi yatay düzlemde, maximum hizdan büyük ise
        {
            agirlik.velocity = new Vector2(maxhiz, agirlik.velocity.y); //x'i maxhiz'a eşitle y tarafı oldugu gibi kalsın

        }
        if (agirlik.velocity.x < -maxhiz) //agirlik'in hizi yatay düzlemde, maximum eksi hizdan kücük ise
        {
            agirlik.velocity = new Vector2(-maxhiz, agirlik.velocity.y); //x'i maxhiz'a eşitle y tarafı oldugu gibi kalsın
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="olme") //değen objenin tagı olme ise
        {
            olme(); //olme fonksiyonunu cagır
        }
        
        if (other.gameObject.tag=="Gold") //değen objenin tagı gold ise
        {
            altin++; //altın değişkenini 1 arttır
            GetComponent<AudioSource>().PlayOneShot(sesler[0]); //eklenen ses componentini calıstır
            Destroy(other.gameObject); //degen objeyi yok et
        }
        if (other.gameObject.tag=="Can") //değen objenin tagı can ise
        {
            if (can!=maxcan) //can, maxcan'a eşit değil ise
            {
                can++; //can'ı 1 arttır
                cansistemi(); //cansistemi fonksiyonunu cagır
                GetComponent<SpriteRenderer>().color = Color.green; //nesnemizin rengini yeşil yap
                Invoke("Duzelt", 0.5f); //5 saniye sonra düzelt
                Destroy(other.gameObject); //değen objeyi yok et
            }
            
            
        }
        if (other.gameObject.tag=="Door") //değen objenin tagı door ise
        {
            
            SceneManager.LoadScene("level_02"); //2. levele geç

        } 
        if (other.gameObject.tag=="Door2") //değen objenin tagı door2 ise
        {
            SceneManager.LoadScene("level_03"); //3. levele geç
        }
    }
    void olme()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //aktif olan sahneyi yeniden yükle
    }
    void cansistemi()
    {
        for (int i = 0; i < maxcan; i++)
        {
            canlar[i].SetActive(false); //i değeri kadar canları false yap
        }
        for (int i = 0; i < can; i++)
        {
            canlar[i].SetActive(true); //i değeri kadar canları true yap
        }


    }
    void Duzelt()
    {

        GetComponent<SpriteRenderer>().color = Color.white; //nesne rengini beyaz yap

    }
    public void Ziplama()
    {

        agirlik.AddForce(Vector2.up * ziplamagücü); //zıplamaya yarar

    }
    public void buttonziplama()
    {
         
        if (yerdemi) //yerdemi true ise
        {
            Ziplama(); //zıplama fonksiyonunu cagır
            ciftzipla = true; //ciftzıpla true dödnür

        }
        else
        {
            if (ciftzipla) //ciftzipla true ise
            {
                ciftzipla = false; //ciftziplayı false yap
                agirlik.AddForce(Vector2.up * ziplamagücü / 2); //zıplamagücünün yarısı kadar zıplat
            }
        }

    }
}
