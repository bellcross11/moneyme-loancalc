using System.Collections.Generic;

namespace LoanCalculator.Application.Web.Helpers
{
    public static class BlackListed
    {
        public static readonly List<string> MobileNumbers = new List<string>() { 
            "09173728431",
            "09452836590",
            "09981216712",
            "09193427979",
            "09473928134"
        };

        public static readonly List<string> EmailDomains = new List<string>() {
            "aol.com",
            "hotmail.co.uk",
            "hotmail.fr",
            "msn.com",
            "live.com"
        };
    }
}