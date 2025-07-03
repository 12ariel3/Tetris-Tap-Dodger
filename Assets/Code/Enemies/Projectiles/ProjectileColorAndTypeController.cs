using UnityEngine;

namespace Assets.Code.Enemies.Projectiles
{
    public class ProjectileColorAndTypeController : MonoBehaviour
    {
        [SerializeField] SpriteRenderer _projectileSpriteRenderer;
        [SerializeField] ParticleSystem _normalParticleSystem;
        [SerializeField] ParticleSystem _fireParticleSystem;
        [SerializeField] ParticleSystem _poisonParticleSystem;
        [SerializeField] ParticleSystem _iceParticleSystem;
        [SerializeField] ParticleSystem _waterParticleSystem;
        [SerializeField] ParticleSystem _electricParticleSystem;
        [SerializeField] ParticleSystem _ghostParticleSystem;
        [SerializeField] ParticleSystem _rainbowParticleSystem;


        [SerializeField] Color _normalColor;
        [SerializeField] Color _fireColor;
        [SerializeField] Color _poisonColor;
        [SerializeField] Color _iceColor;
        [SerializeField] Color _waterColor;
        [SerializeField] Color _electricColor;
        [SerializeField] Color _ghostColor;
        [SerializeField] Color _rainbowColor;
        private int _colorAndType;
        public string _colorAndTypeString;

        public void Configure(int colorAndType)
        {
            _colorAndType = colorAndType;
            TurnOffAllParticleSystem();
            FilterColorAndType(_colorAndType);
        }


        private void TurnOffAllParticleSystem()
        {
            _normalParticleSystem.gameObject.SetActive(false);
            _fireParticleSystem.gameObject.SetActive(false);
            _poisonParticleSystem.gameObject.SetActive(false);
            _iceParticleSystem.gameObject.SetActive(false);
            _waterParticleSystem.gameObject.SetActive(false);
            _electricParticleSystem.gameObject.SetActive(false);
            _ghostParticleSystem.gameObject.SetActive(false);
            _rainbowParticleSystem.gameObject.SetActive(false);
        }

        private void FilterColorAndType(int colorAndType)
        {
            Color brickColor = _normalColor;
            int RandomNumber = Random.Range(0, 100);

            switch (_colorAndType)
            {
                case 0:
                    brickColor = _normalColor;
                    _projectileSpriteRenderer.color = brickColor;
                    _normalParticleSystem.gameObject.SetActive(true);
                    _colorAndTypeString = "Normal";
                    return;

                case 1:
                    brickColor = _fireColor;
                    _projectileSpriteRenderer.color = brickColor;
                    _fireParticleSystem.gameObject.SetActive(true);
                    _colorAndTypeString = "Fire";
                    return;

                case 2:
                    FilterMoonWalker(brickColor, RandomNumber);
                    return;

                case 3:
                    brickColor = _poisonColor;
                    _projectileSpriteRenderer.color = brickColor;
                    _poisonParticleSystem.gameObject.SetActive(true);
                    _colorAndTypeString = "Poison";
                    return;

                case 4:
                    FilterPreAtlansAbyss(brickColor, RandomNumber);
                    return;

                case 5:
                    brickColor = _iceColor;
                    _projectileSpriteRenderer.color = brickColor;
                    _iceParticleSystem.gameObject.SetActive(true);
                    _colorAndTypeString = "Ice";
                    return;

                case 6:
                    FilterAtlansAbyss(brickColor, RandomNumber);
                    return;

                case 7:
                    brickColor = _waterColor;
                    _projectileSpriteRenderer.color = brickColor;
                    _waterParticleSystem.gameObject.SetActive(true);
                    _colorAndTypeString = "Water";
                    return;

                case 8:
                    FilterPreVillaSoldati(brickColor, RandomNumber);
                    return;

                case 9:
                    brickColor = _electricColor;
                    _projectileSpriteRenderer.color = brickColor;
                    _electricParticleSystem.gameObject.SetActive(true);
                    _colorAndTypeString = "Electric";
                    return;

                case 10:
                    FilterVillaSoldati(brickColor, RandomNumber);
                    return;

                case 11:
                    brickColor = _ghostColor;
                    _projectileSpriteRenderer.color = brickColor;
                    _ghostParticleSystem.gameObject.SetActive(true);
                    _colorAndTypeString = "Ghost";
                    return;

                case 12:
                    FilterPreRaklion(brickColor, RandomNumber);
                    return;

                case 13:
                    brickColor = _rainbowColor;
                    _projectileSpriteRenderer.color = brickColor;
                    _rainbowParticleSystem.gameObject.SetActive(true);
                    _colorAndTypeString = "Rainbow";
                    return;

                case 14:
                    FilterRaklion(brickColor, RandomNumber);
                    return;

                case 15:
                    FilterAcheron(brickColor, RandomNumber);
                    return;
            }
           
        }

