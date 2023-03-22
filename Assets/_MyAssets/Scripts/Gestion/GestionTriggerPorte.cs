using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GestionTriggerPorte : MonoBehaviour
{
    // variables
    public GameObject ObjetDesactiver1;
    public GameObject ObjetDesactiver2;
    public GameObject ObjetActiver;
    
    private void OnTriggerEnter(Collider other)
    {
        ObjetDesactiver1.SetActive(false);//désactive la potion
        ObjetDesactiver2.SetActive(false);//désactive égalemnt la fumée
        ObjetActiver.transform.localEulerAngles = new Vector3(0, 0, 0);// tourne la porte d'un angle de 0 dégré ce qui va l'ouvrir
    }
}
