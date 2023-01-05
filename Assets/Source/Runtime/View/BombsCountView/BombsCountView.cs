using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using TMPro;
using UnityEngine;

namespace Minesweeper.Runtime.View.BombsCountView
{
    public class BombsCountView : SerializedMonoBehaviour, IBombsCountView
    {
        [SerializeField] private TextMeshProUGUI _countText;
        [OdinSerialize] private List<Color> _colorsForNumbers;

        public void Display(int bombsCount)
        {
            if (bombsCount == 0)
            {
                _countText.text = "";
                return;
            }

            if (bombsCount is < 0 or > 8)
                throw new ArgumentException("Bombs count must be in range from 0 to 8");

            _countText.text = bombsCount.ToString();
            _countText.color = _colorsForNumbers[bombsCount - 1];
        }
    }
}