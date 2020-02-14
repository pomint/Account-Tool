using System;
using System.DirectoryServices.AccountManagement;
using System.Windows;

namespace Account_Tool_2._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Checkuser_Click(object sender, RoutedEventArgs e)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            // find a user
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, Username.Text);

            if (user != null)
            {
                MessageBox.Show(string.Format("User: {0}{1}Locked : {2}{3}Enabled: {4}{5}Last logged On: {6}{7}LockedOut Time: {8}{9}", user.SamAccountName, Environment.NewLine, user.IsAccountLockedOut(), Environment.NewLine, user.Enabled, Environment.NewLine, user.LastLogon, Environment.NewLine, user.AccountLockoutTime, Environment.NewLine), "Results");
            }
            else
            {
                MessageBox.Show("User not found, Try again.");
            }
        }

        private void UnlockAccount_Click(object sender, RoutedEventArgs e)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            // find a user
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, Username.Text);
            try
            {
                if (user != null)
                {
                    user.UnlockAccount();
                    MessageBox.Show("User Unlocked.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please input a user and try again.");
            }
        }

        private void EnableUser_Click(object sender, RoutedEventArgs e)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            // find a user
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, Username.Text);
            try
            {
                user.Enabled = true;

                user.Save();
                //MessageBox.Show("User Enabled.");
                MessageBox.Show("User Enabled!" + Environment.NewLine + Environment.NewLine + string.Format("User: {0}{1}Locked : {2}{3}Enabled: {4}{5}Last logged On: {6}{7}LockedOut Time: {8}{9}", user.SamAccountName, Environment.NewLine, user.IsAccountLockedOut(), Environment.NewLine, user.Enabled, Environment.NewLine, user.LastLogon, Environment.NewLine, user.AccountLockoutTime, Environment.NewLine), "Results");
            }
            catch (Exception)
            {
                MessageBox.Show("Please input a user and try again.");
            }
        }

        private void DisableUser_Click(object sender, RoutedEventArgs e)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            // find a user
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, Username.Text);
            try
            {
                user.Enabled = false;

                user.Save();
                //MessageBox.Show("User Disabled.");
                MessageBox.Show("User Disabled!" + Environment.NewLine + Environment.NewLine + string.Format("User: {0}{1}Locked : {2}{3}Enabled: {4}{5}Last logged On: {6}{7}LockedOut Time: {8}{9}", user.SamAccountName, Environment.NewLine, user.IsAccountLockedOut(), Environment.NewLine, user.Enabled, Environment.NewLine, user.LastLogon, Environment.NewLine, user.AccountLockoutTime, Environment.NewLine), "Results");
            }
            catch (Exception)
            {
                MessageBox.Show("Please input a user and try again.");
            }
        }

        private void ExitTool_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void SetPassword_Click(object sender, RoutedEventArgs e)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            // find a user
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, Username.Text);
            String SetNewPassword = NewPassword.Password;
            try
            {
                user.SetPassword(SetNewPassword);

                user.Save();
                user.ExpirePasswordNow();
                MessageBox.Show("Password Changed.");
            }
            catch (Exception)
            {
                MessageBox.Show("Please input a user,check if your password meets the requirements and try again.");
            }
        }
    }
}
