using Alat.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alat.Dtos
{
    public class HttpPostOrPutDto
    {
        public string SendData { get; set; }
        public string BaseUrl { get; set; }
        public string EndPoint { get; set; }
        public List<CustomHeader> CustomHeaders { get; set; }
        public ApiHttpVerbs ApiHttpVerbs
        {
            get
            {
                return ApiHttpVerbs.Post;
            }
            set
            {
                this.ApiHttpVerbs = value;
            }

        }
    }
}
