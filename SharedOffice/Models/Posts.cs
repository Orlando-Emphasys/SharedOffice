using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharedOffice.Models
{
    public class Posts
    {
        public  int ID { get; set; }

        public int channelID { get; set; }

        public string content { get; set; }

        public int upVotes { get; set; }

        public int downVotes { get; set; }

    }
}