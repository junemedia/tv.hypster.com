using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hypster_tv.ViewModels
{
    public class getVideoViewModel
    {
        public hypster_tv_DAL.videoClip video = new hypster_tv_DAL.videoClip();
        public List<hypster_tv_DAL.videoComment> comments_list = new List<hypster_tv_DAL.videoComment>();

        public getVideoViewModel()
        {
        }
    }


}