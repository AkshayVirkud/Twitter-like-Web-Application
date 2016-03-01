using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterAplication
{
    /// <summary>
    /// Class for storing Friend Details
    /// </summary>
    public class Friends
    {
        public int UserId { get; set; }

        public int FriendId { get; set; }

        public string FriendName { get; set; }

    }
}