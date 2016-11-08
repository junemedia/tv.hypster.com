using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hypster_tv.Controllers
{
    public class t2Controller : Controller
    {
        //
        // GET: /t2/
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



    }
}
