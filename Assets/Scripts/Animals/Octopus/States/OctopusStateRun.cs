using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusStateRun : IStatesOctopus {

    public int speed = 3;

    public IStatesOctopus Update(Octopus o) {

        o.agent.destination = o.waterTerrain.position;
        if (o.water) {
            return o.wanderState;
        } else {
            return o.runState;
        }
    }
}
