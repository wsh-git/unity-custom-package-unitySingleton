namespace Wsh.Singleton {
    
    public abstract class NonMonoSingleton<T> where T : NonMonoSingleton<T>, new() {
        
        private static T m_instance;
        private readonly static object m_lock = new object();

        public static T Instance {
            get {
                lock(m_lock) {
                    if(m_instance == null) {
                        m_instance = new T();
                        m_instance.OnInit();
                    }
                    return m_instance;
                }
            }
        }

        protected virtual void OnInit() {
            
        }
        
        protected virtual void OnDeinit() {
            
        }

        public void Destroy() {
            m_instance.OnDeinit();
            m_instance = null;
        }

    }

}

