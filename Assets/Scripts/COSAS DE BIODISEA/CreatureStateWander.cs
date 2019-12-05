using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureStateWander : IStatesCreature {

    //Atributo de velocidad.
    public int speed = 1;

    public IStatesCreature Update(CreatureController c) {

        c.agent.speed = speed;

        //Nuevo destino aleatorio.
        int rand = Random.Range(0, 1000);
        if(rand > 995) {
            //Si está en tierra (hay que cambiar esos 20 por la altura del agua)
            if (Vector3.Distance(Vector3.zero, c.transform.position) > 20) {
                //Busca un destino que no esté en el agua
                do {
                    c.agent.destination = c.transform.position + new Vector3((Random.value - 0.5f) * 10, (Random.value - 0.5f) * 10, (Random.value - 0.5f) * 10);
                } while (Vector3.Distance(Vector3.zero, c.transform.position) <= 20);
            //Si está en agua busca un destino en toda la navmesh con tierra y pasa a estado yendo a tierra firme.
            } else {
                do {
                    c.agent.destination = c.transform.position + new Vector3((Random.value - 0.5f) * 10000, (Random.value - 0.5f) * 10000, (Random.value - 0.5f) * 10000);
                } while (Vector3.Distance(Vector3.zero, c.transform.position) <= 20);
                return c.toLandState;
            }
        }
        return c.wanderState;
    }
}