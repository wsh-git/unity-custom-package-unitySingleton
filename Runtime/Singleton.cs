using UnityEngine;

namespace Wsh.Singleton {
    
    public class Singleton<T> : MonoBehaviour where T : Component, ISingleton {

        private static T m_instance;

        public static T Instance {
            get {
                if(m_instance == null) {
                    GameObject go = new GameObject(GetObjName(typeof(T).ToString()));
                    m_instance = go.AddComponent<T>();
                    m_instance.OnInit();
                    DontDestroyOnLoad(go);
                }
                return m_instance;
            }
        }

        private static string GetObjName(string v) {
            string[] array = v.Split('.');
            return "__" + array[array.Length - 1];
        }
        
        protected virtual void Update() {

        }

        public void Destroy() {
            m_instance.OnDeinit();
            Object.Destroy(m_instance.gameObject);
            m_instance = null;
        }
        
    }
    
}