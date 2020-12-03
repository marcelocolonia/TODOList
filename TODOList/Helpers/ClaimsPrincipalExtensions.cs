using System.Security.Claims;

namespace TODOList.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var userIdAsString = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

            int.TryParse(userIdAsString, out int userId);

            return userId;
        }
    }
}