        private void FilterMoonWalker(Color brickColor, int RandomNumber)
        {
            if (RandomNumber <= 50)
            {
                brickColor = _normalColor;
                _projectileSpriteRenderer.color = brickColor;
                _normalParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Normal";
                return;
            }
            else
            {
                brickColor = _fireColor;
                _projectileSpriteRenderer.color = brickColor;
                _fireParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Fire";
                return;
            }
        }

        private void FilterPreAtlansAbyss(Color brickColor, int RandomNumber) 
        {
            if (RandomNumber < 33)
            {
                brickColor = _normalColor;
                _projectileSpriteRenderer.color = brickColor;
                _normalParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Normal";
                return;
            }
            else if (RandomNumber >= 33 && RandomNumber < 66)
            {
                brickColor = _fireColor;
                _projectileSpriteRenderer.color = brickColor;
                _fireParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Fire";
                return;
            }
            else
            {
                brickColor = _poisonColor;
                _projectileSpriteRenderer.color = brickColor;
                _poisonParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Poison";
                return;
            }
        }

        private void FilterAtlansAbyss(Color brickColor, int RandomNumber)
        {
            if (RandomNumber < 25)
            {
                brickColor = _normalColor;
                _projectileSpriteRenderer.color = brickColor;
                _normalParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Normal";
                return;
            }
            else if (RandomNumber >= 25 && RandomNumber < 50)
            {
                brickColor = _fireColor;
                _projectileSpriteRenderer.color = brickColor;
                _fireParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Fire";
                return;
            }
            else if (RandomNumber >= 50 && RandomNumber < 75)
            {
                brickColor = _poisonColor;
                _projectileSpriteRenderer.color = brickColor;
                _poisonParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Poison";
                return;
            }
            else
            {
                brickColor = _iceColor;
                _projectileSpriteRenderer.color = brickColor;
                _iceParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Ice";
                return;
            }
        }

        private void FilterPreVillaSoldati(Color brickColor, int RandomNumber)
        {
            if (RandomNumber < 20)
            {
                brickColor = _normalColor;
                _projectileSpriteRenderer.color = brickColor;
                _normalParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Normal";
                return;
            }
            else if (RandomNumber >= 20 && RandomNumber < 40)
            {
                brickColor = _fireColor;
                _projectileSpriteRenderer.color = brickColor;
                _fireParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Fire";
                return;
            }
            else if (RandomNumber >= 40 && RandomNumber < 60)
            {
                brickColor = _poisonColor;
                _projectileSpriteRenderer.color = brickColor;
                _poisonParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Poison";
                return;
            }
            else if (RandomNumber >= 60 && RandomNumber < 80)
            {
                brickColor = _iceColor;
                _projectileSpriteRenderer.color = brickColor;
                _iceParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Ice";
                return;
            }
            else
            {
                brickColor = _waterColor;
                _projectileSpriteRenderer.color = brickColor;
                _waterParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Water";
                return;
            }
        }

        private void FilterVillaSoldati(Color brickColor, int RandomNumber)
        {
            if (RandomNumber < 16)
            {
                brickColor = _normalColor;
                _projectileSpriteRenderer.color = brickColor;
                _normalParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Normal";
                return;
            }
            else if (RandomNumber >= 16 && RandomNumber < 33)
            {
                brickColor = _fireColor;
                _projectileSpriteRenderer.color = brickColor;
                _fireParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Fire";
                return;
            }
            else if (RandomNumber >= 33 && RandomNumber < 50)
            {
                brickColor = _poisonColor;
                _projectileSpriteRenderer.color = brickColor;
                _poisonParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Poison";
                return;
            }
            else if (RandomNumber >= 50 && RandomNumber < 66)
            {
                brickColor = _iceColor;
                _projectileSpriteRenderer.color = brickColor;
                _iceParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Ice";
                return;
            }
            else if (RandomNumber >= 66 && RandomNumber < 82)
            {
                brickColor = _waterColor;
                _projectileSpriteRenderer.color = brickColor;
                _waterParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Water";
                return;
            }
            else
            {
                brickColor = _electricColor;
                _projectileSpriteRenderer.color = brickColor;
                _electricParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Electric";
                return;
            }
        }

