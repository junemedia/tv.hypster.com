using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hypster_tv.ViewModels
{
    public class HomePageViewModel
    {
        public int NumOfVideos = 0;
        public int NumOfPages = 1;

        public List<hypster_tv_DAL.videoClip> TopVideos = new List<hypster_tv_DAL.videoClip>();
        public List<hypster_tv_DAL.videoClip> NewVideos = new List<hypster_tv_DAL.videoClip>();


        public HomePageViewModel()
        {
        }



    }
}