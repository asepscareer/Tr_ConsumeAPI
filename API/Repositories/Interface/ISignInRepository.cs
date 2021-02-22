﻿using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    interface ISignInRepository
    {
        Task<IEnumerable<SignIn>> Post(SignIn signIn);
    }
}