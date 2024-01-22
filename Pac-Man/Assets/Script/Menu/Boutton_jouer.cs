using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boutton_jouer : MonoBehaviour
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
        SceneManager.LoadScene(1);
        Debug.Log("Vous aller en jeu");
    }
}
