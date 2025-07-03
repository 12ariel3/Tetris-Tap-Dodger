using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Linq;
using UnityEngine.Events;
using TMPro;
using Assets.Code.Core;
using Assets.Code.Common.Level;
using Assets.Code.Common.GemsData;
using Assets.Code.Common.Score;
using Assets.Code.Common.Events;
using Assets.Code.Common.EnergyData;
using Assets.Code.MusicAndSound;
using Assets.Code.Common.AdsData;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class FortuneWheelViewRemixed : MonoBehaviour, EventObserver
{
    [SerializeField] private Button _backgroundBackToMenuButton;

    [Header("Game Objects for some elements")]
    [SerializeField] private Button PaidTurnButton;                 // This button is showed when you can turn the wheel for coins
    [SerializeField] private GameObject Circle;                     // Rotatable GameObject on scene with reward objects


    private bool _isStarted;                    // Flag that the wheel is spinning

    [Header("Params for each sector")]
    [SerializeField] private FortuneWheelSectora[] Sectors;      // All sectors objects

    private float _finalAngle;                  // The final angle is needed to calculate the reward
    private float _startAngle;                  // The first time start angle equals 0 but the next time it equals the last final angle
    private float _currentLerpRotationTime;     // Needed for spinning animation
    private int _playerLevel;


    private FortuneWheelSectora _finalSector;

    private void Awake()
    {
        PaidTurnButton.onClick.AddListener(TurnWheelButtonClick);
    }

    private void Start()
    {
        _playerLevel = ServiceLocator.Instance.GetService<LevelSystem>().GetCurrentLevel();
        ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.LevelUp, this);
        ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.AdWatched, this);
        // Show sector reward value in text object if it's set
        foreach (var sector in Sectors)
        {
            if (sector.ValueTextObject != null)
            {
                SetAllFinalValuesForEverySection(sector);
            }
        }
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.LevelUp, this);
        ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.AdWatched, this);
    }

    private void SetAllFinalValuesForEverySection(FortuneWheelSectora sector)
    {
        int rewardValue;
        switch (sector.NameOfTheObject)
        {
            case "Soul":
                rewardValue = ((sector.RewardValue * _playerLevel * _playerLevel) / 2);
                sector.FinalRewardValue = rewardValue;
                sector.ValueTextObject.GetComponent<TextMeshProUGUI>().text = rewardValue.ToString();
                return;

            case "Exp":
                int currentMaxExp = ServiceLocator.Instance.GetService<LevelSystem>().GetCurrentMaxExp();
                rewardValue = currentMaxExp / sector.RewardValue;
                sector.FinalRewardValue = rewardValue;
                sector.ValueTextObject.GetComponent<TextMeshProUGUI>().text = rewardValue.ToString();
                return;

            case "Gem":
                rewardValue = ((sector.RewardValue * _playerLevel * _playerLevel) / 7);
                sector.FinalRewardValue = rewardValue;
                sector.ValueTextObject.GetComponent<TextMeshProUGUI>().text = rewardValue.ToString();
                return;

            case "Energy":
                rewardValue = sector.RewardValue + (_playerLevel/4);
                sector.FinalRewardValue = rewardValue;
                sector.ValueTextObject.GetComponent<TextMeshProUGUI>().text = rewardValue.ToString();
                return;
        }
    }



    private void TurnWheelForCoins() { TurnWheel(); }

    private void TurnWheel()
    {
        _backgroundBackToMenuButton.gameObject.SetActive(false);

        _currentLerpRotationTime = 0f;

        // All sectors angles
        int[] sectorsAngles = new int[Sectors.Length];

        // Fill the necessary angles (for example if we want to have 12 sectors we need to fill the angles with 30 degrees step)
        // It's recommended to use the EVEN sectors count (2, 4, 6, 8, 10, 12, etc)
        for (int i = 1; i <= Sectors.Length; i++)
        {
            sectorsAngles[i - 1] = 360 / Sectors.Length * i;
        }

        //int cumulativeProbability = Sectors.Sum(sector => sector.Probability);

        double rndNumber = UnityEngine.Random.Range(1, Sectors.Sum(sector => sector.Probability));

        // Calculate the propability of each sector with respect to other sectors
        int cumulativeProbability = 0;
        // Random final sector accordingly to probability
        int randomFinalAngle = sectorsAngles[0];
        _finalSector = Sectors[0];

        for (int i = 0; i < Sectors.Length; i++)
        {
            cumulativeProbability += Sectors[i].Probability;

            if (rndNumber <= cumulativeProbability)
            {
                // Choose final sector
                randomFinalAngle = sectorsAngles[i];
                _finalSector = Sectors[i];
                break;
            }
        }

        int fullTurnovers = 5;

        // Set up how many turnovers our wheel should make before stop
        _finalAngle = fullTurnovers * 360 + randomFinalAngle;

        // Stop the wheel
        _isStarted = true;
    }

    public void TurnWheelButtonClick()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("NotEnough");
            var NotEnoughEventData = new NotEnoughEventData("NotConnection", GetInstanceID());
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(NotEnoughEventData);
        }
        else
        {
            if (ServiceLocator.Instance.GetService<AdsSystem>().GetIfIsAdsRemoved())
            {
                ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("SpinWheel");
                TurnWheelForCoins();
            }
        }
    }

    private void ShowTurnButtons()
    {
        ShowPaidTurnButton();

        if (_isStarted)
            DisablePaidTurnButton();    // Make button non interactable if user has not enough money for the turn of if wheel is turning right now
        else
            EnablePaidTurnButton(); // Can make paid turn right now
    }

    private void Update()
    {
        // We need to show TURN FOR FREE button or TURN FOR COINS button
        ShowTurnButtons();

        if (!_isStarted)
            return;

        // Animation time
        float maxLerpRotationTime = 4f;

        // increment animation timer once per frame
        _currentLerpRotationTime += Time.deltaTime;

        // If the end of animation
        if (_currentLerpRotationTime > maxLerpRotationTime || Circle.transform.eulerAngles.z == _finalAngle)
        {
            _currentLerpRotationTime = maxLerpRotationTime;
            _isStarted = false;
            _startAngle = _finalAngle % 360;


            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("SpinWheelWin");
            //GiveAwardByAngle ();
            _backgroundBackToMenuButton.gameObject.SetActive(true);


            NotEnoughEventData notEnoughEventData;

            switch (_finalSector.NameOfTheObject)
            {
                case "Gem":
                    SendGemRewards(_finalSector.FinalRewardValue);
                    notEnoughEventData = new NotEnoughEventData("SpinWheelGems", GetInstanceID());
                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(notEnoughEventData);
                    break;

                case "Soul":
                    SendSoulRewards(_finalSector.FinalRewardValue);
                    notEnoughEventData = new NotEnoughEventData("SpinWheelScore", GetInstanceID());
                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(notEnoughEventData);
                    break;

                case "Exp":
                    SendExpRewards(_finalSector.FinalRewardValue);
                    notEnoughEventData = new NotEnoughEventData("SpinWheelExp", GetInstanceID());
                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(notEnoughEventData);
                    break;

                case "Energy":
                    SendEnergyRewards(_finalSector.FinalRewardValue);
                    notEnoughEventData = new NotEnoughEventData("SpinWheelEnergy", GetInstanceID());
                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(notEnoughEventData);
                    break;

                default:
                    break;
            }
        }
        else
        {
            // Calculate current position using linear interpolation
            float t = _currentLerpRotationTime / maxLerpRotationTime;

            // This formulae allows to speed up at start and speed down at the end of rotation.
            // Try to change this values to customize the speed
            t = t * t * t * (t * (6f * t - 15f) + 10f);

            float angle = Mathf.Lerp(_startAngle, _finalAngle, t);
            Circle.transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }
   
    // Hide coins delta text after animation
    private IEnumerator HideCoinsDelta()
    {
        yield return new WaitForSeconds(1f);
    }

    

    private void EnableButton(Button button)
    {
        button.interactable = true;
        button.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
    }

    private void DisableButton(Button button)
    {
        button.interactable = false;
        button.GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
    }

    // Function for more readable calls
    
    private void EnablePaidTurnButton() { EnableButton(PaidTurnButton); }
    private void DisablePaidTurnButton() { DisableButton(PaidTurnButton); }

    private void ShowPaidTurnButton()
    {
        PaidTurnButton.gameObject.SetActive(true);
    }

    private void SendGemRewards(int amount)
    {
        int totalGems = ServiceLocator.Instance.GetService<GemsSystem>().GetTotalGems();
        totalGems += amount;
        ServiceLocator.Instance.GetService<GemsSystem>().SaveTotalGems(totalGems);
        ServiceLocator.Instance.GetService<GemsSystem>().ShowTotalGems();
    }

    private void SendSoulRewards(int amount)
    {
        int totalScore = ServiceLocator.Instance.GetService<ScoreSystem>().GetTotalScore();
        totalScore += amount;
        ServiceLocator.Instance.GetService<ScoreSystem>().SaveTotalScore(totalScore);
        ServiceLocator.Instance.GetService<ScoreSystem>().ShowTotalScore();
    }

    private void SendExpRewards(int amount)
    {
        var fortuneWheelExperienceGainedEventDAta = new FortuneWheelExperienceGainedEventData(amount, GetInstanceID());

        ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(fortuneWheelExperienceGainedEventDAta);
    }

    private void SendEnergyRewards(int amount)
    {
        float totalEnergy = ServiceLocator.Instance.GetService<EnergySystem>().GetTotalEnergy();
        float actualEnergy = ServiceLocator.Instance.GetService<EnergySystem>().GetActualEnergy();

        actualEnergy += amount;
        float energyToSave = Math.Min(actualEnergy, totalEnergy);
        ServiceLocator.Instance.GetService<EnergySystem>().SaveActualEnergy(energyToSave);
        ServiceLocator.Instance.GetService<EnergySystem>().SetEnergyValues();
    }

    public void Process(EventData eventData)
    {
        if(eventData.EventId == EventIds.LevelUp)
        {
            foreach (var sector in Sectors)
            {
                if (sector.ValueTextObject != null)
                {
                    SetAllFinalValuesForEverySection(sector);
                }
            }
        }

        if (eventData.EventId == EventIds.AdWatched)
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("SpinWheel");
            TurnWheelForCoins();
        }
    }
}

/**
 * One sector on the wheel
 */
[Serializable]
public class FortuneWheelSectora : System.Object
{
    [Tooltip("Text object where value will be placed (not required)")]
    public GameObject ValueTextObject;

    public string NameOfTheObject;

    [Tooltip("Value of reward")]
    public int RewardValue = 100;

    [HideInInspector] public int FinalRewardValue;

    [Tooltip("Chance that this sector will be randomly selected")]
    [RangeAttribute(0, 100)]
    public int Probability = 100;

    [Tooltip("Method that will be invoked if this sector will be randomly selected")]
    public UnityEvent RewardCallback;
}

