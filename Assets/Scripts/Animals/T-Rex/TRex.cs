using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRex : MonoBehaviour{
    public int health;

    IStatesTRex state;

    [HideInInspector]
    public TRexStateAttack attackState;
    [HideInInspector]
    public TRexStateEat eatState;
    [HideInInspector]
    public TRexStateSearch searchState;
    [HideInInspector]
    public TRexStateRun runState;

    void Start() {
        health = 100;

        attackState = new TRexStateAttack();
        eatState = new TRexStateEat();
        searchState = new TRexStateSearch();
        runState = new TRexStateRun();

        state = searchState;
    }

    // Update is called once per frame
    void Update() {
        state = state.Update(this);
    }
}
