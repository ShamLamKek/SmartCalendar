using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCalendar.Models
{
    public class Day
    {
        #region ID
        public static string TimeID = "ContentPlaceHolderArticle_LVrez3_Ltime_";

        public static string LessonID = "ContentPlaceHolderArticle_LVrez3_Lnamesub_";

        public static string ClassroomID = "ContentPlaceHolderArticle_LVrez3_Lnameroom_";

        public static string TeacherID = "ContentPlaceHolderArticle_LVrez3_Lprep_";

        public static string DayID = "ContentPlaceHolderArticle_LVrez3_Lweekday_";

        public static string OddID = "ContentPlaceHolderArticle_LVrez3_Lodd_";
        #endregion
        

        public List<TimeSpan> Time;
        public List<string> Lesson;
        public List<string> Classroom;
        public List<string> Teacher;

        public List<int> daysStart;
        public List<int> daysEnd;

        public List<int> even;
        public List<int> odd;
        public Day()
        {
            Time =  new List<TimeSpan>();
            Lesson =  new List<string>();
            Classroom = new List<string>();
            Teacher = new List<string>();
            daysStart = new List<int>();
            daysEnd = new List<int>();
            even = new List<int>();
            odd = new List<int>();
            
        }
    }
}
