using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Hero
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _barText;

        private HeroHealth _heroHealth;
        
        public void Construct(HeroHealth heroHealth)
        {
            _slider.value = 1;
            
            _heroHealth = heroHealth;
            
            _heroHealth.HealthChanged += OnValueChanged;
            _heroHealth.HealthTextChanged += OnValueTextChanged;
        }

        private void OnDestroy()
        {
            _heroHealth.HealthChanged -= OnValueChanged;
            _heroHealth.HealthTextChanged -= OnValueTextChanged;
        }

        private void OnValueChanged(int value, int maxValue)
        {
            _slider.value = (float)value / maxValue;
        }

        private void OnValueTextChanged(int value, int maxValue)
        {
            _barText.text = $"{(float)value} / {maxValue}";
        }
    }
}