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
        #endregion

        public List<TimeSpan> Time;
        public List<string> Lesson;
        public List<string> Classroom;
        public List<string> Teacher;

        public List<int> daysStart;
        public List<int> daysEnd;
        public Day()
        {
            Time =  new List<TimeSpan>();
            Lesson =  new List<string>();
            Classroom = new List<string>();
            Teacher = new List<string>();
            daysStart = new List<int>();
            daysEnd = new List<int>();
        }
    }
}
