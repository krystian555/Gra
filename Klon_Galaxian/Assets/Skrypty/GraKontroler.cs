using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GraKontroler : MonoBehaviour
{

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int ilosc;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text wyniki;
    private int punkt;

    public Text wzowienie;
    public Text zakoncz;
    private bool gameOver;
    private bool restart;

    void Start()
    {
        // wyniki = GetComponent<Text>();
        gameOver = false;
        restart = false;
        wzowienie.text = "";
        zakoncz.text = "";
        punkt = 0;
       AktualizujWynik();
        StartCoroutine(SpawnWaves());
        //SpawnWaves();
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < ilosc; i++)
            {
                // GameObject hazard;
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                wzowienie.text = "Wznów R";
                restart = true;
                break;
            }
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

    public void GameOver()
    {
        zakoncz.text = "Koniec Gry!";
        gameOver = true;
    }


}
