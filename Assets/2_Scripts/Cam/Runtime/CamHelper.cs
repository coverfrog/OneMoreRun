using System;
using UnityEngine;

namespace Cf_Cam
{
    public class CamHelper : MonoBehaviour
    {
        [SerializeField] private CamType mCamType;

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            EventSub();
        }

        /// <summary>
        /// OnDestroy
        /// </summary>
        private void OnDestroy()
        {
            EventUnSub();
        }

        /// <summary>
        /// 이벤트 등록
        /// </summary>
        private void EventSub()
        {
            
        }

        /// <summary>
        /// 이벤트 등록 해제
        /// </summary>
        private void EventUnSub()
        {
            
        }
    }
}
