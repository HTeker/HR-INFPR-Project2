using UnityEngine;

namespace Scripts
{
    public static class LogExtension
    {
        public static void LogMessage(this Object obj, string message, LogType type = LogType.Log)
        {
            GameObject go = obj as GameObject;
            Debug.logger.LogFormat(type, obj, "[{0}{1}] {2}", (go != null ? go.name + ":" : ""), obj.GetType().Name, message);
        }
    }
}
