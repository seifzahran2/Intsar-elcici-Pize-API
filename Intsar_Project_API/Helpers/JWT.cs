﻿namespace Intsar_Project_API.Helpers
{
    public class JWT
    {
        public string Key { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public double DurationInDays { get; set; }

    }
}
