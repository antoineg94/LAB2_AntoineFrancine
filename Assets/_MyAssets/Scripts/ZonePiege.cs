using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonePiege : MonoBehaviour
{
    // ***** Atributs *****
     
    private bool _estActive = false;  // bool�en qui permet de valider si la zone pi�ge a �t� activ�e
    [SerializeField] private List<GameObject> _listePieges = new List<GameObject>();  // Liste de gameObjects qui contient tous les gameObjects � d�clencher
    private List<Rigidbody> _listeRb = new List<Rigidbody>(); // Liste de rigidbody qui va contenir tous les rigidbody des gameObjects de la liste pr�c�dente
    [SerializeField] private float _intensiteForce = 200;  // Intensit� de la force � appliquer sur les gameObjects

    // ***** M�thode priv�es ****
    
    private void Awake()
    {
        // Pour chacun des gameObjects d�finis je r�cup�re son rigidbory
        // et l'ajoute � la liste contenant ceux-ci
        foreach(var piege in _listePieges)
        {
            _listeRb.Add(piege.GetComponent<Rigidbody>());
        }
    }

    /*
     * M�thode qui est appel�e quand un object entre dans la zone
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !_estActive)  // Si c'est le joueur qui est entr� dans la zone et qu'elle n'a pas �t� activ�e
        {
            // Pour chacun des RB dans la liste j'active leur gravit�
            // et leur applique une force vers le bas
            foreach(var rb in _listeRb)
            {
                rb.useGravity = true;  //active la gravit� sur le rigidbody
                Vector3 direction = new Vector3(0f, -1f, 0f); // �tabli la direction de la force
                rb.AddForce(direction * _intensiteForce); // Applique la force sur le rigidbody
            }
            _estActive = true;  // Marque la zone comme activ�e
        }
    }
}
