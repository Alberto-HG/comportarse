using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusStateWander : IStatesOctopus {

    public int speed = 3;

    public IStatesOctopus Update(Octopus o) {

        if (o.water) {
            o.agent.speed = speed*2;
        } else {
            o.agent.speed = speed;
        }
        int rand = Random.Range(0, 100);
        if (rand > 80) {
            o.agent.destination = o.transform.position + new Vector3((Random.value - 0.5f) * 80, (Random.value - 0.5f) * 80, (Random.value - 0.5f) * 80);
        }
        return o.wanderState;
    }
}
