using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexStateRun : IStatesTRex
{

    public int runSpeed = 10;

    // Update is called once per frame
    void Update(TRex t)
    {
        return t.runState;
    }
}
