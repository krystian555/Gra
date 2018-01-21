using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraKontroler : MonoBehaviour
{

    public GameObject hazard;
    public Vector3 spawnValues;
    public int ilosc;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text wyniki;
    private int punkt;
    void Start()
    {
      // wyniki = GetComponent<Text>();
        punkt = 0;
       AktualizujWynik();
        StartCoroutine(SpawnWaves());
        //SpawnWaves();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < ilosc; i++)
            {
               // GameObject hazard;
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
    public void DodajWartosc(int nowaWartosc)
    {
        punkt += nowaWartosc;
        AktualizujWynik();
    }
    void AktualizujWynik()
    { //wyniki = GetComponent<Text>();
        wyniki.text = "Wynik: " + punkt.ToString();
    }

   
}
