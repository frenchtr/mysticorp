using System.Collections.Generic;
using UnityEngine;

namespace MystiCorp.Runtime.Portal
{
    public class Portal : MonoBehaviour
    {
        [SerializeField]
        private List<PortalWave> handcraftedWaves;
        [SerializeField]
        private Transform spawnpoint;
        private List<GameObject> activeCritters;

        private int waveIndex;

        private void StartNextWave()
        {
            waveIndex++;

            if (waveIndex >= handcraftedWaves.Count) return;

            var wave = handcraftedWaves[waveIndex];

            activeCritters.Clear();

            foreach (var critter in wave.critters)
            {
                var newCritter = Instantiate(critter, spawnpoint.position, Quaternion.identity);
                activeCritters.Add(newCritter);
            }
        }

        private void Start()
        {
            activeCritters = new();

            waveIndex = -1;
            StartNextWave();
        }

        private void Update()
        {
            // if no active critters exist
            if (!activeCritters.Exists(critter => critter != null))
            {
                StartNextWave();
            }
        }
    }
}
