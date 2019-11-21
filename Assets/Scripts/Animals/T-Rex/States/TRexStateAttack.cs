using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexStateAttack : IStatesTRex {
    public IStatesTRex Update(TRex t) {
        return t.attackState;
    }
}
