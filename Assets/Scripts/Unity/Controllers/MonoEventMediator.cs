using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoEventMediator 
{
    private readonly List<IUpdatable> _updatables;
    protected readonly MonoEventMediatorView _mediatorView;

    // protected UnityEventMediator(List<IUpdatable> updatables, List<ILateUpdatable> lateUpdatables,
    //     List<IFixedUpdatable> fixedUpdatables, List<IApplicationPauseListener> applicationPauses,
    //     List<IApplicationFocusListener> applicationFocus, List<IApplicationQuitListener> applicationQuits)
    
    protected MonoEventMediator(List<IUpdatable> updatables)
    {
        _updatables = updatables;
        // _lateUpdatables = lateUpdatables;
        // _fixedUpdatables = fixedUpdatables;
        // _applicationPauses = applicationPauses;
        // _applicationFocus = applicationFocus;
        // _applicationQuits = applicationQuits;

        _mediatorView = new GameObject("MonoEventMediatorView").AddComponent<MonoEventMediatorView>();
        _mediatorView.Listen(Update);
    }

    private void Update(float deltaTime)
    {
        foreach (var item in _updatables)
            item.CustomUpdate(deltaTime);
    }

    public void Dispose()
    {
        _mediatorView.UnlistenAll();
    }
}
