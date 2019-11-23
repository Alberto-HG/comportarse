using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Octopus : MonoBehaviour {

    public float health;
    public int size;
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
        health = 100;
        size = 2;
        water = false;

        attackState = new OctopusStateAttack();
        runState = new OctopusStateRun();
        wanderState = new OctopusStateWander();

        state = wanderState;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
        state = state.Update(this);
        if (health <= 0) {
            //DIE
        }
    }

    private void OnTriggerEnter(Collider col) {
        enemy = col;
        state = attackState;
    }
}