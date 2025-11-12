using UnityEngine;
using UnityEngine.UI;

public class RandomSlider : MonoBehaviour
{
    public Slider slider;
    public float changeInterval = 0.5f; // 値を変える間隔

    void Start()
    {
        // 一定間隔でランダム値を設定
        InvokeRepeating("SetRandomValue", 0f, changeInterval);
    }

    void SetRandomValue()
    {
        // スライダーの範囲内でランダムな値を設定
        float randomValue = Random.Range(slider.minValue, slider.maxValue);
        slider.value = randomValue;
    }
}
