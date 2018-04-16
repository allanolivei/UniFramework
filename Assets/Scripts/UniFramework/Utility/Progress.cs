namespace UniFramework.Utility
{
    using UniFramework.Variables;
    using UnityEngine;

    public class LinearProgress : MonoBehaviour
    {

        public IntReference currentStage;

        /// <summary>
        /// Executa AddStageProgress() utilizando como parâmetro o valor de IntReference currentStage
        /// </summary>
        public void StageComplete()
        {
            AddStageProgress(currentStage.Value);
        }

        /// <summary>
        /// Retorna o número da fase mais difícil que ele já passou
        /// </summary>
        /// <returns>stageNumber</returns>
        public static int GetPlayerProgress()
        {
            return PlayerPrefs.GetInt("Progress");
        }

        /// <summary>
        /// Define a fase mais difícil que o jogador conseguiu passar
        /// </summary>
        /// <param name="stageNum"></param>
        public static void SetPlayerProgress(int stageNum)
        {
            if (stageNum > GetPlayerProgress())
                PlayerPrefs.SetInt("Progress", stageNum);
        }

        /// <summary>
        /// Quantidade de vezes que o jogador concluiu a fase informada
        /// </summary>
        /// <param name="stageNum"></param>
        /// <returns></returns>
        public static int GetStageProgress(int stageNum)
        {
            return PlayerPrefs.GetInt("Stage" + stageNum);
        }

        /// <summary>
        /// Adiciona 1 à quantidade de vezes que o jogador concluiu a fase informada
        /// </summary>
        /// <param name="stageNum"></param>
        public static void AddStageProgress(int stageNum)
        {
            PlayerPrefs.SetInt("Stage" + stageNum, GetStageProgress(stageNum) + 1);
            SetPlayerProgress(stageNum);
        }
    }
}
