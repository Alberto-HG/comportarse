﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexStateEat : IStatesTRex {

    GameObject rivalObject;
    ScriptDeMierdaParaProbarCosas rival;

    public IStatesTRex Update(TRex t) {

        rival = t.enemy.GetComponent<ScriptDeMierdaParaProbarCosas>();
        rivalObject = t.enemy.gameObject;
        if (rival.eatable) {
            t.health += rival.healthRegen;
            Object.Destroy(rivalObject);
        }

        t.agent.destination = t.transform.position + new Vector3(1, 1, 1);
        return t.wanderState;
    }
}
