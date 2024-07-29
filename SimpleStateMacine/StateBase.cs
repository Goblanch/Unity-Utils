using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase : MonoBehaviour
{
    public string stateName;
    public StateMachineController stateMachine;

    public abstract void StateInput();
    public abstract void StateEnter();
    public abstract void StateExit();
    public abstract void StateStep();
    public abstract void StatePhysicsStep();
    public abstract void StateLateStep();
}
