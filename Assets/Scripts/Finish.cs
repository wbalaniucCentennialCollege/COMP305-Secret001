using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

    public GameObject canvas;

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canvas.SetActive(true);
        }
    }
}