        private void FilterPreRaklion(Color brickColor, int RandomNumber)
        {
            if (RandomNumber < 14)
            {
                brickColor = _normalColor;
                _projectileSpriteRenderer.color = brickColor;
                _normalParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Normal";
                return;
            }
            else if (RandomNumber >= 14 && RandomNumber < 28)
            {
                brickColor = _fireColor;
                _projectileSpriteRenderer.color = brickColor;
                _fireParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Fire";
                return;
            }
            else if (RandomNumber >= 28 && RandomNumber < 42)
            {
                brickColor = _poisonColor;
                _projectileSpriteRenderer.color = brickColor;
                _poisonParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Poison";
                return;
            }
            else if (RandomNumber >= 42 && RandomNumber < 56)
            {
                brickColor = _iceColor;
                _projectileSpriteRenderer.color = brickColor;
                _iceParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Ice";
                return;
            }
            else if (RandomNumber >= 56 && RandomNumber < 70)
            {
                brickColor = _waterColor;
                _projectileSpriteRenderer.color = brickColor;
                _waterParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Water";
                return;
            }
            else if (RandomNumber >= 70 && RandomNumber < 84)
            {
                brickColor = _electricColor;
                _projectileSpriteRenderer.color = brickColor;
                _electricParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Electric";
                return;
            }
            else
            {
                brickColor = _ghostColor;
                _projectileSpriteRenderer.color = brickColor;
                _ghostParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Ghost";
                return;
            }
        }

        private void FilterRaklion(Color brickColor, int RandomNumber)
        {
            if (RandomNumber < 12)
            {
                brickColor = _normalColor;
                _projectileSpriteRenderer.color = brickColor;
                _normalParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Normal";
                return;
            }
            else if (RandomNumber >= 12 && RandomNumber < 25)
            {
                brickColor = _fireColor;
                _projectileSpriteRenderer.color = brickColor;
                _fireParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Fire";
                return;
            }
            else if (RandomNumber >= 25 && RandomNumber < 37)
            {
                brickColor = _poisonColor;
                _projectileSpriteRenderer.color = brickColor;
                _poisonParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Poison";
                return;
            }
            else if (RandomNumber >= 37 && RandomNumber < 50)
            {
                brickColor = _iceColor;
                _projectileSpriteRenderer.color = brickColor;
                _iceParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Ice";
                return;
            }
            else if (RandomNumber >= 50 && RandomNumber < 62)
            {
                brickColor = _waterColor;
                _projectileSpriteRenderer.color = brickColor;
                _waterParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Water";
                return;
            }
            else if (RandomNumber >= 62 && RandomNumber < 75)
            {
                brickColor = _electricColor;
                _projectileSpriteRenderer.color = brickColor;
                _electricParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Electric";
                return;
            }
            else if (RandomNumber >= 75 && RandomNumber < 87)
            {
                brickColor = _ghostColor;
                _projectileSpriteRenderer.color = brickColor;
                _ghostParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Ghost";
                return;
            }
            else
            {
                brickColor = _rainbowColor;
                _projectileSpriteRenderer.color = brickColor;
                _rainbowParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Rainbow";
                return;
            }
        }

        private void FilterAcheron(Color brickColor, int RandomNumber)
        {
            if (RandomNumber < 12)
            {
                brickColor = _normalColor;
                _projectileSpriteRenderer.color = brickColor;
                _normalParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Normal";
                return;
            }
            else if (RandomNumber >= 12 && RandomNumber < 25)
            {
                brickColor = _fireColor;
                _projectileSpriteRenderer.color = brickColor;
                _fireParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Fire";
                return;
            }
            else if (RandomNumber >= 25 && RandomNumber < 37)
            {
                brickColor = _poisonColor;
                _projectileSpriteRenderer.color = brickColor;
                _poisonParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Poison";
                return;
            }
            else if (RandomNumber >= 37 && RandomNumber < 50)
            {
                brickColor = _iceColor;
                _projectileSpriteRenderer.color = brickColor;
                _iceParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Ice";
                return;
            }
            else if (RandomNumber >= 50 && RandomNumber < 62)
            {
                brickColor = _waterColor;
                _projectileSpriteRenderer.color = brickColor;
                _waterParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Water";
                return;
            }
            else if (RandomNumber >= 62 && RandomNumber < 75)
            {
                brickColor = _electricColor;
                _projectileSpriteRenderer.color = brickColor;
                _electricParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Electric";
                return;
            }
            else if (RandomNumber >= 75 && RandomNumber < 87)
            {
                brickColor = _ghostColor;
                _projectileSpriteRenderer.color = brickColor;
                _ghostParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Ghost";
                return;
            }
            else
            {
                brickColor = _rainbowColor;
                _projectileSpriteRenderer.color = brickColor;
                _rainbowParticleSystem.gameObject.SetActive(true);
                _colorAndTypeString = "Rainbow";
                return;
            }
        }

         
    }
}