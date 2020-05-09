using System;
using UnityEngine;

public class MonoEventMediatorView : MonoBehaviour
{
       private Action<float> _update;

        // public void Listen(Action<float> update, Action<float> fixedUpdate, Action<float> lateUpdate,
        //     Action<bool> applicationPause, Action<bool> applicationFocus, Action applicationQuit)
        public void Listen(Action<float> update)
        {
            _update = update;
            // _fixedUpdate = fixedUpdate;
            // _lateUpdate = lateUpdate;
            // _applicationPause = applicationPause;
            // _applicationFocus = applicationFocus;
            // _applicationQuit = applicationQuit;
        }

        public void UnlistenAll()
        {
            _update = null;
            // _fixedUpdate = null;
            // _lateUpdate = null;
            // _applicationPause = null;
            // _applicationFocus = null;
            // _applicationQuit = null;
        }

        public void SetDontDestroy()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            _update?.Invoke(Time.deltaTime);
        }

}
