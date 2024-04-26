using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    //private int allCoints;
    [SerializeField] private TextMeshProUGUI countBonusText;
    [SerializeField] private GameObject AllBonusText;

    void Start()
    {
        //allCoints = FindObjectsOfType<Coin>().Length;

        //Debug.Log(allCoints + " моненты в уровне");

        //Progress.Instance.AllCoints += allCoints;

        //Debug.Log(Progress.Instance.AllCoints + " все моненты");
        
        _ = SetCountTextAsync();
        AllBonusText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            var bonus = other.gameObject.GetComponent<Coin>();

            bonus?.InteractiveActivation();

            Progress.Instance.CollectedCoins++;

            _ = SetCountTextAsync();
        }
    }

    private async Task SetCountTextAsync()
    {
        countBonusText.text = ": " + Progress.Instance.CollectedCoins.ToString();

        if (Progress.Instance.CollectedCoins == Progress.Instance.AllCoints)
        {
            AllBonusText.SetActive(true);

            await Task.Delay(3000);

            AllBonusText.SetActive(false);
        }

    }
}
