using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterAplication
{
    /// <summary>
    /// Class for storing Tweet details
    /// </summary>
    public class Tweet
    {
        public int TweetId { get; set; }

        public string TweetContent { get; set; }

        public string TweetUserName { get; set; }
    }
}