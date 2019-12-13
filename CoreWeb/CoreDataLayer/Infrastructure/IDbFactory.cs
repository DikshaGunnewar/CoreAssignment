using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreRepository.Infrastructure
{
    public interface IDbFactory
    {
        DbContext Init();
    }
}
