using System;
using Cf_Input;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Cf_Move
{
    public enum MoveCtrlType
    {
        Auto,
        Input
    }

    public enum MoveFuncType
    {
        DirectChange,
    }
    
    public partial class MoveSys : MonoBehaviour
    {
        private delegate void MoveDelegate(Vector2 dir);

        [Title("Type")]
        [SerializeField] private MoveCtrlType mMoveCtrlType;
        [SerializeField] private MoveFuncType mMoveFuncType;

        [Title("Speed")] 
        [SerializeField] private bool mUseInitSpeed = true;
        [SerializeField] private float mInitBeginSpeed = 3.0f;
        [SerializeField] private float mInitSpeed = 3.0f;
        [SerializeField] private float mInitCancelSpeed = 3.0f;
        
        [Title("Component")]
        [SerializeField] private Rigidbody mRigidBody;
        [SerializeField] private Animator mAnimator;

        private float _mBeginSpeedCurrent;
        private float _mSpeedCurrent;
        private float _mCancelSpeedCurrent;
        
        private MoveDelegate _mOnMoveBegin, _mOnMoving, _mOnMoveCancel;
        
        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            InitSpeed();
            ActionSub();
            EventSub();
        }

        /// <summary>
        /// OnDestroy
        /// </summary>
        private void OnDestroy()
        {
            ActionUnSub();
            EventUnSub();
        }

        /// <summary>
        /// 초기 속도 초기화
        /// </summary>
        private void InitSpeed()
        {
            if (!mUseInitSpeed) 
                return;
            
            _mBeginSpeedCurrent = mInitBeginSpeed;
            _mSpeedCurrent = mInitSpeed;
            _mCancelSpeedCurrent = mInitCancelSpeed;
        }

        /// <summary>
        /// Action 연결
        /// </summary>
        private void ActionSub()
        {
            _mOnMoveBegin = mMoveFuncType switch
            {
                MoveFuncType.DirectChange => OnMoveBegin_DirectChange,
                _ => null
            };

            _mOnMoving = mMoveFuncType switch
            {
                MoveFuncType.DirectChange => OnMoving_DirectChange,
                _ => null
            };

            _mOnMoveCancel = mMoveFuncType switch
            {
                MoveFuncType.DirectChange => OnMoveCancel_DirectChange,
                _ => null
            };
        }

        /// <summary>
        /// Action 연결 해제
        /// </summary>
        private void ActionUnSub()
        {
            _mOnMoveBegin = null;
            _mOnMoving = null;
            _mOnMoveCancel = null;
        }


        /// <summary>
        /// Input Handler 이벤트 등록
        /// </summary>
        private void EventSub()
        {
            // 입력 모드 아니면 제외
            if (mMoveCtrlType != MoveCtrlType.Input) return;
            
            InputHandler.OnMoveBegin += OnMoveBegin;
            InputHandler.OnMoving += OnMoving;
            InputHandler.OnMoveCancel += OnMoveCancel;
        }

        /// <summary>
        /// Input Handler 이벤트 해제
        /// </summary>
        private void EventUnSub()
        {
            // 입력 모드 아니면 제외
            if (mMoveCtrlType != MoveCtrlType.Input) return;
            
            InputHandler.OnMoveBegin -= OnMoveBegin;
            InputHandler.OnMoving -= OnMoving;
            InputHandler.OnMoveCancel -= OnMoveCancel;
        }

        /// <summary>
        /// 시작 
        /// </summary>
        /// <param name="dir"></param>
        private void OnMoveBegin(Vector2 dir)
        {
            if (!IsRigidBodyExist()) 
                return;
            
            _mOnMoveBegin?.Invoke(dir);
        }

        /// <summary>
        /// 진행
        /// </summary>
        /// <param name="dir"></param>
        private void OnMoving(Vector2 dir)
        {
            if (!IsRigidBodyExist()) 
                return;
            
            _mOnMoving?.Invoke(dir);
        }
        
        /// <summary>
        /// 종료
        /// </summary>
        /// <param name="dir"></param>
        private void OnMoveCancel(Vector2 dir)
        {
            if (!IsRigidBodyExist()) 
                return;
            
            _mOnMoveCancel?.Invoke(dir);
        }
        
        /// <summary>
        /// 경고
        /// </summary>
        /// <returns></returns>
        private bool IsRigidBodyExist()
        {
            Debug.Assert(mRigidBody, "mRigidBody != null");
            
            return mRigidBody;
        }
    }
}
