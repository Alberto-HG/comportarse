using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class TRexStateWander : IStatesTRex {

    //Atributo de velocidad.
    public int speed = 3;

    public IStatesTRex Update(TRex t) {

        //Elige una dirección aleatoria.
        t.agent.speed = speed;
        t.agent.destination = t.transform.position + new Vector3((Random.value - 0.5f) * 80, (Random.value - 0.5f) * 80, (Random.value - 0.5f) * 80);
        return t.wanderState;
    }
}
