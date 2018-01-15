using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZniszczPrzezKontakt : MonoBehaviour {

    public GameObject eksplozja;
    public GameObject eksplozjaGracza;

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
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
