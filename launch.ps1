$adminUser = "mytest\admin user"
$adminPassword = ConvertTo-SecureString "Password" -AsPlainText -Force
$mycreds = New-Object System.Management.Automation.PSCredential -ArgumentList $AdminUser, $AdminPassword
Start-Process -FilePath "C:\Tool\Account Tool 2.1.exe" -Credential $mycreds -WorkingDirectory "C:\Tool\"
