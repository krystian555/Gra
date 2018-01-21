using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZniszczPrzezKontakt : MonoBehaviour {

    public GameObject eksplozja;
    public GameObject eksplozjaGracza;
    public int wynik;
    private GraKontroler graKontroler;

    private void Start()
    {
        GameObject graKontolerObjekt = GameObject.FindWithTag("GraKontroler");
        if(graKontolerObjekt != null)
        {
            graKontroler = graKontolerObjekt.GetComponent<GraKontroler>();
        }
        else
        {
            Debug.Log(" Nie mogę znaleźć GraKontroler skrypt");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Granica")
        {
            return;
        }
        Instantiate(eksplozja, transform.position, transform.rotation);

        if (other.tag == "Gracz")
        {
            Instantiate(eksplozjaGracza, other.transform.position, other.transform.rotation);
            graKontroler.GameOver();
        }
       graKontroler.DodajWartosc(wynik);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
