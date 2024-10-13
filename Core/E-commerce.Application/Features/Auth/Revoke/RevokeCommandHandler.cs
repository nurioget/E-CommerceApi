using E_commerce.Application.Interfaces.AutoMapper;
using E_commerce.Application.Interfaces.UnitOfWorks;
using E_commerce.Bases;
using E_commerce.Domain.Entities;
using E_commerce.Features.Auth.Rules;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Features.Auth.Revoke
{
    public class RevokeCommandHandler : BaseHandler, IRequestHandler<RevokeCommandRequest, Unit>
    {
        private readonly UserManager<User> _userManager;
        private readonly AuthRules _authRules;
        public RevokeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, AuthRules authRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _userManager = userManager;
            _authRules = authRules;
        }

        public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await _userManager.FindByEmailAsync(request.Email);
            await _authRules.EmailAddressShouldBeValid(user);

            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
