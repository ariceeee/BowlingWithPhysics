using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] pins;

    private void Start()
    {
        // find all objs of type FallTrigger
        // note for later: for some reason unity does not like this line
        pins = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include);


        // then loop over array of pins and add the
        // incrementscore function as their listener
        foreach (FallTrigger pin in pins)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
}
