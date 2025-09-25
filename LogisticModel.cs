using UnityEngine;

public class LogisticModel
{
    public static float Predict(float gazeTime, float[] weights)
    {
        float z = weights[0] + weights[1] * gazeTime;
        return 1f / (1f + Mathf.Exp(-z));
    }

    public static float PredictThreshold(float[] weights, float targetProb = 0.5f)
    {
        return -(Mathf.Log((1 / targetProb) - 1) - weights[0]) / weights[1];
    }
}
