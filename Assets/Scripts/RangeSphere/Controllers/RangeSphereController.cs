using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeSphereController : IRangeSphereController
{
    private readonly RangeSphereView _view;

    
    private static Color MoveColor = new Color(0.2f, 0.2f, 0.2f, 1f);
    private static Color AttackColor = new Color(0.3f, 0.3f, 0.3f, 1f);

    public RangeSphereController(RangeSphereView view)
    {
        _view = view;
    }

    public void ShowSphere(ICharacter character, ERangeSphereType type)
    {
        switch(type)
        {
            case ERangeSphereType.Move:
                _view.Show(character.Position, character.MoveRange, MoveColor);
            break;

            case ERangeSphereType.Attack:
                _view.Show(character.Position, character.AttackRange, AttackColor);
            break;
        }
    }

    public void HideSphere()
    {
        _view.Hide();
    }
}
