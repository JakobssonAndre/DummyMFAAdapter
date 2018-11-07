using Microsoft.IdentityServer.Web.Authentication.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MFAAdapter
{
    public class DummyAdapterPresentation : IAdapterPresentation
    {
        private HttpListenerRequest request;
        private ExternalAuthenticationException ex;
        private IAuthenticationContext context;
        private IProofData proofData;
        private Claim[] claims;
        private Claim identityClaim;

        public DummyAdapterPresentation(HttpListenerRequest request, ExternalAuthenticationException ex)
        {
            this.request = request;
            DummyLogger.Log(string.Format("ServiceName: {0}, Uri: {1}, UserHostName: {2}, UserHostAddress: {3}", request.ServiceName, request.Url.AbsoluteUri, request.UserHostName, request.UserHostAddress));
            this.ex = ex;
            DummyLogger.Log(string.Format("ExternalAuthenticationException: {0}", ex.Message));
        }

        public DummyAdapterPresentation(Claim identityClaim, HttpListenerRequest request, IAuthenticationContext context)
        {
            this.identityClaim = identityClaim;
            DummyLogger.Log(string.Format("Issuer: {0}, Subject.Name: {1}, Subject.NameClaimType: {2}, Subject.RoleClaimType: {3}", identityClaim.Issuer, identityClaim.Subject.Name, identityClaim.Subject.NameClaimType, identityClaim.Subject.RoleClaimType));
            this.request = request;
            DummyLogger.Log(string.Format("ServiceName: {0}, Uri: {1}, UserHostName: {2}, UserHostAddress: {3}", request.ServiceName, request.Url.AbsoluteUri, request.UserHostName, request.UserHostAddress));
            this.context = context;
            DummyLogger.Log(string.Format("ActivityId: {0}, ContextId: {1}, Lcid: {2}", context.ActivityId, context.ContextId, context.Lcid));
        }

        public DummyAdapterPresentation(IAuthenticationContext context, IProofData proofData, HttpListenerRequest request, out Claim[] claims)
        {
            this.context = context;
            DummyLogger.Log(string.Format("ActivityId: {0}, ContextId: {1}, Lcid: {2}", context.ActivityId, context.ContextId, context.Lcid));
            this.proofData = proofData;
            DummyLogger.Log(string.Format("ProofData: {0}", proofData.Properties.Count));
            this.request = request;
            DummyLogger.Log(string.Format("ServiceName: {0}, Uri: {1}, UserHostName: {2}, UserHostAddress: {3}", request.ServiceName, request.Url.AbsoluteUri, request.UserHostName, request.UserHostAddress));
            this.claims = new Claim[1];
            this.claims[0] = new Claim("dummyType", "dummyValue");
            claims = this.claims;
            DummyLogger.Log(string.Format("Claims: {0}", claims.Length));
        }

        public string GetPageTitle(int lcid)
        {
            DummyLogger.Log(string.Format("IAdapterPresentation.GetPageTitle: {0}", lcid));
            return string.Empty;
        }
    }
}
