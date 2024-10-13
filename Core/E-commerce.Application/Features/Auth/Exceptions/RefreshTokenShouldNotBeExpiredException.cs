﻿using E_commerce.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Features.Auth.Exceptions
{
    public class RefreshTokenShouldNotBeExpiredException : BaseException
    {
        public RefreshTokenShouldNotBeExpiredException() : base("Oturum süresi sona ermiştir. Lütfen tekrar giriş yapın.") { }
    }
}
