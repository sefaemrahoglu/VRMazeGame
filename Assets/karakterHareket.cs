using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class karakterHareket : MonoBehaviour
{
    GameObject kamera;
    Vector3 kameraYonu;
    [SerializeField]
    RawImage gpsResim;
    [SerializeField]
    Image finalGosterge;
    float zaman;
    float finalZaman;

    void Start()
    {
        kamera = GameObject.FindGameObjectWithTag("MainCamera");


    }


    void FixedUpdate()
    {
        zaman += Time.deltaTime;
        if (zaman > 250)
        {
            SceneManager.LoadScene("Level1");
            zaman = 0;
        }
        if (kamera.transform.eulerAngles.x >= 18.3f && kamera.transform.eulerAngles.x < 90)
        {
            kameraYonu = (kamera.transform.position - transform.position).normalized;
            kameraYonu.Set(kameraYonu.x, 0, kameraYonu.z);
            transform.position += kameraYonu * Time.deltaTime * 5;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "dusme")
        {
            SceneManager.LoadScene("Level1");
            zaman = 0;
        }
        if (other.tag == "gps")
        {
            gpsResim.gameObject.SetActive(true);
        }

    }
    private void OnTriggerStay(Collider bitis)
    {
        if (bitis.tag == "finish")
        {
            finalZaman += Time.deltaTime;
            finalGosterge.fillAmount += finalZaman / 10;
            if (finalZaman > 10)
            {
                Debug.Log("Bölüm Bitti !!");
            }


        }
    }


    private void OnTriggerExit(Collider other2)
    {
        if (other2.tag == "gps")
        {
            gpsResim.gameObject.SetActive(false);
        }
    }
}
