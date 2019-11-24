using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Clase que implementa al Trex
public class TRex : MonoBehaviour {
    //Estadisticas
    public int health;
    public int grouped;

    [HideInInspector]
    public Collider enemy;

    //Estado actual
    IStatesTRex state;

    //Referencias a estados
    [HideInInspector]
    public TRexStateAttack attackState;
    [HideInInspector]
    public TRexStateSearch searchState;
    [HideInInspector]
    public TRexStateRun runState;
    [HideInInspector]
    public TRexStateWander wanderState;

    //Agente de pathfinding
    [HideInInspector]
    public NavMeshAgent agent;

    void Start() {
        //Inicializamos tamaño y estadisticas
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * Settings.tamTrex;

        health = Settings.tamTrex * 50;
        grouped = 0;

        //Inicializamos los estados
        attackState = new TRexStateAttack();
        searchState = new TRexStateSearch();
        runState = new TRexStateRun();
        wanderState = new TRexStateWander();
        state = wanderState;

        //Inicializamos el agente de pathfinding
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        //Realizamos el update de nuestro estado y cambiamos la referencia al siguiente
        state = state.Update(this);
    }

    //Funcion que maneja el daño recibido
    public void GetHit (int damage) {
        health -= damage;

        if (health < 1) {
            DestroyImmediate(gameObject);
        }
    }

    //Funciones que maneja la vision
    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag(gameObject.tag)) {
            if (col.gameObject != gameObject) {
                grouped++;
            }
        } else if (enemy == null && (col.gameObject.CompareTag("Pulpo") || col.gameObject.CompareTag("TRex") || col.gameObject.CompareTag("Hormiga"))) {
            enemy = col;
            state = searchState;
        }
    }

    private void OnTriggerExit(Collider col) {
        if (col.gameObject.CompareTag(gameObject.tag)) {
            grouped--;
        }
    }

    //Funcion que maneja la colision
    private void OnCollisionStay(Collision collision) {
        if (!gameObject.CompareTag(collision.collider.tag) && !collision.collider.isTrigger && state == attackState) {
            if (collision.collider.transform == enemy.transform) {
                attackState.colision = true;
            }
        }
    }
}