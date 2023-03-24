using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MouvementVasEtViens : MonoBehaviour
{
    //variables
    [SerializeField] float distance;
    [SerializeField] float vitesse;
    
    private Vector3 PositionDebut; void Start()
    {
        PositionDebut = transform.position;
    }     // Update is called once per frame
    void Update()
    {
        Vector3 v = PositionDebut;
        v.x += distance * Mathf.Sin(Time.time * vitesse);
        transform.position = v;
    }
}