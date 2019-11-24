using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusStateWander : IStatesOctopus {

    //Atributo de velocidad.
    public int speed = 3;

    public IStatesOctopus Update(Octopus o) {

        //Si está en agua, va el doble de rápido.
        if (o.water) {
            o.agent.speed = speed*2;
        } else {
            o.agent.speed = speed;
        }

        //Nuevo destino aleatorio.
        o.agent.destination = o.transform.position + new Vector3((Random.value - 0.5f) * 80, (Random.value - 0.5f) * 80, (Random.value - 0.5f) * 80);
        return o.wanderState;
    }
}
