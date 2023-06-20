using System.Collections.Generic;
using Patterns.Adapter;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Facade
{
    public class FacadeMenu : MonoBehaviour
    {
        [SerializeField] private Button saveButton;
        [SerializeField] private Button loadButton;

        [SerializeField] private GameFacade gameFacade;

        private void Awake()
        {
            saveButton.onClick.AddListener(SaveGame);
            loadButton.onClick.AddListener(LoadGame);
        }

        private void SaveGame()
        {
            gameFacade.SaveGame();
        }

        private void LoadGame()
        {
            gameFacade.LoadGame();
        }
    }
}
