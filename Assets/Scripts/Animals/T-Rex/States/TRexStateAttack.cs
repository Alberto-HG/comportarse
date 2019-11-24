using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexStateAttack : IStatesTRex {

    float force;
    int attackSpeed = 5;

    public IStatesTRex Update(TRex t) {

        if (t.enemy == null) {
            return t.wanderState;
        }

        t.agent.speed = attackSpeed;
        force = Settings.tamTrex * 10;
        if (t.agent.remainingDistance > 1) {
            t.agent.isStopped = false;
            if (t.enemy == null) {
                return t.wanderState;
            } else {
                t.agent.destination = t.enemy.transform.position;
                return t.attackState;
            }
        } else {
            t.agent.isStopped = true;
            if (t.enemy.gameObject.CompareTag("Pulpo")) {
                Octopus rival = t.enemy.GetComponent<Octopus>();
                rival.GetHit((int)force);
                if (t.enemy == null) {
                    t.health += 20;
                }
            } else if(t.enemy.gameObject.CompareTag("Hormiga")) {
            Hormiga rival = t.enemy.GetComponent<Hormiga>();
            if (rival == null) {
                HormigaReina rivalHR = t.enemy.GetComponent<HormigaReina>();
                rivalHR.GetHit((int)force);
                } else {
                    rival.GetHit();
                }
            } else if(t.enemy.gameObject.CompareTag("Gallina")) {
                Gallina rival = t.enemy.GetComponent<Gallina>();
                rival.GetHit((int)force);
                if (t.enemy == null) {
                    t.health += 20;
                }
            }
        }

        return t.attackState;
    }
}
