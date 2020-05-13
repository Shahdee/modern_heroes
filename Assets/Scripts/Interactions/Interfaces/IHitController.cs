using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IHitController 
{
    event Action<RaycastHit[]> OnHit;
}
