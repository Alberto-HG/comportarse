using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TRexStateRun : IStatesTRex {

    //Atributos de velocidad y de final de huida.
    public int runSpeed = 5;
    bool done = false;

    public IStatesTRex Update(TRex t) {

        //Si no ha acabado su huida sigue corriendo.
        if (!done) {
            t.agent.speed = runSpeed;
            t.agent.destination = t.transform.position - 4 * (t.enemy.transform.position - t.transform.position);
            done = true;
        }

        //Si ha huido vaga por el mapa de nuevo.
        if (t.agent.remainingDistance == 0) {
            t.enemy = null;
            done = false;
            return t.wanderState;
        } else {
            return t.runState;
        }
    }
}