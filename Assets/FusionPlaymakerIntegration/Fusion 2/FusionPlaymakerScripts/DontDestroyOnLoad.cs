using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GooglyEyesGames
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}

