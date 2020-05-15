using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthBarStorage 
{
    Dictionary<ICharacter, HealthBarView> AllCharacterHealthBars {get;}

    void Add(ICharacter character, HealthBarView view);
    void Add(HealthBarView view);
    HealthBarView Get(ICharacter character);

}
