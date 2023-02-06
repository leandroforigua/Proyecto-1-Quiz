using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidoboton : MonoBehaviour
{
	public AudioSource sonidoBoton;
	public AudioClip Boton;
	
    void Start()
    {
	    sonidoBoton.clip = Boton;
	    
    }

    // Update is called once per frame
	public void Reproducir ()
    {
	    sonidoBoton.Play ();
	    
    }
}
