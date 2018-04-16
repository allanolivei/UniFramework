namespace UniFramework.Utility
{
#if UNITY_EDITOR
    using UnityEditor;

    public class GitCommands
    {

        [MenuItem("Tools/Git/Update Submodules")]
        public static void UpdateSubmodules()
        {
            RunBatch.ExecuteCommand("git submodule update --init --recursive", printOutput: true, baseOutput: "Updating git submodules.");
        }

        //[InitializeOnLoadMethod] // Descomente essa linha se usar submodulos no projeto
        public static void UpdateSubmodulesSilently()
        {
            RunBatch.ExecuteCommand("git submodule update --init --recursive");
        }

        [MenuItem("Tools/Git/Status")]
        public static void GitStatus()
        {
            RunBatch.ExecuteCommand("git status", printOutput: true);
        }
    }
#endif
}