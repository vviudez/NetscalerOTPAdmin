# Netscaler OTP Admin
User TOTP Administration for Netscaler, using a AD service user.

Based on the idea of Andreas Nick (https://www.andreasnick.com/102-otpedit.html), I've build a similar solution for the administration
of seeds on the Active Directory attribute, but instead of the user running the application having admin permissions or attribute modification permissions, we use an Active Directory service user, as an intermediary, just like in Netscaler for LDAP queries. In fact, it could be the same user for both cases.


Main Screen:
![main](https://github.com/user-attachments/assets/baf105f7-372e-4a4a-bd9b-d4a043b96b85)

Add new OTP seed to user:
![new_user_otp](https://github.com/user-attachments/assets/0f2206a7-b9e8-4605-86f3-f61f201e9a56)

Edit user OTP seeds:
![edit_user_otp](https://github.com/user-attachments/assets/a6e8994b-1892-4a49-a9db-83cd4adf3461)

Settings:
![settings](https://github.com/user-attachments/assets/8395ad29-d3b3-4797-b9cf-bae9ef7d1941)


