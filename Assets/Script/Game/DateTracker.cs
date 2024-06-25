using UnityEngine;

public class DateTracker : MonoBehaviour
{
    [SerializeField]
    private int currentWeek;
    [SerializeField]
    private int currentMonth;
    [SerializeField]
    private int currentYear;

    public void nextWeek(){
        currentWeek += 1;

        if(currentWeek > 4){

            currentWeek = 1;
            currentMonth += 1;

            if(currentMonth > 12){
                currentMonth = 1;
                currentYear += 1;
            }
        }
    }
}
