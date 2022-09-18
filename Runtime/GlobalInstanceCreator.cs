using UnityEngine;

namespace Kogane.Internal
{
    /// <summary>
    /// 各シーンで使用する機能を初期化するための Global プレハブを生成するコンポーネント
    /// </summary>
    [DisallowMultipleComponent]
    [DefaultExecutionOrder( -1000 )]
    internal sealed class GlobalInstanceCreator : MonoBehaviour
    {
        //==============================================================================
        // 変数(SerializeField)
        //==============================================================================
        [SerializeField] private GameObject m_globalInstancePrefab;

        //==============================================================================
        // 変数(static)
        //==============================================================================
        private static bool m_isInitialized;

        //==============================================================================
        // 関数
        //==============================================================================
        /// <summary>
        /// 初期化される時に呼び出されます
        /// </summary>
        private void Awake()
        {
            if ( m_isInitialized )
            {
                Destroy( gameObject );
                return;
            }

            m_isInitialized = true;

            Instantiate( m_globalInstancePrefab );
            Destroy( gameObject );
        }

        //==============================================================================
        // 関数(static)
        //==============================================================================
        /// <summary>
        /// ゲーム起動時に呼び出されます
        /// </summary>
        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
        private static void RuntimeInitializeOnLoadMethod()
        {
            m_isInitialized = false;
        }
    }
}