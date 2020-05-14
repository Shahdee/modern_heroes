using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRangeSphereController 
{
    void ShowSphere(ICharacter character, ERangeSphereType type);
    void HideSphere();
}
