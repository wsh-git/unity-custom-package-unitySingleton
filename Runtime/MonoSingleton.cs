using UnityEngine;

namespace Wsh.Singleton {
    
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T> {

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

        protected virtual void OnInit() {
            
        }

        protected virtual void OnDeinit() {
            
        }

        public void Destroy() {
            m_instance.OnDeinit();
            Object.Destroy(m_instance.gameObject);
            m_instance = null;
        }
        
    }
    
}