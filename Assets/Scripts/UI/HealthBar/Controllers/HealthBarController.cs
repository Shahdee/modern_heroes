using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class HealthBarController : IHealthBarController, IDisposable
{
    private readonly IHealthBarFactory _healthBarFactory;
    private readonly ITeamStorage _teamStorage;
    private readonly IHealthBarStorage _healthBarStorage;
    public HealthBarController(IHealthBarFactory healthBarFactory, ITeamStorage teamStorage, IHealthBarStorage healthBarStorage)
    {
        _healthBarFactory = healthBarFactory;
        _teamStorage = teamStorage;
        _healthBarStorage = healthBarStorage;
    }

    public void ShowHealthBars(bool show)
    {
        if (! _healthBarStorage.AllCharacterHealthBars.Any())
            CreateBars();

       foreach(var bar in _healthBarStorage.AllCharacterHealthBars)
       {
           bar.Value.Show(show);
       }
    }

    private void CreateBars()
    {
         foreach (var team in _teamStorage.AllTeams)
         {
             foreach(var character in team.Value.TeamCharacters)
             {
                 var healthabr = _healthBarFactory.Create();
                 _healthBarStorage.Add(character, healthabr);
                 character.OnMove += UpdateBarPosition;
                 character.OnDamaged += UpdateBarValue;
                 character.OnReset += UpdateBarValue;
                 UpdateBarPosition(character);
                 UpdateBarValue(character);
             }
         }
    }

    private void UpdateBarPosition(ICharacter character)
    {
        var healthBar = _healthBarStorage.Get(character);
        if (healthBar != null)
        {
            var screenPoint = Camera.main.WorldToScreenPoint(character.AttachPoint);
            var resultPosition = (screenPoint / healthBar.ScaleFactor);
            healthBar.SetPosition(resultPosition);
        }
    }

    private void UpdateBarValue(ICharacter character)
    {
        var healthBar = _healthBarStorage.Get(character);
        if (healthBar != null)
        {
            if (character.NormHealth <= 0)
                healthBar.Show(false);
            else
                healthBar.SetSlider(character.NormHealth);
        }
    }

    public void Dispose()
    {
         foreach (var team in _teamStorage.AllTeams)
         {
             foreach(var character in team.Value.TeamCharacters)
             {
                 character.OnMove -= UpdateBarPosition;
                 character.OnDamaged -= UpdateBarValue;
                 character.OnReset -= UpdateBarValue;
             }
         }
    }
}
