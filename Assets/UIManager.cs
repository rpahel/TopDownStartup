using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _startRoomText;
        [SerializeField] private GameObject _clearRoomText;


        public void ActiveStartText()
        {
            _startRoomText.SetActive(true);
            StartCoroutine(DisableText(_startRoomText, 1f));
        }
        
        public void ActiveClearText()
        {
            _clearRoomText.SetActive(true);
            StartCoroutine(DisableText(_clearRoomText,  1f));
        }


        public IEnumerator DisableText(GameObject gameObject, float duration)
        {
            yield return new WaitForSeconds(duration);
            gameObject.SetActive(false);
        }
    }
}
