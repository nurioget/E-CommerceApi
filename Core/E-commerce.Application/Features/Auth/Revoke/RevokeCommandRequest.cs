using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Features.Auth.Revoke
{
    public class RevokeCommandRequest :IRequest<Unit>
    {
        public string Email { get; set; }
    }
}
