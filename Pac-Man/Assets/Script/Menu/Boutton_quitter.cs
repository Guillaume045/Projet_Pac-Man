using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boutton_quitter : MonoBehaviour
{
    public Button votreBouton;

    void Start()
    {
        votreBouton.onClick.AddListener(TaskOnClick);
    }

    void Update()
    {

    }

    void TaskOnClick()
    {
        //Debug.Log("Le bouton a été cliqué"); 
        Application.Quit();
        Debug.Log("Vous avez quitté le jeu");
    }
}
