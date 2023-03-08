using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinPartie : MonoBehaviour
{
    // ***** Attributs *****
    
    private bool _finPartie = false;  // bool�en qui d�termine si la partie est termin�e
    private GestionJeu _gestionJeu; // attribut qui contient un objet de type GestionJeu
    private Player _player;  // attribut qui contient un objet de type Player

    // ***** M�thode priv�es  *****
    
    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();  // r�cup�re sur la sc�ne le gameObject de type GestionJeu
        _player = FindObjectOfType<Player>();  // r�cup�re sur la sc�ne le gameObject de type Player
    }

    /*
     * M�thode qui se produit quand il y a collision avec le gameObject de fin
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !_finPartie)  // Si la collision est produite avec le joueur et la partie n'est pas termin�e
        {
            
            _finPartie = true; // met le bool�en � vrai pour indiquer la fin de la partie
            int noScene = SceneManager.GetActiveScene().buildIndex; // R�cup�re l'index de la sc�ne en cours
            if (noScene == (SceneManager.sceneCountInBuildSettings - 1))  // Si nous somme sur la derni�re sc�ne
            {
                int accrochages = _gestionJeu.GetPointage();  // R�cup�re le pointage total dans gestion jeu
                float tempsTotalniv1 = _gestionJeu.GetTempsNiv1() + _gestionJeu.GetAccrochagesNiv1();  //Calcul le temps total pour le niveau 1
                float _tempsNiveau2 = Time.time - _gestionJeu.GetTempsNiv1(); // Calcul le temps pour le niveau 2
                int _accrochagesNiveau2 = _gestionJeu.GetPointage() - _gestionJeu.GetAccrochagesNiv1(); // Calcul le nombre d'accrochages pour le niveau 2
                float tempsTotalniv2 = _tempsNiveau2 + _accrochagesNiveau2; // Calcul le temps total pour le niveau 2
                float _tempsNiveau3 = Time.time - _gestionJeu.GetTempsNiv1() - _gestionJeu.GetTempsNiv2(); // Calcul le temps pour le niveau 3
                int _accrochagesNiveau3 = _gestionJeu.GetPointage() - _gestionJeu.GetAccrochagesNiv1() - _gestionJeu.GetAccrochagesNiv2(); // Calcul le nombre d'accrochages pour le niveau 3
                float tempsTotalniv3 = _tempsNiveau3 + _accrochagesNiveau3; // Calcul le temps total pour le niveau 3


                // Affichage des r�sultats finaux dans la console
                Debug.Log("**** Fin de partie ****");
                Debug.Log("Le temps pour le niveau 1 est de : " + _gestionJeu.GetTempsNiv1().ToString("f2") + " secondes");
                Debug.Log("Vous avez accroch� au niveau 1 : " + _gestionJeu.GetAccrochagesNiv1() + " obstacles");
                Debug.Log("Temps total niveau 1 : " + tempsTotalniv1.ToString("f2") + " secondes");

                Debug.Log("Le temps pour le niveau 2 est de : " + _tempsNiveau2.ToString("f2") + " secondes");
                Debug.Log("Vous avez accroch� au niveau 2 : " + _accrochagesNiveau2 + " obstacles");
                Debug.Log("Temps total niveau 2 : " + tempsTotalniv2.ToString("f2") + " secondes");

                Debug.Log("Le temps pour le niveau 3 est de : " + _gestionJeu.GetTempsNiv3().ToString("f2") + " secondes");
                Debug.Log("Vous avez accroché au niveau 3 : " + _gestionJeu.GetAccrochagesNiv3() + " obstacles");
                Debug.Log("Temps total niveau 3 : " + tempsTotalniv3.ToString("f2") + " secondes");

                Debug.Log("Le temps total des trois niveaux est de : " + (tempsTotalniv1 + tempsTotalniv2 + tempsTotalniv3).ToString("f2") + " secondes");
               
                
               

                _player.finPartieJoueur();  // Appeler la m�thode publique dans Player pour d�sactiver le joueur
            }
            else
            {
                // Appelle la m�thode publique dans gestion jeu pour conserver les informations du niveau 1
                _gestionJeu.SetNiveau1(_gestionJeu.GetPointage(), Time.time);
                // Charge la sc�ne suivante
                SceneManager.LoadScene(noScene + 1);            
            }
        }
    }
}
