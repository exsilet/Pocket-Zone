using TMPro;
using UnityEngine;

namespace CodeBase.Hero.Weapon
{
    public class AmmoView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _barText;

        private HeroAttack _heroAttack;
        
        public void Construct(HeroAttack attack)
        {
            _heroAttack = attack;
            
            _heroAttack.AmmoTextChanged += OnValueTextChanged;
        }
        
        private void OnValueTextChanged(int value, int maxValue)
        {
            _barText.text = $"{(float)value} / {maxValue}";
        }
    }
}