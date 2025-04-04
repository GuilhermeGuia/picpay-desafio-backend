using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPicPay.Exception.ExceptionBase;

public class UnaAuthorizedException : DesafioPicPayException
{
    public UnaAuthorizedException() : base(ResourceMessageExceptions.UNAUTHORIZED_TRANSACTION) { }
    public override IList<string> GetErrorMessages() => [Message];
    public override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized;
}
