using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace GadgetStore
{
	[System.Web.Mvc.Authorize]
	[System.Web.Mvc.RoutePrefix("api/Account")]
	public class AccountController : ApiController
	{
		private AppStoreUserManager _userManager;

		public AccountController()
		{
		}

		public AccountController(AppStoreUserManager userManager, ISecureDataFormat<AuthenticationTicket> accessTokenFormat) {
			UserManager = userManager;
			AccessTokenFormat = accessTokenFormat;
		}

		public AppStoreUserManager UserManager
		{
			get {
				return _userManager ?? Request.GetOwinContext().GetUserManager<AppStoreUserManager>();
			}
			set {
				_userManager = value;
			}
		}

		public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

		//POST api/Account/Register
		[System.Web.Mvc.AllowAnonymous]
		[System.Web.Mvc.Route("Register")]
		public async Task<IHttpActionResult> Register(AppStoreUser model) {
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}

			var user = new AppStoreUser() { UserName = model.UserName, Email = model.Email}

			IdentityResult result = await UserManager.CreateAsync(user, model.PasswordHash);

			if (!result.Succeeded) {
				return GetErrorResult(result);
			}

			return Ok();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && _userManager != null)
			{
				_userManager.Dispose();
				_userManager = null;
			}

			base.Dispose(disposing);
		}


		private IAuthenticationManager Authentication
		{
			get { return Request.GetOwinContext().Authentication; }
		}

		private IHttpActionResult GetErrorResult(IdentityResult result)
		{
			if (result == null)
			{
				return InternalServerError();
			}

			if (!result.Succeeded)
			{
				if (result.Errors != null)
				{
					foreach (string error in result.Errors)
					{
						ModelState.AddModelError("", error);
					}
				}

				if (ModelState.IsValid)
				{
					// No ModelState errors are available to send, so just return an empty BadRequest.
					return BadRequest();
				}

				return BadRequest(ModelState);
			}

			return null;
		}
	}
}
