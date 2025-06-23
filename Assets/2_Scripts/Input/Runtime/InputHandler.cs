using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Cf_Input
{
    public class InputHandler : MonoBehaviour
    {
        public delegate void MoveDelegate(Vector2 dir);

        public static event MoveDelegate OnMoveBegin, OnMoving, OnMoveCancel;
        
        private bool _mIsMove;

        private Vector2 _mMoveDir;

        private void Update()
        {
            if (_mIsMove)
            {
                OnMoving?.Invoke(_mMoveDir);
            }
        }

        public void OnMove(InputValue inputValue)
        {
            _mMoveDir = inputValue.Get<Vector2>().normalized;

            if (_mMoveDir.sqrMagnitude > 0)
            {
                if (_mIsMove) return;

                _mIsMove = true;
                
                OnMoveBegin?.Invoke(_mMoveDir);
            }

            else
            {
                if (!_mIsMove) return;
                
                _mIsMove = false;
                    
                OnMoveCancel?.Invoke(Vector2.zero);
            }
        }
        
    }
}
