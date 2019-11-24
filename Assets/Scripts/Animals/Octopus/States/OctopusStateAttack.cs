using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusStateAttack : IStatesOctopus {

    public float force;
    public int speed = 5;
    public bool colision = false;
    float time = 0f;

    public IStatesOctopus Update(Octopus o) {

        if (o.enemy == null) {
            return o.wanderState;
        }

        if (o.water) {
            force = Settings.tamPulpos * 15f;
            o.agent.speed = speed * 2;
        } else {
            if (o.health < Settings.tamPulpos * 15) {
                return o.runState;
            }

            force = Settings.tamPulpos * 5f;
            o.agent.speed = speed;
        }

        if (!colision) {
            o.agent.isStopped = false;
            if (o.enemy == null) {
                return o.wanderState;
            } else {
                o.agent.destination = o.enemy.transform.position;
                return o.attackState;
            }
        } else {
            colision = false;
            if (Time.time - time > 1f) {
                time = Time.time;

                o.agent.isStopped = true;
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
