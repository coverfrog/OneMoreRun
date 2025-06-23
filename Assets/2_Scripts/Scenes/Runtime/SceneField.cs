using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Cf_Episode
{
    [Serializable]
    public class SceneField
    {
        [SerializeField] private Object sceneAsset;
        [SerializeField] private string sceneName;
        [SerializeField] private string sceneRelativePath;
        [SerializeField] private string sceneAbsolutePath;

        public SceneField()
        {
            
        }

        public SceneField(Object obj)
        {
            sceneAsset = obj;
        }
        
        public string SceneName => sceneName;

        public string SceneRelativePath => sceneRelativePath;

        public string SceneAbsolutePath => sceneAbsolutePath;
    }
}
