using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TRex : MonoBehaviour {

    public int health;
    public int grouped;

    [HideInInspector]
    public Collider enemy;

    IStatesTRex state;

    [HideInInspector]
    public TRexStateAttack attackState;
    [HideInInspector]
    public TRexStateSearch searchState;
    [HideInInspector]
    public TRexStateRun runState;
    [HideInInspector]
    public TRexStateWander wanderState;

    [HideInInspector]
    public NavMeshAgent agent;

    void Start() {
        health = Settings.tamTrex * 50;
        grouped = 0;

        attackState = new TRexStateAttack();
        searchState = new TRexStateSearch();
        runState = new TRexStateRun();
        wanderState = new TRexStateWander();

        state = wanderState;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
        state = state.Update(this);
    }

    public void GetHit (int damage) {
        health -= damage;

        if (health < 0) {
            DestroyImmediate(gameObject);
        }
    }

    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag(gameObject.tag)) {
            grouped++;
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
}