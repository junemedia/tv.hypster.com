using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;


namespace hypster_tv.Controllers
{
    public class homeController : Controller
    {
        //----------------------------------------------------------------------------------------------------------
        protected int CLIPS_NUM_PAGE = 12;
        protected int CLIPS_NUM_PAGING = 16;
        //----------------------------------------------------------------------------------------------------------




        //
        // GET: /Home/
        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// this is preview for home page
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 120)]
        public ActionResult Index()
        {
            hypster_tv.ViewModels.HomePageViewModel model = new ViewModels.HomePageViewModel();



            hypster_tv_DAL.videoClipManager videoManager = new hypster_tv_DAL.videoClipManager();
            model.TopVideos = videoManager.getTopRatedVideos_cache(CLIPS_NUM_PAGE);
            model.NewVideos = videoManager.getNewVideos_cache(CLIPS_NUM_PAGE);



            model.NumOfVideos = model.TopVideos.Count;
            double tmp_numPages = (double)model.NumOfVideos / (double)CLIPS_NUM_PAGE;
            if ((tmp_numPages - (int)tmp_numPages) > 0)
                tmp_numPages++;
            model.NumOfPages = (int)tmp_numPages;


            return View(model);
        }
        //----------------------------------------------------------------------------------------------------------







        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// this is paging functionality 
        /// </summary>
        /// <param name="page_id"></param>
        /// <returns></returns>
        [OutputCache(Duration = 120, VaryByParam = "page_id")]
        public ActionResult getPage(int page_id)
        {
            hypster_tv.ViewModels.HomePageViewModel model = new ViewModels.HomePageViewModel();


            int _start = ((page_id * CLIPS_NUM_PAGING) - CLIPS_NUM_PAGING);
            int _end = _start + CLIPS_NUM_PAGING;

            ViewBag.CurrPage = page_id;
            ViewBag.CurrPage_Start = _start;
            ViewBag.CurrPage_End = _end;



            hypster_tv_DAL.videoClipManager videoManager = new hypster_tv_DAL.videoClipManager();
            model.TopVideos = videoManager.getTopRatedVideos_cache();
            model.NewVideos = videoManager.getNewVideos_cache();



            model.NumOfVideos = model.TopVideos.Count;
            double tmp_numPages = (double)model.NumOfVideos / (double)CLIPS_NUM_PAGING;
            if ((tmp_numPages - (int)tmp_numPages) > 0)
                tmp_numPages++;
            model.NumOfPages = (int)tmp_numPages;


            

            return View(model);
        }
        //----------------------------------------------------------------------------------------------------------










    }
}
