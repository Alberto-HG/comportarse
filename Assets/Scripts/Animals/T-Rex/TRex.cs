using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TRex : MonoBehaviour {

    public float health;
    public int size;

    [HideInInspector]
    public Collider enemy;

    IStatesTRex state;

    [HideInInspector]
    public TRexStateAttack attackState;
    [HideInInspector]
    public TRexStateEat eatState;
    [HideInInspector]
    public TRexStateSearch searchState;
    [HideInInspector]
    public TRexStateRun runState;
    [HideInInspector]
    public TRexStateWander wanderState;

    [HideInInspector]
    public NavMeshAgent agent;

    void Start() {
        health = 100;
        size = 5;

        attackState = new TRexStateAttack();
        eatState = new TRexStateEat();
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

    private void OnTriggerEnter(Collider col) {
        enemy = col;
        state = searchState;
    }
}