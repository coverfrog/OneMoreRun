using System;
using UnityEngine;

namespace Cf_Pattern
{
    public abstract class Singleton<T> : MonoBehaviour where T : Behaviour
    {
        private static T _instance;

        // ReSharper disable once StaticMemberInGenericType
        // ReSharper disable once InconsistentNaming
        private static readonly object _lock = new object();

        // ReSharper disable once StaticMemberInGenericType
        private static bool _isRunning = true;
    
        public static T Instance
        {
            get
            {
                if (!_isRunning) return null;
            
                if (_instance != null) return _instance;

                lock (_lock)
                {
                    _instance = FindAnyObjectByType<T>(FindObjectsInactive.Include);

                    if (_instance != null) return _instance;

                    _instance = new GameObject(typeof(T).Name).AddComponent<T>();
                }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (!_instance)
            {
                _instance = this as T;
            
                DontDestroyOnLoad(gameObject);
            
            }

            else
            {
                Destroy(gameObject);
            }
        }

        private void OnApplicationQuit()
        {
            _isRunning = false;
        }
    }
}