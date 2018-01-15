using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Granica
{   // Prędkość = 10; Xmin = -8.7; Xmax= 8.7; Zmin= -4; Zmax= 12; Przechylenie = 4;
    public float xmin, xmax, zmin, zmax;

}
public class GraczController : MonoBehaviour {

    public float KontrolujPredkosc;
    public Granica granica;
    public float PrzechylStatek;

    public GameObject strzal;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(strzal, shotSpawn.position, shotSpawn.rotation);
            AudioSource a = GetComponent<AudioSource>();
            a.Play();
        }
    }

    private void FixedUpdate()
    {
       string stringH = "Horizontal";
       string stringV = "Vertical";
       float moveHorizontal = Input.GetAxis(stringH);
       float moveVertical = Input.GetAxis(stringV);
       Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
       Rigidbody rb = GetComponent<Rigidbody>();  
       rb.velocity = movement * KontrolujPredkosc;

        rb.position = new Vector3
         (
             Mathf.Clamp(rb.position.x, granica.xmin, granica.xmax),
             0.0f,
             Mathf.Clamp(rb.position.z, granica.zmin, granica.zmax)
         );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -PrzechylStatek);

    }

}
