using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineController : MonoBehaviour
{
    public StateBase[] states;

    private StateBase _currentState;

    public void Initialize() {
        if(states != null && states.Length > 0) {
            SetState(states[0].stateName);
        }
    }

    public void Step() {
        if (_currentState != null) {
            _currentState.StateInput();
            _currentState.StateStep();
        }
    }

    public void PhysicsStep() {
        if (_currentState != null) {
            _currentState.StatePhysicsStep();
        }
    }

    public void LateStep() {
        if (_currentState != null) {
            _currentState.StateLateStep();
        }
    }


    public void SetState(string stateName) {
        StateBase nextState = GetStateByName(stateName);


        if (nextState == null) return;
        
        if(_currentState != null) _currentState.StateExit();

        _currentState = nextState;
        _currentState.StateEnter();

    }

    private StateBase GetStateByName(string stateName) {
        for(int i = 0; i < states.Length; i++) {
            if (states[i].stateName == stateName) {
                return states[i];
            }
        }

        return null;
    }
}
