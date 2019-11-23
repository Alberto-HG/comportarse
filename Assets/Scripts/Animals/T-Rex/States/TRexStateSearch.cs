using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexStateSearch : IStatesTRex {

    int enemies;
    ScriptDeMierdaParaProbarCosas rival;
    float enemySize;
    float force;

    public IStatesTRex Update(TRex t) {

        rival = t.enemy.GetComponent<ScriptDeMierdaParaProbarCosas>();
        enemies = rival.groupSize;
        enemySize = rival.size;
        force = t.size * 7.5f;
        if (t.grouped) {
            force *= 2;
        }
        int rand = Random.Range((int)(force * 0.75f), (int)(force * 1.25f));
        if(rand < enemies * enemySize) {
            return t.runState;
        } else {
            return t.attackState;
        }
    }
}
