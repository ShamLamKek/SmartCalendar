﻿using System;
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
        #endregion

        public List<string> Time;
        public List<string> Lesson;
        public List<string> Classroom;
        public List<string> Teacher;

        public Day() { }
        

        public Day(List<string> time, List<string> lesson, List<string> classroom, List<string> teacher) 
        {
            Time = time;
            Lesson = lesson;
            Classroom = classroom;
            Teacher = teacher;
        
        }
        
    }
}