using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexStateSearch : IStatesTRex {

    int enemies = 2;
    int enemySize = 10;

    public IStatesTRex Update(TRex t) {

        int rand = Random.Range(25, 50);
        if(rand < enemies * enemySize) {
            return t.runState;
        } else {
            return t.attackState;
        }
    }
}
