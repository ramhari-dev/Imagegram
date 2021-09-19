using Application.Accounts.Commands.CreateAccount;
using Application.Accounts.Commands.DeleteAccount;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ImagegramAPI.Controllers
{
    public class AccountController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<CreateAccountResult>> Create([FromBody]CreateAccountCommand createAccountCommand)
        {
            return await Mediator.Send(createAccountCommand);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Delete()
        {
            return await Mediator.Send(new DeleteAccountCommand());
        }
    }
}
