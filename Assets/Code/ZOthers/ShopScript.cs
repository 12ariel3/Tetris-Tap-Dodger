using Assets.Code.Common.AdsData;
using Assets.Code.Common.Events;
using Assets.Code.Common.GemsData;
using Assets.Code.Common.Level;
using Assets.Code.Common.Score;
using Assets.Code.Core;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using UnityEngine.UI;

namespace Assets.Code.ZOthers
{
    [Serializable]
    public class ConsumableItem
    {
        public string Name;
        public string Id;
        public string Desc;
        public float Price;
    }

    [Serializable]
    public class NonConsumableItem
    {
        public string Name;
        public string Id;
        public string Desc;
        public float Price;
    }


    public class ShopScript : MonoBehaviour, IDetailedStoreListener
    {
        private IStoreController _storeController;

        public ConsumableItem Score;
        public ConsumableItem Gems;
        public NonConsumableItem NoAds;

        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _gemsText;
        [SerializeField] private Image _noAdsBoughtImage;


        void Start()
        {
            SetupBuilder();
            SetParameters();
        }


        private void SetupBuilder()
        {
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            UnityPurchasing.Initialize(this, builder);

            builder.AddProduct(Score.Id, ProductType.Consumable);
            builder.AddProduct(Gems.Id, ProductType.Consumable);
            builder.AddProduct(NoAds.Id, ProductType.NonConsumable);
        }

        private void SetParameters()
        {
            ServiceLocator serviceLocator = ServiceLocator.Instance;
            int playerLevel = serviceLocator.GetService<LevelSystem>().GetCurrentLevel();
            int totalScore = serviceLocator.GetService<ScoreSystem>().GetTotalScore();
            int finalScoreAmount = ((350 * playerLevel * playerLevel) / 2);

            int totalGems = serviceLocator.GetService<GemsSystem>().GetTotalGems();
            int finalGemsAmount = ((120 * playerLevel * playerLevel) / 7);

            _scoreText.SetText(finalScoreAmount.ToString());
            _gemsText.SetText(finalGemsAmount.ToString());

            if (serviceLocator.GetService<AdsSystem>().GetIfIsAdsRemoved())
            {
                _noAdsBoughtImage.gameObject.SetActive(true);
            }
            else
            {
                _noAdsBoughtImage.gameObject.SetActive(false);
            }
        }

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            _storeController = controller;
            CheckNonConsumable(NoAds.Id);
        }

        public void ScoreBtnPressed()
        {
            _storeController.InitiatePurchase(Score.Id);
        }

        public void GemsBtnPressed()
        {
            _storeController.InitiatePurchase(Gems.Id);
        }

        public void NoAdsBtnPressed()
        {
            _storeController.InitiatePurchase(NoAds.Id);
        }

        public void SuscriptionBtnPressed()
        {

        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            var product = purchaseEvent.purchasedProduct;

            if (product.definition.id == Score.Id)
            {
                AddScore();
            }
            else if (product.definition.id == Gems.Id)
            {
                AddGems();
            }
            else if (product.definition.id == NoAds.Id)
            {
                RemoveAds();
            }

            return PurchaseProcessingResult.Complete;
        }


        public void OnInitializeFailed(InitializationFailureReason error)
        {
            Debug.Log(error.ToString());
        }

        public void OnInitializeFailed(InitializationFailureReason error, string message)
        {
            Debug.Log(error.ToString());
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            Debug.Log("purchase Failed :(");
        }


        void CheckNonConsumable(string id)
        {
            if (_storeController != null)
            {
                var product = _storeController.products.WithID(id);
                if (product != null)
                {
                    if (product.hasReceipt)
                    {
                        RemoveAds();
                    }
                    else
                    {
                        ShowAds();
                    }
                }
            }
        }


        public void AddScore()
        {
            ServiceLocator serviceLocator = ServiceLocator.Instance;
            int totalScore = serviceLocator.GetService<ScoreSystem>().GetTotalScore();
            int playerLevel = serviceLocator.GetService<LevelSystem>().GetCurrentLevel();
            int totalAmount = ((350 * playerLevel * playerLevel) / 2);

            int newTotalScore = totalScore + totalAmount;
            serviceLocator.GetService<ScoreSystem>().SaveTotalScore(newTotalScore);
            serviceLocator.GetService<ScoreSystem>().ShowTotalScore();

        }

        private void AddGems()
        {
            ServiceLocator serviceLocator = ServiceLocator.Instance;
            int playerLevel = serviceLocator.GetService<LevelSystem>().GetCurrentLevel();
            int totalGems = serviceLocator.GetService<GemsSystem>().GetTotalGems();
            int finalGemsAmount = ((120 * playerLevel * playerLevel) / 7);

            int newTotalGems = totalGems + finalGemsAmount;
            serviceLocator.GetService<GemsSystem>().SaveTotalGems(newTotalGems);
            serviceLocator.GetService<GemsSystem>().ShowTotalGems();
        }

        private void ShowAds()
        {
            Debug.Log("holi");
        }

        private void RemoveAds()
        {
            ServiceLocator serviceLocator = ServiceLocator.Instance;
            bool adsWereRemoved = serviceLocator.GetService<AdsSystem>().GetIfIsAdsRemoved();
            if (!adsWereRemoved)
            {
                serviceLocator.GetService<AdsSystem>().SaveIfAdsWereRemoved(true);
                serviceLocator.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.AdsWereRemoved));
                _noAdsBoughtImage.gameObject.SetActive(true);
            }

        }

        public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
        {
            throw new NotImplementedException();
        }
    }
}