using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Octopus : MonoBehaviour {
    //Estadisticas
    public int health;
    public bool water;
    public Transform waterTerrain;

    [HideInInspector]
    public Collider enemy;

    //Estado actual
    IStatesOctopus state;

    //Referencias a estados
    [HideInInspector]
    public OctopusStateAttack attackState;
    [HideInInspector]
    public OctopusStateRun runState;
    [HideInInspector]
    public OctopusStateWander wanderState;

    //Agente de pathfinding
    [HideInInspector]
    public NavMeshAgent agent;

    void Start() {
        //Inicializamos tamaño y estadisticas
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * Settings.tamPulpos;

        health = Settings.tamPulpos * 50;
        water = false;

        //Inicializamos los estados
        attackState = new OctopusStateAttack();
        runState = new OctopusStateRun();
        wanderState = new OctopusStateWander();
        state = wanderState;

        //Inicializamos el agente de pathfinding
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        //Comprobamos si esta en el agua
        if (this.transform.position.y <= -4.6) {
            water = true;
        } else {
            water = false;
        }

        //Realizamos el update de nuestro estado y cambiamos la referencia al siguiente
        state = state.Update(this);
    }

    //Funcion que maneja el daño recibido
    public void GetHit(int damage) {
        health -= damage;

        if (health < 1) {
            DestroyImmediate(gameObject);
        }
    }

    //Funcion que maneja la vision
    private void OnTriggerEnter(Collider col) {
        if (enemy == null && (col.gameObject.CompareTag("Gallina") || col.gameObject.CompareTag("TRex") || col.gameObject.CompareTag("Hormiga"))) {
            enemy = col;
            state = attackState;
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