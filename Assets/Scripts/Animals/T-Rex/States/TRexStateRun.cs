using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TRexStateRun : IStatesTRex {

    public int runSpeed = 5;
    bool done = false;

    public IStatesTRex Update(TRex t) {
        if (!done) {
            t.agent.speed = runSpeed;
            t.agent.destination = t.transform.position - 4 * (t.enemy.transform.position - t.transform.position);
            done = true;
        }
        
        if (t.agent.remainingDistance == 0) {
            t.enemy = null;
            done = false;
            return t.wanderState;
        } else {
            return t.runState;
        }
    }
}