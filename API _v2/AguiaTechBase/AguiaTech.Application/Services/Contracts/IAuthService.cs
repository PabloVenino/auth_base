using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguiaTech.Application.Services.Contracts;
public interface IAuthService
{
    Task<BaseServiceResult> Login();
    Task<BaseServiceResult> RefreshToken();
}
