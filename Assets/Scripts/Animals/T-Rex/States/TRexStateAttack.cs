using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexStateAttack : IStatesTRex {

    //Atributos de fuerza, velocidad, colisión, y tiempo.
    float force;
    int attackSpeed = 5;
    public bool colision = false;
    float time = 0f;

    public IStatesTRex Update(TRex t) {

        //Si el enemigo desaparece, el TRex vaga.
        if (t.enemy == null) {
            return t.wanderState;
        }

        t.agent.speed = attackSpeed;
        force = Settings.tamTrex * 20;

        //Si no hay colisión, sigue persiguiendo.
        if (!colision) {
            t.agent.isStopped = false;
            if (t.enemy == null) {
                return t.wanderState;
            } else {
                t.agent.destination = t.enemy.transform.position;
                return t.attackState;
            }

        //Si hay colisión, ataca.
        } else {
            colision = false;

            if (Time.time - time > 1f) {
                time = Time.time;

                //Se para.
                t.agent.isStopped = true;

                //Si es un pulpo, ataca hasta morir o matar, si lo mata puede comer.
                if (t.enemy.gameObject.CompareTag("Pulpo")) {
                    Octopus rival = t.enemy.GetComponent<Octopus>();
                    rival.GetHit((int)force);
                    if (t.enemy == null) {
                        t.health += 20;
                    }

                //Si es una hormiga, ataca hasta matar o morir.
                } else if (t.enemy.gameObject.CompareTag("Hormiga")) {
                    Hormiga rival = t.enemy.GetComponent<Hormiga>();
                    if (rival == null) {
                        HormigaReina rivalHR = t.enemy.GetComponent<HormigaReina>();
                        rivalHR.GetHit((int)force);
                    } else {
                        rival.GetHit();
                    }

                //Si es una gallina, ataca hasta morir o matar, si lo mata puede comer.
                } else if (t.enemy.gameObject.CompareTag("Gallina")) {
                    Gallina rival = t.enemy.GetComponent<Gallina>();
                    rival.GetHit((int)force);
                    if (t.enemy == null) {
                        t.health += 20;
                    }
                }
            }
        }

        return t.attackState;
    }
}
