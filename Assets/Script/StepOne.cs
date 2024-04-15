using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Script {
    public class StepOne : MonoBehaviour {
        public GameObject TriangleYellow;
        public GameObject TriangleOrange;
        public Tilemap Tilemap;
        public Vector3Int YellowStart;
        public Vector3Int OrangeStart;
        public TileBase YellowSmartTile;
        public TileBase OrangeSmartTile;
        public int Length = 4;
        public bool Step;
        public AudioSource AudioSource;
        private void Awake() {
            YellowStart = Tilemap.WorldToCell(TriangleYellow.transform.position);
            OrangeStart = Tilemap.WorldToCell(TriangleOrange.transform.position);
        }

        public void StepNow() {
            Step = true;
        }
        public void Start() {
            Steper();
        }

        public async void Steper() {
            Step = false;
            await StepNext();
            for (int i = 0; i < Length; i++) {
                AudioSource.Play();
                Tilemap.SetTile(YellowStart + new Vector3Int(0,i,0),YellowSmartTile);
                Tilemap.SetTile(OrangeStart + new Vector3Int(0,i,0),OrangeSmartTile);
                await UniTask.WaitForSeconds(1);
            }
        }

        public async UniTask StepNext() {
            
            await UniTask.WaitUntil(()=>Step);
            Step = false;
        }
        
    }
}