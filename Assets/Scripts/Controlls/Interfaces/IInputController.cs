﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IInputController
{
    event Action<Vector3> OnQuickTouch;
    bool Enabled {get;}
    void SetEnabled(bool enabled);

}
