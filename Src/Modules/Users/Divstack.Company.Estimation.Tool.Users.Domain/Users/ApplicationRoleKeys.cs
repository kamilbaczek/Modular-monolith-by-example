namespace Divstack.Company.Estimation.Tool.Users.Domain.Users
{
    public static class ApplicationRoleKeys
    {
        // TODO: Move those magic string to Enum
        public const string SystemAdministrator = "SystemAdministrator"; // System wide administrator
        public const string User = "User";

        private const string Separator = ",";

        public const string AnyAdministrator = SystemAdministrator;


        /// <summary>
        ///     Use for [Authorize(Roles = X)] only!
        /// </summary>
        public const string AllRoles =
            SystemAdministrator + Separator +
            User;

        public static readonly string[] UserRoles =
        {
            User,
        };

        public static readonly string[] SystemAdmins = {SystemAdministrator};
    }
}