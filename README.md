# Netscaler OTP Admin
**User TOTP Administration for Netscaler, using a AD service user.**

Based on the idea of Andreas Nick (https://www.andreasnick.com/102-otpedit.html), I've build a similar solution for the administration
of seeds on the Active Directory attribute, but instead of the user running the application having admin permissions or attribute modification permissions, we use an Active Directory service user, as an intermediary, just like in Netscaler for LDAP queries. In fact, it could be the same user for both cases.

## NET Desktop Runtime 8.0
The last release uses **NET Desktop Runtime 8.0**, to allow support native encrypton using AES GCM cipher algorithms.
As a prerequisite it must be installed on your machine, and it can be downloaded from [Microsoft](https://builds.dotnet.microsoft.com/dotnet/WindowsDesktop/8.0.17/windowsdesktop-runtime-8.0.17-win-x64.exe).

## OTP Encryption
Using the info and python code released by Citrix for the [**OTP Encryption Tool**](https://docs.netscaler.com/en-us/citrix-adc/current-release/aaa-tm/authentication-methods/native-otp-authentication/otp-encryption-tool), I made a fist attempt to allow use OTP Encryption from the app. But After some test, I found some problems on the Citrix python code that can't be
replicated using C#. I hope that Citrix can solve the problems to allow complete this feature.


## ScreenShots

**Main Screen:**
![main](https://github.com/user-attachments/assets/62e513c8-7dc6-4d67-b82e-804917818f8a)

**Add new OTP seed to user:**
![new_user_otp](https://github.com/user-attachments/assets/d3a47309-cb0d-44af-9365-e4cc22be7e8a)

**Edit user OTP seeds:**
![edit_user_otp](https://github.com/user-attachments/assets/e23fb3de-d44b-4d91-b052-d6abea758453)

**Settings:**
![settings-1 0 8 2](https://github.com/user-attachments/assets/6b86a99f-294e-4cd4-9214-66e9ce89b7ff)
