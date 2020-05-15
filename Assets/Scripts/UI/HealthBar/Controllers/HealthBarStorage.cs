using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarStorage : IHealthBarStorage
{
    public Dictionary<ICharacter, HealthBarView> AllCharacterHealthBars => _characterBars;
    private readonly List<HealthBarView> _allBars;
    private readonly Dictionary<ICharacter, HealthBarView> _characterBars;

    public HealthBarStorage()
    {
        _allBars = new List<HealthBarView>();
        _characterBars = new Dictionary<ICharacter, HealthBarView>();
    }

    public void Add(HealthBarView view)
    {
        _allBars.Add(view);
    }

    public void Add(ICharacter character, HealthBarView view)
    {
        _characterBars[character] = view;
    }

    public HealthBarView Get(ICharacter character)
    {
        if (_characterBars.ContainsKey(character))
            return _characterBars[character];

        return null;
    }
}
