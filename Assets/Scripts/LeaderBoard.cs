using System;
using System.Collections;
using System.Collections.Generic;
using Dan.Enums;
using Dan.Models;
using UnityEngine;
using TMPro;


namespace Dan.Main
{
    public class LeaderBoard : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI _playerScoreText;
        [SerializeField] private TextMeshProUGUI[] _entryFields;

        [SerializeField] private TMP_InputField _playerUsernameInput;
        [SerializeField] EntriesStorer ent;

        private int _playerScore;

        // Start is called before the first frame update
        void Start()
        {
            Load();
            _entryFields = ent._entryFields;
        }

        /*public void AddPlayerScore()
        {
            
        }*/

        public void Load() => LeaderboardCreator.GetLeaderboard("ff782ca99b24b089d66aeb45d249e79d13be7695e0736200fc15b676a6052fb1", OnLeaderboardLoaded);

        private void OnLeaderboardLoaded(Entry[] entries)
        {
            foreach(var entryField in _entryFields)
            {
                entryField.text = "";
            }

            for(int i = 0; i < entries.Length; ++i)
            {
                _entryFields[i].text = $"{i + 1}. {entries[i].Username} : {entries[i].Score}";
            }
        }

        public void Submit()
        {
            LeaderboardCreator.UploadNewEntry("ff782ca99b24b089d66aeb45d249e79d13be7695e0736200fc15b676a6052fb1", _playerUsernameInput.text, _playerScore, OnUploadComplete);
        }

        private void OnUploadComplete(bool success)
        {
            if (success)
            {
                Load();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

