using Microsoft.IdentityServer.Web.Authentication.External;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MFAAdapter
{
    public class DummyAdapter : IAuthenticationAdapter
    {
        public IAuthenticationAdapterMetadata Metadata
        {
            get
            {
                DummyLogger.Log("IAuthenticationAdapter.Metadata returning DummyAdapterMetadata");
                return new DummyAdapterMetadata();
            }
        }

        public IAdapterPresentation BeginAuthentication(Claim identityClaim, HttpListenerRequest request, IAuthenticationContext context)
        {
            DummyLogger.Log("IAuthenticationAdapter.BeginAuthentication");
            return new DummyAdapterPresentation(identityClaim, request, context);
        }

        public bool IsAvailableForUser(Claim identityClaim, IAuthenticationContext context)
        {
            DummyLogger.Log("IAuthenticationAdapter.IsAvailableForUser");
            DummyLogger.Log(string.Format("", identityClaim.Issuer));
            DummyLogger.Log(string.Format("ActivityId: {0}, ContextId: {1}, Lcid: {2}", context.ActivityId, context.ContextId, context.Lcid));
            return false;
        }

        public void OnAuthenticationPipelineLoad(IAuthenticationMethodConfigData configData)
        {
            DummyLogger.Log("IAuthenticationAdapter.OnAuthenticationPipelineLoad");
        }

        public void OnAuthenticationPipelineUnload()
        {
            DummyLogger.Log("IAuthenticationAdapter.OnAuthenticationPipelineUnload");
        }

        public IAdapterPresentation OnError(HttpListenerRequest request, ExternalAuthenticationException ex)
        {
            DummyLogger.Log("IAuthenticationAdapter.OnError");
            return new DummyAdapterPresentation(request, ex);
        }

        public IAdapterPresentation TryEndAuthentication(IAuthenticationContext context, IProofData proofData, HttpListenerRequest request, out Claim[] claims)
        {
            DummyLogger.Log("IAuthenticationAdapter.TryEndAuthentication");
            return new DummyAdapterPresentation(context, proofData, request, out claims);
        }
    }
}
