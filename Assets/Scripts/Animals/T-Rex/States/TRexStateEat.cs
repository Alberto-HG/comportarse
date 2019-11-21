using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexStateEat : IStatesTRex {
    public IStatesTRex Update(TRex t) {
        return t.eatState;
    }
}
