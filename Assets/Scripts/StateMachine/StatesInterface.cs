using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StatesInterface
{
    void Tick();
    void OnEnter();
    void OnExit();
    Color GizmoColor();
}
