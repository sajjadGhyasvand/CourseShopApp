using System;
using System.Collections.Generic;
using System.Text;
using GhiasAmooz.Core.DTOs;
using GhiasAmooz.DataLayer.Entities.User;
using GhiasAmooz.DataLayer.Entities.Wallet;

namespace GhiasAmooz.Core.Services.Interfaces
{
   public interface IUserService
   {
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        int AddUser(User user);
        User LoginUser(LoginViewModel login);
        User GetUserByEmail(string email);
        User getUserByUserID(int userId);
        User GetUserByActiveCode(string activeCode);
        User GetUserByUserName(string username);
        void UpdateUser(User user);
        bool ActiveAccount(string activeCode);
        int GetUserIdByUserName(string userName);
        void DeleteUser(int userId);
        #region User Panel

        InformationUserViewModel GetUserInformation(string username);
        InformationUserViewModel GetUserInformation(int userId);
        SideBarUserPanelViewModel GetSIdeBarUserPanelData(string username);
        EditProfileViewModel GetDataForEditProfileUser(string username);
        void EditProfile(string username, EditProfileViewModel profile);
        bool ComparePassword(string oldPassword, string userName);
        void ChangeUserPassword(string userName, string newPassword);
        #endregion

        #region Wallet
        int BalanceUserWallet(string userName);
        int ChargeWallet(string userName, int amount, string description, bool isPay = false);
        int AddWallet(Wallet wallet);
        List<WalletViewModel> GetWalletUser(string userName);
        Wallet GetWWalletByWalletId(int walletId);
        void UpdateWallet(Wallet wallet);
        #endregion
        #region AdminPanel

        UsersForAdminViewModel GetUsers(int pageId = 1,string filterEmail = "",string filterUserName = "");
        UsersForAdminViewModel GetDelteUsers(int pageId = 1,string filterEmail = "",string filterUserName = "");

        int AddUserFromAdmin(CreateUserViewModel user);
        EditUserViewModel GetUserForShowInEditMode(int userId);

        void EditUserFromAdmin(EditUserViewModel editUser);
        #endregion
    }
}
