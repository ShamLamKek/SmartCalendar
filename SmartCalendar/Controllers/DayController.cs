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
        public static List<TimeSpan> AddToList(IWebDriver bs, string id, List<TimeSpan> list)
        {
            for (int i = 0; i < 30; i++)
            {
                try
                {
                    var day = bs.FindElement(By.Id(id + i));
                    string innerhtml = day.GetAttribute("innerHTML");
                    TimeSpan time = TimeSpan.Parse(innerhtml);
                    list.Add(time);

                }
                catch (Exception)
                {
                }

            }
            return list;
        }

    }
}
