using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusStateAttack : IStatesOctopus {

    ScriptDeMierdaParaProbarCosas rival;
    public float force;
    public int enemies;
    public float enemySize;
    public int speed = 5;

    public IStatesOctopus Update(Octopus o) {

        rival = o.enemy.GetComponent<ScriptDeMierdaParaProbarCosas>();
        enemies = rival.groupSize;
        enemySize = rival.size;
        if (o.water) {
            force = o.size * 15f;
        } else {
            force = o.size * 5f;
        }
        o.agent.speed = speed;
        if (o.enemy == null) {
            return o.wanderState;
        } else {
            o.agent.destination = o.enemy.transform.position;
        }
        if (o.agent.remainingDistance < 2) {
            o.agent.isStopped = true;
            rival = o.enemy.GetComponent<ScriptDeMierdaParaProbarCosas>();

            //ESTO HAY QUE CAMBIARLO PARA QUE SOLO SE EJECUTE SI EL RIVAL MUERE, ES EJEMPLO DE CADAVER
            rival.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            o.health -= rival.force;
            if(o.health > 30) {
                if (force < rival.health) {
                    //AQUI DEBERIA CAMBIAR LA VIDA DEL RIVAL
                    return o.attackState;
                } else {
                    o.agent.isStopped = false;
                    return o.wanderState;
                }
            } else {
                return o.runState;
            }
        } else {
            return o.attackState;
        }
    }
}
