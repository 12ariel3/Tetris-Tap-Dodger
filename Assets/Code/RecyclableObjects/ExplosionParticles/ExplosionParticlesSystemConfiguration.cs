using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.ExplosionParticles
{
    [CreateAssetMenu(menuName = "Projectile/ExplosionParticleSystemConfiguration", fileName = "ExplosionParticleSystemConfiguration")]
    public class ExplosionParticlesSystemConfiguration : ScriptableObject
    {
        [SerializeField] private ParticleSystemMediator[] _specialExplosionPrefabs;
        [SerializeField] private ParticleSystemMediator[] _moonWalkerExplosionPrefabs;
        [SerializeField] private ParticleSystemMediator[] _atlansAbyssExplosionPrefabs;
        [SerializeField] private ParticleSystemMediator[] _villaSoldatiExplosionPrefabs;
        [SerializeField] private ParticleSystemMediator[] _raklionExplosionPrefabs;
        [SerializeField] private ParticleSystemMediator[] _acheronExplosionPrefabs;



        public ParticleSystemMediator[] GetArrayById(string id)
        {
            switch (id)
            {
                case "Moon Walker":

                    ParticleSystemMediator[] definitiveArray = new ParticleSystemMediator[_specialExplosionPrefabs.Length +
                                                                                   _moonWalkerExplosionPrefabs.Length];
                    Array.Copy(_specialExplosionPrefabs, definitiveArray, _specialExplosionPrefabs.Length);
                    Array.Copy(_moonWalkerExplosionPrefabs, 0, definitiveArray, _specialExplosionPrefabs.Length,
                                                                                _moonWalkerExplosionPrefabs.Length);

                    return definitiveArray;

                case "Atlans Abyss":

                    ParticleSystemMediator[] definitiveArray2 = new ParticleSystemMediator[_specialExplosionPrefabs.Length +
                                                                                   _atlansAbyssExplosionPrefabs.Length];
                    Array.Copy(_specialExplosionPrefabs, definitiveArray2, _specialExplosionPrefabs.Length);
                    Array.Copy(_atlansAbyssExplosionPrefabs, 0, definitiveArray2, _specialExplosionPrefabs.Length,
                                                                                _atlansAbyssExplosionPrefabs.Length);

                    return definitiveArray2;

                case "Villa Soldati":

                    ParticleSystemMediator[] definitiveArray3 = new ParticleSystemMediator[_specialExplosionPrefabs.Length +
                                                                                   _villaSoldatiExplosionPrefabs.Length];
                    Array.Copy(_specialExplosionPrefabs, definitiveArray3, _specialExplosionPrefabs.Length);
                    Array.Copy(_villaSoldatiExplosionPrefabs, 0, definitiveArray3, _specialExplosionPrefabs.Length,
                                                                                _villaSoldatiExplosionPrefabs.Length);

                    return definitiveArray3;

                case "Raklion":

                    ParticleSystemMediator[] definitiveArray4 = new ParticleSystemMediator[_specialExplosionPrefabs.Length +
                                                                                   _raklionExplosionPrefabs.Length];
                    Array.Copy(_specialExplosionPrefabs, definitiveArray4, _specialExplosionPrefabs.Length);
                    Array.Copy(_raklionExplosionPrefabs, 0, definitiveArray4, _specialExplosionPrefabs.Length,
                                                                                _raklionExplosionPrefabs.Length);

                    return definitiveArray4;

                case "Acheron":

                    ParticleSystemMediator[] definitiveArray5 = new ParticleSystemMediator[_specialExplosionPrefabs.Length +
                                                                                   _acheronExplosionPrefabs.Length];
                    Array.Copy(_specialExplosionPrefabs, definitiveArray5, _specialExplosionPrefabs.Length);
                    Array.Copy(_acheronExplosionPrefabs, 0, definitiveArray5, _specialExplosionPrefabs.Length,
                                                                                _acheronExplosionPrefabs.Length);

                    return definitiveArray5;
            }

            return _specialExplosionPrefabs;
        }
    }
}