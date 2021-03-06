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
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(new List<string>() { "headless" });
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            IWebDriver bs = new OpenQA.Selenium.Chrome.ChromeDriver(chromeDriverService, chromeOptions);
            bs.Navigate().GoToUrl("http://bgu.ru/telek/timetable.aspx?id=30250");



            Day Day = new Day();

            DayController.AddToList(bs, Day.TimeID, Day.Time);
            DayController.AddToList(bs, Day.LessonID, Day.Lesson);
            DayController.AddToList(bs, Day.ClassroomID, Day.Classroom);
            DayController.AddToList(bs, Day.TeacherID, Day.Teacher);
            for (int i = 0; i < Day.Time.Count; i++)
            {
                Console.WriteLine(Day.Time[i] + " " + Day.Lesson[i] + " " + Day.Classroom[i] + " " + Day.Teacher[i]);
            
            }



        }
        
    }

    
}
