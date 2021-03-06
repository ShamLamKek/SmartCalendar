using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SmartCalendar.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCalendar.Controllers
{
    class DayController
    {

        public Day Day;

        public List<string> AddDays(IWebDriver bs, string id)
        {
            
            for (int i = 0; i < 30; i++)
            {
                try
                {
                    var day = bs.FindElement(By.Id(id+i));
                    string innerhtml = day.GetAttribute("innerHTML");
                    Day.Lesson.Add(innerhtml);

                }
                catch (Exception)
                {
                }

            }
            return Day.Lesson;
           
            
        }
       
    }
}
