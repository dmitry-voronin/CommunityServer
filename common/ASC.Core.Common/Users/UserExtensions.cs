/*
 *
 * (c) Copyright Ascensio System Limited 2010-2016
 *
 * This program is freeware. You can redistribute it and/or modify it under the terms of the GNU 
 * General Public License (GPL) version 3 as published by the Free Software Foundation (https://www.gnu.org/copyleft/gpl.html). 
 * In accordance with Section 7(a) of the GNU GPL its Section 15 shall be amended to the effect that 
 * Ascensio System SIA expressly excludes the warranty of non-infringement of any third-party rights.
 *
 * THIS PROGRAM IS DISTRIBUTED WITHOUT ANY WARRANTY; WITHOUT EVEN THE IMPLIED WARRANTY OF MERCHANTABILITY OR
 * FITNESS FOR A PARTICULAR PURPOSE. For more details, see GNU GPL at https://www.gnu.org/copyleft/gpl.html
 *
 * You can contact Ascensio System SIA by email at sales@onlyoffice.com
 *
 * The interactive user interfaces in modified source and object code versions of ONLYOFFICE must display 
 * Appropriate Legal Notices, as required under Section 5 of the GNU GPL version 3.
 *
 * Pursuant to Section 7 § 3(b) of the GNU GPL you must retain the original ONLYOFFICE logo which contains 
 * relevant author attributions when distributing the software. If the display of the logo in its graphic 
 * form is not reasonably feasible for technical reasons, you must include the words "Powered by ONLYOFFICE" 
 * in every copy of the program you distribute. 
 * Pursuant to Section 7 § 3(e) we decline to grant you any rights under trademark law for use of our trademarks.
 *
*/



namespace ASC.Core.Users
{
    public static class UserExtensions
    {
        public static bool IsOwner(this UserInfo ui)
        {
            if (ui == null) return false;

            var tenant = CoreContext.TenantManager.GetCurrentTenant();
            return tenant != null && tenant.OwnerId.Equals(ui.ID);
        }

        public static bool IsMe(this UserInfo ui)
        {
            return ui != null && ui.ID == SecurityContext.CurrentAccount.ID;
        }

        public static bool IsAdmin(this UserInfo ui)
        {
            return ui != null && CoreContext.UserManager.IsUserInGroup(ui.ID, Constants.GroupAdmin.ID);
        }

        public static bool IsVisitor(this UserInfo ui)
        {
            return ui != null && CoreContext.UserManager.IsUserInGroup(ui.ID, Constants.GroupVisitor.ID);
        }

        public static bool IsOutsider(this UserInfo ui)
        {
            return IsVisitor(ui) && ui.ID == Constants.OutsideUser.ID;
        }

        public static bool IsLDAP(this UserInfo ui)
        {
            if (ui == null) return false;

            return !string.IsNullOrEmpty(ui.Sid);
        }
    }
}
