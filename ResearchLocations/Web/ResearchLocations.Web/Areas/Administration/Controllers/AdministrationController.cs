namespace ResearchLocations.Web.Areas.Administration.Controllers
{
    using ResearchLocations.Common;
    using ResearchLocations.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
