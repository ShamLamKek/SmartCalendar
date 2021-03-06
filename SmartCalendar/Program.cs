using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SmartCalendar.Controllers;
using SmartCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SmartCalendar
{
    class Program 
    {
        static void Main(string[] args)
        {
            string TimeID = "ContentPlaceHolderArticle_LVrez3_Ltime_";
            string LessonID = "ContentPlaceHolderArticle_LVrez3_Lnamesub_";
            string ClassroomID = "ContentPlaceHolderArticle_LVrez3_Lnameroom_";
            string TeacherID = "ContentPlaceHolderArticle_LVrez3_Lprep_";

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(new List<string>() { "headless" });
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            IWebDriver bs = new OpenQA.Selenium.Chrome.ChromeDriver(chromeDriverService, chromeOptions);
            bs.Navigate().GoToUrl("http://bgu.ru/telek/timetable.aspx?id=30251");



            List<string> Time = new List<string>();
            List<string> Lesson = new List<string>();
            List<string> Classroom = new List<string>();
            List<string> Teacher = new List<string>();

            AddToList(bs, TimeID, Time);
            AddToList(bs, LessonID, Lesson);
            AddToList(bs, ClassroomID, Classroom);
            AddToList(bs, TeacherID, Teacher);
            for (int i = 0; i < Time.Count; i++)
            {
                Console.WriteLine(Time[i] + " " + Lesson[i] + " " + Classroom[i] + " " + Teacher[i]);
            
            }



        }
        public static List<string> AddToList(IWebDriver bs, string id, List<string> list)
        {
            for (int i = 0; i < 30; i++)
            {
                try
                {
                    var day = bs.FindElement(By.Id(id + i));
                    string innerhtml = day.GetAttribute("innerHTML");
                    list.Add(innerhtml);

                }
                catch (Exception)
                {
                }

            }
            return list;
        }
    }

    
}
