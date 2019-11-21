using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexStateRun : IStatesTRex {
    public int runSpeed = 10;

    public IStatesTRex Update(TRex t) {
        return t.runState;
    }
}
