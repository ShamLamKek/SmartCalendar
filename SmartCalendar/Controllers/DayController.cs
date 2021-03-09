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
        public static Tuple<List<int>, List<int>> Difference(IWebDriver bs, string id, List<int> list, List<int> list_2)
        {
            for (int i = 0; i < 30; i++)
            {
                try
                {
                    var day = bs.FindElement(By.Id(id + i));
                    list.Add(i);
                }
                catch (Exception)
                {

                }
            }
            for (int i = 1; i < list.Count; i++)
            {

                list_2.Add(list[i] - 1);
            }
            list_2.Add(30);

            return Tuple.Create(list, list_2);
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
        public static Tuple<List<int>, List<int>> AddToListOdd(IWebDriver bs, string id, List<int> list, List<int> list_2)
        {    
        for (int i = 0; i < 30; i++)
        {
            try
            {
                var day = bs.FindElement(By.Id(id + i));
                if (day.Text == "н.")
                {
                        list.Add(i);
                }
                else if (day.Text=="ч.")
                {
                        list_2.Add(i);
                }
                    
            }
            catch (Exception)
            { 
                
            }
        }
            return Tuple.Create(list, list_2);
        }
        public static bool Odd(IWebDriver bs)
        {
            
            var day = bs.FindElement(By.Id("ContentPlaceHolderHeader_Lweek"));
            string text = day.Text;
            if (text.Contains("ЧЕТНАЯ"))
            {
                return true;
            }
            else
                return false;
            
            
        }

        public static IWebDriver Connection()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(new List<string>() { "headless" });
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            IWebDriver bs = new OpenQA.Selenium.Chrome.ChromeDriver(chromeDriverService, chromeOptions);
            bs.Navigate().GoToUrl("http://bgu.ru/telek/timetable.aspx?id=30250");
            return bs;
        }



    }
}
