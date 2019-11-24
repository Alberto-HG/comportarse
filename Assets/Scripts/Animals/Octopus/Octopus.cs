using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Octopus : MonoBehaviour {

    public int health;
    public bool water;
    public Transform waterTerrain;

    [HideInInspector]
    public Collider enemy;

    IStatesOctopus state;

    [HideInInspector]
    public OctopusStateAttack attackState;
    [HideInInspector]
    public OctopusStateRun runState;
    [HideInInspector]
    public OctopusStateWander wanderState;

    [HideInInspector]
    public NavMeshAgent agent;

    void Start() {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * Settings.tamPulpos;

        health = Settings.tamPulpos * 50;
        water = false;

        attackState = new OctopusStateAttack();
        runState = new OctopusStateRun();
        wanderState = new OctopusStateWander();

        state = wanderState;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
        if (this.transform.position.y <= -4.6) {
            water = true;
        } else {
            water = false;
        }
        state = state.Update(this);
    }
    public void GetHit(int damage) {
        health -= damage;

        if (health < 1) {
            DestroyImmediate(gameObject);
        }
    }


    private void OnTriggerEnter(Collider col) {
        if (enemy == null && (col.gameObject.CompareTag("Gallina") || col.gameObject.CompareTag("TRex") || col.gameObject.CompareTag("Hormiga"))) {
            enemy = col;
            state = attackState;
        }
    }

    private void OnCollisionStay(Collision collision) {
        if (!gameObject.CompareTag(collision.collider.tag) && !collision.collider.isTrigger && state == attackState) {
            if (collision.collider.transform == enemy.transform) {
                attackState.colision = true;
            }
        }
    }
}