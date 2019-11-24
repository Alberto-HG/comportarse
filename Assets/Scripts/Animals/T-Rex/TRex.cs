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
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * Settings.tamTrex;

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

        if (health < 1) {
            DestroyImmediate(gameObject);
        }
    }

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

    private void OnCollisionStay(Collision collision) {
        if (!gameObject.CompareTag(collision.collider.tag) && !collision.collider.isTrigger && state == attackState) {
            if (collision.collider.transform == enemy.transform) {
                attackState.colision = true;
            }
        }
    }
}