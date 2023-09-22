using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Utility
{
    [RequireComponent(typeof(Text))]
    public class showGeneration : MonoBehaviour
    {
        const string display = "Generation: {0}";
        private Text m_Text;

        private void Start()
        {
           
            m_Text = GetComponent<Text>();
        }

        private void Update()
        {
            CarControllerAI c = GameObject.Find("CarController").GetComponent<CarControllerAI>();
            int genNum = c.getGeneration();
            m_Text.text = string.Format(display, genNum);
        }

    }
}
