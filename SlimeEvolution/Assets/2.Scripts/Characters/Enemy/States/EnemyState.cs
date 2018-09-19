using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    protected Enemy state;

    protected abstract void StartBehavior();

    protected abstract void ProceedBehavior();

    protected abstract void EndBehavior();
    
}
