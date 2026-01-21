// Question 7: 

using System;

namespace Day18_Practice
{
    public class EstimateDetails
    {
        public float ConstructionArea { get; set; }
        public float SiteArea { get; set; }
    }

    public class ConstructionEstimateException : Exception
    {
        public ConstructionEstimateException(string message) : base(message)
        {
        }
    }
}
