using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hypster_tv.Controllers
{
    public class newsController : Controller
    {


        //
        // GET: /news/
        //----------------------------------------------------------------------------------------------------------
        // cache applied to data select (here need to show random articles)
        public ActionResult GetLatestNews()
        {
            hypster_tv_DAL.newsManagement newsManager = new hypster_tv_DAL.newsManagement();
            List<hypster_tv_DAL.newsPost> news_list = new List<hypster_tv_DAL.newsPost>();
            news_list = newsManager.GetLatestNews_cache(40);
            



            List<hypster_tv_DAL.newsPost> news_list_Display = new List<hypster_tv_DAL.newsPost>();


            int maxPostsNum = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["numberOfPosts_HomePage"]);
            if (news_list.Count > maxPostsNum)
            {
                Random randomGen = new Random();
                do
                {
                    int next_article = randomGen.Next(0, news_list.Count);

                    hypster_tv_DAL.newsPost item = new hypster_tv_DAL.newsPost();
                    item = news_list[next_article];

                    if (!news_list_Display.Contains(item))
                        news_list_Display.Add(item);


                } while (news_list_Display.Count < maxPostsNum);
            }


            return View(news_list_Display);
        }
        //----------------------------------------------------------------------------------------------------------




    }
}
