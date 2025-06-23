using UnityEngine;

namespace Cf_Move
{
    public partial class MoveSys : MonoBehaviour
    {
        private void OnMoveBegin_DirectChange(Vector2 dir)
        {
            mRigidBody.linearVelocity = new Vector3(dir.x, 0, dir.y) * _mBeginSpeedCurrent;
        }
        
        private void OnMoving_DirectChange(Vector2 dir)
        {
            mRigidBody.linearVelocity = new Vector3(dir.x, 0, dir.y) * _mSpeedCurrent;
        }
        
        private void OnMoveCancel_DirectChange(Vector2 dir)
        {
            mRigidBody.linearVelocity = Vector3.zero * _mCancelSpeedCurrent;
        }
    }
}
