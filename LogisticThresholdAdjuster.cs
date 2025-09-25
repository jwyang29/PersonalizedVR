using UnityEngine;

public class LogisticThresholdAdjuster : MonoBehaviour
{
    public float[] exampleWeights = { -3.5f, 2.2f };  // 학습 결과로 얻은 가중치

    void Start()
    {
        float personalizedThreshold = LogisticModel.PredictThreshold(exampleWeights, 0.5f);
        FindObjectOfType<GazeTracker>().gazeThreshold = personalizedThreshold;

        Debug.Log("개인화된 gazeThreshold: " + personalizedThreshold);
    }
}
