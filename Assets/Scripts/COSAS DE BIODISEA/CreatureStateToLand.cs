using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureStateToLand : IStatesCreature {

    //Atributo de velocidad.
    public int speed = 5;

    //Si no ha llegado a su destino sigue huyendo
    public IStatesCreature Update(CreatureController c) {

        c.agent.speed = speed;

        if (c.agent.remainingDistance == 0) {
            return c.wanderState;
        } else {
            return c.toLandState;
        }
    }
}