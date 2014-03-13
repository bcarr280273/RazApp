using Mvc.Mailer;

namespace RazApp.Web.Mailers
{ 
    public interface IUserMailer
    {
			MvcMailMessage Welcome();
	}
}