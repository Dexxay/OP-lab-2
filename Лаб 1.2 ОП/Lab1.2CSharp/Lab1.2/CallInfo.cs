using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1._2
{
    class CallInfo
    {
        private string phoneNumber;
        private string startTime;
        private string endTime;


        public CallInfo(string phoneNumber, string startTime, string endTime)
        {
            this.phoneNumber = phoneNumber;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public  string GetPhoneNumber()
        {
            return phoneNumber;
        }

        public string GetStartMinute()
        {
            return startTime;
        }

        public string GetEndMinute()
        {
            return endTime;
        }



        public int Duration
        {
            get
            {
                int startMinute = ConvertStringTimeToMinutes(startTime);
                int endMinute = ConvertStringTimeToMinutes(endTime);

                if (startMinute > endMinute)
                {
                    return endMinute + 24 * 60 - startMinute;
                }
                return endMinute - startMinute;
            }
        }

        public float Payment
        {
            get
            {
                float price = 0;
                int totalDurationNight = 0;
                int totalDurationDay = 0;
                //int duration = Duration;
                float priceDay = 1.5f;
                float priceNight = 0.9f;

                const int zeroMinuteOfTheDay = 0;
                const int lastMinuteOfTheDay = 24 * 60;

                int startT = ConvertStringTimeToMinutes(startTime);
                int endT = ConvertStringTimeToMinutes(endTime);

                if (startT <= endT)
                {
                    GetNightAndDayDuration(startT, endT, out totalDurationNight, out totalDurationDay);
                }
                else
                {
                    GetNightAndDayDuration(startT, lastMinuteOfTheDay, out int firstDurationNight, out int firstDurationDay);
                    GetNightAndDayDuration(zeroMinuteOfTheDay, endT, out int secondDurationNight, out int secondDurationDay);
                    totalDurationDay = firstDurationDay + secondDurationDay;
                    totalDurationNight = firstDurationNight + secondDurationNight;
                }

                price = totalDurationNight * priceNight + totalDurationDay * priceDay;
                return price;
            }
        }

        public static bool TryCreateFromString(string line, out CallInfo result)
        {
            string[] elements = line.Split(' ');
            if (elements.Length != 3)
            {
                result = null;
                return false;
            }
            else if (!IsPhoneNumberValid(elements[0]))
            {
                result = null;
                return false;
            }
            else if (!IsTimeValid(elements[1]) || !IsTimeValid(elements[2]))
            {
                result = null;
                return false;
            }

            result = new CallInfo(elements[0], elements[1], elements[2]);
            return true;
        }

        private static bool IsPhoneNumberValid(string number)
        {
            if (number.Length != 13)
            {
                return false;
            }
            if (number[0] != '+')
            {
                return false;
            }
            if (number[3] != '0')
            {
                return false;
            }
            for (int i = 1; i < number.Length; i++)
            {
                if (!Char.IsDigit(number[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsTimeValid(string time)
        {
            if (time.Length != 5 || time[2] != ':')
            {
                return false;
            }
            for (int i = 0; i < time.Length; i++)
            {
                if (i != 2 && !char.IsDigit(time[i]))
                {
                    return false;
                }
            }
            string[] digits = time.Split(':');
            int hours = Convert.ToInt32(digits[0]);
            int minutes = Convert.ToInt32(digits[1]);
            if (hours > 23 || minutes > 59)
            {
                return false;
            }
            return true;
        }

        private static int ConvertStringTimeToMinutes(string time)
        {
            string[] digits = time.Split(':');
            int hours = Convert.ToInt32(digits[0]);
            int minutes = Convert.ToInt32(digits[1]);
            return hours * 60 + minutes;
        }

        private static void GetNightAndDayDuration(int startT, int endT, out int durationNight, out int durationDay)
        {
            durationNight = 0;
            durationDay = 0;

            int nightTime = 20 * 60;
            int dayTime = 9 * 60;
            
            if (startT == endT)
            {
                durationNight = 0;
                durationDay = 0;
            }
            else if (startT < dayTime && endT < dayTime)
            {
                durationNight = endT - startT;
            }
            else if (startT < dayTime && endT > dayTime && endT < nightTime)
            {
                durationNight = dayTime - startT;
                durationDay = endT - dayTime;
            }
            else if (startT < dayTime && endT >= nightTime)
            {
                durationNight = dayTime - startT + endT - nightTime;
                durationDay = nightTime - dayTime;
            }
            else if (startT >= dayTime && startT < nightTime && endT < nightTime)
            {
                durationDay = endT - startT;
            }
            else if (startT >= dayTime && startT < nightTime && endT >= nightTime)
            {
                durationDay = nightTime - startT;
                durationNight = endT - nightTime;
            }
            else if (startT >= nightTime)
            {
                durationNight = endT - startT;
            }
        }

    }
}
