﻿using System;

namespace EmbyStat.Controllers.HelperClasses
{
    public class PersonPosterViewModel
    {
        public string MediaId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? BirthDate { get; set; }
        public int? MovieCount { get; set; }
        public int? ShowCount { get; set; }
        public string Title { get; set; }
        public string Tag { get; set; }
    }
}
