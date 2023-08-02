using Zenject;
using UnityEngine;
using System.Collections.Generic;
using System;

namespace ArcheroClone
{
    public class UnitFactoryMonoInstaller : MonoInstaller
    {
        [SerializeField]
        private PlayerMonoInstaller _playerPrefab;
        [SerializeField]
        private GunmanMonoInstaller _gunmanPrefab;
        [SerializeField]
        private FlyingCowboyMonoInstaller _cowboyPrefab;
        [SerializeField]
        private TurrelmanMonoInstaller _turrelmanPrefab;
        [SerializeField]
        private StartCountdownUI _startCountdownUI;
        [SerializeField]
        private WinGatesTrigger _winGatesTrigger;
        [SerializeField]
        private GameObject _winPanel;

        private System.Random _rand;
        private AllUnitsInfo _allUnitsInfo;

        public override async void InstallBindings()
        {
            _rand = new System.Random();

            AllUnitsInfo();
            Win();
            CreatePrefabs();

            await new StartCountdown(_startCountdownUI).Countdown();

            InjectPrefabs();
        }

        private void AllUnitsInfo()
        {
            _allUnitsInfo = new AllUnitsInfo();
            Container
                .Bind<AllUnitsInfo>()
                .FromInstance(_allUnitsInfo)
                .AsSingle();
        }

        private void Win()
        {
            _winGatesTrigger.Init(_winPanel);
            new WinHandler(_allUnitsInfo, _winGatesTrigger);
        }

        private void CreatePrefabs()
        {
            UnitMonoInstaller unitInstaller;

            unitInstaller = Instantiate(_playerPrefab, new Vector3(_rand.Next(-3, 3), 0, _rand.Next(-7, -3)), Quaternion.identity);
            unitInstaller.Init(new UnitData(1, 3, 2, new HealthData(7)));
            _allUnitsInfo.Add(unitInstaller.GetComponent<UnitMonobehaviour>());

            unitInstaller = Instantiate(_turrelmanPrefab, new Vector3(_rand.Next(-3, 3), 0, _rand.Next(1, 7)), Quaternion.Euler(0, 180, 0));
            unitInstaller.Init(new UnitData(1, 3, 3, new HealthData(4)));
            _allUnitsInfo.Add(unitInstaller.GetComponent<UnitMonobehaviour>());

            unitInstaller = Instantiate(_gunmanPrefab, new Vector3(_rand.Next(-3, 3), 0, _rand.Next(1, 7)), Quaternion.Euler(0, 180, 0));
            unitInstaller.Init(new UnitData(1, 3, 2, new HealthData(3)));
            _allUnitsInfo.Add(unitInstaller.GetComponent<UnitMonobehaviour>());

            unitInstaller = Instantiate(_cowboyPrefab, new Vector3(_rand.Next(-3, 3), 0, _rand.Next(1, 7)), Quaternion.Euler(0, 180, 0));
            unitInstaller.Init(new UnitData(4, 3, 2, new HealthData(2)));
            _allUnitsInfo.Add(unitInstaller.GetComponent<UnitMonobehaviour>());
        }

        private void InjectPrefabs()
        {
            foreach (var unit in _allUnitsInfo.List)
            {
                Container.InjectGameObject(unit.gameObject);
            }
        }
    }
}