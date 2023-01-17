using System;
using Minesweeper.Runtime.Model.Field;
using Minesweeper.Runtime.Model.Settings;
using Minesweeper.Runtime.Tools.Exceptions;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Minesweeper.Runtime.View.Settings
{
    public class CellsFieldDataSettingView : SerializedMonoBehaviour
    {
        [SerializeField] private TMP_InputField _sizeXInputField;
        [SerializeField] private TMP_InputField _sizeYInputField;
        [SerializeField] private TMP_InputField _bombsCountInputField;
        
        [Space]
        [SerializeField] private Button _applyButton;
        [SerializeField] private TextMeshProUGUI _logText;
        
        [Space]
        [OdinSerialize] private CellsFieldData _defaultData;

        private void Awake()
        {
            var cellsFieldDataContainer = new CellsFieldDataContainer(_defaultData);
            InitializeFields(cellsFieldDataContainer);
            _logText.text = string.Empty;
            
            _applyButton.onClick.AddListener(() =>
            {
                if (_sizeXInputField.text == string.Empty || 
                    _sizeYInputField.text == string.Empty ||
                    _bombsCountInputField.text == string.Empty)
                {
                    _logText.text = "Not every field is filled";
                    return;
                }

                try
                {
                    var sizeX = int.Parse(_sizeXInputField.text);
                    var sizeY = int.Parse(_sizeYInputField.text);
                    var bombsCount = int.Parse(_bombsCountInputField.text);
                    
                    cellsFieldDataContainer.SetFieldData(new CellsFieldData(sizeX, sizeY, bombsCount));
                    _logText.text = "Changes applied";
                }
                catch (TooManyBombsException) { _logText.text = "Bombs count it too big"; }
                catch (FieldIsTooBigException) { _logText.text = "Field is too big"; }
                catch (FieldIsToSmallException) { _logText.text = "Field it too small"; }
                catch (Exception) { _logText.text = "Incorrect input"; }
            });
        }

        private void InitializeFields(CellsFieldDataContainer cellsFieldDataContainer)
        {
            var lastCellFieldData = cellsFieldDataContainer.GetFieldData();
            _sizeXInputField.text = lastCellFieldData.SizeX.ToString();
            _sizeYInputField.text = lastCellFieldData.SizeY.ToString();
            _bombsCountInputField.text = lastCellFieldData.TotalBombsCount.ToString();
        }
    }
}