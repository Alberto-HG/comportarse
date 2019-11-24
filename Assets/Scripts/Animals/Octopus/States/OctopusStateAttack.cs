using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusStateAttack : IStatesOctopus {

    //Atributos de fuerza, velocidad, colisión y tiempo.
    public float force;
    public int speed = 5;
    public bool colision = false;
    float time = 0f;

    public IStatesOctopus Update(Octopus o) {

        //Si no hay enemigo, vaga.
        if (o.enemy == null) {
            return o.wanderState;
        }

        //Si está en el agua, es más rápido y más fuerte.
        if (o.water) {
            force = Settings.tamPulpos * 15f;
            o.agent.speed = speed * 2;
        } else {
            //Si su vida es baja, huye.
            if (o.health < Settings.tamPulpos * 15) {
                return o.runState;
            }

            force = Settings.tamPulpos * 5f;
            o.agent.speed = speed;
        }

        //Si no hay colisión, sigue persiguiendo.
        if (!colision) {
            o.agent.isStopped = false;
            if (o.enemy == null) {
                return o.wanderState;
            } else {
                o.agent.destination = o.enemy.transform.position;
                return o.attackState;
            }

        //Si la hay, ataca.
        } else {
            colision = false;
            if (Time.time - time > 1f) {
                time = Time.time;

                //Se para.
                o.agent.isStopped = true;

                //Llama a las funciones de recibir daño del rival.
                if (o.enemy.gameObject.CompareTag("TRex")) {
                    TRex rival = o.enemy.GetComponent<TRex>();
                    rival.GetHit((int)force);
                } else if (o.enemy.gameObject.CompareTag("Hormiga")) {
                    Hormiga rival = o.enemy.GetComponent<Hormiga>();
                    if (rival == null) {
                        HormigaReina rivalHR = o.enemy.GetComponent<HormigaReina>();
                        rivalHR.GetHit((int)force);
                    } else {
                        rival.GetHit();
                    }
                } else if (o.enemy.gameObject.CompareTag("Gallina")) {
                    Gallina rival = o.enemy.GetComponent<Gallina>();
                    rival.GetHit((int)force);
                }
            }
        }

        return o.attackState;
    }
}
