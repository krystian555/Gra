using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZniszczPrzezGranica : MonoBehaviour {
    private void OnTriggerExit(Collider other)
    {
        Cursor.visible = false; // ukrywamy kursor
        Destroy(other.gameObject);
    }

}
