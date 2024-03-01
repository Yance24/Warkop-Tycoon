public static class InGameTime
{
    static int seconds;
    static int minutes;
    static int hours;

    public static int Seconds{
        get{
            return seconds;
        }
        set{
            if(value >= 60){
                seconds = 0;
                Minutes++;
            }else seconds = value;
        }
    }

    public static int Minutes{
        get{
            return minutes;
        }
        set{
            if(value >= 60){
                minutes = 0;
                Hours++;
            }else minutes = value;
        }
    }

    public static int Hours{
        get{
            return hours;
        }
        set{
            hours = value;
        }
    }

    public static void resetTime(){
        seconds = 0;
        minutes = 0;
        hours = 0;
    }

    public static string getTime(){
        string second;
        string minute;
        string hour;

        if(seconds >= 10) second = ""+seconds;
        else second = "0"+seconds;

        if(minutes >= 10) minute = ""+minutes;
        else minute = "0"+minutes;

        if(hours >= 10) hour = ""+hours;
        else hour = "0"+hours;

        return hour+":"+minute+":"+second;
    }
}
