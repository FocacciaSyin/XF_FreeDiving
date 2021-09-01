﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF_FreeDiving.Constants
{
    public class GoogleResponseModel
    {
        public string azp { get; set; }
        public string aud { get; set; }
        public string sub { get; set; }
        public string scope { get; set; }
        public string exp { get; set; }
        public string expires_in { get; set; }
        public string email { get; set; }
        public string email_verified { get; set; }
        public string access_type { get; set; }
        public string picture { get; set; }
    }
}