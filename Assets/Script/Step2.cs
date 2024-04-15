using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace Script {
    public class Step2 : MonoBehaviour {
        public Button Step2Bnt;
        public GameObject TriangleYellow;
        public Tilemap Tilemap;
        public Vector3Int YellowStart;
        public TileBase YellowSmartTile;
        public TileBase OrangeSmartTile;
        public TileBase[] TileSet;
        public bool Step;
        public AudioSource AudioSource;
        
        private void Awake() {
            YellowStart = Tilemap.WorldToCell(TriangleYellow.transform.position);
            TileSet = new[] { YellowSmartTile, YellowSmartTile,OrangeSmartTile,OrangeSmartTile,YellowSmartTile,YellowSmartTile };
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
            for (int i = 0; i < TileSet.Length; i++) {
                AudioSource.Play();
                Tilemap.SetTile(YellowStart + new Vector3Int(i,0,0),TileSet[i]);
                await UniTask.WaitForSeconds(1);
            }
        }

        public async UniTask StepNext() {
            
            await UniTask.WaitUntil(()=>Step);
            Step = false;
        }
        
    }
}