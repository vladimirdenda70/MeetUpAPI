using MeetUpAPI.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetUpAPI.Identity
{
    public interface IJwtProvider
    {
        string GenerateJwtToken(User user);
    }
}
