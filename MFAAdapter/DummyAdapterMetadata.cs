using Microsoft.IdentityServer.Web.Authentication.External;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFAAdapter
{
    public class DummyAdapterMetadata : IAuthenticationAdapterMetadata
    {
        public string[] AuthenticationMethods { get; set; }

        public string[] IdentityClaims { get; set; }

        public string AdminName { get; set; }

        public int[] AvailableLcids { get; set; }

        public Dictionary<int, string> Descriptions { get; set; }

        public Dictionary<int, string> FriendlyNames { get; set; }

        public bool RequiresIdentity { get; set; }

        public DummyAdapterMetadata()
        {
            AuthenticationMethods = new string[] { "dummyAuthenticationMethod" };
            IdentityClaims = new string[] { "dummyIdentityClaim" };
            AdminName = "dummyAdmin";
            AvailableLcids = new int[] { new CultureInfo("en-us").LCID };
            Descriptions = new Dictionary<int, string>();
            Descriptions.Add(new CultureInfo("en-us").LCID, "dummyDescription");
            FriendlyNames = new Dictionary<int, string>();
            FriendlyNames.Add(new CultureInfo("en-us").LCID, "dummyFriendName");
        }
    }
}
