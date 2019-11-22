using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class TRexStateWander : IStatesTRex {

    public int speed = 3;

    public IStatesTRex Update(TRex t) {

        t.agent.speed = speed;
        int rand = Random.Range(0, 100);
        if(rand > 50) {
            t.agent.destination = t.transform.position + new Vector3((Random.value - 0.5f) * 80, (Random.value - 0.5f) * 80, (Random.value - 0.5f) * 80);
        }
        return t.wanderState;
    }
}
