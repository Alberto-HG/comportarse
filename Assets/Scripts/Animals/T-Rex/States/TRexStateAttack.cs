using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexStateAttack : IStatesTRex {

    float force;
    int attackSpeed = 5;
    ScriptDeMierdaParaProbarCosas rival;

    public IStatesTRex Update(TRex t) {

        t.agent.speed = attackSpeed;
        force = t.size * 10;
        if (t.enemy == null) {
            return t.wanderState;
        } else {
            t.agent.destination = t.enemy.transform.position;
        }
        if (t.agent.remainingDistance < 2) {
            t.agent.isStopped = true;
            rival = t.enemy.GetComponent<ScriptDeMierdaParaProbarCosas>();

            //ESTO HAY QUE CAMBIARLO PARA QUE SOLO SE EJECUTE SI EL RIVAL MUERE, ES EJEMPLO DE CADAVER
            rival.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            
            t.health -= rival.force;
            if (force < rival.health) {
                //AQUI DEBERIA CAMBIAR LA VIDA DEL RIVAL
                return t.attackState;
            } else {
                return t.eatState;
            }
        } else {
            return t.attackState;
        }
    }
}
