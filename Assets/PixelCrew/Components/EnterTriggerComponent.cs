using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components
{
    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] string _tag;
        [SerializeField] private UnityEvent _action;
        private static int _silverCoinCount = 0;
        private static int _goldenCoinCount = 0;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(_tag))
            {
                if (_action != null)
                {
                    _action.Invoke();
                }
            }

        }

        public void CollectSilverCoin()
        {

            _silverCoinCount += 1;
            CalculateCoins();

        }

        public void CollectGoldenCoin()
        {
            _goldenCoinCount += 10;
            CalculateCoins();

        }

        public void CalculateCoins()
        {

            int totalCoins = _goldenCoinCount + _silverCoinCount;
            Debug.Log(totalCoins);
        }
    }
}
